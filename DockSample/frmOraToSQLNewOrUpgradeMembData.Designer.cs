namespace DBSync
{
    partial class frmOraToSQLNewOrUpgradeMembData
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblTagPrcessed = new System.Windows.Forms.Label();
            this.lblTot = new System.Windows.Forms.Label();
            this.lblQueue = new System.Windows.Forms.Label();
            this.lblPrcessed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total no. of Record(s) : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "No. of Record(s) in Queue:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTagPrcessed
            // 
            this.lblTagPrcessed.AutoSize = true;
            this.lblTagPrcessed.Location = new System.Drawing.Point(36, 119);
            this.lblTagPrcessed.Name = "lblTagPrcessed";
            this.lblTagPrcessed.Size = new System.Drawing.Size(141, 13);
            this.lblTagPrcessed.TabIndex = 2;
            this.lblTagPrcessed.Text = "No. of Record(s) Processed:";
            // 
            // lblTot
            // 
            this.lblTot.AutoSize = true;
            this.lblTot.Location = new System.Drawing.Point(178, 45);
            this.lblTot.Name = "lblTot";
            this.lblTot.Size = new System.Drawing.Size(13, 13);
            this.lblTot.TabIndex = 3;
            this.lblTot.Text = "0";
            // 
            // lblQueue
            // 
            this.lblQueue.AutoSize = true;
            this.lblQueue.Location = new System.Drawing.Point(178, 82);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(13, 13);
            this.lblQueue.TabIndex = 4;
            this.lblQueue.Text = "0";
            // 
            // lblPrcessed
            // 
            this.lblPrcessed.AutoSize = true;
            this.lblPrcessed.Location = new System.Drawing.Point(177, 119);
            this.lblPrcessed.Name = "lblPrcessed";
            this.lblPrcessed.Size = new System.Drawing.Size(13, 13);
            this.lblPrcessed.TabIndex = 5;
            this.lblPrcessed.Text = "0";
            // 
            // frmOraToSQLNewOrUpgradeMembData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 439);
            this.Controls.Add(this.lblPrcessed);
            this.Controls.Add(this.lblQueue);
            this.Controls.Add(this.lblTot);
            this.Controls.Add(this.lblTagPrcessed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmOraToSQLNewOrUpgradeMembData";
            this.Text = "frmOraToSQLNewOrUpgradeMembData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTagPrcessed;
        private System.Windows.Forms.Label lblTot;
        private System.Windows.Forms.Label lblQueue;
        private System.Windows.Forms.Label lblPrcessed;
    }
}