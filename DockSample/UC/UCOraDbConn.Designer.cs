namespace DBSync.UC
{
    partial class UCOraDbConn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OraDBConnectProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbSchema = new System.Windows.Forms.Label();
            this.tbOraPassword = new System.Windows.Forms.TextBox();
            this.tbOraUser = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.btOraConn = new System.Windows.Forms.Button();
            this.btOraTestConn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbService = new System.Windows.Forms.TextBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OraDBConnectProgressBar
            // 
            this.OraDBConnectProgressBar.Location = new System.Drawing.Point(12, 242);
            this.OraDBConnectProgressBar.MarqueeAnimationSpeed = 20;
            this.OraDBConnectProgressBar.Name = "OraDBConnectProgressBar";
            this.OraDBConnectProgressBar.Size = new System.Drawing.Size(333, 1);
            this.OraDBConnectProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.OraDBConnectProgressBar.TabIndex = 55;
            this.OraDBConnectProgressBar.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbSchema);
            this.groupBox3.Controls.Add(this.tbOraPassword);
            this.groupBox3.Controls.Add(this.tbOraUser);
            this.groupBox3.Controls.Add(this.lbPassword);
            this.groupBox3.Location = new System.Drawing.Point(13, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 96);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Authentication";
            // 
            // lbSchema
            // 
            this.lbSchema.AutoSize = true;
            this.lbSchema.Location = new System.Drawing.Point(13, 28);
            this.lbSchema.Name = "lbSchema";
            this.lbSchema.Size = new System.Drawing.Size(76, 13);
            this.lbSchema.TabIndex = 0;
            this.lbSchema.Text = "User/Schema:";
            // 
            // tbOraPassword
            // 
            this.tbOraPassword.Location = new System.Drawing.Point(97, 57);
            this.tbOraPassword.Name = "tbOraPassword";
            this.tbOraPassword.PasswordChar = '-';
            this.tbOraPassword.Size = new System.Drawing.Size(227, 20);
            this.tbOraPassword.TabIndex = 3;
            this.tbOraPassword.Text = "ieindia";
            // 
            // tbOraUser
            // 
            this.tbOraUser.Location = new System.Drawing.Point(97, 24);
            this.tbOraUser.Name = "tbOraUser";
            this.tbOraUser.Size = new System.Drawing.Size(227, 20);
            this.tbOraUser.TabIndex = 2;
            this.tbOraUser.Text = "IEINDIA";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(13, 61);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(56, 13);
            this.lbPassword.TabIndex = 1;
            this.lbPassword.Text = "Password:";
            // 
            // btOraConn
            // 
            this.btOraConn.Location = new System.Drawing.Point(179, 250);
            this.btOraConn.Name = "btOraConn";
            this.btOraConn.Size = new System.Drawing.Size(167, 50);
            this.btOraConn.TabIndex = 53;
            this.btOraConn.Text = "Connect";
            this.btOraConn.UseVisualStyleBackColor = true;
            this.btOraConn.Click += new System.EventHandler(this.btOraConn_Click);
            // 
            // btOraTestConn
            // 
            this.btOraTestConn.Location = new System.Drawing.Point(13, 250);
            this.btOraTestConn.Name = "btOraTestConn";
            this.btOraTestConn.Size = new System.Drawing.Size(160, 50);
            this.btOraTestConn.TabIndex = 52;
            this.btOraTestConn.Text = "Test Connection";
            this.btOraTestConn.UseVisualStyleBackColor = true;
            this.btOraTestConn.Click += new System.EventHandler(this.btOraTestConn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbService);
            this.groupBox4.Controls.Add(this.tbHost);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.tbPort);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 108);
            this.groupBox4.TabIndex = 51;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Service Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Server Name:";
            // 
            // tbService
            // 
            this.tbService.Location = new System.Drawing.Point(97, 52);
            this.tbService.Name = "tbService";
            this.tbService.Size = new System.Drawing.Size(227, 20);
            this.tbService.TabIndex = 6;
            this.tbService.Text = "ioedb";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(97, 19);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(227, 20);
            this.tbHost.TabIndex = 47;
            this.tbHost.Text = "192.168.0.147";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Port:";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(97, 82);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(51, 20);
            this.tbPort.TabIndex = 49;
            this.tbPort.Text = "1521";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Host:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.OraDBConnectProgressBar);
            this.panel1.Controls.Add(this.btOraTestConn);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.btOraConn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 309);
            this.panel1.TabIndex = 56;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // UCOraDbConn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "UCOraDbConn";
            this.Size = new System.Drawing.Size(363, 309);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar OraDBConnectProgressBar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbSchema;
        private System.Windows.Forms.TextBox tbOraPassword;
        private System.Windows.Forms.TextBox tbOraUser;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Button btOraConn;
        private System.Windows.Forms.Button btOraTestConn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbService;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
