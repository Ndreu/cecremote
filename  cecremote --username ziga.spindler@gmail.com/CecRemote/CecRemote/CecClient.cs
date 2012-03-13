using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CecSharp;
using MediaPortal.GUI.Library;

namespace CecRemote
{
    class CecClient : CecCallbackMethods
    {
        private int LogLevel;
        private LibCecSharp Lib;
        private LibCECConfiguration Config;
        private List<string> commands;

        public CecClient()
        {
            Config = new LibCECConfiguration();
            Config.DeviceTypes.Types[0] = CecDeviceType.PlaybackDevice;
            Config.DeviceName = "CEC GUI";
            Config.ClientVersion = CecClientVersion.Version1_5_0;
            byte iPort;
            if (byte.TryParse("3", out iPort))
                Config.HDMIPort = iPort;
            ushort iDevice;
            if (ushort.TryParse("0", out iDevice))
                Config.BaseDevice = (CecLogicalAddress)iDevice;
            Config.ActivateSource = true;
            Config.WakeDevices.Set(CecLogicalAddress.Tv);
            Config.SetCallbacks(this);
            Config.AutodetectAddress = false;
            LogLevel = (int)CecLogLevel.All;

            Lib = new LibCecSharp(Config);

            commands = new List<string>();
        }

        public override int ReceiveCommand(CecCommand command)
        {
            return 1;
        }

        public override int ReceiveKeypress(CecKeypress key)
        {
            commands.Add(string.Format("{0};{1}", key.Keycode, key.Duration));
            return 1;
        }

        public override int ReceiveLogMessage(CecLogMessage message)
        {
            if (((int)message.Level & LogLevel) == (int)message.Level)
            {
                switch (message.Level)
                {
                    case CecLogLevel.Error:
                        Log.Error("{1,16} {2}", message.Time, message.Message);
                        break;
                    case CecLogLevel.Warning:
                        Log.Warn("{1,16} {2}", message.Time, message.Message);
                        break;
                    case CecLogLevel.Notice:
                        Log.Info("{1,16} {2}", message.Time, message.Message);
                        break;
                    case CecLogLevel.Traffic:
                        Log.Info("{1,16} {2}", message.Time, message.Message);
                        break;
                    case CecLogLevel.Debug:
                        Log.Debug("{1,16} {2}", message.Time, message.Message);
                        break;
                    default:
                        break;
                }
            }
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
            Lib.Close();
        }

        public void setHdmiPort(int address, int port)
        {
            Lib.SetHDMIPort((CecLogicalAddress)address, (byte)port);
        }

        public string getCommand()
        {
            if (commands.Count != 0)
            {
                string output = commands[0];
                commands.RemoveAt(0);
                return output;
            }
            return null;
        }
    }
}
