using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ViewModel.Tables.OracleTables
{
    public class PARTYCHADD : IORA_PARTYCHADD
    {
        public string MEMBCODE { get; set; }
        public string RECSLNO { get; set; }
        public string ADD1 { get; set; }
        public string ADD2 { get; set; }
        public string ADD3 { get; set; }
        public string ADD4 { get; set; }
        public string ADD5 { get; set; }
        public string CENTRE { get; set; }
        public string DIVISION { get; set; }
        public string PARTYNAME { get; set; }
        public string PARTYSURNAME { get; set; }
        public string TEL1 { get; set; }
        public string EMAIL { get; set; }
        public string MOBILE { get; set; }
        public DateTime DATEIN { get; set; }
        public int PIN { get; set; }
        public DateTime SYSDT { get; set; }
        public string FUNC { get; set; }
        public string USER_EDIT_TELNO { get; set; }

    }
}
