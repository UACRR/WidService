using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioStationReports
{

    public static class Translit
    {
        private static Dictionary<char, string> _ukr = new Dictionary<char, string>
        {
            {'Ь' , ""    },
            {'\'', ""    },
            {'А' , "A"   },
            {'Б' , "B"   },
            {'В' , "V"   },
            {'Г' , "H"   },
            {'Д' , "D"   },
            {'Е' , "E"   },
            {'Є' , ""    },
            {'Ж' , "ZH"  },
            {'З' , "Z"   },
            {'И' , "Y"   },
            {'І' , "I"   },
            {'Ї' , ""    },
            {'Й' , ""    },
            {'К' , "K"   },
            {'Л' , "L"   },
            {'М' , "M"   },
            {'Н' , "N"   },
            {'О' , "O"   },
            {'П' , "P"   },
            {'Р' , "R"   },
            {'С' , "S"   },
            {'Т' , "T"   },
            {'У' , "U"   },
            {'Ф' , "F"   },
            {'Х' , "KH"  },
            {'Ц' , "TS"  },
            {'Ч' , "CH"  },
            {'Ш' , "SH"  },
            {'Щ' , "SHCH"},
            {'Ё' , "IO"  },
            {'Ъ' , ""    },
            {'Ы' , "Y"   },
            {'Э' , "E"   },
            {'№' , "#"   },
            {'…' , "..." },
            {'«' , "\""  },
            {'»' , "\""  },
            {'’' , "'"   },
            {'‘' , "'"   },
            {'–' , "-"   },
            {'—' , "-"   },
            {' ' , " "   },
        };

        private static Dictionary<char, string> _rus = new Dictionary<char, string>
        {
            {'\'', ""},
            {'А', "A"},
            {'Б', "B"},
            {'В', "V"},
            {'Г', "G"},
            {'Д', "D"},
            {'Е', "E"},
            {'Ё', "IO"},
            {'Ж', "ZH"},
            {'З', "Z"},
            {'И', "I"},
            {'Й', "Y"},
            {'К', "K"},
            {'Л', "L"},
            {'М', "M"},
            {'Н', "N"},
            {'О', "O"},
            {'П', "P"},
            {'Р', "R"},
            {'С', "S"},
            {'Т', "T"},
            {'У', "U"},
            {'Ф', "F"},
            {'Х', "KH"},
            {'Ц', "TS"},
            {'Ч', "CH"},
            {'Ш', "SH"},
            {'Щ', "SHCH"},
            {'Ь', ""},
            {'Ъ', ""},
            {'Ы', "I"},
            {'Э', "E"},
            {'Ю', "IU"},
            {'Я', "IA"},
            {'№', "#"},
            {'…', "..."},
            {'«', "\""},
            {'»', "\""},
            {'’', "'"},
            {'‘', "'"},
            {'–', "-"},
            {'—', "-"},
            {' ', " "},
        };

        public static string FromUkr(string source)
        {
            var sb = new StringBuilder();

            source = source.ToUpper();
            source = source.Replace("ЗГ", "ZGH");

            var isFirst = true;
            source.ToList().ForEach(c =>
            {
                if (c == 'Є')
                {
                    sb.Append(isFirst ? "YE" : "IE");
                }
                else if (c == 'Ї')
                {
                    sb.Append(isFirst ? "YI" : "I");
                }
                else if (c == 'Й')
                {
                    sb.Append(isFirst ? "Y" : "I");
                }
                else if (c == 'Ю')
                {
                    sb.Append(isFirst ? "YU" : "IU");
                }
                else if (c == 'Я')
                {
                    sb.Append(isFirst ? "YA" : "IA");
                }
                else
                {
                    if(_ukr.ContainsKey(c))
                    {
                        sb.Append(_ukr[c]);
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                isFirst = false;
            });

            var res = sb.ToString();
            res = NormalizeText(res);
            return res;
        }

        public static string FromRus(string source)
        {
            var sb = new StringBuilder();

            source = source.ToUpper();
            source.ToList().ForEach(c =>
            {
                if (_rus.ContainsKey(c))
                {
                    sb.Append(_rus[c]);
                }
                else
                {
                    sb.Append(c);
                }
            });

            var res = sb.ToString();
            res = NormalizeText(res);
            return res;
        }

        private static string NormalizeText(string value)
        {
            var npChars = new List<int>();
            for (int i = 0; i < value.Length; i++)
            {
                var chr = value[i];
                if (char.IsControl(chr))
                {
                    var cde = Convert.ToInt32(chr);
                    npChars.Add(cde);
                }
            }

            var retVal = value;
            npChars.ForEach(x =>
            {
                retVal = retVal.Replace((char)x, ' ');
            });
            while (retVal.Contains("  "))
            {
                retVal = retVal.Replace("  ", " ");
            }
            return retVal.Trim();
        }

    }
}
