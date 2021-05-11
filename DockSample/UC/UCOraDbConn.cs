using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBAdapter.OraDBCon;
using ViewModel.Global;
using DBAdapter;

namespace DBSync.UC
{
    public partial class UCOraDbConn : UserControl
    {
        public void SafeInvoke(Action updater, Control UiElement, bool forceSynchronous)
        {

            if (UiElement == null)
            {
                throw new ArgumentNullException("uiElement");

            }

            if (UiElement.InvokeRequired)
            {
                if (forceSynchronous)
                {
                    UiElement.Invoke((Action)delegate { SafeInvoke(updater, UiElement, forceSynchronous); });
                }
                else
                {
                    UiElement.BeginInvoke((Action)delegate { SafeInvoke(updater, UiElement, forceSynchronous); });
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
        public UCOraDbConn()
        {
            InitializeComponent();
        }
        string host = String.Empty;
        string port = String.Empty;
        string servicename = String.Empty;
        string user = String.Empty;
        string pass = String.Empty;
        Action monitor;
        Control uiElement;
        public Action Monitor { get => monitor; set => monitor = value; }
        public Control UiElement { get => uiElement; set => uiElement = value; }
        public string Host { get => tbHost.Text; set => host = tbHost.Text; }
        public string Port { get => tbPort.Text; set => port = tbPort.Text; }

        public string Servicename { get => servicename = tbService.Text; set => servicename = tbService.Text; }
        public string User { get => tbOraUser.Text; set => user = tbOraUser.Text; }
        public string Pass { get => tbOraPassword.Text; set => pass = tbOraPassword.Text; }

        public void enabled(bool Flag)
        {
            btOraConn.Enabled = Flag;
            btOraTestConn.Enabled = Flag;
            tbHost.Enabled = Flag;
            tbService.Enabled = Flag;
            tbPort.Enabled = Flag;
            tbOraUser.Enabled = Flag;
            tbOraPassword.Enabled = Flag;
        }
        private void btOraConn_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                enabled(false);
                OraDBConnectProgressBar.Visible = true;
                Connection.Host = Host;
                Connection.Port = Port;
                Connection.Servicename = Servicename;
                Connection.User = User;
                Connection.Password = Pass;
                backgroundWorker1.RunWorkerAsync();
            }
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Connection.Connect(Host, Port, Servicename, User, Pass);
           
            Connection.Connect();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                
                OraDBConnectProgressBar.Visible = false;
                
                if (Connection.State == DBAdapterEnums.state.connected)
                {
                    OutputProperties.BackColor = Connection.Status.Properties.LabelBackColor;
                    OutputProperties.ForeColor = Connection.Status.Properties.LabelForeColor;
                    OutputProperties.Text = Connection.Status.Properties.Label + ": ";
                    MainForm._OutputWindow.SetUPOutput(false);

                    OutputProperties.BackColor = Connection.Status.Properties.ConnectionstringBackColor;
                    OutputProperties.ForeColor = Connection.Status.Properties.ConnectionstringColor;
                    OutputProperties.Text = Connection.ConnectionString + " ";
                    MainForm._OutputWindow.SetUPOutput(true);

                    MainForm._StartUp.ConnectionObject();
                    SafeInvoke(monitor, UiElement, true);
                    //((Form)this.TopLevelControl).Close();
                }
                else
                {
                    OutputProperties.BackColor = Connection.Status.Properties.TextBackColor;
                    OutputProperties.ForeColor = Connection.Status.Properties.TextForeColor;
                    OutputProperties.Text = Connection.Status.Properties.Text + ": ";
                    MainForm._OutputWindow.SetUPOutput(false);

                    OutputProperties.BackColor = Connection.Status.Properties.LabelBackColor;
                    OutputProperties.ForeColor = Connection.Status.Properties.LabelForeColor;
                    OutputProperties.Text = Connection.Status.Properties.Label + " ";
                    MainForm._OutputWindow.SetUPOutput(true);
                    enabled(true);
                }

            }
            
        }

        private void btOraTestConn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Connection.OraTestCon(Host, Port, Servicename, User, Pass));
        }
    }
}
