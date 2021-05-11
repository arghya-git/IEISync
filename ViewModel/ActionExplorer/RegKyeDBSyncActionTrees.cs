using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.DataModel;
using ViewModel.Interfaces;

namespace ViewModel.ActionExplorer
{
    //public class Schedule { }
    public class RegKyeDBSyncActionTreeNode : IRegKyeDBSyncActionTrees
    {
        public string Name { get; set; }
        public string Type { get; set; }

        //[TypeConverter(typeof(ExpandableObjectConverter))]
        public RegKyeDBSyncActionProperties ActionProperties { get; set; }


        Control uiElement;

        public Control UiElement { get => uiElement; set => uiElement = value; }
        ISynchronizeInvoke synchronizingObject = new Control();
        public ISynchronizeInvoke SynchronizingObject { get => synchronizingObject; set => synchronizingObject = value; }
        public void SafeInvoke(Action updater, bool forceSynchronous)
        {

            if (UiElement == null)
            {
                throw new ArgumentNullException("uiElement");

            }

            if (UiElement.InvokeRequired)
            {
                if (forceSynchronous)
                {
                    UiElement.Invoke((Action)delegate { SafeInvoke(updater, forceSynchronous); });
                }
                else
                {
                    UiElement.BeginInvoke((Action)delegate { SafeInvoke(updater, forceSynchronous); });
                }

            }
            else
            {
                if (UiElement.IsDisposed)
                {
                    throw new ObjectDisposedException("Control is already disposed.");
                }

                updater();

            }

        }
        SqlServerToOracleServices SQL2OraObj;
        OracleToSqlServerServices Ora2SQLObj;

        public RegKyeDBSyncActionTreeNode()
        {
            Timer = new System.Timers.Timer();

            SQL2OraObj = new SqlServerToOracleServices();
            Ora2SQLObj = new OracleToSqlServerServices();
        }
        public void intiTimer(bool enabled, Control ctrl)
        {

            uiElement = ctrl;
            bgWorker = new BackgroundWorker();
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGW_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_RunWorkerCompleted);
            //this.Timer.SynchronizingObject = synchronizingObject;
            this.Timer.Interval = this.ActionProperties.Schedule.Interval;
            this.Timer.Elapsed += new System.Timers.ElapsedEventHandler(this.ServiceTimer_Tick);
            this.Timer.Enabled = enabled;
            doWorkFlag = enabled;
        }
        public System.Timers.Timer Timer { get; set; }

        private Action monitor;
        public Action Monitor { get => monitor; set => monitor = value; }

        private Action doWork;
        public Action DoWork { get => doWork; set => doWork = value; }
        public bool DoWorkFlag { get => doWorkFlag; set => doWorkFlag = value; }

        bool doWorkFlag = false;
        private void ServiceTimer_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            //bool flg = false;
            //SafeInvoke(monitor, true);
            if (doWorkFlag)
            {
                if (!bgWorker.IsBusy)
                {
                    Timer.Stop();
                    bgWorker.RunWorkerAsync();
                }
            }

        }


        private System.ComponentModel.BackgroundWorker bgWorker;

        private void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            ActionProperties.Schedule.CurrentState = true;
            Timer.Stop();
            try
            {

                if (this.Name == "NodeChangeAddress")
                {
                    Ora2SQLObj.UiElement = uiElement;
                    Ora2SQLObj.Monitor = DoWork;
                    
                    if(SQL2OraObj.init("ADDRESSCHANGE"))
                    {
                        SQL2OraObj.SyncChangeAddress(DoWork, uiElement, ActionProperties.Buffer);
                    }
                }
                if (this.Name == "NodeDirect")
                {
                    Ora2SQLObj.UiElement = uiElement;
                    Ora2SQLObj.Monitor = DoWork;
                    if (SQL2OraObj.init("PAYMENTDIRECT"))
                    {
                        SQL2OraObj.SyncPaymentDirect(DoWork, uiElement, ActionProperties.Buffer);

                    }
                }
                if (this.Name == "NodeMemberData")
                {
                    SQL2OraObj.UiElement = uiElement;
                    SQL2OraObj.Monitor = DoWork;
                    if (Ora2SQLObj.init())
                    {

                        Ora2SQLObj.SynMembData(DoWork, uiElement, ActionProperties.Buffer);
                    }
                    else
                    {

                    }
                }
            }
            catch
            {
                //throw ex;
                Timer.Start();
            }
        }
        private void BGW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Action Monitor = delegate () { monitor(); };

        }

        private void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Timer.Start();
            ActionProperties.Schedule.CurrentState = false;
        }

    }
}
