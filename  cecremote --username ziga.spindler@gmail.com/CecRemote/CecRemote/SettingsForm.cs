using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MediaPortal.Profile;
using MediaPortal.Configuration;

namespace CecRemote
{
    public partial class SettingsForm : Form
    {
        CecClient client;
        Thread communicationThread;
        PressButton pb;
        String buttonName;

        public SettingsForm()
        {
            client = new CecClient();
            buttonName = null;
            pb = new PressButton();

            InitializeComponent();
            
            String hdmiPort;
            using (MediaPortal.Profile.Settings reader = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, "MediaPortal.xml")))
            {
                hdmiPort = reader.GetValue("CecRemote", "HDMIPort");
                if (hdmiPort == "")
                {
                    hdmiPort = "1";
                }
                else
                {
                    foreach (Control c in this.groupBox1.Controls)
                    {
                        String[] temp = c.Name.Split('_');
                        if (temp[0] == "l")
                        {
                            Label l = (Label)c;
                            l.Text = reader.GetValue("CecRemote", temp[1]);
                        }
                    }
                }
                cb_hdmiPort.Text = hdmiPort;
            }

            if(client.Connect(10000))
            {
                client.setHdmiPort(0, int.Parse(cb_hdmiPort.Text));
                communicationThread = new Thread(new ThreadStart(comFunc));
                communicationThread.IsBackground = true;
                communicationThread.Start();
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (communicationThread.IsAlive)
                communicationThread.Abort();
            client.Close();
        }

        private void comFunc()
        {
            while (true)
            {
                string command = client.getCommand();
                if (command != null)
                {
                    string[] temp = command.Split(';');
                    if (temp[1] != "0" && buttonName != null)
                    {
                        this.Invoke(new keyPressedDelegate(keyPressed), new object[] { temp[0] });
                    }
                }
                Thread.Sleep(1);
            }
        }

        private delegate void keyPressedDelegate(String buttonPressed);

        private void keyPressed(String buttonPressed)
        {
            Label l = (Label)this.Controls.Find("l_" + buttonName, true)[0];
            l.Text = buttonPressed;
            pb.Close();
        }

        private void bt_click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            String[] temp = bt.Name.Split('_');
            buttonName = temp[1];
            pb.ShowDialog();
            buttonName = null;
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save()
        {
            using (MediaPortal.Profile.Settings writer = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, "MediaPortal.xml")))
            {
                writer.SetValue("CecRemote", "HDMIPort", cb_hdmiPort.SelectedItem.ToString());
                foreach (Control c in this.groupBox1.Controls)
                {
                    String[] temp = c.Name.Split('_');
                    if (temp[0] == "l")
                    {
                        Label l = (Label)c;
                        writer.SetValue("CecRemote", temp[1], l.Text);
                    }
                }
            }
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            save();
            this.Close();
        }

        private void cb_hdmiPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            client.setHdmiPort(0, int.Parse(cb_hdmiPort.Text));
        }
    }
}
