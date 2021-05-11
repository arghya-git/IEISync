namespace DBSync
{
    partial class frmSQLToOraChangeOfAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSQLToOraChangeOfAddress));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTotalCount = new System.Windows.Forms.DataGridView();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btProcessed = new System.Windows.Forms.Button();
            this.btAll = new System.Windows.Forms.Button();
            this.btQueue = new System.Windows.Forms.Button();
            this.btTotalCount = new System.Windows.Forms.Button();
            this.splitContainerOne = new System.Windows.Forms.SplitContainer();
            this.splitContainerTwo = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvQueue = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvProcessed = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarAddChange = new System.Windows.Forms.ToolStripProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOne)).BeginInit();
            this.splitContainerOne.Panel1.SuspendLayout();
            this.splitContainerOne.Panel2.SuspendLayout();
            this.splitContainerOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTwo)).BeginInit();
            this.splitContainerTwo.Panel1.SuspendLayout();
            this.splitContainerTwo.Panel2.SuspendLayout();
            this.splitContainerTwo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessed)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.dgvTotalCount);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 111);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total No of Records";
            // 
            // dgvTotalCount
            // 
            this.dgvTotalCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTotalCount.Location = new System.Drawing.Point(3, 16);
            this.dgvTotalCount.Name = "dgvTotalCount";
            this.dgvTotalCount.Size = new System.Drawing.Size(510, 92);
            this.dgvTotalCount.TabIndex = 0;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainerMain.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerOne);
            this.splitContainerMain.Size = new System.Drawing.Size(770, 340);
            this.splitContainerMain.SplitterDistance = 250;
            this.splitContainerMain.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.SteelBlue;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.Controls.Add(this.btProcessed, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btQueue, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btTotalCount, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 340);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btProcessed
            // 
            this.btProcessed.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btProcessed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btProcessed.Image = ((System.Drawing.Image)(resources.GetObject("btProcessed.Image")));
            this.btProcessed.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btProcessed.Location = new System.Drawing.Point(0, 90);
            this.btProcessed.Margin = new System.Windows.Forms.Padding(0);
            this.btProcessed.Name = "btProcessed";
            this.btProcessed.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btProcessed.Size = new System.Drawing.Size(250, 30);
            this.btProcessed.TabIndex = 6;
            this.btProcessed.Text = "No. of Record(s) Processed:";
            this.btProcessed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btProcessed.UseVisualStyleBackColor = false;
            this.btProcessed.Click += new System.EventHandler(this.btProcessed_Click);
            this.btProcessed.MouseLeave += new System.EventHandler(this.btAll_MouseLeave);
            this.btProcessed.MouseHover += new System.EventHandler(this.btAll_MouseHover);
            // 
            // btAll
            // 
            this.btAll.BackColor = System.Drawing.Color.White;
            this.btAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btAll.Image = ((System.Drawing.Image)(resources.GetObject("btAll.Image")));
            this.btAll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAll.Location = new System.Drawing.Point(0, 0);
            this.btAll.Margin = new System.Windows.Forms.Padding(0);
            this.btAll.Name = "btAll";
            this.btAll.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btAll.Size = new System.Drawing.Size(250, 30);
            this.btAll.TabIndex = 3;
            this.btAll.Text = "View All";
            this.btAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAll.UseVisualStyleBackColor = false;
            this.btAll.Click += new System.EventHandler(this.btAll_Click);
            this.btAll.MouseLeave += new System.EventHandler(this.btAll_MouseLeave);
            this.btAll.MouseHover += new System.EventHandler(this.btAll_MouseHover);
            // 
            // btQueue
            // 
            this.btQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btQueue.Image = ((System.Drawing.Image)(resources.GetObject("btQueue.Image")));
            this.btQueue.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btQueue.Location = new System.Drawing.Point(0, 60);
            this.btQueue.Margin = new System.Windows.Forms.Padding(0);
            this.btQueue.Name = "btQueue";
            this.btQueue.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btQueue.Size = new System.Drawing.Size(250, 30);
            this.btQueue.TabIndex = 5;
            this.btQueue.Text = "No. of Record(s) in Queue:";
            this.btQueue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btQueue.UseVisualStyleBackColor = false;
            this.btQueue.Click += new System.EventHandler(this.btQueue_Click);
            this.btQueue.MouseLeave += new System.EventHandler(this.btAll_MouseLeave);
            this.btQueue.MouseHover += new System.EventHandler(this.btAll_MouseHover);
            // 
            // btTotalCount
            // 
            this.btTotalCount.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btTotalCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btTotalCount.Image = ((System.Drawing.Image)(resources.GetObject("btTotalCount.Image")));
            this.btTotalCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btTotalCount.Location = new System.Drawing.Point(0, 30);
            this.btTotalCount.Margin = new System.Windows.Forms.Padding(0);
            this.btTotalCount.Name = "btTotalCount";
            this.btTotalCount.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btTotalCount.Size = new System.Drawing.Size(250, 30);
            this.btTotalCount.TabIndex = 4;
            this.btTotalCount.Text = "Total no. of Record(s) : 0";
            this.btTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTotalCount.UseVisualStyleBackColor = false;
            this.btTotalCount.Click += new System.EventHandler(this.btTotalCount_Click);
            this.btTotalCount.MouseLeave += new System.EventHandler(this.btAll_MouseLeave);
            this.btTotalCount.MouseHover += new System.EventHandler(this.btAll_MouseHover);
            // 
            // splitContainerOne
            // 
            this.splitContainerOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOne.Location = new System.Drawing.Point(0, 0);
            this.splitContainerOne.Name = "splitContainerOne";
            this.splitContainerOne.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerOne.Panel1
            // 
            this.splitContainerOne.Panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.splitContainerOne.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerOne.Panel2
            // 
            this.splitContainerOne.Panel2.BackColor = System.Drawing.Color.LightGreen;
            this.splitContainerOne.Panel2.Controls.Add(this.splitContainerTwo);
            this.splitContainerOne.Size = new System.Drawing.Size(516, 340);
            this.splitContainerOne.SplitterDistance = 111;
            this.splitContainerOne.TabIndex = 0;
            // 
            // splitContainerTwo
            // 
            this.splitContainerTwo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.splitContainerTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTwo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTwo.Name = "splitContainerTwo";
            this.splitContainerTwo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTwo.Panel1
            // 
            this.splitContainerTwo.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainerTwo.Panel2
            // 
            this.splitContainerTwo.Panel2.Controls.Add(this.groupBox3);
            this.splitContainerTwo.Size = new System.Drawing.Size(516, 225);
            this.splitContainerTwo.SplitterDistance = 108;
            this.splitContainerTwo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.dgvQueue);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 108);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "In Queue";
            // 
            // dgvQueue
            // 
            this.dgvQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQueue.Location = new System.Drawing.Point(3, 16);
            this.dgvQueue.Name = "dgvQueue";
            this.dgvQueue.Size = new System.Drawing.Size(510, 89);
            this.dgvQueue.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvProcessed);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(516, 113);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Processed";
            // 
            // dgvProcessed
            // 
            this.dgvProcessed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcessed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProcessed.Location = new System.Drawing.Point(3, 16);
            this.dgvProcessed.Name = "dgvProcessed";
            this.dgvProcessed.Size = new System.Drawing.Size(510, 94);
            this.dgvProcessed.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBarAddChange});
            this.statusStrip1.Location = new System.Drawing.Point(0, 384);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(770, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel1.Text = "Status: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(73, 17);
            this.toolStripStatusLabel2.Text = "Not Initiated";
            // 
            // toolStripProgressBarAddChange
            // 
            this.toolStripProgressBarAddChange.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBarAddChange.Name = "toolStripProgressBarAddChange";
            this.toolStripProgressBarAddChange.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBarAddChange.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 384);
            this.panel1.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainerMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(770, 384);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(770, 40);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(325, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 40);
            this.panel2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(12, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 24);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(42, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 24);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(72, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 24);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // frmChangeOfAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 406);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.HideOnClose = true;
            this.Name = "frmChangeOfAddress";
            this.Text = "Synchronize Member\'s Address";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalCount)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainerOne.Panel1.ResumeLayout(false);
            this.splitContainerOne.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOne)).EndInit();
            this.splitContainerOne.ResumeLayout(false);
            this.splitContainerTwo.Panel1.ResumeLayout(false);
            this.splitContainerTwo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTwo)).EndInit();
            this.splitContainerTwo.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessed)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTotalCount;
        private System.Windows.Forms.SplitContainer splitContainerOne;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvQueue;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvProcessed;
        private System.Windows.Forms.SplitContainer splitContainerTwo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarAddChange;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btAll;
        private System.Windows.Forms.Button btQueue;
        private System.Windows.Forms.Button btTotalCount;
        private System.Windows.Forms.Button btProcessed;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}