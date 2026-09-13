using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareCalc
{

    public static class Translit
    {
        private static Dictionary<string, char> _lat = new Dictionary<string, char>
        {
            {"A"    , 'А' },
            {"B"    , 'Б' },
            {"V"    , 'В' },
            {"H"    , 'Г' },
            {"G"    , 'Г' },
            {"D"    , 'Д' },
            {"E"    , 'Е' },
            {"Z"    , 'З' },
            {"Y"    , 'И' },
            {"I"    , 'І' },
            {"J"    , 'Й' },
            {"K"    , 'К' },
            {"L"    , 'Л' },
            {"M"    , 'М' },
            {"N"    , 'Н' },
            {"O"    , 'О' },
            {"P"    , 'П' },
            {"R"    , 'Р' },
            {"S"    , 'С' },
            {"T"    , 'Т' },
            {"U"    , 'У' },
            {"F"    , 'Ф' },
            {"KH"   , 'Х' },
            {"TS"   , 'Ц' },
            {"CH"   , 'Ч' },
            {"SH"   , 'Ш' },
            {"SHCH" , 'Щ' },
            {"IO"   , 'Ё' },
            {"YE"   , 'Є' },
            {"YU"   , 'Ю' },
            {"YA"   , 'Я' },
            {"ZH"   , 'Ж' },
            {"JA"   , 'Я' },
            {" "    , ' ' },
        };

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

        public static string FstCharFromLat(string source)
        {
            source = source.Trim();
            if (char.IsDigit(source[0]))
                return source.Substring(0, 1);

            var startTxt = "";
            for(var cntChar = 4; cntChar > 0; cntChar--)
            {
                startTxt = source.Substring(0, Math.Min(cntChar, source.Length)).ToUpper();
                if(_lat.ContainsKey(startTxt))
                    return _lat[startTxt].ToString();
            }
            return "";
        }

        public static string FstNCharsFromLat(string source, int cnt)
        {
            var retVal = "";
            source = source.Trim();
            while(retVal.Length < cnt)
            {
                var cntCharsProcessed = 0;
                if (char.IsDigit(source[0]))
                {
                    retVal += source.Substring(0, 1);
                    cntCharsProcessed += 1;
                }
                else
                {
                    var startTxt = "";
                    for(var cntChar = 4; cntChar > 0; cntChar--)
                    {
                        startTxt = source.Substring(0, Math.Min(cntChar, source.Length)).ToUpper();
                        if(_lat.ContainsKey(startTxt))
                        {
                            retVal += _lat[startTxt].ToString();
                            cntCharsProcessed += cntChar;
                            break;
                        }
                    }
                }

                if (cntCharsProcessed == 0 || source.Length <= cntCharsProcessed)
                    break;

                source = source.Substring(cntCharsProcessed).ToUpper();

            }
            return retVal;
        }

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
