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
    
    public partial class IEI_TBL_TECH_SCHEDULE
    {
        public int SCH_ID { get; set; }
        public Nullable<int> PROG_HD_ID { get; set; }
        public string SCHEDULE_YEAR { get; set; }
        public string SCHEDULE_DESC { get; set; }
        public string THEME { get; set; }
        public Nullable<int> TECH_PROP_ID { get; set; }
        public Nullable<System.DateTime> SCHEDULE_DT { get; set; }
        public Nullable<int> NO_OF_DAYS { get; set; }
        public Nullable<System.DateTime> SCHEDULE_CREATE_DT { get; set; }
        public string SCHEDULE_CREATE_USER { get; set; }
        public string CL { get; set; }
    
        public virtual IEI_TBL_TECH_PROG_HD IEI_TBL_TECH_PROG_HD { get; set; }
        public virtual IEI_TBL_TECH_PROPOSAL IEI_TBL_TECH_PROPOSAL { get; set; }
    }
}
