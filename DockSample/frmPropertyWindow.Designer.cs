namespace DBSync
{
    partial class frmPropertyWindow
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
            this.ucRegKeySettings = new DBSync.UC.UCRegKeySettings();
            this.SuspendLayout();
            // 
            // ucRegKeySettings
            // 
            this.ucRegKeySettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRegKeySettings.Location = new System.Drawing.Point(0, 0);
            this.ucRegKeySettings.Name = "ucRegKeySettings";
            this.ucRegKeySettings.Size = new System.Drawing.Size(269, 480);
            this.ucRegKeySettings.TabIndex = 1;
            // 
            // frmPropertyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 480);
            this.Controls.Add(this.ucRegKeySettings);
            this.HideOnClose = true;
            this.Name = "frmPropertyWindow";
            this.Text = "Properties";
            this.ResumeLayout(false);

        }

        #endregion

        private UC.UCRegKeySettings ucRegKeySettings;
    }
}