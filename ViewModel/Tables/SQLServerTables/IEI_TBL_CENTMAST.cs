using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ViewModel.Tables.SQLServerTables
{
    public class IEI_TBL_CENTMAST : IIEI_TBL_CENTMAST
    {
        public string CCODE { get; set; }
        public string TYPE { get; set; }
        public string CNAME { get; set; }
        public string CADL2 { get; set; }
        public string CADL3 { get; set; }
        public string CADL4 { get; set; }
        public string CADL5 { get; set; }
        public string EMAILID { get; set; }
        public string TEL { get; set; }
        public string FAX { get; set; }
        public string COUNTRY_TYPE { get; set; }
    }
}
