using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface IIEI_TBL_FILE_UPLOADED
    {
        int FU_ID { get; set; }
        Nullable<int> REG_ID { get; set; }
        string RECSLNO { get; set; }
        string FILE_TYPE { get; set; }
        Nullable<int> FM_ID { get; set; }
        string UPLOAD_FOR { get; set; }
        string ROOT_PATH { get; set; }
        string PHYSICAL_PATH { get; set; }
        Nullable<int> FILE_SIZE { get; set; }
        string ORIGINAL_FILE_NAME { get; set; }
        string MODIFIED_FILE_NAME { get; set; }
        string FILE_EXTENSION { get; set; }
        string ERR_MSG { get; set; }
        string ERR_CODE { get; set; }
        string STATUS { get; set; }
        Nullable<bool> STATUS_FLAG { get; set; }
        string APP_VER { get; set; }
    }
}
