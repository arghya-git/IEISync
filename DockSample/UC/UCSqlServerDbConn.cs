using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBAdapter.SQLServerDBCon;
using ViewModel.Global;
using System.Data.Sql;
using System.Data.SqlClient;
using DBAdapter;

namespace DBSync.UC
{
    public partial class UCSqlServerDbConn : UserControl
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
        public UCSqlServerDbConn()
        {
            InitializeComponent();
            rbAuthenticationSql.Checked = true;
            tbSQLServerUser.Enabled = rbAuthenticationSql.Checked;
            tbSQLServerPassword.Enabled = rbAuthenticationSql.Checked;
        }

        Action monitor;
        Control uiElement;
        public Action Monitor { get => monitor; set => monitor = value; }
        public Control UiElement { get => uiElement; set => uiElement = value; }

        private void rbAuthenticationWin_CheckedChanged(object sender, EventArgs e)
        {
            tbSQLServerUser.Enabled = !rbAuthenticationWin.Checked;
            tbSQLServerPassword.Enabled = !rbAuthenticationWin.Checked;
        }

        private void btOraTestConn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Connection.OraTestCon(Host, Port, Servicename, User, Pass));
        }
        string server = String.Empty;
        string database = String.Empty;
        string user = String.Empty;
        string pass = String.Empty;

        public string Server { get => cbServers.Text; set => server = cbServers.Text; }
        public string Database { get => cbDataBase.Text; set => database = cbDataBase.Text; }
        public string User { get => tbSQLServerUser.Text; set => user = tbSQLServerUser.Text; }
        public string Pass { get => tbSQLServerPassword.Text; set => pass = tbSQLServerPassword.Text; }
       

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Connection.Connect();
        }

        private void btOraConn_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                Connection.Server = Server;
                Connection.Database = Database;
                Connection.AuthMode = Connection.AuthenticationMode.Server;
                Connection.User = User;
                Connection.Password = Pass;

                OraDBConnectProgressBar.Visible = true;

                backgroundWorker1.RunWorkerAsync();
            }
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
                    MainForm._OutputWindow.SetDOWNOutput(false);

                    OutputProperties.BackColor = Connection.Status.Properties.ConnectionstringBackColor;
                    OutputProperties.ForeColor = Connection.Status.Properties.ConnectionstringColor;
                    OutputProperties.Text = Connection.ConnectionString + " ";
                    MainForm._OutputWindow.SetDOWNOutput(true);

                    MainForm._StartUp.ConnectionObject();

                    SafeInvoke(monitor, UiElement, true);
                    //((Form)this.TopLevelControl).Close();
                }
                else
                {
                    OutputProperties.BackColor = Connection.Status.Properties.TextBackColor;
                    OutputProperties.ForeColor = Connection.Status.Properties.TextForeColor;
                    OutputProperties.Text = Connection.Status.Properties.Text + ": ";
                    MainForm._OutputWindow.SetDOWNOutput(false);

                    OutputProperties.BackColor = Connection.Status.Properties.LabelBackColor;
                    OutputProperties.ForeColor = Connection.Status.Properties.LabelForeColor;
                    OutputProperties.Text = Connection.Status.Properties.Label + " ";
                    MainForm._OutputWindow.SetDOWNOutput(true);
                    //Enabled(true);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OraDBConnectProgressBar.Visible = true;
                if (!bgwGetSrvers.IsBusy)
                {
                    bgwGetSrvers.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              
            }
           
        }
        DataTable servers;
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            servers = SqlDataSourceEnumerator.Instance.GetDataSources();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int i = 0; i < servers.Rows.Count; i++)
            {
                cbServers.Items.Add(servers.Rows[i]["ServerName"]);
                //cbServers.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
                //comboDB2Ser.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
            }
            //cbServers.SelectedIndex = 0;
            OraDBConnectProgressBar.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string dbConnectionString = "Data Source=" + Server + ";";
                dbConnectionString = dbConnectionString + " User ID=" + User + "; Password=" + Pass + ";";

                SqlConnection dbConnection = new SqlConnection(dbConnectionString);
                dbConnection.Open();
                DataTable DTdatabase = dbConnection.GetSchema("Databases");

                cbDataBase.DataSource = DTdatabase;
                cbDataBase.DisplayMember = "Database_Name";
                //cbDataBase.SelectedIndex = 0;
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
    }
}
