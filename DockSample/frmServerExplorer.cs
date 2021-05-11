using DBAdapter;
using DBAdapter.OraDBCon;
using DBAdapter.SQLServerDBCon;
using ViewModel.Global;

namespace DBSync
{
    public partial class frmServerExplorer :  ToolWindow
    {
        public frmServerExplorer()
        {
            InitializeComponent();
            //AutoScaleMode = AutoScaleMode.Dpi;
            tvServerExplorer.ExpandAll();
            ConnectionObject();
        }
        public void ConnectionObject() {
           TSMIOraConnect.Enabled = DBAdapter.OraDBCon.Connection.State == DBAdapterEnums.state.connected ? false : true;
           TSMIOraDisconnect.Enabled = !(DBAdapter.OraDBCon.Connection.State == DBAdapterEnums.state.connected ? false : true);

            TSMISQLServerConnect.Enabled = DBAdapter.SQLServerDBCon.Connection.State == DBAdapterEnums.state.connected ? false : true;
            TSMISQLServerDisconnect.Enabled = !(DBAdapter.SQLServerDBCon.Connection.State == DBAdapterEnums.state.connected ? false : true);
        }
        private void linkLabel1_Click(object sender, System.EventArgs e)
        {
            frmDBConnect _frmDBConnect = new frmDBConnect();
            _frmDBConnect.ShowDialog();
        }

        private void tvServerExplorer_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // Select the clicked node
                tvServerExplorer.SelectedNode = tvServerExplorer.GetNodeAt(e.X, e.Y);

                if (tvServerExplorer.SelectedNode != null)
                {
                    if(tvServerExplorer.SelectedNode.Name == "NodeSQLServer")
                        CMSSQLServer.Show(tvServerExplorer, e.Location);
                    if (tvServerExplorer.SelectedNode.Name == "NodeOra")
                        CMSOracle.Show(tvServerExplorer, e.Location);
                }
            }
           
        }

        private void TSMIOraConnect_Click(object sender, System.EventArgs e)
        {
            frmOraDBConn obj = new frmOraDBConn();
            obj.ShowDialog();
        }

        private void TSMIOraDisconnect_Click(object sender, System.EventArgs e)
        {
            DBAdapter.OraDBCon.Connection.Disconnect();
            ConnectionObject();
            OutputProperties.BackColor = DBAdapter.OraDBCon.Connection.Status.Properties.LabelBackColor;
            OutputProperties.ForeColor = DBAdapter.OraDBCon.Connection.Status.Properties.LabelForeColor;
            OutputProperties.Text = DBAdapter.OraDBCon.Connection.Status.Properties.Label + " ";
            MainForm._OutputWindow.SetUPOutput(true);
        }

        private void TSMISQLServerConnect_Click(object sender, System.EventArgs e)
        {
            frmSqlServerConnect obj = new frmSqlServerConnect();
            obj.ShowDialog();
        }

        private void TSMISQLServerDisconnect_Click(object sender, System.EventArgs e)
        {
            DBAdapter.SQLServerDBCon.Connection.Disconnect();
            ConnectionObject();
            OutputProperties.BackColor = DBAdapter.SQLServerDBCon.Connection.Status.Properties.LabelBackColor;
            OutputProperties.ForeColor = DBAdapter.SQLServerDBCon.Connection.Status.Properties.LabelForeColor;
            OutputProperties.Text = DBAdapter.SQLServerDBCon.Connection.Status.Properties.Label + " ";
            MainForm._OutputWindow.SetDOWNOutput(true);
        }
    }
}
