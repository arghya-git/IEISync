using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{

    public interface IORA_TBL_MEMBER_MASTER
    {
         Int32 REG_ID { get; set; }
         string MEMBCODE { get; set; }
          string MEMB_IDENTITY { get; set; }
          string NAME { get; set; }
          string SFX { get; set; }
          string DOB { get; set; }
          string ADD1 { get; set; }
          string ADD2 { get; set; }
          string ADD3 { get; set; }
          string ADD4 { get; set; }
          string ADD5 { get; set; }
          string RES_COUNTRY { get; set; }
          string NATIONALITY { get; set; }
          string COUNTRY_CODE { get; set; }
          string PIN { get; set; }
          string MOBILE { get; set; }
          string EMAIL { get; set; }
          string GENDER { get; set; }
          string TEL_O { get; set; }
          string ELECTIONDATE { get; set; }
          string STATUS { get; set; }
          string DIVISION { get; set; }

          string CCODE { get; set; }
          DateTime? SYSDT { get; set; }

          string WEB_UPDN_FLAG { get; set; }
          string SALUTATION { get; set; }

          string UPDT_USR { get; set; }
          string UPDT_DT { get; set; }
          string IP_ADD { get; set; }
    }
    public interface IORA_PARTYMAST
    {
        string PARTYCODE { get; set; }
        string PARTYNAME { get; set; }
        string PARTYSURNAME { get; set; }
        string PARTYHOUSE { get; set; }
        string PARTYSTREET { get; set; }
        string PARTYCITY { get; set; }
        string PARTYSTATE { get; set; }
        string PARTYCOUNTRY { get; set; }
        string PIN { get; set; }
        string RESTEL { get; set; }
        string OFFTEL { get; set; }
        string TELEX { get; set; }
        string EMAILID { get; set; }
        string MOBILE { get; set; }
        string CATRGORY { get; set; }
        string TYPE { get; set; }
        string COUNTRYOFRES { get; set; }
        double DUEFEES { get; set; }
        string FEES { get; set; }
        string DATEOFPAY { get; set; }
        string RECSLNO { get; set; }
        string CL { get; set; }
        DateTime? DATE_STAMP { get; set; }
        string ID_STAMP { get; set; }
        DateTime? DATEOFENROL { get; set; }
        string SERVICECODE { get; set; }
        string CCODE { get; set; }
        DateTime? SYSDT { get; set; }
        DateTime? SYSDT1 { get; set; }
        string WEB_UPDT_FLG { get; set; }
        string SALUTATION { get; set; }
        string GENDER { get; set; }
        string NAME_SFX { get; set; }
        string MEMB_IDENTITY { get; set; }
        string UPDT_USR { get; set; }
        string IPADD { get; set; }
    }
}
