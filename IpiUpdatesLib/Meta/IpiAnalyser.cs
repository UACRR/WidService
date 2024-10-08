using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IpiUpdatesLib
{
    public static class IpiAnalyser
    {
        class FieldDef
        {
            public string Field { get; set; }
            public int Offset { get; set; }
            public int Size { get; set; }
            public string Fmt { get; set; }
        }

        class RecDef
        {
            public string Code { get; set; }
            public List<FieldDef> Fields { get; set; }
        }

        private static Dictionary<string, RecDef> _recs;
        private static HashSet<string> _formats;
        private static HashSet<string> _fields ;
        private static Dictionary<string, string> _mapFieldToName;

        public static void LoadDefinitions()
        {
            _recs = new Dictionary<string, RecDef>();
            _formats = new HashSet<string>();
            _fields = new HashSet<string>();

            var lines = File.ReadAllLines(@"D:\UACRR\WID\Sources\WidService\IpiUpdatesLib\Meta\ExampleExcerpt.txt");
            for(int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var parts = line.Split('\t');
                if(parts[0].Trim().Equals("Record type", StringComparison.OrdinalIgnoreCase))
                {
                    var recType = parts[5];
                    if(!_recs.ContainsKey(recType))
                    {
                        var rec = new RecDef
                        {
                            Code = recType,
                            Fields = new List<FieldDef>(),
                        };
                        rec.Fields.Add(new FieldDef
                        {
                            Field = parts[0],
                            Offset = 1,
                            Size = int.Parse(parts[2]),
                            Fmt = parts[3]
                        });
                        if(!_fields.Contains(parts[0]))
                        {
                            _fields.Add(parts[0] + ":");
                        }
                        if (!_formats.Contains(parts[3]))
                        {
                            _formats.Add(parts[3]);
                        }
                        i++;
                        while(true)
                        {
                            line = lines[i];
                            parts = line.Split('\t');
                            if(parts.Length != 6)
                            {
                                _recs.Add(recType, rec);
                                break;
                            }
                            rec.Fields.Add(new FieldDef
                            {
                                Field = parts[0],
                                Offset = 1,
                                Size = int.Parse(parts[2]),
                                Fmt = parts[3]
                            });
                            if (!_fields.Contains(parts[0]))
                            {
                                _fields.Add(parts[0] + ":");
                            }
                            if (!_formats.Contains(parts[3]))
                            {
                                _formats.Add(parts[3]);
                            }
                            i++;
                        }
                    }
                }
            }
            CalcOffsets();
            BuildMapFieldToName();
            BuildEntityFiles();
            //File.WriteAllLines(@"D:\UACRR\WID\IPI\Docs\Fields.txt", fields.OrderBy(x => x).ToArray());
        }

        private static void CalcOffsets()
        {
            _recs.Values.ToList().ForEach(x =>
            {
                for(int i = 1; i < x.Fields.Count(); i++)
                {
                    x.Fields[i].Offset = x.Fields[i - 1].Offset + x.Fields[i - 1].Size;
                }
            });
        }

        private static void BuildMapFieldToName()
        {
            var lines = File.ReadAllLines(@"D:\UACRR\WID\Sources\WidService\IpiUpdatesLib\Meta\Fields.txt");
            _mapFieldToName = new Dictionary<string, string>();
            lines.ToList().ForEach(line =>
            {
                var parts = line.Split(':');
                _mapFieldToName.Add(parts[0], parts[1]);
            });
        }

        private static void BuildEntityFiles()
        {
            _recs.Values.ToList().ForEach(x =>
            {
                BuildEntityFile(x, @"D:\UACRR\WID\Sources\WidService\IpiUpdatesLib\Entities");
            });
        }

        public static void GenDomainEntities(string defFileFullName, string targetFilePath)
        {
            var lines = File.ReadAllLines(defFileFullName);
            RecDef recDef = null;
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if(line[0] == '#')
                {
                    if(recDef != null)
                    {
                        BuildEntityFile(recDef, targetFilePath);
                    }
                    recDef = new RecDef
                    {
                        Code = line.Substring(1),
                        Fields = new List<FieldDef>(),
                    };
                }
                else if(recDef != null)
                {
                    var parts = line.Split(' ');
                    recDef.Fields.Add(new FieldDef
                    {
                        Field = parts[0],
                        Offset = int.Parse(parts[1]),
                        Size = int.Parse(parts[2]),
                        Fmt = "",
                    });
                }
            }
        }

        private static void BuildEntityFile(RecDef recDef, string targetFilePath)
        {
            if(string.IsNullOrEmpty(recDef.Code))
            {
                return;
            }
            var code = $"{recDef.Code[0]}{char.ToLower(recDef.Code[1])}{char.ToLower(recDef.Code[2])}";
            Console.WriteLine($"public DbSet<Rec{code}> Rec{code} {{ get; set; }}");
            var sb = new StringBuilder();
            sb.AppendLine("using System.ComponentModel.DataAnnotations.Schema;");
            sb.AppendLine("");
            sb.AppendLine("namespace IpiUpdatesLib.Entities");
            sb.AppendLine("{");
            sb.AppendLine($"[Table(\"Dic{code}\")]");
            sb.AppendLine($"    public class Rec{code}");
            sb.AppendLine("    {");
            sb.AppendLine("        [Column(TypeName = \"int\")] public int Id { get; set; }");
            sb.AppendLine("        [Column(TypeName = \"int\")] public int UpdFileId { get; set; }");
            recDef.Fields.ForEach(x =>
            {
                var name = x.Field;
                sb.AppendLine($"        [CustomPosInFile({x.Offset}, {x.Size})] [Column(TypeName = \"varchar({x.Size})\")] public string {name} {{ get; set; }}");
            });
            sb.AppendLine("");
            sb.AppendLine("        public UpdFile UpdFile { get; set; }");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            sb.AppendLine("");

            var fileName = $"Rec{code}.cs";
            File.WriteAllText(Path.Combine(targetFilePath, fileName), sb.ToString());
        }
    }
}
