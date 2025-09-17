using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwrTools
{
    public class BaseRec
    {
#region StringToValue
        protected string ParseA(string fieldText)
        {
            return fieldText.Trim();
        }

        protected bool? ParseB(string fieldText)
        {
            return fieldText == " " ? (bool?)null : fieldText == "Y" ? true : false;
        }

        protected char ParseF(string fieldText)
        {
            return fieldText[0];
        }

        protected DateTime? ParseD(string fieldText)
        {
            if (string.IsNullOrEmpty(fieldText.Trim()) || fieldText == "00000000")
            {
                return null;
            }
            else
            {
                return new DateTime(
                    int.Parse(fieldText.Substring(0, 4)),
                    int.Parse(fieldText.Substring(4, 2)),
                    int.Parse(fieldText.Substring(6, 2))
                );
            }
        }

        protected string ParseN(string fieldText)
        {
            var zeroString = new string('0', fieldText.Length);
            if (fieldText == zeroString)
            {
                return null;
            }
            else
            {
                return fieldText.Trim();
            }
        }

        protected TimeSpan? ParseT(string fieldText)
        {
            if (string.IsNullOrEmpty(fieldText.Trim()) || fieldText == "000000")
            {
                return null;
            }
            else
            {
                return new TimeSpan(0,
                    int.Parse(fieldText.Substring(0, 2)),
                    int.Parse(fieldText.Substring(2, 2)),
                    int.Parse(fieldText.Substring(4, 2))
                );
            }
        }

        protected string ParseL(string fieldText)
        {
            return fieldText.Trim();
        }

        public virtual void FromLine(string line) { }

        #endregion StringToValue

#region ValueToString
        protected string FormatFieldA(string value, int size)
        {
            return value == null ? new string(' ', size) : value.PadRight(size);
        }

        protected string FormatFieldB(bool? value, int size)
        {
            return value == null ? " " : value == true ? "Y" : "N";
        }

        protected string FormatFieldF(char? value, int size)
        {
            return value == null ? " " : (char)value == 0 ? "U" : ((char)value).ToString();
        }

        protected string FormatFieldD(DateTime? value, int size)
        {
            return value == null ? new string(' ', size) : ((DateTime)value).ToString("yyyyMMdd");
        }

        protected string FormatFieldN(string value, int size)
        {
            return value == null ? new string(' ', size) : value.PadLeft(size, '0');
        }

        protected string FormatFieldT(TimeSpan? value, int size)
        {
            return value == null ? new string(' ', size) : ((TimeSpan)value).ToString("hhmmss");
        }

        protected string FormatFieldL(string value, int size)
        {
            return value == null ? new string(' ', size) : value.PadRight(size);
        }

        protected string FormatSeqNr(int value, int size)
        {
            return value.ToString().PadLeft(size, '0');
        }

        public virtual string ToFileLine(int tranSeqNr, int recSeqNr) => "";

#endregion
    
    }
}
