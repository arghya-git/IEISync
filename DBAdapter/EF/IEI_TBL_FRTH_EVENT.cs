//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBAdapter.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class IEI_TBL_FRTH_EVENT
    {
        public Nullable<int> TECH_PROP_ID { get; set; }
        public string CCODE { get; set; }
        public Nullable<int> PROG_HD_ID { get; set; }
        public string PROG_TYPE { get; set; }
        public string DIVISION { get; set; }
        public string PROG_TITLE { get; set; }
        public Nullable<System.DateTime> PROG_DT { get; set; }
        public Nullable<int> NO_OF_DAYS { get; set; }
        public string PROG_THEME { get; set; }
        public string PROG_ABSTRUCT { get; set; }
        public string PROG_VENUE_NAME { get; set; }
        public string PROG_VENUE_ADD { get; set; }
        public string C_PERSON { get; set; }
        public string C_PERSON_ADD { get; set; }
        public string C_PERSON_MOB { get; set; }
        public string C_PERSON_PHONE { get; set; }
        public string C_PERSON_EMAIL { get; set; }
        public string GUIDELINE_LINK { get; set; }
        public string BROCHURE_LINK { get; set; }
        public string WEBSITE_LINK { get; set; }
        public string EX_LINK1 { get; set; }
        public string EX_LINK2 { get; set; }
        public string EX_FIELD1 { get; set; }
        public string EX_FIELD2 { get; set; }
        public int EVENT_ID { get; set; }
        public string CUR_EVENT_DAY { get; set; }
        public Nullable<int> GUIDLINE_FU_ID { get; set; }
        public Nullable<int> BROCHURE_FU_ID { get; set; }
        public string PROG_MONTH { get; set; }
        public string PROG_YR { get; set; }
    
        public virtual IEI_TBL_TECH_PROPOSAL IEI_TBL_TECH_PROPOSAL { get; set; }
        public virtual IEI_TBL_CENTMAST IEI_TBL_CENTMAST { get; set; }
        public virtual IEI_TBL_FILE_UPLOADED IEI_TBL_FILE_UPLOADED { get; set; }
        public virtual IEI_TBL_FILE_UPLOADED IEI_TBL_FILE_UPLOADED1 { get; set; }
    }
}
