using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class IdentReconciler
    {
        public class ReconcileEntry
        {
            public int SeqNr { get; set; }
            public int MwId { get; set; }
            public string Title { get; set; }
            public string TitleFromIswcInWid { get; set; }
            public string Artist { get; set; }
            public bool IsConfirmed { get; set; }
            public bool IsRejected { get; set; }
            public bool NeedsReIdent { get; set; }
            public char IsAutoConfirmed { get; set; }
            public bool IsApplied { get; set; }
        }

        public class Statistics
        {
            public int Total { get; set; }
            public int Unprocessed { get; set; }
            public int Confirmed { get; set; }
            public int AutoConfirmed { get; set; }
            public int Rejected { get; set; }
            public int NeedsReident { get; set; }

            public int TotalInBlock { get; set; }
            public int UnprocessedInBlock { get; set; }
            public int ConfirmedInBlock { get; set; }
            public int AutoConfirmedInBlock { get; set; }
            public int RejectedInBlock { get; set; }
            public int NeedsReidentInBlock { get; set; }
        }

        private delegate void CmdBlock(SqlCommand cmd);
        const char IsAutoConfirmedChar = '+';

        private int _ddexReportId;
        private string _connectionString;
        private List<ReconcileEntry> _entries;

        public IdentReconciler(int ddexReportId, string connectionString)
        {
            _ddexReportId = ddexReportId;
            _connectionString = connectionString;
        }

        public void Load()
        {
            UsingCmdT(cmd =>
            {
                if (!IsInitialized(cmd))
                {
                    Initialize(cmd);
                    ReadRecords(cmd);
                    AutoConfirm(cmd);
                }
                else
                {
                    ReadRecords(cmd);
                }
            });
        }

        public Statistics GetStatistics(int pageIndex)
        {
            var retVal = new Statistics
            {
                Total = 0,
                Unprocessed = 0,
                Confirmed = 0,
                AutoConfirmed = 0,
                Rejected = 0,
                NeedsReident = 0,

                TotalInBlock = 0,
                UnprocessedInBlock = 0,
                ConfirmedInBlock = 0,
                AutoConfirmedInBlock = 0,
                RejectedInBlock = 0,
                NeedsReidentInBlock = 0,
            };

            var idxFrom = 1000 * pageIndex + 1;
            var idxTo = idxFrom + 1000;
            _entries.ForEach(x =>
            {
                if(x.SeqNr >= idxFrom && x.SeqNr < idxTo)
                {
                   retVal.TotalInBlock++;
                   if(!x.IsConfirmed && !x.IsRejected && !x.NeedsReIdent)
                        retVal.UnprocessedInBlock++;
                    if (x.IsConfirmed)
                        retVal.ConfirmedInBlock++;
                    if (x.IsConfirmed && x.IsAutoConfirmed == IsAutoConfirmedChar)
                        retVal.AutoConfirmedInBlock++;
                    if (x.IsRejected)
                        retVal.RejectedInBlock++;
                    if (x.NeedsReIdent)
                        retVal.NeedsReidentInBlock++;
                }

                retVal.Total++;
                if (!x.IsConfirmed && !x.IsRejected && !x.NeedsReIdent)
                    retVal.Unprocessed++;
                if (x.IsConfirmed)
                    retVal.Confirmed++;
                if (x.IsConfirmed && x.IsAutoConfirmed == IsAutoConfirmedChar)
                    retVal.AutoConfirmed++;
                if (x.IsRejected)
                    retVal.Rejected++;
                if (x.NeedsReIdent)
                    retVal.NeedsReident++;
            });

            return retVal;
        }

        public int GetEntriesCount()
        {
            return _entries.Count;
        }

        public List<ReconcileEntry> GetEntries()
        {
            return _entries;
        }

        public List<ReconcileEntry> GetAllEntries(int pageIndex)
        {
            var retVal = _entries
                .Skip(1000 * pageIndex)
                .Take(1000)
                .Where(x => !x.IsApplied)
                .ToList();
            return retVal;
        }

        public List<ReconcileEntry> GetUnprocessedEntries(int pageIndex)
        {
            var retVal = _entries
                .Skip(1000 * pageIndex)
                .Take(1000)
                .Where(x => !x.IsConfirmed && !x.IsRejected && !x.NeedsReIdent && !x.IsApplied)
                .ToList();
            return retVal;
        }

        public List<ReconcileEntry> GetConfirmedEntries(int pageIndex)
        {
            var retVal = _entries
                .Skip(1000 * pageIndex)
                .Take(1000)
                .Where(x => x.IsConfirmed && !x.IsApplied)
                .ToList();
            return retVal;
        }

        public List<ReconcileEntry> GetAutoconfirmedEntries(int pageIndex)
        {
            var retVal = _entries
                .Skip(1000 * pageIndex)
                .Take(1000)
                .Where(x => x.IsAutoConfirmed == IsAutoConfirmedChar && !x.IsApplied)
                .ToList();
            return retVal;
        }

        public List<ReconcileEntry> GetRejectedEntries(int pageIndex)
        {
            var retVal = _entries
                .Skip(1000 * pageIndex)
                .Take(1000)
                .Where(x => x.IsRejected && !x.IsApplied)
                .ToList();
            return retVal;
        }

        public List<ReconcileEntry> GetNeedReidentEntries(int pageIndex)
        {
            var retVal = _entries
                .Skip(1000 * pageIndex)
                .Take(1000)
                .Where(x => x.NeedsReIdent && !x.IsApplied)
                .ToList();
            return retVal;
        }

        public void SetIsConfirmed(int mwId, bool value)
        {
            SetFlag(mwId, "isConfirmed", value);
        }

        public void SetIsRejected(SqlCommand cmd, int mwId, bool value)
        {
            SetFlag(mwId, "isRejected", value);
        }

        public void SetNeedsReIdent(int mwId, bool value)
        {
            SetFlag(mwId, "needsReIdent", value);
        }

        public void SaveFlagsIntoDb(List<ReconcileEntry> changedEntries)
        {
            UsingCmdT(cmd =>
            {
                InitTmpPreClaimIdentReconcile(cmd, changedEntries);
                cmd.CommandText = @"
                    update t1
                    set 
                          t1.isConfirmed = t2.isConfirmed
                        , t1.isRejected = t2.isRejected
                        , t1.needsReIdent = t2.needsReIdent
                    from PreClaimIdentReconcile t1
                        join #PreClaimIdentReconcile t2 on t1.ddexReportId = t2.ddexReportId and t1.mwId = t2.mwId
                    where t1.ddexReportId = @ddexReportId

                    drop table #PreClaimIdentReconcile
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
                cmd.ExecuteNonQuery();
            });
        }

        public bool HasUnprocessed()
        {
            return _entries.Any(x => !x.IsConfirmed && !x.IsRejected && !x.NeedsReIdent);
        }

        public void ApplyToReport()
        {
            UsingCmdT(cmd =>
            {
                AdjustIdentMw(cmd);
                AdjustIdentReportMwRecords(cmd);
            });
        }

        private void UsingCmd(CmdBlock fnc)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandTimeout = 0;
                fnc(cmd);
            }
        }
        private void UsingCmdT(CmdBlock fnc)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        cmd.CommandTimeout = 0;
                        cmd.Transaction = tran;
                        fnc(cmd);
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
        private void SetFlag(int mwId, string flagName, bool value)
        {
            UsingCmd(cmd =>
            {
                cmd.CommandText = $@"
                    update PreClaimIdentReconcile
                    set {flagName} = @value
                    where ddexReportId = @ddexReportId
                        and mwId = @mwId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
                cmd.Parameters.AddWithValue("@mwId", mwId);
                cmd.Parameters.AddWithValue("@value", value);
                cmd.ExecuteNonQuery();
            });
        }
        private bool IsInitialized(SqlCommand cmd)
        {
            cmd.CommandText = @"
                select top 1 null from PreClaimIdentReconcile where ddexReportId = @ddexReportId
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            using (var r = cmd.ExecuteReader())
            {
                return r.HasRows;
            }
        }
        private void ReadRecords(SqlCommand cmd)
        {
            cmd.CommandText = @"select 
                      mwId
                    , TITLE
                    , TITLE_FROM_ISWC_IN_WID
                    , ARTIST
                    , isConfirmed
                    , isRejected
                    , needsReIdent
                    , isAutoConfirmed
                    , IsApplied
                from PreClaimIdentReconcile
                where ddexReportId = @ddexReportId
                order by TITLE";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            using (var r = cmd.ExecuteReader())
            {
                _entries = new List<ReconcileEntry>();
                while (r.Read())
                {
                    _entries.Add(new ReconcileEntry
                    {
                        SeqNr = 0,
                        MwId = r.GetInt32(0),
                        Title = r.GetString(1),
                        TitleFromIswcInWid = r.GetString(2),
                        Artist = r.GetString(3),
                        IsConfirmed = r.GetBoolean(4),
                        IsRejected = r.GetBoolean(5),
                        NeedsReIdent = r.GetBoolean(6),
                        IsAutoConfirmed = r.GetBoolean(7) ? IsAutoConfirmedChar : ' ',
                        IsApplied = r.GetBoolean(8)
                    });
                }
            }
            int seqNr = 1;
            _entries.ForEach(x => x.SeqNr = seqNr++);
        }
        private void Initialize(SqlCommand cmd)
        {
            cmd.CommandText = @"
                insert PreClaimIdentReconcile (
                        ddexReportId
                     ,  mwId
                     , TITLE
                     , TITLE_FROM_ISWC_IN_WID
                     , ARTIST
                     , isConfirmed
                     , isRejected
                     , needsReIdent
                     , isAutoConfirmed
                     , isApplied
                )
                select distinct
                      t1.DdexReportId
                    , t2.id
                    , left(t2.ResourceTitle, 256) TITLE
                    , left(t3.Ttl, 256) TITLE_FROM_ISWC_IN_WID
                    , left(t2.DisplayArtistName, 64) ARTIST
                    , 0 isConfirmed
                    , 0 isRejected
                    , 0 needsReIdent
                    , 0 isAutoConfirmed
                    , 0 isApplied
                from IdentBacklog t1
                    join IdentMw t2 on t1.mwId = t2.Id
                    join wid_ipi..TblTitle t3 on t2.wic = t3.wic
                where DdexReportId = @ddexReportId
                    and t2.ISWC <> ''
                    and t2.Wic is not null";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            cmd.ExecuteNonQuery();
        }
        private void InitTmpPreClaimIdentReconcile(SqlCommand cmd, List<ReconcileEntry> entries)
        {
            cmd.CommandText = @"
                drop table if exists #PreClaimIdentReconcile
                create table #PreClaimIdentReconcile (
                      ddexReportId int
                    , mwId int
                    , isConfirmed bit
                    , isRejected bit
                    , needsReIdent bit
                    , isAutoConfirmed bit
                    , IsApplied bit
                )
            ";
            cmd.Parameters.Clear();
            cmd.ExecuteNonQuery();

            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("ddexReportId", typeof(int)));
            dt.Columns.Add(new DataColumn("mwId", typeof(int)));
            dt.Columns.Add(new DataColumn("isConfirmed", typeof(bool)));
            dt.Columns.Add(new DataColumn("isRejected", typeof(bool)));
            dt.Columns.Add(new DataColumn("needsReIdent", typeof(bool)));
            dt.Columns.Add(new DataColumn("isAutoConfirmed", typeof(bool)));
            dt.Columns.Add(new DataColumn("isApplied", typeof(bool)));

            entries.ForEach(x =>
            {
                var dr = dt.NewRow();
                dr[0] = _ddexReportId;
                dr[1] = x.MwId;
                dr[2] = x.IsConfirmed;
                dr[3] = x.IsRejected;
                dr[4] = x.NeedsReIdent;
                dr[5] = x.IsAutoConfirmed == IsAutoConfirmedChar;
                dr[6] = x.IsApplied;
                dt.Rows.Add(dr);
            });
            var uploader = new SqlBulkCopy(
                    cmd.Connection,
                    SqlBulkCopyOptions.TableLock
                        | SqlBulkCopyOptions.FireTriggers
                        | SqlBulkCopyOptions.KeepIdentity
                        | SqlBulkCopyOptions.CheckConstraints,
                    cmd.Transaction
                );
            uploader.BulkCopyTimeout = 0;
            uploader.DestinationTableName = "#PreClaimIdentReconcile";
            uploader.WriteToServer(dt);
        }
        private void AdjustIdentMw(SqlCommand cmd)
        {
            cmd.CommandText = @"
                update t2
                set 
                    t2.Wic = 
                        case 
                            when t1.isConfirmed = 1 then t2.Wic
                            when t1.isRejected = 1 then null
                            when t1.needsReIdent = 1 then null
                            else t2.Wic
                        end,
                    t2.status = 
                        case 
                            when t1.isConfirmed = 1 then 2
                            when t1.isRejected = 1 then 1
                            when t1.needsReIdent = 1 then 0
                            else t2.status 
                        end
                from PreClaimIdentReconcile t1
                    join IdentMw t2 on  t1.mwId = t2.Id
                where t1.ddexReportId = @ddexReportId
                    and t1.IsApplied <> 1
                    and (t1.isConfirmed = 1 or t1.isRejected = 1 or t1.needsReIdent = 1)

                update t1
                set t1.IsApplied = 1
                from PreClaimIdentReconcile t1
                    join IdentMw t2 on  t1.mwId = t2.Id
                where t1.ddexReportId = @ddexReportId
                    and t1.IsApplied <> 1
                    and (t1.isConfirmed = 1 or t1.isRejected = 1 or t1.needsReIdent = 1)
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            cmd.ExecuteNonQuery();
        }
        private void AdjustIdentReportMwRecords(SqlCommand cmd)
        {
            cmd.CommandText = $@"update IdentReportMwRecords
                            set PriorityIndex = null
                            where ddexReportId = @ddexReportId

                            drop table if exists #tmp;
                            select t1.ddexReportId
                                , t1.mwId
                                , row_number() over(order by t1.NetRevenue desc) as rn
                            into #tmp
                            from IdentReportMwRecords t1
                                join IdentMW t2 on t1.mwId = t2.Id
                            where 
                                    isnull(t2.Wic, 0) = 0 
                                and isnull(t2.ObjId, 0) = 0 
                                and t1.ddexReportId = @ddexReportId
 
                            update t2
                            set t2.PriorityIndex = t1.rn 
                            from #tmp t1
                                join IdentReportMwRecords t2 on 
                                        t1.DdexReportId = t2.ddexReportId 
                                    and t1.mwId = t2.mwId

                            drop table if exists #tmp;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            cmd.ExecuteNonQuery();
        }
        private void AutoConfirm(SqlCommand cmd)
        {
            _entries.ForEach(x => AutoConfirmEntry(x));

            InitTmpPreClaimIdentReconcile(cmd, _entries);

            cmd.CommandText = @"
                update t1
                set 
                      t1.isConfirmed = t2.isConfirmed
                    , t1.isRejected = t2.isRejected
                    , t1.needsReIdent = t2.needsReIdent
                    , t1.isAutoConfirmed = t2.isAutoConfirmed
                    , t1.isApplied = t2.isApplied
                from PreClaimIdentReconcile t1
                    join #PreClaimIdentReconcile t2 on t1.ddexReportId = t2.ddexReportId and t1.mwId = t2.mwId
                where t1.ddexReportId = @ddexReportId

                drop table #PreClaimIdentReconcile
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            cmd.ExecuteNonQuery();
        }
        private void AutoConfirmEntry(ReconcileEntry entry)
        {
            var titleInReport = NormalizeString(entry.Title);
            var titleInWid = NormalizeString(entry.TitleFromIswcInWid);

            if (string.IsNullOrEmpty(titleInReport) || string.IsNullOrEmpty(titleInWid))
            {
                return;
            }

            if (titleInReport.Contains(titleInWid) || titleInWid.Contains(titleInReport))
            {
                entry.IsConfirmed = true;
                entry.IsAutoConfirmed = IsAutoConfirmedChar;
            }
        }
        private string NormalizeString(string input)
        {
            return (new string(input.Where(c => char.IsLetterOrDigit(c)).ToArray())).ToUpper();
        }
    }
}
