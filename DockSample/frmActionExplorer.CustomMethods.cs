using System.Windows.Forms;
using ViewModel.ActionExplorer;
using DBSyncBL.RegKey;
using static ViewModel.Enumeration.ActionPropertyEnums;

namespace DBSync
{
    public partial class frmActionExplorer
    {

        public void setMode(bool _Mode)
        {
            startToolStripMenuItemBoth.Visible = _Mode;
            startToolStripMenuItemDown.Visible = _Mode;
            startToolStripMenuItemUp.Visible = _Mode;

            pauseToolStripMenuItemDown.Visible = _Mode;
            pauseToolStripMenuItemUp.Visible = _Mode;

            stopToolStripMenuItemDown.Visible = _Mode;
            stopToolStripMenuItemUp.Visible = _Mode;
        }
        public void initToolStrip(type _ToolStripType)
        {
            if (_ToolStripType == type.LeafNode)
            {
                startToolStripMenuItemBoth.Text = "Start (All)";
                startToolStripMenuItemDown.Text = "Start (SqlServer to Oracle)";
                startToolStripMenuItemUp.Text = "Start (Oracle to SqlServer)";

                viewToolStripMenuItem.Text = "View";
                settingsToolStripMenuItem.Text = "Properties";
            }
            if (_ToolStripType == type.ChiledNode)
            {
                startToolStripMenuItemBoth.Text = "Start All";

                viewToolStripMenuItem.Text = "View";
                settingsToolStripMenuItem.Text = "Settings";              
            }
            if (_ToolStripType == type.RootNode)
            {
                startToolStripMenuItemBoth.Text = "Start (All)";

                viewToolStripMenuItem.Text = "View";
                settingsToolStripMenuItem.Text = "Settings";             
            }
        }
        public void initAction(string ch, MouseEventArgs e)
        {
            ActionToolStrip obj = new ActionToolStrip();
            switch (ch)
            {
                case "NodeDataSynchronization":
                    obj = ActionDataSync;
                    initToolStrip(ActionDataSync.ActionPropery.ActionProperties.Type);
                    CMSAction.Show(tvActionExplorer, e.Location);
                    break;
                case "NodePayments":
                    obj = ActionDataSyncPayment;
                    initToolStrip(ActionDataSyncPayment.ActionPropery.ActionProperties.Type);
                    CMSAction.Show(tvActionExplorer, e.Location);
                    break;

                case "NodeDirect":

                    obj = ActionDataSyncPaymentDirect;
                    initToolStrip(ActionDataSyncPaymentDirect.ActionPropery.ActionProperties.Type);
                    changeModeToolStripMenuItem.Text = "Change Mode : " + ActionDataSyncPaymentDirect.getMode();
                    CMSAction.Show(tvActionExplorer, e.Location);
                    break;
                case "NodeIndirect":

                    obj = ActionDataSyncPaymentIndirect;
                    initToolStrip(ActionDataSyncPaymentIndirect.ActionPropery.ActionProperties.Type);
                    changeModeToolStripMenuItem.Text = "Change Mode : " + ActionDataSyncPaymentIndirect.getMode();
                    CMSAction.Show(tvActionExplorer, e.Location);
                    break;
                case "NodeFile":

                    obj = ActionDataSyncPaymentIndirect;
                    initToolStrip(ActionDataSyncPaymentIndirect.ActionPropery.ActionProperties.Type);
                    changeModeToolStripMenuItem.Text = "Change Mode : " + ActionDataSyncPaymentIndirect.getMode();
                    CMSAction.Show(tvActionExplorer, e.Location);
                    break;
                case "NodeMembership":

                    obj = ActionDataSyncMembership;
                    initToolStrip(ActionDataSyncMembership.ActionPropery.ActionProperties.Type);
                    changeModeToolStripMenuItem.Text = "Change Mode : " + ActionDataSyncMembership.getMode();
                    CMSAction.Show(tvActionExplorer, e.Location);
                    break;
                case "NodeMembershipApplication":


                    obj = ActionDataSyncMembershipApplication;
                    initToolStrip(ActionDataSyncMembershipApplication.ActionPropery.ActionProperties.Type);
                    changeModeToolStripMenuItem.Text = "Change Mode : " + ActionDataSyncMembershipApplication.getMode();
                    CMSAction.Show(tvActionExplorer, e.Location);
                    break;
                case "NodeChangeAddress":


                    obj = ActionDataSyncChangeAddress;
                    initToolStrip(ActionDataSyncChangeAddress.ActionPropery.ActionProperties.Type);
                    changeModeToolStripMenuItem.Text = "Change Mode : " + ActionDataSyncChangeAddress.getMode();
                    CMSAction.Show(tvActionExplorer, e.Location);
                    break;
                case "NodeMemberData":

                    obj = ActionDataSyncMemberData;
                    initToolStrip(ActionDataSyncMemberData.ActionPropery.ActionProperties.Type);
                    changeModeToolStripMenuItem.Text = "Change Mode : " + ActionDataSyncMemberData.getMode();
                    CMSAction.Show(tvActionExplorer, e.Location);
                    break;
                case "NodeExamination":

                    initToolStrip(ActionDataSyncExamination.ActionPropery.ActionProperties.Type);
                    changeModeToolStripMenuItem.Text = "Change Mode : " + ActionDataSyncExamination.getMode();
                    CMSAction.Show(tvActionExplorer, e.Location);
                    break;
                case "NodeTechnicalActivities":

                    initToolStrip(ActionDataSyncTechnicalActivities.ActionPropery.ActionProperties.Type);
                    changeModeToolStripMenuItem.Text = "Change Mode : " + ActionDataSyncTechnicalActivities.getMode();
                    CMSAction.Show(tvActionExplorer, e.Location);
                    break;

            }
            CMSActionRefresh(obj.ActionPropery);
        }

        private void CMSActionRefresh(RegKyeDBSyncActionTreeNode obj)
        {

            CMSAction.Items["startToolStripMenuItemBoth"].Enabled = 
                (obj.ActionProperties.StartEnabledBoth && (obj.ActionProperties.Mode == mode.Auto ? false : true));

            CMSAction.Items["startToolStripMenuItemDown"].Enabled =
                (obj.ActionProperties.StartEnabledDown && (obj.ActionProperties.Mode == mode.Auto ? false : true));

            CMSAction.Items["startToolStripMenuItemUp"].Enabled = 
                (obj.ActionProperties.StartEnabledUp && (obj.ActionProperties.Mode == mode.Auto ? false : true));

            CMSAction.Items["stopToolStripMenuItemUp"].Enabled = 
                (obj.ActionProperties.StopEnabledUp && (obj.ActionProperties.Mode == mode.Auto ? false : true));

            CMSAction.Items["stopToolStripMenuItemDown"].Enabled = 
                (obj.ActionProperties.StopEnabledDown && (obj.ActionProperties.Mode == mode.Auto ? false : true));

            CMSAction.Items["pauseToolStripMenuItemUp"].Enabled = 
                (obj.ActionProperties.PauseEnabledUp && (obj.ActionProperties.Mode == mode.Auto ? false : true));

            CMSAction.Items["pauseToolStripMenuItemDown"].Enabled =
                (obj.ActionProperties.PauseEnabledDown && (obj.ActionProperties.Mode == mode.Auto ? false : true));



            CMSAction.Items["startToolStripMenuItemBoth"].Visible =
                (obj.ActionProperties.StartVisibleBoth && (obj.ActionProperties.Mode == mode.Auto ? false : true));

            CMSAction.Items["startToolStripMenuItemDown"].Visible =
                (obj.ActionProperties.StartVisibleDown && (obj.ActionProperties.Mode == mode.Auto ? false : true));

            CMSAction.Items["startToolStripMenuItemUp"].Visible = 
                (obj.ActionProperties.StartVisibleUp && (obj.ActionProperties.Mode == mode.Auto ? false : true));

            CMSAction.Items["stopToolStripMenuItemUp"].Visible = 
                (obj.ActionProperties.StopVisibleUp && (obj.ActionProperties.Mode == mode.Auto ? false : true));

            CMSAction.Items["stopToolStripMenuItemDown"].Visible = 
                (obj.ActionProperties.StopVisibleDown && (obj.ActionProperties.Mode == mode.Auto ? false : true));

            CMSAction.Items["pauseToolStripMenuItemUp"].Visible = 
                (obj.ActionProperties.PauseVisibleUp && (obj.ActionProperties.Mode == mode.Auto ? false : true));

            CMSAction.Items["pauseToolStripMenuItemDown"].Visible = 
                (obj.ActionProperties.PauseVisibleDown && (obj.ActionProperties.Mode == mode.Auto ? false : true));

            CMSAction.Items["toolStripSeparator1"].Visible = CMSAction.Items["startToolStripMenuItemBoth"].Visible;
            CMSAction.Items["toolStripSeparator2"].Visible = CMSAction.Items["startToolStripMenuItemDown"].Visible;
            CMSAction.Items["toolStripSeparator4"].Visible = CMSAction.Items["startToolStripMenuItemUp"].Visible;

            CMSAction.Refresh();
        }

        private void setValues(ActionToolStrip obj)
        {
            if (obj.ActionPropery.ActionProperties.Mode == 0)
            {

                obj.ActionPropery.ActionProperties.StartEnabledBoth = false;
                obj.ActionPropery.ActionProperties.StartEnabledDown = false;
                obj.ActionPropery.ActionProperties.StartEnabledUp = false;

                obj.ActionPropery.ActionProperties.StopEnabledUp = false;
                obj.ActionPropery.ActionProperties.StopEnabledDown = false;

                obj.ActionPropery.ActionProperties.PauseEnabledUp = false;
                obj.ActionPropery.ActionProperties.PauseEnabledDown = false;

                obj.ActionPropery.ActionProperties.StartVisibleBoth = false;
                obj.ActionPropery.ActionProperties.StartVisibleDown = false;
                obj.ActionPropery.ActionProperties.StartVisibleUp = false;

                obj.ActionPropery.ActionProperties.StopVisibleUp = false;
                obj.ActionPropery.ActionProperties.StopVisibleDown = false;

                obj.ActionPropery.ActionProperties.PauseVisibleUp = false;
                obj.ActionPropery.ActionProperties.PauseVisibleDown = false;

            }
            CMSAction.Items["changeModeToolStripMenuItem"].Text = "Change Mode : " + obj.ActionPropery.ActionProperties.Mode.ToString();


            CMSAction.Items["changeModeToolStripMenuItem"].Text = "Change Mode : " + obj.ActionPropery.ActionProperties.Mode.ToString();
            CMSAction.Items["startToolStripMenuItemBoth"].Enabled = obj.ActionPropery.ActionProperties.StartEnabledBoth;
            CMSAction.Items["startToolStripMenuItemDown"].Enabled = obj.ActionPropery.ActionProperties.StartEnabledDown;
            CMSAction.Items["startToolStripMenuItemUp"].Enabled = obj.ActionPropery.ActionProperties.StartEnabledUp;

            CMSAction.Items["stopToolStripMenuItemUp"].Enabled = obj.ActionPropery.ActionProperties.StopEnabledUp;
            CMSAction.Items["stopToolStripMenuItemDown"].Enabled = obj.ActionPropery.ActionProperties.StopEnabledDown;

            CMSAction.Items["pauseToolStripMenuItemUp"].Enabled = obj.ActionPropery.ActionProperties.PauseEnabledUp;
            CMSAction.Items["pauseToolStripMenuItemDown"].Enabled = obj.ActionPropery.ActionProperties.PauseEnabledDown;

            CMSAction.Items["startToolStripMenuItemBoth"].Visible = obj.ActionPropery.ActionProperties.StartVisibleBoth;
            CMSAction.Items["startToolStripMenuItemDown"].Visible = obj.ActionPropery.ActionProperties.StartVisibleDown;
            CMSAction.Items["startToolStripMenuItemUp"].Visible = obj.ActionPropery.ActionProperties.StartVisibleUp;

            CMSAction.Items["stopToolStripMenuItemUp"].Visible = obj.ActionPropery.ActionProperties.StopVisibleUp;
            CMSAction.Items["stopToolStripMenuItemDown"].Visible = obj.ActionPropery.ActionProperties.StopVisibleDown;

            CMSAction.Items["pauseToolStripMenuItemUp"].Visible = obj.ActionPropery.ActionProperties.PauseVisibleUp;
            CMSAction.Items["pauseToolStripMenuItemDown"].Visible = obj.ActionPropery.ActionProperties.PauseVisibleDown;

            CMSAction.Items["startToolStripMenuItemBoth"].Visible = CMSAction.Items["toolStripSeparator1"].Visible = obj.ActionPropery.ActionProperties.StartEnabledBoth;
            CMSAction.Items["startToolStripMenuItemDown"].Visible = CMSAction.Items["toolStripSeparator2"].Visible = obj.ActionPropery.ActionProperties.StartEnabledDown;
            CMSAction.Items["startToolStripMenuItemUp"].Visible = CMSAction.Items["toolStripSeparator4"].Visible = obj.ActionPropery.ActionProperties.StartEnabledDown;


            CMSAction.Refresh();
        }
     
    }
}
