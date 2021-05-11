using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;
using static ViewModel.Enumeration.ActionPropertyEnums;

namespace ViewModel.ActionExplorer
{
    public class Schedule: ISchedule
    {
        [Browsable(false)]                         // this property should be visible
        [ReadOnly(false)]

        [Description("The frequency of Elapsed events in milliseconds")]
        public bool CurrentState { get; set; } = false;

        [Browsable(true)]                         // this property should be visible
        [ReadOnly(false)]

        [Description("The frequency of Elapsed events in milliseconds")]
        public double Interval { get; set; } = 200;

        [TypeConverter(typeof(enumConverter))]

        [Browsable(true)]                         // this property should be visible
        [ReadOnly(false)]
        [DisplayName("Unit")]

        [Description("The frequency of Elapsed events in milliseconds")]
        //[Description("Indicates the name used in code to identify the objects")]
        public intervalUnit IntervalUnit { get; set; } = intervalUnit.Munite;


        [Category("Accessibility")]
        [Browsable(true)]                         // this property should be visible
        [ReadOnly(false)]                          // but just read only
        //[Description("Indicates the name used in code to identify the objects")]
        public DateTime ScheduleDate { get; set; } = DateTime.Now;

        [TypeConverter(typeof(enumConverter))]
        [Category("Accessibility")]
        [Browsable(true)]                         // this property should be visible
        [ReadOnly(false)]                          // but just read only
        //[Description("Indicates the name used in code to identify the objects")]
        public IntervalMode IntMode { get; set; } = IntervalMode.Multiple;

        public override string ToString()
        {
            return "...";
            //return Interval.ToString()+","+ IntervalUnit.ToString() + ","+ ScheduleDate.ToString("dd/MM/yyyy") + ","+ IntMode.ToString();
        }
    }
}
