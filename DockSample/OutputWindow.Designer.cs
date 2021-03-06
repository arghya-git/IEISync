namespace DBSync
{
    partial class OutputWindow
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
            this.outputWindowEditor = new DBSync.UC.OutputWindowEditor();
            this.SuspendLayout();
            // 
            // outputWindowEditor
            // 
            this.outputWindowEditor.BackColor = System.Drawing.Color.Transparent;
            this.outputWindowEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputWindowEditor.Location = new System.Drawing.Point(0, 0);
            this.outputWindowEditor.Name = "outputWindowEditor";
            this.outputWindowEditor.Size = new System.Drawing.Size(780, 164);
            this.outputWindowEditor.TabIndex = 0;
            // 
            // OutputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 164);
            this.Controls.Add(this.outputWindowEditor);
            this.HideOnClose = true;
            this.Name = "OutputWindow";
            this.Text = "Output Window";
            this.ResumeLayout(false);

        }

        #endregion

        private UC.OutputWindowEditor outputWindowEditor;
    }
}