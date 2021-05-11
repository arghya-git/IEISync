using AutoMapper;
using DBAdapter;
using DBAdapter.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.StoreProcedure.SQLServerSPs;
using ViewModel.VM.NewUpgradeMembersData;

namespace ViewModel.DataModel.DataSynch.Membership
{
    public class Oracle2SQLServerMembData:coreentity
    {
        public StoreProcedure.SQLServerSPs.SP_Sync_MembData_Result SyncMembdata(VM_SP_IEI_TBL_PARTY_MASTER _VM_SP_IEI_TBL_PARTY_MASTER)
        {
            StoreProcedure.SQLServerSPs.SP_Sync_MembData_Result obj =new StoreProcedure.SQLServerSPs.SP_Sync_MembData_Result();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DBAdapter.EF.SP_Sync_MembData_Result, StoreProcedure.SQLServerSPs.SP_Sync_MembData_Result>();
                
            });

            IMapper mapper = new Mapper(config);
            try
            {
                var _SP_Sync_MembData_Result = objtIEIEntities.SP_Sync_MembData1(_VM_SP_IEI_TBL_PARTY_MASTER.RECSLNO,
                    _VM_SP_IEI_TBL_PARTY_MASTER.OLDMEMBCODE,
                    _VM_SP_IEI_TBL_PARTY_MASTER.NEWMEMBCODE,
                    _VM_SP_IEI_TBL_PARTY_MASTER.PARTYCODE,
                    _VM_SP_IEI_TBL_PARTY_MASTER.MEMB_IDENTITY,
                    _VM_SP_IEI_TBL_PARTY_MASTER.LOGIN_ID,
                    _VM_SP_IEI_TBL_PARTY_MASTER.PARTY_NAME,
                    _VM_SP_IEI_TBL_PARTY_MASTER.SALUTATION,
                    _VM_SP_IEI_TBL_PARTY_MASTER.SFX,
                    _VM_SP_IEI_TBL_PARTY_MASTER.ADD1,
                    _VM_SP_IEI_TBL_PARTY_MASTER.ADD2,
                    _VM_SP_IEI_TBL_PARTY_MASTER.ADD3,
                    _VM_SP_IEI_TBL_PARTY_MASTER.ADD4,
                    _VM_SP_IEI_TBL_PARTY_MASTER.ADD5,
                    _VM_SP_IEI_TBL_PARTY_MASTER.PIN,
                    _VM_SP_IEI_TBL_PARTY_MASTER.NATIONALITY,
                    _VM_SP_IEI_TBL_PARTY_MASTER.COUNTRY_RESIDENCE,
                    _VM_SP_IEI_TBL_PARTY_MASTER.GENDER,
                    _VM_SP_IEI_TBL_PARTY_MASTER.MOBILE,
                    _VM_SP_IEI_TBL_PARTY_MASTER.EMAIL,
                    _VM_SP_IEI_TBL_PARTY_MASTER.PHONE,
                    _VM_SP_IEI_TBL_PARTY_MASTER.DOB,
                    _VM_SP_IEI_TBL_PARTY_MASTER.CENTRE,
                    _VM_SP_IEI_TBL_PARTY_MASTER.DIVISION,
                    _VM_SP_IEI_TBL_PARTY_MASTER.SUBSCRIPTION_CATEGORY,
                    _VM_SP_IEI_TBL_PARTY_MASTER.ENROLEMENT_START_DT,
                    _VM_SP_IEI_TBL_PARTY_MASTER.ENROLEMENT_END_DT,
                    _VM_SP_IEI_TBL_PARTY_MASTER.SUBSCRIPTION_END_DT,
                    _VM_SP_IEI_TBL_PARTY_MASTER.MEMB_CATEGORY,
                    _VM_SP_IEI_TBL_PARTY_MASTER.REG_CAT,
                    _VM_SP_IEI_TBL_PARTY_MASTER.MEMB_TYPE,
                    _VM_SP_IEI_TBL_PARTY_MASTER.GENERATE_DATE,
                    _VM_SP_IEI_TBL_PARTY_MASTER.UPLOAD_DATE,
                    _VM_SP_IEI_TBL_PARTY_MASTER.WEB_UPDT_FLG,
                    _VM_SP_IEI_TBL_PARTY_MASTER.CL,
                    _VM_SP_IEI_TBL_PARTY_MASTER.REMARKS
                    ).Single();

                obj = mapper.Map<DBAdapter.EF.SP_Sync_MembData_Result, StoreProcedure.SQLServerSPs.SP_Sync_MembData_Result>(_SP_Sync_MembData_Result);

            }
            catch(Exception ex)
            {

            }
            //obj = mapper.Map<List<IEI_TBL_FRTH_EVENT>, List<VM_IEI_TBL_FRTH_EVENT>>(_IEI_TBL_FRTH_EVENT);

            //ReturnResult = JsonConvert.SerializeObject(obj);


            return obj;
        }
    }
}
