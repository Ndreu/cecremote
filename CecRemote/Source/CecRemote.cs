// CECRemote
//
// Copyright (C) 2012, CECRemote team
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using MediaPortal.GUI.Library;
using MediaPortal.Dialogs;
using MediaPortal.Utils;
using MediaPortal.Util;
using MediaPortal.Configuration;
using MediaPortal.Common.Utils;
using MediaPortal.InputDevices;
using MediaPortal.Profile;
using Microsoft.Win32;

namespace CecRemote
{

    [PluginIcons("CecRemote.Resources.cecremotelogo.png", "CecRemote.Resources.cecremotelogo_disabled.png")]
    public class CecRemote : ISetupForm, IPlugin, IPluginReceiver
    {

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
           int dwExtraInfo);


 

        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;
        public const byte VK_LSHIFT = 0xA0;


        private const int WM_POWERBROADCAST = 0x0218;
        const int PBT_APMSUSPEND = 0x0004;
        const int PBT_APMRESUMEAUTOMATIC = 0x0012;
        const int PBT_APMRESUMESUSPEND = 0x0007;

        #region members

        private CecConfig _config;
        private bool _fastScrolling;
        private int _keyDownDelay;

        private StopWatch _keyDownTimer;
        private CecClient _client;
        private InputHandler _remoteHandler;
        private Thread _repeatCommand;
        private volatile bool _keyDown;
        private volatile bool _scrolling;
        private int _currentKey;
        private int _previousKey;
        #endregion


        #region ISetupForm Members

        // Returns the name of the plugin which is shown in the plugin menu
        public string PluginName()
        {
            return "CecRemote";
        }

        // Returns the description of the plugin is shown in the plugin menu
        public string Description()
        {
            return "CecRemote";
        }

        // Returns the author of the plugin which is shown in the plugin menu
        public string Author()
        {
            return "Tuomas, Springfield";
        }

        // show the setup dialog
        public void ShowPlugin()
        {
            CecSettings settings = new CecSettings();
            settings.StartPosition = FormStartPosition.CenterParent;
            settings.ShowDialog();
        }

        // Indicates whether plugin can be enabled/disabled
        public bool CanEnable()
        {
            return true;
        }

        // Get Windows-ID
        public int GetWindowId()
        {
            // WindowID of windowplugin belonging to this setup
            // enter your own unique code
            return -1;
        }

        // Indicates if plugin is enabled by default;
        public bool DefaultEnabled()
        {
            return true;
        }

        // indicates if a plugin has it's own setup screen
        public bool HasSetup()
        {
            return true;
        }

        /// <summary>
        /// If the plugin should have it's own button on the main menu of MediaPortal then it
        /// should return true to this method, otherwise if it should not be on home
        /// it should return false
        /// </summary>
        /// <param name="strButtonText">text the button should have</param>
        /// <param name="strButtonImage">image for the button, or empty for default</param>
        /// <param name="strButtonImageFocus">image for the button, or empty for default</param>
        /// <param name="strPictureImage">subpicture for the button or empty for none</param>
        /// <returns>true : plugin needs it's own button on home
        /// false : plugin does not need it's own button on home</returns>

        public bool GetHome(out string strButtonText, out string strButtonImage,
          out string strButtonImageFocus, out string strPictureImage)
        {
            strButtonText = String.Empty;
            strButtonImage = String.Empty;
            strButtonImageFocus = String.Empty;
            strPictureImage = String.Empty;
            return false;
        }

        // With GetID it will be an window-plugin / otherwise a process-plugin
        // Enter the id number here again


        #endregion

        public void Start()
        {

            _currentKey = -1;
            _previousKey = -1;
            _keyDown = false;

            // Create configuration instance and read current configuration
            Log.Info("CecRemote: Loading configuration...");
            _config = new CecConfig();
            _config.ReadConfig(Defaults.CONFIG);
            Log.Info("CecRemote: Configuration loaded.");

            _fastScrolling = _config.FastScrolling;
            _keyDownDelay = _config.KeyDownDelay;

            // Connect to client and start receiving commands
            connectClient(false);
           
        }


        public void Stop()
        {
            Log.Info("CecRemote: Closing connection to client...");

            try
            {
                if (_client != null)
                {
                    _client.Close();
                    _client = null;
                    Log.Info("CecRemote: Client closed.");
                }
                else
                {
                    Log.Info("CecRemote: Client already disconnected!");
                }


                if (_repeatCommand != null)
                {
                    if (_repeatCommand.IsAlive)
                    {
                        _repeatCommand.Abort();
                    }

                    _repeatCommand = null;
                }
            }
            catch (Exception ex)
            {
                Log.Error("CecRemote: Client was not properly closed! {0}", ex.ToString());
                throw;
            }

            Log.Info("CecRemote: Plugin exit.");

        }

        private void connectClient(bool activateSource = true)
        {
            if (_client != null)
            {
                if (activateSource)
                {
                    _client.sendActiveSource();
                }

                return;
            }
                
            CecSharp.CecLogLevel level;

            switch ((MediaPortal.Services.Level)_config.LogLevel)
            {
                /*
                case MediaPortal.Services.Level.Error:
                    level = CecSharp.CecLogLevel.Error;
                    break;
                case MediaPortal.Services.Level.Warning:
                    level = CecSharp.CecLogLevel.Warning;
                    break;
                case MediaPortal.Services.Level.Information:
                    level = CecSharp.CecLogLevel.Notice;
                    break;
                */
                case MediaPortal.Services.Level.Debug:
                    level = CecSharp.CecLogLevel.Debug;
                    break;
                default:
                    level = CecSharp.CecLogLevel.None;
                    break;
            }

            Log.Info("CecRemote: LibCec log level set to: " + level.ToString());


            _client = new CecClient("MediaPortal", _config.CecType, level, (byte)_config.HdmiPort, activateSource);

            _client.CecRemoteKeyEvent += new CecRemoteKeyEventHandler(oCecRemote_CecRemoteKeyEvent);
            _client.CecRemoteLogEvent += new CecRemoteLogEventHandler(oCecRemote_CecRemoteLogEvent);
            _client.CecRemoteCommandEvent += new CecRemoteCommandEventHandler(oCecRemote_CecRemoteCommandEvent);

            if (_client.Connect(Defaults.CONNECT_DELAY))
            {
                _remoteHandler = new InputHandler("CecRemote");
                _keyDownTimer = new StopWatch();

                if (_client.getAVRdevice() != null)
                {
                    _config.ConnectedTo = CecSharp.CecLogicalAddress.AudioSystem;
                }
                
                if (_config.HdmiPort != 0)
                {
                    _client.setHdmiPort(_config.ConnectedTo, _config.HdmiPort);
                }
                
                if (_config.FilterShortPulses)
                {
                    _client.setFilterDelay(_config.FilterDelay);
                }

                _client.setExitCommands(_config.SendInactiveSource, _config.PowerOff);
 
                Log.Info("CecRemote: Client connected!");

            }
            else
            {
                Log.Error("CecRemote: Could not connect to CEC-Adapter, check configuration!");
            }
        }


        private void oCecRemote_CecRemoteKeyEvent(object sender, CecRemoteEventArgs e)
        {
            Log.Info("CecRemote: Message from LibCec: KeyEvent start.");

            if (_fastScrolling)
            {
                if (_currentKey == _previousKey && _previousKey == (int)e.Key.Keycode)
                {
                    if (_keyDown == true && _scrolling == false)
                    {

                        _scrolling = true;
                        _keyDownTimer.StartZero();
                        _repeatCommand = new Thread(new ThreadStart(repeatKey));
                        _repeatCommand.Start();
                    }
                    else if (_keyDown == true && _scrolling == true)
                    {
                        
                        _keyDownTimer.StartZero();
                    }

                    return;
                }
                else
                {
                    _remoteHandler.MapAction((int)e.Key.Keycode);
                    _previousKey = _currentKey;
                    _currentKey = (int)e.Key.Keycode;
                    
                }
            }
            else
            {

                _remoteHandler.MapAction((int)e.Key.Keycode);
                
            }

            keybd_event(VK_LSHIFT, 0x2A, 0, 0);
            keybd_event(VK_LSHIFT, 0xAA, KEYEVENTF_KEYUP, 0);
             
        }

        private void oCecRemote_CecRemoteLogEvent(object sender, CecRemoteEventArgs e)
        {
            Log.Debug("CecRemote: Message from LibCec: " + e.Message.Message + e.Message.Level.ToString());
        }

        private void oCecRemote_CecRemoteCommandEvent(object sender, CecRemoteEventArgs e)
        {
            Log.Info("CecRemote: Message from LibCec: CommandEvent start.");

            if (e.Command.Opcode == CecSharp.CecOpcode.UserControlPressed)
            {
                _keyDown = true;
            }
            else if (e.Command.Opcode == CecSharp.CecOpcode.UserControlRelease)
            {
                _keyDown = false;
                _scrolling = false;
                _currentKey = -1;
                _previousKey = -1;
            }

            Log.Info("CecRemote: Message from LibCec: CommandEvent stop.");
        }


        private void repeatKey()
        {
            while (_keyDown && _keyDownTimer.ElapsedMilliseconds < _keyDownDelay)
            {
                _remoteHandler.MapAction(_currentKey);
                Thread.Sleep(Defaults.REPEAT_DELAY);
            }

            _keyDownTimer.Stop();
            _keyDown = false;
        }

        public bool WndProc(ref Message msg)
        {
            if (msg.Msg == WM_POWERBROADCAST)
            {

                switch (msg.WParam.ToInt32())
                {
                    case PBT_APMSUSPEND:
                        Log.Info("CecRemote: PowerControl: System going to sleep, stoppping CEC-client...");
                        Stop(); //Disconnect
                        break;

                    case PBT_APMRESUMESUSPEND:
                        Log.Info("CecRemote: PowerControl: User input detected after sleep (APMRESUMESUSPEND), powering on TV...");
                        connectClient(true); // If client connected already, power on tv (true = power tv)
                        break;

                    case PBT_APMRESUMEAUTOMATIC:
                        Log.Info("CecRemote: PowerControl: System resuming from sleep (APMRESUMEAUTOMATIC), starting CEC-client...");
                        connectClient(false); //Connect again when resuming from sleep (false = don't power tv)
                        break;

                    default:
                        break;
                }
            }

            return false; // false = allow other plugins to handle the message
        }
    }
}
