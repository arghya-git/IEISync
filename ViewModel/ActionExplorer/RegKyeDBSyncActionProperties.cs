using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Enumeration;
using ViewModel.Interfaces;
using static ViewModel.Enumeration.ActionPropertyEnums;

namespace ViewModel.ActionExplorer
{

    public class RegKyeDBSyncActionProperties : IRegKyeDBSyncActionProperties
    {
        [Category("Design")]
        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Indicates the name used in code to identify the objects")]
        [DisplayName("(Text)")]
        public string Text { get; set; } = "";


        [Category("Design")]
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Indicates the name used in code to identify the objects")]
        [DisplayName("(Name)")]
        public string Name { get; set; }




        /// <summary>
        /// Start Visible
        /// </summary>
        
        bool _StartVisibleBoth;
        [Category("Availability")]
        [Browsable(true)]
        [ReadOnly(false)]
        public bool StartVisibleBoth
        {
            get
            {
                return _StartVisibleBoth;
            }
            set
            {
                _StartVisibleBoth = value;
                //SetReadOnly("StartVisibleBoth", false);
                //SetReadOnly("StartVisibleUp", true);
                //SetReadOnly("StartVisibleDown", true);
                //SetReadOnly("PauseVisibleUp", true);
                //SetReadOnly("StopVisibleUp", true);
                //SetReadOnly("PauseVisibleDown", true);
                //SetReadOnly("StopVisibleDown", true);

                //SetReadOnly("StartEnabledBoth", true);
                //SetReadOnly("StartEnabledUp", true);
                //SetReadOnly("StartEnabledDown", true);
                //SetReadOnly("PauseEnabledUp", true);
                //SetReadOnly("StopEnabledUp", true);
                //SetReadOnly("PauseEnabledDown", true);
                //SetReadOnly("StopEnabledDown", true);


                //StartVisibleBoth = false;
                //StopVisibleUp = PauseVisibleUp = StopVisibleDown = PauseVisibleDown = StartVisibleDown = StartVisibleUp = true;
                //StartVisibleBoth = false;

                //StartEnabledBoth = false;
                //StopEnabledUp = PauseEnabledUp = StopEnabledDown = PauseEnabledDown = true;
                //StartEnabledDown = StartEnabledUp = StartEnabledBoth = false;

            }
        }

        [Category("Availability")]
        [Browsable(true)]
        [ReadOnly(false)]
        public bool StartVisibleDown { get; set; } = true;

        [Category("Availability")]
        [Browsable(true)]
        [ReadOnly(false)]
        public bool StartVisibleUp { get; set; } = true;


        /// <summary>
        /// Start Enabled
        /// </summary>

        [Category("Availability")]
        [Browsable(true)]
        [ReadOnly(false)]
    
        public bool StartEnabledBoth { get; set; } = true;

        [Category("Availability")]
        [Browsable(true)]
        [ReadOnly(false)]
        public bool StartEnabledUp { get; set; } = true;

        [Category("Availability")]
        [Browsable(true)]
        [ReadOnly(false)]
        public bool StartEnabledDown { get; set; } = true;


        /// <summary>
        /// Pause Visible
        /// </summary>


        [Category("Availability")]
        [Browsable(false)]
        [ReadOnly(false)]
        public bool PauseVisibleUp { get; set; } = false;

      

        [Category("Availability")]
        [Browsable(false)]
        [ReadOnly(false)]
        public bool PauseVisibleDown { get; set; } = false;

       
        /// <summary>
        /// Pause Enabled
        /// </summary>
        [Category("Availability")]
        [Browsable(true)]
        [ReadOnly(false)]
        public bool PauseEnabledUp { get; set; } = false;

        [Category("Availability")]
        [Browsable(true)]
        [ReadOnly(false)]
        public bool PauseEnabledDown { get; set; } = false;



        /// <summary>
        /// Stop Visible
        /// </summary>

        [Category("Availability")]
        [Browsable(false)]
        [ReadOnly(false)]
        public bool StopVisibleDown { get; set; } = false;

        [Category("Availability")]
        [Browsable(false)]
        [ReadOnly(false)]
        public bool StopVisibleUp { get; set; } = false;


        /// <summary>
        /// Stop Enabled
        /// </summary>
        
        [Category("Availability")]
        [Browsable(true)]
        [ReadOnly(false)]
        public bool StopEnabledUp { get; set; } = false;    

        [Category("Availability")]
        [Browsable(true)]
        [ReadOnly(false)]
        public bool StopEnabledDown { get; set; } = false;

        [Category("Behavior")]
        [Browsable(true)]
        [ReadOnly(false)]

        [TypeConverter(typeof(enumConverter))]
        mode _Mode = mode.Manual;



        public void SetReadOnly(string name, bool value)
        {
            try
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())[name];
                ReadOnlyAttribute attribute = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
                FieldInfo fieldToChange = attribute.GetType().GetField("isReadOnly",
                                                    System.Reflection.BindingFlags.NonPublic |
                                                    System.Reflection.BindingFlags.Instance);
                fieldToChange.SetValue(attribute, value);
            }
            catch { }
        }

        public void SetBrowsable(string name, bool value)
        {
            try
            {

                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())[name];
                ReadOnlyAttribute attribute = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
                FieldInfo fieldToChange = attribute.GetType().GetField("browsable",
                                                    System.Reflection.BindingFlags.NonPublic |
                                                    System.Reflection.BindingFlags.Instance);
                fieldToChange.SetValue(attribute, value);
            }
            catch { }
        }
        [RefreshProperties(RefreshProperties.All)]


        [Category("Behavior")]
        [Browsable(true)]
        [ReadOnly(false)]
        public mode Mode
        {
            get
            {
                return _Mode;
            }
            set
            {
                _Mode = value;
                if (Mode == mode.Auto)
                {
                    SetBrowsable("StartVisibleBoth", false);
                    SetBrowsable("StartVisibleUp", false);
                    SetBrowsable("StartVisibleDown", false);
                    SetBrowsable("PauseVisibleUp", false);
                    SetBrowsable("StopVisibleUp", false);
                    SetBrowsable("PauseVisibleDown", false);
                    SetBrowsable("StopVisibleDown", false);

                    SetBrowsable("StartEnabledBoth", false);
                    SetBrowsable("StartEnabledUp", false);
                    SetBrowsable("StartEnabledDown", false);
                    SetBrowsable("PauseEnabledUp", false);
                    SetBrowsable("StopEnabledUp", false);
                    SetBrowsable("PauseEnabledDown", false);
                    SetBrowsable("StopEnabledDown", false);

                    //SetReadOnly("StartVisibleBoth", true);
                    //SetReadOnly("StartVisibleUp", true);
                    //SetReadOnly("StartVisibleDown", true);
                    //SetReadOnly("PauseVisibleUp", true);
                    //SetReadOnly("StopVisibleUp", true);
                    //SetReadOnly("PauseVisibleDown", true);
                    //SetReadOnly("StopVisibleDown", true);

                    //SetReadOnly("StartEnabledBoth", true);
                    //SetReadOnly("StartEnabledUp", true);
                    //SetReadOnly("StartEnabledDown", true);
                    //SetReadOnly("PauseEnabledUp", true);
                    //SetReadOnly("StopEnabledUp", true);
                    //SetReadOnly("PauseEnabledDown", true);
                    //SetReadOnly("StopEnabledDown", true);

                    //StartVisibleBoth = StartVisibleUp = StartVisibleDown = PauseVisibleUp = StopVisibleUp =
                    //PauseVisibleDown = StopVisibleDown = false;

                    //StartEnabledBoth = StartEnabledUp = StartEnabledDown = PauseEnabledUp = StopEnabledUp =
                    //PauseEnabledDown = StopEnabledDown = false;
                }
                if (Mode == mode.Manual)
                {
                    SetBrowsable("StartVisibleBoth", true);
                    SetBrowsable("StartVisibleUp", true);
                    SetBrowsable("StartVisibleDown", true);
                    SetBrowsable("PauseVisibleUp", true);
                    SetBrowsable("StopVisibleUp", true);
                    SetBrowsable("PauseVisibleDown", true);
                    SetBrowsable("StopVisibleDown", true);

                    SetBrowsable("StartEnabledBoth", true);
                    SetBrowsable("StartEnabledUp", true);
                    SetBrowsable("StartEnabledDown", true);
                    SetBrowsable("PauseEnabledUp", true);
                    SetBrowsable("StopEnabledUp", true);
                    SetBrowsable("PauseEnabledDown", true);
                    SetBrowsable("StopEnabledDown", true);

                    //SetReadOnly("StartVisibleBoth", false);
                    //SetReadOnly("StartVisibleUp", false);
                    //SetReadOnly("StartVisibleDown", false);
                    //SetReadOnly("PauseVisibleUp", false);
                    //SetReadOnly("StopVisibleUp", false);
                    //SetReadOnly("PauseVisibleDown", false);
                    //SetReadOnly("StopVisibleDown", false);

                    //SetReadOnly("StartEnabledBoth", false);
                    //SetReadOnly("StartEnabledUp", false);
                    //SetReadOnly("StartEnabledDown", false);
                    //SetReadOnly("PauseEnabledUp", false);
                    //SetReadOnly("StopEnabledUp", false);
                    //SetReadOnly("PauseEnabledDown", false);
                    //SetReadOnly("StopEnabledDown", false);

                    //StartVisibleBoth = StartVisibleUp = StartVisibleDown = true;
                    //PauseVisibleUp = StopVisibleUp = PauseVisibleDown = StopVisibleDown = false;

                    //StartEnabledBoth = StartEnabledUp = StartEnabledDown = true;
                    //PauseEnabledUp = StopEnabledUp = PauseEnabledDown = StopEnabledDown = false;
                }
            }
        }

        [TypeConverter(typeof(enumConverter))]
        [Category("Accessibility")]
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Indicates the name used in code to identify the objects")]
        public type Type { get; set; }


        [TypeConverter(typeof(enumConverter))]
        state _StateUP;
        [Category("Behavior")]
        [Browsable(true)]
        [ReadOnly(false)]
        public state StateUP { get => _StateUP; set => _StateUP = value; }

        [TypeConverter(typeof(enumConverter))]
        state _StateDown;
        [Category("Behavior")]
        [Browsable(true)]
        [ReadOnly(false)]
        public state StateDown { get => _StateDown; set => _StateDown = value; }

        Schedule _schedule;

        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Category("Behavior")]
        [Browsable(true)]
        public Schedule Schedule { get => _schedule; set => _schedule = value; }


        int _BufferSize = 10;
        [Category("Behavior")]
        [Description("Buffer Size")]
        [Browsable(true)]
        public int Buffer { get => _BufferSize; set => _BufferSize = value; }

        public RegKyeDBSyncActionProperties()
        {
            Schedule = new Schedule();
        }


    }
}
