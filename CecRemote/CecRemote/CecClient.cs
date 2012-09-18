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

        public CecRemoteEventArgs(CecKeypress key)
        {
            _key = key;
        }
        public CecRemoteEventArgs(CecLogMessage message)
        {
            _message = message;
        }

        public CecKeypress Key
        {
            get { return _key; }
        }
        public CecLogMessage Message
        {
            get { return _message; }
        }
    }

    public delegate void CecRemoteKeyEventHandler(object sender, CecRemoteEventArgs e);
    public delegate void CecRemoteLogEventHandler(object sender, CecRemoteEventArgs e);

    class CecClient : CecCallbackMethods
    {
        private int LogLevel;
        private LibCecSharp Lib;
        private LibCECConfiguration Config;

        public event CecRemoteKeyEventHandler CecRemoteKeyEvent;
        public event CecRemoteLogEventHandler CecRemoteLogEvent;

        public CecClient(string deviceName, CecDeviceType deviceType, CecLogLevel Level)
        {
            Config = new LibCECConfiguration();
            Config.DeviceTypes.Types[0] = deviceType;
            Config.DeviceName = deviceName;
            Config.ClientVersion = CecClientVersion.Version1_6_3;
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

        public override int ReceiveCommand(CecCommand command)
        {
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
