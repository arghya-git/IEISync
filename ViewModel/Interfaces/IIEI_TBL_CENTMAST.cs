using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface IIEI_TBL_CENTMAST
    {
        string CCODE { get; set; }
        string TYPE { get; set; }
        string CNAME { get; set; }
        string CADL2 { get; set; }
        string CADL3 { get; set; }
        string CADL4 { get; set; }
        string CADL5 { get; set; }
        string EMAILID { get; set; }
        string TEL { get; set; }
        string FAX { get; set; }
        string COUNTRY_TYPE { get; set; }
    }
}
