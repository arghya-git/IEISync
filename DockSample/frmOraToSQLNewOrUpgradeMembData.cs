using DBAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.DataModel;
using WeifenLuo.WinFormsUI.Docking;

namespace DBSync
{
    public partial class frmOraToSQLNewOrUpgradeMembData : DockContent
    {
        public frmOraToSQLNewOrUpgradeMembData()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }
        public void MonitorChangeAddressDown()
        {
            //MainForm._OutputWindow.SetDOWNOutput(true);

            //dgvTotalCount.DataSource = ReturnSyncChangeAddress.DT_Total_Records;
            //dgvQueue.DataSource = ReturnSyncChangeAddress.DT_Queue;

            //try { lblTot.Text = ReturnMembSync.DT_Total_Records.ToString(); } catch { }
            try { lblQueue.Text = ReturnMembSync.DT_Queue.ToString(); } catch { }
            try { lblPrcessed.Text = ReturnMembSync.DT_Processed.ToString(); } catch { }
            //btProcessed.Text = "No. of Record(s) Processed: ";

        }

        public void doChangeAddressDown()
        {
            try { lblTot.Text = ReturnMembSync.DT_Total_Records.ToString(); } catch { }
            try { lblQueue.Text = ReturnMembSync.DT_Queue.ToString(); } catch { }
            try { lblPrcessed.Text = ReturnMembSync.DT_Processed.ToString(); } catch { }
            //MainForm._OutputWindow.SetDOWNOutput(true);
            //dgvTotalCount.DataSource = ReturnSyncChangeAddress.DT_Total_Records;
            //dgvQueue.DataSource = ReturnSyncChangeAddress.DT_Queue;
            //try { dgvProcessed.DataSource = (DataTable)JsonConvert.DeserializeObject(ReturnSyncChangeAddress.ST_Processed, (typeof(DataTable))); } catch { dgvProcessed.DataSource = null; }
            //try { btTotalCount.Text = "Total no. of Record(s) : " + ReturnSyncChangeAddress.DT_Total_Records.Rows.Count.ToString(); } catch { }
            //try { btQueue.Text = "No. of Record(s) in Queue: " + ReturnSyncChangeAddress.DT_Queue.Rows.Count.ToString(); } catch { }

            //btProcessed.Text = "No. of Record(s) Processed: ";
        }
        public void Start(Control UiElement)
        {
            if (DBAdapter.OraDBCon.Connection.State == DBAdapterEnums.state.connected && DBAdapter.SQLServerDBCon.Connection.State == DBAdapterEnums.state.connected)
            {

                try
                {
                    frmActionExplorer.ActionDataSyncMemberData.ActionPropery.SynchronizingObject = this;
                    frmActionExplorer.ActionDataSyncMemberData.ActionPropery.UiElement = UiElement;
                    frmActionExplorer.ActionDataSyncMemberData.ActionPropery.Monitor = delegate () { MonitorChangeAddressDown(); };
                    frmActionExplorer.ActionDataSyncMemberData.ActionPropery.DoWork = delegate () { doChangeAddressDown(); };
                    frmActionExplorer.ActionDataSyncMemberData.ActionPropery.intiTimer(true, UiElement);
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

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
