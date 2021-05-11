using DBSync.UC;
using DBSyncBL.RegKey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.ActionExplorer;

namespace DBSync
{
    public partial class frmPropertyWindow : ToolWindow
    {
        public UCRegKeySettings KeySettings { get => ucRegKeySettings; set => ucRegKeySettings = value; }

        public frmPropertyWindow()
        {
            InitializeComponent();
        }

        RegKyeDBSyncActionTreeNode _Properies;
        public void initPropery(string propName)
        {
            _Properies = new RegKyeDBSyncActionTreeNode();
            _Properies = RegKeySettings.getKeyProp(propName);
            if (_Properies.ActionProperties.Type == ViewModel.Enumeration.ActionPropertyEnums.type.ChiledNode)
            {
                ucRegKeySettings.PropertySettings.SelectedObject = _Properies;
            }
            if (_Properies.ActionProperties.Type == ViewModel.Enumeration.ActionPropertyEnums.type.LeafNode)
            {
                ucRegKeySettings.PropertySettings.SelectedObject = _Properies.ActionProperties;

                switch (propName)
                {
                    case "NodeDataSynchronization":

                        break;
                    case "NodePayments":

                        break;
                    case "NodeDirect":

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
                        frmActionExplorer.ActionDataSyncChangeAddress.ActionPropery = _Properies;
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
        public RegKyeDBSyncActionTreeNode Properies
        {
            get
            {
                return _Properies;
            }
            set
            {
                _Properies = value;
                ucRegKeySettings.PropertySettings.SelectedObject = _Properies.ActionProperties;

            }

        }
    }
}
