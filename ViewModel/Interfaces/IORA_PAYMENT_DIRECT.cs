using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface IORA_PAYMENT_DIRECT
    {
       int ID {get;set;}
       string REFNO  {get;set;}
        string PREVREFNO {get;set;}
        bool IS_DUPLICATE {get;set;}
        string ORDER_ID {get;set;}
        string WEB_SERVICE_CODE {get;set;}
        string IN_SERVICE_CODE {get;set;}
        string WEB_SER_DESC {get;set;}
        string IN_SER_DESC {get;set;}
        string MEMBCODE {get;set;}
        string WEB_SER_TYPE {get;set;}
        string WEB_FUNC_DESC {get;set;}
        string WEB_SER_DESC_TYPE {get;set;}
        double  RATE {get;set;}
        string COUNTRY_TYPE {get;set;}
         int WEB_TAX_ID {get;set;}
        string USER_NAME {get;set;}
        string ADD1 {get;set;}
        string ADD2 {get;set;}
        string ADD3 {get;set;}
        string ADD4 {get;set;}
        string ADD5 {get;set;}
        string COUNTRY_RESIDENCE {get;set;}
        string NATIONALITY {get;set;}
        string COUNTRY_CODE {get;set;}
        string PIN {get;set;}
        string MOB {get;set;}
        string EMAIL {get;set;}
        string DOUNLOAD_TYPE {get;set;}
        string DOUNLOAD_FLAG {get;set;}
    }
}
