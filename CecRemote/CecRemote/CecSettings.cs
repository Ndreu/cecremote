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
        private CecClient client;
        private ushort HdmiPort;
        private CecDeviceType type;

        public CecSettings()
        {

            InitializeComponent();

            this.readConfig(Defaults.CONFIG);

            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);

            backgroundWorker1.RunWorkerAsync();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            client.Close();
            this.Close();
        }

        private void readConfig(string config)
        {
            using (MediaPortal.Profile.Settings reader = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, config)))
            {
                HdmiPort = (ushort)reader.GetValueAsInt("CecRemote", "HDMIPort", 0);
                this.numericUpDown4.Value = HdmiPort;
                this.numericUpDown1.Value = reader.GetValueAsInt("CecRemote", "KeyDownDelay", Defaults.KEY_DOWN_DELAY);
                this.numericUpDown2.Value = reader.GetValueAsInt("CecRemote", "StartDelay", Defaults.KEY_START_DELAY);
                this.numericUpDown3.Value = reader.GetValueAsInt("CecRemote", "StopDelay", Defaults.KEY_STOP_DELAY);
                this.checkBox1.Checked = reader.GetValueAsBool("CecRemote", "FastScrolling", Defaults.FAST_SCROLLING);
                type = (CecSharp.CecDeviceType)Enum.Parse(typeof(CecSharp.CecDeviceType), (reader.GetValueAsString("CecRemote", "Type", Defaults.DEVICE_TYPE)), true);
                this.comboBox2.SelectedItem = reader.GetValueAsString("CecRemote", "Type", Defaults.DEVICE_TYPE);
            }
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            client = new CecClient("Settings", type, CecSharp.CecLogLevel.All);
            client.CecRemoteKeyEvent += new CecRemoteKeyEventHandler(oCecRemote_CecRemoteEvent);

            backgroundWorker1.ReportProgress(10);

            backgroundWorker1.ReportProgress(20);

            if (client.Connect(Defaults.CONNECT_DELAY))
            {
                if (HdmiPort != 0)
                {
                    client.setHdmiPort(0, HdmiPort);
                }
                
                // Send connected
                backgroundWorker1.ReportProgress(30, "Connected=1");
                
                // Send firmware version
                string value = client.getFirmwareVersion().ToString();
                backgroundWorker1.ReportProgress(40, "Firmware=" + value);
                
                // Send Hdmi port
                backgroundWorker1.ReportProgress(50, "HDMIPort=" + HdmiPort);
               
                // Send TV vendor
                value = client.getTvVendor();
                backgroundWorker1.ReportProgress(70, "TVVendor=" + value);
           
                value = client.getAVRdevice();
                
                if (value == null)
                { value = "AVR=No"; }
                else
                { value = "AVR=" + value; }

                backgroundWorker1.ReportProgress(90, value);
            }
            else
            {
                backgroundWorker1.ReportProgress(90, "Connected=0");
            }

        }


        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	    {
	       progressBar1.Value = e.ProgressPercentage;

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


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	    {
                progressBar1.Hide();
                buttonRefresh.Enabled = true;
                tabControl1.Enabled = true;
	    }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            buttonRefresh.Enabled = false;
            tabControl1.Enabled = false;

            client.Close();

            this.setInfoLabels("Updating...");

            progressBar1.Value = 5;
            progressBar1.Show();

            backgroundWorker1.RunWorkerAsync();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
            }
            else
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MediaPortal.Profile.Settings writer = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, Defaults.CONFIG)))
            {
                // Write configuration to MediaPortal.xml

                writer.SetValue("CecRemote", "HDMIPort", numericUpDown4.Value.ToString());
                writer.SetValue("CecRemote", "Type", comboBox2.SelectedItem.ToString());
                writer.SetValueAsBool("CecRemote", "FastScrolling", checkBox1.Checked);
                writer.SetValue("CecRemote", "KeyDownDelay", numericUpDown1.Value.ToString());
                writer.SetValue("CecRemote", "StartDelay", numericUpDown2.Value.ToString());
                writer.SetValue("CecRemote", "StopDelay", numericUpDown3.Value.ToString());
   
            }

            // Set HDMI-port
            HdmiPort = (ushort)numericUpDown4.Value;

            this.buttonRefresh_Click(sender, e);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Open MediaPortal mapping form
            InputMappingForm mappings = new InputMappingForm("CecRemote");
            mappings.ShowDialog(this);
        }


        private void oCecRemote_CecRemoteEvent(object sender, CecRemoteEventArgs e)
        {
            if(this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { oCecRemote_CecRemoteEvent(sender, e); }));
                return;
            }

            // Save keypress only if "Test" -tab is active
            if (tabControl1.SelectedIndex != 2)
            {
                return;
            }

            if (e.Key.Duration > 0)
            {
                label10.Hide();

                // Add new keypress to listview
                string[] listItem = new string[3];
                listItem[0] = ((int)e.Key.Keycode).ToString();
                listItem[1] = e.Key.Keycode.ToString();
                listItem[2] = e.Key.Duration.ToString();

                ListViewItem lvi = new ListViewItem(listItem);
                listView1.Items.Insert(0, lvi);
                
                label10.Show();
            }

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Copy selected listview text to clipboard

            if (listView1.SelectedItems.Count == 0)
            { return; }

            StringBuilder buffer = new StringBuilder();
            foreach (ListViewItem currentItem in listView1.SelectedItems)
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

    }
}
