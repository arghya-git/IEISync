using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Enumeration
{
    public static class ActionPropertyEnums
    {
        public enum mode
        {
            [Description("Auto")]
            Auto,
            [Description("Manual")]
            Manual
        }
        public enum type
        {
            RootNode, ChiledNode, LeafNode
        }


        public enum state
        {
            Running, Paused, Stop, Abandent
        }

        public enum intervalUnit
        {
            Milisecond, Second, Munite, Hour, Day, Month, Year
        }
        public enum IntervalMode
        {
            Once, Multiple, Immediate
        }
        public class enumConverter : EnumConverter
        {
            private Type _enumType;
            /// <summary />Initializing instance</summary />
            /// <param name=""type"" />type Enum</param />
            /// this is only one function, that you must
            /// change. All another functions for enums
            /// you can use by Ctrl+C/Ctrl+V
            public enumConverter(Type type)
                : base(type)
            {
                _enumType = type;
            }

            public override bool CanConvertTo(ITypeDescriptorContext context,
                Type destType)
            {
                return destType == typeof(string);
            }

            public override object ConvertTo(ITypeDescriptorContext context,
                CultureInfo culture,
                object value, Type destType)
            {
                FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, value));
                DescriptionAttribute dna =
                    (DescriptionAttribute)Attribute.GetCustomAttribute(
                    fi, typeof(DescriptionAttribute));

                if (dna != null)
                    return dna.Description;
                else
                    return value.ToString();
            }

            public override bool CanConvertFrom(ITypeDescriptorContext context,
                Type srcType)
            {
                return srcType == typeof(string);
            }

            public override object ConvertFrom(ITypeDescriptorContext context,
                CultureInfo culture,
                object value)
            {
                foreach (FieldInfo fi in _enumType.GetFields())
                {
                    DescriptionAttribute dna =
                    (DescriptionAttribute)Attribute.GetCustomAttribute(
                    fi, typeof(DescriptionAttribute));

                    if ((dna != null) && ((string)value == dna.Description))
                        return Enum.Parse(_enumType, fi.Name);
                }
                return Enum.Parse(_enumType, (string)value);
            }
        }
    }
}
