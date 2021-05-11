using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViewModel.Tables.SQLServerTables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ViewModel.Tables.OracleTables;
using System.Windows.Forms;
using ViewModel.Global;
using DBAdapter.OraDBCon;
using DBAdapter.SQLServerDBCon;
using System.Drawing;
using System.IO;
using ReadWriteJson;
using DBAdapter;

namespace ViewModel.DataModel
{
    public static class ProcessingMemb
    {
        static List<IEI_TBL_PARTY_MASTER> _PARTY_MASTER_TOTAL_COUNT = new List<IEI_TBL_PARTY_MASTER>();

        static List<IEI_TBL_PARTY_MASTER> _PARTY_MASTER_QUEUE = new List<IEI_TBL_PARTY_MASTER>();

        static List<IEI_TBL_PARTY_MASTER> _PARTY_MASTER_PROCESSED = new List<IEI_TBL_PARTY_MASTER>();

        static List<IEI_TBL_PARTY_MASTER> _PARTY_MASTERS_CLOSE = new List<IEI_TBL_PARTY_MASTER>();

        public static List<IEI_TBL_PARTY_MASTER> PARTY_MASTERS_TOTAL_COUNT { get => _PARTY_MASTER_TOTAL_COUNT; set => _PARTY_MASTER_TOTAL_COUNT = value; }
        public static List<IEI_TBL_PARTY_MASTER> PARTY_MASTERS_CLOSE { get => _PARTY_MASTERS_CLOSE; set => _PARTY_MASTERS_CLOSE = value; }
        public static List<IEI_TBL_PARTY_MASTER> PARTY_MASTER_QUEUE { get => _PARTY_MASTER_QUEUE; set => _PARTY_MASTER_QUEUE = value; }
        public static List<IEI_TBL_PARTY_MASTER> PARTY_MASTER_PROCESSED { get => _PARTY_MASTER_PROCESSED; set => _PARTY_MASTER_PROCESSED = value; }
    }

    public static class ReturnSyncChangeAddress
    {
        static DataTable _DT_Total_Records;
        static DataTable _DT_Queue;
        static DataTable _DT_Processed;

        static string _ST_Queue;
        static string _ST_Processed;
        public static DataTable DT_Total_Records { get => _DT_Total_Records; set => _DT_Total_Records = value; }
        public static DataTable DT_Queue { get => _DT_Queue; set => _DT_Queue = value; }
        public static DataTable DT_Processed { get => _DT_Processed; set => _DT_Processed = value; }
        public static string ST_Queue { get => _ST_Queue; set => _ST_Queue = value; }
        public static string ST_Processed { get => _ST_Processed; set => _ST_Processed = value; }
    }

    public class ReturnSyncPaymenyDirect
    {
        //static DataTable _DT_Total_Records;
        //static DataTable _DT_Queue;
        //static DataTable _DT_Processed;

        static int _ST_Queue = 0;
        static int _ST_Processed = 0;
        //public static DataTable DT_Total_Records { get => _DT_Total_Records; set => _DT_Total_Records = value; }
        //public static DataTable DT_Queue { get => _DT_Queue; set => _DT_Queue = value; }
        //public static DataTable DT_Processed { get => _DT_Processed; set => _DT_Processed = value; }
        public static int ST_Queue { get => _ST_Queue; set => _ST_Queue = value; }
        public static int ST_Processed { get => _ST_Processed; set => _ST_Processed = value; }

        public static List<IEI_VIEW_PAYMENT_SYNC> DT_Current_Duplicate { get; set; }

        public static DataTable DT_Total_Duplicate { get; set; }

        public static List<IEI_VIEW_PAYMENT_SYNC> VIEW_PAYMENT_SYNC { get; set; }

        public ReturnSyncPaymenyDirect() {
            VIEW_PAYMENT_SYNC = new List<IEI_VIEW_PAYMENT_SYNC>();
        }

    }
    public class SqlServerToOracleServices
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

        public SqlServerToOracleServices()
        {
            int i = 0;

            do
            {
                i++;

                rootMembClose = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName + @"\JSonFiles\OraMembClose" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + i.ToString() + ".json";

            } while (File.Exists(rootMembClose));
        }
        public bool init(string ActionFor)
        {
            if (ActionFor == "ADDRESSCHANGE")
            {
                return initAddressChange();
            }
            else if (ActionFor == "PAYMENTDIRECT")
            {
                return initPaymentDirect();
            }
            else
            {
                return false;
            }
        }
        class TEMPCNT
        {
            public string RECSLNO;
            public int CNT;
        }


        #region Payment Direct Block
        private bool initPaymentDirect()
        {
            if (DBAdapter.OraDBCon.Connection.State == DBAdapterEnums.state.connected && DBAdapter.SQLServerDBCon.Connection.State == DBAdapterEnums.state.connected)
            {
                try
                {
                    SQLCon = new DBAdapter.SQLServerDBCon.DbCon();

                    SQL = "SELECT RECSLNO,COUNT(*) CNT FROM [WEBIEI].[dbo].[IEI_VIEW_PAYMENT_SYNC] GROUP BY RECSLNO";
                    SQLCon.Select = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBSelectResult>(DBAdapter.SQLServerDBCon.QueryType.SELECT, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);

                    var temp = JsonConvert.SerializeObject(SQLCon.Select.SELECT.ReaderDT);
                    List<TEMPCNT> cnt = JsonConvert.DeserializeObject<List<TEMPCNT>>(temp);
                    int count = cnt.ToList().Sum(q => q.CNT);
                    if (Convert.ToInt32(SQLCon.Select.SELECT.ReaderDT.Rows[0]["CNT"]) > 0)
                    {
                        //SQL = @"SELECT * FROM [WEBIEI].[dbo].[IEI_TBL_PARTY_MASTER] WHERE [DOWNLOAD_FLAG]='T'  AND CL='N'";
                        //SQLCon.Select = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBSelectResult>(DBAdapter.SQLServerDBCon.QueryType.SELECT, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);
                        ReturnSyncPaymenyDirect.DT_Current_Duplicate = new List<IEI_VIEW_PAYMENT_SYNC>();
                        TotalCount = SQLCon.Select.SELECT.ReaderDT.Rows.Count.ToString();

                        //ReturnSyncPaymenyDirect.ST_Queue = Convert.ToInt32(TotalCount);

                        //SafeInvoke(Monitor, UiElement, true);
                    }
                    //UiElement = ctrl;


                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
            else
            {
                return false;

            }
        }

        public void SyncPaymentDirect(Action monitor, Control UiElement, int bufferSize)
        {
            bool COMMIT_FLG = false;
            bufferSize = 1;
            try { int validCheck = bufferSize; } catch { bufferSize = 1; }

            SQLCon = new DBAdapter.SQLServerDBCon.DbCon();
            OraCon = new DBAdapter.OraDBCon.DbCon();

            OraCon.BeginTransaction();
            SQLCon.BeginTransaction();

            SQL = string.Empty;
            string TEMP_APO_FLG = string.Empty;

            SQL = "SELECT RECSLNO,COUNT(*) CNT FROM [WEBIEI].[dbo].[IEI_VIEW_PAYMENT_SYNC] GROUP BY RECSLNO";
            SQLCon.Select = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBSelectResult>(DBAdapter.SQLServerDBCon.QueryType.SELECT, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);

            var temp = JsonConvert.SerializeObject(SQLCon.Select.SELECT.ReaderDT);
            List<TEMPCNT> cnt = JsonConvert.DeserializeObject<List<TEMPCNT>>(temp);
            int count = cnt.ToList().Sum(q => q.CNT);

            SQL = "SELECT * FROM IEI_TBL_PAYMENT_REF WHERE IS_DOWNLOAD='B'";
            SQLCon.Select = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBSelectResult>(DBAdapter.SQLServerDBCon.QueryType.SELECT, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);

            ReturnSyncPaymenyDirect.DT_Total_Duplicate = SQLCon.Select.SELECT.ReaderDT;


            if (Convert.ToInt32(ReturnSyncPaymenyDirect.ST_Queue) < count)
            {
                ReturnSyncPaymenyDirect.ST_Queue = count;
                ReturnSyncPaymenyDirect.ST_Processed = 0;
            }

            if (ReturnSyncPaymenyDirect.ST_Processed == ReturnSyncPaymenyDirect.ST_Queue)
            {
                ReturnSyncPaymenyDirect.ST_Queue += count;
                //ReturnSyncPaymenyDirect.ST_Processed = 0;
            }
           
            if (count > 0)
            {
                bool alreadyInserted = false;
                //#endregion
                try
                {

                    OutputProperties.BackColor = Color.Empty;
                    OutputProperties.ForeColor = Color.Black;
                    OutputProperties.Text = "SELECT * FROM [WEBIEI].[dbo].[IEI_VIEW_PAYMENT_SYNC]";
                    SafeInvoke(monitor, UiElement, true);
                    if (count < bufferSize)
                        bufferSize = count;

                    SQL = @"SELECT top " + bufferSize + @"[RECSLNO_MODIFIED],
                               [RECSLNO]
                              ,[ORDER_ID]
                              ,[SERVICE_CODE]
                              ,[SER_DESC]
                              ,[MEMBCODE]
                              ,[SER_TYPE]
                              ,[FUNC_DESC]
                              ,[SER_DESC_TYPE]
                              ,[RATE]
                              ,[COUNTRY_TYPE]
                              ,[TAX_ID]
                              ,[NAME]
                              ,[ADD1]
                              ,[ADD2]
                              ,[ADD3]
                              ,[ADD4]
                              ,[ADD5]
                              ,[COUNTRY_RESIDENCE]
                              ,[NATIONALITY]
                              ,[COUNTRY_CODE]
                              ,[PIN]
                              ,[MOB]
                              ,[EMAIL]
                              ,[IS_DOWNLOAD]
                              ,[PAY_STATUS]
                              ,[PAY_DATE]
                              ,[PAYMENT_GATEWAY]
                          FROM [WEBIEI].[dbo].[IEI_VIEW_PAYMENT_SYNC] order by [PAY_DATE]";
                    SQLCon.Select = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBSelectResult>(DBAdapter.SQLServerDBCon.QueryType.SELECT, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);


                    var temp2 = JsonConvert.SerializeObject(SQLCon.Select.SELECT.ReaderDT);
                    List<IEI_VIEW_PAYMENT_SYNC> _VIEW_PAYMENT_SYNC = JsonConvert.DeserializeObject<List<IEI_VIEW_PAYMENT_SYNC>>(temp2);




                    COMMIT_FLG = true;
                    //bool DuplicateFlag = false;
                    int c = SQLCon.Select.SELECT.ReaderDT.Rows.Count;

                    string inClause = "'";

                    int i = 0;
                    ReturnSyncPaymenyDirect.VIEW_PAYMENT_SYNC = new List<IEI_VIEW_PAYMENT_SYNC>();
                    

                    foreach (IEI_VIEW_PAYMENT_SYNC _SQL_PAYMENT_SYNC in _VIEW_PAYMENT_SYNC)
                    {
                        i++;

                        ReturnSyncPaymenyDirect.VIEW_PAYMENT_SYNC.Add(_SQL_PAYMENT_SYNC);

                      


                        string ADD1 = _SQL_PAYMENT_SYNC.ADD1 != null ? _SQL_PAYMENT_SYNC.ADD1.Replace("'", "`").Substring(0, _SQL_PAYMENT_SYNC.ADD1.Length < 40 ? _SQL_PAYMENT_SYNC.ADD1.Length : 39) : "";
                        string ADD2 = _SQL_PAYMENT_SYNC.ADD2 != null ? _SQL_PAYMENT_SYNC.ADD2.Replace("'", "`").Substring(0, _SQL_PAYMENT_SYNC.ADD2.Length < 40 ? _SQL_PAYMENT_SYNC.ADD2.Length : 39) : "";         // ADD2
                        string ADD3 = _SQL_PAYMENT_SYNC.ADD3 != null ? _SQL_PAYMENT_SYNC.ADD3.Replace("'", "`").Substring(0, _SQL_PAYMENT_SYNC.ADD3.Length < 40 ? _SQL_PAYMENT_SYNC.ADD3.Length : 39) : "";         // ADD3
                        string ADD4 = _SQL_PAYMENT_SYNC.ADD4 != null ? _SQL_PAYMENT_SYNC.ADD4.Replace("'", "`").Substring(0, _SQL_PAYMENT_SYNC.ADD4.Length < 40 ? _SQL_PAYMENT_SYNC.ADD4.Length : 39) : "";         // ADD4
                        string ADD5 = _SQL_PAYMENT_SYNC.ADD5 != null ? _SQL_PAYMENT_SYNC.ADD5.Replace("'", "`").Substring(0, _SQL_PAYMENT_SYNC.ADD5.Length < 40 ? _SQL_PAYMENT_SYNC.ADD5.Length : 39) : "";

                        string EMAIL = _SQL_PAYMENT_SYNC.EMAIL != null ? _SQL_PAYMENT_SYNC.EMAIL.ToLower() : "";
                        string NAME = _SQL_PAYMENT_SYNC.NAME != null ? _SQL_PAYMENT_SYNC.NAME.Replace("'", "`").Substring(0, _SQL_PAYMENT_SYNC.NAME.Length < 40 ? _SQL_PAYMENT_SYNC.NAME.Length : 39) : "";

                        



                        SQL = @"select IN_CD1 from web_vs_in_servicemast where CODE='" + _SQL_PAYMENT_SYNC.SERVICE_CODE + "' and nvl(IN_CD1,0) <> 0";
                        OraCon.DbSelectDML = OraCon.OraDML<DBAdapter.OraDBCon.DBSelectResult>(DBAdapter.OraDBCon.QueryType.SELECT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);


                        string IN_SERVICE_CODE = OraCon.DbSelectDML.SELECT.ReaderDT.Rows[0]["IN_CD1"].ToString();

                        //SQL = "'";

                        //for (int __Dup = 0; __Dup < cnt1[0].CNT; __Dup++)
                        //{

                        //}
                            string PREVREFNO = _SQL_PAYMENT_SYNC.RECSLNO;

                        //inClause = inClause + PREVREFNO + (__Dup < cnt1[0].CNT ? "','":"'");

                        //inClause = inClause + PREVREFNO + (i < bufferSize ? "','" : "'");

                        inClause =  PREVREFNO ;
                        //_SQL_PAYMENT_SYNC.RECSLNO = _SQL_PAYMENT_SYNC.RECSLNO.Substring(0, 11) + __Dup.ToString();
                        SQL = @"SELECT COUNT(*) CNT FROM  tbl_document WHERE REFNO='" + _SQL_PAYMENT_SYNC.RECSLNO + "'";

                        OraCon.DbSelectDML = OraCon.OraDML<DBAdapter.OraDBCon.DBSelectResult>(DBAdapter.OraDBCon.QueryType.SELECT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);

                        DataRow rowCNT = OraCon.DbSelectDML.SELECT.ReaderDT.Rows[0];
                        var CNT = rowCNT["CNT"].ToString();



                        if (Convert.ToInt32(CNT) == 0)
                        {
                            #region INSERT INTO IEINDIA.TBL_PAYMENT_SYNC
                            SQL = @"INSERT INTO IEINDIA.TBL_PAYMENT_SYNC(REFNO,
                                                                         PREVREFNO,
                                                                         ORDER_ID,
                                                                         WEB_SERVICE_CODE,
                                                                         IN_SERVICE_CODE,
                                                                         WEB_SER_DESC,
                                                                         IN_SER_DESC,
                                                                         MEMBCODE,
                                                                         WEB_SER_TYPE,
                                                                         WEB_FUNC_DESC,
                                                                         WEB_SER_DESC_TYPE,
                                                                         RATE,
                                                                         COUNTRY_TYPE,
                                                                         WEB_TAX_ID,
                                                                         USER_NAME,
                                                                         ADD1,
                                                                         ADD2,
                                                                         ADD3,
                                                                         ADD4,
                                                                         ADD5,
                                                                         COUNTRY_RESIDENCE,
                                                                         NATIONALITY,
                                                                         COUNTRY_CODE,
                                                                         PIN,
                                                                         MOB,
                                                                         EMAIL,
                                                                         DOUNLOAD_TYPE,
                                                                         IS_PROCESSED_FLAG,
                                                                         PAY_DATE,
                                                                         PAY_STATUS,
                                                                         PAYMENT_GATEWAY) VALUES ('" +
                                                                      _SQL_PAYMENT_SYNC.RECSLNO_MODIFIED + "','" +                                // REFNO
                                                                      PREVREFNO + "','" +                                                // PREVREFNO
                                                                      _SQL_PAYMENT_SYNC.ORDER_ID + "','" +                               // ORDER_ID
                                                                      _SQL_PAYMENT_SYNC.SERVICE_CODE + "','" +                           // WEB_SERVICE_CODE
                                                                      IN_SERVICE_CODE + "','" +                                          // IN_SERVICE_CODE
                                                                      _SQL_PAYMENT_SYNC.SER_DESC + "','" +                               // WEB_SER_DESC
                                                                      _SQL_PAYMENT_SYNC.SER_DESC + "','" +                               // IN_SER_DESC
                                                                      _SQL_PAYMENT_SYNC.MEMBCODE + "','" +                               // MEMBCODE
                                                                      _SQL_PAYMENT_SYNC.SER_TYPE + "','" +                               // WEB_SER_TYPE
                                                                      _SQL_PAYMENT_SYNC.FUNC_DESC + "','" +                              // WEB_FUNC_DESC
                                                                      _SQL_PAYMENT_SYNC.SER_DESC_TYPE + "','" +                          // WEB_SER_DESC_TYPE
                                                                      _SQL_PAYMENT_SYNC.RATE + "','" +                                   // RATE
                                                                      _SQL_PAYMENT_SYNC.COUNTRY_TYPE + "','" +                           // COUNTRY_TYPE
                                                                      _SQL_PAYMENT_SYNC.TAX_ID + "','" +                                 // WEB_TAX_ID
                                                                      NAME + "','" +                                   // USER_NAME
                                                                      ADD1 + "','" +         // ADD1
                                                                      ADD2 + "','" +         // ADD2
                                                                      ADD3 + "','" +         // ADD3
                                                                      ADD4 + "','" +         // ADD4
                                                                      ADD5 + "','" +         // ADD5
                                                                      _SQL_PAYMENT_SYNC.COUNTRY_RESIDENCE + "','" +                      // COUNTRY_RESIDENCE
                                                                      _SQL_PAYMENT_SYNC.NATIONALITY + "','" +                            // NATIONALITY
                                                                      _SQL_PAYMENT_SYNC.COUNTRY_CODE + "','" +                           // COUNTRY_CODE
                                                                      _SQL_PAYMENT_SYNC.PIN + "','" +                                    // PIN
                                                                      _SQL_PAYMENT_SYNC.MOB + "','" +                                    // MOB
                                                                      _SQL_PAYMENT_SYNC.EMAIL + "','" +                                  // EMAIL
                                                                      "DIRECT" + "','" +                                                 // DOUNLOAD_TYPE
                                                                      "N" + "',TO_DATE('" +                                              // IS_PROCESSED_FLAG
                                                                      _SQL_PAYMENT_SYNC.PAY_DATE.Day.ToString().PadLeft(2, '0') +
                                                                      "/" + _SQL_PAYMENT_SYNC.PAY_DATE.Month.ToString().PadLeft(2, '0')
                                                                      + "/" + _SQL_PAYMENT_SYNC.PAY_DATE.Year + "','dd/mm/yyyy'),'" +      // PAY_DATE
                                                                      _SQL_PAYMENT_SYNC.PAY_STATUS + "','" +                             // PAY_STATUS
                                                                      _SQL_PAYMENT_SYNC.PAYMENT_GATEWAY + "'" +                          // PAYMENT_GATEWAY
                                                                      ")";

                            OraCon.DbInsertDML = OraCon.OraDML<DBAdapter.OraDBCon.DBInsertResult>(DBAdapter.OraDBCon.QueryType.INSERT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);
                            #endregion

                            COMMIT_FLG = COMMIT_FLG && !OraCon.DbInsertDML.INSERT.OraErrFlg && (OraCon.DbInsertDML.INSERT.Count == 1);
                            if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                            {
                                MessageBox.Show("IEINDIA.TBL_PAYMENT_SYNC");
                            }
                            if (!OraCon.DbInsertDML.INSERT.OraErrFlg)
                            {
                                SQL = @"SELECT SEQ_CHQGROUPID.NEXTVAL SEQ_CHQGROUPID FROM DUAL";

                                OraCon.DbSelectDML = OraCon.OraDML<DBAdapter.OraDBCon.DBSelectResult>(DBAdapter.OraDBCon.QueryType.SELECT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);
                                DataRow row = OraCon.DbSelectDML.SELECT.ReaderDT.Rows[0];
                                var SEQ_CHQGROUPID = row["SEQ_CHQGROUPID"].ToString();




                                //if (Convert.ToInt32(CNT) == 0)
                                //{
                                SQL = @"SELECT COUNT(*) CNT FROM TBL_DOCNO_HD WHERE YR=TO_CHAR(SYSDATE,'YY') AND TYPE1='010'";
                                OraCon.DbSelectDML = OraCon.OraDML<DBAdapter.OraDBCon.DBSelectResult>(DBAdapter.OraDBCon.QueryType.SELECT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);

                                DataRow rowDOCNO_HD = OraCon.DbSelectDML.SELECT.ReaderDT.Rows[0];
                                var CNTDOCNO_HD = rowDOCNO_HD["CNT"].ToString();

                                if (Convert.ToInt32(CNTDOCNO_HD) == 0)
                                {
                                    #region INSERT INTO TBL_DOCNO_HD
                                    SQL = @"INSERT INTO TBL_DOCNO_HD (DOCLOT,TYPE1,YR,GENDT,FROMNUMBER,TONUMBER) 
                                            VALUES(SEQ_DOCNO_LOT.NEXT,'010',TO_CHAR(SYSDATE,'YY'),TRUNC(SYSDATE),1,999999)";
                                    OraCon.DbInsertDML = OraCon.OraDML<DBAdapter.OraDBCon.DBInsertResult>(DBAdapter.OraDBCon.QueryType.INSERT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);
                                    #endregion

                                    COMMIT_FLG = COMMIT_FLG && !OraCon.DbInsertDML.INSERT.OraErrFlg && (OraCon.DbInsertDML.INSERT.Count == 1);
                                    if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                                    {
                                        MessageBox.Show("INSERT INTO TBL_DOCNO_HD");
                                    }
                                }
                                if (!OraCon.DbInsertDML.INSERT.OraErrFlg)
                                {
                                    #region INSERT INTO TBL_DOCNO_DTLS

                                    //SQL = @" MERGE INTO TBL_DOCNO_DTLS s1 
                                    //         USING (select DOCLOT,TYPE1 FROM TBL_DOCNO_HD  
                                    //         WHERE YR=TO_CHAR(SYSDATE,'YY') AND TYPE1='010')
                                    //         s2 ON(s1.DOCNUMBER = '"+ _SQL_PAYMENT_SYNC.RECSLNO_MODIFIED + @"')
                                    //         WHEN NOT MATCHED THEN INSERT(DOCLOT,TYPE1,CREATEDT,DOCNUMBER) 
                                    //         values ( s2.DOCLOT,s2.TYPE1,SYSDATE,'"+ _SQL_PAYMENT_SYNC.RECSLNO_MODIFIED + "')";
                                    SQL = @"INSERT INTO TBL_DOCNO_DTLS (DOCLOT,TYPE1,CREATEDT,DOCNUMBER)
                                        (SELECT DOCLOT,TYPE1,SYSDATE,'" + _SQL_PAYMENT_SYNC.RECSLNO_MODIFIED + "' FROM TBL_DOCNO_HD WHERE YR=TO_CHAR(SYSDATE,'YY') AND TYPE1='010')";
                                    OraCon.DbInsertDML = OraCon.OraDML<DBAdapter.OraDBCon.DBInsertResult>(DBAdapter.OraDBCon.QueryType.INSERT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);
                                    #endregion

                                    COMMIT_FLG = COMMIT_FLG && !OraCon.DbInsertDML.INSERT.OraErrFlg && (OraCon.DbInsertDML.INSERT.Count == 1);
                                    if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                                    {
                                        MessageBox.Show("INSERT INTO TBL_DOCNO_DTLS");
                                    }
                                    if (!OraCon.DbInsertDML.INSERT.OraErrFlg)
                                    {
                                        #region insert into TBL_CHEQUEHD
                                        SQL = @"insert into TBL_CHEQUEHD (
                                                                                CHQIDGRP,
                                                                                SYSDT,
                                                                                CREATEDT,
                                                                                UPDATEDT
                                                                             ) VALUES
                                                                             (" + SEQ_CHQGROUPID + "," +  // CHQIDGRP
                                                                            "SYSDATE" + "," +        // SYSDT
                                                                            "SYSDATE" + "," +        // CREATEDT
                                                                            "SYSDATE" +              // UPDATEDT
                                                                         ")";

                                        OraCon.DbInsertDML = OraCon.OraDML<DBAdapter.OraDBCon.DBInsertResult>(DBAdapter.OraDBCon.QueryType.INSERT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);
                                        #endregion

                                        COMMIT_FLG = COMMIT_FLG && !OraCon.DbInsertDML.INSERT.OraErrFlg && (OraCon.DbInsertDML.INSERT.Count == 1);
                                        if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                                        {
                                            MessageBox.Show("INSERT INTO TBL_CHEQUEHD");
                                        }
                                        if (!OraCon.DbInsertDML.INSERT.OraErrFlg)
                                        {
                                            #region insert into TBL_CHEQUE_DTL
                                            SQL = @"insert into TBL_CHEQUE_DTL (CHQID,
                                                                                  CHQNO,
                                                                                  CHQDT,
                                                                                  AMT,
                                                                                  CURRTYPE,
                                                                                  CHQDOCNO,
                                                                                  PAYTYPEID,
                                                                                  ONLINEORDERID,
                                                                                  ISSUEBANK,
                                                                                  REALIZEBANK,
                                                                                  PAYINSLIPSTATUS,
                                                                                  CREATEDT,
                                                                                  IPADD,
                                                                                  UPDATEUSR,
                                                                                  UPDATEDT,
                                                                                  CHQIDGRP,
                                                                                  SYSDT,
                                                                                  CREATEUSR,
                                                                                  CHECKLIST_STAT
                                                                                 ) VALUES
                                                                                 (SEQ_CHEQUEID.NEXTVAL,'" +             // CHQID
                                                                                  _SQL_PAYMENT_SYNC.ORDER_ID + "'," +    // CHQNO
                                                                                  "TO_DATE('" +
                                                                                    _SQL_PAYMENT_SYNC.PAY_DATE.Day.ToString().PadLeft(2, '0') +
                                                                                    "/" + _SQL_PAYMENT_SYNC.PAY_DATE.Month.ToString().PadLeft(2, '0') +
                                                                                    "/" + _SQL_PAYMENT_SYNC.PAY_DATE.Year + "','dd/mm/yyyy')" + ",'" +   // CHQDT
                                                                                  _SQL_PAYMENT_SYNC.RATE + "'," +       // AMT
                                                                                  "1" + ",'" +                          // CURRTYPE
                                                                                  _SQL_PAYMENT_SYNC.RECSLNO_MODIFIED + "','" +   // CHQDOCNO
                                                                                  "WEB" + "','" +                       // PAYTYPEID
                                                                                  "" + "'," +                           // ONLINEORDERID
                                                                                  _SQL_PAYMENT_SYNC.ISSUEBANK + ",'" +  // ISSUEBANK
                                                                                  "" + "','" +                          // REALIZEBANK
                                                                                  "N" + "'," +                          // PAYINSLIPSTATUS
                                                                                  "SYSDATE" + ",'" +                    // CREATEDT
                                                                                  "" + "','" +                          // IPADD
                                                                                  "" + "'," +                           // UPDATEUSR
                                                                                  "SYSDATE" + "," +                     // UPDATEDT
                                                                                  SEQ_CHQGROUPID + "," +                // CHQIDGRP
                                                                                  "SYSDATE" + ",'" +                    // SYSDT
                                                                                  "" + "','" +                          // CREATEUSR
                                                                                  "W" + "'" +                            // CHECKLIST_STAT
                                                                                  ")";


                                            OraCon.DbInsertDML = OraCon.OraDML<DBAdapter.OraDBCon.DBInsertResult>(DBAdapter.OraDBCon.QueryType.INSERT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);
                                            #endregion

                                            COMMIT_FLG = COMMIT_FLG && !OraCon.DbInsertDML.INSERT.OraErrFlg && (OraCon.DbInsertDML.INSERT.Count == 1);
                                            if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                                            {
                                                MessageBox.Show("INSERT INTO TBL_CHEQUE_DTL");
                                            }
                                            if (!OraCon.DbInsertDML.INSERT.OraErrFlg)
                                            {
                                                SQL = @"select FN_GET_WEB_PAYMENT_GST_STATE ('" + _SQL_PAYMENT_SYNC.RECSLNO + "') SERV_LOC_CD  from dual";
                                                OraCon.DbSelectDML = OraCon.OraDML<DBAdapter.OraDBCon.DBSelectResult>(DBAdapter.OraDBCon.QueryType.SELECT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);

                                                DataRow rowSERV_LOC_CD = OraCon.DbSelectDML.SELECT.ReaderDT.Rows[0];
                                                var SERV_LOC_CD = rowSERV_LOC_CD["SERV_LOC_CD"].ToString();

                                                SQL = @"select ACTION_TYPE from VW_SERVICE_RATE where scode='" + IN_SERVICE_CODE + "'";
                                                OraCon.DbSelectDML = OraCon.OraDML<DBAdapter.OraDBCon.DBSelectResult>(DBAdapter.OraDBCon.QueryType.SELECT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);

                                                DataRow rowACTION_TYPE = OraCon.DbSelectDML.SELECT.ReaderDT.Rows[0];
                                                var ACTION_TYPE = rowACTION_TYPE["ACTION_TYPE"].ToString();

                                                #region insert into tbl_document
                                                SQL = @"insert into tbl_document (
                                                                                  REFNO,
                                                                                  MEMBCODE,
                                                                                  NAME,
                                                                                  ADD1,
                                                                                  ADD2,
                                                                                  ADD3,
                                                                                  ADD4,
                                                                                  ADD5,
                                                                                  PIN,
                                                                                  DOCDT,
                                                                                  DOCPAYTYPE,
                                                                                  SERVICEPAYTYPE,
                                                                                  PREVREFNO,
                                                                                  RECVCAT,
                                                                                  EXTERNALREF,
                                                                                  EXTERNALVENDOR,
                                                                                  EXTREFDT,
                                                                                  DIRECTION,
                                                                                  PSCODE,
                                                                                  IPADD,
                                                                                  CREATEUSR,
                                                                                  CREATEDT,
                                                                                  UPDATEDT,
                                                                                  UPDATEUSR,
                                                                                  SYSDT,
                                                                                  EMAIL,
                                                                                  MOBILE,
                                                                                  CUST_TYPE,
                                                                                  GSTIN,
                                                                                  CATEGORY,
                                                                                  SERV_LOC_CD,
                                                                                  AMT,
                                                                                  AMT_STAT,
                                                                                  CHQIDGRP,
                                                                                  CENTRECODE,
                                                                                  SMS_STAT,
                                                                                  EMAIL_STAT,
                                                                                  CHECKLIST_STAT,
                                                                                  MIGRATION_STAT
                                                                             ) VALUES
                                                                             ('" + _SQL_PAYMENT_SYNC.RECSLNO_MODIFIED + "','" +      // REFNO
                                                                                       _SQL_PAYMENT_SYNC.MEMBCODE + "','" +     // MEMBCODE
                                                                                       NAME + "','" +         // NAME
                                                                                       ADD1 + "','" +         // ADD1
                                                                                       ADD2 + "','" +         // ADD2
                                                                                       ADD3 + "','" +         // ADD3
                                                                                       ADD4 + "','" +         // ADD4
                                                                                       ADD5 + "','" +         // ADD5
                                                                                       _SQL_PAYMENT_SYNC.PIN + "'," +           // PIN
                                                                                       "TRUNC(SYSDATE)" + ",'" +                       // DOCDT
                                                                                       "PAY" + "','" +                          // DOCPAYTYPE
                                                                                       ACTION_TYPE + "','" +    // SERVICEPAYTYPE
                                                                                       _SQL_PAYMENT_SYNC.RECSLNO + "','" +                      // PREVREFNO
                                                                                       "BYWEB" + "','" +                        // RECVCAT
                                                                                       "" + "','" +                             // EXTERNALREF
                                                                                       "" + "','" +                             // EXTERNALVENDOR
                                                                                       "" + "','" +                             // EXTREFDT
                                                                                       "INWARD" + "','" +                       // DIRECTION
                                                                                       IN_SERVICE_CODE + "','" + // PSCODE
                                                                                       "" + "','" +                             // IPADD
                                                                                       "" + "'," +                              // CREATEUSR
                                                                                       "SYSDATE" + ",'" +                       // CREATEDT
                                                                                        "" + "','" +                            // UPDATEDT
                                                                                       "" + "'," +                              // UPDATEUSR
                                                                                       "SYSDATE" + ",'" +                       // SYSDT
                                                                                       EMAIL + "','" +        // EMAIL
                                                                                       _SQL_PAYMENT_SYNC.MOB + "','" +          // MOBILE
                                                                                       "B2C" + "','" +                          // CUST_TYPE
                                                                                       "" + "','" +                             // GSTIN
                                                                                       "SDSP" + "','" +                         // CATEGORY
                                                                                       SERV_LOC_CD + "','" +                     // SERV_LOC_CD
                                                                                       _SQL_PAYMENT_SYNC.RATE + "','" +         // AMT
                                                                                       "F" + "','" +                            // AMT_STAT
                                                                                       SEQ_CHQGROUPID + "','" +                 // CHQIDGRP
                                                                                        "000" + "','" +                         // CENTRECODE
                                                                                       "F" + "','" +                            // SMS_STAT
                                                                                       "F" + "','" +                            // EMAIL_STAT
                                                                                       "W" + "','" +                            // CHECKLIST_STAT
                                                                                       "N" + "'" +                              // MIGRATION_STAT
                                                                                 ")";

                                                OraCon.DbInsertDML = OraCon.OraDML<DBAdapter.OraDBCon.DBInsertResult>(DBAdapter.OraDBCon.QueryType.INSERT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);
                                                #endregion
                                                if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                                                {
                                                    MessageBox.Show("INSERT INTO TBL_DOCUMENT");
                                                }
                                                COMMIT_FLG = COMMIT_FLG && !OraCon.DbInsertDML.INSERT.OraErrFlg && (OraCon.DbInsertDML.INSERT.Count == 1);

                                                if (!OraCon.DbInsertDML.INSERT.OraErrFlg)
                                                {
                                                    SQL = @"SELECT * FROM [dbo].[IEI_TBL_PAYMENT_VS_SERVICE] WHERE RECSLNO='" + _SQL_PAYMENT_SYNC.RECSLNO + "'";

                                                    SQLCon.Select = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBSelectResult>(DBAdapter.SQLServerDBCon.QueryType.SELECT, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);


                                                    var tempPAYMENT_VS_SERVICE = JsonConvert.SerializeObject(SQLCon.Select.SELECT.ReaderDT);
                                                    List<IEI_TBL_PAYMENT_VS_SERVICE> _PAYMENT_VS_SERVICE = JsonConvert.DeserializeObject<List<IEI_TBL_PAYMENT_VS_SERVICE>>(tempPAYMENT_VS_SERVICE);

                                                    foreach (var __PAYMENT_VS_SERVICE in _PAYMENT_VS_SERVICE)
                                                    {

                                                        SQL = @"SELECT SEQ_DOC_VS_SERVICE.NEXTVAL SERVICEREFNO FROM DUAL";


                                                        OraCon.DbSelectDML = OraCon.OraDML<DBAdapter.OraDBCon.DBSelectResult>(DBAdapter.OraDBCon.QueryType.SELECT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);

                                                        DataRow rowSERVICEREFNO = OraCon.DbSelectDML.SELECT.ReaderDT.Rows[0];
                                                        var SERVICEREFNO = rowSERVICEREFNO["SERVICEREFNO"].ToString();


                                                        SQL = @"select IN_CD1 from web_vs_in_servicemast where CODE='" + __PAYMENT_VS_SERVICE.SERVICE_CODE + "' and nvl(IN_CD1,0) <> 0";
                                                        OraCon.DbSelectDML = OraCon.OraDML<DBAdapter.OraDBCon.DBSelectResult>(DBAdapter.OraDBCon.QueryType.SELECT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);


                                                        string IN_PAYMENT_VS_SERVICE_CODE = OraCon.DbSelectDML.SELECT.ReaderDT.Rows[0]["IN_CD1"].ToString();


                                                        #region INSERT INTO TBL_PAYMENT_VS_SCODE_SYNC
                                                        SQL = @"INSERT INTO TBL_PAYMENT_VS_SCODE_SYNC(REFNO,SCODE,INSCODE) VALUES('" + _SQL_PAYMENT_SYNC.RECSLNO + "','" + _SQL_PAYMENT_SYNC.SERVICE_CODE + "','" + IN_PAYMENT_VS_SERVICE_CODE + "')";

                                                        OraCon.DbInsertDML = OraCon.OraDML<DBAdapter.OraDBCon.DBInsertResult>(DBAdapter.OraDBCon.QueryType.INSERT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);
                                                        #endregion
                                                        if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                                                        {
                                                            MessageBox.Show("INSERT INTO TBL_PAYMENT_VS_SCODE_SYNC");
                                                        }
                                                        if (!OraCon.DbInsertDML.INSERT.OraErrFlg)
                                                        {
                                                            COMMIT_FLG = COMMIT_FLG && !OraCon.DbInsertDML.INSERT.OraErrFlg && (OraCon.DbInsertDML.INSERT.Count == 1);

                                                            #region INSERT INTO IEINDIA.TBL_DOC_VS_SERVICE
                                                            SQL = @"INSERT INTO IEINDIA.TBL_DOC_VS_SERVICE
                                                        (
                                                          SERVICEREFNO,
                                                          REFNO,
                                                          SCODE,                                                        
                                                          CREATEDT,                                                        
                                                          SYSDT,
                                                          IGST,
                                                          CGST,
                                                          SGST,
                                                          QUANTITY,
                                                          GST_APP_TAG,
                                                          SERV_STAT,
                                                          ALERT_FLG,
                                                          APP_PROC_FLG
                                                        )
                                                        ( SELECT '" +
                                                                                     SERVICEREFNO + "','" + //  SERVICEREFNO,
                                                                                     _SQL_PAYMENT_SYNC.RECSLNO_MODIFIED + "','" + //REFNO,
                                                                                     IN_PAYMENT_VS_SERVICE_CODE + "'," +  //SCODE,
                                                                                      "TRUNC(SYSDATE)" + "," + //CREATEDT,
                                                                                     "SYSDATE" + "," +                          //SYSDT,
                                                                                     "IGST" + "," +                             //IGST,
                                                                                     "CGST" + "," +                             //CGST,
                                                                                      "SGST" + "," +                            //SGST,
                                                                                      "1" + "," +                             //QUANTITY,
                                                                                     "GST_APP_TAG" + "," +                      //GST_APP_TAG,
                                                                                     "'N'" + "," +                                //SERV_STAT,
                                                                                     "'N'" + "," +                                //ALERT_FLG,
                                                                                     "'N'" + "" +                                //APP_PROC_FLG,
                                                            "FROM VW_SERVICE_RATE WHERE SCODE='" + IN_PAYMENT_VS_SERVICE_CODE + "')";

                                                            OraCon.DbInsertDML = OraCon.OraDML<DBAdapter.OraDBCon.DBInsertResult>(DBAdapter.OraDBCon.QueryType.INSERT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);
                                                            #endregion
                                                            if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                                                            {
                                                                MessageBox.Show("INSERT INTO TBL_DOC_VS_SERVICE");
                                                            }
                                                            COMMIT_FLG = COMMIT_FLG && !OraCon.DbInsertDML.INSERT.OraErrFlg && (OraCon.DbInsertDML.INSERT.Count == 1);

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        //}

                                    }

                                }

                            }
                        }
                        else
                        {
                            //COMMIT_FLG = COMMIT_FLG && false;
                            alreadyInserted = true;
                            SQL = @"UPDATE [dbo].[IEI_TBL_PAYMENT_REF] SET IS_DOWNLOAD='B' WHERE RECSLNO ='" + _SQL_PAYMENT_SYNC.RECSLNO + "' AND IS_DOWNLOAD='Y'";

                            SQLCon.Update = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBUpdateResult>(DBAdapter.SQLServerDBCon.QueryType.UPDATE, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);

                            ReturnSyncPaymenyDirect.DT_Current_Duplicate.Add(_SQL_PAYMENT_SYNC);

                            //ReturnSyncPaymenyDirect.DT_Total_Duplicate.Add(_SQL_PAYMENT_SYNC);
                            //if (!SQLCon.Update.UPDATE.OraErrFlg)
                            //{
                            COMMIT_FLG = COMMIT_FLG && !SQLCon.Update.UPDATE.OraErrFlg && (SQLCon.Update.UPDATE.Count == 1);

                            //}
                        }
                       
                        
                       

                    }

                    SQL = @"UPDATE [dbo].[IEI_TBL_PAYMENT_REF] SET IS_DOWNLOAD='N' WHERE RECSLNO IN('" + inClause + "') AND IS_DOWNLOAD='Y'";

                    SQLCon.Update = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBUpdateResult>(DBAdapter.SQLServerDBCon.QueryType.UPDATE, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);


                    if (!SQLCon.Update.UPDATE.OraErrFlg)
                    {
                        if (SQLCon.Update.UPDATE.Count == bufferSize)
                        {
                            COMMIT_FLG = COMMIT_FLG && true;
                        }
                        else
                        {
                            if (alreadyInserted)
                            {
                                COMMIT_FLG = COMMIT_FLG && alreadyInserted;



                                alreadyInserted = false;
                            }
                            else
                            {
                                COMMIT_FLG = COMMIT_FLG && false;
                                if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                                {
                                    MessageBox.Show("SQLCon.Update.UPDATE.Count == bufferSize");
                                }
                            }
                        }
                    }
                    else
                    {
                        COMMIT_FLG = COMMIT_FLG && false;

                        if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                        {
                            MessageBox.Show("UPDATE [dbo].[IEI_TBL_PAYMENT_REF]");
                        }
                    }

                    if (COMMIT_FLG == true)
                    {
                        try
                        {
                            SQLCon.Commit();
                        }
                        catch (Exception ex)
                        {
                            OraCon.Rollback();

                            if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                        try
                        {
                            OraCon.Commit();
                            ReturnSyncPaymenyDirect.ST_Processed += bufferSize;


                            SafeInvoke(monitor, UiElement, true);

                        }
                        catch (Exception ex)
                        {
                            SQLCon = new DBAdapter.SQLServerDBCon.DbCon();
                            SQLCon.BeginTransaction();
                            SQL = @"UPDATE [dbo].[IEI_TBL_PAYMENT_REF] SET IS_DOWNLOAD='Y' WHERE RECSLNO IN(" + inClause + ") AND IS_DOWNLOAD='R'";
                            SQLCon.Update = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBUpdateResult>(DBAdapter.SQLServerDBCon.QueryType.UPDATE, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);
                            SQLCon.Commit();

                            if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                    }
                    else
                    {
                        SQLCon.Rollback();
                        OraCon.Rollback();

                    }
                }
                catch (Exception ex)
                {
                    COMMIT_FLG = false;

                    OutputProperties.BackColor = Color.Empty;
                    OutputProperties.ForeColor = Color.Red;
                    OutputProperties.Text = ex.Message;
                    OraCon.Rollback();
                    SQLCon.Rollback();
                    //if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                    //{
                    MessageBox.Show(ex.Message);
                    //}
                    throw new Exception(ex.Message);
                }
                finally
                {
                    //if (ProcessingMemb.PARTY_MASTERS_CLOSE.Count != 0)
                    //{
                    //    Json json = new Json();
                    //    json.Write(rootMembClose, JsonConvert.SerializeObject(ProcessingMemb.PARTY_MASTERS_CLOSE));
                    //}

                }

            }
            else
            {

                SQLCon.Rollback();
                OraCon.Rollback();

                SafeInvoke(monitor, UiElement, true);

                if (OraCon.DbInsertDML.INSERT.OraErrFlg)
                {
                    MessageBox.Show("SELECT RECSLNO,COUNT(*) CNT FROM [WEBIEI].[dbo].[IEI_VIEW_PAYMENT_SYNC] GROUP BY RECSLNO : CNT=0");
                }
            }
        }

        #endregion



        #region Address Change Block
        private bool initAddressChange()
        {
            if (DBAdapter.OraDBCon.Connection.State == DBAdapterEnums.state.connected && DBAdapter.SQLServerDBCon.Connection.State == DBAdapterEnums.state.connected)
            {
                try
                {
                    SQLCon = new DBAdapter.SQLServerDBCon.DbCon();

                    SQL = "SELECT COUNT(*) CNT FROM [WEBIEI].[dbo].[IEI_TBL_PARTY_MASTER] WHERE [DOWNLOAD_FLAG]='T'  AND CL='N'";
                    SQLCon.Select = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBSelectResult>(DBAdapter.SQLServerDBCon.QueryType.SELECT, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);


                    if (Convert.ToInt32(SQLCon.Select.SELECT.ReaderDT.Rows[0]["CNT"]) != 0)
                    {
                        SQL = @"SELECT * FROM [WEBIEI].[dbo].[IEI_TBL_PARTY_MASTER] WHERE [DOWNLOAD_FLAG]='T'  AND CL='N'";
                        SQLCon.Select = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBSelectResult>(DBAdapter.SQLServerDBCon.QueryType.SELECT, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);

                        TotalCount = SQLCon.Select.SELECT.ReaderDT.Rows.Count.ToString();

                        ReturnSyncChangeAddress.DT_Total_Records = SQLCon.Select.SELECT.ReaderDT;

                        //SafeInvoke(Monitor, UiElement, true);
                    }
                    //UiElement = ctrl;


                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
            else
            {
                return false;

            }
        }
        public void SyncChangeAddress(Action monitor, Control UiElement, int bufferSize)
        {
            bool COMMIT_FLG = false;
            bufferSize = 10;
            SQLCon = new DBAdapter.SQLServerDBCon.DbCon();
            OraCon = new DBAdapter.OraDBCon.DbCon();

            OraCon.BeginTransaction();
            SQLCon.BeginTransaction();

            SQL = string.Empty;
            string TEMP_APO_FLG = string.Empty;
            SQL = "SELECT COUNT(*) CNT FROM [WEBIEI].[dbo].[IEI_TBL_PARTY_MASTER] WHERE [DOWNLOAD_FLAG]='T'  AND CL='N'";
            SQLCon.Select = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBSelectResult>(DBAdapter.SQLServerDBCon.QueryType.SELECT, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);

            //ReturnSyncChangeAddress.DT_Total_Records = SQLCon.Select.SELECT.ReaderDT;

            #region select IEI_TBL_PARTY_MASTER
            int count = Convert.ToInt32(SQLCon.Select.SELECT.ReaderDT.Rows[0]["CNT"]);
            if (count != 0)
            {
                #endregion
                try
                {

                    OutputProperties.BackColor = Color.Empty;
                    OutputProperties.ForeColor = Color.Black;
                    OutputProperties.Text = "SELECT * FROM [WEBIEI].[dbo].[IEI_TBL_PARTY_MASTER] WHERE [DOWNLOAD_FLAG]='T'  AND CL='N'";
                    SafeInvoke(monitor, UiElement, true);
                    if (count < bufferSize)
                        bufferSize = count;
                    //SQL = @"SELECT top " + bufferSize + @"[PARTYCODE],[MEMB_IDENTITY],[LOGIN_ID],[PARTY_NAME],[SALUTATION],[SFX],[ADD1],[ADD2],[ADD3],[ADD4],[ADD5],[PIN],[NATIONALITY],[COUNTRY_RESIDENCE],
                    //        [GENDER],[MOBILE],[EMAIL],[PHONE],[DOB],[CENTRE],[DIVISION],[SUBSCRIPTION_CATEGORY],[ENROLEMENT_START_DT],[ENROLEMENT_END_DT],[SUBSCRIPTION_END_DT],[MEMB_CATEGORY],
                    //        [MEMB_TYPE],[GENERATE_DATE],[UPLOAD_DATE],[DOWNLOAD_FLAG],[CL],[REMARKS],CONVERT(VARCHAR,[ADD_CHANGE_DATE],103) AS ADD_CHANGE_DATE 
                    //        FROM [WEBIEI].[dbo].[IEI_TBL_PARTY_MASTER] WHERE [DOWNLOAD_FLAG]='T'  AND CL='N'";// need to reviced
                    SQL = @"SELECT top " + bufferSize + @"[PARTYCODE],[MEMB_IDENTITY],[LOGIN_ID],[PARTY_NAME],[SALUTATION],[SFX],[ADD1],[ADD2],[ADD3],[ADD4],[ADD5],[PIN],[NATIONALITY],[COUNTRY_RESIDENCE],[WEBIEI].[dbo].[IEI_TBL_COUNTRY_MAST].CNAME AS COUNTRY_NAME,
                            [GENDER],[MOBILE],[EMAIL],[PHONE],[DOB],[CENTRE],[DIVISION],[SUBSCRIPTION_CATEGORY],[ENROLEMENT_START_DT],[ENROLEMENT_END_DT],[SUBSCRIPTION_END_DT],[MEMB_CATEGORY],
                            [MEMB_TYPE],[GENERATE_DATE],[UPLOAD_DATE],[DOWNLOAD_FLAG],[CL],[REMARKS],CONVERT(VARCHAR,[ADD_CHANGE_DATE],103) AS ADD_CHANGE_DATE 
                            FROM [WEBIEI].[dbo].[IEI_TBL_PARTY_MASTER] LEFT OUTER JOIN [WEBIEI].[dbo].[IEI_TBL_COUNTRY_MAST]  ON
                            [WEBIEI].[dbo].[IEI_TBL_PARTY_MASTER].COUNTRY_RESIDENCE=[WEBIEI].[dbo].[IEI_TBL_COUNTRY_MAST].COUNTRY_CODE WHERE [DOWNLOAD_FLAG]='T'  AND CL='N'";
                    SQLCon.Select = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBSelectResult>(DBAdapter.SQLServerDBCon.QueryType.SELECT, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);

                    ReturnSyncChangeAddress.DT_Queue = SQLCon.Select.SELECT.ReaderDT;



                    //OutputProperties.BackColor = Color.Empty;
                    //OutputProperties.ForeColor = Color.Black;
                    //OutputProperties.Text = SQLCon.Select.SELECT.ReaderDT.Rows.Count.ToString() + "/" + TotalCount.ToString();
                    SafeInvoke(monitor, UiElement, true);




                    COMMIT_FLG = false;

                    for (int i = 0; i < SQLCon.Select.SELECT.ReaderDT.Rows.Count; i++)
                    {

                        DataRow row = SQLCon.Select.SELECT.ReaderDT.Rows[i];


                        IEI_TBL_PARTY_MASTER _SQL_PARTY_MASTER = new IEI_TBL_PARTY_MASTER();

                        try { _SQL_PARTY_MASTER.PARTYCODE = row["PARTYCODE"].ToString(); } catch { _SQL_PARTY_MASTER.PARTYCODE = ""; }
                        try { _SQL_PARTY_MASTER.MEMB_IDENTITY = row["MEMB_IDENTITY"].ToString(); } catch { _SQL_PARTY_MASTER.MEMB_IDENTITY = ""; }
                        try { _SQL_PARTY_MASTER.LOGIN_ID = Convert.ToInt32(row["LOGIN_ID"].ToString()); } catch { _SQL_PARTY_MASTER.LOGIN_ID = 0; }
                        try { _SQL_PARTY_MASTER.PARTY_NAME = row["PARTY_NAME"].ToString().Replace('\'', '`'); } catch { _SQL_PARTY_MASTER.PARTY_NAME = ""; }
                        try { _SQL_PARTY_MASTER.SALUTATION = row["SALUTATION"].ToString(); } catch { _SQL_PARTY_MASTER.SALUTATION = ""; }
                        try { _SQL_PARTY_MASTER.SFX = row["SFX"].ToString(); } catch { _SQL_PARTY_MASTER.SFX = ""; }
                        try { _SQL_PARTY_MASTER.ADD1 = row["ADD1"].ToString().Replace('\'', '`'); } catch { _SQL_PARTY_MASTER.ADD1 = ""; }
                        try { _SQL_PARTY_MASTER.ADD2 = row["ADD2"].ToString().Replace('\'', '`'); } catch { _SQL_PARTY_MASTER.ADD2 = ""; }
                        try { _SQL_PARTY_MASTER.ADD3 = row["ADD3"].ToString().Replace('\'', '`'); } catch { _SQL_PARTY_MASTER.ADD3 = ""; }
                        try { _SQL_PARTY_MASTER.ADD4 = row["ADD4"].ToString().Replace('\'', '`'); } catch { _SQL_PARTY_MASTER.ADD4 = ""; }
                        try { _SQL_PARTY_MASTER.ADD5 = row["ADD5"].ToString().Replace('\'', '`'); } catch { _SQL_PARTY_MASTER.ADD5 = ""; }
                        try { _SQL_PARTY_MASTER.PIN = row["PIN"].ToString(); } catch { _SQL_PARTY_MASTER.PIN = ""; }
                        try { _SQL_PARTY_MASTER.NATIONALITY = row["NATIONALITY"].ToString(); } catch { _SQL_PARTY_MASTER.NATIONALITY = ""; }
                        try { _SQL_PARTY_MASTER.COUNTRY_RESIDENCE = row["COUNTRY_RESIDENCE"].ToString(); } catch { _SQL_PARTY_MASTER.COUNTRY_RESIDENCE = ""; }
                        try { _SQL_PARTY_MASTER.COUNTRY_NAME = row["COUNTRY_NAME"].ToString(); } catch { _SQL_PARTY_MASTER.COUNTRY_NAME = ""; }
                        try { _SQL_PARTY_MASTER.GENDER = row["GENDER"].ToString(); } catch { _SQL_PARTY_MASTER.GENDER = ""; }
                        try { _SQL_PARTY_MASTER.MOBILE = row["MOBILE"].ToString(); } catch { _SQL_PARTY_MASTER.MOBILE = ""; }
                        try { _SQL_PARTY_MASTER.EMAIL = row["EMAIL"].ToString(); } catch { _SQL_PARTY_MASTER.EMAIL = ""; }
                        try { _SQL_PARTY_MASTER.PHONE = row["PHONE"].ToString(); } catch { _SQL_PARTY_MASTER.PHONE = ""; }
                        try { _SQL_PARTY_MASTER.DOB = Convert.ToDateTime(row["DOB"].ToString()); } catch {/* _SQL_PARTY_MASTER.DOB = ""; */}
                        try { _SQL_PARTY_MASTER.CENTRE = row["CENTRE"].ToString(); } catch { _SQL_PARTY_MASTER.CENTRE = ""; }
                        try { _SQL_PARTY_MASTER.DIVISION = row["DIVISION"].ToString(); } catch { _SQL_PARTY_MASTER.DIVISION = ""; }
                        try { _SQL_PARTY_MASTER.SUBSCRIPTION_CATEGORY = row["SUBSCRIPTION_CATEGORY"].ToString(); } catch { _SQL_PARTY_MASTER.SUBSCRIPTION_CATEGORY = ""; }
                        try { _SQL_PARTY_MASTER.ENROLEMENT_START_DT = Convert.ToDateTime(row["ENROLEMENT_START_DT"].ToString()); } catch {/* _SQL_PARTY_MASTER.ENROLEMENT_START_DT = ""; */}
                        try { _SQL_PARTY_MASTER.ENROLEMENT_END_DT = Convert.ToDateTime(row["ENROLEMENT_END_DT"].ToString()); } catch { /*_SQL_PARTY_MASTER.ENROLEMENT_END_DT = ""; */}
                        try { _SQL_PARTY_MASTER.SUBSCRIPTION_END_DT = Convert.ToDateTime(row["SUBSCRIPTION_END_DT"].ToString()); } catch { /*_SQL_PARTY_MASTER.SUBSCRIPTION_END_DT = ""; */}
                        try { _SQL_PARTY_MASTER.MEMB_CATEGORY = row["MEMB_CATEGORY"].ToString(); } catch { _SQL_PARTY_MASTER.MEMB_CATEGORY = ""; }
                        try { _SQL_PARTY_MASTER.MEMB_TYPE = row["MEMB_TYPE"].ToString(); } catch { _SQL_PARTY_MASTER.MEMB_TYPE = ""; }
                        try { _SQL_PARTY_MASTER.GENERATE_DATE = Convert.ToDateTime(row["GENERATE_DATE"].ToString()); } catch { /*_SQL_PARTY_MASTER.GENERATE_DATE = "";*/ }
                        try { _SQL_PARTY_MASTER.UPLOAD_DATE = Convert.ToDateTime(row["UPLOAD_DATE"].ToString()); } catch {/* _SQL_PARTY_MASTER.UPLOAD_DATE = "";*/ }
                        try { _SQL_PARTY_MASTER.DOWNLOAD_FLAG = row["DOWNLOAD_FLAG"].ToString(); } catch { _SQL_PARTY_MASTER.DOWNLOAD_FLAG = ""; }
                        try { _SQL_PARTY_MASTER.CL = row["CL"].ToString(); } catch { _SQL_PARTY_MASTER.CL = ""; }
                        try { _SQL_PARTY_MASTER.REMARKS = row["REMARKS"].ToString(); } catch { _SQL_PARTY_MASTER.REMARKS = ""; }
                        try { _SQL_PARTY_MASTER.ADD_CHANGE_DATE = Convert.ToDateTime(row["ADD_CHANGE_DATE"].ToString()); } catch { /*_SQL_PARTY_MASTER.ADD_CHANGE_DATE = "";*/ }
                        SQL = string.Empty;

                        //#region Select PARTYMAST
                        //SQL = @"SELECT PARTYCODE,PARTYNAME, PARTYSURNAME, PARTYHOUSE, PARTYSTREET,PARTYCITY,PARTYSTATE,PARTYCOUNTRY,PIN,RESTEL,OFFTEL,TELEX,EMAILID,MOBILE,CATRGORY,TYPE,COUNTRYOFRES,DUEFEES,FEES,DATEOFPAY,RECSLNO,NVL(CL,'N') AS CL,DATE_STAMP,ID_STAMP,DATEOFENROL,SERVICECODE,CCODE,SYSDT,SYSDT1,IPADD FROM PARTYMAST WHERE PARTYCODE='" + _SQL_PARTY_MASTER.PARTYCODE + "'";// need to reviced
                        //#endregion
                        #region Select PARTYMAST
                        SQL = @"SELECT MEMB_IDENTITY,MEMBCODE,NAME ,ADD1 ,ADD2 ,ADD3 ,ADD4 , ADD5 ,PIN,TEL_O ,EMAIL ,MOBILE,DIVISION ,COUNTRY_CODE,RES_COUNTRY,NATIONALITY , NVL(STATUS,'Y') AS STATUS,CCODE,UPDT_DT,IP_ADD FROM TBL_MEMBER_MASTER WHERE MEMBCODE='" + _SQL_PARTY_MASTER.PARTYCODE + "'";// need to reviced
                        #endregion
                        ProcessingMemb.PARTY_MASTERS_TOTAL_COUNT.Add(_SQL_PARTY_MASTER);

                        OraCon.DbSelectDML = OraCon.OraDML<DBAdapter.OraDBCon.DBSelectResult>(DBAdapter.OraDBCon.QueryType.SELECT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);


                        OutputProperties.BackColor = Color.Empty;
                        OutputProperties.ForeColor = Color.Black;
                        OutputProperties.Text = OraCon.DbSelectDML.QUERY;
                        SafeInvoke(monitor, UiElement, true);



                        if (!OraCon.DbSelectDML.SELECT.OraErrFlg)
                        {
                            TBL_MEMBER_MASTER _ORA_PARTYMAST = new TBL_MEMBER_MASTER();
                            if (OraCon.DbSelectDML.SELECT.RowCount != 0)
                            {
                                DataRow dr = OraCon.DbSelectDML.SELECT.ReaderDT.Rows[0];

                                try { _ORA_PARTYMAST.MEMBCODE = dr["MEMBCODE"].ToString(); } catch { _ORA_PARTYMAST.MEMBCODE = ""; }
                                try { _ORA_PARTYMAST.NAME = dr["NAME"].ToString(); } catch { _ORA_PARTYMAST.NAME = ""; }
                                // try { _ORA_PARTYMAST.PARTYSURNAME = dr["PARTYSURNAME"].ToString(); } catch { _ORA_PARTYMAST.PARTYSURNAME = ""; }
                                try { _ORA_PARTYMAST.ADD1 = dr["ADD1"].ToString(); } catch { _ORA_PARTYMAST.ADD1 = ""; }
                                try { _ORA_PARTYMAST.ADD2 = dr["ADD2"].ToString(); } catch { _ORA_PARTYMAST.ADD2 = ""; }
                                try { _ORA_PARTYMAST.ADD3 = dr["ADD3"].ToString(); } catch { _ORA_PARTYMAST.ADD3 = ""; }
                                try { _ORA_PARTYMAST.ADD4 = dr["ADD4"].ToString(); } catch { _ORA_PARTYMAST.ADD4 = ""; }
                                try { _ORA_PARTYMAST.ADD5 = dr["ADD5"].ToString(); } catch { _ORA_PARTYMAST.ADD5 = ""; }
                                try { _ORA_PARTYMAST.PIN = dr["PIN"].ToString(); } catch { _ORA_PARTYMAST.PIN = ""; }
                                try { _ORA_PARTYMAST.TEL_O = dr["TEL_O"].ToString(); } catch { _ORA_PARTYMAST.TEL_O = ""; }
                                //try { _ORA_PARTYMAST.OFFTEL = dr["OFFTEL"].ToString(); } catch { _ORA_PARTYMAST.OFFTEL = ""; }
                                //try { _ORA_PARTYMAST.TELEX = dr["TELEX"].ToString(); } catch { _ORA_PARTYMAST.TELEX = ""; }
                                try { _ORA_PARTYMAST.EMAIL = dr["EMAIL"].ToString(); } catch { _ORA_PARTYMAST.EMAIL = ""; }
                                try { _ORA_PARTYMAST.MOBILE = dr["MOBILE"].ToString(); } catch { _ORA_PARTYMAST.MOBILE = ""; }
                                // try { _ORA_PARTYMAST.CATRGORY = dr["CATRGORY"].ToString(); } catch { _ORA_PARTYMAST.CATRGORY = ""; }
                                try { _ORA_PARTYMAST.DIVISION = dr["DIVISION"].ToString(); } catch { _ORA_PARTYMAST.DIVISION = ""; }
                                try { _ORA_PARTYMAST.COUNTRY_CODE = dr["COUNTRY_CODE"].ToString(); } catch { _ORA_PARTYMAST.COUNTRY_CODE = ""; }
                                try { _ORA_PARTYMAST.RES_COUNTRY = dr["RES_COUNTRY"].ToString(); } catch { _ORA_PARTYMAST.RES_COUNTRY = ""; }
                                try { _ORA_PARTYMAST.NATIONALITY = dr["NATIONALITY"].ToString(); } catch { _ORA_PARTYMAST.NATIONALITY = ""; }
                                try { _ORA_PARTYMAST.RES_COUNTRY = dr["RES_COUNTRY"].ToString(); } catch { _ORA_PARTYMAST.RES_COUNTRY = ""; }
                                // try { _ORA_PARTYMAST.DUEFEES = Convert.ToDouble(dr["DUEFEES"].ToString()); } catch { _ORA_PARTYMAST.DUEFEES = 0; }
                                //try { _ORA_PARTYMAST.DATEOFPAY = dr["DATEOFPAY"].ToString(); } catch { _ORA_PARTYMAST.DATEOFPAY = ""; }
                                //try { _ORA_PARTYMAST.RECSLNO = dr["RECSLNO"].ToString(); } catch { _ORA_PARTYMAST.RECSLNO = ""; }
                                try { _ORA_PARTYMAST.STATUS = dr["STATUS"].ToString(); } catch { _ORA_PARTYMAST.STATUS = ""; }
                                // try { _ORA_PARTYMAST.DATE_STAMP = Convert.ToDateTime(dr["DATE_STAMP"].ToString()); } catch { _ORA_PARTYMAST.DATE_STAMP = null; }
                                // try { _ORA_PARTYMAST.ID_STAMP = dr["ID_STAMP"].ToString(); } catch { _ORA_PARTYMAST.ID_STAMP = ""; }
                                //  try { _ORA_PARTYMAST.DATEOFENROL = Convert.ToDateTime(dr["DATEOFENROL"].ToString()); } catch { _ORA_PARTYMAST.DATEOFENROL = null; }
                                // try { _ORA_PARTYMAST.SERVICECODE = dr["SERVICECODE"].ToString(); } catch { _ORA_PARTYMAST.SERVICECODE = ""; }
                                try { _ORA_PARTYMAST.CCODE = dr["CCODE"].ToString(); } catch { _ORA_PARTYMAST.CCODE = ""; }
                                try { _ORA_PARTYMAST.SYSDT = Convert.ToDateTime(dr["UPDT_DT"].ToString()); } catch { _ORA_PARTYMAST.SYSDT = null; }
                                //try { _ORA_PARTYMAST.SYSDT1 = Convert.ToDateTime(dr["SYSDT1"].ToString()); } catch { _ORA_PARTYMAST.SYSDT1 = null; }
                                try { _ORA_PARTYMAST.WEB_UPDN_FLAG = dr["WEB_UPDN_FLAG"].ToString(); } catch { _ORA_PARTYMAST.WEB_UPDN_FLAG = ""; }
                                try { _ORA_PARTYMAST.SALUTATION = dr["SALUTATION"].ToString(); } catch { _ORA_PARTYMAST.SALUTATION = ""; }
                                try { _ORA_PARTYMAST.GENDER = dr["GENDER"].ToString(); } catch { _ORA_PARTYMAST.GENDER = ""; }
                                try { _ORA_PARTYMAST.SFX = dr["NAME_SFX"].ToString(); } catch { _ORA_PARTYMAST.SFX = ""; }
                                try { _ORA_PARTYMAST.MEMB_IDENTITY = dr["MEMB_IDENTITY"].ToString(); } catch { _ORA_PARTYMAST.MEMB_IDENTITY = ""; }
                                try { _ORA_PARTYMAST.UPDT_USR = dr["UPDT_USR"].ToString(); } catch { _ORA_PARTYMAST.UPDT_USR = ""; }
                                try { _ORA_PARTYMAST.UPDT_DT = dr["UPDT_DT"].ToString(); } catch { _ORA_PARTYMAST.UPDT_DT = ""; }
                                try { _ORA_PARTYMAST.IP_ADD = dr["IP_ADD"].ToString(); } catch { _ORA_PARTYMAST.IP_ADD = ""; }


                                if (_ORA_PARTYMAST.STATUS == "Y")
                                {
                                    SQL = string.Empty;
                                    try
                                    {
                                        //#region insert log to the PARTYCHADD
                                        //SQL = @"INSERT INTO PARTYCHADD (MEMBCODE,RECSLNO,ADD1,ADD2,ADD3,ADD4,ADD5,CENTRE,DIVISION ,PARTYNAME,PARTYSURNAME,EMAIL,MOBILE,DATEIN,PIN,SYSDT,FUNC,UPDT_DIR) (SELECT PARTYCODE,RECSLNO,PARTYHOUSE,PARTYSTREET,PARTYCITY,PARTYSTATE,PARTYCOUNTRY,CCODE,TYPE,PARTYNAME,PARTYSURNAME,EMAILID,MOBILE,SYSDT1,PIN,SYSDT,'AUTO','WEB TO LOCAL' FROM PARTYMAST WHERE PARTYCODE='" + _SQL_PARTY_MASTER.PARTYCODE + "' AND NVL(CL,'N')<>'Y')";// need to reviced
                                        //#endregion

                                        //OraCon.DbInsertDML = OraCon.OraDML<DBAdapter.OraDBCon.DBInsertResult>(DBAdapter.OraDBCon.QueryType.INSERT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);

                                        OutputProperties.BackColor = Color.Empty;
                                        OutputProperties.ForeColor = Color.Black;
                                        OutputProperties.Text = OraCon.DbSelectDML.QUERY;
                                        SafeInvoke(monitor, UiElement, true);
                                        string CCODE = string.Empty;
                                        //if (!OraCon.DbInsertDML.INSERT.OraErrFlg)
                                        //{
                                        //if (OraCon.DbInsertDML.INSERT.Count == 1)
                                        //{
                                        SQL = string.Empty;

                                        if (!string.IsNullOrEmpty(_SQL_PARTY_MASTER.PIN))
                                        {
                                            TEMP_APO_FLG = _SQL_PARTY_MASTER.CENTRE.ToString() == "004" ? "T" : "F";
                                            // SQL = @"select DA_PIN('" + _SQL_PARTY_MASTER.PIN + "') CCODE FROM DUAL";
                                            SQL = @"select FN_FIND_CCODE('" + _SQL_PARTY_MASTER.PIN + "','" + _SQL_PARTY_MASTER.COUNTRY_RESIDENCE + "','" + TEMP_APO_FLG + "') CCODE FROM DUAL";
                                            OraCon.DbSelectDML = OraCon.OraDML<DBAdapter.OraDBCon.DBSelectResult>(DBAdapter.OraDBCon.QueryType.SELECT, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);

                                            if (OraCon.DbSelectDML.SELECT.ReaderDT.Rows.Count == 1)
                                            {
                                                CCODE = OraCon.DbSelectDML.SELECT.ReaderDT.Rows[0]["CCODE"].ToString();

                                                if (CCODE != _SQL_PARTY_MASTER.CENTRE)
                                                {
                                                    SQL = string.Empty;

                                                    SQL = @"UPDATE [WEBIEI].[dbo].[IEI_TBL_PARTY_MASTER] SET CENTRE='" + CCODE + "' WHERE PARTYCODE='" + _SQL_PARTY_MASTER.PARTYCODE + "' AND CL='N'"; // need to reviced


                                                    SQLCon.Update = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBUpdateResult>(DBAdapter.SQLServerDBCon.QueryType.UPDATE, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);
                                                    if (!SQLCon.Update.UPDATE.OraErrFlg)
                                                    {
                                                        if (SQLCon.Update.UPDATE.Count == 1)
                                                        {
                                                            COMMIT_FLG = true;
                                                        }
                                                        else
                                                        {
                                                            COMMIT_FLG = false;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        COMMIT_FLG = false;
                                                    }

                                                }
                                            }
                                        }
                                        else
                                        {
                                            CCODE = _SQL_PARTY_MASTER.CENTRE;
                                        }
                                        SQL = string.Empty;

                                        #region update PARTYMAST



                                        // SQL = @"UPDATE PARTYMAST SET SYSDT=TO_DATE(substr('" + _SQL_PARTY_MASTER.ADD_CHANGE_DATE + "',1,10),'DD/MM/YYYY'),SYSDT1=TO_DATE(substr('" + _SQL_PARTY_MASTER.ADD_CHANGE_DATE + "',1,10),'DD/MM/YYYY'),UPDT_USR='AUTO', WEB_UPDT_FLG = 'T', PARTYHOUSE = '" + _SQL_PARTY_MASTER.ADD1 + "'," + "PARTYSTREET = '" + _SQL_PARTY_MASTER.ADD2 + "'," + "PARTYCITY = '" + _SQL_PARTY_MASTER.ADD3 + "'," + "PARTYSTATE = '" + _SQL_PARTY_MASTER.ADD4 + "'," + "PARTYCOUNTRY = '" + _SQL_PARTY_MASTER.ADD5 + "'," + "CCODE = '" + CCODE + "'," + "PIN = '" + _SQL_PARTY_MASTER.PIN + "'," + "EMAILID = '" + _SQL_PARTY_MASTER.EMAIL + "'," + "MOBILE = '" + _SQL_PARTY_MASTER.MOBILE + "' WHERE PARTYCODE = '" + _SQL_PARTY_MASTER.PARTYCODE + "' AND NVL(CL,'N')<>'Y'";// need to reviced
                                        SQL = @"UPDATE TBL_MEMBER_MASTER SET UPDT_DT=sysdate,LAST_UPDATE_MODE='ONLINE', WEB_UPDN_FLAG = 'T', ADD1 = '" + _SQL_PARTY_MASTER.ADD1.ToUpper() + "'," + "ADD2 = '" + _SQL_PARTY_MASTER.ADD2.ToUpper() + "'," + "ADD3 = '" + _SQL_PARTY_MASTER.ADD3.ToUpper() + "'," + "ADD4 = '" + _SQL_PARTY_MASTER.ADD4.ToUpper() + "'," + "ADD5 = '" + _SQL_PARTY_MASTER.ADD5.ToUpper() + "'," + "CCODE = '" + CCODE + "'," + "PIN = '" + _SQL_PARTY_MASTER.PIN + "'," + "EMAIL = '" + _SQL_PARTY_MASTER.EMAIL.ToLower() + "'," + "MOBILE = '" + _SQL_PARTY_MASTER.MOBILE + "'," +
                                            "IS_APO='" + TEMP_APO_FLG + "',COUNTRY_CODE='" + _SQL_PARTY_MASTER.COUNTRY_RESIDENCE + "',RES_COUNTRY='" + _SQL_PARTY_MASTER.COUNTRY_NAME.ToUpper() + "',NATIONALITY='" +
                                            _SQL_PARTY_MASTER.NATIONALITY.ToUpper() + "' WHERE MEMBCODE = '" + _SQL_PARTY_MASTER.PARTYCODE + "' AND NVL(STATUS,'Y')<>'N'";// need to reviced

                                        #endregion

                                        OraCon.DbUpdateDML = OraCon.OraDML<DBAdapter.OraDBCon.DBUpdateResult>(DBAdapter.OraDBCon.QueryType.UPDATE, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);

                                        OutputProperties.BackColor = Color.Empty;
                                        OutputProperties.ForeColor = Color.Black;
                                        OutputProperties.Text = OraCon.DbUpdateDML.QUERY;
                                        SafeInvoke(monitor, UiElement, true);

                                        SQL = string.Empty;

                                        /////////////////////////
                                        SQL = @"UPDATE TBL_MEMBER_MASTER SET NATIONALITY='INDIAN' WHERE MEMBCODE = '" + _SQL_PARTY_MASTER.PARTYCODE + "' AND NVL(STATUS,'Y')<>'N' AND TRIM(NATIONALITY)='INDIA'";
                                        OraCon.DbUpdateDML = OraCon.OraDML<DBAdapter.OraDBCon.DBUpdateResult>(DBAdapter.OraDBCon.QueryType.UPDATE, DBAdapter.OraDBCon.UsingType.DataReader, SQL, 100);
                                        OutputProperties.BackColor = Color.Empty;
                                        OutputProperties.ForeColor = Color.Black;
                                        OutputProperties.Text = OraCon.DbUpdateDML.QUERY;
                                        SafeInvoke(monitor, UiElement, true);

                                        SQL = string.Empty;

                                        #region update IEI_TBL_PARTY_MASTER
                                        SQL = @"UPDATE [WEBIEI].[dbo].[IEI_TBL_PARTY_MASTER] SET DOWNLOAD_FLAG='F' WHERE PARTYCODE='" + _SQL_PARTY_MASTER.PARTYCODE + "'  AND CL='N'"; // need to reviced
                                        #endregion

                                        SQLCon.Update = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBUpdateResult>(DBAdapter.SQLServerDBCon.QueryType.UPDATE, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);

                                        OutputProperties.BackColor = Color.Empty;
                                        OutputProperties.ForeColor = Color.Black;
                                        OutputProperties.Text = SQLCon.Select.QUERY;
                                        SafeInvoke(monitor, UiElement, true);

                                        if (!SQLCon.Update.UPDATE.OraErrFlg)
                                        {
                                            if (SQLCon.Update.UPDATE.Count == 1)
                                            {
                                                ProcessingMemb.PARTY_MASTER_PROCESSED.Add(_SQL_PARTY_MASTER);



                                                //OraCon.Commit();
                                                //SQLCon.Commit();
                                                COMMIT_FLG = true;

                                            }
                                            else
                                            {
                                                COMMIT_FLG = false;
                                            }

                                        }
                                        else
                                        {
                                            COMMIT_FLG = false;
                                        }

                                        //}
                                        //else
                                        //{
                                        //    COMMIT_FLG = false;
                                        //}
                                        //}
                                        //else
                                        //{
                                        //    COMMIT_FLG = false;
                                        //}
                                    }
                                    catch
                                    {
                                        COMMIT_FLG = false;
                                    }
                                }
                                else
                                {
                                    ProcessingMemb.PARTY_MASTERS_CLOSE.Add(_SQL_PARTY_MASTER);

                                    try
                                    {
                                        SQL = string.Empty;
                                        SQL = @"UPDATE [WEBIEI].[dbo].[IEI_TBL_PARTY_MASTER] SET CL = '" + _ORA_PARTYMAST.STATUS == "Y" ? "N" : "Y" + "' ,[DOWNLOAD_FLAG]='F', REMARKS = 'CLOSE THE MEMBER AT THE TIME OF ADDRESS SYNCHRONIZATION' WHERE PARTYCODE='" + _SQL_PARTY_MASTER.PARTYCODE + "'  AND CL='N'"; // need to reviced
                                        SQLCon.Update = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBUpdateResult>(DBAdapter.SQLServerDBCon.QueryType.UPDATE, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);

                                        SQL = string.Empty;
                                        SQL = @"INSERT INTO [WEBIEI].[dbo].[IEI_TBL_PARTY_MASTER_NEED_ATTN] ([PARTYCODE],[MEMB_IDENTITY],[LOGIN_ID],[PARTY_NAME],[SALUTATION],[SFX],[ADD1],[ADD2],[ADD3],[ADD4],[ADD5]
                                          ,[PIN],[NATIONALITY],[COUNTRY_RESIDENCE],[GENDER],[MOBILE],[EMAIL],[PHONE],[DOB],[CENTRE],[DIVISION],[SUBSCRIPTION_CATEGORY],[ENROLEMENT_START_DT],[ENROLEMENT_END_DT],[SUBSCRIPTION_END_DT]
                                          ,[MEMB_CATEGORY],[MEMB_TYPE],[GENERATE_DATE],[UPLOAD_DATE],[DOWNLOAD_FLAG],[CL],[REMARKS],[ADD_CHANGE_DATE],[TYPE_OF_ATTN])
                                           (SELECT [PARTYCODE],[MEMB_IDENTITY],[LOGIN_ID],[PARTY_NAME],[SALUTATION],[SFX],[ADD1],[ADD2],[ADD3],[ADD4],[ADD5],[PIN],[NATIONALITY]
                                          ,[COUNTRY_RESIDENCE],[GENDER],[MOBILE],[EMAIL],[PHONE],[DOB],[CENTRE],[DIVISION],[SUBSCRIPTION_CATEGORY],[ENROLEMENT_START_DT]
                                          ,[ENROLEMENT_END_DT],[SUBSCRIPTION_END_DT],[MEMB_CATEGORY],[MEMB_TYPE],[GENERATE_DATE],[UPLOAD_DATE],[DOWNLOAD_FLAG],[CL]
                                          ,'CLOSE THE MEMBER AT THE TIME OF ADDRESS SYNCHRONIZATION',[ADD_CHANGE_DATE],'CLOSE' FROM [WEBIEI].[dbo].[IEI_TBL_PARTY_MASTER] WHERE  PARTYCODE='" + _SQL_PARTY_MASTER.PARTYCODE + "')"; // need to reviced

                                        SQLCon.Insert = SQLCon.SqlDML<DBAdapter.SQLServerDBCon.DBInsertResult>(DBAdapter.SQLServerDBCon.QueryType.INSERT, DBAdapter.SQLServerDBCon.UsingType.DataReader, SQL);


                                        ProcessingMemb.PARTY_MASTERS_CLOSE.Add(_SQL_PARTY_MASTER);
                                        COMMIT_FLG = true;
                                    }
                                    catch
                                    {
                                        COMMIT_FLG = false;
                                    }


                                }
                            }

                            //_ORA_PARTYMAST.PARTYCODE = row["PARTYCODE"].ToString();

                        }
                    }
                    if (COMMIT_FLG == true)
                    {
                        OraCon.Commit();
                        SQLCon.Commit();

                        ReturnSyncChangeAddress.ST_Processed = JsonConvert.SerializeObject(ProcessingMemb.PARTY_MASTER_PROCESSED);
                    }
                    else
                    {
                        OraCon.Rollback();
                        SQLCon.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    COMMIT_FLG = false;

                    OutputProperties.BackColor = Color.Empty;
                    OutputProperties.ForeColor = Color.Red;
                    OutputProperties.Text = ex.Message;
                    SafeInvoke(monitor, UiElement, true);

                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (ProcessingMemb.PARTY_MASTERS_CLOSE.Count != 0)
                    {
                        Json json = new Json();
                        json.Write(rootMembClose, JsonConvert.SerializeObject(ProcessingMemb.PARTY_MASTERS_CLOSE));
                    }

                }

            }
            else
            {
                ReturnSyncChangeAddress.DT_Queue = null;
                SafeInvoke(monitor, UiElement, true);
            }
        }

        #endregion
    }
}
