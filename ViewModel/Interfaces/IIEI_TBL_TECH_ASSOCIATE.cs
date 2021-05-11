using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface IIEI_TBL_TECH_ASSOCIATE
    {
        int ASSOCIATE_ID { get; set; }
        Nullable<int> TECH_PROP_ID { get; set; }
        string ASSOCIATE_NAME { get; set; }
        string ASSOCIATE_ADD { get; set; }
        string ASSOCIATE_CONTACTS { get; set; }
        string CONTACT_PERSON { get; set; }
        string REMARKS { get; set; }
    }
}
