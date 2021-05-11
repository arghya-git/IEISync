namespace DBSync
{
    partial class fromSQLToOraPayment
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
            this.TotalProcessed = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dgvProcessing = new System.Windows.Forms.DataGridView();
            this.dgbCAtt = new System.Windows.Forms.DataGridView();
            this.dgbTAtt = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbCAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbTAtt)).BeginInit();
            this.SuspendLayout();
            // 
            // TotalProcessed
            // 
            this.TotalProcessed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalProcessed.AutoSize = true;
            this.TotalProcessed.Location = new System.Drawing.Point(12, 9);
            this.TotalProcessed.Name = "TotalProcessed";
            this.TotalProcessed.Size = new System.Drawing.Size(24, 13);
            this.TotalProcessed.TabIndex = 0;
            this.TotalProcessed.Text = "0/0";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 76);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(851, 10);
            this.progressBar1.TabIndex = 1;
            // 
            // dgvProcessing
            // 
            this.dgvProcessing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcessing.Location = new System.Drawing.Point(15, 117);
            this.dgvProcessing.Name = "dgvProcessing";
            this.dgvProcessing.Size = new System.Drawing.Size(392, 140);
            this.dgvProcessing.TabIndex = 2;
            // 
            // dgbCAtt
            // 
            this.dgbCAtt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbCAtt.Location = new System.Drawing.Point(15, 294);
            this.dgbCAtt.Name = "dgbCAtt";
            this.dgbCAtt.Size = new System.Drawing.Size(392, 164);
            this.dgbCAtt.TabIndex = 3;
            // 
            // dgbTAtt
            // 
            this.dgbTAtt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbTAtt.Location = new System.Drawing.Point(454, 117);
            this.dgbTAtt.Name = "dgbTAtt";
            this.dgbTAtt.Size = new System.Drawing.Size(392, 341);
            this.dgbTAtt.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Processing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Current Attention Required";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total No. of Duplicate Found";
            // 
            // fromSQLToOraPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(881, 507);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgbTAtt);
            this.Controls.Add(this.dgbCAtt);
            this.Controls.Add(this.dgvProcessing);
            this.Controls.Add(this.TotalProcessed);
            this.Controls.Add(this.progressBar1);
            this.Name = "fromSQLToOraPayment";
            this.Text = "fromSQLToOraPayment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbCAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgbTAtt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TotalProcessed;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dgvProcessing;
        private System.Windows.Forms.DataGridView dgbCAtt;
        private System.Windows.Forms.DataGridView dgbTAtt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}