using System.Timers;

namespace DBSync
{

    partial class frmActionExplorer
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
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Direct [Table to Table]", 17, 17);
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Indirect [Gateway to DB]", 18, 18);
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("From File [ *.csv To Table]", 36, 36);
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Payments", 8, 8, new System.Windows.Forms.TreeNode[] {
            treeNode31,
            treeNode32,
            treeNode33});
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Membership Application", 3, 3);
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Change of Address", 14, 14);
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("New/Upgraded Member\'s Data ", 15, 15);
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Membership", 10, 10, new System.Windows.Forms.TreeNode[] {
            treeNode35,
            treeNode36,
            treeNode37});
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Sec-B Registraton", 33, 33);
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Re-registration", 32, 32);
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Change of Optional Subjects", 34, 34);
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Marks History", 30, 30);
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Examination Application Forms", 35, 35);
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Examination", 11, 11, new System.Windows.Forms.TreeNode[] {
            treeNode39,
            treeNode40,
            treeNode41,
            treeNode42,
            treeNode43});
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Technical Activities", 7, 7);
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Employees", 20, 20);
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Council Members", 26, 26);
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Project Guides", 24, 24);
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Users", 16, 16, new System.Windows.Forms.TreeNode[] {
            treeNode46,
            treeNode47,
            treeNode48});
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("PE", 28, 28);
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Int. PE");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Certification", 27, 27, new System.Windows.Forms.TreeNode[] {
            treeNode50,
            treeNode51});
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Data Synchronization", 4, 4, new System.Windows.Forms.TreeNode[] {
            treeNode34,
            treeNode38,
            treeNode44,
            treeNode45,
            treeNode49,
            treeNode52});
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("Membership", 10, 10);
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("Examination", 11, 11);
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("Technical Activities", 7, 7);
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("File Synchronization", 5, 5, new System.Windows.Forms.TreeNode[] {
            treeNode54,
            treeNode55,
            treeNode56});
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("Forthcomming Events", 12, 12);
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("Highlights", 13, 13);
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("UI Synchronization", 6, 6, new System.Windows.Forms.TreeNode[] {
            treeNode58,
            treeNode59});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActionExplorer));
            this.items1 = new DBSync.UC.UserControl1.Items();
            this.tvActionExplorer = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.CMSAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripMenuItemBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripMenuItemDown = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItemDown = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItemDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripMenuItemUp = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItemUp = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItemUp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CMSAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // items1
            // 
            this.items1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.items1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.items1.FullRowSelect = true;
            this.items1.ItemHeight = 30;
            this.items1.LineColor = System.Drawing.Color.Empty;
            this.items1.Location = new System.Drawing.Point(0, 0);
            this.items1.Name = "items1";
            this.items1.ShowLines = false;
            this.items1.Size = new System.Drawing.Size(121, 97);
            this.items1.TabIndex = 0;
            // 
            // tvActionExplorer
            // 
            this.tvActionExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvActionExplorer.FullRowSelect = true;
            this.tvActionExplorer.ImageIndex = 0;
            this.tvActionExplorer.ImageList = this.imageList1;
            this.tvActionExplorer.ItemHeight = 20;
            this.tvActionExplorer.Location = new System.Drawing.Point(0, 0);
            this.tvActionExplorer.Name = "tvActionExplorer";
            treeNode31.ImageIndex = 17;
            treeNode31.Name = "NodeDirect";
            treeNode31.SelectedImageIndex = 17;
            treeNode31.Text = "Direct [Table to Table]";
            treeNode32.ImageIndex = 18;
            treeNode32.Name = "NodeIndirect";
            treeNode32.SelectedImageIndex = 18;
            treeNode32.Text = "Indirect [Gateway to DB]";
            treeNode33.ImageIndex = 36;
            treeNode33.Name = "NodeFile";
            treeNode33.SelectedImageIndex = 36;
            treeNode33.Text = "From File [ *.csv To Table]";
            treeNode34.ImageIndex = 8;
            treeNode34.Name = "NodePayments";
            treeNode34.SelectedImageIndex = 8;
            treeNode34.Text = "Payments";
            treeNode35.ImageIndex = 3;
            treeNode35.Name = "NodeMembershipApplication";
            treeNode35.SelectedImageIndex = 3;
            treeNode35.Text = "Membership Application";
            treeNode36.ImageIndex = 14;
            treeNode36.Name = "NodeChangeAddress";
            treeNode36.SelectedImageIndex = 14;
            treeNode36.Text = "Change of Address";
            treeNode37.ImageIndex = 15;
            treeNode37.Name = "NodeMemberData";
            treeNode37.SelectedImageIndex = 15;
            treeNode37.Text = "New/Upgraded Member\'s Data ";
            treeNode38.ImageIndex = 10;
            treeNode38.Name = "NodeMembership";
            treeNode38.SelectedImageIndex = 10;
            treeNode38.Text = "Membership";
            treeNode39.ImageIndex = 33;
            treeNode39.Name = "NodeSecB";
            treeNode39.SelectedImageIndex = 33;
            treeNode39.Text = "Sec-B Registraton";
            treeNode40.ImageIndex = 32;
            treeNode40.Name = "NodeReRegistration";
            treeNode40.SelectedImageIndex = 32;
            treeNode40.Text = "Re-registration";
            treeNode41.ImageIndex = 34;
            treeNode41.Name = "NodeChangeOfOptionalSub";
            treeNode41.SelectedImageIndex = 34;
            treeNode41.Text = "Change of Optional Subjects";
            treeNode42.ImageIndex = 30;
            treeNode42.Name = "NodeMarksHistory";
            treeNode42.SelectedImageIndex = 30;
            treeNode42.Text = "Marks History";
            treeNode43.ImageIndex = 35;
            treeNode43.Name = "NodeExaminationAppForm";
            treeNode43.SelectedImageIndex = 35;
            treeNode43.Text = "Examination Application Forms";
            treeNode44.ImageIndex = 11;
            treeNode44.Name = "NodeExamination";
            treeNode44.SelectedImageIndex = 11;
            treeNode44.Text = "Examination";
            treeNode45.ImageIndex = 7;
            treeNode45.Name = "NodeTechnicalActivities";
            treeNode45.SelectedImageIndex = 7;
            treeNode45.Text = "Technical Activities";
            treeNode46.ImageIndex = 20;
            treeNode46.Name = "NodeEmployees";
            treeNode46.SelectedImageIndex = 20;
            treeNode46.Text = "Employees";
            treeNode47.ImageIndex = 26;
            treeNode47.Name = "NodeCouncilMembers";
            treeNode47.SelectedImageIndex = 26;
            treeNode47.Text = "Council Members";
            treeNode48.ImageIndex = 24;
            treeNode48.Name = "NodeProjectGuides";
            treeNode48.SelectedImageIndex = 24;
            treeNode48.Text = "Project Guides";
            treeNode49.ImageIndex = 16;
            treeNode49.Name = "NodeUsers";
            treeNode49.SelectedImageIndex = 16;
            treeNode49.Text = "Users";
            treeNode50.ImageIndex = 28;
            treeNode50.Name = "Node1";
            treeNode50.SelectedImageIndex = 28;
            treeNode50.Text = "PE";
            treeNode51.ImageKey = "WebCustomControl(ASCX)_816.ico";
            treeNode51.Name = "Node2";
            treeNode51.SelectedImageIndex = 29;
            treeNode51.Text = "Int. PE";
            treeNode52.ImageIndex = 27;
            treeNode52.Name = "Node0";
            treeNode52.SelectedImageIndex = 27;
            treeNode52.Text = "Certification";
            treeNode53.ImageIndex = 4;
            treeNode53.Name = "NodeDataSynchronization";
            treeNode53.SelectedImageIndex = 4;
            treeNode53.Text = "Data Synchronization";
            treeNode54.ImageIndex = 10;
            treeNode54.Name = "NodeFileSyncMembership";
            treeNode54.SelectedImageIndex = 10;
            treeNode54.Text = "Membership";
            treeNode55.ImageIndex = 11;
            treeNode55.Name = "NodeFileSyncExamination";
            treeNode55.SelectedImageIndex = 11;
            treeNode55.Text = "Examination";
            treeNode56.ImageIndex = 7;
            treeNode56.Name = "NodeFileSyncTechnicalActivities";
            treeNode56.SelectedImageIndex = 7;
            treeNode56.Text = "Technical Activities";
            treeNode57.ImageIndex = 5;
            treeNode57.Name = "NodeFileSync";
            treeNode57.SelectedImageIndex = 5;
            treeNode57.Text = "File Synchronization";
            treeNode58.ImageIndex = 12;
            treeNode58.Name = "NodeForthcommingEvents";
            treeNode58.SelectedImageIndex = 12;
            treeNode58.Text = "Forthcomming Events";
            treeNode59.ImageIndex = 13;
            treeNode59.Name = "NodeHighlights";
            treeNode59.SelectedImageIndex = 13;
            treeNode59.Text = "Highlights";
            treeNode60.ImageIndex = 6;
            treeNode60.Name = "NodeUISync";
            treeNode60.SelectedImageIndex = 6;
            treeNode60.Text = "UI Synchronization";
            this.tvActionExplorer.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode53,
            treeNode57,
            treeNode60});
            this.tvActionExplorer.SelectedImageIndex = 0;
            this.tvActionExplorer.ShowLines = false;
            this.tvActionExplorer.Size = new System.Drawing.Size(320, 505);
            this.tvActionExplorer.TabIndex = 1;
            this.tvActionExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvActionExplorer_AfterSelect);
            this.tvActionExplorer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tvActionExplorer_KeyUp);
            this.tvActionExplorer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvActionExplorer_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Run.ico");
            this.imageList1.Images.SetKeyName(1, "Pause.ico");
            this.imageList1.Images.SetKeyName(2, "Stop.ico");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "OpenInWebAccess.ico");
            this.imageList1.Images.SetKeyName(20, "Team.ico");
            this.imageList1.Images.SetKeyName(21, "TeamFoundationServer.ico");
            this.imageList1.Images.SetKeyName(22, "TeamProjectCollection.ico");
            this.imageList1.Images.SetKeyName(23, "user.ico");
            this.imageList1.Images.SetKeyName(24, "UserControl.ico");
            this.imageList1.Images.SetKeyName(25, "users.ico");
            this.imageList1.Images.SetKeyName(26, "Spy.ico");
            this.imageList1.Images.SetKeyName(27, "SigningKey.ico");
            this.imageList1.Images.SetKeyName(28, "327_Options.ico");
            this.imageList1.Images.SetKeyName(29, "WebCustomControl(ASCX)_816.ico");
            this.imageList1.Images.SetKeyName(30, "126_Edit.ico");
            this.imageList1.Images.SetKeyName(31, "FileSystemEditor_5852.ico");
            this.imageList1.Images.SetKeyName(32, "VirtualMachineRefresh.ico");
            this.imageList1.Images.SetKeyName(33, "ChangesetGroup_inverse.ico");
            this.imageList1.Images.SetKeyName(34, "RetargetApplication.ico");
            this.imageList1.Images.SetKeyName(35, "WindowsForm.ico");
            this.imageList1.Images.SetKeyName(36, "FileEncodingDialog.ico");
            // 
            // CMSAction
            // 
            this.CMSAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeModeToolStripMenuItem,
            this.toolStripSeparator3,
            this.startToolStripMenuItemBoth,
            this.toolStripSeparator1,
            this.startToolStripMenuItemDown,
            this.pauseToolStripMenuItemDown,
            this.stopToolStripMenuItemDown,
            this.toolStripSeparator2,
            this.startToolStripMenuItemUp,
            this.pauseToolStripMenuItemUp,
            this.stopToolStripMenuItemUp,
            this.toolStripSeparator4,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.CMSAction.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.CMSAction.Name = "CMSAction";
            this.CMSAction.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.CMSAction.Size = new System.Drawing.Size(209, 248);
            // 
            // changeModeToolStripMenuItem
            // 
            this.changeModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem,
            this.manualToolStripMenuItem});
            this.changeModeToolStripMenuItem.Name = "changeModeToolStripMenuItem";
            this.changeModeToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.changeModeToolStripMenuItem.Text = "Change Mode : Manual";
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.autoToolStripMenuItem.Text = "Auto";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(205, 6);
            // 
            // startToolStripMenuItemBoth
            // 
            this.startToolStripMenuItemBoth.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripMenuItemBoth.Image")));
            this.startToolStripMenuItemBoth.Name = "startToolStripMenuItemBoth";
            this.startToolStripMenuItemBoth.Size = new System.Drawing.Size(208, 22);
            this.startToolStripMenuItemBoth.Text = "Start (All)";
            this.startToolStripMenuItemBoth.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // startToolStripMenuItemDown
            // 
            this.startToolStripMenuItemDown.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripMenuItemDown.Image")));
            this.startToolStripMenuItemDown.Name = "startToolStripMenuItemDown";
            this.startToolStripMenuItemDown.Size = new System.Drawing.Size(208, 22);
            this.startToolStripMenuItemDown.Text = "Start (SqlServer to Oracle)";
            this.startToolStripMenuItemDown.Click += new System.EventHandler(this.startToolStripMenuItemDown_Click);
            // 
            // pauseToolStripMenuItemDown
            // 
            this.pauseToolStripMenuItemDown.Image = ((System.Drawing.Image)(resources.GetObject("pauseToolStripMenuItemDown.Image")));
            this.pauseToolStripMenuItemDown.Name = "pauseToolStripMenuItemDown";
            this.pauseToolStripMenuItemDown.Size = new System.Drawing.Size(208, 22);
            this.pauseToolStripMenuItemDown.Text = "Pause";
            this.pauseToolStripMenuItemDown.Click += new System.EventHandler(this.pauseToolStripMenuItemDown_Click);
            // 
            // stopToolStripMenuItemDown
            // 
            this.stopToolStripMenuItemDown.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripMenuItemDown.Image")));
            this.stopToolStripMenuItemDown.Name = "stopToolStripMenuItemDown";
            this.stopToolStripMenuItemDown.Size = new System.Drawing.Size(208, 22);
            this.stopToolStripMenuItemDown.Text = "Stop";
            this.stopToolStripMenuItemDown.Click += new System.EventHandler(this.stopToolStripMenuItemDown_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // startToolStripMenuItemUp
            // 
            this.startToolStripMenuItemUp.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripMenuItemUp.Image")));
            this.startToolStripMenuItemUp.Name = "startToolStripMenuItemUp";
            this.startToolStripMenuItemUp.Size = new System.Drawing.Size(208, 22);
            this.startToolStripMenuItemUp.Text = "Start (Oracle to SqlServer)";
            this.startToolStripMenuItemUp.Click += new System.EventHandler(this.startToolStripMenuItemUp_Click);
            // 
            // pauseToolStripMenuItemUp
            // 
            this.pauseToolStripMenuItemUp.Image = ((System.Drawing.Image)(resources.GetObject("pauseToolStripMenuItemUp.Image")));
            this.pauseToolStripMenuItemUp.Name = "pauseToolStripMenuItemUp";
            this.pauseToolStripMenuItemUp.Size = new System.Drawing.Size(208, 22);
            this.pauseToolStripMenuItemUp.Text = "Pause";
            this.pauseToolStripMenuItemUp.Click += new System.EventHandler(this.pauseToolStripMenuItemUp_Click);
            // 
            // stopToolStripMenuItemUp
            // 
            this.stopToolStripMenuItemUp.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripMenuItemUp.Image")));
            this.stopToolStripMenuItemUp.Name = "stopToolStripMenuItemUp";
            this.stopToolStripMenuItemUp.Size = new System.Drawing.Size(208, 22);
            this.stopToolStripMenuItemUp.Text = "Stop";
            this.stopToolStripMenuItemUp.Click += new System.EventHandler(this.stopToolStripMenuItemUp_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(205, 6);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewToolStripMenuItem.Image")));
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.viewToolStripMenuItem.Text = "View ";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingsToolStripMenuItem.Image")));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.settingsToolStripMenuItem.Text = "Properties";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button4);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1Collapsed = true;
            this.splitContainer1.Panel1MinSize = 15;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tvActionExplorer);
            this.splitContainer1.Panel2MinSize = 15;
            this.splitContainer1.Size = new System.Drawing.Size(320, 505);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(233, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(157, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(80, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(134, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmActionExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 505);
            this.Controls.Add(this.splitContainer1);
            this.HideOnClose = true;
            this.Name = "frmActionExplorer";
            this.Text = "Action Explorer";
            this.CMSAction.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void CustomInitialization()
        {
            // 
            // timer
            // 

            //this.timer.SynchronizingObject = this;
            //this.timer.Interval = 1;
            //this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.ServiceTimer_Tick);
        }

        #endregion
        private UC.UserControl1.Items items1;
        private System.Windows.Forms.TreeView tvActionExplorer;
        private System.Windows.Forms.ContextMenuStrip CMSAction;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItemBoth;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItemDown;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItemUp;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItemDown;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItemDown;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItemUp;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItemUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem changeModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}