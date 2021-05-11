using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ViewModel.Tables.SQLServerTables
{
    public class IEI_TBL_FILE_UPLOADED : IIEI_TBL_FILE_UPLOADED
    {
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
    }
}
