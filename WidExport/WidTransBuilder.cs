using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WidExport.Entities;

namespace WidSubmit
{
    public class WidTransBuilder
    {
        public class ObjIdTranType
        {
            public int ObjId { get; set; }
            public string TranType { get; set; }
        }
        public class Sip
        {
            public RecSip RecSip { get; set; }
            public List<RecSsr> RecSsrList { get; set; }
        }
        public class Oip
        {
            public RecOip RecOip { get; set; }
            public List<RecOsr> RecOsrList { get; set; }
        }
        public class Wia
        {
            public RecWia RecWia { get; set; }
            public List<RecAlt> RecAltList { get; set; }
            public List<RecPer> RecPerList { get; set; }
            public List<Sip> SipList { get; set; }
            public List<Oip> OipList { get; set; }
        }
        public class Grh
        {
            public RecGrh RecGrh { get; set; }
            public List<Wia> WiaList { get; set; }
            public RecGrt RecGrt { get; set; }
        }
        public class Hdr
        {
            public RecHdr RecHdr { get; set; }
            public List<Grh> GrhList { get; set; }
            public RecTrl RecTrl { get; set; }
        }

        private readonly Dictionary<string, Type> _recTypeToEntityType = new Dictionary<string, Type>() {
            {"HDR", typeof(RecHdr)},
            {"TRL", typeof(RecTrl)},
            {"GRH", typeof(RecGrh)},
            {"GRT", typeof(RecGrt)},
            {"ACK", typeof(RecAck)},
            {"MSG", typeof(RecMsg)},
        };

        private readonly Dictionary<string, string> _recTypeToTableName = new Dictionary<string, string> () {
            {"HDR", "RecHdrRsp"},
            {"TRL", "RecTrlRsp"},
            {"GRH", "RecGrhRsp"},
            {"GRT", "RecGrtRsp"},
            {"ACK", "RecAck"},
            {"MSG", "RecMsg"},
        };

        private readonly string _connectStringSocWid;
        private readonly string _connectStringSocWidSubmit;

        public WidTransBuilder()
        {

        }
        public WidTransBuilder(string connectStringSocWid, string connectStringSocWidSubmit)
        {
            _connectStringSocWid = connectStringSocWid;
            _connectStringSocWidSubmit = connectStringSocWidSubmit;
        }

        private int CreateWiaWiuRecords(List<Wia> wiaWiuList, int submFileId, int grpSeqNr)
        {
            var wiaRecCnt = 0;
            var tranSeqNrWia = 0;
            var tranSeqNrWiu = 0;
            wiaWiuList.ForEach(wia =>
            {
                var recSeqNr = 0;
                var tranSeqNr = wia.RecWia.TranType.ToLower() == "wia" ? tranSeqNrWia : tranSeqNrWiu;

                wia.RecWia.SubmFileId = submFileId;
                wia.RecWia.TransSeqNr = tranSeqNr.ToString("D8");
                wia.RecWia.RecSeqNr = recSeqNr.ToString("D8");
                wia.RecWia.GrpSeqNr = grpSeqNr;
                recSeqNr++;

                wia.SipList.ForEach(sip =>
                {
                    sip.RecSip.SubmFileId = submFileId;
                    sip.RecSip.TransSeqNr = tranSeqNr.ToString("D8");
                    sip.RecSip.RecSeqNr = recSeqNr.ToString("D8");
                    sip.RecSip.GrpSeqNr = grpSeqNr;
                    recSeqNr++;

                    sip.RecSsrList.ForEach(ssr =>
                    {
                        ssr.SubmFileId = submFileId;
                        ssr.TransSeqNr = tranSeqNr.ToString("D8");
                        ssr.RecSeqNr = recSeqNr.ToString("D8");
                        ssr.GrpSeqNr = grpSeqNr;
                        recSeqNr++;
                    });

                    wiaRecCnt += 1 + sip.RecSsrList.Count;
                });

                wia.OipList.ForEach(oip =>
                {
                    oip.RecOip.SubmFileId = submFileId;
                    oip.RecOip.TransSeqNr = tranSeqNr.ToString("D8");
                    oip.RecOip.RecSeqNr = recSeqNr.ToString("D8");
                    oip.RecOip.GrpSeqNr = grpSeqNr;
                    recSeqNr++;

                    oip.RecOsrList.ForEach(osr =>
                    {
                        osr.SubmFileId = submFileId;
                        osr.TransSeqNr = tranSeqNr.ToString("D8");
                        osr.RecSeqNr = recSeqNr.ToString("D8");
                        osr.GrpSeqNr = grpSeqNr;
                        recSeqNr++;
                    });

                    wiaRecCnt += 1 + oip.RecOsrList.Count;
                });

                wia.RecAltList.ForEach(alt =>
                {
                    alt.SubmFileId = submFileId;
                    alt.TransSeqNr = tranSeqNr.ToString("D8");
                    alt.RecSeqNr = recSeqNr.ToString("D8");
                    alt.GrpSeqNr = grpSeqNr;
                    recSeqNr++;
                });

                wia.RecPerList.ForEach(per =>
                {
                    per.SubmFileId = submFileId;
                    per.TransSeqNr = tranSeqNr.ToString("D8");
                    per.RecSeqNr = recSeqNr.ToString("D8");
                    per.GrpSeqNr = grpSeqNr;
                    recSeqNr++;
                });

                wiaRecCnt += 1 + wia.RecAltList.Count + wia.RecPerList.Count;

                if(wia.RecWia.TranType.ToLower() == "wia")
                {
                    tranSeqNrWia++;
                }
                {
                    tranSeqNrWiu++;
                }
            });
            return wiaRecCnt;
        }

        public void CreateSubmFile(int groupId)
        {
            try
            {
                Helpers.RunSqlSocWidSubmitT(cmd =>
                {
                    // Створюємо рядок файлу в БД або використовуємо останній не переданий (в цьому видадку видаляємо повязану інформацію)
                    var submFileId = 0;
                    var oldSubmFileName = "";

                    cmd.CommandTimeout = 60;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spSubmFileSelectCurrent";
                    cmd.Parameters.Clear();
                    using (var r = cmd.ExecuteReader())
                    {
                        r.Read();
                        submFileId = r.GetInt32(0);
                        oldSubmFileName = r.GetString(1);
                    }

                    if(submFileId != 0)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spSubmFileClearRecRefs";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@submFileId", submFileId);
                        cmd.ExecuteNonQuery();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spSubmFileClear";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@submFileId", submFileId);
                        cmd.ExecuteNonQuery();

                        }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spWidSubmGroupClearRecRefs";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@groupId", groupId);
                    cmd.ExecuteNonQuery();

                    // Вибираємо затверджені до передачі твори
                    var objIdTranTypeList = new List<ObjIdTranType>();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"
                        select ObjId, TranType
                        from WidSubmGroupWork 
                        where WidSubmGroupId = @groupId 
                            and ShouldResubmit = 1
                    ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@groupId", groupId);
                    cmd.Parameters.AddWithValue("@status", (int)WidSubmGroupWorkStatusEnum.Accepted);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            objIdTranTypeList.Add(new ObjIdTranType {
                                ObjId = r.GetInt32(0),
                                TranType = r.GetString(1),
                            });
                        }
                    }

                    // Створюємо і заповнюємо Wia транзакції
                    var wiaList = new List<Wia>();
                    var wiuList = new List<Wia>();
                    objIdTranTypeList.ForEach(objIdTranType =>
                    {
                        var wia = CreateWia(cmd, submFileId, groupId, objIdTranType);
                        if(wia.RecWia.TranType.ToUpper() == "A")
                        {
                            wiaList.Add(wia);
                        }
                        else
                        {
                            wiuList.Add(wia);
                        }
                    });

                    // Створюємо і заповнюємо структуру файлу в памяті
                    var hdr = new Hdr();

                    hdr.RecHdr = new RecHdr
                    {
                        SubmFileId = submFileId,
                        RecType = "HDR",
                        SenderType = "SO",
                        SenderId = "000000140",
                        SenderName = "UACRR",
                        StdVerNr = "02.10",
                        CreD = DateTime.Now.ToString("yyyyMMdd"),
                        CreT = DateTime.Now.ToString("hhmmss"),
                        TransmitD = DateTime.Now.ToString("yyyyMMdd"),
                        Filler = "",
                        FileNameRef = "",
                    };

                    var wiaRecCnt = CreateWiaWiuRecords(wiaList, submFileId, 0);
                    var wiuRecCnt = CreateWiaWiuRecords(wiuList, submFileId, wiaRecCnt == 0 ? 0 : 1);

                    var RecGrhWia = wiaRecCnt == 0 ? null : new Grh
                    {
                        RecGrh = new RecGrh
                        {
                            SubmFileId = submFileId,
                            RecType = "GRH",
                            TransType = "WIA",
                            GrId = "0",
                            VerNr = "01.30",
                        },
                        WiaList = wiaList,
                        RecGrt = new RecGrt
                        {
                            SubmFileId = submFileId,
                            RecType = "GRT",
                            GrId = "0",
                            TransCnt = wiaList.Count.ToString("D8"),
                            RecCnt = (wiaRecCnt + 2).ToString("D8"),
                        },
                    };

                    var RecGrhWiu = wiuRecCnt == 0 ? null : new Grh
                    {
                        RecGrh = new RecGrh
                        {
                            SubmFileId = submFileId,
                            RecType = "GRH",
                            TransType = "WIU",
                            GrId = RecGrhWia == null ? "0" : "1",
                            VerNr = "01.30",
                        },
                        WiaList = wiuList,
                        RecGrt = new RecGrt
                        {
                            SubmFileId = submFileId,
                            RecType = "GRT",
                            GrId = "0",
                            TransCnt = wiuList.Count.ToString("D8"),
                            RecCnt = (wiuRecCnt + 2).ToString("D8"),
                        },
                    };

                    hdr.GrhList = new List<Grh>();

                    if(RecGrhWia != null)
                    {
                        hdr.GrhList.Add(RecGrhWia);
                    }

                    if(RecGrhWiu != null)
                    {
                        hdr.GrhList.Add(RecGrhWiu);
                    }

                    hdr.RecTrl = new RecTrl
                    {
                        SubmFileId = submFileId,
                        RecType = "TRL",
                        GrCnt = RecGrhWia == null ? "1" : RecGrhWiu == null ? "1" : "2",
                        TransCnt = (wiaList.Count + wiuList.Count).ToString("D8"),
                        RecCnt = (
                                  (wiaRecCnt == 0 ? 0 : wiaRecCnt + 2)
                                + (wiuRecCnt == 0 ? 0 : wiuRecCnt + 2)
                                + 2
                            )
                            .ToString("D8"),
                    };

                    // Заносимо інформацію в БД
                    SaveUpdFileInDb(cmd, hdr);

                    // Створюємо реальний файл
                    var folderPath = Path.Combine(ConfigurationManager.AppSettings["FileExchangeRootDir"], "OutFiles");
                    if (!string.IsNullOrEmpty(oldSubmFileName))
                    {
                        File.Delete(Path.Combine(folderPath, oldSubmFileName));
                    }
                    var fileName = SaveUpdFile(hdr, folderPath);

                    // Запамятовуємо назву файлу
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update SubmFile set Name = @name, WidSubmGroupId = @groupId where Id = @submFileId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@submFileId", submFileId);
                    cmd.Parameters.AddWithValue("@name", fileName);
                    cmd.Parameters.AddWithValue("@groupId", groupId);
                    cmd.ExecuteNonQuery();

                    /*
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update WidSubmGroup set Status = @Status where Id = @groupId ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@groupId", groupId);
                    cmd.Parameters.AddWithValue("@Status", (int)WidSubmGroupStatus.FileCreated);
                    cmd.ExecuteNonQuery();
                    */
                });
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void CheckDeclinedFiles()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var ftpClient = new FtpClient(
                appSettings["FileExchangeFtpErrorDir"],
                appSettings["FileExchangeFtpLogin"],
                appSettings["FileExchangeFtpPassword"]
            );
            var ftpFiles = ftpClient.ReadDirectoryFiles("")
                .ToList()
                .Where(x => !string.Equals(Path.GetExtension(x), ".gz", StringComparison.OrdinalIgnoreCase))
                .ToList();

            var dbFiles = new List<string>();
            Helpers.RunSqlSocWidSubmitT(cmd =>
            {
                var declinedFileIds = new List<int>();
                cmd.CommandText = "select Id, Name from SubmFile where SubmFileStatus = @SubmFileStatus";
                cmd.Parameters.AddWithValue("@SubmFileStatus", ExchangeFileStatus.Submitted);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var id = r.GetInt32(0);
                        var name = r.GetString(1);
                        if(ftpFiles.Any(x => x.Contains(name)))
                        {
                            declinedFileIds.Add(id);
                        }
                    }
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSubmFileDecline";
                declinedFileIds.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@SubmFileId", x);
                    cmd.ExecuteNonQuery();
                });

            });

        }


        public void LoadRespFiles()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var ftpClient = new FtpClient(
                appSettings["FileExchangeFtpRespDir"],
                appSettings["FileExchangeFtpLogin"],
                appSettings["FileExchangeFtpPassword"]
            );
            /*
            var ftpFiles = ftpClient.ReadDirectoryFiles("")
                .ToList()
                .Where(x => !string.Equals(Path.GetExtension(x), ".gz", StringComparison.OrdinalIgnoreCase))
                .ToList();
            */
            var ftpFiles = ftpClient.ReadDirectoryFiles("")
                .ToList();
            var localFiles = Directory.GetFiles(
                Path.Combine(appSettings["FileExchangeRootDir"], "RespFiles"),
                "*.021"
            ).ToList();

            var dbFiles = new List<string>();
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = "select Name from RespFile";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        dbFiles.Add(r.GetString(0));
                    }
                }
            });


            var unprocessedFiles = ftpFiles
                .Where(x => !dbFiles.Contains(Path.GetFileNameWithoutExtension(x)))
                .ToList();

            unprocessedFiles.ForEach(fileName =>
            {
                var isArchived = string.Compare(Path.GetExtension(fileName), ".gz", StringComparison.OrdinalIgnoreCase) == 0;
                var fileNameUnzipped = isArchived ?
                    Path.GetFileNameWithoutExtension(fileName) : fileName;
                var folder = Path.Combine(appSettings["FileExchangeRootDir"], "RespFiles");
                if (!localFiles.Contains(fileNameUnzipped))
                {
                    ftpClient.DownloadFile(
                        "",
                        fileName,
                        folder
                    );
                }

                if(isArchived)
                {
                    var fileFullName = Path.Combine(folder, fileName);
                    var fileFullNameUnzipped = Path.Combine(folder, fileNameUnzipped);
                    using (FileStream compressedFileStream = File.OpenRead(fileFullName))
                    {
                        using (FileStream decompressedFileStream = File.Create(fileFullNameUnzipped))
                        {
                            using (GZipStream decompressionStream = new GZipStream(compressedFileStream, CompressionMode.Decompress))
                            {
                                decompressionStream.CopyTo(decompressedFileStream);
                            }
                        }
                    }
                    File.Delete(fileFullName);
                }

                LoadRespFile(Path.Combine(appSettings["FileExchangeRootDir"], "RespFiles", fileNameUnzipped));
            });
        }

        public void LoadRespFile(string fileFullName)
        {
            var lines = File.ReadAllLines(fileFullName);

            var submFileName = lines[0].Substring(101, 29);
            var isSent = false;
            Helpers.RunSqlSocWidSubmitT(cmd =>
            {
                cmd.CommandText = "select dbo.fnCheckFileSent(@submFileName)";
                cmd.Parameters.AddWithValue("@submFileName", submFileName);
                isSent = (bool)cmd.ExecuteScalar();
            });
            if(!isSent)
            {
                return;
            }
            
            Helpers.RunSqlSocWidSubmitT(cmd =>
            {
                cmd.CommandTimeout = 0;

                var respFileId = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spRespFileSelectOrCreate";
                cmd.Parameters.AddWithValue("@name", Path.GetFileName(fileFullName));
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    respFileId = r.GetInt32(0);
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spRespFileClear";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@respFileId", respFileId);
                cmd.ExecuteNonQuery();

                lines.ToList().ForEach(line =>
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        return;
                    }

                    var entityType = GetEntityType(line);
                    if (entityType == null)
                    {
                        return;
                    }

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = GetCreateRespEntityInsertCmdText(GetEntityTableName(line), entityType);
                    GetCreateRespEntityInsertCmdParams(cmd, entityType, respFileId, line);
                    cmd.ExecuteNonQuery();

                });

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spRespFileUpdateErrCodes";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@respFileId", respFileId);
                cmd.ExecuteNonQuery();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spRespFileProcess";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@respFileId", respFileId);

                cmd.ExecuteNonQuery();

            });
        }

        private Type GetEntityType(string line)
        {
            var recType = line.Substring(0, 3);
            if(_recTypeToEntityType.ContainsKey(recType))
            {
                return _recTypeToEntityType[recType];
            }
            else
            {
                return null;
            }
        }

        private string GetEntityTableName(string line)
        {
            var recType = line.Substring(0, 3);
            return _recTypeToTableName[recType];
        }

        private string GetCreateRespEntityInsertCmdText(string tableName, Type t)
        {
            var piList = t.GetProperties();
            var colsText = "RespFileId";
            var paramsText = "@RespFileId";
            for (int i = 2; i < piList.Count(); i++)
            {
                colsText += $", {piList[i].Name}";
                paramsText += $", @{piList[i].Name}";
            }
            return $"insert {tableName} ({colsText}) values({paramsText})";
        }

        private void GetCreateRespEntityInsertCmdParams(SqlCommand cmd, Type t, int respFileId, string line)
        {
            var piList = t.GetProperties();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@RespFileId", respFileId);
            for (int i = 2; i < piList.Count(); i++)
            {
                var pi = piList[i];
                var posInFile = (CustomPosInFileAttribute)pi.GetCustomAttribute(typeof(CustomPosInFileAttribute));
                cmd.Parameters.AddWithValue($"@{pi.Name}", line.Substring(posInFile.Start - 1, posInFile.Size).Trim());
            }
        }

        private Wia CreateWia(SqlCommand cmd, int submFileId, int groupId, ObjIdTranType objIdTranType)
        {
            var wia = new Wia
            {
                SipList = new List<Sip>(),
                OipList = new List<Oip>(),
                RecAltList = new List<RecAlt>(),
                RecPerList = new List<RecPer>(),
            };

            // WIA
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spSelectDataForWia";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@groupId", groupId);
            cmd.Parameters.AddWithValue("@objId", objIdTranType.ObjId);
            using (var r = cmd.ExecuteReader())
            {
                r.Read();
                wia.RecWia = new RecWia
                {
                    Id = r.GetInt32(0), // PseudoId - ідентифікатор запису, на основі якого створюється даний запис
                    SubmFileId = submFileId,
                    RecType = objIdTranType.TranType == "A" ? "WIA" : "WIU",
                    TransSeqNr = "",
                    RecSeqNr = "",
                    WrkTtl = r.GetString(1),
                    LngCode = "",
                    SubmWrkNr = $"MS{r.GetInt32(2)}",
                    Iswc = r.GetString(3),
                    CprDate = "",
                    CprNr = "",
                    MwDistrCat = "UNC",
                    Dur = "",
                    RecInd = "Y",
                    TxtMusicRel = "",
                    CmpType = "",
                    VerType = "ORI",
                    ExcType = "",
                    MusicArr = "",
                    LyrAdapt = "",
                    WicCode = "",
                    UpdDate = "",
                    FstSendDateToCis = "",
                    LstSendDateToCis = "",
                    SocWrkType = "",
                    TranType = objIdTranType.TranType,
                };
            }

            // ALT
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"
                    select Id, WidName 
                    from WidSubmGroupWorkName
                    where WidSubmGroupId = @groupId
                        and ObjId = @objId 
                        and IsMain = 0 
                        and IsDuplicate = 0";
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    wia.RecAltList.Add(new RecAlt
                    {
                        Id = r.GetInt32(0), // PseudoId - ідентифікатор запису, на основі якого створюється даний запис
                        SubmFileId = submFileId,
                        RecType = "ALT",
                        TransSeqNr = "",
                        RecSeqNr = "",
                        AltTtl = r.GetString(1),
                        TtlType = "ET",
                        LngCode = "",
                    });
                }
            }

            // PER
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"
                    select Id, WidName 
                    from WidSubmGroupWorkPerformer
                    where WidSubmGroupId = @groupId 
                        and ObjId = @objId
                        and IsDuplicate = 0";
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    wia.RecPerList.Add(new RecPer
                    {
                        Id = r.GetInt32(0), // PseudoId - ідентифікатор запису, на основі якого створюється даний запис
                        SubmFileId = submFileId,
                        RecType = "PER",
                        TransSeqNr = "",
                        RecSeqNr = "",
                        PerfArtistLstName = r.GetString(1),
                        PerfArtistFstName = "",
                        Filler4 = "",
                        PerfArtistIpNameNr = "",
                    });
                }
            }

            // SipAndOip
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spSelectDataForSipAndOip";
            var da = new SqlDataAdapter(cmd);
            var dtSipAndOip = new DataTable();
            da.Fill(dtSipAndOip);
            if (dtSipAndOip.Rows.Count > 0)
            {
                decimal perShrTotal = 0;
                decimal mecShrTotal = 0;
                foreach (DataRow dr in dtSipAndOip.Rows)
                {
                    perShrTotal += (decimal)dr["PerShr"];
                    mecShrTotal += (decimal)dr["MecShr"];
                }

                var hasPerShr = perShrTotal > 0;
                var hasMecShr = mecShrTotal > 0;

                foreach (DataRow dr in dtSipAndOip.Rows)
                {
                    var ipRole = (string)dr["IpRole"];
                    if (string.IsNullOrEmpty(ipRole))
                    {
                        throw new Exception("Не визначена роль для автора");
                    }
                    // SIP
                    if ((bool)dr["HasAgreement"])
                    {
                        var sip = new Sip
                        {
                            RecSip = new RecSip
                            {
                                Id = (int)dr["Id"], // PseudoId - ідентифікатор запису, на основі якого створюється даний запис
                                SubmFileId = submFileId,
                                RecType = "SIP",
                                TransSeqNr = "",
                                RecSeqNr = "",
                                Filler5 = "",
                                IpNr = dr["IpNr"].ToString(),
                                IpName = dr["IpName"].ToString(),
                                IpFstName = dr["IpFstName"].ToString(),
                                IpRole = (string)dr["IpRole"],
                                IpNameNr = dr["IpNameNr"].ToString(),
                            },
                            RecSsrList = new List<RecSsr>(),
                        };
                        wia.SipList.Add(sip);
                        // SSR
                        var perShr = Convert.ToInt32(((decimal)dr["PerShr"] * 100));
                        if (hasPerShr)
                        {
                            sip.RecSsrList.Add(new RecSsr
                            {
                                Id = (int)dr["Id"], // PseudoId - ідентифікатор запису, на основі якого створюється даний запис
                                SubmFileId = submFileId,
                                RecType = "SSR",
                                TransSeqNr = "",
                                RecSeqNr = "",
                                Filler6 = "",
                                RightType = "PER",
                                Shares = perShr.ToString(),
                                IpNameNr = dr["IpNameNr"].ToString(),
                                Aff = "",
                            });
                        }

                        var mecShr = Convert.ToInt32(((decimal)dr["MecShr"] * 100));
                        if (hasMecShr)
                        {
                            sip.RecSsrList.Add(new RecSsr
                            {
                                Id = (int)dr["Id"], // PseudoId - ідентифікатор запису, на основі якого створюється даний запис
                                SubmFileId = submFileId,
                                RecType = "SSR",
                                TransSeqNr = "",
                                RecSeqNr = "",
                                Filler6 = "",
                                RightType = "MEC",
                                Shares = mecShr.ToString(),
                                IpNameNr = dr["IpNameNr"].ToString(),
                                Aff = "",
                            });
                        }

                    }
                    // OIP
                    else
                    {
                        var oip = new Oip
                        {
                            RecOip = new RecOip
                            {
                                Id = (int)dr["Id"], // PseudoId - ідентифікатор запису, на основі якого створюється даний запис
                                SubmFileId = submFileId,
                                RecType = "OIP",
                                TransSeqNr = "",
                                RecSeqNr = "",
                                Filler1 = "",
                                IpNr = dr["IpNr"].ToString(),
                                IpName = dr["IpName"].ToString(),
                                IpFstName = dr["IpFstName"].ToString(),
                                IpRole = (string)dr["IpRole"],
                                IpNameNr = dr["IpNameNr"].ToString(),
                            },
                            RecOsrList = new List<RecOsr>(),
                        };
                        wia.OipList.Add(oip);

                        // OSR
                        var perShr = Convert.ToInt32(((decimal)dr["PerShr"] * 100));
                        if (hasPerShr)
                        {
                            oip.RecOsrList.Add(new RecOsr
                            {
                                Id = (int)dr["Id"], // PseudoId - ідентифікатор запису, на основі якого створюється даний запис
                                SubmFileId = submFileId,
                                RecType = "OSR",
                                TransSeqNr = "",
                                RecSeqNr = "",
                                Filler3 = "",
                                RightType = "PER",
                                Shares = perShr.ToString(),
                                IpNameNr = dr["IpNameNr"].ToString(),
                                Aff = "",
                            });
                        }

                        var mecShr = Convert.ToInt32(((decimal)dr["MecShr"] * 100));
                        if (hasMecShr)
                        {
                            oip.RecOsrList.Add(new RecOsr
                            {
                                Id = (int)dr["Id"], // PseudoId - ідентифікатор запису, на основі якого створюється даний запис
                                SubmFileId = submFileId,
                                RecType = "OSR",
                                TransSeqNr = "",
                                RecSeqNr = "",
                                Filler3 = "",
                                RightType = "MEC",
                                Shares = mecShr.ToString(),
                                IpNameNr = dr["IpNameNr"].ToString(),
                                Aff = "",
                            });
                        }

                    }
                }
            }
            return wia;
        }

        private void SaveUpdFileInDb(SqlCommand cmd, Hdr hdr)
        {
            InsertEntityInDb(cmd, hdr.RecHdr, null, null);
            hdr.GrhList.ForEach(grh =>
            {
                InsertEntityInDb(cmd, grh.RecGrh, null, null);
                grh.WiaList.ForEach(wia =>
                {
                    InsertEntityInDb(cmd, wia.RecWia, "WidSubmGroupWork", "RecWiaId");
                    wia.SipList.ForEach(sip =>
                    {
                        InsertEntityInDb(cmd, sip.RecSip, "WidSubmGroupWorkShare", "RecSipId");
                        sip.RecSsrList.ForEach(ssr =>
                        {
                            InsertEntityInDb(cmd, ssr, "WidSubmGroupWorkShare",
                                ssr.RightType.Equals("PER", StringComparison.OrdinalIgnoreCase) ? "RecSsrPerId" : "RecSsrMecId");
                        });
                    });
                    wia.OipList.ForEach(oip =>
                    {
                        InsertEntityInDb(cmd, oip.RecOip, "WidSubmGroupWorkShare", "RecOipId");
                        oip.RecOsrList.ForEach(osr =>
                        {
                            InsertEntityInDb(cmd, osr, "WidSubmGroupWorkShare",
                                osr.RightType.Equals("PER", StringComparison.OrdinalIgnoreCase) ? "RecOsrPerId" : "RecOsrMecId");
                        });
                    });
                    wia.RecAltList.ForEach(recAlt =>
                    {
                        InsertEntityInDb(cmd, recAlt, "WidSubmGroupWorkName", "RecAltId");
                    });
                    wia.RecPerList.ForEach(recPer =>
                    {
                        InsertEntityInDb(cmd, recPer, "WidSubmGroupWorkPerformer", "RecPerId");
                    });
                });
                InsertEntityInDb(cmd, grh.RecGrt, null, null);
            });
            InsertEntityInDb(cmd, hdr.RecTrl, null, null);
        }

        private string SaveUpdFile(Hdr hdr, string folderPath)
        {
            var lines = new List<string>();
            lines.Add(EntityToString(hdr.RecHdr, 2));
            hdr.GrhList.ForEach(grh =>
            {
                lines.Add(EntityToString(grh.RecGrh, 2));
                grh.WiaList.ForEach(wia =>
                {
                    lines.Add(EntityToString(wia.RecWia, 2));
                    wia.SipList.ForEach(sip =>
                    {
                        lines.Add(EntityToString(sip.RecSip, 2));
                        sip.RecSsrList.ForEach(ssr =>
                        {
                            lines.Add(EntityToString(ssr, 2));
                        });
                    });
                    wia.OipList.ForEach(oip =>
                    {
                        lines.Add(EntityToString(oip.RecOip, 2));
                        oip.RecOsrList.ForEach(osr =>
                        {
                            lines.Add(EntityToString(osr, 2));
                        });
                    });
                    wia.RecAltList.ForEach(recAlt =>
                    {
                        lines.Add(EntityToString(recAlt, 2));
                    });
                    wia.RecPerList.ForEach(recPer =>
                    {
                        lines.Add(EntityToString(recPer, 2));
                    });
                });
                lines.Add(EntityToString(grh.RecGrt, 2));
            });
            lines.Add(EntityToString(hdr.RecTrl, 2));

            // Пишемо в файл
            var fileName = $"WID{hdr.RecHdr.CreD}{hdr.RecHdr.CreT.Substring(0, 2)}24{hdr.RecHdr.CreT.Substring(2)}300140.021";
            File.WriteAllLines(Path.Combine(folderPath, fileName), lines);

            return fileName;
        }

        private int InsertEntityInDb(SqlCommand cmd, object entity, string refTableName, string refColName)
        {
            var t = entity.GetType();
            var piList = t.GetProperties();
            var tableName = ((TableAttribute)t.GetCustomAttributes().Single(x => x.GetType() == typeof(TableAttribute))).Name;
            var colsText = piList[1].Name;
            var paramsText = $"@{piList[1].Name}";
            for (int i = 2; i < piList.Count(); i++)
            {
                colsText += $", {piList[i].Name}";
                paramsText += $", @{piList[i].Name}";
            }
            var sql = $@"
                set ansi_warnings off
                insert into SocWidSubmit..{tableName} (
                    {colsText}
                ) values (
                    {paramsText}
                )
                select scope_identity()
            ";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            for (int i = 1; i < piList.Count(); i++)
            {
                cmd.Parameters.AddWithValue($"@{piList[i].Name}", piList[i].GetValue(entity));
            }
            var entityId = Convert.ToInt32(cmd.ExecuteScalar());

            if(!string.IsNullOrEmpty(refTableName))
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"update {refTableName} set {refColName} = @entityId where Id = @Id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", (int)piList[0].GetValue(entity));
                cmd.Parameters.AddWithValue("@entityId", entityId);
                cmd.ExecuteNonQuery();
            }

            return entityId;
        }
        private T ReadEntityFromDb<T>(SqlCommand cmd, int recId) where T : new()
        {
            var t = typeof(T);
            var piList = t.GetProperties();
            var tableName = ((TableAttribute)t.GetCustomAttributes().Single(x => x.GetType() == typeof(TableAttribute))).Name;
            var colsText = piList[0].Name;
            for (int i = 1; i < piList.Count(); i++)
            {
                colsText += $", {piList[i].Name}";
            }
            var sql = $"select {colsText} from SocWidSubmit..{tableName} where Id = {@recId}";
            var dt = FillDtForRec(cmd.Connection, sql, recId);
            var row = dt.Rows[0];
            var entity = new T();
            for (int i = 0; i < piList.Count(); i++)
            {
                var pi = piList[i];
                pi.SetValue(entity, row[pi.Name]);
            }
            return entity;
        }

        private List<T> ReadRelatedEntityListFromDb<T>(SqlCommand cmd, int parentRecId, string parentRefColName) where T : new()
        {
            var t = typeof(T);
            var piList = t.GetProperties();
            var tableName = ((TableAttribute)t.GetCustomAttributes().Single(x => x.GetType() == typeof(TableAttribute))).Name;
            var colsText = piList[0].Name;
            for (int i = 1; i < piList.Count(); i++)
            {
                colsText += $", {piList[i].Name}";
            }
            var sql = $"select {colsText} from SocWidSubmit..{tableName} where {parentRefColName} = {@parentRecId}";
            var dt = FillDtForRec(cmd.Connection, sql, parentRecId);
            if(dt.Rows.Count == 0)
            {
                return null;
            }

            var retVal = new List<T>();
            foreach(DataRow row in dt.Rows)
            {
                var entity = new T();
                for (int i = 0; i < piList.Count(); i++)
                {
                    var pi = piList[i];
                    pi.SetValue(entity, row[pi.Name]);
                }
                retVal.Add(entity);
            }
            return retVal;
        }

        private string EntityToString(object entity, int startPropIdx)
        {
            var t = entity.GetType();
            var piList = t.GetProperties();

            var sb = new StringBuilder();
            for (int i = startPropIdx; i < piList.Count(); i++)
            {
                var pi = piList[i];
                sb.Append(FormatProp(entity, pi));
            }

            var retVal = sb.ToString();
            return retVal;
        }

        private string FormatProp(object entity, PropertyInfo pi)
        {
            var posInFile = (CustomPosInFileAttribute)pi.GetCustomAttribute(typeof(CustomPosInFileAttribute));
            if (posInFile == null)
            {
                return "";
            }
            var size = posInFile.Size;
            var fmt = posInFile.Fmt;
            var value = (string)pi.GetValue(entity);
            if(string.IsNullOrEmpty(value))
            {
                return new string(' ', size);
            }
            else if(fmt == 'N')
            {
                return int.Parse(value).ToString($"D{size}");
            }
            else
            {
                value = FileValidator.NormalizeText(value);
                value = value.Substring(0, Math.Min(size, value.Length));
                return value + new string(' ', size - value.Length);
            }
        }

        private DataTable FillDtForRec(SqlConnection conn, string commandText, int recId)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = commandText;
                cmd.Parameters.AddWithValue("@recId", recId);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
