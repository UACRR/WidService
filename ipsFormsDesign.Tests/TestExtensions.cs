using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Tests
{
    public static class TestExtensions
    {
        public static bool ObjectEquals(this object dest, object source, string[] FieldExclude = null)
        {
            if (ReferenceEquals(dest, source))
                return true;

            if (dest == null && source == null)
                return true;

            if ((dest == null && source != null) || (dest != null && source == null))
                return false;

            if (dest.GetType() != source.GetType())
                return false;

            List<string> excludeList = new List<string>();
            if (FieldExclude != null)
            {
                excludeList.AddRange(FieldExclude);
                excludeList.Sort();
            }

            foreach (var property in dest.GetType().GetProperties())
            {
                if (excludeList.Contains(property.Name))
                    continue;

                // If nullable
                Type checkType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                TypeInfo ti = checkType == null ? property.GetType().GetTypeInfo() : checkType.GetTypeInfo();

                if (!(ti.IsPrimitive == true
                      || checkType == typeof(string)
                      || checkType == typeof(Decimal)
                      || checkType == typeof(DateTime)
                      || checkType == typeof(TimeSpan)
                    ))
                    continue;

                var objValue = property.GetValue(dest);
                var anotherValue = property.GetValue(source);

                if (objValue == null && anotherValue == null)
                    continue;

                if ((objValue != null && anotherValue == null) || (objValue == null && anotherValue != null))
                    return false;

                if (!objValue.Equals(anotherValue))
                    return false;
            }

            return true;
        }

    }
}
