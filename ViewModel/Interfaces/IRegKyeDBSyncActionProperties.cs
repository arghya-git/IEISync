using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface IRegKyeDBSyncActionProperties
    {

        bool StartVisibleBoth { get; set; }
        bool StartVisibleUp { get; set; }
        bool StartVisibleDown { get; set; }
        bool PauseVisibleUp { get; set; }
        bool StopVisibleUp { get; set; }
        bool PauseVisibleDown { get; set; }
        bool StopVisibleDown { get; set; }
        string Text { get; set; }
        string Name { get; set; }
        bool StartEnabledBoth { get; set; }
        bool StartEnabledUp { get; set; }
        bool StartEnabledDown { get; set; }
        bool PauseEnabledUp { get; set; }
        bool StopEnabledUp { get; set; }
        bool PauseEnabledDown { get; set; }
        bool StopEnabledDown { get; set; }
        //string Mode { get; set; }
    }
}
