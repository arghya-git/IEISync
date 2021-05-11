using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface IIEI_TBL_FRTH_EVENT
    {
        Nullable<int> TECH_PROP_ID { get; set; }
        //string CCODE { get; set; }
        Nullable<int> PROG_HD_ID { get; set; }
        string PROG_TYPE { get; set; }
        string DIVISION { get; set; }
        string PROG_TITLE { get; set; }
        Nullable<System.DateTime> PROG_DT { get; set; }
        Nullable<int> NO_OF_DAYS { get; set; }
        string PROG_THEME { get; set; }
        string PROG_ABSTRUCT { get; set; }
        string PROG_VENUE_NAME { get; set; }
        string PROG_VENUE_ADD { get; set; }
        string C_PERSON { get; set; }
        string C_PERSON_ADD { get; set; }
        string C_PERSON_MOB { get; set; }
        string C_PERSON_PHONE { get; set; }
        string C_PERSON_EMAIL { get; set; }
        string GUIDELINE_LINK { get; set; }
        string BROCHURE_LINK { get; set; }
        string WEBSITE_LINK { get; set; }
        string EX_LINK1 { get; set; }
        string EX_LINK2 { get; set; }
        string EX_FIELD1 { get; set; }
        string EX_FIELD2 { get; set; }
        int EVENT_ID { get; set; }
        string CUR_EVENT_DAY { get; set; }

        string PROG_MONTH { get; set; }
        string PROG_YR { get; set; }
    }
}
