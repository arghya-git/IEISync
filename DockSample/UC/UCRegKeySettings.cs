using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBSyncBL.RegKey;
using ViewModel.ActionExplorer;

namespace DBSync.UC
{
    public partial class UCRegKeySettings : UserControl
    {
        PropertyGrid _PropertySettings;
        public UCRegKeySettings()
        {
            InitializeComponent();
          
        }
        public UCRegKeySettings(string Id)
        {
            InitializeComponent();
            _ID = Id;
        }
        string _ID = string.Empty;
        public PropertyGrid PropertySettings { get => propertyGrid; set => _PropertySettings = propertyGrid; }
        public string ID { get => _ID; set => _ID = value; }
        public RegKyeDBSyncActionTreeNode ActionTreeNode { get => _ActionTreeNode; set => _ActionTreeNode = value; }

        RegKyeDBSyncActionTreeNode _ActionTreeNode = new RegKyeDBSyncActionTreeNode();
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            ActionTreeNode = RegKeySettings.setRegKey(_ID, propertyGrid.SelectedGridItem.Label, propertyGrid.SelectedGridItem.Value.ToString());
            switch (_ID)
            {
               
                case "NodeDirect":
                    frmActionExplorer.ActionDataSyncPaymentDirect.ActionPropery = ActionTreeNode;
                    break;
                case "NodeIndirect":
                    frmActionExplorer.ActionDataSyncPaymentIndirect.ActionPropery = ActionTreeNode;
                    break;
                case "NodeMembershipApplication":
                    frmActionExplorer.ActionDataSyncMembershipApplication.ActionPropery = ActionTreeNode;
                    break;
                case "NodeChangeAddress":
                    frmActionExplorer.ActionDataSyncChangeAddress.ActionPropery = ActionTreeNode;
                    break;
                case "NodeMemberData":

                    break;
                case "NodeExamination":

                    break;
                case "NodeTechnicalActivities":

                    break;
            }
         
    }
    }
}
