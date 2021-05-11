using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface IORA_PARTYCHADD
    {
        string MEMBCODE { get; set; }
        string RECSLNO { get; set; }
        string ADD1 { get; set; }
        string ADD2 { get; set; }
        string ADD3 { get; set; }
        string ADD4 { get; set; }
        string ADD5 { get; set; }
        string CENTRE { get; set; }
        string DIVISION { get; set; }
        string PARTYNAME { get; set; }
        string PARTYSURNAME { get; set; }
        string TEL1 { get; set; }
        string EMAIL { get; set; }
        string MOBILE { get; set; }
        DateTime DATEIN { get; set; }
        int PIN { get; set; }
        DateTime SYSDT { get; set; }
        string FUNC { get; set; }
        string USER_EDIT_TELNO { get; set; }
    }
}
