using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface ISQLSERVER_IEI_TBL_PAYMENT_VS_SERVICE
    {
       int PS_ID { get; set; }

       string RECSLNO{ get; set; }
        string SERVICE_CODE { get; set; }
        string SERVICE_STATE_CODE { get; set; }
        string PAY_DATE { get; set; }
        string PAY_STATUS { get; set; }
        string CAN_PAY { get; set; }
        string IS_DOWNLOAD { get; set; }
        string REMARKS { get; set; }
    }
    public interface ISQLSERVER_IEI_VIEW_PAYMENT_SYNC
    {
        string RECSLNO_MODIFIED { get; set; }
        string RECSLNO { get; set; }
      string ORDER_ID { get; set; }
        string SERVICE_CODE { get; set; }
        string SER_DESC { get; set; }
        string MEMBCODE { get; set; }
        string SER_TYPE { get; set; }
        string FUNC_DESC { get; set; }
        string SER_DESC_TYPE { get; set; }
        double RATE { get; set; }
        string COUNTRY_TYPE { get; set; }
        int TAX_ID { get; set; }
        string NAME { get; set; }
        string ADD1 { get; set; }
        string ADD2 { get; set; }
        string ADD3 { get; set; }
        string ADD4 { get; set; }
        string ADD5 { get; set; }
        string COUNTRY_RESIDENCE { get; set; }
        string NATIONALITY { get; set; }
        string COUNTRY_CODE { get; set; }
        string PIN { get; set; }
        string MOB { get; set; }
        string EMAIL { get; set; }
        string IS_DOWNLOAD { get; set; }
    }
    public interface ISQLSERVER_IEI_TBL_PARTY_MASTER
    {
        string PARTYCODE { get; set; }
        string MEMB_IDENTITY { get; set; }
        int LOGIN_ID { get; set; }
        string PARTY_NAME { get; set; }
        string SALUTATION { get; set; }
        string SFX { get; set; }
        string ADD1 { get; set; }
        string ADD2 { get; set; }
        string ADD3 { get; set; }
        string ADD4 { get; set; }
        string ADD5 { get; set; }
        string PIN { get; set; }
        string NATIONALITY { get; set; }
        string COUNTRY_RESIDENCE { get; set; }
         //string COUNTRY_NAME { get; set; }
        string GENDER { get; set; }
        string MOBILE { get; set; }
        string EMAIL { get; set; }
        string PHONE { get; set; }
        //DateTime DOB { get; set; }

        DateTime? DOB { get; set; }
        string CENTRE { get; set; }
        string DIVISION { get; set; }
        string SUBSCRIPTION_CATEGORY { get; set; }
        DateTime? ENROLEMENT_START_DT { get; set; }
        DateTime? ENROLEMENT_END_DT { get; set; }
        DateTime? SUBSCRIPTION_END_DT { get; set; }
        string MEMB_CATEGORY { get; set; }
        string MEMB_TYPE { get; set; }

        
        DateTime? GENERATE_DATE { get; set; }
        DateTime? UPLOAD_DATE { get; set; }
        string DOWNLOAD_FLAG { get; set; }
        string CL { get; set; }
        string REMARKS { get; set; }

        //DateTime ADD_CHANGE_DATE { get; set; }
    }
}
