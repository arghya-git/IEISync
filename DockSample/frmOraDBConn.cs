using DBAdapter;
using DBAdapter.OraDBCon;
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
    public partial class frmOraDBConn : Form
    {
        public frmOraDBConn()
        {
            InitializeComponent();
            ucOraDbConn1.UiElement = this;
            ucOraDbConn1.Monitor = delegate () { fmrClose(); };
        }
       
        public void fmrClose()
        {
            if (Connection.State == DBAdapterEnums.state.connected)
            {
                this.Close();
            }
          
        }
    }
}
