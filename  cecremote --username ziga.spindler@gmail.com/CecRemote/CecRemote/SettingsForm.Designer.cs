namespace CecRemote
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_hdmiPort = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.l_rw = new System.Windows.Forms.Label();
            this.bt_rw = new System.Windows.Forms.Button();
            this.l_ff = new System.Windows.Forms.Label();
            this.bt_ff = new System.Windows.Forms.Button();
            this.l_stop = new System.Windows.Forms.Label();
            this.bt_stop = new System.Windows.Forms.Button();
            this.l_pause = new System.Windows.Forms.Label();
            this.bt_pause = new System.Windows.Forms.Button();
            this.l_play = new System.Windows.Forms.Label();
            this.bt_play = new System.Windows.Forms.Button();
            this.l_home = new System.Windows.Forms.Label();
            this.bt_home = new System.Windows.Forms.Button();
            this.l_back = new System.Windows.Forms.Label();
            this.bt_back = new System.Windows.Forms.Button();
            this.l_enter = new System.Windows.Forms.Label();
            this.bt_enter = new System.Windows.Forms.Button();
            this.l_right = new System.Windows.Forms.Label();
            this.bt_right = new System.Windows.Forms.Button();
            this.l_left = new System.Windows.Forms.Label();
            this.bt_left = new System.Windows.Forms.Button();
            this.l_down = new System.Windows.Forms.Label();
            this.bt_down = new System.Windows.Forms.Button();
            this.l_up = new System.Windows.Forms.Label();
            this.bt_up = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_ok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "HDMI Port:";
            // 
            // cb_hdmiPort
            // 
            this.cb_hdmiPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_hdmiPort.FormattingEnabled = true;
            this.cb_hdmiPort.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cb_hdmiPort.Location = new System.Drawing.Point(78, 6);
            this.cb_hdmiPort.Name = "cb_hdmiPort";
            this.cb_hdmiPort.Size = new System.Drawing.Size(44, 21);
            this.cb_hdmiPort.TabIndex = 2;
            this.cb_hdmiPort.SelectedIndexChanged += new System.EventHandler(this.cb_hdmiPort_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.l_rw);
            this.groupBox1.Controls.Add(this.bt_rw);
            this.groupBox1.Controls.Add(this.l_ff);
            this.groupBox1.Controls.Add(this.bt_ff);
            this.groupBox1.Controls.Add(this.l_stop);
            this.groupBox1.Controls.Add(this.bt_stop);
            this.groupBox1.Controls.Add(this.l_pause);
            this.groupBox1.Controls.Add(this.bt_pause);
            this.groupBox1.Controls.Add(this.l_play);
            this.groupBox1.Controls.Add(this.bt_play);
            this.groupBox1.Controls.Add(this.l_home);
            this.groupBox1.Controls.Add(this.bt_home);
            this.groupBox1.Controls.Add(this.l_back);
            this.groupBox1.Controls.Add(this.bt_back);
            this.groupBox1.Controls.Add(this.l_enter);
            this.groupBox1.Controls.Add(this.bt_enter);
            this.groupBox1.Controls.Add(this.l_right);
            this.groupBox1.Controls.Add(this.bt_right);
            this.groupBox1.Controls.Add(this.l_left);
            this.groupBox1.Controls.Add(this.bt_left);
            this.groupBox1.Controls.Add(this.l_down);
            this.groupBox1.Controls.Add(this.bt_down);
            this.groupBox1.Controls.Add(this.l_up);
            this.groupBox1.Controls.Add(this.bt_up);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 216);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Button configuration";
            // 
            // l_rw
            // 
            this.l_rw.AutoSize = true;
            this.l_rw.Location = new System.Drawing.Point(240, 169);
            this.l_rw.Name = "l_rw";
            this.l_rw.Size = new System.Drawing.Size(31, 13);
            this.l_rw.TabIndex = 23;
            this.l_rw.Text = "none";
            // 
            // bt_rw
            // 
            this.bt_rw.Location = new System.Drawing.Point(159, 164);
            this.bt_rw.Name = "bt_rw";
            this.bt_rw.Size = new System.Drawing.Size(75, 23);
            this.bt_rw.TabIndex = 22;
            this.bt_rw.Text = "RW";
            this.bt_rw.UseVisualStyleBackColor = true;
            this.bt_rw.Click += new System.EventHandler(this.bt_click);
            // 
            // l_ff
            // 
            this.l_ff.AutoSize = true;
            this.l_ff.Location = new System.Drawing.Point(240, 140);
            this.l_ff.Name = "l_ff";
            this.l_ff.Size = new System.Drawing.Size(31, 13);
            this.l_ff.TabIndex = 21;
            this.l_ff.Text = "none";
            // 
            // bt_ff
            // 
            this.bt_ff.Location = new System.Drawing.Point(159, 135);
            this.bt_ff.Name = "bt_ff";
            this.bt_ff.Size = new System.Drawing.Size(75, 23);
            this.bt_ff.TabIndex = 20;
            this.bt_ff.Text = "FF";
            this.bt_ff.UseVisualStyleBackColor = true;
            this.bt_ff.Click += new System.EventHandler(this.bt_click);
            // 
            // l_stop
            // 
            this.l_stop.AutoSize = true;
            this.l_stop.Location = new System.Drawing.Point(240, 111);
            this.l_stop.Name = "l_stop";
            this.l_stop.Size = new System.Drawing.Size(31, 13);
            this.l_stop.TabIndex = 19;
            this.l_stop.Text = "none";
            // 
            // bt_stop
            // 
            this.bt_stop.Location = new System.Drawing.Point(159, 106);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(75, 23);
            this.bt_stop.TabIndex = 18;
            this.bt_stop.Text = "Stop";
            this.bt_stop.UseVisualStyleBackColor = true;
            this.bt_stop.Click += new System.EventHandler(this.bt_click);
            // 
            // l_pause
            // 
            this.l_pause.AutoSize = true;
            this.l_pause.Location = new System.Drawing.Point(240, 82);
            this.l_pause.Name = "l_pause";
            this.l_pause.Size = new System.Drawing.Size(31, 13);
            this.l_pause.TabIndex = 17;
            this.l_pause.Text = "none";
            // 
            // bt_pause
            // 
            this.bt_pause.Location = new System.Drawing.Point(159, 77);
            this.bt_pause.Name = "bt_pause";
            this.bt_pause.Size = new System.Drawing.Size(75, 23);
            this.bt_pause.TabIndex = 16;
            this.bt_pause.Text = "Pause";
            this.bt_pause.UseVisualStyleBackColor = true;
            this.bt_pause.Click += new System.EventHandler(this.bt_click);
            // 
            // l_play
            // 
            this.l_play.AutoSize = true;
            this.l_play.Location = new System.Drawing.Point(240, 53);
            this.l_play.Name = "l_play";
            this.l_play.Size = new System.Drawing.Size(31, 13);
            this.l_play.TabIndex = 15;
            this.l_play.Text = "none";
            // 
            // bt_play
            // 
            this.bt_play.Location = new System.Drawing.Point(159, 48);
            this.bt_play.Name = "bt_play";
            this.bt_play.Size = new System.Drawing.Size(75, 23);
            this.bt_play.TabIndex = 14;
            this.bt_play.Text = "Play";
            this.bt_play.UseVisualStyleBackColor = true;
            this.bt_play.Click += new System.EventHandler(this.bt_click);
            // 
            // l_home
            // 
            this.l_home.AutoSize = true;
            this.l_home.Location = new System.Drawing.Point(240, 24);
            this.l_home.Name = "l_home";
            this.l_home.Size = new System.Drawing.Size(31, 13);
            this.l_home.TabIndex = 13;
            this.l_home.Text = "none";
            // 
            // bt_home
            // 
            this.bt_home.Location = new System.Drawing.Point(159, 19);
            this.bt_home.Name = "bt_home";
            this.bt_home.Size = new System.Drawing.Size(75, 23);
            this.bt_home.TabIndex = 12;
            this.bt_home.Text = "Home";
            this.bt_home.UseVisualStyleBackColor = true;
            this.bt_home.Click += new System.EventHandler(this.bt_click);
            // 
            // l_back
            // 
            this.l_back.AutoSize = true;
            this.l_back.Location = new System.Drawing.Point(87, 169);
            this.l_back.Name = "l_back";
            this.l_back.Size = new System.Drawing.Size(31, 13);
            this.l_back.TabIndex = 11;
            this.l_back.Text = "none";
            // 
            // bt_back
            // 
            this.bt_back.Location = new System.Drawing.Point(6, 164);
            this.bt_back.Name = "bt_back";
            this.bt_back.Size = new System.Drawing.Size(75, 23);
            this.bt_back.TabIndex = 10;
            this.bt_back.Text = "Back";
            this.bt_back.UseVisualStyleBackColor = true;
            this.bt_back.Click += new System.EventHandler(this.bt_click);
            // 
            // l_enter
            // 
            this.l_enter.AutoSize = true;
            this.l_enter.Location = new System.Drawing.Point(87, 140);
            this.l_enter.Name = "l_enter";
            this.l_enter.Size = new System.Drawing.Size(31, 13);
            this.l_enter.TabIndex = 9;
            this.l_enter.Text = "none";
            // 
            // bt_enter
            // 
            this.bt_enter.Location = new System.Drawing.Point(6, 135);
            this.bt_enter.Name = "bt_enter";
            this.bt_enter.Size = new System.Drawing.Size(75, 23);
            this.bt_enter.TabIndex = 8;
            this.bt_enter.Text = "Enter";
            this.bt_enter.UseVisualStyleBackColor = true;
            this.bt_enter.Click += new System.EventHandler(this.bt_click);
            // 
            // l_right
            // 
            this.l_right.AutoSize = true;
            this.l_right.Location = new System.Drawing.Point(87, 111);
            this.l_right.Name = "l_right";
            this.l_right.Size = new System.Drawing.Size(31, 13);
            this.l_right.TabIndex = 7;
            this.l_right.Text = "none";
            // 
            // bt_right
            // 
            this.bt_right.Location = new System.Drawing.Point(6, 106);
            this.bt_right.Name = "bt_right";
            this.bt_right.Size = new System.Drawing.Size(75, 23);
            this.bt_right.TabIndex = 6;
            this.bt_right.Text = "Right";
            this.bt_right.UseVisualStyleBackColor = true;
            this.bt_right.Click += new System.EventHandler(this.bt_click);
            // 
            // l_left
            // 
            this.l_left.AutoSize = true;
            this.l_left.Location = new System.Drawing.Point(87, 82);
            this.l_left.Name = "l_left";
            this.l_left.Size = new System.Drawing.Size(31, 13);
            this.l_left.TabIndex = 5;
            this.l_left.Text = "none";
            // 
            // bt_left
            // 
            this.bt_left.Location = new System.Drawing.Point(6, 77);
            this.bt_left.Name = "bt_left";
            this.bt_left.Size = new System.Drawing.Size(75, 23);
            this.bt_left.TabIndex = 4;
            this.bt_left.Text = "Left";
            this.bt_left.UseVisualStyleBackColor = true;
            this.bt_left.Click += new System.EventHandler(this.bt_click);
            // 
            // l_down
            // 
            this.l_down.AutoSize = true;
            this.l_down.Location = new System.Drawing.Point(87, 53);
            this.l_down.Name = "l_down";
            this.l_down.Size = new System.Drawing.Size(31, 13);
            this.l_down.TabIndex = 3;
            this.l_down.Text = "none";
            // 
            // bt_down
            // 
            this.bt_down.Location = new System.Drawing.Point(6, 48);
            this.bt_down.Name = "bt_down";
            this.bt_down.Size = new System.Drawing.Size(75, 23);
            this.bt_down.TabIndex = 2;
            this.bt_down.Text = "Down";
            this.bt_down.UseVisualStyleBackColor = true;
            this.bt_down.Click += new System.EventHandler(this.bt_click);
            // 
            // l_up
            // 
            this.l_up.AutoSize = true;
            this.l_up.Location = new System.Drawing.Point(87, 24);
            this.l_up.Name = "l_up";
            this.l_up.Size = new System.Drawing.Size(31, 13);
            this.l_up.TabIndex = 1;
            this.l_up.Text = "none";
            // 
            // bt_up
            // 
            this.bt_up.Location = new System.Drawing.Point(6, 19);
            this.bt_up.Name = "bt_up";
            this.bt_up.Size = new System.Drawing.Size(75, 23);
            this.bt_up.TabIndex = 0;
            this.bt_up.Text = "Up";
            this.bt_up.UseVisualStyleBackColor = true;
            this.bt_up.Click += new System.EventHandler(this.bt_click);
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(233, 255);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 4;
            this.bt_cancel.Text = "Cancel";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(151, 255);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 5;
            this.bt_ok.Text = "Ok";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 290);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cb_hdmiPort);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_hdmiPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label l_up;
        private System.Windows.Forms.Button bt_up;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Label l_down;
        private System.Windows.Forms.Button bt_down;
        private System.Windows.Forms.Label l_back;
        private System.Windows.Forms.Button bt_back;
        private System.Windows.Forms.Label l_enter;
        private System.Windows.Forms.Button bt_enter;
        private System.Windows.Forms.Label l_right;
        private System.Windows.Forms.Button bt_right;
        private System.Windows.Forms.Label l_left;
        private System.Windows.Forms.Button bt_left;
        private System.Windows.Forms.Button bt_ff;
        private System.Windows.Forms.Label l_stop;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.Label l_pause;
        private System.Windows.Forms.Button bt_pause;
        private System.Windows.Forms.Label l_play;
        private System.Windows.Forms.Button bt_play;
        private System.Windows.Forms.Label l_home;
        private System.Windows.Forms.Button bt_home;
        private System.Windows.Forms.Button bt_rw;
        private System.Windows.Forms.Label l_ff;
        private System.Windows.Forms.Label l_rw;
    }
}