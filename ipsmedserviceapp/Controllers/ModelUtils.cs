using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ipsmedserviceapp.Controllers
{

    static class PrimitiveTypes
    {
        public static readonly Type[] List;

        static PrimitiveTypes()
        {
            var types = new[]
                           {
                              typeof (Enum),
                              typeof (String),
                              typeof (Char),
                              typeof (Guid),

                              typeof (Boolean),
                              typeof (Byte),
                              typeof (Int16),
                              typeof (Int32),
                              typeof (Int64),
                              typeof (Single),
                              typeof (Double),
                              typeof (Decimal),

                              typeof (SByte),
                              typeof (UInt16),
                              typeof (UInt32),
                              typeof (UInt64),

                              typeof (DateTime),
                              typeof (DateTimeOffset),
                              typeof (TimeSpan),
                          };


            var nullTypes = from t in types
                            where t.GetTypeInfo().IsValueType
                            select typeof(Nullable<>).MakeGenericType(t);

            List = types.Concat(nullTypes).ToArray();
        }

        public static bool Test(Type type)
        {
            if (List.Any(x => x.IsAssignableFrom(type)))
                return true;

            var nut = Nullable.GetUnderlyingType(type);
            return nut != null && nut.GetTypeInfo().IsEnum;
        }
    }

    public static class ModelUtils
    {
        /// <summary>
        /// Синхронізувати об'єкти однакового типу
        /// </summary>
        /// <param name="target">об'єкт якому буде присвоєно значення</param>
        /// <param name="source">об'єкт з якого буде присвоєно значення</param>
        /// <param name="fieldExclude">ігноровані властивості</param>
        public static void SetFields(this object target, object source, string[] fieldExclude = null )
        {
            if (ReferenceEquals(target, source))
                return;

            if ((target == null) || (source == null))
                return;

            if (target.GetType() != source.GetType())
                return;

            var excludeList = new List<string>();
            if (fieldExclude != null)
            {
                excludeList.AddRange(fieldExclude);
                excludeList.Sort();
            }

            foreach (var property in target.GetType().GetProperties())
            {
                if (excludeList.Contains(property.Name))
                    continue;

                // If nullable
                Type checkType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                TypeInfo typeInfo = checkType.GetTypeInfo();

                if (!(typeInfo.IsPrimitive || checkType == typeof(string) || checkType == typeof(decimal) || checkType == typeof(DateTime) || checkType == typeof(TimeSpan)))
                    continue;

                var objValue = property.GetValue(target);
                var anotherValue = property.GetValue(source);
                //Recursion
                if (anotherValue == null)
                {
                    if (objValue != null)
                        property.SetValue(target, anotherValue, null);
                }
                else if (objValue == null || !objValue.Equals(anotherValue))
                    property.SetValue(target, anotherValue, null);
            }
        }
    }
}
