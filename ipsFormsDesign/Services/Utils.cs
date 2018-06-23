using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ipsFormsDesign
{
    public static class Utils
    {

        public static void SetFields(this object dest, object source, string[] FieldExclude = null)
        {
            if (ReferenceEquals(dest, source)) return;
            if ((dest == null) || (source == null)) return;
            if (dest.GetType() != source.GetType()) return;

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
                  || checkType == typeof(DateTime)))
                    continue;

                var objValue = property.GetValue(dest);
                var anotherValue = property.GetValue(source);
                //Recursion
                if (anotherValue == null)
                {
                    if (objValue != null)
                        property.SetValue(dest, anotherValue, null);
                }
                else if (objValue == null || !objValue.Equals(anotherValue))
                    property.SetValue(dest, anotherValue, null);
            }
        }

        /// <summary>
        /// Класс отображения суммы прописью.
        /// 3 варианта - рубли, доллары и просто для использования
        /// других любых единиц (вагоны, мешки и т.п.)
        /// --------------------------------------
        /// Автор - Глеб Уфимцев (dnkvpb@nm.ru)
        /// </summary>

        public static string GrnPhrase(decimal money)
        {
            return CurPhrase(money, "гривня", "гривні", "гривень", "копійка", "копійки", "копійок");
        }



        public static string NumPhrase(ulong Value, bool IsMale)
        {
            if (Value == 0UL) return "Нуль";
            string[] Dek1 = { "", " од", " дв", " три", " чотири", " п'ять", " шість", " сім", " вісім", " дев'ять", " десять", " одинадцять", " дванадцять", " тринадцять", " чотирнадцять", " п'ятнадцять", " шістнадцять", " сімнадцять", " вісімнадцять", " дев'ятнадцять" };
            string[] Dek2 = { "", "", " двадцять", " тридцять", " сорок", " п'ятдесят", " шістдесят", " сімдесят", " вісімдесят", " дев'яносто" };
            string[] Dek3 = { "", " сто", " двісті", " триста", " чотириста", " п'ятсот", " шістсот", " сімсот", " вісімсот", " дев'ятсот" };
            string[] Th = { "", "", " тисяч", " мільйон", " міліард", " триліон", " квадриліон", " квинтиліон" };
            string str = "";
            for (byte th = 1; Value > 0; th++)
            {
                ushort gr = (ushort)(Value % 1000);
                Value = (Value - gr) / 1000;
                if (gr > 0)
                {
                    byte d3 = (byte)((gr - gr % 100) / 100);
                    byte d1 = (byte)(gr % 10);
                    byte d2 = (byte)((gr - d3 * 100 - d1) / 10);
                    if (d2 == 1) d1 += (byte)10;
                    bool ismale = (th > 2) || ((th == 1) && IsMale);
                    str = Dek3[d3] + Dek2[d2] + Dek1[d1] + EndDek1(d1, ismale) + Th[th] + EndTh(th, d1) + str;
                };
            };
            str = str.Substring(1, 1).ToUpper() + str.Substring(2);
            return str;
        }

        #region Private members
        private static string CurPhrase(decimal money,
            string word1, string word234, string wordmore,
            string sword1, string sword234, string swordmore)
        {
            //money=decimal.Round(money,2);
            decimal decintpart = decimal.Truncate(money);
            ulong intpart = decimal.ToUInt64(decintpart);
            string str = NumPhrase(intpart, true) + " ";
            byte endpart = (byte)(intpart % 100UL);
            if (endpart > 19) endpart = (byte)(endpart % 10);
            switch (endpart)
            {
                case 1: str += word1; break;
                case 2:
                case 3:
                case 4: str += word234; break;
                default: str += wordmore; break;
            }
            byte fracpart = decimal.ToByte((money - decintpart) * 100M);
            str += " " + ((fracpart < 10) ? "0" : "") + fracpart.ToString() + " ";
            if (fracpart > 19) fracpart = (byte)(fracpart % 10);
            switch (fracpart)
            {
                case 1: str += sword1; break;
                case 2:
                case 3:
                case 4: str += sword234; break;
                default: str += swordmore; break;
            };
            return str;
        }
        private static string EndTh(byte ThNum, byte Dek)
        {
            bool In234 = ((Dek >= 2) && (Dek <= 4));
            bool More4 = ((Dek > 4) || (Dek == 0));
            if (((ThNum > 2) && In234) || ((ThNum == 2) && (Dek == 1))) return "і";
            else if ((ThNum > 2) && More4) return "ів";
            else if ((ThNum == 2) && In234) return "і";
            else return "";
        }
        private static string EndDek1(byte Dek, bool IsMale)
        {
            if ((Dek > 2) || (Dek == 0)) return "";
            else if (Dek == 1)
            {
                if (IsMale) return "ин";
                else return "на";
            }
            else
            {
                if (IsMale) return "а";
                else return "а";
            }
        }
        #endregion
        #region WORD PROCESSING

        #endregion
    }
}
