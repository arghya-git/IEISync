using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ViewModel.Tables.SQLServerTables
{
    public class IEI_TBL_TECH_PROPOSAL: IIEI_TBL_TECH_PROPOSAL
    {
        public int TECH_PROP_ID { get; set; }
        public Nullable<int> REG_ID { get; set; }
        public string CCODE { get; set; }
        public Nullable<int> PROG_HD_ID { get; set; }
        public string DIVISION_BOARD { get; set; }
        public string PROG_TITLE { get; set; }
        public Nullable<bool> PROG_DT_VIOLATION_FLG { get; set; }
        public string DT_VIOLATION_RESION { get; set; }
        public Nullable<System.DateTime> PROG_DT { get; set; }
        public Nullable<int> NO_OF_DAYS { get; set; }
        public string PROG_VENUE { get; set; }
        public string CURR_AMT { get; set; }
        public Nullable<decimal> REQUEST_AMT { get; set; }
        public Nullable<decimal> GRANT_AMT { get; set; }
        public string PROG_ABSTRUCT { get; set; }
        public string PROP_IP_ADD { get; set; }
        public string PROPOSAL_FLAG { get; set; }
        public string PROPOSAL_STATUS { get; set; }
        public string REMARKS { get; set; }
        public string REPORT_STATUS { get; set; }
        public string REPORT_DESC { get; set; }
        public string REPORT_DETAILS_DESC_PATH { get; set; }
        public Nullable<int> DESC_FU_ID { get; set; }
        public string REPORT_IMG_DAIS_CAPTION { get; set; }
        public string REPORT_IMG_DAIS_PATH { get; set; }
        public Nullable<int> DAIS_FU_ID { get; set; }
        public string REPORT_IMG_TITLE_CAPTION { get; set; }
        public string REPORT_IMG_TITLE_PATH { get; set; }
        public Nullable<int> IMG_FU_ID { get; set; }
        public Nullable<System.DateTime> PROPOSAL_CREATE_DT { get; set; }
        public Nullable<System.DateTime> PROPOSAL_APPROVED_DT { get; set; }
        public Nullable<System.DateTime> PROPOSAL_REPORT_SUBMIT_DT { get; set; }
        public Nullable<int> USER_PROPOSAL_LOGIN { get; set; }
        public string USER_MODERATOR { get; set; }
        public string USER_MODERATOR_IP_ADD { get; set; }
        public Nullable<int> USER_REPORT_LOGIN { get; set; }
        public Nullable<int> INSERTED_ID { get; set; }
    }
}
