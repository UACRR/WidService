using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WidSubmit
{
    internal static class EntityHelpers
    {
          internal static string EntityToString(object entity, int startPropIdx)
          {
            var t = entity.GetType();
            var piList = t.GetProperties();

            var sb = new StringBuilder();
            for (int i = startPropIdx; i < piList.Count(); i++)
            {
                var pi = piList[i];
                sb.Append(FormatProp(entity, pi));
            }

            var retVal = sb.ToString();
            return retVal;
        }

        internal static List<object> EntityToList(object entity, int startPropIdx)
        {
            var retVal = new List<object>();
            var t = entity.GetType();
            var piList = t.GetProperties();

            var sb = new StringBuilder();
            for (int i = startPropIdx; i < piList.Count(); i++)
            {
                var pi = piList[i];
                retVal.Add(FormatProp(entity, pi));
            }

            return retVal;
        }

        internal static string FormatProp(object entity, PropertyInfo pi)
        {
            var posInFile = (CustomPosInFileAttribute)pi.GetCustomAttribute(typeof(CustomPosInFileAttribute));
            if (posInFile == null)
            {
                return "";
            }
            var size = posInFile.Size;
            var fmt = posInFile.Fmt;
            var value = (string)pi.GetValue(entity);
            if(string.IsNullOrEmpty(value))
            {
                return new string(' ', size);
            }
            else if(fmt == 'N')
            {
                return int.Parse(value).ToString($"D{size}");
            }
            else
            {
                value = FileValidator.NormalizeText(value);
                value = value.Substring(0, Math.Min(size, value.Length));
                return value + new string(' ', size - value.Length);
            }
        }
    }
}
