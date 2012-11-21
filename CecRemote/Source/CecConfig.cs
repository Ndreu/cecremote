using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaPortal.GUI.Library;
using MediaPortal.Configuration;
using CecSharp;

namespace CecRemote
{
    class CecConfig
    {
        public int KeyDownDelay {get; set; }
        public int FilterDelay { get; set; }
        public int HdmiPort { get; set; }
        public int LogLevel { get; set; }
        public bool FastScrolling { get; set; }
        public bool FilterShortPulses { get; set; }
        public bool SendInactiveSource { get; set; }
        public bool PowerOff { get; set; }
        public CecDeviceType CecType { get; set; }
        public CecLogicalAddress ConnectedTo { get; set; }

        public CecConfig()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            KeyDownDelay = Defaults.KEY_DOWN_DELAY;
            FilterDelay = Defaults.KEY_FILTER_DELAY;
            HdmiPort = Defaults.HDMI_PORT;
            LogLevel = Defaults.LOG_LEVEL;
            FastScrolling = Defaults.FAST_SCROLLING;
            FilterShortPulses = Defaults.FILTER_SHORT_PULSES;
            SendInactiveSource = Defaults.INACTIVE_SOURCE;
            PowerOff = Defaults.POWER_OFF;
            ConnectedTo = Defaults.CONNECTED_TO;
            CecType = (CecSharp.CecDeviceType)Enum.Parse(typeof(CecSharp.CecDeviceType), Defaults.DEVICE_TYPE);
        }

        public void ReadConfig(string SettingsFile = Defaults.CONFIG)
        {
            try
            {
                using (MediaPortal.Profile.Settings reader = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, SettingsFile)))
                {
                    HdmiPort = reader.GetValueAsInt("CecRemote", "HDMIPort", Defaults.HDMI_PORT);
                    FilterDelay = reader.GetValueAsInt("CecRemote", "FilterDelay", Defaults.KEY_FILTER_DELAY);
                    KeyDownDelay = Defaults.KEY_DOWN_DELAY;
                    FastScrolling = reader.GetValueAsBool("CecRemote", "FastScrolling", Defaults.FAST_SCROLLING);
                    FilterShortPulses = reader.GetValueAsBool("CecRemote", "FilterShortPulses", Defaults.FILTER_SHORT_PULSES);
                    SendInactiveSource = reader.GetValueAsBool("CecRemote", "InactiveSource", Defaults.INACTIVE_SOURCE);
                    PowerOff = reader.GetValueAsBool("CecRemote", "PowerOff", Defaults.POWER_OFF);
                    CecType = (CecSharp.CecDeviceType)Enum.Parse(typeof(CecSharp.CecDeviceType), (reader.GetValueAsString("CecRemote", "Type", Defaults.DEVICE_TYPE)), true);
                    ConnectedTo = Defaults.CONNECTED_TO;
                    LogLevel = reader.GetValueAsInt("general", "loglevel", 0);
                }
            }
            catch (Exception ex)
            {
                Log.Error("CecRemote: Configuration read failed, using defaults! {0}", ex.ToString());
                SetDefaults();
            }

        }

        public void WriteConfig(string SettingsFile = Defaults.CONFIG)
        {
            try
            {
                using (MediaPortal.Profile.Settings writer = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, SettingsFile)))
                {
                    // Write configuration to config file (default is MediaPortal.xml)

                    writer.SetValue("CecRemote", "HDMIPort", HdmiPort.ToString());
                    writer.SetValue("CecRemote", "Type", CecType.ToString());
                    writer.SetValueAsBool("CecRemote", "FastScrolling", FastScrolling);
                    writer.SetValueAsBool("CecRemote", "FilterShortPulses", FilterShortPulses);
                    writer.SetValueAsBool("CecRemote", "InactiveSource", SendInactiveSource);
                    writer.SetValueAsBool("CecRemote", "PowerOff", PowerOff);
                    writer.SetValue("CecRemote", "FilterDelay", FilterDelay.ToString());
                }
            }
            catch (Exception ex)
            {
                Log.Error("CecRemote: Configuration write failed, settings not saved! {0}", ex.ToString());
                throw;
            }
        }
    }


}
