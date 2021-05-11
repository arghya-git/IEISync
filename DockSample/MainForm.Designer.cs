namespace DBSync
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.serverExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeOfAddressWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newUpgradeMembersDataWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemToolBar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSchemaVS2015Light = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSchemaVS2015Blue = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSchemaVS2015Dark = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemDockingMdi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDockingSdi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDockingWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSystemMdi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showRightToLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.toolBarButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolBarButtonSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBarButtonPropertyWindow = new System.Windows.Forms.ToolStripButton();
            this.toolBarButtonToolbox = new System.Windows.Forms.ToolStripButton();
            this.toolBarButtonConnect = new System.Windows.Forms.ToolStripButton();
            this.toolBarButtonReConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.vS2005Theme1 = new WeifenLuo.WinFormsUI.Docking.VS2005Theme();
            this.vS2015LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015LightTheme();
            this.vS2015BlueTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
            this.vS2015DarkTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme();
            this.vsToolStripExtender1 = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemView,
            this.menuItemTools,
            this.menuItemWindow});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.MdiWindowListItem = this.menuItemWindow;
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(579, 24);
            this.mainMenu.TabIndex = 7;
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNew,
            this.menuItem4,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "&File";
            // 
            // menuItemNew
            // 
            this.menuItemNew.Name = "menuItemNew";
            this.menuItemNew.Size = new System.Drawing.Size(180, 22);
            this.menuItemNew.Text = "&Open Default ";
            this.menuItemNew.Click += new System.EventHandler(this.menuItemLayoutByXml_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Name = "menuItem4";
            this.menuItem4.Size = new System.Drawing.Size(177, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(180, 22);
            this.menuItemExit.Text = "&Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverExplorerToolStripMenuItem,
            this.actionExplorerToolStripMenuItem,
            this.outputWindowToolStripMenuItem,
            this.propertiesWindowToolStripMenuItem,
            this.changeOfAddressWindowToolStripMenuItem,
            this.newUpgradeMembersDataWindowToolStripMenuItem,
            this.paymentToolStripMenuItem,
            this.toolStripSeparator1,
            this.menuItemToolBar,
            this.menuItemStatusBar});
            this.menuItemView.MergeIndex = 1;
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(44, 20);
            this.menuItemView.Text = "&View";
            // 
            // serverExplorerToolStripMenuItem
            // 
            this.serverExplorerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("serverExplorerToolStripMenuItem.Image")));
            this.serverExplorerToolStripMenuItem.Name = "serverExplorerToolStripMenuItem";
            this.serverExplorerToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.serverExplorerToolStripMenuItem.Text = "Server Explorer";
            this.serverExplorerToolStripMenuItem.Click += new System.EventHandler(this.serverExplorerToolStripMenuItem_Click);
            // 
            // actionExplorerToolStripMenuItem
            // 
            this.actionExplorerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("actionExplorerToolStripMenuItem.Image")));
            this.actionExplorerToolStripMenuItem.Name = "actionExplorerToolStripMenuItem";
            this.actionExplorerToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.actionExplorerToolStripMenuItem.Text = "Action Explorer";
            this.actionExplorerToolStripMenuItem.Click += new System.EventHandler(this.actionExplorerToolStripMenuItem_Click);
            // 
            // outputWindowToolStripMenuItem
            // 
            this.outputWindowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("outputWindowToolStripMenuItem.Image")));
            this.outputWindowToolStripMenuItem.Name = "outputWindowToolStripMenuItem";
            this.outputWindowToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.outputWindowToolStripMenuItem.Text = "Output Pannel";
            this.outputWindowToolStripMenuItem.Click += new System.EventHandler(this.outputWindowToolStripMenuItem_Click);
            // 
            // propertiesWindowToolStripMenuItem
            // 
            this.propertiesWindowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("propertiesWindowToolStripMenuItem.Image")));
            this.propertiesWindowToolStripMenuItem.Name = "propertiesWindowToolStripMenuItem";
            this.propertiesWindowToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.propertiesWindowToolStripMenuItem.Text = "Properties Window";
            this.propertiesWindowToolStripMenuItem.Click += new System.EventHandler(this.propertiesWindowToolStripMenuItem_Click);
            // 
            // changeOfAddressWindowToolStripMenuItem
            // 
            this.changeOfAddressWindowToolStripMenuItem.Name = "changeOfAddressWindowToolStripMenuItem";
            this.changeOfAddressWindowToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.changeOfAddressWindowToolStripMenuItem.Text = "Change of Address Window";
            this.changeOfAddressWindowToolStripMenuItem.Click += new System.EventHandler(this.changeOfAddressWindowToolStripMenuItem_Click);
            // 
            // newUpgradeMembersDataWindowToolStripMenuItem
            // 
            this.newUpgradeMembersDataWindowToolStripMenuItem.Name = "newUpgradeMembersDataWindowToolStripMenuItem";
            this.newUpgradeMembersDataWindowToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.newUpgradeMembersDataWindowToolStripMenuItem.Text = "New/Upgrade Member\'s Data Window";
            this.newUpgradeMembersDataWindowToolStripMenuItem.Click += new System.EventHandler(this.newUpgradeMembersDataWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(275, 6);
            // 
            // menuItemToolBar
            // 
            this.menuItemToolBar.Checked = true;
            this.menuItemToolBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemToolBar.Name = "menuItemToolBar";
            this.menuItemToolBar.Size = new System.Drawing.Size(278, 22);
            this.menuItemToolBar.Text = "Tool &Bar";
            this.menuItemToolBar.Click += new System.EventHandler(this.menuItemToolBar_Click);
            // 
            // menuItemStatusBar
            // 
            this.menuItemStatusBar.Checked = true;
            this.menuItemStatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemStatusBar.Name = "menuItemStatusBar";
            this.menuItemStatusBar.Size = new System.Drawing.Size(278, 22);
            this.menuItemStatusBar.Text = "Status B&ar";
            this.menuItemStatusBar.Click += new System.EventHandler(this.menuItemStatusBar_Click);
            // 
            // menuItemTools
            // 
            this.menuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSchemaVS2015Light,
            this.menuItemSchemaVS2015Blue,
            this.menuItemSchemaVS2015Dark,
            this.menuItem6,
            this.menuItemDockingMdi,
            this.menuItemDockingSdi,
            this.menuItemDockingWindow,
            this.menuItemSystemMdi,
            this.menuItem5,
            this.showRightToLeft});
            this.menuItemTools.MergeIndex = 2;
            this.menuItemTools.Name = "menuItemTools";
            this.menuItemTools.Size = new System.Drawing.Size(46, 20);
            this.menuItemTools.Text = "&Tools";
            // 
            // menuItemSchemaVS2015Light
            // 
            this.menuItemSchemaVS2015Light.Name = "menuItemSchemaVS2015Light";
            this.menuItemSchemaVS2015Light.Size = new System.Drawing.Size(255, 22);
            this.menuItemSchemaVS2015Light.Text = "Schema: VS2015 Light";
            this.menuItemSchemaVS2015Light.Click += new System.EventHandler(this.SetSchema);
            // 
            // menuItemSchemaVS2015Blue
            // 
            this.menuItemSchemaVS2015Blue.Checked = true;
            this.menuItemSchemaVS2015Blue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemSchemaVS2015Blue.Name = "menuItemSchemaVS2015Blue";
            this.menuItemSchemaVS2015Blue.Size = new System.Drawing.Size(255, 22);
            this.menuItemSchemaVS2015Blue.Text = "Schema: VS2015 Blue";
            this.menuItemSchemaVS2015Blue.Click += new System.EventHandler(this.SetSchema);
            // 
            // menuItemSchemaVS2015Dark
            // 
            this.menuItemSchemaVS2015Dark.Name = "menuItemSchemaVS2015Dark";
            this.menuItemSchemaVS2015Dark.Size = new System.Drawing.Size(255, 22);
            this.menuItemSchemaVS2015Dark.Text = "Schema: VS2015 Dark";
            this.menuItemSchemaVS2015Dark.Click += new System.EventHandler(this.SetSchema);
            // 
            // menuItem6
            // 
            this.menuItem6.Name = "menuItem6";
            this.menuItem6.Size = new System.Drawing.Size(252, 6);
            // 
            // menuItemDockingMdi
            // 
            this.menuItemDockingMdi.Checked = true;
            this.menuItemDockingMdi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemDockingMdi.Name = "menuItemDockingMdi";
            this.menuItemDockingMdi.Size = new System.Drawing.Size(255, 22);
            this.menuItemDockingMdi.Text = "Document Style: Docking &MDI";
            this.menuItemDockingMdi.Click += new System.EventHandler(this.SetDocumentStyle);
            // 
            // menuItemDockingSdi
            // 
            this.menuItemDockingSdi.Name = "menuItemDockingSdi";
            this.menuItemDockingSdi.Size = new System.Drawing.Size(255, 22);
            this.menuItemDockingSdi.Text = "Document Style: Docking &SDI";
            this.menuItemDockingSdi.Click += new System.EventHandler(this.SetDocumentStyle);
            // 
            // menuItemDockingWindow
            // 
            this.menuItemDockingWindow.Name = "menuItemDockingWindow";
            this.menuItemDockingWindow.Size = new System.Drawing.Size(255, 22);
            this.menuItemDockingWindow.Text = "Document Style: Docking &Window";
            this.menuItemDockingWindow.Click += new System.EventHandler(this.SetDocumentStyle);
            // 
            // menuItemSystemMdi
            // 
            this.menuItemSystemMdi.Name = "menuItemSystemMdi";
            this.menuItemSystemMdi.Size = new System.Drawing.Size(255, 22);
            this.menuItemSystemMdi.Text = "Document Style: S&ystem MDI";
            this.menuItemSystemMdi.Click += new System.EventHandler(this.SetDocumentStyle);
            // 
            // menuItem5
            // 
            this.menuItem5.Name = "menuItem5";
            this.menuItem5.Size = new System.Drawing.Size(252, 6);
            // 
            // showRightToLeft
            // 
            this.showRightToLeft.Name = "showRightToLeft";
            this.showRightToLeft.Size = new System.Drawing.Size(255, 22);
            this.showRightToLeft.Text = "Show &Right-To-Left";
            this.showRightToLeft.Click += new System.EventHandler(this.showRightToLeft_Click);
            // 
            // menuItemWindow
            // 
            this.menuItemWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewWindow});
            this.menuItemWindow.MergeIndex = 2;
            this.menuItemWindow.Name = "menuItemWindow";
            this.menuItemWindow.Size = new System.Drawing.Size(63, 20);
            this.menuItemWindow.Text = "&Window";
            // 
            // menuItemNewWindow
            // 
            this.menuItemNewWindow.Name = "menuItemNewWindow";
            this.menuItemNewWindow.Size = new System.Drawing.Size(153, 22);
            this.menuItemNewWindow.Text = "&Status Window";
            this.menuItemNewWindow.Click += new System.EventHandler(this.menuItemNewWindow_Click);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.DimGray;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusBar.Location = new System.Drawing.Point(0, 387);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(579, 22);
            this.statusBar.TabIndex = 4;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel2.Image")));
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(16, 20);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            this.imageList.Images.SetKeyName(6, "");
            this.imageList.Images.SetKeyName(7, "");
            this.imageList.Images.SetKeyName(8, "");
            // 
            // toolBar
            // 
            this.toolBar.ImageList = this.imageList;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarButtonNew,
            this.toolBarButtonSeparator1,
            this.toolBarButtonPropertyWindow,
            this.toolBarButtonToolbox,
            this.toolBarButtonConnect,
            this.toolBarButtonReConnect,
            this.toolStripDropDownButton1});
            this.toolBar.Location = new System.Drawing.Point(0, 24);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(579, 25);
            this.toolBar.TabIndex = 6;
            this.toolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolBar_ButtonClick);
            // 
            // toolBarButtonNew
            // 
            this.toolBarButtonNew.Image = ((System.Drawing.Image)(resources.GetObject("toolBarButtonNew.Image")));
            this.toolBarButtonNew.Name = "toolBarButtonNew";
            this.toolBarButtonNew.Size = new System.Drawing.Size(23, 22);
            this.toolBarButtonNew.ToolTipText = "Show Layout From XML";
            // 
            // toolBarButtonSeparator1
            // 
            this.toolBarButtonSeparator1.Name = "toolBarButtonSeparator1";
            this.toolBarButtonSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBarButtonPropertyWindow
            // 
            this.toolBarButtonPropertyWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBarButtonPropertyWindow.Image = ((System.Drawing.Image)(resources.GetObject("toolBarButtonPropertyWindow.Image")));
            this.toolBarButtonPropertyWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBarButtonPropertyWindow.Name = "toolBarButtonPropertyWindow";
            this.toolBarButtonPropertyWindow.Size = new System.Drawing.Size(23, 22);
            this.toolBarButtonPropertyWindow.Text = "toolStripButton1";
            this.toolBarButtonPropertyWindow.ToolTipText = "Property Window";
            // 
            // toolBarButtonToolbox
            // 
            this.toolBarButtonToolbox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBarButtonToolbox.Image = ((System.Drawing.Image)(resources.GetObject("toolBarButtonToolbox.Image")));
            this.toolBarButtonToolbox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBarButtonToolbox.Name = "toolBarButtonToolbox";
            this.toolBarButtonToolbox.Size = new System.Drawing.Size(23, 22);
            this.toolBarButtonToolbox.Text = "toolStripButton1";
            this.toolBarButtonToolbox.ToolTipText = "Tool Box";
            // 
            // toolBarButtonConnect
            // 
            this.toolBarButtonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBarButtonConnect.Image = ((System.Drawing.Image)(resources.GetObject("toolBarButtonConnect.Image")));
            this.toolBarButtonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBarButtonConnect.Name = "toolBarButtonConnect";
            this.toolBarButtonConnect.Size = new System.Drawing.Size(23, 22);
            this.toolBarButtonConnect.Text = "toolStripButton1";
            this.toolBarButtonConnect.ToolTipText = "Connect";
            // 
            // toolBarButtonReConnect
            // 
            this.toolBarButtonReConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBarButtonReConnect.Image = ((System.Drawing.Image)(resources.GetObject("toolBarButtonReConnect.Image")));
            this.toolBarButtonReConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBarButtonReConnect.Name = "toolBarButtonReConnect";
            this.toolBarButtonReConnect.Size = new System.Drawing.Size(23, 22);
            this.toolBarButtonReConnect.Text = "toolStripButton2";
            this.toolBarButtonReConnect.ToolTipText = "Reconnect";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(60, 22);
            this.toolStripDropDownButton1.Tag = "Start";
            this.toolStripDropDownButton1.Text = "Start";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripMenuItem.Image")));
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dockPanel.DockBottomPortion = 150D;
            this.dockPanel.DockLeftPortion = 200D;
            this.dockPanel.DockRightPortion = 200D;
            this.dockPanel.DockTopPortion = 150D;
            this.dockPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.dockPanel.Location = new System.Drawing.Point(0, 49);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.RightToLeftLayout = true;
            this.dockPanel.Size = new System.Drawing.Size(579, 338);
            this.dockPanel.TabIndex = 0;
            // 
            // vsToolStripExtender1
            // 
            this.vsToolStripExtender1.DefaultRenderer = null;
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
            this.imageList1.Images.SetKeyName(8, "Payment");
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
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paymentToolStripMenuItem1,
            this.paymentToolStripMenuItem2,
            this.paymentToolStripMenuItem3});
            this.paymentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("paymentToolStripMenuItem.Image")));
            this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
            this.paymentToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.paymentToolStripMenuItem.Text = "Payment";
            // 
            // paymentToolStripMenuItem1
            // 
            this.paymentToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("paymentToolStripMenuItem1.Image")));
            this.paymentToolStripMenuItem1.Name = "paymentToolStripMenuItem1";
            this.paymentToolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.paymentToolStripMenuItem1.Text = "Direct [Table to Table]";
            this.paymentToolStripMenuItem1.Click += new System.EventHandler(this.paymentToolStripMenuItem1_Click);
            // 
            // paymentToolStripMenuItem2
            // 
            this.paymentToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("paymentToolStripMenuItem2.Image")));
            this.paymentToolStripMenuItem2.Name = "paymentToolStripMenuItem2";
            this.paymentToolStripMenuItem2.Size = new System.Drawing.Size(203, 22);
            this.paymentToolStripMenuItem2.Text = "Indirect [Gateway to Db]";
            // 
            // paymentToolStripMenuItem3
            // 
            this.paymentToolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("paymentToolStripMenuItem3.Image")));
            this.paymentToolStripMenuItem3.Name = "paymentToolStripMenuItem3";
            this.paymentToolStripMenuItem3.Size = new System.Drawing.Size(203, 22);
            this.paymentToolStripMenuItem3.Text = "From File [*.csv to Table]";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(579, 409);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "DockSample";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton toolBarButtonNew;
        private System.Windows.Forms.ToolStripSeparator toolBarButtonSeparator1;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemNew;
        private System.Windows.Forms.ToolStripSeparator menuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemStatusBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemTools;
        private System.Windows.Forms.ToolStripSeparator menuItem6;
        private System.Windows.Forms.ToolStripMenuItem menuItemDockingMdi;
        private System.Windows.Forms.ToolStripMenuItem menuItemDockingSdi;
        private System.Windows.Forms.ToolStripMenuItem menuItemDockingWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemSystemMdi;
        private System.Windows.Forms.ToolStripSeparator menuItem5;
        private System.Windows.Forms.ToolStripMenuItem menuItemWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewWindow;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem showRightToLeft;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2015Light;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2015Blue;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2015Dark;
        private WeifenLuo.WinFormsUI.Docking.VS2015LightTheme vS2015LightTheme1;
        private WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme vS2015BlueTheme1;
        private WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme vS2015DarkTheme1;
        //private WeifenLuo.WinFormsUI.Docking.VS2013LightTheme vS2013LightTheme1;
        //private WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme vS2013BlueTheme1;
        //private WeifenLuo.WinFormsUI.Docking.VS2013DarkTheme vS2013DarkTheme1;
        //private WeifenLuo.WinFormsUI.Docking.VS2012LightTheme vS2012LightTheme1;
        //private WeifenLuo.WinFormsUI.Docking.VS2012BlueTheme vS2012BlueTheme1;
        //private WeifenLuo.WinFormsUI.Docking.VS2012DarkTheme vS2012DarkTheme1;
        //private WeifenLuo.WinFormsUI.Docking.VS2003Theme vS2003Theme1;
        private WeifenLuo.WinFormsUI.Docking.VS2005Theme vS2005Theme1;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender vsToolStripExtender1;
        private System.Windows.Forms.ToolStripButton toolBarButtonPropertyWindow;
        private System.Windows.Forms.ToolStripButton toolBarButtonToolbox;
        private System.Windows.Forms.ToolStripButton toolBarButtonConnect;
        private System.Windows.Forms.ToolStripButton toolBarButtonReConnect;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem serverExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeOfAddressWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newUpgradeMembersDataWindowToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem3;
    }
}