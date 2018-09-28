using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Utilities
{
    public static class EnumUtility
    {
        public static string GetDescription<TEnum>(TEnum enumerationValue)
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));

            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
                else
                    throw new ArgumentException($"{nameof(enumerationValue)} no attributes found", nameof(enumerationValue));
            }
            return enumerationValue.ToString();
        }

    }
}
