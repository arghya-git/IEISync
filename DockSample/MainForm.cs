using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DBSync
{
    public partial class MainForm : Form
    {
        private bool m_bSaveLayout = true;
        private DeserializeDockContent m_deserializeDockContent;
        //private DummySolutionExplorer m_solutionExplorer;
        //private DummyPropertyWindow m_propertyWindow;
        //private DummyToolbox m_toolbox;
        //private Test test;
        //private DummyOutputWindow m_outputWindow;
        //private DummyTaskList m_taskList;
        private bool _showSplash;
        private SplashScreen _splashScreen;


        public static frmServerExplorer _StartUp;
        public static OutputWindow _OutputWindow;
        public static frmPropertyWindow _PropertyWindow;
        //public OutputWindow OutputWindow { get => _OutputWindow; set => _OutputWindow = value; }
        public frmStatusWindow _StatusWindow;
        public static frmSQLToOraChangeOfAddress _SQLToOraChangeOfAddress;
        public static frmOraToSQLNewOrUpgradeMembData _OraToSQLNewOrUpgradeMembData;
        public static fromSQLToOraPayment _SQLToOraPayment;
        public static frmActionExplorer _ActionExplorer;
        //private frmActionExplorer _ActionExplorer;
        public MainForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            //SetSplashScreen();
            CreateStandardControls();

            showRightToLeft.Checked = (RightToLeft == RightToLeft.Yes);
            RightToLeftLayout = showRightToLeft.Checked;
            //_StartUp.RightToLeftLayout = RightToLeftLayout;
            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);

            vsToolStripExtender1.DefaultRenderer = _toolStripProfessionalRenderer;
            SetSchema(this.menuItemSchemaVS2015Blue, null);
        }

        #region Methods

        private IDockContent FindDocument(string text)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in dockPanel.Documents)
                    if (content.DockHandler.TabText == text)
                        return content;

                return null;
            }
        }

        private DummyDoc CreateNewDocument()
        {
            DummyDoc dummyDoc = new DummyDoc();

            int count = 1;
            string text = $"Document{count}";
            while (FindDocument(text) != null)
            {
                count++;
                text = $"Document{count}";
            }

            dummyDoc.Text = text;
            return dummyDoc;
        }

        private DummyDoc CreateNewDocument(string text)
        {
            DummyDoc dummyDoc = new DummyDoc();
            dummyDoc.Text = text;
            return dummyDoc;
        }

        private void CloseAllDocuments()
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    form.Close();
            }
            else
            {
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    // IMPORANT: dispose all panes.
                    document.DockHandler.DockPanel = null;
                    document.DockHandler.Close();
                }
            }
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(frmServerExplorer).ToString())
                return _StartUp;
            else if (persistString == typeof(OutputWindow).ToString())
                return _OutputWindow;
            else if (persistString == typeof(frmPropertyWindow).ToString())
                return _PropertyWindow;
            else if (persistString == typeof(frmStatusWindow).ToString())
                return _StatusWindow;
            else if (persistString == typeof(frmSQLToOraChangeOfAddress).ToString())
                return _SQLToOraChangeOfAddress;
            else if (persistString == typeof(frmOraToSQLNewOrUpgradeMembData).ToString())
                return _OraToSQLNewOrUpgradeMembData;
            else if (persistString == typeof(fromSQLToOraPayment).ToString())
                return _SQLToOraPayment;

            else if (persistString == typeof(frmActionExplorer).ToString())
                return _ActionExplorer;
            else
            {
                // DummyDoc overrides GetPersistString to add extra information into persistString.
                // Any DockContent may override this value to add any needed information for deserialization.

                string[] parsedStrings = persistString.Split(new char[] { ',' });
                if (parsedStrings.Length != 3)
                    return null;

                if (parsedStrings[0] != typeof(DummyDoc).ToString())
                    return null;

                frmServerExplorer _StartUp = new frmServerExplorer();

                frmStatusWindow _StatusWindow = new frmStatusWindow();

                frmSQLToOraChangeOfAddress _ChangeOfAddress = new frmSQLToOraChangeOfAddress();

                frmPropertyWindow _PropertyWindow = new frmPropertyWindow();

                return null;
            }
        }

        private void CloseAllContents()
        {
            // we don't want to create another instance of tool window, set DockPanel to null



            _StartUp.DockPanel = null;
            _OutputWindow.DockPanel = null;
            _StatusWindow.DockPanel = null;
            _SQLToOraChangeOfAddress.DockPanel = null;

            _OraToSQLNewOrUpgradeMembData.DockPanel = null;

            _ActionExplorer.DockPanel = null;
            _PropertyWindow.DockPanel = null;
            _SQLToOraPayment.DockPanel = null;
            CloseAllDocuments();

            // IMPORTANT: dispose all float windows.
            foreach (var window in dockPanel.FloatWindows.ToList())
                window.Dispose();

            System.Diagnostics.Debug.Assert(dockPanel.Panes.Count == 0);
            System.Diagnostics.Debug.Assert(dockPanel.Contents.Count == 0);
            System.Diagnostics.Debug.Assert(dockPanel.FloatWindows.Count == 0);
        }

        private readonly ToolStripRenderer _toolStripProfessionalRenderer = new ToolStripProfessionalRenderer();



        private void SetSchema(object sender, System.EventArgs e)
        {
            // Persist settings when rebuilding UI
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.temp.config");

            dockPanel.SaveAsXml(configFile);
            CloseAllContents();


            if (sender == this.menuItemSchemaVS2015Blue)
            {
                this.dockPanel.Theme = this.vS2015BlueTheme1;
                this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015BlueTheme1);
            }
            else if (sender == this.menuItemSchemaVS2015Light)
            {
                this.dockPanel.Theme = this.vS2015LightTheme1;
                this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015LightTheme1);
            }
            else if (sender == this.menuItemSchemaVS2015Dark)
            {
                this.dockPanel.Theme = this.vS2015DarkTheme1;
                this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015DarkTheme1);
            }

            menuItemSchemaVS2015Light.Checked = (sender == menuItemSchemaVS2015Light);
            menuItemSchemaVS2015Blue.Checked = (sender == menuItemSchemaVS2015Blue);
            menuItemSchemaVS2015Dark.Checked = (sender == menuItemSchemaVS2015Dark);
            if (dockPanel.Theme.ColorPalette != null)
            {
                statusBar.BackColor = dockPanel.Theme.ColorPalette.MainWindowStatusBarDefault.Background;
            }

            if (File.Exists(configFile))
                dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
        }

        private void EnableVSRenderer(VisualStudioToolStripExtender.VsVersion version, ThemeBase theme)
        {
            vsToolStripExtender1.SetStyle(mainMenu, version, theme);
            vsToolStripExtender1.SetStyle(toolBar, version, theme);
            vsToolStripExtender1.SetStyle(statusBar, version, theme);
        }

        private void SetDocumentStyle(object sender, System.EventArgs e)
        {
            DocumentStyle oldStyle = dockPanel.DocumentStyle;
            DocumentStyle newStyle;
            if (sender == menuItemDockingMdi)
                newStyle = DocumentStyle.DockingMdi;
            else if (sender == menuItemDockingWindow)
                newStyle = DocumentStyle.DockingWindow;
            else if (sender == menuItemDockingSdi)
                newStyle = DocumentStyle.DockingSdi;
            else
                newStyle = DocumentStyle.SystemMdi;

            if (oldStyle == newStyle)
                return;

            if (oldStyle == DocumentStyle.SystemMdi || newStyle == DocumentStyle.SystemMdi)
                CloseAllDocuments();

            dockPanel.DocumentStyle = newStyle;
            menuItemDockingMdi.Checked = (newStyle == DocumentStyle.DockingMdi);
            menuItemDockingWindow.Checked = (newStyle == DocumentStyle.DockingWindow);
            menuItemDockingSdi.Checked = (newStyle == DocumentStyle.DockingSdi);
            menuItemSystemMdi.Checked = (newStyle == DocumentStyle.SystemMdi);
            //menuItemLayoutByCode.Enabled = (newStyle != DocumentStyle.SystemMdi);
            menuItemNew.Enabled = (newStyle != DocumentStyle.SystemMdi);
            //toolBarButtonLayoutByCode.Enabled = (newStyle != DocumentStyle.SystemMdi);
            //toolBarButtonLayoutByXml.Enabled = (newStyle != DocumentStyle.SystemMdi);
        }

        #endregion

        #region Event Handlers

        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }



        private void menuItemAbout_Click(object sender, System.EventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.ShowDialog(this);
        }

        private void menuItemNew_Click(object sender, System.EventArgs e)
        {

            //if (dockPanel.DocumentStyle == DocumentStyle.DockingMdi)
            //{

            //    _StatusWindow.Show(dockPanel);

            //    _StartUp.Show(dockPanel, DockState.DockLeft);

            //    _ActionExplorer.Show(dockPanel, DockState.DockLeft);

            //    _OutputWindow.Show(dockPanel, DockState.DockBottom);

            //    //_DownloadOutputWindow.Show(_UploadOutputWindow.Pane, DockAlignment.Left, 0.5);

            //}
            //else
            //{

            //}
        }

        //private void menuItemOpen_Click(object sender, System.EventArgs e)
        //{
        //    OpenFileDialog openFile = new OpenFileDialog();

        //    openFile.InitialDirectory = Application.ExecutablePath;
        //    openFile.Filter = "rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*";
        //    openFile.FilterIndex = 1;
        //    openFile.RestoreDirectory = true;

        //    if (openFile.ShowDialog() == DialogResult.OK)
        //    {
        //        string fullName = openFile.FileName;
        //        string fileName = Path.GetFileName(fullName);

        //        if (FindDocument(fileName) != null)
        //        {
        //            MessageBox.Show("The document: " + fileName + " has already opened!");
        //            return;
        //        }

        //        DummyDoc dummyDoc = new DummyDoc();
        //        dummyDoc.Text = fileName;
        //        if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
        //        {
        //            dummyDoc.MdiParent = this;
        //            dummyDoc.Show();
        //        }
        //        else
        //            dummyDoc.Show(dockPanel);
        //        try
        //        {
        //            dummyDoc.FileName = fullName;
        //        }
        //        catch (Exception exception)
        //        {
        //            dummyDoc.Close();
        //            MessageBox.Show(exception.Message);
        //        }

        //    }
        //}

        //private void menuItemFile_Popup(object sender, System.EventArgs e)
        //{
        //    if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
        //    {
        //        menuItemClose.Enabled = 
        //            menuItemCloseAll.Enabled =
        //            menuItemCloseAllButThisOne.Enabled = (ActiveMdiChild != null);
        //    }
        //    else
        //    {
        //        menuItemClose.Enabled = (dockPanel.ActiveDocument != null);
        //        menuItemCloseAll.Enabled =
        //            menuItemCloseAllButThisOne.Enabled = (dockPanel.DocumentsCount > 0);
        //    }
        //}

        private void menuItemClose_Click(object sender, System.EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                ActiveMdiChild.Close();
            else if (dockPanel.ActiveDocument != null)
                dockPanel.ActiveDocument.DockHandler.Close();
        }

        private void menuItemCloseAll_Click(object sender, System.EventArgs e)
        {
            CloseAllDocuments();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            if (File.Exists(configFile))
                dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            if (m_bSaveLayout)
                dockPanel.SaveAsXml(configFile);
            else if (File.Exists(configFile))
                File.Delete(configFile);
        }

        private void menuItemToolBar_Click(object sender, System.EventArgs e)
        {
            toolBar.Visible = menuItemToolBar.Checked = !menuItemToolBar.Checked;
        }

        private void menuItemStatusBar_Click(object sender, System.EventArgs e)
        {
            statusBar.Visible = menuItemStatusBar.Checked = !menuItemStatusBar.Checked;
        }

        private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolBarButtonNew)
                menuItemNew_Click(null, null);
            //else if (e.ClickedItem == toolBarButtonOpen)
            //    menuItemOpen_Click(null, null);
            //else if (e.ClickedItem == toolBarButtonSolutionExplorer)
            //    menuItemSolutionExplorer_Click(null, null);
            //else if (e.ClickedItem == toolBarButtonPropertyWindow)
            //    menuItemPropertyWindow_Click(null, null);
            //else if (e.ClickedItem == toolBarButtonToolbox)
            //    menuItemToolbox_Click(null, null);
            //else if (e.ClickedItem == toolBarButtonOutputWindow)
            //    menuItemOutputWindow_Click(null, null);
            //else if (e.ClickedItem == toolBarButtonTaskList)
            //    menuItemTaskList_Click(null, null);
            //else if (e.ClickedItem == toolBarButtonLayoutByCode)
            //    menuItemLayoutByCode_Click(null, null);
            //else if (e.ClickedItem == toolBarButtonLayoutByXml)
            //    menuItemLayoutByXml_Click(null, null);
        }

        private void menuItemNewWindow_Click(object sender, System.EventArgs e)
        {
            _StatusWindow.Show(dockPanel);

        }

        //private void menuItemTools_Popup(object sender, System.EventArgs e)
        //{
        //    menuItemLockLayout.Checked = !this.dockPanel.AllowEndUserDocking;
        //}

        private void menuItemLockLayout_Click(object sender, System.EventArgs e)
        {
            dockPanel.AllowEndUserDocking = !dockPanel.AllowEndUserDocking;
        }

        private void menuItemLayoutByCode_Click(object sender, System.EventArgs e)
        {

        }

        private void SetSplashScreen()
        {

            _showSplash = true;
            _splashScreen = new SplashScreen();

            ResizeSplash();
            _splashScreen.Visible = true;
            _splashScreen.TopMost = true;

            Timer _timer = new Timer();
            _timer.Tick += (sender, e) =>
            {
                _splashScreen.Visible = false;
                _timer.Enabled = false;
                _showSplash = false;
            };
            _timer.Interval = 4000;
            _timer.Enabled = true;
        }

        private void ResizeSplash()
        {
            if (_showSplash)
            {

                var centerXMain = (this.Location.X + this.Width) / 2.0;
                var LocationXSplash = Math.Max(0, centerXMain - (_splashScreen.Width / 2.0));

                var centerYMain = (this.Location.Y + this.Height) / 2.0;
                var LocationYSplash = Math.Max(0, centerYMain - (_splashScreen.Height / 2.0));

                _splashScreen.Location = new Point((int)Math.Round(LocationXSplash), (int)Math.Round(LocationYSplash));
            }
        }

        private void CreateStandardControls()
        {
            _StartUp = new frmServerExplorer();
            _OutputWindow = new OutputWindow();
            _PropertyWindow = new frmPropertyWindow();
            //_UploadOutputWindow = new OutputWindow();
            _StatusWindow = new frmStatusWindow();
            _SQLToOraChangeOfAddress = new frmSQLToOraChangeOfAddress();
            _OraToSQLNewOrUpgradeMembData = new frmOraToSQLNewOrUpgradeMembData();
            _SQLToOraPayment = new fromSQLToOraPayment();
            _ActionExplorer = new frmActionExplorer();
        }

        private void menuItemLayoutByXml_Click(object sender, System.EventArgs e)
        {
            dockPanel.SuspendLayout(true);

            // In order to load layout from XML, we need to close all the DockContents
            CloseAllContents();

            CreateStandardControls();

            Assembly assembly = Assembly.GetAssembly(typeof(MainForm));
            Stream xmlStream = assembly.GetManifestResourceStream("DBSync.Resources.DockPanel.xml");
            dockPanel.LoadFromXml(xmlStream, m_deserializeDockContent);
            xmlStream.Close();

            dockPanel.ResumeLayout(true, true);
        }

        private void menuItemCloseAllButThisOne_Click(object sender, System.EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                Form activeMdi = ActiveMdiChild;
                foreach (Form form in MdiChildren)
                {
                    if (form != activeMdi)
                        form.Close();
                }
            }
            else
            {
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    if (!document.DockHandler.IsActivated)
                        document.DockHandler.Close();
                }
            }
        }

        //private void menuItemShowDocumentIcon_Click(object sender, System.EventArgs e)
        //{
        //    dockPanel.ShowDocumentIcon = menuItemShowDocumentIcon.Checked = !menuItemShowDocumentIcon.Checked;
        //}

        private void showRightToLeft_Click(object sender, EventArgs e)
        {
            CloseAllContents();
            if (showRightToLeft.Checked)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = false;
            }
            else
            {
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
            }
            //m_solutionExplorer.RightToLeftLayout = this.RightToLeftLayout;
            showRightToLeft.Checked = !showRightToLeft.Checked;
        }

        private void exitWithoutSavingLayout_Click(object sender, EventArgs e)
        {
            m_bSaveLayout = false;
            Close();
            m_bSaveLayout = true;
        }

        #endregion

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeSplash();
        }

        private void serverExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _StartUp.Show(dockPanel, DockState.DockLeft);
        }

        private void actionExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ActionExplorer.Show(dockPanel, DockState.DockLeft);
        }

        private void outputWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OutputWindow.Show(dockPanel, DockState.DockBottom);
        }

        private void propertiesWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _PropertyWindow.Show(dockPanel, DockState.DockRight);
        }



        private void changeOfAddressWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SQLToOraChangeOfAddress.Show(dockPanel);
        }

        private void newUpgradeMembersDataWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OraToSQLNewOrUpgradeMembData.Show(dockPanel);
        }

        private void paymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _SQLToOraPayment.Show(dockPanel);
        }
    }
}