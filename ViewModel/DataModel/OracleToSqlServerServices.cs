
using DBAdapter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.DataModel.DataSynch.Membership;
using ViewModel.StoreProcedure.SQLServerSPs;
using ViewModel.VM.NewUpgradeMembersData;

namespace ViewModel.DataModel
{
    //public static class Ora2SqlProcessingMemb
    //{
    //    static List<IEI_TBL_PARTY_MASTER> _PARTY_MASTER_TOTAL_COUNT = new List<IEI_TBL_PARTY_MASTER>();

    //    static List<IEI_TBL_PARTY_MASTER> _PARTY_MASTER_QUEUE = new List<IEI_TBL_PARTY_MASTER>();

    //    static List<IEI_TBL_PARTY_MASTER> _PARTY_MASTER_PROCESSED = new List<IEI_TBL_PARTY_MASTER>();

    //    static List<IEI_TBL_PARTY_MASTER> _PARTY_MASTERS_CLOSE = new List<IEI_TBL_PARTY_MASTER>();

    //    public static List<IEI_TBL_PARTY_MASTER> PARTY_MASTERS_TOTAL_COUNT { get => _PARTY_MASTER_TOTAL_COUNT; set => _PARTY_MASTER_TOTAL_COUNT = value; }
    //    public static List<IEI_TBL_PARTY_MASTER> PARTY_MASTERS_CLOSE { get => _PARTY_MASTERS_CLOSE; set => _PARTY_MASTERS_CLOSE = value; }
    //    public static List<IEI_TBL_PARTY_MASTER> PARTY_MASTER_QUEUE { get => _PARTY_MASTER_QUEUE; set => _PARTY_MASTER_QUEUE = value; }
    //    public static List<IEI_TBL_PARTY_MASTER> PARTY_MASTER_PROCESSED { get => _PARTY_MASTER_PROCESSED; set => _PARTY_MASTER_PROCESSED = value; }
    //}

    public static class ReturnMembSync
    {
        static int _DT_Total_Records;
        static int _DT_Queue;
        static int _DT_Processed;

        static string _ST_Queue;
        static string _ST_Processed;
        public static int DT_Total_Records { get => _DT_Total_Records; set => _DT_Total_Records = value; }
        public static int DT_Queue { get => _DT_Queue; set => _DT_Queue = value; }
        public static int DT_Processed { get => _DT_Processed; set => _DT_Processed = value; }
        public static string ST_Queue { get => _ST_Queue; set => _ST_Queue = value; }
        public static string ST_Processed { get => _ST_Processed; set => _ST_Processed = value; }
    }
    public class OracleToSqlServerServices
    {
        private Action monitor;
        Control uiElement;
        string rootMembClose = string.Empty;

        public Control UiElement { get => uiElement; set => uiElement = value; }
        public Action Monitor { get => monitor; set => monitor = value; }


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

        DBAdapter.SQLServerDBCon.DbCon SQLCon;


        DBAdapter.OraDBCon.DbCon OraCon;
        string SQL = string.Empty;
        string TotalCount = string.Empty;
        public bool init()
        {
            if (DBAdapter.OraDBCon.Connection.State == DBAdapterEnums.state.connected && DBAdapter.SQLServerDBCon.Connection.State == DBAdapterEnums.state.connected)
            {
                try
                {
                  
                    OraCon = new DBAdapter.OraDBCon.DbCon();

                    OraCon.BeginTransaction();
                    //SQLCon.BeginTransaction();

                    SQL = string.Empty;

                    SQL = @"SELECT * FROM IEI_VIEW_PARTY_SYNC";
                    //SQLCon.Select = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBSelectResult>(DBAdapter.SQLServerDBCon.QueryType.SELECT, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);
                    OraCon.DbSelectDML = OraCon.OraDML<DBAdapter.OraDBCon.DBSelectResult>(DBAdapter.OraDBCon.QueryType.SELECT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);

                    ReturnMembSync.DT_Total_Records = OraCon.DbSelectDML.SELECT.ReaderDT.Rows.Count;
                    //SafeInvoke(monitor, UiElement, true);
                    OraCon.Commit();
                    //UiElement = ctrl;


                    return true;
                }
                catch
                {

                    return false;
                }
            }
            else
            {
                return false;

            }

           
        }
        List<VM_SP_IEI_TBL_PARTY_MASTER> _VM_SP_IEI_TBL_PARTY_MASTERs = new List<VM_SP_IEI_TBL_PARTY_MASTER>();
        public object BLOracle2SQLServerMembData { get; private set; }

        public void SynMembData(Action monitor, Control UiElement, int bufferSize)
        {
            try
            {
                bool COMMIT_FLG = false;

                SQLCon = new DBAdapter.SQLServerDBCon.DbCon();
                OraCon = new DBAdapter.OraDBCon.DbCon();

                OraCon.BeginTransaction();
                //SQLCon.BeginTransaction();

                SQL = string.Empty;

                SQL = @"SELECT * FROM IEI_VIEW_PARTY_SYNC WHERE ROWNUM <=" + 10.ToString();
                //SQLCon.Select = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBSelectResult>(DBAdapter.SQLServerDBCon.QueryType.SELECT, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);
                OraCon.DbSelectDML = OraCon.OraDML<DBAdapter.OraDBCon.DBSelectResult>(DBAdapter.OraDBCon.QueryType.SELECT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);

                ReturnMembSync.DT_Queue = OraCon.DbSelectDML.SELECT.ReaderDT.Rows.Count;
                SafeInvoke(monitor, UiElement, true);

               

                for (int i = 0; i < OraCon.DbSelectDML.SELECT.ReaderDT.Rows.Count; i++)
                {

                    DataRow row = OraCon.DbSelectDML.SELECT.ReaderDT.Rows[i];

                    Oracle2SQLServerMembData OBJ = new Oracle2SQLServerMembData();

                    VM_SP_IEI_TBL_PARTY_MASTER _VM_SP_IEI_TBL_PARTY_MASTER = new VM_SP_IEI_TBL_PARTY_MASTER();



                    try { _VM_SP_IEI_TBL_PARTY_MASTER.RECSLNO = row["RECSLNO"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.RECSLNO = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.OLDMEMBCODE = row["OLDMEMBCODE"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.OLDMEMBCODE = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.NEWMEMBCODE = row["NEWMEMBCODE"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.NEWMEMBCODE = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.PARTYCODE = row["PARTYCODE"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.PARTYCODE = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.MEMB_IDENTITY = row["MEMB_IDENTITY"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.MEMB_IDENTITY = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.LOGIN_ID = Convert.ToInt32(row["LOGIN_ID"].ToString()); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.LOGIN_ID = 0; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.PARTY_NAME = row["PARTY_NAME"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.PARTY_NAME = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.SALUTATION = row["SALUTATION"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.SALUTATION = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.SFX = row["SFX"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.SFX = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.ADD1 = row["ADD1"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.ADD1 = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.ADD2 = row["ADD2"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.ADD2 = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.ADD3 = row["ADD3"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.ADD3 = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.ADD4 = row["ADD4"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.ADD4 = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.ADD5 = row["ADD5"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.ADD5 = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.PIN = row["PIN"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.PIN = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.NATIONALITY = row["NATIONALITY"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.NATIONALITY = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.COUNTRY_RESIDENCE = row["COUNTRY_RESIDENCE"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.COUNTRY_RESIDENCE = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.GENDER = row["GENDER"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.GENDER = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.MOBILE = row["MOBILE"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.MOBILE = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.EMAIL = row["EMAIL"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.EMAIL = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.PHONE = row["PHONE"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.PHONE = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.DOB = Convert.ToDateTime(row["DOB"].ToString()); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.DOB = null; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.CENTRE = row["CENTRE"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.CENTRE = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.DIVISION = row["DIVISION"].ToString().Trim(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.DIVISION = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.SUBSCRIPTION_CATEGORY = row["SUBSCRIPTION_CATEGORY"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.SUBSCRIPTION_CATEGORY = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.ENROLEMENT_START_DT = Convert.ToDateTime(row["ENROLMENT_START_DATE"].ToString()); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.ENROLEMENT_START_DT = null; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.ENROLEMENT_END_DT = Convert.ToDateTime(row["ENROLMENT_END_DATE"].ToString()); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.ENROLEMENT_END_DT = null; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.SUBSCRIPTION_END_DT = Convert.ToDateTime(row["SUBSCRIPTION_END_DATE"].ToString()); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.SUBSCRIPTION_END_DT = null; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.MEMB_CATEGORY = row["MEMB_CATEGORY"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.MEMB_CATEGORY = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.REG_CAT = row["REG_CAT"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.REG_CAT = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.MEMB_TYPE = row["MEMB_TYPE"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.MEMB_TYPE = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.GENERATE_DATE = Convert.ToDateTime(row["GENERATE_DATE"]); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.GENERATE_DATE = null; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.UPLOAD_DATE = Convert.ToDateTime(row["UPLOAD_DATE"].ToString()); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.UPLOAD_DATE = null; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.WEB_UPDT_FLG = row["DOWNLOAD_FLAG"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.WEB_UPDT_FLG = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.CL = row["CL"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.CL = ""; }
                    try { _VM_SP_IEI_TBL_PARTY_MASTER.REMARKS = row["REMARKS"].ToString(); } catch { _VM_SP_IEI_TBL_PARTY_MASTER.REMARKS = ""; }


                    _VM_SP_IEI_TBL_PARTY_MASTERs.Add(_VM_SP_IEI_TBL_PARTY_MASTER);

                    SP_Sync_MembData_Result retObj = new SP_Sync_MembData_Result();

                    retObj = OBJ.SyncMembdata(_VM_SP_IEI_TBL_PARTY_MASTER);

                    //SQL = "UPDATE PARTYMAST SET WEB_UPDT_FLG = '" + retObj.WEB_UPDT_FLG + "' WHERE PARTYCODE='" + retObj.PARTYCODE + "'";
                    SQL = "UPDATE TBL_MEMBER_MASTER SET WEB_UPDN_FLAG = '" + retObj.WEB_UPDT_FLG + "' WHERE MEMBCODE='" + retObj.PARTYCODE + "'";
                    //SQL = "UPDATE PARTYMAST SET WEB_UPDT_FLG = 'Z' WHERE PARTYCODE='" + retObj.PARTYCODE + "'";
                    OraCon.DbUpdateDML = OraCon.OraDML<DBAdapter.OraDBCon.DBUpdateResult>(DBAdapter.OraDBCon.QueryType.UPDATE, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);

                    ReturnMembSync.DT_Processed = _VM_SP_IEI_TBL_PARTY_MASTERs.Count;
                    SafeInvoke(monitor, UiElement, true);
                }

                OraCon.Commit();
            }
            catch (Exception ex)
            {
                OraCon.Rollback();
            }
        }
    }
}
