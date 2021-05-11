using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ViewModel.Tables.SQLServerTables
{
    public class IEI_TBL_PAYMENT_VS_SERVICE : ISQLSERVER_IEI_TBL_PAYMENT_VS_SERVICE
    {
        public int PS_ID { get; set; }

        public string RECSLNO { get; set; }

        public string SERVICE_CODE { get; set; }

        public string SERVICE_STATE_CODE { get; set; }

        public string PAY_DATE { get; set; }

        public string PAY_STATUS { get; set; }
        public string CAN_PAY { get; set; }

        public string IS_DOWNLOAD { get; set; }

        public string REMARKS { get; set; }
    }
    public class IEI_VIEW_PAYMENT_SYNC : ISQLSERVER_IEI_VIEW_PAYMENT_SYNC
    {
        public string RECSLNO_MODIFIED { get; set; }
        public string RECSLNO { get; set; }
        public string ORDER_ID { get; set; }
        public string SERVICE_CODE { get; set; }
        public string SER_DESC { get; set; }
        public string MEMBCODE { get; set; }
        public string SER_TYPE { get; set; }
        public string FUNC_DESC { get; set; }
        public string SER_DESC_TYPE { get; set; }
        public double RATE { get; set; }
        public string COUNTRY_TYPE { get; set; }
        public int TAX_ID { get; set; }
        public string NAME { get; set; }
        public string ADD1 { get; set; }
        public string ADD2 { get; set; }
        public string ADD3 { get; set; }
        public string ADD4 { get; set; }
        public string ADD5 { get; set; }
        public string COUNTRY_RESIDENCE { get; set; }
        public string NATIONALITY { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string PIN { get; set; }
        public string MOB { get; set; }
        public string EMAIL { get; set; }
        public string IS_DOWNLOAD { get; set; }
        public DateTime PAY_DATE { get; set; }
        public string PAY_STATUS { get; set; }

        public string PAYMENT_GATEWAY { get; set; }

        public int ISSUEBANK
        {
            get
            {
                return PAYMENT_GATEWAY == "HDFC_CCAVENUE" ? 52:55;
            }
        }

        
    }
}
