using DBAdapter;
using DBAdapter.SQLServerDBCon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSync
{
    public partial class frmSqlServerConnect : Form
    {
        public frmSqlServerConnect()
        {
            InitializeComponent();
            ucSqlServerDbConn1.UiElement = this;
            ucSqlServerDbConn1.Monitor = delegate () { fmrClose(); };
           
        }
        public void fmrClose()
        {
            if (Connection.State == DBAdapterEnums.state.connected)
            {
                this.Close();
            }
        }

        private void ucSqlServerDbConn1_Load(object sender, EventArgs e)
        {

        }
    }
}
