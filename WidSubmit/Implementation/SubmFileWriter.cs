using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static WidSubmit.SubmFileWriter;

namespace WidSubmit
{
    public class SubmFileWriter
    {
        public class SubmWork
        {
            public int                     SubmWorkId  { get; set; }
            public int                     ObjId       { get; set; }
            public string                  NameForWid  { get; set; }
            public string                  Iswc        { get; set; }
            public bool                    IsChanged   { get; set; }
            public RecWiaWiu               RecWiaWiu   { get; set; }
            public List<SubmWorkShare>     Shares      { get; set; }
            public List<SubmWorkAltName>   AltNames    { get; set; }
            public List<SubmWorkPerformer> Performers  { get; set; }
            public SubmWork()
            {
                Shares = new List<SubmWorkShare>();
                AltNames = new List<SubmWorkAltName>();
                Performers = new List<SubmWorkPerformer>();
            }
        }
        
        public class SubmWorkShare
        {
	        public int       SubmWorkShareId    { get; set; }
	        public int       SubmWorkId         { get; set; }
            public bool      IsSubmWorkCnanged  { get; set; }
	        public int       IpNameNr           { get; set; }
	        public string    NameForWid         { get; set; }
	        public string    FstNameForWid      { get; set; }
	        public string    RoleForWid         { get; set; }
            public int       ShrPer             { get; set; }
            public int       ShrMec             { get; set; }
            public RecSipOip RecSipOip          { get; set; }
            public RecSsrOsr RecSsrOsrPer       { get; set; }
            public RecSsrOsr RecSsrOsrMec       { get; set; }
            public bool      IsOwn              { get; set; }
        }

        public class SubmWorkAltName
        {
	        public int       SubmWorkAltNameId  { get; set; }
	        public int       SubmWorkId         { get; set; }
            public bool      IsSubmWorkCnanged  { get; set; }
	        public string    NameForWid         { get; set; }
	        public RecAlt    RecAlt             { get; set; }
        }
        
        public class SubmWorkPerformer
        {
	        public int       SubmWorkPerformerId { get; set; }
	        public int       SubmWorkId          { get; set; }
            public bool      IsSubmWorkCnanged   { get; set; }
	        public string    NameForWid          { get; set; }
	        public RecPer    RecPer              { get; set; }
        }

        public class Grh
        {
            public RecGrh         RecGrh { get; set; }
            public List<SubmWork> SubmWorks { get; set; }
            public RecGrt         RecGrt { get; set; }
            public Grh()
            {
                SubmWorks = new List<SubmWork>();
            }
        }

        public class Hdr
        {
            public RecHdr RecHdr { get; set; }
            public Grh    GrhWia { get; set; }
            public Grh    GrhWiu { get; set; }
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

        //private readonly string _connectStringSocWid;
        //private readonly string _connectStringSocWidSubmit;

        public SubmFileWriter()
        {

        }

        public SubmFileWriter(string connectStringSocWid, string connectStringSocWidSubmit)
        {
            //_connectStringSocWid = connectStringSocWid;
            //_connectStringSocWidSubmit = connectStringSocWidSubmit;
        }

        #region ФОРМУВАННЯ ДАНИХ В ПАМЯТІ // --------------------------------------------------------------

        private Hdr CreateHdrRecord(int submissionId)
        {
            var hdr = new Hdr();
            hdr.GrhWia = null;
            hdr.GrhWiu = null;
            hdr.RecTrl = null;

            hdr.RecHdr = new RecHdr
            {
                SubmissionId = submissionId,
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

            return hdr;
        }

        private void CreateGrhRecords(SqlCommand cmd, Hdr hdr)
        {
            // Вибираємо твори до передачі
            var submWorks = new List<SubmWork>();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"
	            select
		              Id		 as SubmWorkId
		            , ObjId	     as ObjId
		            , NameForWid as NameForWid
		            , Iswc	     as Iswc
		            , IsChanged  as IsChanged
	            from vCurSubmWorks
	            where Status = 1
                order by Id
            ";
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    var submWork = new SubmWork();
                    var idx = 0;
                    submWork.SubmWorkId = r.GetInt32(idx++);
                    submWork.ObjId      = r.GetInt32(idx++);
		            submWork.NameForWid = r.GetString(idx++);
		            submWork.Iswc       = r.GetString(idx++);
		            submWork.IsChanged  = r.GetBoolean(idx++);
                    submWorks.Add(submWork);
                }
            }

            hdr.GrhWia = null;
            hdr.GrhWiu = null;

            var cntWia = submWorks.Where(x => !x.IsChanged).Count();
            var cntWiu = submWorks.Where(x => x.IsChanged).Count();
            var grId = 0;

            if(cntWia > 0)
            {
                var grh = new Grh();
                grh.RecGrh = new RecGrh
                {
                    Id = 0,
                    RecHdrId = 0,
                    RecType = "GRH",
                    TransType = "WIA",
                    GrId = grId.ToString(),
                    VerNr = "01.30",
                };
                grh.SubmWorks = submWorks.Where(x => !x.IsChanged).ToList();
                grh.RecGrt = null;

                hdr.GrhWia = grh;

                grId++;
            };

            if(cntWiu > 0)
            {
                var grh = new Grh();
                grh.RecGrh = new RecGrh
                {
                    Id = 0,
                    RecHdrId = 0,
                    RecType = "GRH",
                    TransType = "WIU",
                    GrId = grId.ToString(),
                    VerNr = "01.30",
                };
                grh.SubmWorks = submWorks.Where(x => x.IsChanged).ToList();
                grh.RecGrt = null;

                hdr.GrhWiu = grh;

            };
         }

        private void CreateWiaWiuRecords(SqlCommand cmd, Grh grh)
        {
            if(grh == null) return;

            // Вибираємо твори до передачі
            var submWorks = grh.SubmWorks;
            
            // Створюємо і заповнюємо Wia транзакції
            var tranSeqNr = 0;
            submWorks.ForEach(submWork =>
            {
                submWork.RecWiaWiu = new RecWiaWiu
                {
                    Id = submWork.SubmWorkId, // PseudoId - ідентифікатор запису, на основі якого створюється даний запис
                    RecGrhId = 0,
                    SubmWorkId = submWork.SubmWorkId,
                    RecType = grh.RecGrh.TransType,
                    TransSeqNr = "",
                    RecSeqNr = "",
                    WrkTtl = submWork.NameForWid,
                    LngCode = "",
                    SubmWrkNr = $"MS{submWork.ObjId}",
                    Iswc = submWork.Iswc,
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
                };

                tranSeqNr++;
            });

       }

        private void CreateShareRecords(SqlCommand cmd, Grh grh)
        {
            if(grh == null)
                return;

            var isWia = grh.RecGrh.TransType == "WIA" ? true : false;

            var shares = new List<SubmWorkShare>();
                
            cmd.CommandText = @"
                 select
	                  t1.Id						as SubmWorkShareId
	                , t1.SubmWorkId				as SubmWorkId
                    , t2.IsChanged				as IsSubmWorkChanged
	                , t3.IpNameNr				as IpNameNr
	                , t3.NameForWid				as NameForWid
	                , t3.FstNameForWid			as FstNameForWid
	                , t1.RoleForWid				as RoleForWid
	                , t1.ShrPer					as ShrPer
	                , t1.ShrMec					as ShrMec
                    , t3.IsOwn					as IsOwn
                from SubmWorkShare t1
	                join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
	                join vCurRightHolder t3 on t1.RightHolderId = t3.Id
                where t2.Status = 1
                    and t2.IsChanged = @isChanged
                order by t1.SubmWorkId
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@isChanged", !isWia);

            using(var r = cmd.ExecuteReader())
            {
                while(r.Read())
                {
                    var share = new SubmWorkShare();
                    var idx = 0;
                    share.SubmWorkShareId   = r.GetInt32(idx);                               idx++;
                    share.SubmWorkId        = r.GetInt32(idx);                               idx++;
                    share.IsSubmWorkCnanged = r.GetBoolean(idx);                             idx++;
                    share.IpNameNr          = r.GetInt32(idx);                               idx++;
                    share.NameForWid        = r.GetString(idx);                              idx++;
                    share.FstNameForWid     = r.GetString(idx);                              idx++;
                    share.RoleForWid        = r.GetString(idx);                              idx++;
                    share.ShrPer            = (int)r.GetDecimal(idx) * 100;                  idx++;
                    share.ShrMec            = (int)r.GetDecimal(idx) * 100;                  idx++;
                    share.IsOwn             = (bool)r.GetBoolean(idx);                       idx++;
                    share.RecSipOip         = null;
                    share.RecSsrOsrPer      = null;
                    share.RecSsrOsrMec      = null;
                    shares.Add(share);
                }
            }

            shares.ForEach(share =>
            {
                share.RecSipOip = new RecSipOip
                {
                    Id = 0,
                    RecWiaWiuId = 0,
                    SubmWorkShareId = share.SubmWorkShareId,
                    RecType = !share.IsOwn ? "OIP" : "SIP",
                    TransSeqNr = "",
                    RecSeqNr = "",
                    Filler5 = "",
                    IpNr = share.IpNameNr.ToString("D9"),
                    IpName = share.NameForWid,
                    IpFstName = share.FstNameForWid,
                    IpRole = share.RoleForWid,
                };

                share.RecSsrOsrPer  = new RecSsrOsr{
                    Id = 0,
                    RecSipOipId = 0,
                    RecType = !share.IsOwn ? "OSR" : "SSR",
                    TransSeqNr = "",
                    RecSeqNr = "",
                    Filler6 = "",
                    RightType = "PER",
                    Shares = share.ShrPer.ToString(CultureInfo.InvariantCulture),
                    IpNameNr = share.IpNameNr.ToString("D11"),
                    Aff = "",
                }; 
                
                share.RecSsrOsrMec  = new RecSsrOsr{
                    Id = 0,
                    RecSipOipId = 0,
                    RecType = !share.IsOwn ? "OSR" : "SSR",
                    TransSeqNr = "",
                    RecSeqNr = "",
                    Filler6 = "",
                    RightType = "MEC",
                    Shares = share.ShrPer.ToString(CultureInfo.InvariantCulture),
                    IpNameNr = share.IpNameNr.ToString("D11"),
                    Aff = "",
                };
             });

            var submWorks = grh.SubmWorks;
            var workIdx = 0;
            for(var shareIdx = 0; shareIdx < shares.Count; shareIdx++)
            {
                var work = submWorks[workIdx];
                var workSubmWorkId = work.SubmWorkId;
                var share = shares[shareIdx];
                var shareSubmWorkId = share.SubmWorkId;
                if(workSubmWorkId != shareSubmWorkId)
                {
                    while(true)
                    { 
                        workIdx++;
                        work = submWorks[workIdx];
                        if(work.SubmWorkId == shareSubmWorkId) break;
                    }
                }

                work.Shares.Add(share);
 
            }
        }

        private void CreateAltNameRecords(SqlCommand cmd, Grh grh)
        {
            if(grh == null)
                return;

            var isWia = grh.RecGrh.TransType == "WIA" ? true : false;

            var altNames = new List<SubmWorkAltName>();
                
            cmd.CommandText = @"
                 select
	                  t1.Id			as SubmWorkAltNameId
	                , t1.SubmWorkId	as SubmWorkId       
	                , t2.IsChanged	as IsSubmWorkCnanged
	                , t1.NameForWid	as NameForWid       
                from SubmWorkAltName t1
                    join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
                where t2.Status = 1
                    and t2.IsChanged = @isChanged
                order by t1.SubmWorkId, t1.NameForWid
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@isChanged", !isWia);

            using(var r = cmd.ExecuteReader())
            {
                while(r.Read())
                {
                    var altName = new SubmWorkAltName();
                    var idx = 0;
                    altName.SubmWorkAltNameId = r.GetInt32(idx);                               idx++;
                    altName.SubmWorkId        = r.GetInt32(idx);                               idx++;
                    altName.IsSubmWorkCnanged = r.GetBoolean(idx);                             idx++;
                    altName.NameForWid        = r.GetString(idx);                              idx++;
                    altNames.Add(altName);
                }
            }

            var submWorks = grh.SubmWorks;
            var workIdx = 0;
            for(var altNameIdx = 0; altNameIdx < altNames.Count; altNameIdx++)
            {
                var altName = altNames[altNameIdx];
                var altNameSubmWorkId = altName.SubmWorkId;

                var work = submWorks[workIdx];
                var workSubmWorkId = work.SubmWorkId;

                if(workSubmWorkId != altNameSubmWorkId)
                {
                    while(true)
                    { 
                        workIdx++;
                        work = submWorks[workIdx];
                        if(work.SubmWorkId == altNameSubmWorkId) break;
                    }
                }

                work.AltNames.Add(altName);
 
            }

            altNames.ForEach(altName =>
            {
                altName.RecAlt = new RecAlt
                {
                    Id = 0, // PseudoId - ідентифікатор запису, на основі якого створюється даний запис
                    RecWiaWiuId = 0,
                    SubmWorkAltNameId = altName.SubmWorkAltNameId,
                    RecType = "ALT",
                    TransSeqNr = "",
                    RecSeqNr = "",
                    AltTtl = altName.NameForWid,
                    TtlType = "ET",
                    LngCode = "",
                };
            });

        }
                
        private void CreatePerformerRecords(SqlCommand cmd, Grh grh)
        {
            if(grh == null)
                return;

            var isWia = grh.RecGrh.TransType == "WIA" ? true : false;

            var performers = new List<SubmWorkPerformer>();
                
            cmd.CommandText = @"
                 select
	                  t1.Id			as SubmWorkAltNameId
	                , t1.SubmWorkId	as SubmWorkId       
	                , t2.IsChanged	as IsSubmWorkCnanged
	                , t1.NameForWid	as NameForWid       
                from SubmWorkPerformer t1
                    join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
                where t2.Status = 1
                    and t2.IsChanged = @isChanged
                order by t1.SubmWorkId, t1.NameForWid
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@isChanged", !isWia);

            using(var r = cmd.ExecuteReader())
            {
                while(r.Read())
                {
                    var performer = new SubmWorkPerformer();
                    var idx = 0;
                    performer.SubmWorkPerformerId = r.GetInt32(idx);   idx++;
                    performer.SubmWorkId          = r.GetInt32(idx);   idx++;
                    performer.IsSubmWorkCnanged   = r.GetBoolean(idx); idx++;
                    performer.NameForWid          = r.GetString(idx);  idx++;
                    performers.Add(performer);
                }
            }

            var submWorks = grh.SubmWorks;
            var workIdx = 0;
            for(var performerIdx = 0; performerIdx < performers.Count; performerIdx++)
            {
                var work = submWorks[workIdx];
                var workSubmWorkId = work.SubmWorkId;
                var performer = performers[performerIdx];
                var performerSubmWorkId = performer.SubmWorkId;
                if(workSubmWorkId != performerSubmWorkId)
                {
                    while(true)
                    { 
                        workIdx++;
                        work = submWorks[workIdx];
                        if(work.SubmWorkId == performerSubmWorkId) break;
                    }
                }

                work.Performers.Add(performer);
 
            }

            performers.ForEach(performer =>
            {
                performer.RecPer = new RecPer
                {
                    Id = 0, // PseudoId - ідентифікатор запису, на основі якого створюється даний запис
                    RecWiaWiuId = 0,
                    SubmWorkPerformerId = performer.SubmWorkPerformerId,
                    RecType = "PER",
                    TransSeqNr = "",
                    RecSeqNr = "",
                    PerfArtistLstName = performer.NameForWid,
                    PerfArtistFstName = "",
                    Filler4 = "",
                    PerfArtistIpNameNr = "",
                };
            });
        }

        private void CreateGrtRecord(Grh grh)
        {
            if(grh == null)
                return;

            var recCnt = 0;
            grh.SubmWorks.ForEach(work =>
            {
                recCnt += 3 * work.Shares.Count();
                recCnt += work.AltNames.Count();
                recCnt += work.Performers.Count();
                recCnt += 1; // Транзакція  WIA/WIU
            });
            recCnt += 2; // GRH + GRT

            grh.RecGrt = new RecGrt
            {
                Id          = 0,
                RecGrhId    = 0,
                RecType     = "GRT",
                GrId        = grh.RecGrh.GrId,
                TransCnt    = grh.SubmWorks.Count().ToString("D8"),
                RecCnt      = recCnt.ToString("D8"),
            };
        }

        private void CreateTrlRecord(Hdr hdr)
        {
            hdr.RecTrl = new RecTrl
            {
                Id          = 0,
                RecHdrId    = 0,
                RecType     = "TRL",
                GrCnt       = ((hdr.GrhWia == null ? 0 : 1) + (hdr.GrhWiu == null ? 0 : 1)).ToString("D5"),
                TransCnt    = (
                      (hdr.GrhWia == null ? 0 : int.Parse(hdr.GrhWia.RecGrt.TransCnt)) 
                    + (hdr.GrhWiu == null ? 0 : int.Parse(hdr.GrhWiu.RecGrt.TransCnt))
                ).ToString("D8"),
                RecCnt      = (
                      (hdr.GrhWia == null ? 0 : int.Parse(hdr.GrhWia.RecGrt.RecCnt)) 
                    + (hdr.GrhWiu == null ? 0 : int.Parse(hdr.GrhWiu.RecGrt.RecCnt)) 
                    + 2 // HDR + TRL
               ).ToString("D8"),
            };
        }
        
        private void CreateSeqNrs(Grh grh)
        {
            if(grh == null)
                return;

            var transSeqNr = 0;
            grh.SubmWorks.ForEach(work =>
            {
                var recSeqNr = 0;
                work.RecWiaWiu.TransSeqNr = transSeqNr.ToString("D8");
                work.RecWiaWiu.RecSeqNr = recSeqNr.ToString("D8");
                
                recSeqNr++;
                work.Shares.ForEach(share => {
                    share.RecSipOip.TransSeqNr = transSeqNr.ToString("D8");
                    share.RecSipOip.RecSeqNr = recSeqNr.ToString("D8");
                    recSeqNr++;

                    share.RecSsrOsrPer.TransSeqNr = transSeqNr.ToString("D8");
                    share.RecSsrOsrPer.RecSeqNr = recSeqNr.ToString("D8");
                    recSeqNr++;

                    share.RecSsrOsrMec.TransSeqNr = transSeqNr.ToString("D8");
                    share.RecSsrOsrMec.RecSeqNr = recSeqNr.ToString("D8");
                    recSeqNr++;
                
                });

                work.AltNames.ForEach(altName => {
                    altName.RecAlt.TransSeqNr = transSeqNr.ToString("D8");
                    altName.RecAlt.RecSeqNr = recSeqNr.ToString("D8");
                    recSeqNr++;
                });

                work.Performers.ForEach(performer => {
                    performer.RecPer.TransSeqNr = transSeqNr.ToString("D8");
                    performer.RecPer.RecSeqNr = recSeqNr.ToString("D8");
                    recSeqNr++;
                });

               transSeqNr++;
            });
        }

        #endregion ФОРМУВАННЯ ДАНИХ В ПАМЯТІ // --------------------------------------------------------------

        #region ЗБЕРЕЖЕННЯ ДАНИХ В БД // --------------------------------------------------------------

        private void SaveEntityInDb(SqlCommand cmd, string tableName, List<object> data)
        {
            var loader = new BulkUploadToSql();
            loader.conn = cmd.Connection;
            //loader.tran = cmd.Transaction;
            loader.TableName = tableName;
            loader.AddData(data);
            loader.Flush();
        }

        private void SaveEntitiesInDb(SqlCommand cmd, string tableName, List<List<object>> dataList)
        {
            var loader = new BulkUploadToSql();
            loader.conn = cmd.Connection;
            //loader.tran = cmd.Transaction;
            loader.TableName = tableName;
            dataList.ForEach(data =>
            {
                loader.AddData(data);
            });
            loader.Flush();
        }
        
        private void SaveRecHdrInDb(SqlCommand cmd, Hdr hdr)
        {
            var data = new List<object>();
            data.Add(DBNull.Value);
            data.Add(hdr.RecHdr.SubmissionId);
            data.AddRange(EntityHelpers.EntityToList(hdr.RecHdr, 2));
            SaveEntityInDb(cmd, "RecHdr", data);

            cmd.CommandText = "select Id from RecHdr where SubmissionId = @submissionId";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@submissionId", hdr.RecHdr.SubmissionId);
            hdr.RecHdr.Id = (int)cmd.ExecuteScalar();

            SaveRecGrhInDb(cmd, hdr, hdr.GrhWia);
            SaveRecGrhInDb(cmd, hdr, hdr.GrhWiu);
            SaveRecTrlInDb(cmd, hdr);
        }
       
        private void SaveRecGrhInDb(SqlCommand cmd, Hdr hdr, Grh grh)
        {
            if(grh == null) return;

            var data = new List<object>();
            data.Add(DBNull.Value);
            data.Add(hdr.RecHdr.Id);
            data.AddRange(EntityHelpers.EntityToList(grh.RecGrh, 2));
            SaveEntityInDb(cmd, "RecGrh", data);

            cmd.CommandText = "select Id from RecGrh where RecHdrId = @recHdrId and TransType = @transType";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@recHdrId", hdr.RecHdr.Id);
            cmd.Parameters.AddWithValue("@transType", grh.RecGrh.TransType);
            grh.RecGrh.Id = (int)cmd.ExecuteScalar();

            SaveRecWiaWiuInDb(cmd, grh);
            SaveRecGrtInDb(cmd, grh);
        }

        private void SaveRecGrtInDb(SqlCommand cmd, Grh grh)
        {
            if(grh == null) return;

            var data = new List<object>();
            data.Add(DBNull.Value);
            data.Add(grh.RecGrh.Id);
            data.AddRange(EntityHelpers.EntityToList(grh.RecGrt, 2));
            SaveEntityInDb(cmd, "RecGrt", data);
        }

        private void SaveRecWiaWiuInDb(SqlCommand cmd, Grh grh)
        {
            if(grh == null) return;

            var dataList = new List<List<object>>();
            grh.SubmWorks.ForEach(work =>
            {
                var data = new List<object>();
                data.Add(DBNull.Value);
                data.Add(grh.RecGrh.Id);
                data.Add(work.SubmWorkId);
                data.AddRange(EntityHelpers.EntityToList(work.RecWiaWiu, 3));
                dataList.Add(data);
            });
            SaveEntitiesInDb(cmd, "RecWiaWiu", dataList);

            cmd.CommandText = $@"
                select Id
                from RecWiaWiu
                where RecGrhId = @recGrhId
                    and RecType = @recType
                order by TransSeqNr
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@recGrhId", grh.RecGrh.Id);
            cmd.Parameters.AddWithValue("@recType", grh.RecGrh.TransType);
            var recIdx = 0;
            using(var r = cmd.ExecuteReader())
            {
                while(r.Read())
                {
                    grh.SubmWorks[recIdx].RecWiaWiu.Id = r.GetInt32(0);
                    recIdx++;
                }
            }

            SaveRecSipOipInDb(cmd, grh);
            SaveRecAltInDb(cmd, grh);
            SaveRecPerInDb(cmd, grh);

        }

        private void SaveRecSipOipInDb(SqlCommand cmd, Grh grh)
        {
            if(grh == null) return;

            var dataList = new List<List<object>>();
            grh.SubmWorks.ForEach(work =>
            {
                work.Shares.ForEach(share =>
                {
                    var data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(work.RecWiaWiu.Id);
                    data.Add(share.SubmWorkShareId);
                    data.AddRange(EntityHelpers.EntityToList(share.RecSipOip, 3));
                    dataList.Add(data);
                });
            });
            SaveEntitiesInDb(cmd, "RecSipOip", dataList);

            cmd.CommandText = $@"
                select t1.Id
                from RecSipOip t1
	                join RecWiaWiu t2 on t1.RecWiaWiuId = t2.Id
                where t2.RecGrhId = @recGrhId
                order by t1.TransSeqNr, t1.RecSeqNr
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@recGrhId", grh.RecGrh.Id);
            using(var r = cmd.ExecuteReader())
            {
                grh.SubmWorks.ForEach(work =>
                {
                    work.Shares.ForEach(share =>
                    {
                        r.Read();
                        share.RecSipOip.Id = r.GetInt32(0);
                    });
                });
            }

            SaveRecSsrOsrInDb(cmd, grh);
        }

        private void SaveRecSsrOsrInDb(SqlCommand cmd, Grh grh)
        {
            if(grh == null) return;

            var dataList = new List<List<object>>();
            grh.SubmWorks.ForEach(work =>
            {
                work.Shares.ForEach(share =>
                {
                    var data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(share.RecSipOip.Id);
                    data.AddRange(EntityHelpers.EntityToList(share.RecSsrOsrPer, 2));
                    dataList.Add(data);

                    data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(share.RecSipOip.Id);
                    data.AddRange(EntityHelpers.EntityToList(share.RecSsrOsrMec, 2));
                    dataList.Add(data);
                });
            });
            SaveEntitiesInDb(cmd, "RecSsrOsr", dataList);

        }

        private void SaveRecAltInDb(SqlCommand cmd, Grh grh)
        {
            if(grh == null) return;

            var dataList = new List<List<object>>();
            grh.SubmWorks.ForEach(work =>
            {
                work.AltNames.ForEach(altName =>
                {
                    var data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(work.RecWiaWiu.Id);
                    data.Add(altName.SubmWorkAltNameId);
                    data.AddRange(EntityHelpers.EntityToList(altName.RecAlt, 3));
                    dataList.Add(data);
                });
            });
            SaveEntitiesInDb(cmd, "RecAlt", dataList);

            cmd.CommandText = $@"
                select t1.Id
                from RecAlt t1
	                join RecWiaWiu t2 on t1.RecWiaWiuId = t2.Id
                where t2.RecGrhId = @recGrhId
                order by t1.TransSeqNr, t1.RecSeqNr
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@recGrhId", grh.RecGrh.Id);
            using(var r = cmd.ExecuteReader())
            {
                grh.SubmWorks.ForEach(work =>
                {
                    work.AltNames.ForEach(altName =>
                    {
                        r.Read();
                        altName.RecAlt.Id = r.GetInt32(0);
                    });
                });
            }

        }

        private void SaveRecPerInDb(SqlCommand cmd, Grh grh)
        {
            if(grh == null) return;

            var dataList = new List<List<object>>();
            grh.SubmWorks.ForEach(work =>
            {
                work.Performers.ForEach(performer =>
                {
                    var data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(work.RecWiaWiu.Id);
                    data.Add(performer.SubmWorkPerformerId);
                    data.AddRange(EntityHelpers.EntityToList(performer.RecPer, 3));
                    dataList.Add(data);
                });
            });
            SaveEntitiesInDb(cmd, "RecPer", dataList);

            cmd.CommandText = $@"
                select t1.Id
                from RecPer t1
	                join RecWiaWiu t2 on t1.RecWiaWiuId = t2.Id
                where t2.RecGrhId = @recGrhId
                order by t1.TransSeqNr, t1.RecSeqNr
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@recGrhId", grh.RecGrh.Id);
            using(var r = cmd.ExecuteReader())
            {
                grh.SubmWorks.ForEach(work =>
                {
                    work.Performers.ForEach(performer =>
                    {
                        r.Read();
                        performer.RecPer.Id = r.GetInt32(0);
                    });
                });
            }

        }
        
        private void SaveRecTrlInDb(SqlCommand cmd, Hdr hdr)
        {
            var data = new List<object>();
            data.Add(DBNull.Value);
            data.Add(hdr.RecHdr.Id);
            data.AddRange(EntityHelpers.EntityToList(hdr.RecTrl, 2));
            SaveEntityInDb(cmd, "RecTrl", data);
        }

        private void SaveSubmFileInDb(SqlCommand cmd, Hdr hdr)
        {
            SaveRecHdrInDb(cmd, hdr);
        }

        #endregion ЗБЕРЕЖЕННЯ ДАНИХ В БД

        // --------------------------------------------------------

        #region СТВОРЕННЯ ФАЙЛУ У ФОЛДЕРІ
        private void AddFileLines(Grh grh, List<string> lines)
        {
            if(grh == null) return;

            lines.Add(EntityHelpers.EntityToString(grh.RecGrh, 2));
            grh.SubmWorks.ForEach(work =>
            {
                lines.Add(EntityHelpers.EntityToString(work.RecWiaWiu, 3));
                work.Shares.ForEach(share => {
                    lines.Add(EntityHelpers.EntityToString(share.RecSipOip, 3));
                    lines.Add(EntityHelpers.EntityToString(share.RecSsrOsrPer, 2));
                    lines.Add(EntityHelpers.EntityToString(share.RecSsrOsrMec, 2));
                });

                work.AltNames.ForEach(altName => {
                    lines.Add(EntityHelpers.EntityToString(altName.RecAlt, 3));
                });

                work.Performers.ForEach(performer => {
                    lines.Add(EntityHelpers.EntityToString(performer.RecPer, 3));
                });
            });
            lines.Add(EntityHelpers.EntityToString(grh.RecGrt, 2));
        }

        private string WriteSubmFile(SqlCommand cmd, Hdr hdr)
        {
            cmd.CommandText = "select SubmFileName from Submission where Id = dbo.fnCurSubmId()";
            var oldSubmFileName = (string)cmd.ExecuteScalar();

            var folderPath = Path.Combine(ConfigurationManager.AppSettings["FileExchangeRootDir"], "OutFiles");
            if (!string.IsNullOrEmpty(oldSubmFileName))
            {
                File.Delete(Path.Combine(folderPath, oldSubmFileName));
            }
            
            var lines = new List<string>();
            lines.Add(EntityHelpers.EntityToString(hdr.RecHdr, 2));
            AddFileLines(hdr.GrhWia, lines);
            AddFileLines(hdr.GrhWiu, lines);
            lines.Add(EntityHelpers.EntityToString(hdr.RecTrl, 2));

            
            // Пишемо в файл
            var submFileName = $"WID{hdr.RecHdr.CreD}{hdr.RecHdr.CreT.Substring(0, 2)}24{hdr.RecHdr.CreT.Substring(2)}300140.021";
            var submFileFullName = Path.Combine(folderPath, submFileName);
            File.WriteAllLines(submFileFullName, lines);

            // Запамятовуємо назву файлу
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Submission set SubmFileName = @submFileName where Id = dbo.fnCurSubmId()";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@submFileName", submFileName);
            cmd.ExecuteNonQuery();

            return submFileName;
        }
        
        public string CreateSubmFile()
        {
            var submissionId = 0;
            var submFileName = "";
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandTimeout = 60;

                cmd.CommandText = "select dbo.fnCurSubmId()";
                submissionId = (int)cmd.ExecuteScalar();

                // Выдаляємо записи для файлу публякації (якщо був створений раніше)
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCurSubmFileRecsClear";
                cmd.ExecuteNonQuery();

                // Вибираємо твори до передачі
                var submWorks = new List<SubmWork>();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"
	                select
		                    Id		 as SubmWorkId
		                , ObjId	     as ObjId
		                , NameForWid as NameForWid
		                , Iswc	     as Iswc
		                , IsChanged  as IsChanged
	                from vCurSubmWorks
	                where Status = 1
                    order by Id
                ";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var submWork = new SubmWork();
                        var idx = 0;
                        submWork.SubmWorkId = r.GetInt32(idx++);
                        submWork.ObjId      = r.GetInt32(idx++);
		                submWork.NameForWid = r.GetString(idx++);
		                submWork.Iswc       = r.GetString(idx++);
		                submWork.IsChanged  = r.GetBoolean(idx++);
                        submWorks.Add(submWork);
                    }
                }
                    
                // Створюємо і заповнюємо структуру файлу в памяті
                var hdr = CreateHdrRecord(submissionId);

                CreateGrhRecords(cmd, hdr);

                CreateWiaWiuRecords(cmd, hdr.GrhWia);
                CreateShareRecords(cmd, hdr.GrhWia);
                CreateAltNameRecords(cmd, hdr.GrhWia);
                CreatePerformerRecords(cmd, hdr.GrhWia);
                CreateGrtRecord(hdr.GrhWia);
                CreateSeqNrs(hdr.GrhWia);
                    
                CreateWiaWiuRecords(cmd, hdr.GrhWiu);
                CreateShareRecords(cmd, hdr.GrhWiu);
                CreateAltNameRecords(cmd, hdr.GrhWiu);
                CreatePerformerRecords(cmd, hdr.GrhWiu);
                CreateGrtRecord(hdr.GrhWiu);
                CreateSeqNrs(hdr.GrhWiu);

                CreateTrlRecord(hdr);

                // Заносимо інформацію в БД
                SaveSubmFileInDb(cmd, hdr);                   
                    
                // Створюємо реальний файл
                submFileName = WriteSubmFile(cmd, hdr);

            });

            return submFileName;
        }
        #endregion

        public void LoadRespFile(string fileFullName)
        {
            var lines = File.ReadAllLines(fileFullName);

            var submFileName = lines[0].Substring(101, 29);
            var isSent = false;
            Helpers.RunSqlSocWidSubmitExT(cmd =>
            {
                cmd.CommandText = "select dbo.fnCheckFileSent(@submFileName)";
                cmd.Parameters.AddWithValue("@submFileName", submFileName);
                isSent = (bool)cmd.ExecuteScalar();
            });
            if(!isSent)
            {
                return;
            }
            
            Helpers.RunSqlSocWidSubmitExT(cmd =>
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

        private void SaveUpdFileInDb(SqlCommand cmd, Hdr hdr)
        {
            /*
            InsertEntityInDb(cmd, hdr.RecHdr, null, null);
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
            */
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
