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
    partial class CecSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelAvrVendorValue = new System.Windows.Forms.Label();
            this.labelAvrConnectedValue = new System.Windows.Forms.Label();
            this.labelTvVendorValue = new System.Windows.Forms.Label();
            this.labelHdmiPortValue = new System.Windows.Forms.Label();
            this.labelFirmwareValue = new System.Windows.Forms.Label();
            this.labelAdapterStatusValue = new System.Windows.Forms.Label();
            this.labelAvrVendor = new System.Windows.Forms.Label();
            this.labelAvrConnected = new System.Windows.Forms.Label();
            this.labelHdmiPort = new System.Windows.Forms.Label();
            this.labelTvVendor = new System.Windows.Forms.Label();
            this.labelFirmware = new System.Windows.Forms.Label();
            this.labelAdapterStatus = new System.Windows.Forms.Label();
            this.progressBarConnect = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelSetMapping = new System.Windows.Forms.Label();
            this.buttonMapping = new System.Windows.Forms.Button();
            this.numericUpDownHdmi = new System.Windows.Forms.NumericUpDown();
            this.comboBoxDeviceType = new System.Windows.Forms.ComboBox();
            this.labelSetDeviceType = new System.Windows.Forms.Label();
            this.labelSetHdmiPort = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxPowerOff = new System.Windows.Forms.CheckBox();
            this.checkBoxInactiveSource = new System.Windows.Forms.CheckBox();
            this.checkBoxIgnoreShortPulses = new System.Windows.Forms.CheckBox();
            this.checkBoxFastScrolling = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownFilter = new System.Windows.Forms.NumericUpDown();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labelTest = new System.Windows.Forms.Label();
            this.listViewTestKeys = new System.Windows.Forms.ListView();
            this.columnKeyCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonClose = new System.Windows.Forms.Button();
            this.backgroundWorkerConnect = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHdmi)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFilter)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelAvrVendorValue);
            this.groupBox1.Controls.Add(this.labelAvrConnectedValue);
            this.groupBox1.Controls.Add(this.labelTvVendorValue);
            this.groupBox1.Controls.Add(this.labelHdmiPortValue);
            this.groupBox1.Controls.Add(this.labelFirmwareValue);
            this.groupBox1.Controls.Add(this.labelAdapterStatusValue);
            this.groupBox1.Controls.Add(this.labelAvrVendor);
            this.groupBox1.Controls.Add(this.labelAvrConnected);
            this.groupBox1.Controls.Add(this.labelHdmiPort);
            this.groupBox1.Controls.Add(this.labelTvVendor);
            this.groupBox1.Controls.Add(this.labelFirmware);
            this.groupBox1.Controls.Add(this.labelAdapterStatus);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CecRemote information";
            // 
            // labelAvrVendorValue
            // 
            this.labelAvrVendorValue.AutoSize = true;
            this.labelAvrVendorValue.Location = new System.Drawing.Point(128, 171);
            this.labelAvrVendorValue.Name = "labelAvrVendorValue";
            this.labelAvrVendorValue.Size = new System.Drawing.Size(59, 13);
            this.labelAvrVendorValue.TabIndex = 11;
            this.labelAvrVendorValue.Text = "Updating...";
            // 
            // labelAvrConnectedValue
            // 
            this.labelAvrConnectedValue.AutoSize = true;
            this.labelAvrConnectedValue.Location = new System.Drawing.Point(128, 148);
            this.labelAvrConnectedValue.Name = "labelAvrConnectedValue";
            this.labelAvrConnectedValue.Size = new System.Drawing.Size(59, 13);
            this.labelAvrConnectedValue.TabIndex = 10;
            this.labelAvrConnectedValue.Text = "Updating...";
            // 
            // labelTvVendorValue
            // 
            this.labelTvVendorValue.AutoSize = true;
            this.labelTvVendorValue.Location = new System.Drawing.Point(128, 126);
            this.labelTvVendorValue.Name = "labelTvVendorValue";
            this.labelTvVendorValue.Size = new System.Drawing.Size(59, 13);
            this.labelTvVendorValue.TabIndex = 9;
            this.labelTvVendorValue.Text = "Updating...";
            // 
            // labelHdmiPortValue
            // 
            this.labelHdmiPortValue.AutoSize = true;
            this.labelHdmiPortValue.Location = new System.Drawing.Point(128, 91);
            this.labelHdmiPortValue.Name = "labelHdmiPortValue";
            this.labelHdmiPortValue.Size = new System.Drawing.Size(59, 13);
            this.labelHdmiPortValue.TabIndex = 8;
            this.labelHdmiPortValue.Text = "Updating...";
            // 
            // labelFirmwareValue
            // 
            this.labelFirmwareValue.AutoSize = true;
            this.labelFirmwareValue.Location = new System.Drawing.Point(128, 69);
            this.labelFirmwareValue.Name = "labelFirmwareValue";
            this.labelFirmwareValue.Size = new System.Drawing.Size(59, 13);
            this.labelFirmwareValue.TabIndex = 7;
            this.labelFirmwareValue.Text = "Updating...";
            // 
            // labelAdapterStatusValue
            // 
            this.labelAdapterStatusValue.AutoSize = true;
            this.labelAdapterStatusValue.Location = new System.Drawing.Point(128, 47);
            this.labelAdapterStatusValue.Name = "labelAdapterStatusValue";
            this.labelAdapterStatusValue.Size = new System.Drawing.Size(59, 13);
            this.labelAdapterStatusValue.TabIndex = 6;
            this.labelAdapterStatusValue.Text = "Updating...";
            // 
            // labelAvrVendor
            // 
            this.labelAvrVendor.AutoSize = true;
            this.labelAvrVendor.Location = new System.Drawing.Point(19, 171);
            this.labelAvrVendor.Name = "labelAvrVendor";
            this.labelAvrVendor.Size = new System.Drawing.Size(106, 13);
            this.labelAvrVendor.TabIndex = 5;
            this.labelAvrVendor.Text = "AV-Receiver vendor:";
            // 
            // labelAvrConnected
            // 
            this.labelAvrConnected.AutoSize = true;
            this.labelAvrConnected.Location = new System.Drawing.Point(19, 148);
            this.labelAvrConnected.Name = "labelAvrConnected";
            this.labelAvrConnected.Size = new System.Drawing.Size(101, 13);
            this.labelAvrConnected.TabIndex = 4;
            this.labelAvrConnected.Text = "AV-Receiver status:";
            // 
            // labelHdmiPort
            // 
            this.labelHdmiPort.AutoSize = true;
            this.labelHdmiPort.Location = new System.Drawing.Point(19, 91);
            this.labelHdmiPort.Name = "labelHdmiPort";
            this.labelHdmiPort.Size = new System.Drawing.Size(96, 13);
            this.labelHdmiPort.TabIndex = 3;
            this.labelHdmiPort.Text = "Current HDMI port:";
            // 
            // labelTvVendor
            // 
            this.labelTvVendor.AutoSize = true;
            this.labelTvVendor.Location = new System.Drawing.Point(19, 126);
            this.labelTvVendor.Name = "labelTvVendor";
            this.labelTvVendor.Size = new System.Drawing.Size(60, 13);
            this.labelTvVendor.TabIndex = 2;
            this.labelTvVendor.Text = "TV vendor:";
            // 
            // labelFirmware
            // 
            this.labelFirmware.AutoSize = true;
            this.labelFirmware.Location = new System.Drawing.Point(19, 69);
            this.labelFirmware.Name = "labelFirmware";
            this.labelFirmware.Size = new System.Drawing.Size(89, 13);
            this.labelFirmware.TabIndex = 1;
            this.labelFirmware.Text = "Firmware version:";
            // 
            // labelAdapterStatus
            // 
            this.labelAdapterStatus.AutoSize = true;
            this.labelAdapterStatus.Location = new System.Drawing.Point(19, 47);
            this.labelAdapterStatus.Name = "labelAdapterStatus";
            this.labelAdapterStatus.Size = new System.Drawing.Size(102, 13);
            this.labelAdapterStatus.TabIndex = 0;
            this.labelAdapterStatus.Text = "CEC-Adapter status:";
            // 
            // progressBarConnect
            // 
            this.progressBarConnect.Location = new System.Drawing.Point(12, 366);
            this.progressBarConnect.Name = "progressBarConnect";
            this.progressBarConnect.Size = new System.Drawing.Size(168, 23);
            this.progressBarConnect.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(303, 338);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonRefresh);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(295, 312);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Enabled = false;
            this.buttonRefresh.Location = new System.Drawing.Point(186, 268);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonSaveSettings);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(295, 312);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(184, 275);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(99, 23);
            this.buttonSaveSettings.TabIndex = 5;
            this.buttonSaveSettings.Text = "Save settings";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelSetMapping);
            this.groupBox3.Controls.Add(this.buttonMapping);
            this.groupBox3.Controls.Add(this.numericUpDownHdmi);
            this.groupBox3.Controls.Add(this.comboBoxDeviceType);
            this.groupBox3.Controls.Add(this.labelSetDeviceType);
            this.groupBox3.Controls.Add(this.labelSetHdmiPort);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 132);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // labelSetMapping
            // 
            this.labelSetMapping.AutoSize = true;
            this.labelSetMapping.Location = new System.Drawing.Point(6, 93);
            this.labelSetMapping.Name = "labelSetMapping";
            this.labelSetMapping.Size = new System.Drawing.Size(110, 13);
            this.labelSetMapping.TabIndex = 7;
            this.labelSetMapping.Text = "Change key mapping:";
            // 
            // buttonMapping
            // 
            this.buttonMapping.Location = new System.Drawing.Point(132, 88);
            this.buttonMapping.Name = "buttonMapping";
            this.buttonMapping.Size = new System.Drawing.Size(117, 23);
            this.buttonMapping.TabIndex = 6;
            this.buttonMapping.Text = "Mapping...";
            this.buttonMapping.UseVisualStyleBackColor = true;
            this.buttonMapping.Click += new System.EventHandler(this.buttonMapping_Click);
            // 
            // numericUpDownHdmi
            // 
            this.numericUpDownHdmi.Location = new System.Drawing.Point(132, 14);
            this.numericUpDownHdmi.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownHdmi.Name = "numericUpDownHdmi";
            this.numericUpDownHdmi.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownHdmi.TabIndex = 5;
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
            this.comboBoxDeviceType.Location = new System.Drawing.Point(132, 51);
            this.comboBoxDeviceType.Name = "comboBoxDeviceType";
            this.comboBoxDeviceType.Size = new System.Drawing.Size(117, 21);
            this.comboBoxDeviceType.TabIndex = 4;
            // 
            // labelSetDeviceType
            // 
            this.labelSetDeviceType.AutoSize = true;
            this.labelSetDeviceType.Location = new System.Drawing.Point(6, 54);
            this.labelSetDeviceType.Name = "labelSetDeviceType";
            this.labelSetDeviceType.Size = new System.Drawing.Size(67, 13);
            this.labelSetDeviceType.TabIndex = 3;
            this.labelSetDeviceType.Text = "Device type:";
            this.toolTip1.SetToolTip(this.labelSetDeviceType, "HDMI-Device type that is reported to TV.");
            // 
            // labelSetHdmiPort
            // 
            this.labelSetHdmiPort.AutoSize = true;
            this.labelSetHdmiPort.Location = new System.Drawing.Point(6, 16);
            this.labelSetHdmiPort.Name = "labelSetHdmiPort";
            this.labelSetHdmiPort.Size = new System.Drawing.Size(59, 13);
            this.labelSetHdmiPort.TabIndex = 1;
            this.labelSetHdmiPort.Text = "HDMI port:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxPowerOff);
            this.groupBox2.Controls.Add(this.checkBoxInactiveSource);
            this.groupBox2.Controls.Add(this.checkBoxIgnoreShortPulses);
            this.groupBox2.Controls.Add(this.checkBoxFastScrolling);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericUpDownFilter);
            this.groupBox2.Location = new System.Drawing.Point(6, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 125);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // checkBoxPowerOff
            // 
            this.checkBoxPowerOff.AutoSize = true;
            this.checkBoxPowerOff.Location = new System.Drawing.Point(9, 89);
            this.checkBoxPowerOff.Name = "checkBoxPowerOff";
            this.checkBoxPowerOff.Size = new System.Drawing.Size(160, 17);
            this.checkBoxPowerOff.TabIndex = 13;
            this.checkBoxPowerOff.Text = "Power off TV when stopping";
            this.checkBoxPowerOff.UseVisualStyleBackColor = true;
            // 
            // checkBoxInactiveSource
            // 
            this.checkBoxInactiveSource.AutoSize = true;
            this.checkBoxInactiveSource.Location = new System.Drawing.Point(9, 65);
            this.checkBoxInactiveSource.Name = "checkBoxInactiveSource";
            this.checkBoxInactiveSource.Size = new System.Drawing.Size(189, 17);
            this.checkBoxInactiveSource.TabIndex = 12;
            this.checkBoxInactiveSource.Text = "Set inactive source when stopping";
            this.toolTip1.SetToolTip(this.checkBoxInactiveSource, "Sends \'inactive source\' command to TV when MediaPortal exits.\r\nTV selects previou" +
                    "sly active source, or default source.");
            this.checkBoxInactiveSource.UseVisualStyleBackColor = true;
            // 
            // checkBoxIgnoreShortPulses
            // 
            this.checkBoxIgnoreShortPulses.AutoSize = true;
            this.checkBoxIgnoreShortPulses.Location = new System.Drawing.Point(9, 42);
            this.checkBoxIgnoreShortPulses.Name = "checkBoxIgnoreShortPulses";
            this.checkBoxIgnoreShortPulses.Size = new System.Drawing.Size(163, 17);
            this.checkBoxIgnoreShortPulses.TabIndex = 11;
            this.checkBoxIgnoreShortPulses.Text = "Require delay between keys:";
            this.toolTip1.SetToolTip(this.checkBoxIgnoreShortPulses, "If you have problems with double taps, check this setting and set a delay that wo" +
                    "rks for you.\r\nLeave unchecked if you don\'t get double taps.\r\n");
            this.checkBoxIgnoreShortPulses.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreShortPulses.CheckedChanged += new System.EventHandler(this.checkBoxIgnoreShortPulses_CheckedChanged);
            // 
            // checkBoxFastScrolling
            // 
            this.checkBoxFastScrolling.AutoSize = true;
            this.checkBoxFastScrolling.Checked = true;
            this.checkBoxFastScrolling.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFastScrolling.Location = new System.Drawing.Point(9, 19);
            this.checkBoxFastScrolling.Name = "checkBoxFastScrolling";
            this.checkBoxFastScrolling.Size = new System.Drawing.Size(157, 17);
            this.checkBoxFastScrolling.TabIndex = 10;
            this.checkBoxFastScrolling.Text = "Fast Scrolling (experimental)";
            this.checkBoxFastScrolling.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "ms";
            // 
            // numericUpDownFilter
            // 
            this.numericUpDownFilter.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownFilter.Location = new System.Drawing.Point(198, 41);
            this.numericUpDownFilter.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownFilter.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownFilter.Name = "numericUpDownFilter";
            this.numericUpDownFilter.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownFilter.TabIndex = 3;
            this.numericUpDownFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownFilter.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labelTest);
            this.tabPage3.Controls.Add(this.listViewTestKeys);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(295, 312);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Test";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTest.Location = new System.Drawing.Point(70, 20);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(111, 19);
            this.labelTest.TabIndex = 1;
            this.labelTest.Text = "Press button!";
            // 
            // listViewTestKeys
            // 
            this.listViewTestKeys.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewTestKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnKeyCode,
            this.columnDescription});
            this.listViewTestKeys.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewTestKeys.FullRowSelect = true;
            this.listViewTestKeys.GridLines = true;
            this.listViewTestKeys.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewTestKeys.LabelWrap = false;
            this.listViewTestKeys.Location = new System.Drawing.Point(3, 51);
            this.listViewTestKeys.Name = "listViewTestKeys";
            this.listViewTestKeys.Size = new System.Drawing.Size(286, 258);
            this.listViewTestKeys.TabIndex = 0;
            this.listViewTestKeys.UseCompatibleStateImageBehavior = false;
            this.listViewTestKeys.View = System.Windows.Forms.View.Details;
            // 
            // columnKeyCode
            // 
            this.columnKeyCode.Text = "Key code";
            this.columnKeyCode.Width = 61;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Description";
            this.columnDescription.Width = 122;
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
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(218, 366);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(87, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // backgroundWorkerConnect
            // 
            this.backgroundWorkerConnect.WorkerReportsProgress = true;
            // 
            // CecSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 401);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBarConnect);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CecSettings";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CecRemote - Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CecSettings_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHdmi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFilter)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelAvrVendorValue;
        private System.Windows.Forms.Label labelAvrConnectedValue;
        private System.Windows.Forms.Label labelTvVendorValue;
        private System.Windows.Forms.Label labelHdmiPortValue;
        private System.Windows.Forms.Label labelFirmwareValue;
        private System.Windows.Forms.Label labelAdapterStatusValue;
        private System.Windows.Forms.Label labelAvrVendor;
        private System.Windows.Forms.Label labelAvrConnected;
        private System.Windows.Forms.Label labelHdmiPort;
        private System.Windows.Forms.Label labelTvVendor;
        private System.Windows.Forms.Label labelFirmware;
        private System.Windows.Forms.Label labelAdapterStatus;
        private System.Windows.Forms.ProgressBar progressBarConnect;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelSetHdmiPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxFastScrolling;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownFilter;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.NumericUpDown numericUpDownHdmi;
        private System.Windows.Forms.ComboBox comboBoxDeviceType;
        private System.Windows.Forms.Label labelSetDeviceType;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelSetMapping;
        private System.Windows.Forms.Button buttonMapping;
        private System.ComponentModel.BackgroundWorker backgroundWorkerConnect;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.ListView listViewTestKeys;
        private System.Windows.Forms.ColumnHeader columnKeyCode;
        private System.Windows.Forms.ColumnHeader columnDescription;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxIgnoreShortPulses;
        private System.Windows.Forms.CheckBox checkBoxPowerOff;
        private System.Windows.Forms.CheckBox checkBoxInactiveSource;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}