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
    
    public partial class IEI_TBL_FILE_UPLOADED
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IEI_TBL_FILE_UPLOADED()
        {
            this.IEI_TBL_FILE_UPLOAD_VS_MEMB_APP = new HashSet<IEI_TBL_FILE_UPLOAD_VS_MEMB_APP>();
            this.IEI_TBL_TECH_PROPOSAL = new HashSet<IEI_TBL_TECH_PROPOSAL>();
            this.IEI_TBL_TECH_PROPOSAL1 = new HashSet<IEI_TBL_TECH_PROPOSAL>();
            this.IEI_TBL_TECH_PROPOSAL2 = new HashSet<IEI_TBL_TECH_PROPOSAL>();
            this.IEI_TBL_FRTH_EVENT = new HashSet<IEI_TBL_FRTH_EVENT>();
            this.IEI_TBL_FRTH_EVENT1 = new HashSet<IEI_TBL_FRTH_EVENT>();
        }
    
        public int FU_ID { get; set; }
        public Nullable<int> REG_ID { get; set; }
        public string RECSLNO { get; set; }
        public string FILE_TYPE { get; set; }
        public Nullable<int> FM_ID { get; set; }
        public string UPLOAD_FOR { get; set; }
        public string ROOT_PATH { get; set; }
        public string PHYSICAL_PATH { get; set; }
        public Nullable<int> FILE_SIZE { get; set; }
        public string ORIGINAL_FILE_NAME { get; set; }
        public string MODIFIED_FILE_NAME { get; set; }
        public string FILE_EXTENSION { get; set; }
        public string ERR_MSG { get; set; }
        public string ERR_CODE { get; set; }
        public string STATUS { get; set; }
        public Nullable<bool> STATUS_FLAG { get; set; }
        public string APP_VER { get; set; }
    
        public virtual IEI_TBL_FILE_TYPES IEI_TBL_FILE_TYPES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IEI_TBL_FILE_UPLOAD_VS_MEMB_APP> IEI_TBL_FILE_UPLOAD_VS_MEMB_APP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IEI_TBL_TECH_PROPOSAL> IEI_TBL_TECH_PROPOSAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IEI_TBL_TECH_PROPOSAL> IEI_TBL_TECH_PROPOSAL1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IEI_TBL_TECH_PROPOSAL> IEI_TBL_TECH_PROPOSAL2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IEI_TBL_FRTH_EVENT> IEI_TBL_FRTH_EVENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IEI_TBL_FRTH_EVENT> IEI_TBL_FRTH_EVENT1 { get; set; }
    }
}