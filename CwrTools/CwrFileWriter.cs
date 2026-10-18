using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwrTools
{
    public class CwrFileWriter
    {
        private RecHdr AddHdr (CwrFile cwrFile)
        {
            var recHdr = new RecHdr
            {
                SenderType = "SO",
                SenderID = "000000140",
                SenderName = "NGO-UACRR",
                EDIVerNr = "01.10",
                CreationDate = DateTime.Now,
                CreationTime = DateTime.Now.TimeOfDay,
                TransmissionDate = DateTime.Now,
            };
            cwrFile.RecHdr = recHdr;
            return recHdr;
        }

        private void AddTrl (RecHdr recHdr)
        {
            var groupCount = recHdr.GroupList.Count;
            var tranCount = recHdr.GroupList.Sum(x => x.TranList.Count);
            var detailCount =  recHdr.GroupList
                .Select(x => new {
                        SumDetails = x.TranList.Sum(y => y.DetailList.Count)
                    }
                 )
                .ToList()
                . Sum(x => x.SumDetails);

            var recTrl = new RecTrl
            {
                GroupCount = groupCount.ToString().PadLeft(5, '0'),
                TranCount = tranCount.ToString().PadLeft(8, '0'),
                RecordCount = (detailCount + tranCount + groupCount * 2 + 2).ToString().PadLeft(8, '0'),
            };
            recHdr.RecTrl = recTrl;
        }

        private RecGrh AddGrh (RecHdr recHdr)
        {
            var recGrh = new RecGrh
            {
                TranType = "NWR",
                GroupID = "00001",
                VerNum = "02.20",
                BatchReq = "",
                SubmDistType = "SF",
                TranList = new List<BaseRecTran>(),
            };
            if(recHdr.GroupList == null)
            {
                recHdr.GroupList = new List<RecGrh> { recGrh };
            }
            else
            {
                recHdr.GroupList.Add(recGrh);
            }
            return recGrh;
        }
        
        private void AddGrt (RecGrh recGrh, string groupId)
        {
            var tranCount = recGrh.TranList.Count();
            var detailCount =  recGrh.TranList.Sum(x => x.DetailList.Count);
            var recGrt = new RecGrt
            {
                GroupID = groupId,
                TranCount = tranCount.ToString().PadLeft(8, '0'),
                RecordCount = (tranCount + detailCount + 2).ToString().PadLeft(8, '0'),
            };
            recGrh.RecGrt = recGrt;

        }
        
        private void AddNwrs(SqlCommand cmd, RecGrh recGrh)
        {
            cmd.CommandText = @"
                select WorkTitle, SubmWorkNr, ISWC, MwDistCat, VersionType
                from TmpWorksNwr
                order by SubmWorkNr
            ";
            using(var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    var recNwr = new RecNwr
                    {
                        WorkTitle = r.GetString(0),
                        SubmWorkNr = r.GetInt32(1).ToString(),
                        ISWC = r.IsDBNull(2) ? null : r.GetString(2),
                        MwDistCat = r.GetString(3),
                        VersionType = r.GetString(4),
                        DetailList = new List<BaseRecDetail>(),
                    };
                    recGrh.TranList.Add(recNwr);

                }
            }
        }
        
        private void AddSpus(SqlCommand cmd, RecGrh recGrh)
        {
            cmd.CommandText = @"
                select
                      ObjId
                    , PublisherSequenceNr
                    , IpNr
                    , PublisherName
                    , PublisherType
                    , PublisherIPNameNr
                    , AffSocNrPR
                    , OwnShrPR
                    , SocMR
                    , OwnShrMR
                    , PublisherIPBaseNr
                    , AroundWorld
                from TmpWorksSpu
                order by ObjId
            ";
            using(var r = cmd.ExecuteReader())
            {
                var idxRecNwr = 0;
                var objId = 0;
                while (r.Read())
                {
                    objId = r.GetInt32(0);

                    var recSpu = new RecSpu
                    {
                        PublisherSequenceNr = r.GetInt32(1).ToString(),
                        IpNr                = r.GetInt32(2).ToString(),
                        PublisherName       = r.IsDBNull(3) ? null : r.GetString(3),
                        PublisherType       = r.GetString(4),
                        PublisherIPNameNr   = r.IsDBNull(5) ? null : r.GetString(5),
                        AffSocNrPR          = r.GetString(6),
                        OwnShrPR            = r.GetInt32(7).ToString(),
                        SocMR               = r.GetString(8),
                        OwnShrMR            = r.GetInt32(9).ToString(),
                        PublisherIPBaseNr   = r.IsDBNull(10) ? null : r.GetString(10),
                    };

                    var recSpt = new RecSpt
                    {
                        IpNr            = r.GetInt32(2).ToString(),
                        Constant        = null,
                        CollShrPR       = "50",
                        CollShrMR       = "100",
                        CollShrSR       = "100",
                        IncExcIndicator = "I",
                        TISNumericCode  = r.IsDBNull(11) ? "0804" : r.GetBoolean(11) ? "2136" : "0804",
                        SharesChange    = null,
                        SeqNr           = "1",
                    };

                    RecNwr recNwr = null;
                    while (true)
                    {
                        recNwr = (RecNwr)recGrh.TranList[idxRecNwr];
                        if(int.Parse((recNwr.SubmWorkNr)) == objId)
                        {
                            break;
                        }
                        idxRecNwr++;
                    }
                    recNwr.DetailList.Add(recSpu);
                    recNwr.DetailList.Add(recSpt);
                }
            }
        }

        private void AddOpus(SqlCommand cmd, RecGrh recGrh)
        {
            cmd.CommandText = @"
                select
                      ObjId
                    , PublisherSequenceNr
                    , IpNr
                    , PublisherName
                    , PublisherType
                    , PublisherIPNameNr
                    , AffSocNrPR
                    , OwnShrPR
                    , SocMR
                    , OwnShrMR
                    , PublisherIPBaseNr
                from TmpWorksOpu
                order by ObjId
            ";
            using(var r = cmd.ExecuteReader())
            {
                var idxRecNwr = 0;
                var objId = 0;
                while (r.Read())
                {
                    objId = r.GetInt32(0);
                    var recOpu = new RecOpu
                    {
                        PublisherSequenceNr = r.GetInt32(1).ToString(),
                        IpNr                = r.GetInt32(2).ToString(),
                        PublisherName       = r.IsDBNull(3) ? null : r.GetString(3),
                        PublisherType       = r.GetString(4),
                        PublisherIPNameNr   = r.IsDBNull(5) ? null : r.GetString(5),
                        AffSocNrPR          = r.GetString(6),
                        OwnShrPR            = r.GetInt32(7).ToString(),
                        SocMR               = r.GetString(8),
                        OwnShrMR            = r.GetInt32(9).ToString(),
                        PublisherIPBaseNr   = r.IsDBNull(10) ? null : r.GetString(10),
                    };

                    RecNwr recNwr = null;
                    while (true)
                    {
                        recNwr = (RecNwr)recGrh.TranList[idxRecNwr];
                        if(int.Parse((recNwr.SubmWorkNr)) == objId)
                        {
                            break;
                        }
                        idxRecNwr++;
                    }
                    recNwr.DetailList.Add(recOpu);
                }
            }
        }

        private void AddSwrs(SqlCommand cmd, RecGrh recGrh)
        {
            cmd.CommandText = @"
                select
                      ObjId
	                , IpNr
	                , WriterLastName
	                , WriterFirstName
	                , WriterDesignationCode
	                , WriterIpNameNr
	                , AffSocNrPR
	                , OwnShrPR
	                , SocMR
	                , OwnShrMR
	                , WriterIpBaseNr
                    , AroundWorld
                from TmpWorksSwr
                order by ObjId
            ";
            using(var r = cmd.ExecuteReader())
            {
                var idxRecNwr = 0;
                var objId = 0;
                while (r.Read())
                {
                    objId = r.GetInt32(0);

                    var recSwr = new RecSwr
                    {
 	                    IpNr                    = r.GetInt32(1).ToString(),
	                    WriterLastName          = r.GetString(2),
	                    WriterFirstName         = r.GetString(3),
	                    WriterDesignationCode   = r.GetString(4),
	                    WriterIpNameNr          = r.GetString(5),
	                    AffSocNrPR              = r.GetString(6),
	                    OwnShrPR                = r.GetInt32(7).ToString(),
	                    SocMR                   = r.GetString(8),
	                    OwnShrMR                = r.GetInt32(9).ToString(),
                    };

                    var recSwt = new RecSwt
                    {
                        IpNr            = r.GetInt32(1).ToString(),
                        CollShrPR       = "100",
                        CollShrMR       = "100",
                        CollShrSR       = "100",
                        IncExcIndicator = "I",
                        TISNumericCode  = r.IsDBNull(11) ? "0804" : r.GetBoolean(11) ? "2136" : "0804",
                        SharesChange    = null,
                        SeqNr           = "1",
                    };

                    RecNwr recNwr = null;
                    while (true)
                    {
                        if (idxRecNwr > recGrh.TranList.Count - 1)
                        {
                            break;
                        }
                        recNwr = (RecNwr)recGrh.TranList[idxRecNwr];
                        if(int.Parse((recNwr.SubmWorkNr)) == objId)
                        {
                            break;
                        }
                        idxRecNwr++;
                    }

                    recNwr?.DetailList.Add(recSwr);
                    recNwr?.DetailList.Add(recSwt);
                }
            }
        }
        
        private void AddOwrs(SqlCommand cmd, RecGrh recGrh)
        {
            cmd.CommandText = @"
                select
	                  ObjId
	                , IpNr
	                , WriterLastName
	                , WriterFirstName
	                , WriterDesignationCode
	                , WriterIpNameNr
	                , OwnShrPR
	                , OwnShrMR
	                , WriterIpBaseNr
                from TmpWorksOwr
                order by ObjId
            ";
            using(var r = cmd.ExecuteReader())
            {
                var idxRecNwr = 0;
                var objId = 0;
                while (r.Read())
                {
                    objId = r.GetInt32(0);
                    var recOwr = new RecOwr
                    {
                         IpNr                   = r.GetInt32(1).ToString(),
                         WriterLastName         = r.GetString(2),
                         WriterFirstName        = r.IsDBNull(3) ? null : r.GetString(3),
                         WriterDesignationCode  = r.GetString(4),
                         WriterIpNameNr         = r.IsDBNull(5) ? null : r.GetString(5),
                         OwnShrPR               = r.GetInt32(6).ToString(),
                         OwnShrMR               = r.GetInt32(7).ToString(),
                         WriterIpBaseNr         = r.GetString(8),
                    };

                    RecNwr recNwr = null;
                    while (true)
                    {
                        recNwr = (RecNwr)recGrh.TranList[idxRecNwr];
                        if(int.Parse((recNwr.SubmWorkNr)) == objId)
                        {
                            break;
                        }
                        idxRecNwr++;
                    }
                    recNwr.DetailList.Add(recOwr);
                }
            }
        }

        private void AddAlts(SqlCommand cmd, RecGrh recGrh)
        {
            cmd.CommandText = @"
                select
	                  ObjId
	                , AltTitle
	                , TitleType
                from TmpWorksAlt
                order by ObjId            
            ";
            using(var r = cmd.ExecuteReader())
            {
                var idxRecNwr = 0;
                var objId = 0;
                while (r.Read())
                {
                    objId = r.GetInt32(0);
                    var recAlt = new RecAlt
                    {
                         AltTitle   = r.GetString(1).Replace('\t', ' ').Trim(' ', '\r', '\n'),
                         TitleType  = r.GetString(2),
                    };

                    RecNwr recNwr = null;
                    while (true)
                    {
                        if (idxRecNwr > recGrh.TranList.Count - 1)
                        {
                            break;
                        }
                        recNwr = (RecNwr)recGrh.TranList[idxRecNwr];
                        if(int.Parse((recNwr.SubmWorkNr)) == objId)
                        {
                            break;
                        }
                        idxRecNwr++;
                    }
                    recNwr?.DetailList.Add(recAlt);
                }
            }
        }
        
        private void AddPers(SqlCommand cmd, RecGrh recGrh)
        {
            cmd.CommandText = @"
                select
	                  ObjId
	                , LastName
                from TmpWorksPer
                order by ObjId
            ";
            using(var r = cmd.ExecuteReader())
            {
                var idxRecNwr = 0;
                var objId = 0;
                while (r.Read())
                {
                    objId = r.GetInt32(0);
                    var recPer = new RecPer
                    {
                         LastName   = r.GetString(1).Replace('\t', ' ').Trim(' ', '\r', '\n'),
                    };

                    RecNwr recNwr = null;
                    while (true)
                    {
                        if (idxRecNwr > recGrh.TranList.Count - 1)
                        {
                            break;
                        }
                        recNwr = (RecNwr)recGrh.TranList[idxRecNwr];
                        if(int.Parse((recNwr.SubmWorkNr)) == objId)
                        {
                            break;
                        }
                        idxRecNwr++;
                    }
                    recNwr?.DetailList.Add(recPer);
                }
            }
        }

        private void CreateInputInfo(SqlCommand cmd, PartnerGroupInfo partnerGroupInfo)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spCreateTmpWorksInfo";
            cmd.Parameters.AddWithValue("@groupId", partnerGroupInfo.Id);
            cmd.ExecuteNonQuery();
        }

        private void WriteFile(CwrFile cwrFile, string fileFullName)
        {
            using (StreamWriter sw = File.CreateText(fileFullName))
            {
                var recHdr = cwrFile.RecHdr;
                var line = recHdr.ToFileLine(0, 0);
                sw.WriteLine(line);

                for (var idxGrh = 0; idxGrh < recHdr.GroupList.Count; idxGrh++)
                {
                    var recGrh = recHdr.GroupList[idxGrh];
                    line = recGrh.ToFileLine(0, 0);
                    sw.WriteLine(line);

                    for (var idxTran = 0; idxTran < recGrh.TranList.Count; idxTran++)
                    {
                        var recTran = recGrh.TranList[idxTran];
                        line = recTran.ToFileLine(idxTran, 0);
                        sw.WriteLine(line);

                        for (var idxDetail = 0; idxDetail < recTran.DetailList.Count; idxDetail++)
                        {
                            var recDetail = recTran.DetailList[idxDetail];
                            line = recDetail.ToFileLine(idxTran, idxDetail + 1);
                            sw.WriteLine(line);
                        }

                    }

                    line = recGrh.RecGrt.ToFileLine(0, 0);
                    sw.WriteLine(line);
                }

                line = recHdr.RecTrl.ToFileLine(0, 0);
                sw.WriteLine(line);
            }
        }

        public string CreateFile(string folderPath, PartnerGroupInfo partnerGroupInfo)
        {
            var cwrFile = new CwrFile
            {
                CrwFileId = 0,
                FileFullName = "",

            };

            var recHdr = AddHdr(cwrFile);
            var recGrh = AddGrh(recHdr);

            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandTimeout = 0;

                CreateInputInfo(cmd, partnerGroupInfo);

                cmd.CommandType = CommandType.Text;
                AddNwrs(cmd, recGrh);
                AddSpus(cmd, recGrh); // Додає також SPT
                AddOpus(cmd, recGrh); // OPT не додаємо
                AddSwrs(cmd, recGrh); // Додає також SWT
                AddOwrs(cmd, recGrh); // OWT не додаємо
                AddAlts(cmd, recGrh);
                AddPers(cmd, recGrh);
            });

            AddGrt(recGrh, "00001");
            AddTrl(recHdr);

            var fileFullName = Path.Combine(folderPath, FormatFileName(partnerGroupInfo.IsV21 ? "V21" : "V22"));
            WriteFile(cwrFile, fileFullName);

            return fileFullName;
        }

        public string FormatFileName(string version)
        {
            var fileSeqNr = 0;
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = "select count(*) + 1 from CwrFiles where Status is not null and Direction = 'OUT'";
                fileSeqNr = (int)cmd.ExecuteScalar();

            });
            var fileSeqNrStr = fileSeqNr.ToString("D4");
            return $"CW{DateTime.Now.ToString("yy")}{fileSeqNrStr}140_000.{version}";
        }

    }
}
