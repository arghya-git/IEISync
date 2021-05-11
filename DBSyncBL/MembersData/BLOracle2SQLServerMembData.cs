
//using DBAdapter.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.DataModel.DataSynch.Membership;
using ViewModel.StoreProcedure.SQLServerSPs;
using ViewModel.VM.NewUpgradeMembersData;

namespace DBSyncBL.MembersData
{
    public class BLOracle2SQLServerMembData
    {
        public SP_Sync_MembData_Result SyncMembdata(VM_SP_IEI_TBL_PARTY_MASTER _VM_SP_IEI_TBL_PARTY_MASTER)
        {
            Oracle2SQLServerMembData obj = new Oracle2SQLServerMembData();
            
            return obj.SyncMembdata(_VM_SP_IEI_TBL_PARTY_MASTER);

        }
    }
}
