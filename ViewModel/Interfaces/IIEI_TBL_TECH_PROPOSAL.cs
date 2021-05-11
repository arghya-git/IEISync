using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface IIEI_TBL_TECH_PROPOSAL
    {
        int TECH_PROP_ID { get; set; }
        Nullable<int> REG_ID { get; set; }
        string CCODE { get; set; }
        Nullable<int> PROG_HD_ID { get; set; }
        string DIVISION_BOARD { get; set; }
        string PROG_TITLE { get; set; }
        Nullable<bool> PROG_DT_VIOLATION_FLG { get; set; }
        string DT_VIOLATION_RESION { get; set; }
        Nullable<System.DateTime> PROG_DT { get; set; }
        Nullable<int> NO_OF_DAYS { get; set; }
        string PROG_VENUE { get; set; }
        string CURR_AMT { get; set; }
        Nullable<decimal> REQUEST_AMT { get; set; }
        Nullable<decimal> GRANT_AMT { get; set; }
        string PROG_ABSTRUCT { get; set; }
        string PROP_IP_ADD { get; set; }
        string PROPOSAL_FLAG { get; set; }
        string PROPOSAL_STATUS { get; set; }
        string REMARKS { get; set; }
        string REPORT_STATUS { get; set; }
        string REPORT_DESC { get; set; }
        string REPORT_DETAILS_DESC_PATH { get; set; }
        Nullable<int> DESC_FU_ID { get; set; }
        string REPORT_IMG_DAIS_CAPTION { get; set; }
        string REPORT_IMG_DAIS_PATH { get; set; }
        Nullable<int> DAIS_FU_ID { get; set; }
        string REPORT_IMG_TITLE_CAPTION { get; set; }
        string REPORT_IMG_TITLE_PATH { get; set; }
        Nullable<int> IMG_FU_ID { get; set; }
        Nullable<System.DateTime> PROPOSAL_CREATE_DT { get; set; }
        Nullable<System.DateTime> PROPOSAL_APPROVED_DT { get; set; }
        Nullable<System.DateTime> PROPOSAL_REPORT_SUBMIT_DT { get; set; }
        Nullable<int> USER_PROPOSAL_LOGIN { get; set; }
        string USER_MODERATOR { get; set; }
        string USER_MODERATOR_IP_ADD { get; set; }
        Nullable<int> USER_REPORT_LOGIN { get; set; }
        Nullable<int> INSERTED_ID { get; set; }
    }
}
