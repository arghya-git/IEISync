using DBAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ViewModel.Global;
using WeifenLuo.WinFormsUI.Docking;

namespace DBSync
{
    public partial class frmDBConnect : DockContent
    {
     
        public frmDBConnect()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            ucOraDbConn1.UiElement = this;
            ucOraDbConn1.Monitor = delegate () { fmrClose(); };

            ucSqlServerDbConn1.UiElement = this;
            ucSqlServerDbConn1.Monitor = delegate () { fmrClose(); };
        }

        public void fmrClose()
        {
            if (DBAdapter.OraDBCon.Connection.State == DBAdapterEnums.state.connected && DBAdapter.SQLServerDBCon.Connection.State == DBAdapterEnums.state.connected)
            {
                this.Close();
            }

        }





    }
}
