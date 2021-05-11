using WeifenLuo.WinFormsUI.Docking;

namespace DBSync
{
    partial class frmActnWindow
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Indirect (Gateway to DB)");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Direct (Table to table)");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Payment", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Membership Application");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Change of Address");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("New/Upgraded Member\'s Data");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Membership", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Examination");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Technical Activities");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Data Synchronization", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Membership Application");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Change of Address");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("New/Upgraded Member\'s Data");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("File Synchronization", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Highlights");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Forthcomming Events");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("UI Synchronization", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.CMSAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.FullRowSelect = true;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node16";
            treeNode1.Text = "Indirect (Gateway to DB)";
            treeNode2.Name = "Node17";
            treeNode2.Text = "Direct (Table to table)";
            treeNode3.Name = "Node4";
            treeNode3.Text = "Payment";
            treeNode4.Name = "Node18";
            treeNode4.Text = "Membership Application";
            treeNode5.Name = "Node19";
            treeNode5.Text = "Change of Address";
            treeNode6.Name = "Node20";
            treeNode6.Text = "New/Upgraded Member\'s Data";
            treeNode7.Name = "Node5";
            treeNode7.Text = "Membership";
            treeNode8.Name = "Node6";
            treeNode8.Text = "Examination";
            treeNode9.Name = "Node15";
            treeNode9.Text = "Technical Activities";
            treeNode10.Name = "Node0";
            treeNode10.Text = "Data Synchronization";
            treeNode11.Name = "Node7";
            treeNode11.Text = "Membership Application";
            treeNode12.Name = "Node8";
            treeNode12.Text = "Change of Address";
            treeNode13.Name = "Node9";
            treeNode13.Text = "New/Upgraded Member\'s Data";
            treeNode14.Name = "Node1";
            treeNode14.Text = "File Synchronization";
            treeNode15.Name = "Node10";
            treeNode15.Text = "Highlights";
            treeNode16.Name = "Node11";
            treeNode16.Text = "Forthcomming Events";
            treeNode17.Name = "Node2";
            treeNode17.Text = "UI Synchronization";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode14,
            treeNode17});
            this.treeView1.Size = new System.Drawing.Size(260, 483);
            this.treeView1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // CMSAction
            // 
            this.CMSAction.Name = "CMSAction";
            this.CMSAction.Size = new System.Drawing.Size(61, 4);
            // 
            // frmActnWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 483);
            this.Controls.Add(this.treeView1);
            this.Name = "frmActnWindow";
            this.Text = "frmActnWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip CMSAction;
    }
}