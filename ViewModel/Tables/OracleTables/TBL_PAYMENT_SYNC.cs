using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ViewModel.Tables.OracleTables
{
    public class TBL_PAYMENT_SYNC : IORA_PAYMENT_DIRECT
    {
        public int ID { get; set; }

        public string REFNO { get; set; }

        public string PREVREFNO { get; set; }

        public bool IS_DUPLICATE { get; set; }

        public string ORDER_ID { get; set; }

        public string WEB_SERVICE_CODE { get; set; }
        public string IN_SERVICE_CODE { get; set; }
        public string WEB_SER_DESC { get; set; }

        public string IN_SER_DESC { get; set; }

        public string MEMBCODE { get; set; }

        public string WEB_SER_TYPE { get; set; }

        public string WEB_FUNC_DESC { get; set; }
        public string WEB_SER_DESC_TYPE { get; set; }
        public double RATE { get; set; }

        public string COUNTRY_TYPE { get; set; }

        public int WEB_TAX_ID { get; set; }
        public string USER_NAME { get; set; }

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

        public string DOUNLOAD_TYPE { get; set; }

        public string DOUNLOAD_FLAG { get; set; }
    }
}
