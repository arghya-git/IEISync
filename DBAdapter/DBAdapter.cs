using Newtonsoft.Json;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace DBAdapter
{
    namespace OraDBCon
    {
        using Oracle.ManagedDataAccess.Client;

        /// <summary>
        /// UsingType retrive data either by DataAdater or by DataReader
        /// </summary>
        public enum UsingType
        {
            DataAdapter, DataReader
        }

        /// <summary>
        /// QueryType Represnts the CRUD (SELECT,INSERT,UPDATE,DELETE) Operation Types.
        /// </summary>
        public enum QueryType
        {
            SELECT, INSERT, UPDATE, DELETE, PROCEDURE
        }

        /// <summary>
        /// Common Return type of Query Output
        /// </summary>
        public interface IResult
        {
            string ConnectionState { get; set; }
            string TRANSACTION_STATUS { get; set; }
            string QUERY { get; set; }
        }

        /// <summary>
        /// Hold output of SELECT Query
        /// </summary>
        public class SELECT
        {
            private OracleDataReader _reader;
            private string _OraErr;
            private bool _OraErrFlg;
            
            private int _visFC;
            private int _hidFC;
            private string _readerJSon;
            private DataTable _readerDT;
            private DataTableReader _dtr;
            public OracleDataReader Reader
            {
                get
                {
                    return _reader;
                }

                set
                {
                    _reader = value;
                }
            }
            public string OraErr
            {
                get
                {
                    return _OraErr;
                }

                set
                {
                    _OraErr = value;
                }
            }
            private int _rowCount;
            public int RowCount { get => _rowCount; set => _rowCount = value; }
            public int VisFC
            {
                get
                {
                    return _visFC;
                }

                set
                {
                    _visFC = value;
                }
            }
            public int HidFC
            {
                get
                {
                    return _hidFC;
                }

                set
                {
                    _hidFC = value;
                }
            }
            public string ReaderJSon
            {
                get
                {
                    return _readerJSon;
                }

                set
                {
                    _readerJSon = value;
                }
            }
            public bool OraErrFlg
            {
                get
                {
                    return _OraErrFlg;
                }

                set
                {
                    _OraErrFlg = value;
                }
            }
            public DataTable ReaderDT
            {
                get
                {
                    return _readerDT;
                }

                set
                {
                    _readerDT = value;
                }
            }
            public DataTableReader Dtr
            {
                get
                {
                    return _dtr;
                }

                set
                {
                    _dtr = value;
                }
            }

            
        }

        /// <summary>
        /// Hold output of INSERT Query
        /// </summary>
        public class INSERT
        {
            private string _OraErr;
            private int _count = 0;
            private string _messagePrompt = " Records is/are Successfully Inserted";
            private bool _OraErrFlg;
            public string MessagePrompt
            {
                get
                {
                    return Count.ToString() + _messagePrompt;
                }

                set
                {
                    _messagePrompt = value;
                }
            }
            public string OraErr
            {
                get
                {
                    return _OraErr;
                }

                set
                {
                    _OraErr = value;
                }
            }
            public int Count
            {
                get
                {
                    return _count;
                }

                set
                {
                    _count = value;
                }
            }
            public bool OraErrFlg
            {
                get
                {
                    return _OraErrFlg;
                }

                set
                {
                    _OraErrFlg = value;
                }
            }
        }

        /// <summary>
        /// Hold output of UPDATE Query
        /// </summary>
        public class UPDATE
        {
            private string _OraErr;
            private bool _OraErrFlg;
            private int _count = 0;
            private string _messagePrompt = " Records is/are Successfully Updated";

            public bool OraErrFlg
            {
                get
                {
                    return _OraErrFlg;
                }

                set
                {
                    _OraErrFlg = value;
                }
            }
            public string MessagePrompt
            {
                get
                {
                    return Count.ToString() + _messagePrompt;
                }

                set
                {
                    _messagePrompt = value;
                }
            }
            public string OraErr
            {
                get
                {
                    return _OraErr;
                }

                set
                {
                    _OraErr = value;
                }
            }
            public int Count
            {
                get
                {
                    return _count;
                }

                set
                {
                    _count = value;
                }
            }

        }

        /// <summary>
        /// Hold output of DELETE Query
        /// </summary>
        public class DELETE
        {
            private string _OraErr;
            private bool _OraErrFlg;
            private int _count = 0;
            private string _messagePrompt = " Records is/are Successfully Deleted";

            public bool OraErrFlg
            {
                get
                {
                    return _OraErrFlg;
                }

                set
                {
                    _OraErrFlg = value;
                }
            }
            public string MessagePrompt
            {
                get
                {
                    return Count.ToString() + _messagePrompt;
                }

                set
                {
                    _messagePrompt = value;
                }
            }
            public string OraErr
            {
                get
                {
                    return _OraErr;
                }

                set
                {
                    _OraErr = value;
                }
            }
            public int Count
            {
                get
                {
                    return _count;
                }

                set
                {
                    _count = value;
                }
            }
        }

        /// <summary>
        /// Return output of Select Query
        /// </summary>
        public class DBSelectResult : IResult
        {
            public string TRANSACTION_STATUS { get; set; }
            public string QUERY { get; set; }
            public string ConnectionState { get; set; }

            SELECT _SELECT;
            public SELECT SELECT { get => _SELECT; set => _SELECT = value; }

            QueryType _QUERY_TYPE = QueryType.SELECT;
            public QueryType QUERY_TYPE { get => _QUERY_TYPE; }

            public DBSelectResult()
            {
                SELECT = new SELECT();
            }
        }

        /// <summary>
        /// Return output of INSERT Query
        /// </summary>
        public class DBInsertResult : IResult
        {

            public string TRANSACTION_STATUS { get; set; }
            public string QUERY { get; set; }
            public string ConnectionState { get; set; }

            INSERT _INSERT;
            public INSERT INSERT { get => _INSERT; set => _INSERT = value; }

            QueryType _QUERY_TYPE = QueryType.INSERT;
            public QueryType QUERY_TYPE { get => _QUERY_TYPE; }

            public DBInsertResult()
            {
                INSERT = new INSERT();
            }

        }

        /// <summary>
        /// Return output of UPDATE Query
        /// </summary>
        public class DBUpdateResult : IResult
        {

            public string TRANSACTION_STATUS { get; set; }
            public string QUERY { get; set; }
            public string ConnectionState { get; set; }

            UPDATE _UPDATE;
            public UPDATE UPDATE { get => _UPDATE; set => _UPDATE = value; }

            QueryType _QUERY_TYPE = QueryType.UPDATE;
            public QueryType QUERY_TYPE { get => _QUERY_TYPE; }

            public DBUpdateResult()
            {
                UPDATE = new UPDATE();
            }

        }

        /// <summary>
        /// Return output of DELETE Query
        /// </summary>
        public class DBDeleteResult : IResult
        {

            public string TRANSACTION_STATUS { get; set; }
            public string QUERY { get; set; }
            public string ConnectionState { get; set; }

            DELETE _DELETE;
            public DELETE DELETE { get => _DELETE; set => _DELETE = value; }

            QueryType _QUERY_TYPE = QueryType.DELETE;
            public QueryType QUERY_TYPE { get => _QUERY_TYPE; }

            public DBDeleteResult()
            {
                DELETE = new DELETE();
            }

        }

        /// <summary>
        /// Connection Class: Responsible for Oracle Connection.
        /// </summary>
        public static class Connection
        {
           
            //public enum state
            //{
            //    connected, disconnected, suspended, resume
            //}


            static DBAdapterEnums.state _State = DBAdapterEnums.state.disconnected;
            public static DBAdapterEnums.state State { get => _State; set => _State = value; }
            //public enum status
            //{
            //    Success, Fail, Error, Waiting, Cancelled, ConnState
            //}

            public static class Status
            {
                static DBAdapterEnums.status _Error;
                static Properties _Properties = new Properties();

                public static DBAdapterEnums.status Error { get => _Error; set => _Error = value; }

                public static Properties Properties
                {
                    get
                    {
                        if (_Error == DBAdapterEnums.status.ConnState)
                        {
                            _Properties.Text = "Connection State";
                            if (State == DBAdapterEnums.state.connected)
                                _Properties.LabelForeColor = Color.Green;
                            else
                                _Properties.LabelForeColor = Color.Gray;
                        }
                        else if (_Error == DBAdapterEnums.status.Success)
                        {
                            _Properties.Text = "Success";
                            _Properties.TextForeColor = Color.Green;
                            _Properties.LabelForeColor = Color.Black;
                        }
                        else if (_Error == DBAdapterEnums.status.Error)
                        {
                            _Properties.Text = "Error";
                            _Properties.TextForeColor = Color.Red;
                            _Properties.LabelForeColor = Color.Red;
                        }
                        else if (_Error == DBAdapterEnums.status.Fail)
                        {
                            _Properties.Text = "Fail";
                            _Properties.TextForeColor = Color.Red;
                            _Properties.LabelForeColor = Color.Red;
                        }
                        else if (_Error == DBAdapterEnums.status.Waiting)
                        {
                            _Properties.Text = "Waiting";
                            _Properties.LabelForeColor = Color.Black;
                            _Properties.LabelBackColor = Color.Yellow;
                            _Properties.TextForeColor = Color.Black;
                            _Properties.TextBackColor = Color.Yellow;
                        }
                        else if (_Error == DBAdapterEnums.status.Cancelled)
                        {
                            _Properties.Text = "Cancelled";
                            _Properties.LabelForeColor = Color.Gray;
                            _Properties.TextForeColor = Color.Gray;
                            _Properties.TextBackColor = Color.Empty;
                        }
                        else { return null; }
                        return _Properties;
                    }

                }
            }
            public class Properties
            {
                string _Label = string.Empty;
                string _Text = string.Empty;
                Color _LabelForeColor = Color.Empty;
                Color _LabelBackColor = Color.Empty;
                Color _TextForeColor = Color.Empty;
                Color _TextBackColor = Color.Empty;
                Color _ConnectionstringColor = Color.Blue;
                Color _ConnectionstringBackColor = Color.Empty;
                public string Label { get => _Label; set => _Label = value; }
                public string Text { get => _Text; set => _Text = value; }
                public Color LabelForeColor { get => _LabelForeColor; set => _LabelForeColor = value; }
                public Color LabelBackColor { get => _LabelBackColor; set => _LabelBackColor = value; }
                public Color TextForeColor { get => _TextForeColor; set => _TextForeColor = value; }
                public Color TextBackColor { get => _TextBackColor; set => _TextBackColor = value; }
                public Color ConnectionstringColor { get => _ConnectionstringColor; }
                public Color ConnectionstringBackColor { get => _ConnectionstringBackColor; }
            }

            static string host;
            static string port;
            static string servicename;
            static string user;
            static string pass;
            public static string Host { get => host; set => host = value; }
            public static string Port { get => port; set => port = value; }
            public static string Servicename { get => servicename; set => servicename = value; }
            public static string User { get => user; set => user = value; }
            public static string Password { get => pass; set => pass = value; }

            static string _Connectionstring;

            //static string _ConnectionState=string.Empty;
            public static string ConnectionString { get => _Connectionstring; set => _Connectionstring = value; }




            //public static string ConnectionState { get => _ConnectionState; set => _ConnectionState = value; }

            static OracleConnection conn;
            public static OracleConnection Conn()
            {
                if (conn == null)
                {
                    conn = new OracleConnection();
                }
                return conn;
            }
            public static void Connect()
            {

                string stat = string.Empty;

                string connectionstring = String.Format(
                  "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
                  "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
                  Host,
                  Port,
                  Servicename,
                  User,
                  Password);

                try
                {
                    OracleConnection conn = Conn();

                    if (conn.State == System.Data.ConnectionState.Closed && State != DBAdapterEnums.state.connected)
                    {
                        try
                        {
                            conn.ConnectionString = connectionstring;
                            conn.Open();
                            stat = "Connected";
                            State = DBAdapterEnums.state.connected;
                            conn.Close();
                            ConnectionString = connectionstring;
                            Status.Error = DBAdapterEnums.status.ConnState;

                        }
                        catch (OracleException ex)
                        {
                            ConnectionString = string.Empty;
                            State = DBAdapterEnums.state.disconnected;
                            Status.Error = DBAdapterEnums.status.Fail;
                            conn.Close();
                            if (ex.Number == 1017)
                            {
                                stat = "Wrong credentials.";
                                //return status;
                            }
                            //Password expired.
                            else if (ex.Number == 28001)
                            {
                                stat = "Password expired.";
                                //return status;
                            }
                            //Acount is locked.
                            else if (ex.Number == 28000)
                            {
                                stat = "Account is locked.";
                                //return status;
                            }
                            else
                            {
                                stat = "An error occurred while attempting to connect." + Environment.NewLine + "Error: " + ex.ToString();
                                //return status;
                            }

                        }
                        catch (Exception ex)
                        {
                            Status.Error = DBAdapterEnums.status.Error;
                            ConnectionString = string.Empty;
                            //Transactionflag = false;
                            conn.Close();
                            stat = ex.ToString();
                        }

                    }
                    else
                    {
                        stat = "Already Connected.";
                        Status.Error = DBAdapterEnums.status.Error;
                    }
                }
                catch (OracleException ex)
                {
                    ConnectionString = string.Empty;
                    State = DBAdapterEnums.state.disconnected;
                    Status.Error = DBAdapterEnums.status.Fail;
                    stat = ex.ToString();
                }
                catch (Exception ex)
                {
                    Status.Error = DBAdapterEnums.status.Error;
                    ConnectionString = string.Empty;
                    State = DBAdapterEnums.state.disconnected;
                    stat = ex.ToString();
                }
                finally
                {
                    //ConnectionState = status;
                    Status.Properties.Label = stat;
                }
            }
            public static void Connect(string host, string port, string servicename, string user, string pass)
            {
                Host = host;
                Port = port;
                Servicename = Servicename;
                User = user;
                Password = pass;
                string stat = string.Empty;

                string connectionstring = String.Format(
                  "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
                  "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
                  Host,
                  Port,
                  Servicename,
                  User,
                  Password);

                try
                {
                    OracleConnection conn = Conn();

                    if (conn.State == System.Data.ConnectionState.Closed && State != DBAdapterEnums.state.connected)
                    {
                        try
                        {
                            conn.ConnectionString = connectionstring;
                            conn.Open();
                            stat = "Connected";
                            State = DBAdapterEnums.state.connected;
                            conn.Close();
                            ConnectionString = connectionstring;
                            Status.Error = DBAdapterEnums.status.Success;

                        }
                        catch (OracleException ex)
                        {
                            ConnectionString = string.Empty;
                            State = DBAdapterEnums.state.disconnected;
                            Status.Error = DBAdapterEnums.status.Fail;
                            conn.Close();
                            if (ex.Number == 1017)
                            {
                                stat = "Wrong credentials.";
                                //return status;
                            }
                            //Password expired.
                            else if (ex.Number == 28001)
                            {
                                stat = "Password expired.";
                                //return status;
                            }
                            //Acount is locked.
                            else if (ex.Number == 28000)
                            {
                                stat = "Account is locked.";
                                //return status;
                            }
                            else
                            {
                                stat = "An error occurred while attempting to connect." + Environment.NewLine + "Error: " + ex.ToString();
                                //return status;
                            }

                        }
                        catch (Exception ex)
                        {
                            Status.Error = DBAdapterEnums.status.Error;
                            ConnectionString = string.Empty;
                            //Transactionflag = false;
                            conn.Close();
                            stat = ex.ToString();
                        }

                    }
                    else
                    {
                        stat = "Already Connected.";
                        Status.Error = DBAdapterEnums.status.Error;
                    }
                }
                catch (OracleException ex)
                {
                    ConnectionString = string.Empty;
                    State = DBAdapterEnums.state.disconnected;
                    Status.Error = DBAdapterEnums.status.Fail;
                    stat = ex.ToString();
                }
                catch (Exception ex)
                {
                    Status.Error = DBAdapterEnums.status.Error;
                    ConnectionString = string.Empty;
                    State = DBAdapterEnums.state.disconnected;
                    stat = ex.ToString();
                }
                finally
                {
                    //ConnectionState = status;
                    Status.Properties.Label = stat;
                }
            }
            public static string OraTestCon(string host, string port, string servicename, string user, string pass)
            {
                string connectionstring = String.Format(
                  "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
                  "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
                  host,
                  port,
                  servicename,
                  user,
                  pass);

                //connectionstring = @"User Id=" + user + @";Password=" + pass + @";Data Source= " + connectionstring;
                try
                {
                    OracleConnection conn = new OracleConnection(connectionstring);



                    string status = string.Empty;
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        try
                        {
                            conn.Open();
                            status = "Connection Successfull";
                            conn.Close();

                        }
                        catch (OracleException ex)
                        {
                            conn.Close();
                            if (ex.Number == 1017)
                            {
                                status = "Wrong credentials.";
                                //return status;
                            }
                            //Password expired.
                            else if (ex.Number == 28001)
                            {
                                status = "Password expired.";
                                //return status;
                            }
                            //Acount is locked.
                            else if (ex.Number == 28000)
                            {
                                status = "Account is locked.";
                                //return status;
                            }
                            else
                            {
                                status = "An error occurred while attempting to connect." + Environment.NewLine + "Error: " + ex.ToString();
                                //return status;
                            }
                            return status;
                        }
                        catch (Exception ex)
                        {
                            //Transactionflag = false;
                            conn.Close();
                            status = ex.ToString();
                            return status;

                        }
                        return status;
                    }
                    else
                    {
                        status = "Connection Successfull";

                        return status;
                    }
                }
                catch (OracleException ex)
                {
                    return ex.ToString();
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }

            public static void Disconnect()
            {
                if (State != DBAdapterEnums.state.disconnected)
                {
                    conn.ConnectionString = string.Empty;
                    Host = string.Empty;
                    Port = string.Empty;
                    Servicename = string.Empty;
                    User = string.Empty;
                    Password = string.Empty;
                    State = DBAdapterEnums.state.disconnected;
                    Status.Properties.Label = "Disconnected.";
                    Status.Error = DBAdapterEnums.status.ConnState;

                }
                else
                {
                    Status.Properties.Label = "Already Disconnected.";
                    Status.Error = DBAdapterEnums.status.ConnState;
                }
            }
        }

        /// <summary>
        /// DBAdapter Exception
        /// </summary>
        public class UsingTypeException : Exception
        {
            public UsingTypeException(String message) : base(message)
            {

            }
        }

        /// <summary>
        /// DbCon is responsible for DML,DQL,TCL 
        /// </summary>
        public class DbCon
        {
            public UsingType UType { get; set; }
            public UsingType QType { get; set; }


            private bool _transactionflag = false;
            public bool Transactionflag
            {
                get
                {
                    return _transactionflag;
                }

                set
                {
                    _transactionflag = value;
                }
            }

            public string TRANSACTION_STATUS { get => _TRANSACTION_STATUS; set => _TRANSACTION_STATUS = value; }
            

            private string _TRANSACTION_STATUS;

            OracleCommand cmd;
            OracleConnection conn;

            public DbCon()
            {
                conn = new OracleConnection();
                conn.ConnectionString = Connection.ConnectionString;
                DbUpdateDML = new DBUpdateResult();
                DbSelectDML = new DBSelectResult();
                DbInsertDML = new DBInsertResult();
                DbDeleteDML = new DBDeleteResult();
                cmd = new OracleCommand();
            }
            public string Open()
            {
                string status = string.Empty;
                
                if (conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        conn.ConnectionString = Connection.ConnectionString;
                        conn.Open();
                        status = "Connection Open";
                    }
                    catch (OracleException ex)
                    {
                        if (ex.Number == 1017)
                        {
                            status = "Wrong credentials.";
                            //return status;
                        }
                        //Password expired.
                        else if (ex.Number == 28001)
                        {
                            status = "Password expired.";
                            //return status;
                        }
                        //Acount is locked.
                        else if (ex.Number == 28000)
                        {
                            status = "Account is locked.";
                            //return status;
                        }
                        else
                        {
                            status = "An error occurred while attempting to connect." + Environment.NewLine + "Error: " + ex.ToString();
                            //return status;
                        }
                        throw new Exception(status);
                    }
                    catch (Exception ex)
                    {
                        //Transactionflag = false;
                        status = ex.ToString();

                        throw new Exception(status);
                        //return status;

                    }
                    finally
                    {
                        //Connection.ConnectionState = status;
                    }
                    return status;
                }
                else
                {
                    status = "Connection Open";
                    return status;
                }
            }


            OracleTransaction transaction;
            DBSelectResult dbSelectDML;
            DBInsertResult dbInsertDML;
            DBUpdateResult dbUpdateDML;
            DBDeleteResult dbDeleteDML;
            public DBSelectResult DbSelectDML { get => dbSelectDML; set => dbSelectDML = value; }
            public DBInsertResult DbInsertDML { get => dbInsertDML; set => dbInsertDML = value; }
            public DBUpdateResult DbUpdateDML { get => dbUpdateDML; set => dbUpdateDML = value; }
            public DBDeleteResult DbDeleteDML { get => dbDeleteDML; set => dbDeleteDML = value; }
            public string BeginTransaction()
            {
                Transactionflag = true;
                string status = string.Empty;
                // Start a local transaction
                try
                {
                    status = Open();
                    transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    cmd.Transaction = transaction;
                    return status;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            public string Commit()
            {
                try
                {
                    cmd.Transaction.Commit();
                    //transaction.Commit();

                    conn.Dispose();
                    conn.Close();

                    Transactionflag = false;
                    _TRANSACTION_STATUS = "successfully Commited";

                    return _TRANSACTION_STATUS;
                    //Type obj = typeof(T);
                    //var prop = obj.GetProperty("TRANSACTION_STATUS");
                    //prop.SetValue(OraDML, "COMMITED");
                }
                catch (Exception ex) { return ex.Message; }

            }
            public string Commit(ref DbCon con)
            {
                try
                {
                    //con.cmd.Transaction.Commit();
                    transaction.Commit();

                    conn.Dispose();
                    conn.Close();

                    Transactionflag = false;
                    return "successfully Commited";
                    //Type obj = typeof(T);
                    //var prop = obj.GetProperty("TRANSACTION_STATUS");
                    //prop.SetValue(OraDML, "COMMITED");
                }
                catch (Exception ex) { return ex.Message; }

            }
            
            public string Rollback()
            {
                transaction.Rollback();

                conn.Dispose();
                conn.Close();

                Transactionflag = false;
                
                _TRANSACTION_STATUS = "successfully Rollbacked";

                return _TRANSACTION_STATUS;
               
            }
            public string Rollback<T>(ref T OraDML)
            {
                transaction.Rollback();

                conn.Dispose();
                conn.Close();

                Transactionflag = false;

                Type obj = typeof(T);
                if (obj.Name == "DBInsertResult")
                {
                    //dbInsertDML.INSERT.Count = cmd.ExecuteNonQuery();
                    //dbInsertDML.INSERT.OraErrFlg = false;
                    DbInsertDML.INSERT.OraErr = "CANCELED";
                    DbInsertDML.INSERT.MessagePrompt = "successfully Rollbacked";
                    DbInsertDML.TRANSACTION_STATUS = "ROLLBACKED";
                }

                if (obj.Name == "dbUpdateDML")
                {
                    //dbUpdateDML.UPDATE.Count = cmd.ExecuteNonQuery();
                    //dbUpdateDML.UPDATE.OraErrFlg = false;
                    DbUpdateDML.UPDATE.OraErr = "CANCELED";
                    DbUpdateDML.UPDATE.MessagePrompt = "successfully Rollbacked";
                    DbUpdateDML.TRANSACTION_STATUS = "ROLLBACKED";

                }

                if (obj.Name == "dbDeleteDML")
                {
                    //dbDeleteDML.DELETE.Count = cmd.ExecuteNonQuery();
                    //dbDeleteDML.DELETE.OraErrFlg = false;
                    DbDeleteDML.DELETE.OraErr = "CANCELED";
                    DbDeleteDML.DELETE.MessagePrompt = "successfully Rollbacked";
                    DbDeleteDML.TRANSACTION_STATUS = "ROLLBACKED";
                }

                return "successfully Rollbacked";
            }
            static bool ExactMatch(string input, QueryType queryType)
            {
                string match = string.Empty;
                bool errFlg = false;
                if (queryType == QueryType.SELECT)
                {
                    match = "SELECT";
                    errFlg = Regex.IsMatch(input, string.Format(@"\b{0}\b", Regex.Escape(match)));
                }
                if (queryType == QueryType.INSERT)
                {
                    match = "INSERT";
                    string match1 = "MERGE";
                    errFlg = Regex.IsMatch(input, string.Format(@"\b{0}\b", Regex.Escape(match))) || Regex.IsMatch(input, string.Format(@"\b{0}\b", Regex.Escape(match1)));
                }
                if (queryType == QueryType.UPDATE)
                {
                    match = "UPDATE";
                    errFlg = Regex.IsMatch(input, string.Format(@"\b{0}\b", Regex.Escape(match)));
                }
                if (queryType == QueryType.DELETE)
                {
                    match = "DELETE";
                    errFlg = Regex.IsMatch(input, string.Format(@"\b{0}\b", Regex.Escape(match)));
                }
                try
                {
                    if (!errFlg)
                    {
                        throw new UsingTypeException("Query Type is mismatched with your SQL Statement.");
                    }
                }
                catch (UsingTypeException ex)
                {
                    throw new UsingTypeException(ex.Message);
                }
                return errFlg;
            }
            public T OraDML<T>(QueryType QType, UsingType UType, string cmdQuery, int RowSize)
            {
                if (!Transactionflag)
                {
                    conn = new OracleConnection(Connection.ConnectionString);
                }
                string cmdArr = cmdQuery.ToUpper();
                try
                {
                    ExactMatch(cmdArr, QType);
                }
                catch (UsingTypeException ex)
                {
                    throw new UsingTypeException(ex.Message);
                }

                #region queryType SELECT

                if (QType == QueryType.SELECT)
                {
                    //dbSelectDML = new DBSelectResult();

                    DbSelectDML.QUERY = cmdArr;
                    #region usingType DataAdapter  
                    if (UType == UsingType.DataAdapter)
                    {
                        OracleDataAdapter ODA = new OracleDataAdapter();
                        //if (!Transactionflag)
                        //{
                        //    cmd = new OracleCommand();
                        //}
                        cmd.CommandText = cmdArr;
                        try
                        {
                            DbSelectDML.ConnectionState = Open();

                            cmd.Connection = conn;

                            OracleDataAdapter adapter = new OracleDataAdapter();
                            adapter.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);


                            DbSelectDML.SELECT.OraErrFlg = false;
                            try { DbSelectDML.SELECT.RowCount = dt.Rows.Count; } catch { DbSelectDML.SELECT.RowCount = 0; }
                            if (dt.Rows.Count > 0)
                            {
                                DbSelectDML.SELECT.ReaderDT = new DataTable();
                                DbSelectDML.SELECT.ReaderDT = dt;
                                //dbSelectDML.SELECT.ReaderJSon = JsonConvert.SerializeObject(dbSelectDML.SELECT.ReaderDT);
                            }
                            if (!Transactionflag)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();
                                    conn.Dispose();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            DbSelectDML.SELECT.OraErrFlg = true;
                            DbSelectDML.SELECT.OraErr = ex.Message;
                            DbSelectDML.SELECT.RowCount = -1;
                            //conn.Dispose();
                            if (!Transactionflag)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();
                                    conn.Dispose();
                                }
                            }
                            string err = ex.ToString();
                            throw new Exception(err);

                        }

                        return (T)(object)DbSelectDML;
                    }
                    #endregion

                    #region usingType DataReader
                    else if (UType == UsingType.DataReader)
                    {
                        try
                        {
                            DbSelectDML.ConnectionState = Open();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }

                        try
                        {
                            //if (!Transactionflag)
                            //{
                            //    cmd = new OracleCommand();
                            //}
                            cmd.CommandText = cmdArr;
                            //cmd = new OracleCommand();
                            //OracleCommand cmd = new OracleCommand(cmdArr);
                            cmd.Connection = conn;

                            DbSelectDML.SELECT.Reader = cmd.ExecuteReader();


                            DbSelectDML.SELECT.Reader.FetchSize = cmd.RowSize * RowSize;

                            DbSelectDML.SELECT.OraErrFlg = false;


                            DbSelectDML.SELECT.VisFC = DbSelectDML.SELECT.Reader.VisibleFieldCount;
                            DbSelectDML.SELECT.HidFC = DbSelectDML.SELECT.Reader.HiddenFieldCount;

                            

                            if (DbSelectDML.SELECT.Reader.HasRows)
                            {
                                DbSelectDML.SELECT.ReaderDT = new DataTable();

                                DbSelectDML.SELECT.ReaderDT.Load(DbSelectDML.SELECT.Reader);

                                try { DbSelectDML.SELECT.RowCount = DbSelectDML.SELECT.ReaderDT.Rows.Count; } catch { DbSelectDML.SELECT.RowCount = 0; }
                                //dbSelectDML.SELECT.Dtr = dbSelectDML.SELECT.ReaderDT.CreateDataReader();

                                //dbSelectDML.SELECT.ReaderJSon = JsonConvert.SerializeObject(dbSelectDML.SELECT.ReaderDT);
                            }

                            if (!Transactionflag)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();
                                    conn.Dispose();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            DbSelectDML.SELECT.OraErrFlg = true;
                            DbSelectDML.SELECT.OraErr = ex.Message;
                            DbSelectDML.SELECT.RowCount = -1;
                            //conn.Dispose();
                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                                conn.Dispose();
                            }
                            throw new Exception(ex.Message);

                        }
                        return (T)(object)DbSelectDML;
                    }
                    else
                    {
                        return (T)(object)DbSelectDML;
                    }
                    #endregion
                }
                #endregion
                else
                {


                    #region queryType INSERT
                    if (QType == QueryType.INSERT)
                    {

                        try
                        {

                            //dbInsertDML = new DBInsertResult();
                            DbInsertDML.ConnectionState = Open();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        //if (!Transactionflag)
                        //{                           
                        //    cmd = new OracleCommand();
                        //}
                        //cmd = new OracleCommand();
                        cmd.Connection = conn;


                        try
                        {
                            DbInsertDML.QUERY = cmdArr;
                            cmd.CommandText = DbInsertDML.QUERY;
                            DbInsertDML.INSERT.Count = cmd.ExecuteNonQuery();

                            DbInsertDML.INSERT.OraErrFlg = false;
                            DbInsertDML.INSERT.OraErr = "SUCCESS";

                            if (!Transactionflag)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();
                                    conn.Dispose();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            DbInsertDML.INSERT.OraErrFlg = true;
                            DbInsertDML.INSERT.OraErr = ex.Message;
                            DbInsertDML.INSERT.MessagePrompt = "Faild to Insert";

                            transaction.Rollback();
                            DbInsertDML.TRANSACTION_STATUS = "ROLLBACK";
                            if (!Transactionflag)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Dispose();
                                    conn.Close();
                                }
                            }
                            return (T)(object)DbInsertDML;
                        }
                        return (T)(object)DbInsertDML;
                    }
                    #endregion

                    #region queryType UPDATE
                    else if (QType == QueryType.UPDATE)
                    {

                        try
                        {

                            //dbUpdateDML = new DBUpdateResult();
                            DbUpdateDML.ConnectionState = Open();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        //if (!Transactionflag)
                        //{
                        //    cmd = new OracleCommand();
                        //}
                        //cmd = new OracleCommand();
                        cmd.Connection = conn;


                        try
                        {
                            DbUpdateDML.QUERY = cmdArr;
                            cmd.CommandText = DbUpdateDML.QUERY;
                           


                            DbUpdateDML.UPDATE.Count = cmd.ExecuteNonQuery();
                            DbUpdateDML.UPDATE.OraErrFlg = false;

                            if (!Transactionflag)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();
                                    conn.Dispose();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            DbUpdateDML.UPDATE.OraErrFlg = true;
                            DbUpdateDML.UPDATE.OraErr = ex.Message;
                            DbUpdateDML.UPDATE.MessagePrompt = "Faild to Update";
                            DbUpdateDML.UPDATE.Count = -1;

                           DbUpdateDML.TRANSACTION_STATUS = "ROLLBACK";
                            if (!Transactionflag)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Dispose();
                                    conn.Close();
                                    return (T)(object)DbUpdateDML;
                                }
                            }
                        }
                        return (T)(object)DbUpdateDML;
                    }
                    #endregion

                    #region queryType DELETE
                    else if (QType == QueryType.DELETE)
                    {

                        DbDeleteDML.ConnectionState = Open();

                        try
                        {
                            DbDeleteDML.QUERY = cmdArr;
                            cmd.CommandText = DbDeleteDML.QUERY;
                            cmd.Connection = conn;

                            DbDeleteDML.DELETE.Count = cmd.ExecuteNonQuery();
                            DbDeleteDML.DELETE.OraErrFlg = false;

                            if (!Transactionflag)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();
                                    conn.Dispose();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            DbDeleteDML.DELETE.OraErrFlg = true;
                            DbDeleteDML.DELETE.OraErr = ex.Message;
                            DbDeleteDML.DELETE.MessagePrompt = "Faild to Delete";
                            DbDeleteDML.DELETE.Count = -1;
                            //Trans.Rollback();
                            DbDeleteDML.TRANSACTION_STATUS = "ROLLBACK";

                            conn.Dispose();
                            conn.Close();
                            return (T)(object)DbDeleteDML;
                        }
                        return (T)(object)DbDeleteDML;
                    }
                    #endregion
                    else
                    {
                        return (T)(object)null;
                    }

                }
            }

        }
    }

    namespace SQLServerDBCon
    {
        using System.Data.SqlClient;

        /// <summary>
        /// UsingType retrive data either by DataAdater or by DataReader
        /// </summary>
        public enum UsingType
        {
            DataAdapter, DataReader
        }

        /// <summary>
        /// QueryType Represnts the CRUD (SELECT,INSERT,UPDATE,DELETE) Operation Types.
        /// </summary>
        public enum QueryType
        {
            SELECT, INSERT, UPDATE, DELETE, PROCEDURE
        }

        /// <summary>
        /// Common Return type of Query Output
        /// </summary>
        public interface IResult
        {
            string ConnectionState { get; set; }
            string TRANSACTION_STATUS { get; set; }
            string QUERY { get; set; }
        }

        /// <summary>
        /// Hold output of SELECT Query
        /// </summary>
        public class SELECT
        {
            private SqlDataReader _reader;
            private string _OraErr;
            private bool _OraErrFlg;
            private int _visFC;
            private int _hidFC;
            private string _readerJSon;
            private DataTable _readerDT;
            private DataTableReader _dtr;
            public SqlDataReader Reader
            {
                get
                {
                    return _reader;
                }

                set
                {
                    _reader = value;
                }
            }
            public string OraErr
            {
                get
                {
                    return _OraErr;
                }

                set
                {
                    _OraErr = value;
                }
            }
            public int VisFC
            {
                get
                {
                    return _visFC;
                }

                set
                {
                    _visFC = value;
                }
            }
            public int HidFC
            {
                get
                {
                    return _hidFC;
                }

                set
                {
                    _hidFC = value;
                }
            }
            public string ReaderJSon
            {
                get
                {
                    return _readerJSon;
                }

                set
                {
                    _readerJSon = value;
                }
            }
            public bool OraErrFlg
            {
                get
                {
                    return _OraErrFlg;
                }

                set
                {
                    _OraErrFlg = value;
                }
            }
            public DataTable ReaderDT
            {
                get
                {
                    return _readerDT;
                }

                set
                {
                    _readerDT = value;
                }
            }
            public DataTableReader Dtr
            {
                get
                {
                    return _dtr;
                }

                set
                {
                    _dtr = value;
                }
            }

            private int _rowCount;
            public int RowCount { get => _rowCount; set => _rowCount = value; }
        }

        /// <summary>
        /// Hold output of INSERT Query
        /// </summary>
        public class INSERT
        {
            private string _OraErr;
            private int _count = 0;
            private string _messagePrompt = " Records is/are Successfully Inserted";
            private bool _OraErrFlg;
            public string MessagePrompt
            {
                get
                {
                    return Count.ToString() + _messagePrompt;
                }

                set
                {
                    _messagePrompt = value;
                }
            }
            public string OraErr
            {
                get
                {
                    return _OraErr;
                }

                set
                {
                    _OraErr = value;
                }
            }
            public int Count
            {
                get
                {
                    return _count;
                }

                set
                {
                    _count = value;
                }
            }
            public bool OraErrFlg
            {
                get
                {
                    return _OraErrFlg;
                }

                set
                {
                    _OraErrFlg = value;
                }
            }
        }

        /// <summary>
        /// Hold output of UPDATE Query
        /// </summary>
        public class UPDATE
        {
            private string _OraErr;
            private bool _OraErrFlg;
            private int _count = 0;
            private string _messagePrompt = " Records is/are Successfully Updated";

            public bool OraErrFlg
            {
                get
                {
                    return _OraErrFlg;
                }

                set
                {
                    _OraErrFlg = value;
                }
            }
            public string MessagePrompt
            {
                get
                {
                    return Count.ToString() + _messagePrompt;
                }

                set
                {
                    _messagePrompt = value;
                }
            }
            public string OraErr
            {
                get
                {
                    return _OraErr;
                }

                set
                {
                    _OraErr = value;
                }
            }
            public int Count
            {
                get
                {
                    return _count;
                }

                set
                {
                    _count = value;
                }
            }

        }

        /// <summary>
        /// Hold output of DELETE Query
        /// </summary>
        public class DELETE
        {
            private string _OraErr;
            private bool _OraErrFlg;
            private int _count = 0;
            private string _messagePrompt = " Records is/are Successfully Deleted";

            public bool OraErrFlg
            {
                get
                {
                    return _OraErrFlg;
                }

                set
                {
                    _OraErrFlg = value;
                }
            }
            public string MessagePrompt
            {
                get
                {
                    return Count.ToString() + _messagePrompt;
                }

                set
                {
                    _messagePrompt = value;
                }
            }
            public string OraErr
            {
                get
                {
                    return _OraErr;
                }

                set
                {
                    _OraErr = value;
                }
            }
            public int Count
            {
                get
                {
                    return _count;
                }

                set
                {
                    _count = value;
                }
            }
        }

        /// <summary>
        /// Return output of Select Query
        /// </summary>
        public class DBSelectResult : IResult
        {
            public string TRANSACTION_STATUS { get; set; }
            public string QUERY { get; set; }
            public string ConnectionState { get; set; }

            SELECT _SELECT;
            public SELECT SELECT { get => _SELECT; set => _SELECT = value; }

            QueryType _QUERY_TYPE = QueryType.SELECT;
            public QueryType QUERY_TYPE { get => _QUERY_TYPE; }

            public DBSelectResult()
            {
                SELECT = new SELECT();
            }
        }

        /// <summary>
        /// Return output of INSERT Query
        /// </summary>
        public class DBInsertResult : IResult
        {

            public string TRANSACTION_STATUS { get; set; }
            public string QUERY { get; set; }
            public string ConnectionState { get; set; }

            INSERT _INSERT;
            public INSERT INSERT { get => _INSERT; set => _INSERT = value; }

            QueryType _QUERY_TYPE = QueryType.INSERT;
            public QueryType QUERY_TYPE { get => _QUERY_TYPE; }

            public DBInsertResult()
            {
                INSERT = new INSERT();
            }

        }

        /// <summary>
        /// Return output of UPDATE Query
        /// </summary>
        public class DBUpdateResult : IResult
        {

            public string TRANSACTION_STATUS { get; set; }
            public string QUERY { get; set; }
            public string ConnectionState { get; set; }

            UPDATE _UPDATE;
            public UPDATE UPDATE { get => _UPDATE; set => _UPDATE = value; }

            QueryType _QUERY_TYPE = QueryType.UPDATE;
            public QueryType QUERY_TYPE { get => _QUERY_TYPE; }

            public DBUpdateResult()
            {
                UPDATE = new UPDATE();
            }

        }

        /// <summary>
        /// Return output of DELETE Query
        /// </summary>
        public class DBDeleteResult : IResult
        {

            public string TRANSACTION_STATUS { get; set; }
            public string QUERY { get; set; }
            public string ConnectionState { get; set; }

            DELETE _DELETE;
            public DELETE DELETE { get => _DELETE; set => _DELETE = value; }

            QueryType _QUERY_TYPE = QueryType.DELETE;
            public QueryType QUERY_TYPE { get => _QUERY_TYPE; }

            public DBDeleteResult()
            {
                DELETE = new DELETE();
            }

        }

        /// <summary>
        /// Connection Class: Responsible for Sql Connection.
        /// </summary>
        public static class Connection
        {
            //public enum state
            //{
            //    connected, disconnected, suspended, resume
            //}


            static DBAdapterEnums.state _State = DBAdapterEnums.state.disconnected;
            public static DBAdapterEnums.state State { get => _State; set => _State = value; }
            //public enum status
            //{
            //    Success, Fail, Error, Waiting, Cancelled, ConnState
            //}

            public enum AuthenticationMode
            {
                Windows, Server
            }
            public static class Status
            {
                static DBAdapterEnums.status _Error;
                static Properties _Properties = new Properties();

                public static DBAdapterEnums.status Error { get => _Error; set => _Error = value; }

                public static Properties Properties
                {
                    get
                    {
                        if (_Error == DBAdapterEnums.status.ConnState)
                        {
                            _Properties.Text = "Connection State";
                            if (State == DBAdapterEnums.state.connected)
                                _Properties.LabelForeColor = Color.Green;
                            else
                                _Properties.LabelForeColor = Color.Gray;
                        }
                        else if (_Error == DBAdapterEnums.status.Success)
                        {
                            _Properties.Text = "Success";
                            _Properties.TextForeColor = Color.Green;
                            _Properties.LabelForeColor = Color.Black;
                        }
                        else if (_Error == DBAdapterEnums.status.Error)
                        {
                            _Properties.Text = "Error";
                            _Properties.TextForeColor = Color.Red;
                            _Properties.LabelForeColor = Color.Red;
                        }
                        else if (_Error == DBAdapterEnums.status.Fail)
                        {
                            _Properties.Text = "Fail";
                            _Properties.TextForeColor = Color.Red;
                            _Properties.LabelForeColor = Color.Red;
                        }
                        else if (_Error == DBAdapterEnums.status.Waiting)
                        {
                            _Properties.Text = "Waiting";
                            _Properties.LabelForeColor = Color.Black;
                            _Properties.LabelBackColor = Color.Yellow;
                            _Properties.TextForeColor = Color.Black;
                            _Properties.TextBackColor = Color.Yellow;
                        }
                        else if (_Error == DBAdapterEnums.status.Cancelled)
                        {
                            _Properties.Text = "Cancelled";
                            _Properties.LabelForeColor = Color.Gray;
                            _Properties.TextForeColor = Color.Gray;
                            _Properties.TextBackColor = Color.Empty;
                        }
                        else { return null; }
                        return _Properties;
                    }

                }
            }
            public class Properties
            {
                string _Label = string.Empty;
                string _Text = string.Empty;
                Color _LabelForeColor = Color.Empty;
                Color _LabelBackColor = Color.Empty;
                Color _TextForeColor = Color.Empty;
                Color _TextBackColor = Color.Empty;
                Color _ConnectionstringColor = Color.Blue;
                Color _ConnectionstringBackColor = Color.Empty;
                public string Label { get => _Label; set => _Label = value; }
                public string Text { get => _Text; set => _Text = value; }
                public Color LabelForeColor { get => _LabelForeColor; set => _LabelForeColor = value; }
                public Color LabelBackColor { get => _LabelBackColor; set => _LabelBackColor = value; }
                public Color TextForeColor { get => _TextForeColor; set => _TextForeColor = value; }
                public Color TextBackColor { get => _TextBackColor; set => _TextBackColor = value; }
                public Color ConnectionstringColor { get => _ConnectionstringColor; }
                public Color ConnectionstringBackColor { get => _ConnectionstringBackColor; }
            }

            static string server;
            static string database;
            static AuthenticationMode authenticationMode;
            static string user;
            static string pass;
            public static string Server { get => server; set => server = value; }
            public static string Database { get => database; set => database = value; }
            public static AuthenticationMode AuthMode { get => authenticationMode; set => authenticationMode = value; }
            public static string User { get => user; set => user = value; }
            public static string Password { get => pass; set => pass = value; }

            static string _Connectionstring;

            //static string _ConnectionState=string.Empty;
            public static string ConnectionString { get => _Connectionstring; set => _Connectionstring = value; }




            //public static string ConnectionState { get => _ConnectionState; set => _ConnectionState = value; }

            static SqlConnection conn;
            public static SqlConnection Conn()
            {
                if (conn == null)
                {
                    conn = new SqlConnection();
                }
                return conn;
            }
            public static void Connect()
            {

                string stat = string.Empty;
                string connectionstring = String.Empty;
                if (AuthMode == AuthenticationMode.Windows)
                {
                    connectionstring = String.Format(
                     "server={0};Integrated Security=SSPI;uid={2};pwd={3}; database={4}",
                     Server,
                     authenticationMode,
                     User,
                     Password,
                     Database);
                }
                if (AuthMode == AuthenticationMode.Server)
                {
                    connectionstring = String.Format(
                 "server={0};uid={2};pwd={3}; database={4}",
                 Server,
                 authenticationMode,
                 User,
                 Password,
                 Database);
                }
                try
                {
                    SqlConnection conn = Conn();

                    if (conn.State == System.Data.ConnectionState.Closed && State != DBAdapterEnums.state.connected)
                    {
                        try
                        {
                            conn.ConnectionString = connectionstring;
                            conn.Open();
                            stat = "Connected";
                            State = DBAdapterEnums.state.connected;
                            conn.Close();
                            ConnectionString = connectionstring;
                            Status.Error = DBAdapterEnums.status.ConnState;

                        }
                        catch (SqlException ex)
                        {
                            ConnectionString = string.Empty;
                            State = DBAdapterEnums.state.disconnected;
                            Status.Error = DBAdapterEnums.status.Fail;
                            conn.Close();
                            if (ex.Number == 1017)
                            {
                                stat = "Wrong credentials.";
                                //return status;
                            }
                            //Password expired.
                            else if (ex.Number == 28001)
                            {
                                stat = "Password expired.";
                                //return status;
                            }
                            //Acount is locked.
                            else if (ex.Number == 28000)
                            {
                                stat = "Account is locked.";
                                //return status;
                            }
                            else
                            {
                                stat = "An error occurred while attempting to connect." + Environment.NewLine + "Error: " + ex.ToString();
                                //return status;
                            }

                        }
                        catch (Exception ex)
                        {
                            Status.Error = DBAdapterEnums.status.Error;
                            ConnectionString = string.Empty;
                            //Transactionflag = false;
                            conn.Close();
                            stat = ex.ToString();
                        }

                    }
                    else
                    {
                        stat = "Already Connected.";
                        Status.Error = DBAdapterEnums.status.Error;
                    }
                }
                catch (SqlException ex)
                {
                    ConnectionString = string.Empty;
                    State = DBAdapterEnums.state.disconnected;
                    Status.Error = DBAdapterEnums.status.Fail;
                    stat = ex.ToString();
                }
                catch (Exception ex)
                {
                    Status.Error = DBAdapterEnums.status.Error;
                    ConnectionString = string.Empty;
                    State = DBAdapterEnums.state.disconnected;
                    stat = ex.ToString();
                }
                finally
                {
                    //ConnectionState = status;
                    Status.Properties.Label = stat;
                }
            }
            public static void Connect(string server, AuthenticationMode authenticationMode, string user, string pass, string database)
            {
                Server = server;
                User = user;
                Password = pass;
                Database = database;

                string stat = string.Empty;

                string connectionstring = string.Empty;

                if (authenticationMode == AuthenticationMode.Windows)
                {
                    connectionstring = String.Format(
                     "server={0};Integrated Security=SSPI;uid={2};pwd={3}; database={4}",
                     Server,
                     authenticationMode,
                     User,
                     Password,
                     Database);
                }
                if (authenticationMode == AuthenticationMode.Server)
                {
                    connectionstring = String.Format(
                 "server={0};uid={2};pwd={3}; database={4}",
                 Server,
                 authenticationMode,
                 User,
                 Password,
                 Database);
                }
                //string connectionstring = String.Format(
                //  "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
                //  "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
                //  Host,
                //  Port,
                //  Servicename,
                //  User,
                //  Password);

                try
                {
                    SqlConnection conn = Conn();

                    if (conn.State == System.Data.ConnectionState.Closed && State != DBAdapterEnums.state.connected)
                    {
                        try
                        {
                            conn.ConnectionString = connectionstring;
                            conn.Open();
                            stat = "Connected";
                            State = DBAdapterEnums.state.connected;
                            conn.Close();
                            ConnectionString = connectionstring;
                            Status.Error = DBAdapterEnums.status.Success;

                        }
                        catch (SqlException ex)
                        {
                            ConnectionString = string.Empty;
                            State = DBAdapterEnums.state.disconnected;
                            Status.Error = DBAdapterEnums.status.Fail;
                            conn.Close();
                            if (ex.Number == 1017)
                            {
                                stat = "Wrong credentials.";
                                //return status;
                            }
                            //Password expired.
                            else if (ex.Number == 28001)
                            {
                                stat = "Password expired.";
                                //return status;
                            }
                            //Acount is locked.
                            else if (ex.Number == 28000)
                            {
                                stat = "Account is locked.";
                                //return status;
                            }
                            else
                            {
                                stat = "An error occurred while attempting to connect." + Environment.NewLine + "Error: " + ex.ToString();
                                //return status;
                            }

                        }
                        catch (Exception ex)
                        {
                            Status.Error = DBAdapterEnums.status.Error;
                            ConnectionString = string.Empty;
                            //Transactionflag = false;
                            conn.Close();
                            stat = ex.ToString();
                        }

                    }
                    else
                    {
                        stat = "Already Connected.";
                        Status.Error = DBAdapterEnums.status.Error;
                    }
                }
                catch (SqlException ex)
                {
                    ConnectionString = string.Empty;
                    State = DBAdapterEnums.state.disconnected;
                    Status.Error = DBAdapterEnums.status.Fail;
                    stat = ex.ToString();
                }
                catch (Exception ex)
                {
                    Status.Error = DBAdapterEnums.status.Error;
                    ConnectionString = string.Empty;
                    State = DBAdapterEnums.state.disconnected;
                    stat = ex.ToString();
                }
                finally
                {
                    //ConnectionState = status;
                    Status.Properties.Label = stat;
                }
            }
            public static string SQLServerTestCon(string host, string port, string servicename, string user, string pass)
            {
                string connectionstring = String.Format(
                  "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
                  "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
                  host,
                  port,
                  servicename,
                  user,
                  pass);

                //connectionstring = @"User Id=" + user + @";Password=" + pass + @";Data Source= " + connectionstring;
                try
                {
                    SqlConnection conn = new SqlConnection(connectionstring);



                    string status = string.Empty;
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        try
                        {
                            conn.Open();
                            status = "Connection Open";
                            conn.Close();

                        }
                        catch (SqlException ex)
                        {
                            conn.Close();
                            if (ex.Number == 1017)
                            {
                                status = "Wrong credentials.";
                                //return status;
                            }
                            //Password expired.
                            else if (ex.Number == 28001)
                            {
                                status = "Password expired.";
                                //return status;
                            }
                            //Acount is locked.
                            else if (ex.Number == 28000)
                            {
                                status = "Account is locked.";
                                //return status;
                            }
                            else
                            {
                                status = "An error occurred while attempting to connect." + Environment.NewLine + "Error: " + ex.ToString();
                                //return status;
                            }
                            return status;
                        }
                        catch (Exception ex)
                        {
                            //Transactionflag = false;
                            conn.Close();
                            status = ex.ToString();
                            return status;

                        }
                        return status;
                    }
                    else
                    {
                        status = "Connection already Open";

                        return status;
                    }
                }
                catch (SqlException ex)
                {
                    return ex.ToString();
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }

            public static void Disconnect()
            {
                if (State != DBAdapterEnums.state.disconnected)
                {
                   
                    conn.ConnectionString = string.Empty;
                    Server = string.Empty;
                    //authenticationMode = AuthMode.
                    Database = string.Empty;
                    User = string.Empty;
                    Password = string.Empty; 
                     State = DBAdapterEnums.state.disconnected;
                    Status.Properties.Label = "Disconnected.";
                    Status.Error = DBAdapterEnums.status.ConnState;

                }
                else
                {
                    Status.Properties.Label = "Already Disconnected.";
                    Status.Error = DBAdapterEnums.status.ConnState;
                }
            }
        }

        /// <summary>
        /// DBAdapter Exception
        /// </summary>
        public class UsingTypeException : Exception
        {
            public UsingTypeException(String message) : base(message)
            {

            }
        }

        /// <summary>
        /// DbCon is responsible for DML,DQL,TCL 
        /// </summary>
        public class DbCon
        {
            public UsingType UType { get; set; }
            public UsingType QType { get; set; }


            private bool _transactionflag = false;
            public bool Transactionflag
            {
                get
                {
                    return _transactionflag;
                }

                set
                {
                    _transactionflag = value;
                }
            }

            public string TRANSACTION_STATUS { get => _TRANSACTION_STATUS; set => _TRANSACTION_STATUS = value; }
           

            private string _TRANSACTION_STATUS;

            SqlCommand cmd;
            SqlConnection conn;

            public DbCon()
            {
                conn = new SqlConnection();
                conn.ConnectionString = Connection.ConnectionString;
                Update = new DBUpdateResult();
                Select = new DBSelectResult();
                Insert = new DBInsertResult();
                Delete = new DBDeleteResult();
                cmd = new SqlCommand();
            }
            public string Open()
            {
                string status = string.Empty;
              
                if (conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        conn.ConnectionString = Connection.ConnectionString;
                        conn.Open();
                        status = "Connection Open";
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 1017)
                        {
                            status = "Wrong credentials.";
                            //return status;
                        }
                        //Password expired.
                        else if (ex.Number == 28001)
                        {
                            status = "Password expired.";
                            //return status;
                        }
                        //Acount is locked.
                        else if (ex.Number == 28000)
                        {
                            status = "Account is locked.";
                            //return status;
                        }
                        else
                        {
                            status = "An error occurred while attempting to connect." + Environment.NewLine + "Error: " + ex.ToString();
                            //return status;
                        }
                        throw new Exception(status);
                    }
                    catch (Exception ex)
                    {
                        //Transactionflag = false;
                        status = ex.ToString();

                        throw new Exception(status);
                        //return status;

                    }
                    finally
                    {
                        //Connection.ConnectionState = status;
                    }
                    return status;
                }
                else
                {
                    status = "Connection Open";
                    return status;
                }
            }


            SqlTransaction transaction;
            DBSelectResult dbSelectDML;
            DBInsertResult dbInsertDML;
            DBUpdateResult dbUpdateDML;
            DBDeleteResult dbDeleteDML;

            public DBSelectResult Select { get => dbSelectDML; set => dbSelectDML = value; }
            public DBInsertResult Insert { get => dbInsertDML; set => dbInsertDML = value; }
            public DBUpdateResult Update { get => dbUpdateDML; set => dbUpdateDML = value; }
            public DBDeleteResult Delete { get => dbDeleteDML; set => dbDeleteDML = value; }
            public string BeginTransaction()
            {
                Transactionflag = true;
                string status = string.Empty;
                // Start a local transaction
                try
                {
                    status = Open();
                    transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    cmd.Transaction = transaction;
                    return status;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            public string Commit()
            {
                try
                {
                    cmd.Transaction.Commit();
                   
                    conn.Dispose();
                    conn.Close();

                    Transactionflag = false;
                    _TRANSACTION_STATUS = "successfully Commited";

                    return _TRANSACTION_STATUS;
                 
                }
                catch (Exception ex) { return ex.Message; }

            }

         
            public string Rollback()
            {
                cmd.Transaction.Rollback();
              
                conn.Dispose();
                conn.Close();

                Transactionflag = false;


                _TRANSACTION_STATUS = "successfully Rollbacked";

                return _TRANSACTION_STATUS;

            }

        

            static bool ExactMatch(string input, QueryType queryType)
            {
                string match = string.Empty;
                bool errFlg = false;
                if (queryType == QueryType.SELECT)
                {
                    match = "SELECT";
                    errFlg = Regex.IsMatch(input, string.Format(@"\b{0}\b", Regex.Escape(match)));
                }
                if (queryType == QueryType.INSERT)
                {
                    match = "INSERT";
                    string match1 = "MERGE";
                    errFlg = Regex.IsMatch(input, string.Format(@"\b{0}\b", Regex.Escape(match))) || Regex.IsMatch(input, string.Format(@"\b{0}\b", Regex.Escape(match1)));
                }
                if (queryType == QueryType.UPDATE)
                {
                    match = "UPDATE";
                    errFlg = Regex.IsMatch(input, string.Format(@"\b{0}\b", Regex.Escape(match)));
                }
                if (queryType == QueryType.DELETE)
                {
                    match = "DELETE";
                    errFlg = Regex.IsMatch(input, string.Format(@"\b{0}\b", Regex.Escape(match)));
                }
                try
                {
                    if (!errFlg)
                    {
                        throw new UsingTypeException("Query Type is mismatched with your SQL Statement.");
                    }
                }
                catch (UsingTypeException ex)
                {
                    throw new UsingTypeException(ex.Message);
                }
                return errFlg;
            }
            public T SqlDML<T>(QueryType QType, UsingType UType, string cmdQuery)
            {
                if (!Transactionflag)
                {
                    conn = new SqlConnection(Connection.ConnectionString);
                }
                string cmdArr = cmdQuery.ToUpper();
                try
                {
                    ExactMatch(cmdArr, QType);
                }
                catch (UsingTypeException ex)
                {
                    throw new UsingTypeException(ex.Message);
                }

               
                #region queryType SELECT

                if (QType == QueryType.SELECT)
                {
                   
                    Select.QUERY = cmdArr;
                    #region usingType DataAdapter  
                    if (UType == UsingType.DataAdapter)
                    {
                       
                        cmd.CommandText = cmdArr;
                        try
                        {
                            Select.ConnectionState = Open();

                            cmd.Connection = conn;

                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);


                            Select.SELECT.OraErrFlg = false;
                            try { Select.SELECT.RowCount = dt.Rows.Count; } catch { Select.SELECT.RowCount = 0; }
                            if (dt.Rows.Count > 0)
                            {
                                Select.SELECT.ReaderDT = new DataTable();
                                Select.SELECT.ReaderDT = dt;
                                //dbSelectDML.SELECT.ReaderJSon = JsonConvert.SerializeObject(dbSelectDML.SELECT.ReaderDT);
                            }
                            if (!Transactionflag)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();
                                    conn.Dispose();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Select.SELECT.OraErrFlg = true;
                            Select.SELECT.OraErr = ex.Message;
                            Select.SELECT.RowCount = -1;
                            //conn.Dispose();
                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                                conn.Dispose();
                            }
                            string err = ex.ToString();
                            throw new Exception(err);

                        }

                        return (T)(object)Select;
                    }
                    #endregion

                    #region usingType DataReader
                    else if (UType == UsingType.DataReader)
                    {
                        try
                        {
                            Select.ConnectionState = Open();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }

                        try
                        {
                         
                            cmd.CommandText = cmdArr;
                       
                            cmd.Connection = conn;

                            Select.SELECT.Reader = cmd.ExecuteReader();



                            Select.SELECT.OraErrFlg = false;


                            Select.SELECT.VisFC = Select.SELECT.Reader.VisibleFieldCount;
                         
                            if (Select.SELECT.Reader.HasRows)
                            {
                                Select.SELECT.ReaderDT = new DataTable();

                                Select.SELECT.ReaderDT.Load(Select.SELECT.Reader);

                                try { Select.SELECT.RowCount = Select.SELECT.ReaderDT.Rows.Count; } catch { Select.SELECT.RowCount = 0; }
                                //dbSelectDML.SELECT.Dtr = dbSelectDML.SELECT.ReaderDT.CreateDataReader();

                                //dbSelectDML.SELECT.ReaderJSon = JsonConvert.SerializeObject(dbSelectDML.SELECT.ReaderDT);
                            }

                            if (!Transactionflag)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();
                                    conn.Dispose();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Select.SELECT.OraErrFlg = true;
                            Select.SELECT.OraErr = ex.Message;
                            Select.SELECT.RowCount = -1;
                           
                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                                conn.Dispose();
                            }
                            throw new Exception(ex.Message);

                        }
                        return (T)(object)Select;
                    }
                    else
                    {
                        return (T)(object)Select;
                    }
                    #endregion
                }
                #endregion
                else
                {


                    #region queryType INSERT
                    if (QType == QueryType.INSERT)
                    {

                        try
                        {
                            Insert.ConnectionState = Open();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                      
                        cmd.Connection = conn;


                        try
                        {
                            Insert.QUERY = cmdArr;
                            cmd.CommandText = Insert.QUERY;
                            Insert.INSERT.Count = cmd.ExecuteNonQuery();

                            Insert.INSERT.OraErrFlg = false;
                            Insert.INSERT.OraErr = "SUCCESS";

                            if (!Transactionflag)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();
                                    conn.Dispose();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Insert.INSERT.OraErrFlg = true;
                            Insert.INSERT.OraErr = ex.Message;
                            Insert.INSERT.MessagePrompt = "Faild to Insert";

                            transaction.Rollback();
                            Insert.TRANSACTION_STATUS = "ROLLBACK";

                            conn.Dispose();
                            conn.Close();
                            return (T)(object)Insert;
                        }
                        return (T)(object)Insert;
                    }
                    #endregion

                    #region queryType UPDATE
                    else if (QType == QueryType.UPDATE)
                    {

                        try
                        {
                            Update.ConnectionState = Open();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                     
                        cmd.Connection = conn;


                        try
                        {
                            Update.QUERY = cmdArr;
                            cmd.CommandText = Update.QUERY;

                            Update.UPDATE.Count = cmd.ExecuteNonQuery();
                            Update.UPDATE.OraErrFlg = false;

                            if (!Transactionflag)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();
                                    conn.Dispose();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Update.UPDATE.OraErrFlg = true;
                            Update.UPDATE.OraErr = ex.Message;
                            Update.UPDATE.MessagePrompt = "Faild to Update";
                            Update.UPDATE.Count = -1;

                            Update.TRANSACTION_STATUS = "ROLLBACK";

                            conn.Dispose();
                            conn.Close();
                            return (T)(object)Update;
                        }
                        return (T)(object)Update;
                    }
                    #endregion

                    #region queryType DELETE
                    else if (QType == QueryType.DELETE)
                    {
                        
                        Delete.ConnectionState = Open();

                        try
                        {
                            Delete.QUERY = cmdArr;
                            cmd.CommandText = Delete.QUERY;
                            cmd.Connection = conn;

                            Delete.DELETE.Count = cmd.ExecuteNonQuery();
                            Delete.DELETE.OraErrFlg = false;

                            if (!Transactionflag)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();
                                    conn.Dispose();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Delete.DELETE.OraErrFlg = true;
                            Delete.DELETE.OraErr = ex.Message;
                            Delete.DELETE.MessagePrompt = "Faild to Delete";
                            Delete.DELETE.Count = -1;
                            //Trans.Rollback();
                            Delete.TRANSACTION_STATUS = "ROLLBACK";

                            conn.Dispose();
                            conn.Close();
                            return (T)(object)Delete;
                        }
                        return (T)(object)Delete;
                    }
                    #endregion
                    else
                    {
                        return (T)(object)null;
                    }

                }
            }

        }
    }
}
