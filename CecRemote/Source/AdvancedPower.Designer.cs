namespace CecRemote
{
  partial class AdvancedPower
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
            this.checkBoxRequireUser = new System.Windows.Forms.CheckBox();
            this.checkBoxSendTvPower = new System.Windows.Forms.CheckBox();
            this.radioButtonAlways = new System.Windows.Forms.RadioButton();
            this.radioButtonOnlyIfMediaPortal = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxRequireActiveSource = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxRequireUser
            // 
            this.checkBoxRequireUser.AutoSize = true;
            this.checkBoxRequireUser.Checked = true;
            this.checkBoxRequireUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRequireUser.Location = new System.Drawing.Point(13, 30);
            this.checkBoxRequireUser.Name = "checkBoxRequireUser";
            this.checkBoxRequireUser.Size = new System.Drawing.Size(353, 17);
            this.checkBoxRequireUser.TabIndex = 0;
            this.checkBoxRequireUser.Text = "Require user input before waking devices (when resuming from sleep)";
            this.toolTip1.SetToolTip(this.checkBoxRequireUser, "If tchecked, devices you have selected to be powered on when resuming from sleep," +
        "\r\nare not woken up if computer resumes for automatic event, e.g scheduled record" +
        "ing.");
            this.checkBoxRequireUser.UseVisualStyleBackColor = true;
            // 
            // checkBoxSendTvPower
            // 
            this.checkBoxSendTvPower.AutoSize = true;
            this.checkBoxSendTvPower.Location = new System.Drawing.Point(13, 96);
            this.checkBoxSendTvPower.Name = "checkBoxSendTvPower";
            this.checkBoxSendTvPower.Size = new System.Drawing.Size(338, 17);
            this.checkBoxSendTvPower.TabIndex = 1;
            this.checkBoxSendTvPower.Text = "Send \'TvPowerOff\'  button to MediaPortal when TV is switched off";
            this.toolTip1.SetToolTip(this.checkBoxSendTvPower, "If checked, this will emulate pressing Power Off (or similar) button when you swi" +
        "tch off your TV. \r\nYou can map this virtual button (TvPowerOff in mappings form)" +
        " to anything you like.");
            this.checkBoxSendTvPower.UseVisualStyleBackColor = true;
            // 
            // radioButtonAlways
            // 
            this.radioButtonAlways.AutoSize = true;
            this.radioButtonAlways.Checked = true;
            this.radioButtonAlways.Location = new System.Drawing.Point(48, 130);
            this.radioButtonAlways.Name = "radioButtonAlways";
            this.radioButtonAlways.Size = new System.Drawing.Size(58, 17);
            this.radioButtonAlways.TabIndex = 2;
            this.radioButtonAlways.TabStop = true;
            this.radioButtonAlways.Text = "Always";
            this.radioButtonAlways.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnlyIfMediaPortal
            // 
            this.radioButtonOnlyIfMediaPortal.AutoSize = true;
            this.radioButtonOnlyIfMediaPortal.Location = new System.Drawing.Point(135, 130);
            this.radioButtonOnlyIfMediaPortal.Name = "radioButtonOnlyIfMediaPortal";
            this.radioButtonOnlyIfMediaPortal.Size = new System.Drawing.Size(208, 17);
            this.radioButtonOnlyIfMediaPortal.TabIndex = 3;
            this.radioButtonOnlyIfMediaPortal.TabStop = true;
            this.radioButtonOnlyIfMediaPortal.Text = "Only if MediaPortal is the active source";
            this.radioButtonOnlyIfMediaPortal.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(128, 200);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(239, 200);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxRequireActiveSource);
            this.groupBox1.Controls.Add(this.checkBoxSendTvPower);
            this.groupBox1.Controls.Add(this.radioButtonAlways);
            this.groupBox1.Controls.Add(this.checkBoxRequireUser);
            this.groupBox1.Controls.Add(this.radioButtonOnlyIfMediaPortal);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 169);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // checkBoxRequireActiveSource
            // 
            this.checkBoxRequireActiveSource.AutoSize = true;
            this.checkBoxRequireActiveSource.Checked = true;
            this.checkBoxRequireActiveSource.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRequireActiveSource.Location = new System.Drawing.Point(13, 63);
            this.checkBoxRequireActiveSource.Name = "checkBoxRequireActiveSource";
            this.checkBoxRequireActiveSource.Size = new System.Drawing.Size(394, 17);
            this.checkBoxRequireActiveSource.TabIndex = 4;
            this.checkBoxRequireActiveSource.Text = "Turn off devices only if Media Portal is the active source (when entering sleep)";
            this.checkBoxRequireActiveSource.UseVisualStyleBackColor = true;
            // 
            // AdvancedPower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(454, 235);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedPower";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Advanced Power Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckBox checkBoxRequireUser;
    private System.Windows.Forms.CheckBox checkBoxSendTvPower;
    private System.Windows.Forms.RadioButton radioButtonAlways;
    private System.Windows.Forms.RadioButton radioButtonOnlyIfMediaPortal;
    private System.Windows.Forms.Button buttonOK;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.CheckBox checkBoxRequireActiveSource;

  }
}