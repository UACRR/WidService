using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using WidUpdatesLib.Entities;

namespace WidUpdatesLib.UpdRecs
{
    public class UpdRecTran : UpdRec
    {
        protected List<UpdRecDetail> detailRecs;

        public UpdRecTran(SqlCommand cmd, List<string> tranLines, DateTime fileTime)
        {
            this.cmd = cmd;
            this.fileTime = fileTime;
            Init(tranLines);
        }

        /*
         * Inits private variables. Resulting widTitleId == null means that record shoyld be added, othrwise updated
         */
        private void Init(List<string> tranLines)
        {
            base.Init(tranLines[0]);

            detailRecs = new List<UpdRecDetail>();
            for (int i = 1; i < tranLines.Count; i++)
            {
                var detailRecord = new UpdRecDetail(this);
                detailRecord.Init(tranLines[i]);
                detailRecs.Add(detailRecord);
            }

            updWic = null;
            if (info.piWicCode != null)
            {
                var updWicString = (string)info.piWicCode.GetValue(recEntity);
                if (!string.IsNullOrEmpty(updWicString) && !updWicString.Equals("0000000000"))
                {
                    updWic = int.Parse(updWicString);
                }
            }

            updIswc = null;
            if (info.piIswc != null)
            {
                updIswc = (string)info.piIswc.GetValue(recEntity);
            }
        }

        public bool HasRecLnk()
        {
            return detailRecs.Any(x => x.IsLnk());
        }


        public override void Apply()
        {
            // Processing LNK records that do not require WicCode of owner transaction
            if(updWic == null)
            {
                detailRecs.Where(x => x.IsLnk()).ToList().ForEach(x =>
                {
                    ProcessLnk(x);
                });
                return;
            }

            // Processing other records
            base.Apply();

            if(detailRecs.Count == 0)
            {
                return;
            }

            detailRecs.ForEach(x =>
            {
                x.PropagateFromTran(updWic, updIswc, fileTime);
            });

            detailRecs.Where(x => x.IsEwt()).ToList().ForEach(x =>
            {
                x.Apply();
            });

            ProcessIntrPtyRelated();

            detailRecs.Where(x => !x.IsIntrPtyRelated()).ToList().ForEach(x =>
            {
                if(x.IsWpl())
                {
                    ProcessWpl(x);
                }
                else
                {
                    x.Apply();
                }
            });
        }

        private void ProcessIntrPtyRelated()
        {
            Logger.WriteLine($"    Process IntrPty Related");
            Logger.WriteLine($"        Deleting old lines from widIntrPty and widShares");
            cmd.CommandText = "delete from SocWid..widIntrPty where Wic = @wic; delete from SocWid..widShares where Wic = @wic; ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", updWic);
            cmd.ExecuteNonQuery();

            RegisterAffectedRecords();

            var rolId = 0;
            detailRecs.Where(x => x.IsIntrPtyRelated()).ToList().ForEach(x =>
            {
                Logger.WriteLine($"        {x.recType}-{x.recSeqNr}: Adding record into {x.info.widServiceEntityInfoEntry.tableName}");
                if(x.IsSipOrOip())
                {
                    rolId++;
                    x.AddWidTblRecord("@RolId", rolId);
                }
                else
                {
                    x.AddWidTblRecord("@IntrPtyRolid", rolId);
                }
            });
        }

        private bool IsTitleMissing(int wic)
        {
            cmd.CommandText = "if exists(select null from SocWid..WidTitle where Wic = @wic) select 1 else select 0";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", wic);
            return (int)cmd.ExecuteScalar() == 0;
        }
        private void ProcessWpl(UpdRecDetail updRec)
        {
            Logger.WriteLine($"    WPL-{transSeqNr}");

            var wrtIpNameNr = (string)updRec.GetPropValue("WrtIpNameNr");
            var pubIpNameNr = (string)updRec.GetPropValue("PubIpNameNr");

            cmd.CommandText = "select RolId from SocWid..widIntrPty where wic = @wic and IpNameNr = @wrtIpNameNr";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", updWic);
            cmd.Parameters.AddWithValue("@wrtIpNameNr", wrtIpNameNr);
            var wrtRolId = (int)cmd.ExecuteScalar();

            cmd.CommandText = "select RolId from SocWid..widIntrPty where wic = @wic and IpNameNr = @pubIpNameNr";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", updWic);
            cmd.Parameters.AddWithValue("@pubIpNameNr", pubIpNameNr);
            var pubRolIdObj = cmd.ExecuteScalar();

            if (pubRolIdObj == null)
            {
                return;
            }

            var pubRolId = (int)pubRolIdObj;

            cmd.CommandText = 
                "if exists (select null from SocWid..widWtrPubRel where wic = @wic and WtrIntrPtySeq = @WtrIntrPtySeq and PubIntrPtySeq = @PubIntrPtySeq) select 1 else select 0";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", updWic);
            cmd.Parameters.AddWithValue("@WtrIntrPtySeq", wrtRolId);
            cmd.Parameters.AddWithValue("@PubIntrPtySeq", pubRolId);
            var exists = (int)cmd.ExecuteScalar();
            if(exists == 1)
            {
                Logger.WriteLine($"    {updRec.GetPropValue("RecType")}-{int.Parse((string)updRec.GetPropValue("RecSeqNr"))}: already exists in widWtrPubRel, skipping");
                return;
            }

            Logger.WriteLine($"        {recType}-{recSeqNr}: Adding record into {info.widServiceEntityInfoEntry.tableName}");
            updRec.AddWidTblRecord("@WtrIntrPtySeq", wrtRolId, "@PubIntrPtySeq", pubRolId);
        }

        public void ProcessLnk(UpdRecDetail updRec)
        {
            Logger.WriteLine($"    LNK-{transSeqNr}");
            var rec = (RecLnk)updRec.GetRecEntity();

            // Verify that references are correct
            if(IsTitleMissing(int.Parse(rec.WicDelWrk)))
            {
                Logger.WriteLine($"        Music Work to delete {rec.WicDelWrk} does not exist in the database");
                return;
            }
            if (IsTitleMissing(int.Parse(rec.WicMergedWrk)))
            {
                Logger.WriteLine($"        Music Work to merge {rec.WicMergedWrk} does not exist in the database");
                return;
            }

            // Get ISWCs
            cmd.CommandText = "select Iswc, PrefIswc from SocWid..widIswc where Wic = @wic";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", rec.WicDelWrk);
            var delIswcs = new DataTable();
            using(var da = new SqlDataAdapter(cmd))
            {
                da.Fill(delIswcs);
            }

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", rec.WicMergedWrk);
            var mergedIswcs = new DataTable();
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(mergedIswcs);
            }

            // Add ISWCs from deleted work
            Logger.WriteLine($"        Adding ISWCs to music work {rec.WicMergedWrk}");

            foreach (DataRow row in delIswcs.Rows)
            {
                cmd.CommandText = "if not exists (select null from SocWid..widIswc where Wic = @mergedWic and Iswc = @iswc)\r\n" +
                    $"insert SocWid..widIswc(Wic, Iswc, PrefIswc{TsAllCols}) values(@mergedWic, @iswc, @prefIswc{TsAllParams})";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mergedWic", int.Parse(rec.WicMergedWrk));
                cmd.Parameters.AddWithValue("@iswc", (string)row[0]);
                cmd.Parameters.AddWithValue("@prefIswc", updIswc);
                AddTsAllParamValues(cmd);
                cmd.ExecuteNonQuery();

                Logger.WriteLine($"        Registering SocIswc");
                RegisterAffectedRecords("SocIsw", int.Parse(rec.WicMergedWrk));
            }

            // Update PrefIswcs of merged works
            Logger.WriteLine($"        Updating preferred ISWC of music work {rec.WicMergedWrk}");
            foreach (DataRow row in mergedIswcs.Rows)
            {
                if ((string)row[1] != updIswc)
                {
                    cmd.CommandText = "update SocWid..widIswc set PrefIswc = @prefIswc where wic = @mergedWic and Iswc = @iswc";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mergedWic", int.Parse(rec.WicMergedWrk));
                    cmd.Parameters.AddWithValue("@iswc", (string)row[0]);
                    cmd.Parameters.AddWithValue("@prefIswc", updIswc);
                    cmd.ExecuteNonQuery();
                    RegisterAffectedRecords("SocIsw", int.Parse(rec.WicMergedWrk));
                }
            }

            // Delete music work and related records
            Logger.WriteLine($"        Deleting music work {rec.WicDelWrk}");
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", int.Parse(rec.WicDelWrk));
            EntityInfo.GetEntityInfoList().Where(x => x.widServiceEntityInfoEntry != null).ToList().ForEach(entityInfo =>
            {
                if(entityInfo.tableName.StartsWith("wid", StringComparison.OrdinalIgnoreCase))
                {
                    cmd.CommandText = $"delete from SocWid..{entityInfo.widServiceEntityInfoEntry.tableName} where Wic = @wic";
                    cmd.ExecuteNonQuery();
                    try
                    {
                        RegisterAffectedRecords(entityInfo.name, int.Parse(rec.WicDelWrk));
                    }
                    catch(Exception ex)
                    {
                        Logger.WriteLine($"        Error registering {entityInfo.name}: {ex.Message}");
                        throw;
                    }
                }
            });
        }


        public void ToHtmlFile(string path)
        {
            var sb = new StringBuilder();
            sb.AppendLine(@"
                <!DOCTYPE html>
                <html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml\"">
                <head>
                <meta charset = ""utf-8"" />
                 <style>
                     .label {
                            font-family: Tahoma;
                            font-size: x-small;
                            font-style: italic;
                     }
                    .field {
                        font-family: Tahoma;
                        font-size: small;
                        white-space: nowrap;
                    }
                    .cellCenter {
                        padding-left: 5px;
                        padding-right: 5px;
                        vertical-align: central;
                    }
                    .cellVert {
                        padding-left: 5px;
                        padding-right: 5px;
                        vertical-align: top;
                    }
                    tr:nth-child(even) {
                            background-color: #f2f2f2;
                    }
                </style >
            </head >
            <body>
            <table>");

            sb.AppendLine(ToHtmlRow());
            detailRecs.ForEach(x => sb.AppendLine(x.ToHtmlRow()));

            sb.AppendLine(@"
                </table>
            </body>
            </html>");

            var fileName = $"{GetPropValue("RecType")}-{GetPropValue("TransSeqNr")}.html";
            File.WriteAllText(Path.Combine(path, fileName), sb.ToString());
        }
    
    }
}
