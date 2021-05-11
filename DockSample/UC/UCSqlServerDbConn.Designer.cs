namespace DBSync.UC
{
    partial class UCSqlServerDbConn
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbServers = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbDataBase = new System.Windows.Forms.ComboBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.tbSQLServerPassword = new System.Windows.Forms.TextBox();
            this.tbSQLServerUser = new System.Windows.Forms.TextBox();
            this.rbAuthenticationWin = new System.Windows.Forms.RadioButton();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.lbClave = new System.Windows.Forms.Label();
            this.rbAuthenticationSql = new System.Windows.Forms.RadioButton();
            this.OraDBConnectProgressBar = new System.Windows.Forms.ProgressBar();
            this.btOraTestConn = new System.Windows.Forms.Button();
            this.btOraConn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bgwGetSrvers = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.GroupBox1);
            this.panel1.Controls.Add(this.GroupBox2);
            this.panel1.Controls.Add(this.OraDBConnectProgressBar);
            this.panel1.Controls.Add(this.btOraTestConn);
            this.panel1.Controls.Add(this.btOraConn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 317);
            this.panel1.TabIndex = 57;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbServers);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(15, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(333, 50);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server Name";
            // 
            // cbServers
            // 
            this.cbServers.FormattingEnabled = true;
            this.cbServers.Items.AddRange(new object[] {
            "SASTESTSERVER"});
            this.cbServers.Location = new System.Drawing.Point(13, 18);
            this.cbServers.Name = "cbServers";
            this.cbServers.Size = new System.Drawing.Size(262, 21);
            this.cbServers.TabIndex = 59;
            this.cbServers.Text = "49.50.68.179";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 22);
            this.button1.TabIndex = 58;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.button2);
            this.GroupBox1.Controls.Add(this.cbDataBase);
            this.GroupBox1.Location = new System.Drawing.Point(15, 191);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(333, 48);
            this.GroupBox1.TabIndex = 59;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Select or enter a database name";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(290, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 22);
            this.button2.TabIndex = 59;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbDataBase
            // 
            this.cbDataBase.FormattingEnabled = true;
            this.cbDataBase.Items.AddRange(new object[] {
            "WEBIEI"});
            this.cbDataBase.Location = new System.Drawing.Point(13, 19);
            this.cbDataBase.Name = "cbDataBase";
            this.cbDataBase.Size = new System.Drawing.Size(262, 21);
            this.cbDataBase.TabIndex = 27;
            this.cbDataBase.Text = "WEBIEI";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.tbSQLServerPassword);
            this.GroupBox2.Controls.Add(this.tbSQLServerUser);
            this.GroupBox2.Controls.Add(this.rbAuthenticationWin);
            this.GroupBox2.Controls.Add(this.lbUsuario);
            this.GroupBox2.Controls.Add(this.lbClave);
            this.GroupBox2.Controls.Add(this.rbAuthenticationSql);
            this.GroupBox2.Location = new System.Drawing.Point(15, 72);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(334, 115);
            this.GroupBox2.TabIndex = 58;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Log on to the server";
            // 
            // tbSQLServerPassword
            // 
            this.tbSQLServerPassword.Location = new System.Drawing.Point(91, 86);
            this.tbSQLServerPassword.Name = "tbSQLServerPassword";
            this.tbSQLServerPassword.PasswordChar = '*';
            this.tbSQLServerPassword.Size = new System.Drawing.Size(231, 20);
            this.tbSQLServerPassword.TabIndex = 8;
            this.tbSQLServerPassword.Text = "GFHRFF#$%F^321";
            // 
            // tbSQLServerUser
            // 
            this.tbSQLServerUser.Enabled = false;
            this.tbSQLServerUser.Location = new System.Drawing.Point(91, 60);
            this.tbSQLServerUser.Name = "tbSQLServerUser";
            this.tbSQLServerUser.Size = new System.Drawing.Size(231, 20);
            this.tbSQLServerUser.TabIndex = 7;
            this.tbSQLServerUser.Text = "ieindia2";
            // 
            // rbAuthenticationWin
            // 
            this.rbAuthenticationWin.AutoSize = true;
            this.rbAuthenticationWin.Location = new System.Drawing.Point(13, 17);
            this.rbAuthenticationWin.Name = "rbAuthenticationWin";
            this.rbAuthenticationWin.Size = new System.Drawing.Size(162, 17);
            this.rbAuthenticationWin.TabIndex = 3;
            this.rbAuthenticationWin.Text = "Use Windows Authentication";
            this.rbAuthenticationWin.UseVisualStyleBackColor = true;
            this.rbAuthenticationWin.CheckedChanged += new System.EventHandler(this.rbAuthenticationWin_CheckedChanged);
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(32, 63);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(29, 13);
            this.lbUsuario.TabIndex = 9;
            this.lbUsuario.Text = "User";
            // 
            // lbClave
            // 
            this.lbClave.AutoSize = true;
            this.lbClave.Location = new System.Drawing.Point(32, 89);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(53, 13);
            this.lbClave.TabIndex = 10;
            this.lbClave.Text = "Password";
            // 
            // rbAuthenticationSql
            // 
            this.rbAuthenticationSql.AutoSize = true;
            this.rbAuthenticationSql.Checked = true;
            this.rbAuthenticationSql.Location = new System.Drawing.Point(13, 37);
            this.rbAuthenticationSql.Name = "rbAuthenticationSql";
            this.rbAuthenticationSql.Size = new System.Drawing.Size(173, 17);
            this.rbAuthenticationSql.TabIndex = 4;
            this.rbAuthenticationSql.TabStop = true;
            this.rbAuthenticationSql.Text = "Use SQL Server Authentication";
            // 
            // OraDBConnectProgressBar
            // 
            this.OraDBConnectProgressBar.Location = new System.Drawing.Point(15, 248);
            this.OraDBConnectProgressBar.MarqueeAnimationSpeed = 20;
            this.OraDBConnectProgressBar.Name = "OraDBConnectProgressBar";
            this.OraDBConnectProgressBar.Size = new System.Drawing.Size(333, 1);
            this.OraDBConnectProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.OraDBConnectProgressBar.TabIndex = 55;
            this.OraDBConnectProgressBar.Visible = false;
            // 
            // btOraTestConn
            // 
            this.btOraTestConn.Location = new System.Drawing.Point(15, 253);
            this.btOraTestConn.Name = "btOraTestConn";
            this.btOraTestConn.Size = new System.Drawing.Size(160, 50);
            this.btOraTestConn.TabIndex = 52;
            this.btOraTestConn.Text = "Test Connection";
            this.btOraTestConn.UseVisualStyleBackColor = true;
            this.btOraTestConn.Click += new System.EventHandler(this.btOraTestConn_Click);
            // 
            // btOraConn
            // 
            this.btOraConn.Location = new System.Drawing.Point(181, 253);
            this.btOraConn.Name = "btOraConn";
            this.btOraConn.Size = new System.Drawing.Size(167, 50);
            this.btOraConn.TabIndex = 53;
            this.btOraConn.Text = "Connect";
            this.btOraConn.UseVisualStyleBackColor = true;
            this.btOraConn.Click += new System.EventHandler(this.btOraConn_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // bgwGetSrvers
            // 
            this.bgwGetSrvers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.bgwGetSrvers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // UCSqlServerDbConn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Name = "UCSqlServerDbConn";
            this.Size = new System.Drawing.Size(361, 317);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar OraDBConnectProgressBar;
        private System.Windows.Forms.Button btOraTestConn;
        private System.Windows.Forms.Button btOraConn;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox tbSQLServerPassword;
        internal System.Windows.Forms.TextBox tbSQLServerUser;
        internal System.Windows.Forms.RadioButton rbAuthenticationWin;
        internal System.Windows.Forms.Label lbUsuario;
        internal System.Windows.Forms.Label lbClave;
        internal System.Windows.Forms.RadioButton rbAuthenticationSql;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ComboBox cbDataBase;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbServers;
        private System.ComponentModel.BackgroundWorker bgwGetSrvers;
    }
}
