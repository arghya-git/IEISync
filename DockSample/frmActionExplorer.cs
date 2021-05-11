using DBAdapter.OraDBCon;
using DBAdapter.SQLServerDBCon;
using Microsoft.Win32;
using Newtonsoft.Json;
using ReadWriteJson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.ActionExplorer;
using WeifenLuo.WinFormsUI.Docking;
using System.Timers;
using DBSyncBL.RegKey;
using static ViewModel.Enumeration.ActionPropertyEnums;
using DBSyncBL.Change_of_Address;
using DBSyncBL.UISynch;
using DBAdapter;
using ViewModel.Enumeration;
using FTPSolution;

namespace DBSync
{

    public partial class frmActionExplorer : DockContent
    {
        public frmActionExplorer()
        {
            InitializeComponent();

            CustomInitialization();

            tvActionExplorer.ExpandAll();


            try
            {
                ActionProperies = new List<RegKyeDBSyncActionTreeNode>();
                ActionProperies = RegKeySettings.getAllKeyProp();

                node = ActionProperies.Where(w => w.Name == "NodeDataSynchronization").SingleOrDefault();
                ActionDataSync = new ActionToolStrip(node);

                ActionToolStrips.Add(ActionDataSync);


                node = ActionProperies.Where(w => w.Name == "NodePayments").SingleOrDefault();
                ActionDataSyncPayment = new ActionToolStrip(node);
                ActionToolStrips.Add(ActionDataSyncPayment);

                node = ActionProperies.Where(w => w.Name == "NodeDirect").SingleOrDefault();
                ActionDataSyncPaymentDirect = new ActionToolStrip(node);
                ActionToolStrips.Add(ActionDataSyncPaymentDirect);


                node = ActionProperies.Where(w => w.Name == "NodeIndirect").SingleOrDefault();
                ActionDataSyncPaymentIndirect = new ActionToolStrip(node);
                ActionToolStrips.Add(ActionDataSyncPaymentIndirect);

                node = ActionProperies.Where(w => w.Name == "NodeFile").SingleOrDefault();
                ActionDataSyncPaymentFile = new ActionToolStrip(node);
                ActionToolStrips.Add(ActionDataSyncPaymentIndirect);

                node = ActionProperies.Where(w => w.Name == "NodeMembership").SingleOrDefault();
                ActionDataSyncMembership = new ActionToolStrip(node);
                ActionToolStrips.Add(ActionDataSyncMembership);

                node = ActionProperies.Where(w => w.Name == "NodeMembershipApplication").SingleOrDefault();
                ActionDataSyncMembershipApplication = new ActionToolStrip(node);
                //ActionDataSync.ActionPropery.ActionProperties.Timer.Elapsed += new System.Timers.ElapsedEventHandler(this.PaymentIndirectTimer_Tick);
                ActionToolStrips.Add(ActionDataSyncMembershipApplication);

                node = ActionProperies.Where(w => w.Name == "NodeChangeAddress").SingleOrDefault();
                ActionDataSyncChangeAddress = new ActionToolStrip(node);
                ActionToolStrips.Add(ActionDataSyncChangeAddress);

                node = ActionProperies.Where(w => w.Name == "NodeMemberData").SingleOrDefault();
                ActionDataSyncMemberData = new ActionToolStrip(node);
                ActionToolStrips.Add(ActionDataSyncMemberData);

                node = ActionProperies.Where(w => w.Name == "NodeExamination").SingleOrDefault();
                ActionDataSyncExamination = new ActionToolStrip(node);
                ActionToolStrips.Add(ActionDataSyncExamination);

                node = ActionProperies.Where(w => w.Name == "NodeTechnicalActivities").SingleOrDefault();
                ActionDataSyncTechnicalActivities = new ActionToolStrip(node);
                ActionToolStrips.Add(ActionDataSyncTechnicalActivities);



            }
            catch { }
        }





        public void ChangeMode(string ch, string Mode)
        {
            RegKyeDBSyncActionTreeNode obj = new RegKyeDBSyncActionTreeNode();

            obj = RegKeySettings.setRegKey(ch, "Mode", Mode);
            MainForm._PropertyWindow.Properies = obj;
            //frmPropertyWindow.k

            //RegKeySettings.setRegKey(ch, propertyGrid.SelectedGridItem.Label, propertyGrid.SelectedGridItem.Value.ToString());
            switch (ch)
            {
                case "NodeDataSynchronization":
                    //obj = ActionDataSync;

                    //MainForm._PropertyWindow.Properies = obj.ActionPropery;
                    break;
                case "NodePayments":
                    //obj = ActionDataSyncPayment;

                    //MainForm._PropertyWindow.Properies = obj.ActionPropery;
                    break;
                case "NodeDirect":
                    //obj = ActionDataSyncPaymentDirect;

                    //MainForm._PropertyWindow.Properies = obj.ActionPropery;
                    break;
                case "NodeIndirect":
                    //obj = ActionDataSyncPaymentIndirect;
                    //obj.ActionPropery = RegKeySettings.setRegKey(ch, "Mode", Mode);
                    //MainForm._PropertyWindow.Properies = obj.ActionPropery;
                    break;
                case "NodeMembership":
                    //obj = ActionDataSyncMembership;

                    //obj.ActionPropery = RegKeySettings.setRegKey(ch, "Mode", Mode);
                    //MainForm._PropertyWindow.Properies = obj.ActionPropery;
                    break;
                case "NodeMembershipApplication":
                    //obj = ActionDataSyncMembershipApplication;

                    //obj.ActionPropery = RegKeySettings.setRegKey(ch, "Mode", Mode);
                    //MainForm._PropertyWindow.Properies = obj.ActionPropery;
                    break;
                case "NodeChangeAddress":
                    ActionDataSyncChangeAddress.ActionPropery = obj;
                    //obj = ActionDataSyncChangeAddress;
                    ////obj.ActionPropery.ActionProperties.Mode = ActionDataSyncChangeAddress.setMode(Mode);

                    //obj.ActionPropery = RegKeySettings.setRegKey(ch, "Mode", Mode);
                    //MainForm._PropertyWindow.Properies = obj.ActionPropery;

                    break;
                case "NodeMemberData":
                    //obj = ActionDataSyncMemberData;
                    //obj.ActionPropery.ActionProperties.Mode = ActionDataSyncChangeAddress.setMode(Mode);
                    //MainForm._PropertyWindow.Properies = obj.ActionPropery;
                    break;
                case "NodeExamination":
                    //obj = ActionDataSyncExamination;
                    //obj.ActionPropery.ActionProperties.Mode = ActionDataSyncChangeAddress.setMode(Mode);
                    //MainForm._PropertyWindow.Properies = obj.ActionPropery;
                    break;
                case "NodeTechnicalActivities":
                    //obj = ActionDataSyncTechnicalActivities;
                    //obj.ActionPropery.ActionProperties.Mode = ActionDataSyncChangeAddress.setMode(Mode);
                    //MainForm._PropertyWindow.Properies = obj.ActionPropery;
                    break;
            }

            CMSActionRefresh(obj);
        }
        public void setAction(string ch, int state)
        {
            ActionToolStrip obj = new ActionToolStrip();
            switch (ch)
            {
                case "NodeDataSynchronization":
                    obj = ActionDataSync;
                    ActionDataSync.changeState(state);

                    break;
                case "NodePayments":
                    obj = ActionDataSyncPayment;
                    ActionDataSyncPayment.changeState(state);

                    break;
                case "NodeDirect":
                    obj = ActionDataSyncPaymentDirect;
                    ActionDataSyncPaymentDirect.changeState(state);
                    tvActionExplorer.SelectedNode.Text = "Direct [Table to table]    " + "(" + ActionDataSyncPaymentDirect.ActionPropery.ActionProperties.Text + ")";
                    break;
                case "NodeIndirect":
                    obj = ActionDataSyncPaymentIndirect;
                    ActionDataSyncPaymentIndirect.changeState(state);
                    tvActionExplorer.SelectedNode.Text = "Indirect [Gateway to DB]    " + "(" + ActionDataSyncPaymentIndirect.ActionPropery.ActionProperties.Text + ")";
                    break;
                case "NodeFile":
                    obj = ActionDataSyncPaymentIndirect;
                    ActionDataSyncPaymentIndirect.changeState(state);
                    tvActionExplorer.SelectedNode.Text = "From File [*.csv to table]    " + "(" + ActionDataSyncPaymentIndirect.ActionPropery.ActionProperties.Text + ")";
                    break;
                case "NodeMembership":
                    obj = ActionDataSyncMembership;
                    ActionDataSyncMembership.changeState(state);

                    break;
                case "NodeMembershipApplication":
                    obj = ActionDataSyncMembershipApplication;
                    ActionDataSyncMembershipApplication.changeState(state);
                    tvActionExplorer.SelectedNode.Text = "Membership Application    " + "(" + ActionDataSyncMembershipApplication.ActionPropery.ActionProperties.Text + ")";
                    break;
                case "NodeChangeAddress":
                    obj = ActionDataSyncChangeAddress;
                    ActionDataSyncChangeAddress.changeState(state);
                    tvActionExplorer.SelectedNode.Text = "Change of Address    " + "(" + ActionDataSyncChangeAddress.ActionPropery.ActionProperties.Text + ")";
                    break;
                case "NodeMemberData":
                    obj = ActionDataSyncMemberData;
                    ActionDataSyncMemberData.changeState(state);
                    tvActionExplorer.SelectedNode.Text = "New/Upgraded Member's Data    " + "(" + ActionDataSyncMemberData.ActionPropery.ActionProperties.Text + ")";
                    break;
                case "NodeExamination":
                    obj = ActionDataSyncExamination;
                    ActionDataSyncExamination.changeState(state);
                    //tvActionExplorer.SelectedNode.Text = "New/Upgraded Member's Data    " + "(" + ActionDataSyncExamination.Text + ")";
                    break;
                case "NodeTechnicalActivities":
                    obj = ActionDataSyncTechnicalActivities;
                    ActionDataSyncTechnicalActivities.changeState(state);
                    //tvActionExplorer.SelectedNode.Text = "New/Upgraded Member's Data    " + "(" + ActionDataSyncTechnicalActivities.Text + ")";
                    break;
            }
            //if(state == 1)
            //{
            //    tvActionExplorer.SelectedNode.Text = "Direct [Table to table]   (Up & Down Sync Runing  ...)";
            //}
            //if (state == 2)
            //{
            //    tvActionExplorer.SelectedNode.Text = "Indirect [Gateway to DB]   (Up & Down Sync Runing  ...)";
            //}
            CMSActionRefresh(obj.ActionPropery);

        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setAction(tvActionExplorer.SelectedNode.Name, 1);
        }
        private void startToolStripMenuItemUp_Click(object sender, EventArgs e)
        {
            setAction(tvActionExplorer.SelectedNode.Name, 2);

            if (tvActionExplorer.SelectedNode.Name == "NodeMemberData")
            {
                MainForm._OraToSQLNewOrUpgradeMembData.Start(this);
            }

        }
        private void startToolStripMenuItemDown_Click(object sender, EventArgs e)
        {
            setAction(tvActionExplorer.SelectedNode.Name, 4);

            //initAction(mode.Manual);
            if (tvActionExplorer.SelectedNode.Name == "NodeChangeAddress")
            {
                MainForm._SQLToOraChangeOfAddress.Start(this,"NodeChangeAddress");
            }
            if (tvActionExplorer.SelectedNode.Name == "NodeDirect")
            {
                MainForm._SQLToOraPayment.Start(this, "NodeDirect");
            }
        }
        private void pauseToolStripMenuItemUp_Click(object sender, EventArgs e)
        {
            setAction(tvActionExplorer.SelectedNode.Name, 8);
        }
        private void pauseToolStripMenuItemDown_Click(object sender, EventArgs e)
        {
            setAction(tvActionExplorer.SelectedNode.Name, 16);
        }
        private void stopToolStripMenuItemUp_Click(object sender, EventArgs e)
        {
            setAction(tvActionExplorer.SelectedNode.Name, 32);
        }
        private void stopToolStripMenuItemDown_Click(object sender, EventArgs e)
        {
            setAction(tvActionExplorer.SelectedNode.Name, 64);
        }

        private void selectedFormShow(string NodeName)
        {
            switch (NodeName)
            {
                case "NodeDataSynchronization":

                    break;
                case "NodePayments":

                    break;

                case "NodeDirect":
                    MainForm._SQLToOraPayment.Show();

                    break;
                case "NodeIndirect":


                    break;
                case "NodeFile":


                    break;
                case "NodeMembership":


                    break;
                case "NodeMembershipApplication":

                    break;
                case "NodeChangeAddress":
                    MainForm._SQLToOraChangeOfAddress.Show();

                    break;
                case "NodeMemberData":
                    MainForm._OraToSQLNewOrUpgradeMembData.Show();
                    break;
                case "NodeExamination":

                    break;
                case "NodeTechnicalActivities":

                    break;

            }
        }
        private void tvActionExplorer_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {


                if (DBAdapter.OraDBCon.Connection.State == DBAdapterEnums.state.connected && DBAdapter.SQLServerDBCon.Connection.State == DBAdapterEnums.state.connected)
                {
                    try
                    {
                        tvActionExplorer.SelectedNode = tvActionExplorer.GetNodeAt(e.X, e.Y);

                        if (tvActionExplorer.SelectedNode != null)
                        {
                            initAction(tvActionExplorer.SelectedNode.Name, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    frmDBConnect obj = new frmDBConnect();
                    obj.ShowDialog();

                }

                // Select the clicked node

            }
        }
        private void tvActionExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvActionExplorer.SelectedNode != null)
            {
                selectedFormShow(tvActionExplorer.SelectedNode.Name);
                RegKyeDBSyncActionProperties obj = new RegKyeDBSyncActionProperties();
                MainForm._PropertyWindow.KeySettings.ID = tvActionExplorer.SelectedNode.Name;
                MainForm._PropertyWindow.initPropery(tvActionExplorer.SelectedNode.Name);

            }
        }
        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeMode(tvActionExplorer.SelectedNode.Name, autoToolStripMenuItem.Text);


            changeModeToolStripMenuItem.Text = "Change Mode : " + autoToolStripMenuItem.Text;

            CMSAction.Show();
            CMSAction.Refresh();
        }
        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeMode(tvActionExplorer.SelectedNode.Name, manualToolStripMenuItem.Text);
            changeModeToolStripMenuItem.Text = "Change Mode : " + manualToolStripMenuItem.Text;
            CMSAction.Show();
            CMSAction.Refresh();

        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegKyeDBSyncActionProperties obj = new RegKyeDBSyncActionProperties();
            MainForm._PropertyWindow.KeySettings.ID = tvActionExplorer.SelectedNode.Name;
            MainForm._PropertyWindow.initPropery(tvActionExplorer.SelectedNode.Name);

            if (MainForm._PropertyWindow.DockState == DockState.DockRightAutoHide)
            {
                MainForm._PropertyWindow.Show();
                MainForm._PropertyWindow.Focus();
                MainForm._PropertyWindow.DockPanel.ActiveAutoHideContent = MainForm._PropertyWindow;
                MainForm._PropertyWindow.Activate();

            }
            else if (MainForm._PropertyWindow.DockState == DockState.DockRight)
            {
                MainForm._PropertyWindow.Show();
                MainForm._PropertyWindow.Activate();
            }
            else
            {
                MainForm._PropertyWindow.Show();
                MainForm._PropertyWindow.DockState = DockState.DockRightAutoHide;
                MainForm._PropertyWindow.Focus();
                MainForm._PropertyWindow.DockPanel.ActiveAutoHideContent = MainForm._PropertyWindow;
                MainForm._PropertyWindow.Activate();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmRegKeySettings obj = new frmRegKeySettings();
            obj.ShowDialog();
        }


        CrossThreadHandler _CrossThreadHandler = new CrossThreadHandler();

        public void MonitorChangeAddressDown()
        {
            ActionDataSyncChangeAddress.ActionPropery.DoWorkFlag = true;
        }
        public void doChangeAddressDown()
        {
            //SqlServerToOracleChangeOfAddress obj = new SqlServerToOracleChangeOfAddress();

            //obj.SyncChangeAddress();
            //ActionDataSyncChangeAddress.ActionPropery.ActionProperties.Schedule.CurrentState = false;
            //RegKeySettings.setRegKey("NodeChangeAddress", "ScheduleDate", DateTime.Now.ToString());

            //textBox1.Text = DateTime.Now.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            ActionDataSyncChangeAddress.ActionPropery.SynchronizingObject = this;
            ActionDataSyncChangeAddress.ActionPropery.UiElement = this;
            ActionDataSyncChangeAddress.ActionPropery.Monitor = delegate () { MonitorChangeAddressDown(); };
            ActionDataSyncChangeAddress.ActionPropery.DoWork = delegate () { doChangeAddressDown(); };
            ActionDataSyncChangeAddress.ActionPropery.intiTimer(true, this);



            //ActionDataSyncChangeAddress.ActionPropery.SynchronizingObject = this;
            //ActionDataSyncChangeAddress.ActionPropery.UiElement = this;
            //ActionDataSyncChangeAddress.ActionPropery.Monitor = delegate () { MonitorChangeAddressDown(); };

            //ActionDataSyncChangeAddress.ActionPropery.DoWork = delegate () { doChangeAddressDown(); };

            //ActionDataSyncChangeAddress.ActionPropery.intiTimer(true);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //timer.Stop();
            BLForthCommingEvents obj = new BLForthCommingEvents();

            string JsonStr = obj.createJSon();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            //timer.Start();

            UploadFile obj = new UploadFile();

            obj.User = "webiei";
            obj.Host = "137.59.201.63";
            obj.Pass = "edp@123$";
            //obj.upload(@"WebUI/Handler/Home/JsonForthComingEvent.json", @"D:\JsonForthComingEvent.json");
            obj.upload(@"ftp://www.ieindia.org/WebUI/Handler/Home/JsonForthComingEvent3.json", @"D:\JsonForthComingEvent.json");
        }
        private void refreshToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            //ChangeMode(tvActionExplorer.SelectedNode.Name, autoToolStripMenuItem.Text);
            //changeModeToolStripMenuItem.Text = "Change Mode : " + autoToolStripMenuItem.Text;
            //CMSActionRefresh(tvActionExplorer.SelectedNode.Name);
            //CMSAction.Refresh();
            //CMSAction.Refresh();

            //CMSAction.Show();
            //CMSAction.Refresh();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm._SQLToOraChangeOfAddress.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void tvActionExplorer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                // var _DockState=   MainForm._PropertyWindow.DockState;
                MainForm._PropertyWindow.Show(DockState.Unknown);
            }

        }


    }
}
