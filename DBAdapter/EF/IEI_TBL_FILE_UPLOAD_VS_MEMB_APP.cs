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
    
    public partial class IEI_TBL_FILE_UPLOAD_VS_MEMB_APP
    {
        public int UM_ID { get; set; }
        public Nullable<int> FU_ID { get; set; }
        public string RECSLNO { get; set; }
    
        public virtual IEI_TBL_FILE_UPLOADED IEI_TBL_FILE_UPLOADED { get; set; }
    }
}
