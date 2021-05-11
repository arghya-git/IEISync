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
    public partial class fromSQLToOraPayment : DockContent
    {
        public fromSQLToOraPayment()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }

        //public void MonitorChangeAddressDown()
        //{
        //    //MainForm._OutputWindow.SetDOWNOutput(true);

        //    //dgvTotalCount.DataSource = ReturnSyncChangeAddress.DT_Total_Records;
        //    //dgvQueue.DataSource = ReturnSyncChangeAddress.DT_Queue;

        //    //try { btTotalCount.Text = "Total no. of Record(s) : " + ReturnSyncChangeAddress.DT_Total_Records.Rows.Count.ToString(); } catch { }
        //    //try { btQueue.Text = "No. of Record(s) in Queue: " + ReturnSyncChangeAddress.DT_Queue.Rows.Count.ToString(); } catch { }

        //    //btProcessed.Text = "No. of Record(s) Processed: ";

        //}
        //public void doChangeAddressDown()
        //{
        //    //MainForm._OutputWindow.SetDOWNOutput(true);
        //    //dgvTotalCount.DataSource = ReturnSyncChangeAddress.DT_Total_Records;
        //    //dgvQueue.DataSource = ReturnSyncChangeAddress.DT_Queue;
        //    //try { dgvProcessed.DataSource = (DataTable)JsonConvert.DeserializeObject(ReturnSyncChangeAddress.ST_Processed, (typeof(DataTable))); } catch { dgvProcessed.DataSource = null; }
        //    //try { btTotalCount.Text = "Total no. of Record(s) : " + ReturnSyncChangeAddress.DT_Total_Records.Rows.Count.ToString(); } catch { }
        //    //try { btQueue.Text = "No. of Record(s) in Queue: " + ReturnSyncChangeAddress.DT_Queue.Rows.Count.ToString(); } catch { }

        //    //btProcessed.Text = "No. of Record(s) Processed: ";
        //}
        public void MonitorDirectPaymentDown()
        {
            TotalProcessed.Text= ReturnSyncPaymenyDirect.ST_Processed.ToString()+ "/" + ReturnSyncPaymenyDirect.ST_Queue.ToString();
            progressBar1.Maximum = ReturnSyncPaymenyDirect.ST_Queue;
            progressBar1.Value = ReturnSyncPaymenyDirect.ST_Processed;
        }
        public void doDirectPaymentDown()
        {
            TotalProcessed.Text = ReturnSyncPaymenyDirect.ST_Processed.ToString() + "/" + ReturnSyncPaymenyDirect.ST_Queue.ToString();
            progressBar1.Maximum = ReturnSyncPaymenyDirect.ST_Queue;
            progressBar1.Value = ReturnSyncPaymenyDirect.ST_Processed;
            dgbCAtt.DataSource = ReturnSyncPaymenyDirect.DT_Current_Duplicate;
            dgbTAtt.DataSource = ReturnSyncPaymenyDirect.DT_Total_Duplicate;
            dgvProcessing.DataSource = ReturnSyncPaymenyDirect.VIEW_PAYMENT_SYNC;
        }

        public void Start(Control UiElement, string NodeName)
        {
            if (DBAdapter.OraDBCon.Connection.State == DBAdapterEnums.state.connected && DBAdapter.SQLServerDBCon.Connection.State == DBAdapterEnums.state.connected)
            {
                try
                {
                    //if (NodeName == "NodeChangeAddress")
                    //{
                    //    frmActionExplorer.ActionDataSyncChangeAddress.ActionPropery.SynchronizingObject = this;
                    //    frmActionExplorer.ActionDataSyncChangeAddress.ActionPropery.UiElement = UiElement;
                    //    frmActionExplorer.ActionDataSyncChangeAddress.ActionPropery.Monitor = delegate () { MonitorChangeAddressDown(); };
                    //    frmActionExplorer.ActionDataSyncChangeAddress.ActionPropery.DoWork = delegate () { doChangeAddressDown(); };
                    //    frmActionExplorer.ActionDataSyncChangeAddress.ActionPropery.intiTimer(true, UiElement);
                    //}
                    if (NodeName == "NodeDirect")
                    {
                        frmActionExplorer.ActionDataSyncPaymentDirect.ActionPropery.SynchronizingObject = this;
                        frmActionExplorer.ActionDataSyncPaymentDirect.ActionPropery.UiElement = UiElement;
                        frmActionExplorer.ActionDataSyncPaymentDirect.ActionPropery.Monitor = delegate () { MonitorDirectPaymentDown(); };
                        frmActionExplorer.ActionDataSyncPaymentDirect.ActionPropery.DoWork = delegate () { doDirectPaymentDown(); };
                        frmActionExplorer.ActionDataSyncPaymentDirect.ActionPropery.intiTimer(true, UiElement);
                    }
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
    }
 
}
