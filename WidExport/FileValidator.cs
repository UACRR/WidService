using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidExport
{
    public static class FileValidator
    {
        private static readonly Dictionary<string, int> recLen = new Dictionary<string, int>
        {
            { "HDR", 130 },
            { "GRH", 16 },
            { "WIA", 191 },
            { "WIU", 191 },
            { "SIP", 125 },
            { "SSR", 50 },
            { "PER", 114 },
            { "ALT", 84 },
            { "OIP", 125 },
            { "OSR", 50 },
            { "GRT", 24 },
            { "TRL", 24 },
        };
        public static List<int> Validate(string fileFullName)
        {
            var retVal = new List<int>();
            var lines = File.ReadAllLines(fileFullName).ToList();
            var lineIdx = 1;
            lines.ForEach(line =>
            {
                var recType = line.Substring(0, 3);
                var lineLen = line.Length;
                if (!recLen.ContainsKey(recType))
                {
                    retVal.Add(lineIdx);
                    Console.WriteLine(line);
                }
                else if (recLen[recType] != lineLen)
                {
                    retVal.Add(lineIdx);
                    Console.WriteLine(line);
                }
                else if (line.Contains('\t'))
                {
                    retVal.Add(lineIdx);
                    Console.WriteLine(line);
                }
                lineIdx++;
            });
            return retVal;
        }

        public static void ValidateWorkNamesInMs()
        {
            var occuredNonPrintable = new HashSet<int>();
            var cnt = 0;
            var idx = 1;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = "select Id, codeI, ObjId, name from MediaService..SeekObject where name is not null";
                using(var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        cnt++;
                        var id = r.GetInt32(0);
                        var codeI = r.GetInt32(1);
                        var objId = r.IsDBNull(2) ? 0 : r.GetInt32(2);
                        var name = r.GetString(3);
                        var nonPrintables = GetNonPrintables(name, occuredNonPrintable);
                        var newVName = NormalizeText(name);
                        if(nonPrintables.Count() > 0)
                        {
                            var printout = $"{objId}, [{newVName}]";
                            nonPrintables.ForEach(x =>
                            {
                                printout += $", Chr({x})";
                            });
                            Console.WriteLine($"{idx}) {id}, {codeI}, {printout}");
                            idx++;
                        }
                    }
                }
            });
            Console.WriteLine($"Total works processed: {cnt}");
        }

        public static List<int> GetNonPrintables(string value, HashSet<int> occuredNonPrintable)
        {
            var retVal = new List<int>();
            for(int i = 0; i < value.Length; i++)
            {
                var chr = value[i];
                if(char.IsControl(chr))
                {
                    var cde = Convert.ToInt32(chr);
                    retVal.Add(cde);
                    if(!occuredNonPrintable.Contains(chr))
                    {
                        occuredNonPrintable.Add(chr);
                    }
                }
            }
            return retVal;
        }

        public static string NormalizeText(string value)
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
            while(retVal.Contains("  "))
            {
                retVal = retVal.Replace("  ", " ");
            }
            return retVal.Trim();
        }
    }
}
