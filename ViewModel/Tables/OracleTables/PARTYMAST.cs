using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ViewModel.Tables.OracleTables

{


    public class TBL_MEMBER_MASTER : IORA_TBL_MEMBER_MASTER
    {
        public Int32 REG_ID { get; set; }
        public string MEMBCODE { get; set; }
        public string MEMB_IDENTITY { get; set; }
        public string NAME { get; set; }
        public string SFX { get; set; }
        public string DOB { get; set; }
        public string ADD1 { get; set; }
        public string ADD2 { get; set; }
        public string ADD3 { get; set; }
        public string ADD4 { get; set; }
        public string ADD5 { get; set; }
        public string RES_COUNTRY { get; set; }
        public string NATIONALITY { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string PIN { get; set; }
        public string MOBILE { get; set; }
        public string EMAIL { get; set; }
        public string GENDER { get; set; }
        public string TEL_O { get; set; }
        public string ELECTIONDATE { get; set; }
        public string STATUS { get; set; }
        public string DIVISION { get; set; }

        public string CCODE { get; set; }
        public DateTime? SYSDT { get; set; }

        public string WEB_UPDN_FLAG { get; set; }
        public string SALUTATION { get; set; }
        //public string NATIONALITY { get; set; }
        public string UPDT_USR { get; set; }
        public string UPDT_DT { get; set; }
        public string IP_ADD { get; set; }
    }
    public class PARTYMAST : IORA_PARTYMAST
    {
        public string PARTYCODE { get; set; }
        public string PARTYNAME { get; set; }
        public string PARTYSURNAME { get; set; }
        public string PARTYHOUSE { get; set; }
        public string PARTYSTREET { get; set; }
        public string PARTYCITY { get; set; }
        public string PARTYSTATE { get; set; }
        public string PARTYCOUNTRY { get; set; }
        public string PIN { get; set; }
        public string RESTEL { get; set; }
        public string OFFTEL { get; set; }
        public string TELEX { get; set; }
        public string EMAILID { get; set; }
        public string MOBILE { get; set; }
        public string CATRGORY { get; set; }
        public string TYPE { get; set; }
        public string COUNTRYOFRES { get; set; }
        public double DUEFEES { get; set; }
        public string FEES { get; set; }
        public string DATEOFPAY { get; set; }
        public string RECSLNO { get; set; }
        public string CL { get; set; }
        public DateTime? DATE_STAMP { get; set; }
        public string ID_STAMP { get; set; }
        public DateTime? DATEOFENROL { get; set; }
        public string SERVICECODE { get; set; }
        public string CCODE { get; set; }
        public DateTime? SYSDT { get; set; }
        public DateTime? SYSDT1 { get; set; }
        public string WEB_UPDT_FLG { get; set; }
        public string SALUTATION { get; set; }
        public string GENDER { get; set; }
        public string NAME_SFX { get; set; }
        public string MEMB_IDENTITY { get; set; }
        public string UPDT_USR { get; set; }
        public string IPADD { get; set; }
    }
}
