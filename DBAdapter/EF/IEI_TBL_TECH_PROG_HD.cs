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
    
    public partial class IEI_TBL_TECH_PROG_HD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IEI_TBL_TECH_PROG_HD()
        {
            this.IEI_TBL_TECH_PROPOSAL = new HashSet<IEI_TBL_TECH_PROPOSAL>();
            this.IEI_TBL_TECH_SCHEDULE = new HashSet<IEI_TBL_TECH_SCHEDULE>();
        }
    
        public int PROG_HD_ID { get; set; }
        public string PROG_TYPE_FLG { get; set; }
        public string PROG_TYPE_DESC { get; set; }
        public string PROG_TYPE { get; set; }
        public string PROG_DESC { get; set; }
        public string PROG_RULES1 { get; set; }
        public string PROG_RULES2 { get; set; }
        public string PROG_RULES3 { get; set; }
        public string REMARKS { get; set; }
        public Nullable<bool> RESERVE_FLG { get; set; }
        public string CL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IEI_TBL_TECH_PROPOSAL> IEI_TBL_TECH_PROPOSAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IEI_TBL_TECH_SCHEDULE> IEI_TBL_TECH_SCHEDULE { get; set; }
    }
}