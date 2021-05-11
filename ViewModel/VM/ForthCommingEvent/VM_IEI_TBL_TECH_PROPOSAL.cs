using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Tables.SQLServerTables;

namespace ViewModel.VM.ForthCommingEvent
{
    public class VM_IEI_TBL_TECH_PROPOSAL: IEI_TBL_TECH_PROPOSAL
    {
        public List<VM_IEI_TBL_TECH_ASSOCIATE> IEI_TBL_TECH_ASSOCIATE { get; set; }
        public VM_IEI_TBL_TECH_DIVISION_MAST IEI_TBL_TECH_DIVISION_MAST { get; set; }
        public VM_IEI_TBL_TECH_PROG_HD IEI_TBL_TECH_PROG_HD { get; set; }      
        public VM_IEI_TBL_CENTMAST IEI_TBL_CENTMAST { get; set; }
    }
}
