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
    
    public partial class IEI_TBL_TECH_ASSOCIATE
    {
        public int ASSOCIATE_ID { get; set; }
        public Nullable<int> TECH_PROP_ID { get; set; }
        public string ASSOCIATE_NAME { get; set; }
        public string ASSOCIATE_ADD { get; set; }
        public string ASSOCIATE_CONTACTS { get; set; }
        public string CONTACT_PERSON { get; set; }
        public string REMARKS { get; set; }
    
        public virtual IEI_TBL_TECH_PROPOSAL IEI_TBL_TECH_PROPOSAL { get; set; }
    }
}