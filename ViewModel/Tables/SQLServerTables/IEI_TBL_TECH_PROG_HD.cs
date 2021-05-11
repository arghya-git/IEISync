using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ViewModel.Tables.SQLServerTables
{
    public class IEI_TBL_TECH_PROG_HD: IIEI_TBL_TECH_PROG_HD
    {
        public int PROG_HD_ID { get; set; }
        public string PROG_TYPE_FLG { get; set; }
        public string PROG_TYPE_DESC { get; set; }
        public string PROG_TYPE { get; set; }
        public string PROG_DESC { get; set; }
        public string PROG_RULES1 { get; set; }
        public string PROG_RULES2 { get; set; }
        public string PROG_RULES3 { get; set; }
        public string REMARKS { get; set; }
        public Nullable<bool> RESERVE_FLG { get; set; }
        public string CL { get; set; }
    }
}
