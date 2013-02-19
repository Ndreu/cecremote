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
using MediaPortal.GUI.Library;
using MediaPortal.Configuration;
using CecRemote.Base;
using CecSharp;

namespace CecRemote
{
  public class CecConfig : CecConfigBase
  {
    public CecConfig()
    {
    }

    public CecConfig(CecConfig conf) : base((CecConfigBase)conf)
    {
    }

    public override void ReadConfig()
    {
      try
      {
        using (MediaPortal.Profile.Settings reader = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, "MediaPortal.xml")))
        {
          HdmiPort = reader.GetValueAsInt("CecRemote", "HDMIPort", base.HdmiPort);
          DeviceType = (CecSharp.CecDeviceType)Enum.Parse(typeof(CecSharp.CecDeviceType), (reader.GetValueAsString("CecRemote", "Type", base.DeviceType.ToString())), true);
          OsdName = reader.GetValueAsString("CecRemote", "OsdName", base.OsdName);
          FastScrolling = reader.GetValueAsBool("CecRemote", "FastScrolling", base.FastScrolling);
          FastScrollingRepeatDelay = (ushort)reader.GetValueAsInt("CecRemote", "FastScrollingRepeatDelay", base.FastScrollingRepeatDelay);
          FastScrollingRepeatRate = (ushort)reader.GetValueAsInt("CecRemote", "FastScrollingRepeatRate", base.FastScrollingRepeatRate);
          RequireDelayBetweenKeys = reader.GetValueAsBool("CecRemote", "RequireDelayBetweenKeys", base.RequireDelayBetweenKeys);
          DelayBetweenKeys = (ushort)reader.GetValueAsInt("CecRemote", "DelayBetweenKeys", base.DelayBetweenKeys);
          DisableScreensaver = reader.GetValueAsBool("CecRemote", "DisableScreensaver", base.DisableScreensaver);
          ExtensiveLogging = reader.GetValueAsBool("CecRemote", "ExtensiveLogging", base.ExtensiveLogging);
          WakeDevicesOnStart = reader.GetValueAsBool("CecRemote", "WakeDevicesOnStart", base.WakeDevicesOnStart);
          ActivateSourceOnStart = reader.GetValueAsBool("CecRemote", "ActivateSourceOnStart", base.ActivateSourceOnStart);
          OnStartWakeDevices = ParseDevices(reader.GetValueAsString("CecRemote", "OnStartWakeDevices", base.OnStartWakeDevices.Primary.ToString()));
          StandbyDevicesOnExit = reader.GetValueAsBool("CecRemote", "StandbyDevicesOnExit", base.StandbyDevicesOnExit);
          InactivateSourceOnExit = reader.GetValueAsBool("CecRemote", "InactivateSourceOnExit", base.InactivateSourceOnExit);
          OnExitStandbyDevices = ParseDevices(reader.GetValueAsString("CecRemote", "OnExitStandbyDevices", base.OnExitStandbyDevices.Primary.ToString()));
          WakeDevicesOnResume = reader.GetValueAsBool("CecRemote", "WakeDevicesOnResume", base.WakeDevicesOnResume);
          ActivateSourceOnResume = reader.GetValueAsBool("CecRemote", "ActivateSourceOnResume", base.ActivateSourceOnResume);
          RequireUserInputOnResume = reader.GetValueAsBool("CecRemote", "RequireUserInputOnResume", base.RequireUserInputOnResume);
          OnResumeWakeDevices = ParseDevices(reader.GetValueAsString("CecRemote", "OnResumeWakeDevices", base.OnResumeWakeDevices.Primary.ToString()));
          StandbyDevicesOnSleep = reader.GetValueAsBool("CecRemote", "StandbyDevicesOnSleep", base.StandbyDevicesOnSleep);
          InactivateSourceOnSleep = reader.GetValueAsBool("CecRemote", "InactivateSourceOnSleep", base.InactivateSourceOnSleep);
          OnSleepStandbyDevices = ParseDevices(reader.GetValueAsString("CecRemote", "OnSleepStandbyDevices", base.OnSleepStandbyDevices.Primary.ToString()));
          ConnectedTo = (CecSharp.CecLogicalAddress)Enum.Parse(typeof(CecSharp.CecLogicalAddress), (reader.GetValueAsString("CecRemote", "ConnectedTo", base.ConnectedTo.ToString())), true);
          SendTvPowerOff = reader.GetValueAsBool("CecRemote", "SendTvPowerOff", base.SendTvPowerOff);
          SendTvPowerOffOnlyIfActiveSource = reader.GetValueAsBool("CecRemote", "SendTvPowerOffOnlyIfActiveSource", base.SendTvPowerOffOnlyIfActiveSource);

        }
      }
      catch (Exception ex)
      {
        Log.Error("CecRemote: Configuration read failed, using defaults! {0}", ex.ToString());
        base.SetDefaults();
      }

    }

    public override void WriteConfig()
    {
      try
      {
        using (MediaPortal.Profile.Settings writer = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, "MediaPortal.xml")))
          {
            writer.SetValue("CecRemote", "HDMIPort", base.HdmiPort);
            writer.SetValue("CecRemote", "Type", base.DeviceType.ToString() );
            writer.SetValue("CecRemote", "OsdName", base.OsdName);
            writer.SetValueAsBool("CecRemote", "FastScrolling", base.FastScrolling);
            writer.SetValue("CecRemote", "FastScrollingRepeatDelay", base.FastScrollingRepeatDelay);
            writer.SetValue("CecRemote", "FastScrollingRepeatRate", base.FastScrollingRepeatRate);
            writer.SetValueAsBool("CecRemote", "RequireDelayBetweenKeys", base.RequireDelayBetweenKeys);
            writer.SetValue("CecRemote", "DelayBetweenKeys", base.DelayBetweenKeys);
            writer.SetValueAsBool("CecRemote", "DisableScreensaver", base.DisableScreensaver);
            writer.SetValueAsBool("CecRemote", "ExtensiveLogging", base.ExtensiveLogging);
            writer.SetValueAsBool("CecRemote", "WakeDevicesOnStart", base.WakeDevicesOnStart);
            writer.SetValueAsBool("CecRemote", "ActivateSourceOnStart", base.ActivateSourceOnStart);
            writer.SetValue("CecRemote", "OnStartWakeDevices", DevicesToString(base.OnStartWakeDevices));
            writer.SetValueAsBool("CecRemote", "StandbyDevicesOnExit", base.StandbyDevicesOnExit);
            writer.SetValueAsBool("CecRemote", "InactivateSourceOnExit", base.InactivateSourceOnExit);
            writer.SetValue("CecRemote", "OnExitStandbyDevices", DevicesToString(base.OnExitStandbyDevices) );
            writer.SetValueAsBool("CecRemote", "WakeDevicesOnResume", base.WakeDevicesOnResume);
            writer.SetValueAsBool("CecRemote", "ActivateSourceOnResume", base.ActivateSourceOnResume);
            writer.SetValueAsBool("CecRemote", "RequireUserInputOnResume", base.RequireUserInputOnResume);
            writer.SetValue("CecRemote", "OnResumeWakeDevices", DevicesToString(base.OnResumeWakeDevices) );
            writer.SetValueAsBool("CecRemote", "StandbyDevicesOnSleep", base.StandbyDevicesOnSleep);
            writer.SetValueAsBool("CecRemote", "InactivateSourceOnSleep", base.InactivateSourceOnSleep);
            writer.SetValue("CecRemote", "OnSleepStandbyDevices", DevicesToString(base.OnSleepStandbyDevices) );
            writer.SetValue("CecRemote", "ConnectedTo", base.ConnectedTo.ToString());
            writer.SetValueAsBool("CecRemote", "SendTvPowerOff", base.SendTvPowerOff);
            writer.SetValueAsBool("CecRemote", "SendTvPowerOffOnlyIfActiveSource", base.SendTvPowerOffOnlyIfActiveSource);
          }
      }
      catch (Exception ex)
      {
          Log.Error("CecRemote: Configuration write failed, settings not saved correctly! {0}", ex.ToString());
          throw;
      }
    }

    private CecLogicalAddresses ParseDevices(string devices)
    {
      CecLogicalAddresses list = new CecLogicalAddresses();

      if (devices.Length == 0)
      {
        return list;
      }

      string[] devicelist = devices.Split(',');
      
      foreach (string d in devicelist)
      {
        if (d != "Unknown" && d != "Unregistered")
        {
          list.Set((CecSharp.CecLogicalAddress)Enum.Parse(typeof(CecLogicalAddress), d));
        }
      }

      return list;
    }

    private string DevicesToString(CecLogicalAddresses list)
    {
      if (list.Primary == CecLogicalAddress.Unknown)
      {
        return string.Empty;
      }

      string deviceList = "";

      foreach (CecLogicalAddress a in list.Addresses)
      {
        if (a != CecLogicalAddress.Unknown && a != CecLogicalAddress.Unregistered)
        {
          deviceList += a.ToString() + ',';
        }
      }

      if (deviceList.Length == 0)
      {
        return string.Empty;
      }
      else
      {
        return deviceList.Remove(deviceList.Length - 1);
      }

    }

  }


}
