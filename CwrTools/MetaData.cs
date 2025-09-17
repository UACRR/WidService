using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CwrTools.MetaData;

namespace CwrTools
{
    public static class MetaData
    {
        public class SpecField
        {
            public int Id { get; set; }
            public string RecordType { get; set; }
            public string Field { get; set; }
            public int Start { get; set; }
            public int Size { get; set; }
            public string Fmt { get; set; }
            public string Req { get; set; }
            public string Description { get; set; }
            public string ColName { get; set; }

            public bool IsMandatory { get { return Req == "M"; } }


            private object ParseA(string fieldText)
            {
                return fieldText.Trim();
            }

            private object ParseB(string fieldText)
            {
                if (fieldText == " ") return DBNull.Value;
                else return fieldText == "Y" ? true : false;
            }

            private object ParseF(string fieldText)
            {
                if (fieldText == "Y") return true;
                else if (fieldText == "Y") return false;
                else return DBNull.Value;
            }

            private object ParseD(string fieldText)
            {
                if (string.IsNullOrEmpty(fieldText.Trim()) || fieldText == "00000000")
                {
                    return DBNull.Value;
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

            private object ParseN(string fieldText)
            {
                var zeroString = new string('0', fieldText.Length);
                if (fieldText == zeroString)
                {
                    return DBNull.Value;
                }
                else
                {
                    return fieldText.Trim();
                }
            }

            private object ParseT(string fieldText)
            {
                if (string.IsNullOrEmpty(fieldText.Trim()) || fieldText == "000000")
                {
                    return DBNull.Value;
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

            private object ParseL(string fieldText)
            {
                return fieldText.Trim();
            }

            private object Parse(string line)
            {
                var fieldText = line.Substring(Start - 1, Size);
                switch (Fmt)
                {
                    case "A": return ParseA(fieldText);
                    case "B": return ParseB(fieldText);
                    case "D": return ParseD(fieldText);
                    case "F": return ParseF(fieldText);
                    case "N": return ParseN(fieldText);
                    case "L": return ParseL(fieldText);
                    case "T": return ParseT(fieldText);
                    default: return null;
                }
            }
            
            public object GetValue(string line)
            {
                return Parse(line);
            }

        }

        public class SpecRecord
        {
            public string RecordType { get; set; }
            public int SeqNr { get; set; }
            public bool IsTran { get; set; }
            public bool IsDetail { get; set; }
            public string TableName { get; set; }
            public string Description { get; set; }

            public List<SpecField> SpecFields{ get; set; }
        }

        private static List<SpecRecord> _specRecords;

        public static void Load()
        {
            LoadRecordSpecs();
            LoadFieldSpecs();
        }

        public static void LoadRecordSpecs()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = "select RecordType, SeqNr, IsTran, IsDetail, TableName, Description from SpecRecords order by SeqNr";
                using (var r = cmd.ExecuteReader())
                {
                    _specRecords = new List<SpecRecord>();
                    while (r.Read())
                    {
                        _specRecords.Add(new SpecRecord {
                            RecordType = r.GetString(0),
                            SeqNr = r.GetInt32(1),
                            IsTran = r.GetBoolean(2),
                            IsDetail = r.GetBoolean(3),
                            TableName = r.GetString(4),
                            Description = r.GetString(5),
                        });
                    }
                }
            });
        }

        public static void LoadFieldSpecs()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                    select t1.Id, t1.RecordType, t1.Field, t1.Start, t1.Size, t1.Fmt, t1.Req, t1.Description, t1.ColName
                    from SpecFields t1
	                    join SpecRecords t2 on t1.RecordType = t2.RecordType
                    order by t2.SeqNr, t1.Start
                ";

                var idxCurSpecRecord = 0;
                var curSpecRecord = _specRecords[idxCurSpecRecord];
                var curRecordType = curSpecRecord.RecordType;
                curSpecRecord.SpecFields = new List<SpecField>();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                            //var Id = r.GetInt32(0);
                            //var RecordType = r.GetString(1);
                            //var Field = r.GetString(2);
                            //var Start = r.GetInt32(3);
                            //var Size = r.GetInt32(4);
                            //var Fmt = r.GetString(5);
                            //var Req = r.GetString(6);
                            //var Description = r.GetString(7);
                           //var ColName = r.GetString(8);
                        var specField = new SpecField
                        {
                            Id = r.GetInt32(0),
                            RecordType = r.GetString(1),
                            Field = r.GetString(2),
                            Start = r.GetInt32(3),
                            Size = r.GetInt32(4),
                            Fmt = r.GetString(5),
                            Req = r.GetString(6),
                            Description = r.GetString(7),
                            ColName = r.GetString(8),
                        };
                        if(specField.RecordType != curRecordType)
                        {
                            specField.RecordType = curRecordType;
                            idxCurSpecRecord++;
                            curSpecRecord = _specRecords[idxCurSpecRecord];
                            curRecordType = curSpecRecord.RecordType;
                            curSpecRecord.SpecFields = new List<SpecField>();
                        }

                        curSpecRecord.SpecFields.Add(specField);
                    }
                }
            });
        }

        public static List<SpecRecord> GetSpecRecords()
        {
            return _specRecords;
        }

        public static List<SpecRecord> GetSpecTranRecords()
        {
            return _specRecords.Where(x => x.IsTran).ToList();
        }

        public static List<SpecRecord> GetSpecDetailRecords()
        {
            return _specRecords.Where(x => x.IsDetail).ToList();
        }

        public static SpecRecord GetSpecRecord(string recordType)
        {
            SpecRecord retVal = _specRecords
                .Single(x => string.Compare(recordType, x.RecordType, StringComparison.OrdinalIgnoreCase) == 0);
            return retVal;
        }

        public static string GetClassName(string recordType)
        {
            return $"Rec{recordType[0]}{char.ToLower(recordType[1])}{char.ToLower(recordType[2])}";
        }
    }
}
