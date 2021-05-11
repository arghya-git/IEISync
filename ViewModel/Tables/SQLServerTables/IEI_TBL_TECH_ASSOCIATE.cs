using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ViewModel.Tables.SQLServerTables
{
    public class IEI_TBL_TECH_ASSOCIATE: IIEI_TBL_TECH_ASSOCIATE
    {
        public int ASSOCIATE_ID { get; set; }
        public Nullable<int> TECH_PROP_ID { get; set; }
        public string ASSOCIATE_NAME { get; set; }
        public string ASSOCIATE_ADD { get; set; }
        public string ASSOCIATE_CONTACTS { get; set; }
        public string CONTACT_PERSON { get; set; }
        public string REMARKS { get; set; }
    }
}
