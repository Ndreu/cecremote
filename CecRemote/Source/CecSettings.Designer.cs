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

namespace CecRemote
{
  
    public partial class CecSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.components = new System.ComponentModel.Container();
          this.tabControl1 = new System.Windows.Forms.TabControl();
          this.tabPage2 = new System.Windows.Forms.TabPage();
          this.groupBox3 = new System.Windows.Forms.GroupBox();
          this.comboBoxConnectedTo = new System.Windows.Forms.ComboBox();
          this.labelConnectedTo = new System.Windows.Forms.Label();
          this.textBoxOsd = new System.Windows.Forms.TextBox();
          this.label8 = new System.Windows.Forms.Label();
          this.labelSetMapping = new System.Windows.Forms.Label();
          this.buttonMapping = new System.Windows.Forms.Button();
          this.numericUpDownHdmi = new System.Windows.Forms.NumericUpDown();
          this.comboBoxDeviceType = new System.Windows.Forms.ComboBox();
          this.labelSetDeviceType = new System.Windows.Forms.Label();
          this.labelSetHdmiPort = new System.Windows.Forms.Label();
          this.groupBox2 = new System.Windows.Forms.GroupBox();
          this.checkBoxExtensiveLogging = new System.Windows.Forms.CheckBox();
          this.label7 = new System.Windows.Forms.Label();
          this.label6 = new System.Windows.Forms.Label();
          this.label4 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.checkBoxTerminateScreensaver = new System.Windows.Forms.CheckBox();
          this.label5 = new System.Windows.Forms.Label();
          this.checkBoxRequireDelayBetweenKeys = new System.Windows.Forms.CheckBox();
          this.label2 = new System.Windows.Forms.Label();
          this.numericUpDownRequireDelay = new System.Windows.Forms.NumericUpDown();
          this.label1 = new System.Windows.Forms.Label();
          this.trackBarRepeatRate = new System.Windows.Forms.TrackBar();
          this.trackBarRepeatDelay = new System.Windows.Forms.TrackBar();
          this.checkBoxFastScrolling = new System.Windows.Forms.CheckBox();
          this.tabPage1 = new System.Windows.Forms.TabPage();
          this.buttonAdvancedPower = new System.Windows.Forms.Button();
          this.groupBox4 = new System.Windows.Forms.GroupBox();
          this.labelOnSleep = new System.Windows.Forms.Label();
          this.labelOnResumeFromSleep = new System.Windows.Forms.Label();
          this.buttonSelectDevicesOnSleep = new System.Windows.Forms.Button();
          this.checkBoxSetInactiveSourceOnSleep = new System.Windows.Forms.CheckBox();
          this.checkBoxStandbyOnSleep = new System.Windows.Forms.CheckBox();
          this.buttonSelectDevicesOnResume = new System.Windows.Forms.Button();
          this.checkBoxSetActiveSourceOnResume = new System.Windows.Forms.CheckBox();
          this.checkBoxWakeDevicesOnResume = new System.Windows.Forms.CheckBox();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.labelOnExit = new System.Windows.Forms.Label();
          this.labelOnStart = new System.Windows.Forms.Label();
          this.buttonSelectDevicesOnExit = new System.Windows.Forms.Button();
          this.checkBoxSetInactiveSourceOnExit = new System.Windows.Forms.CheckBox();
          this.checkBoxWakeDevicesOnStart = new System.Windows.Forms.CheckBox();
          this.buttonSelectDevicesOnStart = new System.Windows.Forms.Button();
          this.checkBoxSetActiveSourceOnStart = new System.Windows.Forms.CheckBox();
          this.buttonSaveSettings = new System.Windows.Forms.Button();
          this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.buttonClose = new System.Windows.Forms.Button();
          this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
          this.buttonRestoreDefaults = new System.Windows.Forms.Button();
          this.checkBoxStandbyOnExit = new System.Windows.Forms.CheckBox();
          this.tabControl1.SuspendLayout();
          this.tabPage2.SuspendLayout();
          this.groupBox3.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHdmi)).BeginInit();
          this.groupBox2.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRequireDelay)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.trackBarRepeatRate)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.trackBarRepeatDelay)).BeginInit();
          this.tabPage1.SuspendLayout();
          this.groupBox4.SuspendLayout();
          this.groupBox1.SuspendLayout();
          this.contextMenuStrip1.SuspendLayout();
          this.SuspendLayout();
          // 
          // tabControl1
          // 
          this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.tabControl1.Controls.Add(this.tabPage2);
          this.tabControl1.Controls.Add(this.tabPage1);
          this.tabControl1.Location = new System.Drawing.Point(12, 12);
          this.tabControl1.Name = "tabControl1";
          this.tabControl1.SelectedIndex = 0;
          this.tabControl1.Size = new System.Drawing.Size(403, 339);
          this.tabControl1.TabIndex = 2;
          // 
          // tabPage2
          // 
          this.tabPage2.AutoScroll = true;
          this.tabPage2.Controls.Add(this.groupBox3);
          this.tabPage2.Controls.Add(this.groupBox2);
          this.tabPage2.Location = new System.Drawing.Point(4, 22);
          this.tabPage2.Name = "tabPage2";
          this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
          this.tabPage2.Size = new System.Drawing.Size(395, 313);
          this.tabPage2.TabIndex = 1;
          this.tabPage2.Text = "Settings";
          this.tabPage2.UseVisualStyleBackColor = true;
          // 
          // groupBox3
          // 
          this.groupBox3.Controls.Add(this.comboBoxConnectedTo);
          this.groupBox3.Controls.Add(this.labelConnectedTo);
          this.groupBox3.Controls.Add(this.textBoxOsd);
          this.groupBox3.Controls.Add(this.label8);
          this.groupBox3.Controls.Add(this.labelSetMapping);
          this.groupBox3.Controls.Add(this.buttonMapping);
          this.groupBox3.Controls.Add(this.numericUpDownHdmi);
          this.groupBox3.Controls.Add(this.comboBoxDeviceType);
          this.groupBox3.Controls.Add(this.labelSetDeviceType);
          this.groupBox3.Controls.Add(this.labelSetHdmiPort);
          this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
          this.groupBox3.Location = new System.Drawing.Point(3, 3);
          this.groupBox3.Name = "groupBox3";
          this.groupBox3.Size = new System.Drawing.Size(389, 115);
          this.groupBox3.TabIndex = 3;
          this.groupBox3.TabStop = false;
          // 
          // comboBoxConnectedTo
          // 
          this.comboBoxConnectedTo.DisplayMember = "2";
          this.comboBoxConnectedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.comboBoxConnectedTo.FormattingEnabled = true;
          this.comboBoxConnectedTo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
          this.comboBoxConnectedTo.Items.AddRange(new object[] {
            "Tv",
            "AudioSystem"});
          this.comboBoxConnectedTo.Location = new System.Drawing.Point(100, 51);
          this.comboBoxConnectedTo.Name = "comboBoxConnectedTo";
          this.comboBoxConnectedTo.Size = new System.Drawing.Size(81, 21);
          this.comboBoxConnectedTo.TabIndex = 11;
          this.toolTip1.SetToolTip(this.comboBoxConnectedTo, "Device where MediaPortal is connected. Only used if autodetection fails.");
          this.comboBoxConnectedTo.SelectedIndexChanged += new System.EventHandler(this.comboBoxConnectedTo_SelectedIndexChanged);
          // 
          // labelConnectedTo
          // 
          this.labelConnectedTo.AutoSize = true;
          this.labelConnectedTo.Location = new System.Drawing.Point(14, 54);
          this.labelConnectedTo.Name = "labelConnectedTo";
          this.labelConnectedTo.Size = new System.Drawing.Size(74, 13);
          this.labelConnectedTo.TabIndex = 10;
          this.labelConnectedTo.Text = "Connected to:";
          // 
          // textBoxOsd
          // 
          this.textBoxOsd.Location = new System.Drawing.Point(100, 87);
          this.textBoxOsd.MaxLength = 14;
          this.textBoxOsd.Name = "textBoxOsd";
          this.textBoxOsd.Size = new System.Drawing.Size(82, 20);
          this.textBoxOsd.TabIndex = 9;
          this.textBoxOsd.Text = "MediaPortal";
          // 
          // label8
          // 
          this.label8.AutoSize = true;
          this.label8.Location = new System.Drawing.Point(14, 90);
          this.label8.Name = "label8";
          this.label8.Size = new System.Drawing.Size(62, 13);
          this.label8.TabIndex = 8;
          this.label8.Text = "OSD-name:";
          // 
          // labelSetMapping
          // 
          this.labelSetMapping.AutoSize = true;
          this.labelSetMapping.Location = new System.Drawing.Point(187, 54);
          this.labelSetMapping.Name = "labelSetMapping";
          this.labelSetMapping.Size = new System.Drawing.Size(84, 13);
          this.labelSetMapping.TabIndex = 7;
          this.labelSetMapping.Text = "Button mapping:";
          // 
          // buttonMapping
          // 
          this.buttonMapping.Location = new System.Drawing.Point(277, 51);
          this.buttonMapping.Name = "buttonMapping";
          this.buttonMapping.Size = new System.Drawing.Size(106, 23);
          this.buttonMapping.TabIndex = 6;
          this.buttonMapping.Text = "Mapping...";
          this.buttonMapping.UseVisualStyleBackColor = true;
          this.buttonMapping.Click += new System.EventHandler(this.buttonMapping_Click);
          // 
          // numericUpDownHdmi
          // 
          this.numericUpDownHdmi.Location = new System.Drawing.Point(100, 18);
          this.numericUpDownHdmi.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
          this.numericUpDownHdmi.Name = "numericUpDownHdmi";
          this.numericUpDownHdmi.Size = new System.Drawing.Size(39, 20);
          this.numericUpDownHdmi.TabIndex = 5;
          this.numericUpDownHdmi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
          // 
          // comboBoxDeviceType
          // 
          this.comboBoxDeviceType.DisplayMember = "2";
          this.comboBoxDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.comboBoxDeviceType.FormattingEnabled = true;
          this.comboBoxDeviceType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
          this.comboBoxDeviceType.Items.AddRange(new object[] {
            "RecordingDevice",
            "PlaybackDevice",
            "Tuner",
            "AudioSystem"});
          this.comboBoxDeviceType.Location = new System.Drawing.Point(277, 18);
          this.comboBoxDeviceType.Name = "comboBoxDeviceType";
          this.comboBoxDeviceType.Size = new System.Drawing.Size(106, 21);
          this.comboBoxDeviceType.TabIndex = 4;
          this.comboBoxDeviceType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDeviceType_SelectedIndexChanged);
          // 
          // labelSetDeviceType
          // 
          this.labelSetDeviceType.AutoSize = true;
          this.labelSetDeviceType.Location = new System.Drawing.Point(187, 22);
          this.labelSetDeviceType.Name = "labelSetDeviceType";
          this.labelSetDeviceType.Size = new System.Drawing.Size(67, 13);
          this.labelSetDeviceType.TabIndex = 3;
          this.labelSetDeviceType.Text = "Device type:";
          this.toolTip1.SetToolTip(this.labelSetDeviceType, "HDMI-Device type that is reported to TV.");
          // 
          // labelSetHdmiPort
          // 
          this.labelSetHdmiPort.AutoSize = true;
          this.labelSetHdmiPort.Location = new System.Drawing.Point(14, 22);
          this.labelSetHdmiPort.Name = "labelSetHdmiPort";
          this.labelSetHdmiPort.Size = new System.Drawing.Size(59, 13);
          this.labelSetHdmiPort.TabIndex = 1;
          this.labelSetHdmiPort.Text = "HDMI port:";
          this.toolTip1.SetToolTip(this.labelSetHdmiPort, "HDMI port where MediaPortal is connected. Only used if autodetection fails.");
          // 
          // groupBox2
          // 
          this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.groupBox2.Controls.Add(this.checkBoxExtensiveLogging);
          this.groupBox2.Controls.Add(this.label7);
          this.groupBox2.Controls.Add(this.label6);
          this.groupBox2.Controls.Add(this.label4);
          this.groupBox2.Controls.Add(this.label3);
          this.groupBox2.Controls.Add(this.checkBoxTerminateScreensaver);
          this.groupBox2.Controls.Add(this.label5);
          this.groupBox2.Controls.Add(this.checkBoxRequireDelayBetweenKeys);
          this.groupBox2.Controls.Add(this.label2);
          this.groupBox2.Controls.Add(this.numericUpDownRequireDelay);
          this.groupBox2.Controls.Add(this.label1);
          this.groupBox2.Controls.Add(this.trackBarRepeatRate);
          this.groupBox2.Controls.Add(this.trackBarRepeatDelay);
          this.groupBox2.Controls.Add(this.checkBoxFastScrolling);
          this.groupBox2.Location = new System.Drawing.Point(6, 124);
          this.groupBox2.Name = "groupBox2";
          this.groupBox2.Size = new System.Drawing.Size(383, 183);
          this.groupBox2.TabIndex = 0;
          this.groupBox2.TabStop = false;
          // 
          // checkBoxExtensiveLogging
          // 
          this.checkBoxExtensiveLogging.AutoSize = true;
          this.checkBoxExtensiveLogging.Location = new System.Drawing.Point(13, 145);
          this.checkBoxExtensiveLogging.Name = "checkBoxExtensiveLogging";
          this.checkBoxExtensiveLogging.Size = new System.Drawing.Size(109, 17);
          this.checkBoxExtensiveLogging.TabIndex = 20;
          this.checkBoxExtensiveLogging.Text = "Extensive logging";
          this.checkBoxExtensiveLogging.UseVisualStyleBackColor = true;
          // 
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Location = new System.Drawing.Point(271, 60);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(24, 13);
          this.label7.TabIndex = 19;
          this.label7.Text = "fast";
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(349, 60);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(28, 13);
          this.label6.TabIndex = 18;
          this.label6.Text = "slow";
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(234, 60);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(27, 13);
          this.label4.TabIndex = 17;
          this.label4.Text = "long";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(140, 59);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(30, 13);
          this.label3.TabIndex = 16;
          this.label3.Text = "short";
          // 
          // checkBoxTerminateScreensaver
          // 
          this.checkBoxTerminateScreensaver.AutoSize = true;
          this.checkBoxTerminateScreensaver.Location = new System.Drawing.Point(13, 122);
          this.checkBoxTerminateScreensaver.Name = "checkBoxTerminateScreensaver";
          this.checkBoxTerminateScreensaver.Size = new System.Drawing.Size(246, 17);
          this.checkBoxTerminateScreensaver.TabIndex = 15;
          this.checkBoxTerminateScreensaver.Text = "Terminate screensaver when button is pressed";
          this.checkBoxTerminateScreensaver.UseVisualStyleBackColor = true;
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Location = new System.Drawing.Point(238, 98);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(20, 13);
          this.label5.TabIndex = 6;
          this.label5.Text = "ms";
          // 
          // checkBoxRequireDelayBetweenKeys
          // 
          this.checkBoxRequireDelayBetweenKeys.AutoSize = true;
          this.checkBoxRequireDelayBetweenKeys.Location = new System.Drawing.Point(13, 99);
          this.checkBoxRequireDelayBetweenKeys.Name = "checkBoxRequireDelayBetweenKeys";
          this.checkBoxRequireDelayBetweenKeys.Size = new System.Drawing.Size(163, 17);
          this.checkBoxRequireDelayBetweenKeys.TabIndex = 11;
          this.checkBoxRequireDelayBetweenKeys.Text = "Require delay between keys:";
          this.toolTip1.SetToolTip(this.checkBoxRequireDelayBetweenKeys, "If you have problems with double taps, check this setting and set a delay that wo" +
                  "rks for you.\r\nLeave unchecked if you don\'t get double taps.\r\n");
          this.checkBoxRequireDelayBetweenKeys.UseVisualStyleBackColor = true;
          this.checkBoxRequireDelayBetweenKeys.CheckedChanged += new System.EventHandler(this.checkBoxRequireDelayBetweenKeys_CheckedChanged);
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(295, 12);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(66, 13);
          this.label2.TabIndex = 14;
          this.label2.Text = "Repeat rate:";
          // 
          // numericUpDownRequireDelay
          // 
          this.numericUpDownRequireDelay.Enabled = false;
          this.numericUpDownRequireDelay.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
          this.numericUpDownRequireDelay.Location = new System.Drawing.Point(187, 96);
          this.numericUpDownRequireDelay.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
          this.numericUpDownRequireDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
          this.numericUpDownRequireDelay.Name = "numericUpDownRequireDelay";
          this.numericUpDownRequireDelay.Size = new System.Drawing.Size(46, 20);
          this.numericUpDownRequireDelay.TabIndex = 3;
          this.numericUpDownRequireDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
          this.numericUpDownRequireDelay.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(165, 11);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(73, 13);
          this.label1.TabIndex = 13;
          this.label1.Text = "Repeat delay:";
          // 
          // trackBarRepeatRate
          // 
          this.trackBarRepeatRate.BackColor = System.Drawing.SystemColors.ControlLightLight;
          this.trackBarRepeatRate.LargeChange = 10;
          this.trackBarRepeatRate.Location = new System.Drawing.Point(274, 28);
          this.trackBarRepeatRate.Maximum = 100;
          this.trackBarRepeatRate.Minimum = 20;
          this.trackBarRepeatRate.Name = "trackBarRepeatRate";
          this.trackBarRepeatRate.Size = new System.Drawing.Size(104, 45);
          this.trackBarRepeatRate.SmallChange = 10;
          this.trackBarRepeatRate.TabIndex = 12;
          this.trackBarRepeatRate.TickFrequency = 20;
          this.trackBarRepeatRate.Value = 40;
          // 
          // trackBarRepeatDelay
          // 
          this.trackBarRepeatDelay.BackColor = System.Drawing.SystemColors.ControlLightLight;
          this.trackBarRepeatDelay.LargeChange = 1;
          this.trackBarRepeatDelay.Location = new System.Drawing.Point(143, 27);
          this.trackBarRepeatDelay.Maximum = 5;
          this.trackBarRepeatDelay.Minimum = 1;
          this.trackBarRepeatDelay.Name = "trackBarRepeatDelay";
          this.trackBarRepeatDelay.Size = new System.Drawing.Size(115, 45);
          this.trackBarRepeatDelay.TabIndex = 11;
          this.trackBarRepeatDelay.Value = 2;
          // 
          // checkBoxFastScrolling
          // 
          this.checkBoxFastScrolling.AutoSize = true;
          this.checkBoxFastScrolling.Location = new System.Drawing.Point(14, 28);
          this.checkBoxFastScrolling.Name = "checkBoxFastScrolling";
          this.checkBoxFastScrolling.Size = new System.Drawing.Size(89, 17);
          this.checkBoxFastScrolling.TabIndex = 10;
          this.checkBoxFastScrolling.Text = "Fast Scrolling";
          this.checkBoxFastScrolling.UseVisualStyleBackColor = true;
          this.checkBoxFastScrolling.CheckedChanged += new System.EventHandler(this.checkBoxFastScrolling_CheckedChanged);
          // 
          // tabPage1
          // 
          this.tabPage1.Controls.Add(this.buttonAdvancedPower);
          this.tabPage1.Controls.Add(this.groupBox4);
          this.tabPage1.Controls.Add(this.groupBox1);
          this.tabPage1.Location = new System.Drawing.Point(4, 22);
          this.tabPage1.Name = "tabPage1";
          this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
          this.tabPage1.Size = new System.Drawing.Size(395, 313);
          this.tabPage1.TabIndex = 2;
          this.tabPage1.Text = "Power Options ";
          this.tabPage1.UseVisualStyleBackColor = true;
          // 
          // buttonAdvancedPower
          // 
          this.buttonAdvancedPower.Location = new System.Drawing.Point(6, 284);
          this.buttonAdvancedPower.Name = "buttonAdvancedPower";
          this.buttonAdvancedPower.Size = new System.Drawing.Size(119, 23);
          this.buttonAdvancedPower.TabIndex = 2;
          this.buttonAdvancedPower.Text = "Advanced settings...";
          this.buttonAdvancedPower.UseVisualStyleBackColor = true;
          this.buttonAdvancedPower.Click += new System.EventHandler(this.buttonAdvancedPower_Click);
          // 
          // groupBox4
          // 
          this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.groupBox4.Controls.Add(this.labelOnSleep);
          this.groupBox4.Controls.Add(this.labelOnResumeFromSleep);
          this.groupBox4.Controls.Add(this.buttonSelectDevicesOnSleep);
          this.groupBox4.Controls.Add(this.checkBoxSetInactiveSourceOnSleep);
          this.groupBox4.Controls.Add(this.checkBoxStandbyOnSleep);
          this.groupBox4.Controls.Add(this.buttonSelectDevicesOnResume);
          this.groupBox4.Controls.Add(this.checkBoxSetActiveSourceOnResume);
          this.groupBox4.Controls.Add(this.checkBoxWakeDevicesOnResume);
          this.groupBox4.Location = new System.Drawing.Point(6, 154);
          this.groupBox4.Name = "groupBox4";
          this.groupBox4.Size = new System.Drawing.Size(383, 124);
          this.groupBox4.TabIndex = 1;
          this.groupBox4.TabStop = false;
          this.groupBox4.Text = "System Power Options";
          // 
          // labelOnSleep
          // 
          this.labelOnSleep.AutoSize = true;
          this.labelOnSleep.Location = new System.Drawing.Point(203, 16);
          this.labelOnSleep.Name = "labelOnSleep";
          this.labelOnSleep.Size = new System.Drawing.Size(77, 13);
          this.labelOnSleep.TabIndex = 8;
          this.labelOnSleep.Text = "Entering sleep:";
          // 
          // labelOnResumeFromSleep
          // 
          this.labelOnResumeFromSleep.AutoSize = true;
          this.labelOnResumeFromSleep.Location = new System.Drawing.Point(17, 16);
          this.labelOnResumeFromSleep.Name = "labelOnResumeFromSleep";
          this.labelOnResumeFromSleep.Size = new System.Drawing.Size(100, 13);
          this.labelOnResumeFromSleep.TabIndex = 7;
          this.labelOnResumeFromSleep.Text = "Resume from sleep:";
          // 
          // buttonSelectDevicesOnSleep
          // 
          this.buttonSelectDevicesOnSleep.Location = new System.Drawing.Point(206, 89);
          this.buttonSelectDevicesOnSleep.Name = "buttonSelectDevicesOnSleep";
          this.buttonSelectDevicesOnSleep.Size = new System.Drawing.Size(100, 23);
          this.buttonSelectDevicesOnSleep.TabIndex = 5;
          this.buttonSelectDevicesOnSleep.Text = "Select devices...";
          this.buttonSelectDevicesOnSleep.UseVisualStyleBackColor = true;
          this.buttonSelectDevicesOnSleep.Click += new System.EventHandler(this.buttonSelectDevicesOnSleep_Click);
          // 
          // checkBoxSetInactiveSourceOnSleep
          // 
          this.checkBoxSetInactiveSourceOnSleep.AutoSize = true;
          this.checkBoxSetInactiveSourceOnSleep.Location = new System.Drawing.Point(206, 66);
          this.checkBoxSetInactiveSourceOnSleep.Name = "checkBoxSetInactiveSourceOnSleep";
          this.checkBoxSetInactiveSourceOnSleep.Size = new System.Drawing.Size(126, 17);
          this.checkBoxSetInactiveSourceOnSleep.TabIndex = 4;
          this.checkBoxSetInactiveSourceOnSleep.Text = "Send inactive source";
          this.checkBoxSetInactiveSourceOnSleep.UseVisualStyleBackColor = true;
          // 
          // checkBoxStandbyOnSleep
          // 
          this.checkBoxStandbyOnSleep.AutoSize = true;
          this.checkBoxStandbyOnSleep.Checked = true;
          this.checkBoxStandbyOnSleep.CheckState = System.Windows.Forms.CheckState.Checked;
          this.checkBoxStandbyOnSleep.Location = new System.Drawing.Point(206, 43);
          this.checkBoxStandbyOnSleep.Name = "checkBoxStandbyOnSleep";
          this.checkBoxStandbyOnSleep.Size = new System.Drawing.Size(171, 17);
          this.checkBoxStandbyOnSleep.TabIndex = 3;
          this.checkBoxStandbyOnSleep.Text = "Put devices into standby mode";
          this.checkBoxStandbyOnSleep.UseVisualStyleBackColor = true;
          // 
          // buttonSelectDevicesOnResume
          // 
          this.buttonSelectDevicesOnResume.Location = new System.Drawing.Point(20, 89);
          this.buttonSelectDevicesOnResume.Name = "buttonSelectDevicesOnResume";
          this.buttonSelectDevicesOnResume.Size = new System.Drawing.Size(99, 23);
          this.buttonSelectDevicesOnResume.TabIndex = 2;
          this.buttonSelectDevicesOnResume.Text = "Select devices...";
          this.buttonSelectDevicesOnResume.UseVisualStyleBackColor = true;
          this.buttonSelectDevicesOnResume.Click += new System.EventHandler(this.buttonSelectDevicesOnResume_Click);
          // 
          // checkBoxSetActiveSourceOnResume
          // 
          this.checkBoxSetActiveSourceOnResume.AutoSize = true;
          this.checkBoxSetActiveSourceOnResume.Checked = true;
          this.checkBoxSetActiveSourceOnResume.CheckState = System.Windows.Forms.CheckState.Checked;
          this.checkBoxSetActiveSourceOnResume.Location = new System.Drawing.Point(20, 66);
          this.checkBoxSetActiveSourceOnResume.Name = "checkBoxSetActiveSourceOnResume";
          this.checkBoxSetActiveSourceOnResume.Size = new System.Drawing.Size(118, 17);
          this.checkBoxSetActiveSourceOnResume.TabIndex = 1;
          this.checkBoxSetActiveSourceOnResume.Text = "Send active source";
          this.checkBoxSetActiveSourceOnResume.UseVisualStyleBackColor = true;
          // 
          // checkBoxWakeDevicesOnResume
          // 
          this.checkBoxWakeDevicesOnResume.AutoSize = true;
          this.checkBoxWakeDevicesOnResume.Checked = true;
          this.checkBoxWakeDevicesOnResume.CheckState = System.Windows.Forms.CheckState.Checked;
          this.checkBoxWakeDevicesOnResume.Location = new System.Drawing.Point(20, 43);
          this.checkBoxWakeDevicesOnResume.Name = "checkBoxWakeDevicesOnResume";
          this.checkBoxWakeDevicesOnResume.Size = new System.Drawing.Size(95, 17);
          this.checkBoxWakeDevicesOnResume.TabIndex = 0;
          this.checkBoxWakeDevicesOnResume.Text = "Wake devices";
          this.checkBoxWakeDevicesOnResume.UseVisualStyleBackColor = true;
          // 
          // groupBox1
          // 
          this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.groupBox1.Controls.Add(this.checkBoxStandbyOnExit);
          this.groupBox1.Controls.Add(this.labelOnExit);
          this.groupBox1.Controls.Add(this.labelOnStart);
          this.groupBox1.Controls.Add(this.buttonSelectDevicesOnExit);
          this.groupBox1.Controls.Add(this.checkBoxSetInactiveSourceOnExit);
          this.groupBox1.Controls.Add(this.checkBoxWakeDevicesOnStart);
          this.groupBox1.Controls.Add(this.buttonSelectDevicesOnStart);
          this.groupBox1.Controls.Add(this.checkBoxSetActiveSourceOnStart);
          this.groupBox1.Location = new System.Drawing.Point(6, 16);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(383, 132);
          this.groupBox1.TabIndex = 0;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "MediaPortal Power Options";
          // 
          // labelOnExit
          // 
          this.labelOnExit.AutoSize = true;
          this.labelOnExit.Location = new System.Drawing.Point(203, 16);
          this.labelOnExit.Name = "labelOnExit";
          this.labelOnExit.Size = new System.Drawing.Size(85, 13);
          this.labelOnExit.TabIndex = 7;
          this.labelOnExit.Text = "MediaPortal exit:";
          // 
          // labelOnStart
          // 
          this.labelOnStart.AutoSize = true;
          this.labelOnStart.Location = new System.Drawing.Point(17, 16);
          this.labelOnStart.Name = "labelOnStart";
          this.labelOnStart.Size = new System.Drawing.Size(89, 13);
          this.labelOnStart.TabIndex = 6;
          this.labelOnStart.Text = "MediaPortal start:";
          // 
          // buttonSelectDevicesOnExit
          // 
          this.buttonSelectDevicesOnExit.Location = new System.Drawing.Point(206, 91);
          this.buttonSelectDevicesOnExit.Name = "buttonSelectDevicesOnExit";
          this.buttonSelectDevicesOnExit.Size = new System.Drawing.Size(100, 23);
          this.buttonSelectDevicesOnExit.TabIndex = 5;
          this.buttonSelectDevicesOnExit.Text = "Select devices...";
          this.buttonSelectDevicesOnExit.UseVisualStyleBackColor = true;
          this.buttonSelectDevicesOnExit.Click += new System.EventHandler(this.buttonSelectDevicesOnStandby_Click);
          // 
          // checkBoxSetInactiveSourceOnExit
          // 
          this.checkBoxSetInactiveSourceOnExit.AutoSize = true;
          this.checkBoxSetInactiveSourceOnExit.Location = new System.Drawing.Point(206, 68);
          this.checkBoxSetInactiveSourceOnExit.Name = "checkBoxSetInactiveSourceOnExit";
          this.checkBoxSetInactiveSourceOnExit.Size = new System.Drawing.Size(126, 17);
          this.checkBoxSetInactiveSourceOnExit.TabIndex = 4;
          this.checkBoxSetInactiveSourceOnExit.Text = "Send inactive source";
          this.toolTip1.SetToolTip(this.checkBoxSetInactiveSourceOnExit, "Makes MediaPortal inactive source on exit.\r\nTV will return to last or default inp" +
                  "ut.");
          this.checkBoxSetInactiveSourceOnExit.UseVisualStyleBackColor = true;
          // 
          // checkBoxWakeDevicesOnStart
          // 
          this.checkBoxWakeDevicesOnStart.AutoSize = true;
          this.checkBoxWakeDevicesOnStart.Checked = true;
          this.checkBoxWakeDevicesOnStart.CheckState = System.Windows.Forms.CheckState.Checked;
          this.checkBoxWakeDevicesOnStart.Location = new System.Drawing.Point(20, 45);
          this.checkBoxWakeDevicesOnStart.Name = "checkBoxWakeDevicesOnStart";
          this.checkBoxWakeDevicesOnStart.Size = new System.Drawing.Size(95, 17);
          this.checkBoxWakeDevicesOnStart.TabIndex = 2;
          this.checkBoxWakeDevicesOnStart.Text = "Wake devices";
          this.checkBoxWakeDevicesOnStart.UseVisualStyleBackColor = true;
          // 
          // buttonSelectDevicesOnStart
          // 
          this.buttonSelectDevicesOnStart.Location = new System.Drawing.Point(18, 91);
          this.buttonSelectDevicesOnStart.Name = "buttonSelectDevicesOnStart";
          this.buttonSelectDevicesOnStart.Size = new System.Drawing.Size(100, 23);
          this.buttonSelectDevicesOnStart.TabIndex = 1;
          this.buttonSelectDevicesOnStart.Text = "Select devices...";
          this.toolTip1.SetToolTip(this.buttonSelectDevicesOnStart, "Select devices you want to wake when starting");
          this.buttonSelectDevicesOnStart.UseVisualStyleBackColor = true;
          this.buttonSelectDevicesOnStart.Click += new System.EventHandler(this.buttonSelectDevicesOnStart_Click);
          // 
          // checkBoxSetActiveSourceOnStart
          // 
          this.checkBoxSetActiveSourceOnStart.AutoSize = true;
          this.checkBoxSetActiveSourceOnStart.Checked = true;
          this.checkBoxSetActiveSourceOnStart.CheckState = System.Windows.Forms.CheckState.Checked;
          this.checkBoxSetActiveSourceOnStart.Location = new System.Drawing.Point(20, 68);
          this.checkBoxSetActiveSourceOnStart.Name = "checkBoxSetActiveSourceOnStart";
          this.checkBoxSetActiveSourceOnStart.Size = new System.Drawing.Size(118, 17);
          this.checkBoxSetActiveSourceOnStart.TabIndex = 0;
          this.checkBoxSetActiveSourceOnStart.Text = "Send active source";
          this.toolTip1.SetToolTip(this.checkBoxSetActiveSourceOnStart, "Sets MediaPortal as the active source when starting.\r\nTV will select correct inpu" +
                  "t automatically.\r\nNote that setting active source alone can trigger TV to power " +
                  "on. \r\n");
          this.checkBoxSetActiveSourceOnStart.UseVisualStyleBackColor = true;
          // 
          // buttonSaveSettings
          // 
          this.buttonSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.buttonSaveSettings.Location = new System.Drawing.Point(274, 357);
          this.buttonSaveSettings.Name = "buttonSaveSettings";
          this.buttonSaveSettings.Size = new System.Drawing.Size(65, 25);
          this.buttonSaveSettings.TabIndex = 5;
          this.buttonSaveSettings.Text = "OK";
          this.buttonSaveSettings.UseVisualStyleBackColor = true;
          this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
          // 
          // contextMenuStrip1
          // 
          this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
          this.contextMenuStrip1.Name = "contextMenuStrip1";
          this.contextMenuStrip1.Size = new System.Drawing.Size(139, 26);
          // 
          // copyToolStripMenuItem
          // 
          this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
          this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
          this.copyToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
          this.copyToolStripMenuItem.Text = "Copy";
          // 
          // buttonClose
          // 
          this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.buttonClose.Location = new System.Drawing.Point(345, 357);
          this.buttonClose.Name = "buttonClose";
          this.buttonClose.Size = new System.Drawing.Size(70, 25);
          this.buttonClose.TabIndex = 3;
          this.buttonClose.Text = "Cancel";
          this.buttonClose.UseVisualStyleBackColor = true;
          this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
          // 
          // buttonRestoreDefaults
          // 
          this.buttonRestoreDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
          this.buttonRestoreDefaults.Location = new System.Drawing.Point(12, 359);
          this.buttonRestoreDefaults.Name = "buttonRestoreDefaults";
          this.buttonRestoreDefaults.Size = new System.Drawing.Size(97, 23);
          this.buttonRestoreDefaults.TabIndex = 6;
          this.buttonRestoreDefaults.Text = "Restore Defaults";
          this.buttonRestoreDefaults.UseVisualStyleBackColor = true;
          this.buttonRestoreDefaults.Click += new System.EventHandler(this.buttonRestoreDefaults_Click);
          // 
          // checkBoxStandbyOnExit
          // 
          this.checkBoxStandbyOnExit.AutoSize = true;
          this.checkBoxStandbyOnExit.Location = new System.Drawing.Point(206, 45);
          this.checkBoxStandbyOnExit.Name = "checkBoxStandbyOnExit";
          this.checkBoxStandbyOnExit.Size = new System.Drawing.Size(171, 17);
          this.checkBoxStandbyOnExit.TabIndex = 8;
          this.checkBoxStandbyOnExit.Text = "Put devices into standby mode";
          this.checkBoxStandbyOnExit.UseVisualStyleBackColor = true;
          // 
          // CecSettings
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(427, 394);
          this.Controls.Add(this.buttonSaveSettings);
          this.Controls.Add(this.buttonRestoreDefaults);
          this.Controls.Add(this.tabControl1);
          this.Controls.Add(this.buttonClose);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.Name = "CecSettings";
          this.ShowIcon = false;
          this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
          this.Text = "CecRemote - Settings";
          this.tabControl1.ResumeLayout(false);
          this.tabPage2.ResumeLayout(false);
          this.groupBox3.ResumeLayout(false);
          this.groupBox3.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHdmi)).EndInit();
          this.groupBox2.ResumeLayout(false);
          this.groupBox2.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRequireDelay)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.trackBarRepeatRate)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.trackBarRepeatDelay)).EndInit();
          this.tabPage1.ResumeLayout(false);
          this.groupBox4.ResumeLayout(false);
          this.groupBox4.PerformLayout();
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          this.contextMenuStrip1.ResumeLayout(false);
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelSetHdmiPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxFastScrolling;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownRequireDelay;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.NumericUpDown numericUpDownHdmi;
        private System.Windows.Forms.ComboBox comboBoxDeviceType;
        private System.Windows.Forms.Label labelSetDeviceType;
        private System.Windows.Forms.Label labelSetMapping;
        private System.Windows.Forms.Button buttonMapping;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxRequireDelayBetweenKeys;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonSelectDevicesOnSleep;
        private System.Windows.Forms.CheckBox checkBoxSetInactiveSourceOnSleep;
        private System.Windows.Forms.CheckBox checkBoxStandbyOnSleep;
        private System.Windows.Forms.Button buttonSelectDevicesOnResume;
        private System.Windows.Forms.CheckBox checkBoxSetActiveSourceOnResume;
        private System.Windows.Forms.CheckBox checkBoxWakeDevicesOnResume;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSelectDevicesOnExit;
        private System.Windows.Forms.CheckBox checkBoxSetInactiveSourceOnExit;
        private System.Windows.Forms.CheckBox checkBoxWakeDevicesOnStart;
        private System.Windows.Forms.Button buttonSelectDevicesOnStart;
        private System.Windows.Forms.CheckBox checkBoxSetActiveSourceOnStart;
        private System.Windows.Forms.Button buttonRestoreDefaults;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxTerminateScreensaver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarRepeatRate;
        private System.Windows.Forms.TrackBar trackBarRepeatDelay;
        private System.Windows.Forms.CheckBox checkBoxExtensiveLogging;
        private System.Windows.Forms.TextBox textBoxOsd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelOnSleep;
        private System.Windows.Forms.Label labelOnResumeFromSleep;
        private System.Windows.Forms.Label labelOnExit;
        private System.Windows.Forms.Label labelOnStart;
        private System.Windows.Forms.ComboBox comboBoxConnectedTo;
        private System.Windows.Forms.Label labelConnectedTo;
        private System.Windows.Forms.Button buttonAdvancedPower;
        private System.Windows.Forms.CheckBox checkBoxStandbyOnExit;
    }
    
   
}