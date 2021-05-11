using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface ISP_Sync_MembData_Result
    {
        string WEB_UPDT_FLG { get; set; }
        int ERROR_CODE { get; set; }
        string ERROR_DESC { get; set; }
        string ERROR { get; set; }

        string PARTYCODE { get; set; }
    }
}
