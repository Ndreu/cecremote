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

namespace CecRemote.Base
{
  public class CecConfigBase
  {
    public int HdmiPort { get; set; }
    public CecDeviceType DeviceType { get; set; }

    public string OsdName { get; set; }

    public bool FastScrolling { get; set; }
    public ushort FastScrollingRepeatDelay { get; set; }
    public ushort FastScrollingRepeatRate { get; set; }
   
    public bool RequireDelayBetweenKeys { get; set; }
    public ushort DelayBetweenKeys { get; set; }

    public bool DisableScreensaver { get; set; }
    public bool ExtensiveLogging { get; set; }

    public bool WakeDevicesOnStart { get; set; }
    public bool ActivateSourceOnStart { get; set; }
    public CecLogicalAddresses OnStartWakeDevices { get; set; }

    public bool StandbyDevicesOnExit { get; set; }
    public bool InactivateSourceOnExit { get; set; }
    public CecLogicalAddresses OnExitStandbyDevices { get; set; }

    public bool WakeDevicesOnResume { get; set; }
    public bool ActivateSourceOnResume { get; set; }
    public bool RequireUserInputOnResume { get; set; }
    public CecLogicalAddresses OnResumeWakeDevices { get; set; }

    public bool StandbyDevicesOnSleep { get; set; }
    public bool InactivateSourceOnSleep { get; set; }
    public CecLogicalAddresses OnSleepStandbyDevices { get; set; }
       
    public CecLogicalAddress ConnectedTo { get; set; }
    public CecClientVersion ClientVersion { get; set; }

    public bool SendTvPowerOff { get; set; }
    public bool SendTvPowerOffOnlyIfActiveSource { get; set; }

    public CecConfigBase()
    {
      SetDefaults();
    }

    public CecConfigBase(CecConfigBase copyConf)
    {
      SetDefaults();

      HdmiPort = copyConf.HdmiPort;
      DeviceType = copyConf.DeviceType;
      OsdName = copyConf.OsdName;
      FastScrolling = copyConf.FastScrolling;
      FastScrollingRepeatDelay = copyConf.FastScrollingRepeatDelay;
      FastScrollingRepeatRate = copyConf.FastScrollingRepeatRate;

      RequireDelayBetweenKeys = copyConf.RequireDelayBetweenKeys;
      DelayBetweenKeys = copyConf.DelayBetweenKeys;

      DisableScreensaver = copyConf.DisableScreensaver;
      ExtensiveLogging = copyConf.ExtensiveLogging;

      WakeDevicesOnStart = copyConf.WakeDevicesOnStart;
      ActivateSourceOnStart = copyConf.ActivateSourceOnStart;
      OnStartWakeDevices = copyConf.OnStartWakeDevices;

      StandbyDevicesOnExit = copyConf.StandbyDevicesOnExit;
      InactivateSourceOnExit = copyConf.InactivateSourceOnExit;
      OnExitStandbyDevices = copyConf.OnExitStandbyDevices;

      WakeDevicesOnResume = copyConf.WakeDevicesOnResume;
      ActivateSourceOnResume = copyConf.ActivateSourceOnResume;
      RequireUserInputOnResume = copyConf.RequireUserInputOnResume;
      OnResumeWakeDevices = copyConf.OnResumeWakeDevices;

      StandbyDevicesOnSleep = copyConf.StandbyDevicesOnSleep;
      InactivateSourceOnSleep = copyConf.InactivateSourceOnSleep;
      OnSleepStandbyDevices = copyConf.OnSleepStandbyDevices;

      SendTvPowerOff = copyConf.SendTvPowerOff;
      SendTvPowerOffOnlyIfActiveSource = copyConf.SendTvPowerOffOnlyIfActiveSource;

      ClientVersion = copyConf.ClientVersion;
      ConnectedTo = copyConf.ConnectedTo;
   
      
    }

    public void SetDefaults()
    {
      HdmiPort = 1;
      DeviceType = CecDeviceType.RecordingDevice;

      OsdName = "MediaPortal";

      FastScrolling = false;
      FastScrollingRepeatDelay = 2;
      FastScrollingRepeatRate = 40;

      RequireDelayBetweenKeys = false;
      DelayBetweenKeys = 300;

      DisableScreensaver = false;
      ExtensiveLogging = false;

      WakeDevicesOnStart = true;
      ActivateSourceOnStart = true;
      OnStartWakeDevices = new CecLogicalAddresses();
      OnStartWakeDevices.Set(CecLogicalAddress.Tv);
      OnStartWakeDevices.Set(CecLogicalAddress.AudioSystem);

      StandbyDevicesOnExit = false;
      InactivateSourceOnExit = false;
      OnExitStandbyDevices = new CecLogicalAddresses();
      OnExitStandbyDevices.Set(CecLogicalAddress.Tv);
      OnExitStandbyDevices.Set(CecLogicalAddress.AudioSystem);

      WakeDevicesOnResume = true;
      ActivateSourceOnResume = true;
      RequireUserInputOnResume = true;
      OnResumeWakeDevices = new CecLogicalAddresses();
      OnResumeWakeDevices.Set(CecLogicalAddress.Tv);
      OnResumeWakeDevices.Set(CecLogicalAddress.AudioSystem);

      StandbyDevicesOnSleep = true;
      InactivateSourceOnSleep = false;
      OnSleepStandbyDevices = new CecLogicalAddresses();
      OnSleepStandbyDevices.Set(CecLogicalAddress.Tv);
      OnSleepStandbyDevices.Set(CecLogicalAddress.AudioSystem);

      ClientVersion = CecClientVersion.Version2_1_0;
      ConnectedTo = CecLogicalAddress.Tv;

      SendTvPowerOff = false;
      SendTvPowerOffOnlyIfActiveSource = true;

    }

    public virtual void ReadConfig() { }

    public virtual void WriteConfig() { }
        
  }
}

