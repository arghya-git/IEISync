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
    
    public partial class frmRegKeySettings : Form
    {
        TreeView _tvActionExplorer;
        public frmRegKeySettings()
        {
            InitializeComponent();
        }

        public TreeView TvActionExplorer { get => _tvActionExplorer; set => _tvActionExplorer = tvActionExplorer; }

        private void ucRegKeySettings1_Load(object sender, EventArgs e)
        {

        }

        private void tvActionExplorer_Click(object sender, MouseEventArgs e)
        {
            //if (tvActionExplorer.SelectedNode.Name == "NodeDirect")
            //{
            //    RegKyeDBSyncActionProperties obj = new RegKyeDBSyncActionProperties();
            //    obj.Name = "NodeDirect";
            //    ucRegKeySettings1.PropertySettings.SelectedObject = obj;


            //}
        }

        private void tvActionExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (tvActionExplorer.SelectedNode.Name == "NodeDirect")
            //{
                RegKyeDBSyncActionProperties obj = new RegKyeDBSyncActionProperties();
                obj.Name = tvActionExplorer.SelectedNode.Name;
                ucRegKeySettings.PropertySettings.SelectedObject = obj;
            //}
        }
    }
}
