using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WidUpdatesLib.UpdRecs
{
    public class UpdRec
    {
        protected const string TsAllCols = ", CreTs, CreUid, UpdTs, UpdUid";
        protected const string TsUpdCols = ", UpdTs, UpdUid";
        protected const string TsAllParams = ", @CreTs, @CreUid, @UpdTs, @UpdUid";
        protected const string TsUpdParams = ", @UpdTs, @UpdUid";

        protected object recEntity;
        public EntityInfo.EntityInfoEntry info;
        protected int? updWic;
        protected string updIswc;
        protected int? widId;

        public string recType;
        public int transSeqNr;
        public int recSeqNr;
        protected DateTime fileTime;

        protected SqlCommand cmd;
        public SqlCommand Cmd { get { return cmd; } }

        public void Init(string line)
        {
            var recCode = line.Substring(0, 3);
            info = EntityInfo.GetEntityInfoEntry(recCode);
            recEntity = Activator.CreateInstance(info.entityType);

            info.entityPropInfoList.ForEach(x =>
            {
                if (x.start < line.Length)
                {
                    x.propertyInfo.SetValue(recEntity, line.Substring(x.start - 1, x.size));
                }
            });

            recType = (string)recEntity.GetType().GetProperty("RecType").GetValue(recEntity);
            transSeqNr = int.Parse((string)recEntity.GetType().GetProperty("TransSeqNr").GetValue(recEntity));
            recSeqNr = int.Parse((string)recEntity.GetType().GetProperty("RecSeqNr").GetValue(recEntity));

        }

        public bool HasUpdWic()
        {
            return updWic != null;
        }

        public string GetUpdWicString()
        {
            if(updWic == null)
            {
                return "No WicCode";
            }
            else
            {
                return $"WicCode = {updWic}";
            }
        }

        public object GetRecEntity()
        {
            return recEntity;
        }

        public string ToHtmlRow()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<tr>");

            var recType = (string)recEntity.GetType().GetProperty("RecType").GetValue(recEntity);
            sb.AppendLine($"<td class=\"cellCenter\"><div class=\"field\">{recType}</div></td>");

            var recSeqNr = int.Parse((string)recEntity.GetType().GetProperty("RecSeqNr").GetValue(recEntity));
            sb.AppendLine($"<td class=\"cellCenter\"><div class=\"field\">{recSeqNr.ToString()}</div></td>");

            for(int i = 3; i < info.entityPropInfoList.Count; i++)
            {
                var propInfo = info.entityPropInfoList[i].propertyInfo;
                if(!propInfo.Name.StartsWith("Filler"))
                {
                sb.AppendLine($"<td class=\"cellVert\"><div class=\"label\">{propInfo.Name}</div><div class=\"field\">{propInfo.GetValue(recEntity)}</div></td>");
                }
            }

            sb.AppendLine("</tr>");
            return sb.ToString();
        }

        public bool IsIntrPtyRelated()
        {
            return recType == "SIP" || recType == "OIP" || recType == "SSR" || recType == "OSR";
        }

        public bool IsWpl()
        {
            return recType == "WPL";
        }

        public bool IsLnk()
        {
            return recType == "LNK";
        }

        public bool IsEwt()
        {
            return recType == "EWT";
        }

        public bool IsVer()
        {
            return recType == "VER";
        }

        public bool IsSipOrOip()
        {
            return recType == "SIP" || recType == "OIP";
        }

        public bool IsSoc()
        {
            return recType == "SOC";
        }


        public virtual void Apply()
        {
            FindMatchingRecord();
            if (widId == null)
            {
                Logger.WriteLine($"    {recType}-{recSeqNr}: Adding record into {info.widServiceEntityInfoEntry.tableName}");
                AddWidTblRecord();
            }
            else if (info.updateMethod == "I")
            {
                Logger.WriteLine($"    {recType}-{recSeqNr}: already exists in {info.widServiceEntityInfoEntry.tableName}, skipping");
            }
            else if(info.updateMethod != "I")
            {
                Logger.WriteLine($"    {recType}-{recSeqNr}: Updating record in {info.widServiceEntityInfoEntry.tableName}");
                UpdateWidTblRecord();
            }

            // Special case for ISWC
            if(IsSoc() && updWic != null && !string.IsNullOrEmpty(updIswc))
            {
                cmd.CommandText = @"
                    if not exists (select null from SocWid..WidIswc where Wic = @Wic and Iswc = @Iswc)
                    insert SocWid..WidIswc( Wic,  Iswc,  PrefIswc, CreTs,     CreUid,  UpdTs,     UpdUid )
                    values                ( @Wic, @Iswc, @Iswc,	   getdate(), 'UACRR', getdate(), 'UACRR')
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Wic", updWic);
                cmd.Parameters.AddWithValue("@Iswc", updIswc);
                cmd.ExecuteNonQuery();
            }
        }

        protected void FindMatchingRecord()
        {
            cmd.CommandText = info.cmdTextSearch;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@updWic", updWic);
            info.entityPropInfoList
                .Where(x => x.widServicePropInfo != null && (x.isForMatch || info.updateMethod == "I"))
                .ToList()
                .ForEach(x =>
                {
                    AddParameter(x);
                });
            using(var r = cmd.ExecuteReader())
            {
                if(r.HasRows)
                {
                    r.Read();
                    widId = r.GetInt32(0);
                }
            }
        }

        public void AddWidTblRecord(string extraParamName = null, object extraParamValue = null,
            string extraParamName1 = null, object extraParamValue1 = null)
        {
            int? seqNr = null;
            if (info.hasSeqNr)
            {
                cmd.CommandText = $"select isnull(max(SeqNr), 0) + 1\r\n" +
                    $"from SocWid..{info.widServiceEntityInfoEntry.tableName}\r\n" +
                    "where Wic = @updWic";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@updWic", updWic);
                seqNr = (int?)cmd.ExecuteScalar();
            }

            cmd.CommandText = info.cmdTextInsert;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@updWic", updWic);
            info.entityPropInfoList
                .Where(x => x.widServicePropInfo != null)
                .ToList()
                .ForEach(x =>
                {
                    AddParameter(x);
                });
            
            if(extraParamName != null)
            {
                cmd.Parameters.AddWithValue(extraParamName, extraParamValue);
            }

            if (extraParamName1!= null)
            {
                cmd.Parameters.AddWithValue(extraParamName1, extraParamValue1);
            }

            if (info.hasSeqNr)
            {
                cmd.Parameters.AddWithValue("@seqNr", seqNr);
            }

            if (info.fileTimeCol != null)
            {
                cmd.Parameters.AddWithValue($"@{info.fileTimeCol}", fileTime);
            }

            if (info.name == "RecIsw")
            {
                cmd.Parameters.AddWithValue($"@PrefIswc", updIswc);
            }

            AddTsAllParamValues(cmd);

            widId = Convert.ToInt32(cmd.ExecuteScalar());
            RegisterAffectedRecords();
        }

        protected void UpdateWidTblRecord()
        {
            cmd.CommandText = info.cmdTextUpdate;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@widId", widId);
            cmd.Parameters.AddWithValue("@updWic", updWic);
            info.entityPropInfoList
                .Where(x => x.widServicePropInfo != null)
                .ToList()
                .ForEach(x =>
                {
                    AddParameter(x);
                });

            if (info.fileTimeCol != null)
            {
                cmd.Parameters.AddWithValue($"@{info.fileTimeCol}", fileTime);
            }

            AddTsUpdParamValues(cmd);

            cmd.ExecuteNonQuery();

            RegisterAffectedRecords();
        }

        private void AddParameter(EntityInfo.EntityPropInfo entityPropInfo)
        {
            var propName = entityPropInfo.widServicePropInfo.propertyInfo.Name;
            var value = entityPropInfo.
                widServicePropInfo.
                fieldConverter(((string)entityPropInfo.propertyInfo.GetValue(recEntity)).Trim());
            if(propName.Equals("Shares", StringComparison.OrdinalIgnoreCase))
            {
                value = (decimal)value / 100;
            }
            cmd.Parameters.AddWithValue($"@{propName}", value);
        }
    
        public object GetPropValue(string propName)
        {
            return recEntity.GetType().GetProperty(propName).GetValue(recEntity);
        }

        public void RegisterAffectedRecords(string recType, int? wic)
        {
            //cmd.CommandText = "if not exists (select null from SocWidUpdates..WrkAffectedRecords where EntityName = @EntityName and Wic = @Wic)" +
            //    "insert SocWidUpdates..WrkAffectedRecords (EntityName, wic) values(@EntityName, @Wic)";
            //cmd.Parameters.Clear();
            //cmd.Parameters.AddWithValue("@EntityName", recType);
            //cmd.Parameters.AddWithValue("@Wic", wic);
            //cmd.ExecuteNonQuery();
        }

        public void RegisterAffectedRecords()
        {
            //RegisterAffectedRecords(info.name, updWic);
        }

        protected void AddTsAllParamValues(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@CreTs", fileTime);
            cmd.Parameters.AddWithValue("@CreUid", "UACRR");
            cmd.Parameters.AddWithValue("@UpdTs", fileTime);
            cmd.Parameters.AddWithValue("@UpdUid", "UACRR");
        }

        protected void AddTsUpdParamValues(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@UpdTs", fileTime);
            cmd.Parameters.AddWithValue("@UpdUid", "UACRR");
        }
    }
}
