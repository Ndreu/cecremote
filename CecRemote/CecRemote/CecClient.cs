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
        private int LogLevel;
        private LibCecSharp Lib;
        private LibCECConfiguration Config;

        public event CecRemoteKeyEventHandler CecRemoteKeyEvent;
        public event CecRemoteLogEventHandler CecRemoteLogEvent;
        public event CecRemoteCommandEventHandler CecRemoteCommandEvent;

        public CecClient(string deviceName, CecDeviceType deviceType, CecLogLevel Level)
        {
            Config = new LibCECConfiguration();
            Config.DeviceTypes.Types[0] = deviceType;
            Config.DeviceName = deviceName;
            Config.ClientVersion = CecClientVersion.Version1_7_0;
            Config.SetCallbacks(this);
            LogLevel = (int) Level;
            
            Lib = new LibCecSharp(Config);

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
            //test fix for samsung play/stop keys
            if (command.Opcode == CecOpcode.Play || command.Opcode == CecOpcode.DeckControl)
            {
                CecKeypress key = new CecKeypress();
                key.Duration = 0;
                if (command.Opcode == CecOpcode.Play)
                {
                    key.Keycode = CecUserControlCode.Play;
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
            CecRemoteEventArgs e = new CecRemoteEventArgs(key);
            OnCecRemoteKeyEvent(e);

            return 1;
        }

        public override int ReceiveLogMessage(CecLogMessage message)
        {
            if ((int)message.Level <= LogLevel)
            {
                CecRemoteEventArgs e = new CecRemoteEventArgs(message);
                OnCecRemoteLogEvent(e);               
            }
            return 1;
        }

        public override int ConfigurationChanged(LibCECConfiguration config)
        {
            
            return 1;
        }


        public bool Connect(int timeout)
        {
            CecAdapter[] adapters = Lib.FindAdapters(string.Empty);
            if (adapters.Length > 0)
            {
                return Connect(adapters[0].ComPort, timeout);
            }
            else
                return false;
        }

        public bool Connect(string port, int timeout)
        {
            return Lib.Open(port, timeout);
        }

        public void Close()
        {
            Lib.DisableCallbacks();
            Lib.Close();
            Lib.Dispose();

            Lib = null;
            Config = null;
        }

        public void setHdmiPort(int address, int port)
        {
            Lib.SetHDMIPort((CecLogicalAddress)address, (byte)port);
        }

        public ushort getFirmwareVersion()
        {
            LibCECConfiguration temp = new LibCECConfiguration();
            Lib.GetCurrentConfiguration(temp);

            return temp.FirmwareVersion;
        }

        public string getTvVendor()
        {
            CecVendorId tv = Lib.GetDeviceVendorId(CecLogicalAddress.Tv);

            return tv.ToString();
        }

        public string getAVRdevice()
        {

            if(Lib.IsActiveDevice(CecLogicalAddress.AudioSystem))
            {
                return Lib.GetDeviceVendorId(CecLogicalAddress.AudioSystem).ToString();
            }

            return null;
        }

    }
}
