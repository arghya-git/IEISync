using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ViewModel.Tables.SQLServerTables
{
    public class IEI_TBL_TECH_DIVISION_MAST: IIEI_TBL_TECH_DIVISION_MAST
    {
        public string DIV { get; set; }
        public string DISCRIPTION { get; set; }
        public string CL { get; set; }
        public string REMARKS { get; set; }
    }
}
