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
using System.Linq;
using System.Text;
using CecSharp;

namespace CecRemote
{
    public class CecRemoteEventArgs : EventArgs
    {
        private CecKeypress _key;
        private CecLogMessage _message;
        private CecCommand _command;

        public CecRemoteEventArgs(CecKeypress key)
        {
            _key = key;
        }
        public CecRemoteEventArgs(CecLogMessage message)
        {
            _message = message;
        }
        public CecRemoteEventArgs(CecCommand command)
        {
            _command = command;
        }

        public CecKeypress Key
        {
            get { return _key; }
        }
        public CecLogMessage Message
        {
            get { return _message; }
        }
        public CecCommand Command
        {
            get { return _command; }
        }
    }

    public delegate void CecRemoteKeyEventHandler(object sender, CecRemoteEventArgs e);
    public delegate void CecRemoteLogEventHandler(object sender, CecRemoteEventArgs e);
    public delegate void CecRemoteCommandEventHandler(object sender, CecRemoteEventArgs e);

    class CecClient : CecCallbackMethods
    {
        private int _logLevel;
        private LibCecSharp _lib;
        private LibCECConfiguration _config;
        private int _filterDelay;
        private bool _sendInactiveSource;
        private bool _powerOff;
        private DateTime _keyTimeStamp;

        public event CecRemoteKeyEventHandler CecRemoteKeyEvent;
        public event CecRemoteLogEventHandler CecRemoteLogEvent;
        public event CecRemoteCommandEventHandler CecRemoteCommandEvent;

        public CecClient(string deviceName, CecDeviceType deviceType, CecLogLevel Level, byte HdmiPort = 0)
        {
            _keyTimeStamp = DateTime.Now;

            _config = new LibCECConfiguration();
            _config.DeviceTypes.Types[0] = deviceType;
            _config.DeviceName = deviceName;
            _config.ClientVersion = CecClientVersion.Version2_0_2;
            
            
            if (HdmiPort != 0)
            { _config.HDMIPort = HdmiPort; }

            _config.SetCallbacks(this);
            _logLevel = (int) Level;
            _filterDelay = 0;
            
            _lib = new LibCecSharp(_config);

        }

        protected virtual void OnCecRemoteKeyEvent(CecRemoteEventArgs e)
        {
            if (CecRemoteKeyEvent != null)
            {
                CecRemoteKeyEvent(this, e);
            }
        }
        protected virtual void OnCecRemoteLogEvent(CecRemoteEventArgs e)
        {
            if (CecRemoteLogEvent != null)
            {
                CecRemoteLogEvent(this, e);
            }
        }
        protected virtual void OnCecRemoteCommandEvent(CecRemoteEventArgs e)
        {
            if (CecRemoteCommandEvent != null)
            {
                CecRemoteCommandEvent(this, e);
            }
        }

        public override int ReceiveCommand(CecCommand command)
        {
            
            // Dirty fix for some play/stop keys
            if ((command.Opcode == CecOpcode.Play || command.Opcode == CecOpcode.DeckControl) 
                && command.Initiator == CecLogicalAddress.Tv && command.Parameters.Size == 1)
            {
                CecKeypress key = new CecKeypress();
                key.Duration = (uint)_filterDelay;
                if (command.Opcode == CecOpcode.Play )
                {
                    key.Keycode = CecUserControlCode.Pause;   
                }
                else
                {
                    key.Keycode = CecUserControlCode.Stop;
                }

                CecRemoteEventArgs e = new CecRemoteEventArgs(key);
                OnCecRemoteKeyEvent(e);
            }
            else
            {
                CecRemoteEventArgs e = new CecRemoteEventArgs(command);
                OnCecRemoteCommandEvent(e);
            }
            return 1;
        }

        public override int ReceiveKeypress(CecKeypress key)
        {
            if (key.Duration != 0)
            { return 1; }

            else if(_filterDelay != 0)
            {
                DateTime current = DateTime.Now;
                TimeSpan temp = current.Subtract(_keyTimeStamp);

                if(temp.TotalMilliseconds < _filterDelay)
                { return 1; }

                _keyTimeStamp = current;
            }

            CecRemoteEventArgs e = new CecRemoteEventArgs(key);
            OnCecRemoteKeyEvent(e);

            return 1;
        }

        public override int ReceiveLogMessage(CecLogMessage message)
        {
            if ((int)message.Level <= _logLevel)
            {
                CecRemoteEventArgs e = new CecRemoteEventArgs(message);
                OnCecRemoteLogEvent(e);               
            }
            return 1;
        }

        public override int ConfigurationChanged(LibCECConfiguration _config)
        {
            
            return 1;
        }


        public bool Connect(int timeout)
        {
            CecAdapter[] adapters = _lib.FindAdapters(string.Empty);
            if (adapters.Length > 0)
            {
                return Connect(adapters[0].ComPort, timeout);
            }
            else
                return false;
        }

        public bool Connect(string port, int timeout)
        {
            return _lib.Open(port, timeout);
        }

        public void Close()
        {
            if (_lib != null)
            {
                if (_sendInactiveSource)
                {
                    _lib.SetInactiveView();
                }
                if (_powerOff)
                {
                    _lib.StandbyDevices(CecLogicalAddress.Broadcast);
                }

                _lib.DisableCallbacks();
                _lib.Close();
                _lib.Dispose();

                _lib = null;
                _config = null;
            }
        }

        public void setFilterDelay(int delay)
        {
            if (delay < 0)
            { return; }

            _filterDelay = delay;
        }

        public void setExitCommands(bool inactiveSource, bool powerOff)
        {
            this._sendInactiveSource = inactiveSource;
            this._powerOff = powerOff;
        }


        public void setHdmiPort(CecLogicalAddress address, int port)
        {
            _lib.SetHDMIPort((CecLogicalAddress)address, (byte)port);
        }

        public bool getHdmiAutodetectStatus()
        {
            return _config.AutodetectAddress;
        }

        public ushort getFirmwareVersion()
        {
            LibCECConfiguration temp = new LibCECConfiguration();
            _lib.GetCurrentConfiguration(temp);

            return temp.FirmwareVersion;
        }

        public string getLibVersion()
        {
            return _lib.GetLibInfo();
        }

        public string getTvVendor()
        {
            CecVendorId tv = _lib.GetDeviceVendorId(CecLogicalAddress.Tv);

            return tv.ToString();
        }

        public string getAVRdevice()
        {

            if(_lib.IsActiveDevice(CecLogicalAddress.AudioSystem))
            {
                return _lib.GetDeviceVendorId(CecLogicalAddress.AudioSystem).ToString();
            }

            return null;
        }

    }
}
