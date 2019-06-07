using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace IpsViewComponentLibrary.Utilities
{
    public class TimeSpanToDateTimeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(DateTime);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            TimeSpan span = (TimeSpan)value;
            DateTime dt = new DateTime(span.Ticks);
            return dt;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(DateTime);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            DateTime dt = (DateTime)value;
            TimeSpan span = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            return span;
        }
    }
}
