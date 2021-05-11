namespace DBSync
{
    partial class frmRegKeySettings
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Direct [Table to table]", 17, 17);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Indirect [Gateway to DB]", 18, 18);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Payments", 8, 8, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Membership Application", 3, 3);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Change of Address", 14, 14);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("New/Upgraded Member\'s Data ", 15, 15);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Membership", 10, 10, new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Examination", 11, 11);
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Technical Activities", 7, 7);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Data Synchronization", 4, 4, new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Membership", 10, 10);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Examination", 11, 11);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Technical Activities", 7, 7);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("File Synchronization", 5, 5, new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Forthcomming Events", 12, 12);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Highlights", 13, 13);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("UI Synchronization", 6, 6, new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvActionExplorer = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ucRegKeySettings = new DBSync.UC.UCRegKeySettings();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvActionExplorer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(733, 459);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvActionExplorer
            // 
            this.tvActionExplorer.CheckBoxes = true;
            this.tvActionExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvActionExplorer.FullRowSelect = true;
            this.tvActionExplorer.ItemHeight = 20;
            this.tvActionExplorer.Location = new System.Drawing.Point(0, 0);
            this.tvActionExplorer.Name = "tvActionExplorer";
            treeNode1.ImageIndex = 17;
            treeNode1.Name = "NodeDirect";
            treeNode1.SelectedImageIndex = 17;
            treeNode1.Text = "Direct [Table to table]";
            treeNode2.ImageIndex = 18;
            treeNode2.Name = "NodeIndirect";
            treeNode2.SelectedImageIndex = 18;
            treeNode2.Text = "Indirect [Gateway to DB]";
            treeNode3.ImageIndex = 8;
            treeNode3.Name = "NodePayments";
            treeNode3.SelectedImageIndex = 8;
            treeNode3.Text = "Payments";
            treeNode4.ImageIndex = 3;
            treeNode4.Name = "NodeMembershipApplication";
            treeNode4.SelectedImageIndex = 3;
            treeNode4.Text = "Membership Application";
            treeNode5.ImageIndex = 14;
            treeNode5.Name = "NodeChangeAddress";
            treeNode5.SelectedImageIndex = 14;
            treeNode5.Text = "Change of Address";
            treeNode6.ImageIndex = 15;
            treeNode6.Name = "NodeMemberData";
            treeNode6.SelectedImageIndex = 15;
            treeNode6.Text = "New/Upgraded Member\'s Data ";
            treeNode7.ImageIndex = 10;
            treeNode7.Name = "NodeMembership";
            treeNode7.SelectedImageIndex = 10;
            treeNode7.Text = "Membership";
            treeNode8.ImageIndex = 11;
            treeNode8.Name = "NodeExamination";
            treeNode8.SelectedImageIndex = 11;
            treeNode8.Text = "Examination";
            treeNode9.ImageIndex = 7;
            treeNode9.Name = "NodeTechnicalActivities";
            treeNode9.SelectedImageIndex = 7;
            treeNode9.Text = "Technical Activities";
            treeNode10.ImageIndex = 4;
            treeNode10.Name = "NodeDataSynchronization";
            treeNode10.SelectedImageIndex = 4;
            treeNode10.Text = "Data Synchronization";
            treeNode11.ImageIndex = 10;
            treeNode11.Name = "NodeFileSyncMembership";
            treeNode11.SelectedImageIndex = 10;
            treeNode11.Text = "Membership";
            treeNode12.ImageIndex = 11;
            treeNode12.Name = "NodeFileSyncExamination";
            treeNode12.SelectedImageIndex = 11;
            treeNode12.Text = "Examination";
            treeNode13.ImageIndex = 7;
            treeNode13.Name = "NodeFileSyncTechnicalActivities";
            treeNode13.SelectedImageIndex = 7;
            treeNode13.Text = "Technical Activities";
            treeNode14.ImageIndex = 5;
            treeNode14.Name = "NodeFileSync";
            treeNode14.SelectedImageIndex = 5;
            treeNode14.Text = "File Synchronization";
            treeNode15.ImageIndex = 12;
            treeNode15.Name = "NodeForthcommingEvents";
            treeNode15.SelectedImageIndex = 12;
            treeNode15.Text = "Forthcomming Events";
            treeNode16.ImageIndex = 13;
            treeNode16.Name = "NodeHighlights";
            treeNode16.SelectedImageIndex = 13;
            treeNode16.Text = "Highlights";
            treeNode17.ImageIndex = 6;
            treeNode17.Name = "NodeUISync";
            treeNode17.SelectedImageIndex = 6;
            treeNode17.Text = "UI Synchronization";
            this.tvActionExplorer.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode14,
            treeNode17});
            this.tvActionExplorer.ShowLines = false;
            this.tvActionExplorer.Size = new System.Drawing.Size(234, 459);
            this.tvActionExplorer.TabIndex = 2;
            this.tvActionExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvActionExplorer_AfterSelect);
            this.tvActionExplorer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvActionExplorer_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ucRegKeySettings);
            this.splitContainer2.Size = new System.Drawing.Size(495, 459);
            this.splitContainer2.SplitterDistance = 236;
            this.splitContainer2.TabIndex = 1;
            // 
            // ucRegKeySettings
            // 
            this.ucRegKeySettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRegKeySettings.Location = new System.Drawing.Point(0, 0);
            this.ucRegKeySettings.Name = "ucRegKeySettings";
            this.ucRegKeySettings.Size = new System.Drawing.Size(255, 459);
            this.ucRegKeySettings.TabIndex = 0;
            this.ucRegKeySettings.Load += new System.EventHandler(this.ucRegKeySettings1_Load);
            // 
            // frmRegKeySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 459);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmRegKeySettings";
            this.Text = "frmRegKeySettings";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvActionExplorer;
        private UC.UCRegKeySettings ucRegKeySettings;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}