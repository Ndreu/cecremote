using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CecSharp;
using MediaPortal.Profile;
using MediaPortal.GUI.Library;
using MediaPortal.InputDevices;
using MediaPortal.InputDevices.FireDTV;
using MediaPortal.Configuration;
using MediaPortal.UserInterface.Controls;

namespace CecRemote
{
    public partial class CecSettings : Form
    {
        private CecClient _client;
        private CecConfig _config;

        public CecSettings()
        {

            InitializeComponent();

            // Read MediaPortal config 
            _config = new CecConfig();
            _config.ReadConfig(Defaults.CONFIG);

            // Set values for controls
            setControls();

            // Start connecting worker
            backgroundWorkerConnect.DoWork += new DoWorkEventHandler(backgroundWorkerConnect_DoWork);
            backgroundWorkerConnect.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerConnect_ProgressChanged);
            backgroundWorkerConnect.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerConnect_RunWorkerCompleted);

            backgroundWorkerConnect.RunWorkerAsync();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (_client != null)
            {
                _client.Close();
            }

            this.Close();
        }

        private void setControls()
        {
            numericUpDownHdmi.Value = _config.HdmiPort;
            numericUpDownFilter.Value = _config.FilterDelay;
            numericUpDownFilter.Enabled = _config.FilterShortPulses;
            checkBoxIgnoreShortPulses.Checked = _config.FilterShortPulses;
            checkBoxFastScrolling.Checked = _config.FastScrolling;
            checkBoxInactiveSource.Checked = _config.SendInactiveSource;
            checkBoxPowerOff.Checked = _config.PowerOff;
            comboBoxDeviceType.SelectedItem = _config.CecType.ToString();
        }


        private void backgroundWorkerConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            _client = new CecClient("Settings", _config.CecType, CecSharp.CecLogLevel.All, (byte)_config.HdmiPort);
            _client.CecRemoteKeyEvent += new CecRemoteKeyEventHandler(oCecRemote_CecRemoteEvent);

            backgroundWorkerConnect.ReportProgress(10);

            backgroundWorkerConnect.ReportProgress(20);

            if (_client.Connect(Defaults.CONNECT_DELAY))
            {
                // Send connected
                backgroundWorkerConnect.ReportProgress(30, "Connected=1");
                
                // Send firmware version
                string value = _client.getFirmwareVersion().ToString();
                backgroundWorkerConnect.ReportProgress(40, "Firmware=" + value);
                
                // Send Hdmi port
                if (_client.getHdmiAutodetectStatus())
                {
                    backgroundWorkerConnect.ReportProgress(50, "HDMIPort=" + "Autodetected");
                }
                else
                {
                    backgroundWorkerConnect.ReportProgress(50, "HDMIPort=" + _config.HdmiPort);
                }
               
                // Send TV vendor
                value = _client.getTvVendor();
                backgroundWorkerConnect.ReportProgress(70, "TVVendor=" + value);
           
                value = _client.getAVRdevice();
                
                if (value == null)
                { value = "AVR=No"; }
                else
                { 
                    value = "AVR=" + value;
                    _config.ConnectedTo = CecLogicalAddress.AudioSystem;

                }

                backgroundWorkerConnect.ReportProgress(80, value);

                if (_config.HdmiPort != 0)
                {
                    _client.setHdmiPort(_config.ConnectedTo, _config.HdmiPort);
                }

                backgroundWorkerConnect.ReportProgress(90, "Lib=" + _client.getLibVersion());


            }
            else
            {
                backgroundWorkerConnect.ReportProgress(90, "Connected=0");
            }

        }


        private void backgroundWorkerConnect_ProgressChanged(object sender, ProgressChangedEventArgs e)
	    {
	       progressBarConnect.Value = e.ProgressPercentage;

           if (e.UserState != null)
           {
               string[] state = ((string)e.UserState).Split('=');

               switch (state[0])
               {
                   case "Connected":
                       if (state[1] == "1")
                       {
                           labelAdapterStatusValue.Text = "Connected";
                       }
                       else
                       {
                           this.setInfoLabels(string.Empty);
                           labelAdapterStatusValue.Text = "No device";
                       }
                       break;

                   case "Firmware":
                       labelFirmwareValue.Text = state[1];
                       break;

                   case "HDMIPort":
                       if (state[1] == "0")
                       {
                           labelHdmiPortValue.Text = "Set manually!";
                       }
                       else
                       {
                           labelHdmiPortValue.Text = state[1];
                       }
                       break;

                   case "TVVendor":
                       labelTvVendorValue.Text = state[1];
                       break;

                   case "AVR":
                       if (state[1] == "No")
                       {
                           labelAvrConnectedValue.Text = "No device";
                           labelAvrVendor.Hide();
                           labelAvrVendorValue.Hide();
                       }
                       else
                       {
                           labelAvrConnectedValue.Text = "Connected";
                           labelAvrVendorValue.Text = state[1];
                           labelAvrVendor.Show();
                           labelAvrVendorValue.Show();
                       }
                       break;

                   default:
                       break;
               
               }
       
           }
        }


        private void backgroundWorkerConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBarConnect.Hide();
            buttonRefresh.Enabled = true;
            tabControl1.Enabled = true;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            buttonRefresh.Enabled = false;
            tabControl1.Enabled = false;

            if (_client != null)
            {
                _client.Close();
            }

            this.setInfoLabels("Updating...");

            progressBarConnect.Value = 5;
            progressBarConnect.Show();

            backgroundWorkerConnect.RunWorkerAsync();
        }

        private void checkBoxIgnoreShortPulses_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIgnoreShortPulses.Checked == true)
            {
                numericUpDownFilter.Enabled = true;
            }
            else
            {
                numericUpDownFilter.Enabled = false;
            }

        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {

                _config.HdmiPort = (int)numericUpDownHdmi.Value;
                _config.CecType = (CecSharp.CecDeviceType)Enum.Parse(typeof(CecSharp.CecDeviceType), comboBoxDeviceType.SelectedItem.ToString());
                _config.FastScrolling = checkBoxFastScrolling.Checked;
                _config.FilterShortPulses = checkBoxIgnoreShortPulses.Checked;
                _config.SendInactiveSource = checkBoxInactiveSource.Checked;
                _config.PowerOff = checkBoxPowerOff.Checked;
                _config.FilterDelay = (int)numericUpDownFilter.Value;

                _config.WriteConfig(Defaults.CONFIG);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Configuration save failed!" + ex.Message.ToString());
            }

            // Refresh connection
            this.buttonRefresh_Click(sender, e);
        }

        private void buttonMapping_Click(object sender, EventArgs e)
        {
            // Open MediaPortal mapping form
            InputMappingForm mappings = new InputMappingForm("CecRemote");
            mappings.ShowDialog(this);
        }


        private void oCecRemote_CecRemoteEvent(object sender, CecRemoteEventArgs e)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { oCecRemote_CecRemoteEvent(sender, e); }));
                return;
            }

            // Save keypress only if "Test" -tab is active
            if (tabControl1.SelectedIndex != 2)
            {
                return;
            }

            labelTest.Hide();

            // Add new keypress to listview
            string[] listItem = new string[3];
            listItem[0] = ((int)e.Key.Keycode).ToString();
            listItem[1] = e.Key.Keycode.ToString();
            listItem[2] = e.Key.Duration.ToString();
            if (checkBoxIgnoreShortPulses.Checked && e.Key.Duration < (int)numericUpDownFilter.Value)
            {
                    listItem[2] = "Ignored";
            }

            ListViewItem lvi = new ListViewItem(listItem);
            listViewTestKeys.Items.Insert(0, lvi);

            labelTest.Show();


        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Copy selected listview text to clipboard

            if (listViewTestKeys.SelectedItems.Count == 0)
            { return; }

            StringBuilder buffer = new StringBuilder();
            foreach (ListViewItem currentItem in listViewTestKeys.SelectedItems)
            {
                foreach (ListViewItem.ListViewSubItem sub in currentItem.SubItems)
                {
                    buffer.Append(sub.Text);
                    buffer.Append("\t");
                }

                buffer.Remove(buffer.Length - 1, 1);
                buffer.Append("\r\n");
            }

            Clipboard.SetText(buffer.ToString());

        }

        private void setInfoLabels(string labelText)
        {
            labelAdapterStatusValue.Text = labelText;
            labelFirmwareValue.Text = labelText;
            labelHdmiPortValue.Text = labelText;
            labelTvVendorValue.Text = labelText;
            labelAvrConnectedValue.Text = labelText;
            labelAvrVendorValue.Text = labelText;
        }


        private void CecSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_client != null)
            {
                _client.Close();
                _client = null;
            }
        }
    }
}
