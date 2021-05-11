using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface IIEI_TBL_TECH_PROG_HD
    {
        int PROG_HD_ID { get; set; }
        string PROG_TYPE_FLG { get; set; }
        string PROG_TYPE_DESC { get; set; }
        string PROG_TYPE { get; set; }
        string PROG_DESC { get; set; }
        string PROG_RULES1 { get; set; }
        string PROG_RULES2 { get; set; }
        string PROG_RULES3 { get; set; }
        string REMARKS { get; set; }
        Nullable<bool> RESERVE_FLG { get; set; }
        string CL { get; set; }
    }
}
