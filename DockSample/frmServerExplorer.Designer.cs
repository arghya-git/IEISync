namespace DBSync
{
    partial class frmServerExplorer
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("SOL Server", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Oracle", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Data Connection", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServerExplorer));
            this.tvServerExplorer = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CMSSQLServer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMISQLServerConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMISQLServerDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSOracle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMIOraConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIOraDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.CMSSQLServer.SuspendLayout();
            this.CMSOracle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvServerExplorer
            // 
            this.tvServerExplorer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvServerExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvServerExplorer.HideSelection = false;
            this.tvServerExplorer.ImageIndex = 0;
            this.tvServerExplorer.ImageList = this.imageList1;
            this.tvServerExplorer.Location = new System.Drawing.Point(0, 0);
            this.tvServerExplorer.Name = "tvServerExplorer";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "NodeSQLServer";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Text = "SOL Server";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "NodeOra";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "Oracle";
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "Node0";
            treeNode3.SelectedImageIndex = 0;
            treeNode3.Text = "Data Connection";
            this.tvServerExplorer.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.tvServerExplorer.SelectedImageIndex = 0;
            this.tvServerExplorer.Size = new System.Drawing.Size(277, 497);
            this.tvServerExplorer.TabIndex = 0;
            this.tvServerExplorer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvServerExplorer_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "DatabaseGroup.ico");
            this.imageList1.Images.SetKeyName(1, "Database.ico");
            // 
            // CMSSQLServer
            // 
            this.CMSSQLServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMISQLServerConnect,
            this.TSMISQLServerDisconnect});
            this.CMSSQLServer.Name = "contextMenuStrip1";
            this.CMSSQLServer.Size = new System.Drawing.Size(134, 48);
            // 
            // TSMISQLServerConnect
            // 
            this.TSMISQLServerConnect.Image = ((System.Drawing.Image)(resources.GetObject("TSMISQLServerConnect.Image")));
            this.TSMISQLServerConnect.Name = "TSMISQLServerConnect";
            this.TSMISQLServerConnect.Size = new System.Drawing.Size(133, 22);
            this.TSMISQLServerConnect.Text = "Connect";
            this.TSMISQLServerConnect.Click += new System.EventHandler(this.TSMISQLServerConnect_Click);
            // 
            // TSMISQLServerDisconnect
            // 
            this.TSMISQLServerDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("TSMISQLServerDisconnect.Image")));
            this.TSMISQLServerDisconnect.Name = "TSMISQLServerDisconnect";
            this.TSMISQLServerDisconnect.Size = new System.Drawing.Size(133, 22);
            this.TSMISQLServerDisconnect.Text = "Disconnect";
            this.TSMISQLServerDisconnect.Click += new System.EventHandler(this.TSMISQLServerDisconnect_Click);
            // 
            // CMSOracle
            // 
            this.CMSOracle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIOraConnect,
            this.TSMIOraDisconnect});
            this.CMSOracle.Name = "contextMenuStrip1";
            this.CMSOracle.Size = new System.Drawing.Size(134, 48);
            // 
            // TSMIOraConnect
            // 
            this.TSMIOraConnect.Image = ((System.Drawing.Image)(resources.GetObject("TSMIOraConnect.Image")));
            this.TSMIOraConnect.Name = "TSMIOraConnect";
            this.TSMIOraConnect.Size = new System.Drawing.Size(133, 22);
            this.TSMIOraConnect.Text = "Connect";
            this.TSMIOraConnect.Click += new System.EventHandler(this.TSMIOraConnect_Click);
            // 
            // TSMIOraDisconnect
            // 
            this.TSMIOraDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("TSMIOraDisconnect.Image")));
            this.TSMIOraDisconnect.Name = "TSMIOraDisconnect";
            this.TSMIOraDisconnect.Size = new System.Drawing.Size(133, 22);
            this.TSMIOraDisconnect.Text = "Disconnect";
            this.TSMIOraDisconnect.Click += new System.EventHandler(this.TSMIOraDisconnect_Click);
            // 
            // frmServerExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(277, 497);
            this.Controls.Add(this.tvServerExplorer);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmServerExplorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            this.Tag = "Server Explorer";
            this.Text = "Server Explorer";
            this.CMSSQLServer.ResumeLayout(false);
            this.CMSOracle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TreeView tvServerExplorer;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip CMSSQLServer;
        private System.Windows.Forms.ToolStripMenuItem TSMISQLServerConnect;
        private System.Windows.Forms.ToolStripMenuItem TSMISQLServerDisconnect;
        private System.Windows.Forms.ContextMenuStrip CMSOracle;
        private System.Windows.Forms.ToolStripMenuItem TSMIOraConnect;
        private System.Windows.Forms.ToolStripMenuItem TSMIOraDisconnect;
    }
}