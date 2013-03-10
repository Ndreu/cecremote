// This file is part of CECRemote.
//
// CECRemote is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
//
// CECRemote is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with CECRemote. If not, see <http://www.gnu.org/licenses/>.


using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Timers;
using CecSharp;

namespace CecRemote.Base
{


  public class CecClientBase : CecCallbackMethods
  {

    #region dllimports
    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

    // For sending left shift key to terminate screensaver/wake up tv from powersave
    const int KEYEVENTF_KEYUP = 0x2;
    public const byte VK_LSHIFT = 0xA0;
    #endregion


    private LibCecSharp _lib;
    private DateTime _keyTimeStamp;
    private LibCECConfiguration _libConfig;

    private volatile bool _keyDown;
    private bool _fastScrolling;
    private ushort _fastScrollingKeyCount;

    CecKeypress _currentButton;
    private int _currentKeycode;
    private ushort _keyCount;

    private bool _wakeUpByAutoEvent;
    private bool _extensiveLogging;
    private bool _disableScreensaver;
    private bool _requireDelayBetweenKeys;

    private System.Timers.Timer _repeatTimer;

    private CecConfigBase _cecConfig;
    private Object _connectLock = new Object();
    private bool _connected;

    public CecClientBase() { }

    public void SetConfig(CecConfigBase conf)
    {
      _cecConfig = conf;
    }

    public void Init()
    {

      _keyTimeStamp = DateTime.Now;
      _connected = false;
      _keyDown = false;
      _keyCount = 0;
      _currentKeycode = 0;
      _wakeUpByAutoEvent = true; // Assume that user is not present. Set to false after user input.

      _currentButton = new CecKeypress(CecUserControlCode.Unknown, 0);

      LoadConfig();

    }


    public virtual void DeInit()
    {
      if (_lib != null)
      {
        _lib.DisableCallbacks();
        _lib.Close();
        _lib.Dispose();
      }

      _connected = false;

      _lib = null;
      _libConfig = null;
      _cecConfig = null;
      _repeatTimer = null;
    }

    public virtual void LoadConfig()
    {
      WriteLog("Loading configuration...");

      if (_cecConfig == null)
      {
        WriteLog("Configuration not set, abort");
        return;
      }

      _fastScrolling = _cecConfig.FastScrolling;
      _fastScrollingKeyCount = _cecConfig.FastScrollingRepeatDelay;
      _repeatTimer = new System.Timers.Timer(_cecConfig.FastScrollingRepeatRate);

      _extensiveLogging = _cecConfig.ExtensiveLogging;
      _disableScreensaver = _cecConfig.DisableScreensaver;
      _requireDelayBetweenKeys = _cecConfig.RequireDelayBetweenKeys;

      if (_fastScrolling)
      {
        _repeatTimer.Elapsed += new ElapsedEventHandler(OnRepeatKeyPressEvent);
        _repeatTimer.AutoReset = true;
      }


      // Build configuration for new Lib

      try
      {
        if (_libConfig == null)
        {
          _libConfig = new LibCECConfiguration();
          _libConfig.SetCallbacks(this);
        }
        
        _libConfig.DeviceTypes.Types[0] = _cecConfig.DeviceType;
        _libConfig.DeviceName = _cecConfig.OsdName;
        _libConfig.ClientVersion = _cecConfig.ClientVersion;
        _libConfig.WakeDevices.Clear();
        _libConfig.PowerOffDevices.Clear();
        _libConfig.PhysicalAddress = 0;
        _libConfig.ActivateSource = false;  // Control this manually based on settings.
        _libConfig.HDMIPort = (byte)_cecConfig.HdmiPort;
        _libConfig.BaseDevice = _cecConfig.ConnectedTo;
        _libConfig.AutodetectAddress = true;

        WriteLog("Configuration loaded succesfully.");

        if (_lib == null)
        {
          _lib = new LibCecSharp(_libConfig);
          WriteLog("Lib created succesfully.");
        }
        else
        {
          _lib.SetConfiguration(_libConfig);
          _lib.EnableCallbacks(this);
          WriteLog("Lib configuration updated");
        }
      }
      catch (Exception ex)
      {
        WriteLog("Could not configure libCec." + ex.ToString());
        throw;
      }

    }


    /// <summary>
    /// Opens connection to first available CEC-adapter.
    /// </summary>
    private bool Connect(int timeout = 10000)
    {
      WriteLog("Opening connection to CEC-Adapter...");

      if (_lib == null)
      {
        WriteLog("Unable to connect, library (libCEC) doesn't exist!");
        return false;
      }

      CecAdapter[] adapters = _lib.FindAdapters(string.Empty);
      if (adapters.Length > 0)
      {
        // We will use the first available adapter
        return Connect(adapters[0].ComPort, timeout);
      }
      else
      {
        WriteLog("Unable to find free adapter. Adapter not connected or in use by other process?");
        return false;
      }
    }

    private bool Connect(string port, int timeout)
    {
      bool conn = _lib.Open(port, timeout);

      if (conn)
      {
        WriteLog("Connected succesfully to CEC-adapter on port: " + port);

        if (_extensiveLogging)
        {
          WriteLog("TV vendor: " + _lib.GetDeviceVendorId(CecLogicalAddress.Tv).ToString());
          WriteLog("AVR connected: " + _lib.IsActiveDevice(CecLogicalAddress.AudioSystem).ToString() + " vendor: " 
            + _lib.GetDeviceVendorId(CecLogicalAddress.AudioSystem));
        }
      }
      else
      {
        WriteLog("Connection to adapter on port: " + port + " failed");
      }

      return conn;
    }


    /// <summary>
    /// Send "Power ON" -signal to multiple devices.
    /// </summary>
    public bool WakeDevice(CecLogicalAddresses device)
    {
      bool ret = true;

      foreach (CecLogicalAddress a in device.Addresses)
      {
        if (a != CecLogicalAddress.Unknown)
        {
          if (!WakeDevice(a))
          {
            ret = false;
          }
        }
      }

      return ret;
    }


    /// <summary>
    /// Send "Power ON" -signal to device.
    /// </summary>
    public bool WakeDevice(CecLogicalAddress device)
    {
      bool res = _lib.PowerOnDevices(device);

      WriteLog("Wake " + device.ToString() + " ... " + (res ? "Done." : "Failed.")); 

      return res;
    }


    /// <summary>
    /// Send "Stand by" -signal to multiple devices.
    /// </summary>
    public bool StandByDevice(CecLogicalAddresses device)
    {
      bool ret = true;

      foreach (CecLogicalAddress a in device.Addresses)
      {
        if (a != CecLogicalAddress.Unknown)
        {
          if (!StandByDevice(a))
          {
            ret = false;
          }
        }
      }

      return ret;
    }

    /// <summary>
    /// Send "Stand by" -signal to device.
    /// </summary>
    public bool StandByDevice(CecLogicalAddress device)
    {
      bool res = _lib.StandbyDevices(device);

      WriteLog("Put " + device.ToString() + " to standby mode ... " + (res ? "Done." : "Failed."));

      return res;
    }

    public bool SetSource(bool active)
    {
      if (active)
      {
        WriteLog("Sent active source.");
        return _lib.SetActiveSource(CecDeviceType.Reserved);
      }

      WriteLog("Sent inactive source.");
      return _lib.SetInactiveView(); 
    }


    /// <summary>
    /// This method is called every time there is a log message
    /// from libCec or from the client. Override this
    /// to redirect log messages to file, etc.
    /// </summary>
    protected virtual void WriteLog(string message) { }



    public bool OnStart()
    {
     
      lock (_connectLock)
      {
        // If lib is not created, it needs to be initialized first.
        if (_lib == null)
        {
          Init();
        }

        // 10000 is default timeout to wait connection to open.
        if (!Connect(10000))
        {
          return false;
        }
        else
        {
          _connected = true;
        }

        if (_cecConfig.WakeDevicesOnStart)
        {
          WakeDevice(_cecConfig.OnStartWakeDevices);
        }

        // Set this client as a active source(Changes TV input, etc.), if set in config.
        if (_cecConfig.ActivateSourceOnStart)
        {
          SetSource(true);
        }

        _wakeUpByAutoEvent = false;
      }

      return true;

    }

    public void OnStop()
    {
      lock (_connectLock)
      {
        if (_lib == null)
        {
          DeInit();
          return;
        }

        _lib.DisableCallbacks();

        if (_cecConfig.InactivateSourceOnExit)
        {
          SetSource(false);
        }

        if (_cecConfig.StandbyDevicesOnExit)
        {
          StandByDevice(_cecConfig.OnExitStandbyDevices);
        }

        DeInit();
      }
    }

    public void OnSleep()
    {
      lock (_connectLock)
      {

        if (_lib == null)
        {
          DeInit();
          return;
        }

        _lib.DisableCallbacks();

        if (_cecConfig.InactivateSourceOnSleep)
        {
          SetSource(false);
        }

        if (_cecConfig.StandbyDevicesOnSleep)
        {
          StandByDevice(_cecConfig.OnSleepStandbyDevices);
        }
        
        DeInit();
      }
    }

    public void OnResumeByUser()
    {
      lock (_connectLock)
      {

        if (_lib == null || _connected == false)
        {
          OnResumeByAutomatic();
        }

        if (_cecConfig.RequireUserInputOnResume)
        {
          if (_cecConfig.WakeDevicesOnResume)
          {
            WakeDevice(_cecConfig.OnResumeWakeDevices);
          }
          // Set this client as a active source(Changes TV input, etc.), if set in config.

          if (_cecConfig.ActivateSourceOnResume)
          {
            SetSource(true);
          }
        }
        _wakeUpByAutoEvent = false;
      }
    }

    public void OnResumeByAutomatic()
    {
      lock (_connectLock)
      {

        // If lib is not created, it needs to be initialized first.
        if (_lib == null)
        {
          Init();
        }

        if (!_connected)
        {
          // 10000 is default timeout to wait connection to open.
          if (Connect(10000))
          {
            _connected = true;
          }
          else
          {
            return;
          }
        }

        if (!_cecConfig.RequireUserInputOnResume)
        {
          if (_cecConfig.WakeDevicesOnResume)
          {
            WakeDevice(_cecConfig.OnResumeWakeDevices);
          }
          // Set this client as a active source(Changes TV input, etc.), if set in config.

          if (_cecConfig.ActivateSourceOnResume)
          {
            SetSource(true);
          }
        }

      }
     
    }


    public override int ReceiveCommand(CecCommand command)
    {

      if (command.Opcode == CecSharp.CecOpcode.UserControlRelease)
      {
        _repeatTimer.Stop();
        _keyDown = false;
        _currentKeycode = 0;
        _keyCount = 0;
      }
      else if (command.Opcode == CecSharp.CecOpcode.UserControlPressed)
      {
        _keyDown = true;
      }

      // Fix for some play/stop keys
      else if ((command.Opcode == CecOpcode.Play || command.Opcode == CecOpcode.DeckControl)
          && command.Initiator == CecLogicalAddress.Tv && command.Parameters.Size == 1)
      {
        if (command.Opcode == CecOpcode.Play)
        {
          if (command.Parameters.Data[0] == 0x24)
          {
            KeyPress((int)CecUserControlCode.Play);
          }
          else if (command.Parameters.Data[0] == 0x25)
          {
            KeyPress((int)CecUserControlCode.Pause);
          }
          else
          {
            KeyPress((int)CecUserControlCode.Pause);
          }
        }
        else
        {
           KeyPress((int)CecUserControlCode.Stop); 
        }
      }


      else if (command.Opcode == CecOpcode.Standby && command.Initiator == CecLogicalAddress.Tv)
      {
        WriteLog("TV: Standby.");

        if (_cecConfig.SendTvPowerOff)
        {
          if (_cecConfig.SendTvPowerOffOnlyIfActiveSource && !_lib.IsLibCECActiveSource())
          {
            WriteLog("TVPowerOff button not sent, MediaPortal active source state is: " + _lib.IsLibCECActiveSource().ToString());
          }
          else
          {
            WriteLog("TVPowerOff button sent.");
            KeyPress((int)CecUserControlCode.PowerOffFunction);
          }
        }
      }


      if (_extensiveLogging)
      {
        string opcode = String.Empty;
        string param = String.Empty;

        if (command.OpcodeSet)
        {
          opcode = command.Opcode.ToString();
        }

        for (short i = 0; i < command.Parameters.Size; i++)
        {
          param += String.Format("{0:X}", command.Parameters.Data[i]);
        }

        string msg = "Command: " + opcode;

        if (param.Length > 0)
        {
          msg += " Parameters: " + param;
        }

        WriteLog(msg);
      }
      
      return 1;
    }

    public override int ReceiveKeypress(CecKeypress key)
    {
      int keyCode = (int)key.Keycode;

      if (_extensiveLogging)
      {
        WriteLog(String.Format("Button: {0} Code: {1} Duration: {2}", key.Keycode.ToString(), keyCode, key.Duration));
      }

      if (key.Duration != 0)
      {
        if (_currentButton.Keycode == key.Keycode && _currentButton.Duration == 0)
        {
          _currentButton = key;
          return 1;
        }
      }

      if (_requireDelayBetweenKeys)
      {
        DateTime current = DateTime.Now;
        TimeSpan temp = current.Subtract(_keyTimeStamp);

        if (temp.TotalMilliseconds < _cecConfig.DelayBetweenKeys)
        {
          if (_extensiveLogging)
          {
            WriteLog("Button press ignored. Last button was received " + temp.TotalMilliseconds.ToString() +
              " milliseconds ago and required delay is " + _cecConfig.DelayBetweenKeys.ToString() + " milliseconds.");

            return 1;
          }
        }

        _keyTimeStamp = current;
      }

      if (_fastScrolling)
      {
        if (_currentButton.Keycode == key.Keycode)
        {
          if (_keyCount == _fastScrollingKeyCount && _keyDown == true)
          {
            _currentKeycode = (int)key.Keycode;
            _repeatTimer.Enabled = true;

            if (_extensiveLogging)
            {
              WriteLog("FastScrolling enabled, starting button repeat with repeat rate: " + _cecConfig.FastScrollingRepeatRate.ToString());
            }

            return 1;
          }
          else
          {
            _keyCount++;
          }
        }
        else
        {
          _keyCount = 0;
          _repeatTimer.Enabled = false;
        }
      }
      
      KeyPress(keyCode);

      // Disable screensaver and wake "monitor" after waketimer by sending shift key. TODO: find a better way
      if (_disableScreensaver || _wakeUpByAutoEvent)
      {
        keybd_event(VK_LSHIFT, 0x2A, 0, 0);
        keybd_event(VK_LSHIFT, 0xAA, KEYEVENTF_KEYUP, 0);
      }

      _currentButton = key;

      return 1;

    }

    public override int ReceiveLogMessage(CecLogMessage message)
    {
      return 1;
    }

    public override int ConfigurationChanged(LibCECConfiguration config)
    {
      _libConfig = config;
      WriteLog("Configuration updated from libcec.");

      if (_extensiveLogging)
      {
        WriteLog("Autodetected hdmi port: " + _libConfig.AutodetectAddress.ToString());
      }

      return 1;
    }

    public override int ReceiveAlert(CecAlert alert, CecParameter data)
    {
      WriteLog("Received libcec Alert: " + alert.ToString());
      return 1;
    }

    public override void SourceActivated(CecLogicalAddress logicalAddress, bool activated)
    {
      WriteLog("HDMI-device: " + logicalAddress.ToString() + " was " + (activated ? "activated." : "deactivated."));

      if (activated)
      { // MediaPortal becomes active source
        KeyPress(310);
      }
      else
      { // MediaPortal was deactivated
        KeyPress(311);
      }
    }

    private void OnRepeatKeyPressEvent(object source, ElapsedEventArgs e)
    {
      KeyPress(_currentKeycode);
    }

    protected virtual void KeyPress(int keycode)
    {
    }

  }
}
