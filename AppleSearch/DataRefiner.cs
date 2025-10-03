using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleSearch
{
    public static class DataRefiner
    {
        public class Field
        {
            public string Name { get; set; }
        }
        public class Table
        {
            public string Name { get; set; }
            public string[] JoinFieldNames { get; set; }
            public Field[] Fields { get; set; }
        }

        public static Table[] _tables = new Table[]
        {
            new Table {
                Name = "ObjectRight",
                JoinFieldNames = new string[] {"ObjId" },
                Fields = new Field[] {
                    new Field {Name = "Name"},
                    new Field {Name = "Author"},
                    new Field {Name = "Performer"},
                }
            },
            new Table {
                Name = "MediaTrack",
                JoinFieldNames = new string[] {"ObjId" },
                Fields = new Field[] {
                    new Field {Name = "Name"},
                    new Field {Name = "lyrics"},
                    new Field {Name = "composers"},
                    new Field {Name = "performers"},
                }
            },
            new Table {
                Name = "SeekObject",
                JoinFieldNames = new string[] {"Id" },
                Fields = new Field[] {
                    new Field {Name = "Name"},
                }
            },
            new Table {
                Name = "Authors",
                JoinFieldNames = new string[] {"ObjId" },
                Fields = new Field[] {
                    new Field {Name = "authorName"},
                }
            },
            new Table {
                Name = "Performer",
                JoinFieldNames = new string[] {"PerId" },
                Fields = new Field[] {
                    new Field {Name = "perName"},
                }
            },
            new Table {
                Name = "AnketaCompany",
                JoinFieldNames = new string[] {"CustId" },
                Fields = new Field[] {
                    new Field {Name = "Name"},
                    new Field {Name = "ShortName"},
                }
            },
            new Table {
                Name = "AnketaPerson",
                JoinFieldNames = new string[] {"CustId" },
                Fields = new Field[] {
                    new Field {Name = "FirstName"},
                    new Field {Name = "LastName"},
                    new Field {Name = "SurName"},
                    new Field {Name = "NikName"},
                }
            },
            new Table {
                Name = "AnketaExternal",
                JoinFieldNames = new string[] {"CustId" },
                Fields = new Field[] {
                    new Field {Name = "Name"},
                }
            },
            new Table {
                Name = "ClnBusinessPlace",
                JoinFieldNames = new string[] {"PlaceId" },
                Fields = new Field[] {
                    new Field {Name = "placeName"},
                    new Field {Name = "placeCountry"},
                    new Field {Name = "placeRegion"},
                    new Field {Name = "placeCity"},
                    new Field {Name = "placeAddress"},
                    new Field {Name = "placePhone"},
                }
            },
            new Table {
                Name = "RegisterItem",
                JoinFieldNames = new string[] {"RegId", "RegIItemId" },
                Fields = new Field[] {
                    new Field {Name = "ItemName"},
                    new Field {Name = "performer"},
                    new Field {Name = "authorMusic"},
                    new Field {Name = "authorText"},
                }
            },
            new Table {
                Name = "RHCatalogItem",
                JoinFieldNames = new string[] {"ItemId" },
                Fields = new Field[] {
                    new Field {Name = "objName"},
                    new Field {Name = "authorName"},
                    new Field {Name = "cmName"},
                }
            },
        };

        private static void SpRefineTextsAddLineForField (StreamWriter sw, string tableName, string fieldName)
        {
            var tableNamePadded = tableName.PadRight (20);
            var fieldNamePadded = fieldName.PadRight (14);
            sw.WriteLine($"update {tableNamePadded} set {fieldNamePadded} = dbo.ClrRefineText({fieldNamePadded}) where {fieldNamePadded} is not null and dbo.ClrNeedRefineText({fieldNamePadded}) = 1");
        }

        public static void GenerateSpRefineTexts(string fileFullName)
        {
            using (StreamWriter sw = new StreamWriter(fileFullName))
            {
                sw.WriteLine("use MediaService");
                sw.WriteLine("go");
                sw.WriteLine("create or alter procedure spRefineTexts");
                sw.WriteLine("as");
                sw.WriteLine("begin");

                foreach (var table in _tables)
                {
                    foreach (var field in table.Fields)
                    {
                        SpRefineTextsAddLineForField(sw, table.Name, field.Name);
                    }
                    sw.WriteLine("");
                }

                sw.WriteLine("end");
                sw.WriteLine("go");
            }
}

        private static void GenerateRefineTrigger(StreamWriter sw, Table table)
        {
            sw.WriteLine($"create or alter trigger trig{table.Name}Refine on {table.Name} after insert, update");
            sw.WriteLine("as");
            sw.WriteLine("begin");
            sw.WriteLine("    set nocount on;");
            sw.WriteLine($"    if trigger_nestlevel(object_id('trig{table.Name}Refine')) > 1 return");

            sw.Write($"    if");
            for (var idx = 0; idx < table.Fields.Length; idx++)
            {
                var fieldName = table.Fields[idx].Name;
                if (idx > 0) sw.Write(" or ");
                sw.Write($" update({fieldName}) ");
            }
            sw.Write("\r\n");

            sw.WriteLine($"    begin");
            sw.WriteLine($"        update t1");
            sw.WriteLine($"        set");

            for (var idx = 0; idx < table.Fields.Length; idx++)
            {
                var fieldName = table.Fields[idx].Name;
                if (idx > 0) sw.Write(", "); else sw.Write("          ");
                sw.Write($" t1.{fieldName} =  t2.{fieldName}");
            }
            sw.Write("\r\n");

            sw.WriteLine($"        from {table.Name} t1");
            sw.Write($"            join inserted t2 on ");

            for (var idx = 0; idx < table.JoinFieldNames.Length; idx++)
            {
                var fieldName = table.JoinFieldNames[idx];
                if (idx > 0) sw.Write(" and ");
                sw.Write($"t1.{fieldName} = t2.{fieldName}");
            }
            sw.Write("\r\n");

            sw.WriteLine($"    end");
            sw.WriteLine("end");
            sw.WriteLine("go");
            sw.WriteLine("");
        }

        public static void GenerateRefineTriggers(string fileFullName)
        {
            using (StreamWriter sw = new StreamWriter(fileFullName))
            {
                sw.WriteLine("use MediaService");
                sw.WriteLine("go");
                sw.WriteLine("");
                
                foreach (var table in _tables)
                {
                    GenerateRefineTrigger(sw, table);
                }
            }
        }
    }
}
