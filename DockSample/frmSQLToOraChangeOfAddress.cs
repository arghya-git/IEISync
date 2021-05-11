using DBAdapter;
using Newtonsoft.Json;
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
using ViewModel.DataModel;
using WeifenLuo.WinFormsUI.Docking;

namespace DBSync
{
    public partial class frmSQLToOraChangeOfAddress : DockContent
    {
        //ActionToolStrip _ActionDataSyncChangeAddress;
        //public ActionToolStrip ActionDataSyncChangeAddress { get => _ActionDataSyncChangeAddress; set => _ActionDataSyncChangeAddress = value; }
        public frmSQLToOraChangeOfAddress()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            //ActionDataSyncChangeAddress = new ActionToolStrip();

        }
        public void MonitorChangeAddressDown()
        {
            MainForm._OutputWindow.SetDOWNOutput(true);

            dgvTotalCount.DataSource = ReturnSyncChangeAddress.DT_Total_Records;
            dgvQueue.DataSource = ReturnSyncChangeAddress.DT_Queue;

            try { btTotalCount.Text = "Total no. of Record(s) : " + ReturnSyncChangeAddress.DT_Total_Records.Rows.Count.ToString(); } catch { }
            try { btQueue.Text = "No. of Record(s) in Queue: " + ReturnSyncChangeAddress.DT_Queue.Rows.Count.ToString(); } catch { }

            btProcessed.Text = "No. of Record(s) Processed: ";

        }

        public void doChangeAddressDown()
        {
            MainForm._OutputWindow.SetDOWNOutput(true);
            dgvTotalCount.DataSource = ReturnSyncChangeAddress.DT_Total_Records;
            dgvQueue.DataSource = ReturnSyncChangeAddress.DT_Queue;
            try { dgvProcessed.DataSource = (DataTable)JsonConvert.DeserializeObject(ReturnSyncChangeAddress.ST_Processed, (typeof(DataTable))); } catch { dgvProcessed.DataSource = null; }
            try { btTotalCount.Text = "Total no. of Record(s) : " + ReturnSyncChangeAddress.DT_Total_Records.Rows.Count.ToString(); } catch { }
            try { btQueue.Text = "No. of Record(s) in Queue: " + ReturnSyncChangeAddress.DT_Queue.Rows.Count.ToString(); } catch { }

            btProcessed.Text = "No. of Record(s) Processed: ";
        }
        public void Start(Control UiElement,string NodeName)
        {
            if (DBAdapter.OraDBCon.Connection.State == DBAdapterEnums.state.connected && DBAdapter.SQLServerDBCon.Connection.State == DBAdapterEnums.state.connected)
            {
                try
                {
                    frmActionExplorer.ActionDataSyncChangeAddress.ActionPropery.SynchronizingObject = this;
                    frmActionExplorer.ActionDataSyncChangeAddress.ActionPropery.UiElement = UiElement;
                    frmActionExplorer.ActionDataSyncChangeAddress.ActionPropery.Monitor = delegate () { MonitorChangeAddressDown(); };
                    frmActionExplorer.ActionDataSyncChangeAddress.ActionPropery.DoWork = delegate () { doChangeAddressDown(); };
                    frmActionExplorer.ActionDataSyncChangeAddress.ActionPropery.intiTimer(true, UiElement);
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

        private void btTotalCount_Click(object sender, EventArgs e)
        {
            splitContainerOne.Panel2Collapsed = true;

            btAll.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            btProcessed.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            btQueue.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            btTotalCount.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
        }

        private void btQueue_Click(object sender, EventArgs e)
        {
            splitContainerOne.Panel1Collapsed = true;
            splitContainerTwo.Panel2Collapsed = true;

            btAll.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            btProcessed.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            btQueue.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            btTotalCount.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
        }

        private void btProcessed_Click(object sender, EventArgs e)
        {
            splitContainerOne.Panel1Collapsed = true;
            splitContainerTwo.Panel1Collapsed = true;

            btAll.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            btProcessed.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            btQueue.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            btTotalCount.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
        }

        private void btAll_Click(object sender, EventArgs e)
        {
            splitContainerOne.Panel1Collapsed = false;
            splitContainerOne.Panel2Collapsed = false;
            splitContainerTwo.Panel1Collapsed = false;
            splitContainerTwo.Panel2Collapsed = false;

            btAll.Font= new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            btProcessed.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            btQueue.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
            btTotalCount.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
        }

        private void btAll_MouseHover(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (!bt.Font.Bold)
                bt.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
        }

        private void btAll_MouseLeave(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if(!bt.Font.Bold)
                bt.Font = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
        }
    }
}
