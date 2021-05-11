using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ViewModel.VM.NewUpgradeMembersData
{
    public class VM_SP_IEI_TBL_PARTY_MASTER: ISQLSERVER_IEI_TBL_PARTY_MASTER
    {
        public string RECSLNO { get; set; }
        public string OLDMEMBCODE { get; set; }
        public string NEWMEMBCODE { get; set; }
        public string REG_CAT { get; set; }

        public string WEB_UPDT_FLG { get; set; }



        public string PARTYCODE { get; set; }
        public string MEMB_IDENTITY { get; set; }
        public int LOGIN_ID { get; set; }
        public string PARTY_NAME { get; set; }
        public string SALUTATION { get; set; }
        public string SFX { get; set; }
        public string ADD1 { get; set; }
        public string ADD2 { get; set; }
        public string ADD3 { get; set; }
        public string ADD4 { get; set; }
        public string ADD5 { get; set; }
        public string PIN { get; set; }
        public string NATIONALITY { get; set; }
        public string COUNTRY_RESIDENCE { get; set; }
        //public string COUNTRY_NAME 
        public string GENDER { get; set; }
        public string MOBILE { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public DateTime? DOB { get; set; }
        public string CENTRE { get; set; }
        public string DIVISION { get; set; }
        public string SUBSCRIPTION_CATEGORY { get; set; }
        public DateTime? ENROLEMENT_START_DT { get; set; }
        public DateTime? ENROLEMENT_END_DT { get; set; }
        public DateTime? SUBSCRIPTION_END_DT { get; set; }
        public string MEMB_CATEGORY { get; set; }
        public string MEMB_TYPE { get; set; }
        public DateTime? GENERATE_DATE { get; set; }
        public DateTime? UPLOAD_DATE { get; set; }
        public string DOWNLOAD_FLAG { get; set; }
        public string CL { get; set; }
        public string REMARKS { get; set; }

        //public DateTime ADD_CHANGE_DATE { get; set; }
    }
}
