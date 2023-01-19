using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Engines.Helpers
{
    public class PeriodHelper
    {
        private static readonly Dictionary<int, string> _periods = new Dictionary<int, string>
        {
            [1] = Const.Month,
            [2] = Const.Quarter,
            [3] = Const.HalfYear,
            [4] = Const.Year,
        };

        private static readonly Dictionary<string, Dictionary<string, string>> _periodValues = new Dictionary<string, Dictionary<string, string>>
        {
            [Const.Month] = new Dictionary<string, string>
            {
                [Const.I_Each] = "за один календарний місяць",
                [Const.I_NumEach] = "кожного календарного місяця",
                [Const.I_Next] = "наступний місяць",
                [Const.I_NumEach2] = "кожного місяця",
                [Const.I_Previous] = "попередній місяць",
            },
            [Const.Quarter] = new Dictionary<string, string>
            {
                [Const.I_Each] = "за кожен квартал",
                [Const.I_NumEach] = "першого місяця кожного кварталу",
                [Const.I_Next] = "наступний квартал",
                [Const.I_NumEach2] = "першого місяця кожного кварталу",
                [Const.I_Previous] = "попередній квартал",
            },
            [Const.HalfYear] = new Dictionary<string, string>
            {
                [Const.I_Each] = "за кожне півріччя",
                [Const.I_NumEach] = "першого місяця кожного півріччя",
                [Const.I_Next] = "наступне півріччя",
                [Const.I_NumEach2] = "першого місяця кожного півріччя",
                [Const.I_Previous] = "попереднє півріччя",
            },
            [Const.Year] = new Dictionary<string, string>
            {
                [Const.I_Each] = "за один рік",
                [Const.I_NumEach] = "першого місяця кожного року",
                [Const.I_Next] = "наступний рік",
                [Const.I_NumEach2] = "першого місяця кожного року",
                [Const.I_Previous] = "попередній рік",
            },
        };

        public static Dictionary<string, string> GetValuesById(int periodId)
        {
            return _periodValues[_periods[periodId]];
        }
    }
}
