using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ViewModel.StoreProcedure.SQLServerSPs
{
    public class SP_Sync_MembData_Result: ISP_Sync_MembData_Result
    {
        public string WEB_UPDT_FLG { get; set; }
        public int ERROR_CODE { get; set; }
        public string ERROR_DESC { get; set; }
        public string ERROR { get; set; }

        public string PARTYCODE { get; set; }
    }
}
