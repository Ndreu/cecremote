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
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using CecSharp;
using MediaPortal.GUI.Library;
using MediaPortal.InputDevices;
using CecRemote.Base;

namespace CecRemote
{


  public partial class CecSettings : Form
  {
    public CecConfig _config;

    
    public CecSettings()
    {
      // Read MediaPortal config 
      _config = new CecConfig();

      try
      {
        _config.ReadConfig();
      }
      catch (Exception exp)
      {
        MessageBox.Show("Error while reading configuration from MediaPortal.xml" + exp.ToString());
      }

      InitializeComponent();

      AddBindings();
      
    }

    private void AddBindings()
    {
      numericUpDownHdmi.DataBindings.Add("Value", _config, "HdmiPort");
      textBoxOsd.DataBindings.Add("Text", _config, "OsdName");
      checkBoxFastScrolling.DataBindings.Add("Checked", _config, "FastScrolling");
      trackBarRepeatDelay.DataBindings.Add("Value", _config, "FastScrollingRepeatDelay");
      trackBarRepeatRate.DataBindings.Add("Value", _config, "FastScrollingRepeatRate");
      checkBoxRequireDelayBetweenKeys.DataBindings.Add("Checked", _config, "RequireDelayBetweenKeys");
      numericUpDownRequireDelay.DataBindings.Add("Value", _config, "DelayBetweenKeys");
      checkBoxTerminateScreensaver.DataBindings.Add("Checked", _config, "DisableScreensaver");
      checkBoxExtensiveLogging.DataBindings.Add("Checked", _config, "ExtensiveLogging");
      checkBoxWakeDevicesOnStart.DataBindings.Add("Checked", _config, "WakeDevicesOnStart");
      checkBoxStandbyOnExit.DataBindings.Add("Checked", _config, "StandbyDevicesOnExit");
      checkBoxWakeDevicesOnResume.DataBindings.Add("Checked", _config, "WakeDevicesOnResume");
      checkBoxStandbyOnSleep.DataBindings.Add("Checked", _config, "StandbyDevicesOnSleep");
      checkBoxSetActiveSourceOnStart.DataBindings.Add("Checked", _config, "ActivateSourceOnStart");
      checkBoxSetInactiveSourceOnExit.DataBindings.Add("Checked", _config, "InactivateSourceOnExit");
      checkBoxSetActiveSourceOnResume.DataBindings.Add("Checked", _config, "ActivateSourceOnResume");
      checkBoxSetInactiveSourceOnSleep.DataBindings.Add("Checked", _config, "InactivateSourceOnSleep");

      // Handle comboboxes separately

      comboBoxDeviceType.SelectedItem = _config.DeviceType.ToString();
      comboBoxConnectedTo.SelectedItem = _config.ConnectedTo.ToString();

    }

    private void ResetBindings(Control ctl)
    {
      // Remove all bindings (for reset)

      foreach (Control c in ctl.Controls)
      {
        if (c.Controls.Count > 0)
        {
          ResetBindings(c);
        }

        if (c is TextBox || c is NumericUpDown || c is CheckBox || c is TrackBar)
        {
          c.DataBindings.Clear();
         // c.ResetText();
        }
      }
    }


    private void buttonClose_Click(object sender, EventArgs e)
    {

      this.Close();
    }


    private void buttonMapping_Click(object sender, EventArgs e)
    {
      // Open MediaPortal mapping form
      InputMappingForm mappings = new InputMappingForm("CecRemote");
      mappings.ShowDialog(this);
    }


   
    private void ShowSelectDevices(CecLogicalAddresses list)
    {

      SelectDevices sel = new SelectDevices();
      sel.StartPosition = FormStartPosition.CenterParent;

      foreach (PropertyInfo property in sel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
      {
        if (property.CanWrite && property.PropertyType.Equals(typeof(System.Boolean)))
        {
          property.SetValue(sel, false, null);
          if (list.IsSet((CecLogicalAddress)Enum.Parse(typeof(CecLogicalAddress), property.Name, true)))
          {
            property.SetValue(sel, true, null);
          }
        }
      }

      if (sel.ShowDialog(this) == DialogResult.OK)
      {
        list.Clear();

        foreach (PropertyInfo property in sel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
          if (property.CanRead && property.PropertyType.Equals(typeof(System.Boolean)))
          {
            if ((bool)property.GetValue(sel, null))
            {
              list.Set((CecLogicalAddress)Enum.Parse(typeof(CecLogicalAddress), property.Name, true));
            }
          }
        }

        sel = null;
      }
    }

    private void buttonSelectDevicesOnStart_Click(object sender, EventArgs e)
    {
      ShowSelectDevices(_config.OnStartWakeDevices);
    }


    private void buttonSelectDevicesOnStandby_Click(object sender, EventArgs e)
    {
      ShowSelectDevices(_config.OnExitStandbyDevices);
    }

    private void buttonSelectDevicesOnResume_Click(object sender, EventArgs e)
    {
      ShowSelectDevices(_config.OnResumeWakeDevices);
    }

    private void buttonSelectDevicesOnSleep_Click(object sender, EventArgs e)
    {
      ShowSelectDevices(_config.OnSleepStandbyDevices);
    }

    private void buttonSaveSettings_Click(object sender, EventArgs e)
    {
      try
      {
        _config.WriteConfig();
      }
      catch(Exception exp)
      {
        MessageBox.Show("Error while writing configuration to MediaPortal.xml" + exp.ToString() );
      }

      this.Close();

    }

    private void checkBoxFastScrolling_CheckedChanged(object sender, EventArgs e)
    {

      trackBarRepeatDelay.Enabled = checkBoxFastScrolling.Checked;
      trackBarRepeatRate.Enabled = checkBoxFastScrolling.Checked;

    }

    private void checkBoxRequireDelayBetweenKeys_CheckedChanged(object sender, EventArgs e)
    {
      numericUpDownRequireDelay.Enabled = checkBoxRequireDelayBetweenKeys.Checked;
    }

    private void buttonRestoreDefaults_Click(object sender, EventArgs e)
    {
      
      DialogResult result = MessageBox.Show("This will change all your settings to default values.\n Button mappings will still remain unchanged.\n\nReset to defaults?", "Reset to defaults",
        MessageBoxButtons.YesNo);

      if (result == DialogResult.Yes)
      {
        _config.SetDefaults();
        ResetBindings(this);
        AddBindings();
      }

    }

    private void comboBoxDeviceType_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        _config.DeviceType = (CecDeviceType)Enum.Parse(typeof(CecDeviceType), comboBoxDeviceType.SelectedItem.ToString());
      }
      catch (Exception ex)
      {
        Log.Error("Could not set selected device type. Illegal value? " + ex.ToString());
      }

    }

    private void comboBoxConnectedTo_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        _config.ConnectedTo = (CecLogicalAddress)Enum.Parse(typeof(CecLogicalAddress), comboBoxConnectedTo.SelectedItem.ToString());
      }
      catch (Exception ex)
      {
        Log.Error("Could not set connected device type. Illegal value? " + ex.ToString());
      }
    }

    private void buttonAdvancedPower_Click(object sender, EventArgs e)
    {
      AdvancedPower pow = new AdvancedPower();
      pow.StartPosition = FormStartPosition.CenterParent;

      pow.RequireUser = _config.RequireUserInputOnResume;
      pow.SendTvPower = _config.SendTvPowerOff;
      pow.SendTvPowerOffOnlyIfActiveSource = _config.SendTvPowerOffOnlyIfActiveSource;

      if (pow.ShowDialog(this) == DialogResult.OK)
      {
        _config.RequireUserInputOnResume = pow.RequireUser;
        _config.SendTvPowerOff = pow.SendTvPower;
        _config.SendTvPowerOffOnlyIfActiveSource = pow.SendTvPowerOffOnlyIfActiveSource;
      }

      pow = null;
    }

  }
}
