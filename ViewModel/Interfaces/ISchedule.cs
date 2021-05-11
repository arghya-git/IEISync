using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ViewModel.Enumeration.ActionPropertyEnums;

namespace ViewModel.Interfaces
{
   
    public interface ISchedule
    {
        double Interval { get; set; }
        intervalUnit IntervalUnit { get; set; }

        DateTime ScheduleDate { get; set; }

        IntervalMode IntMode { get; set; }
    }
}
