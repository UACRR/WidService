using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdexPreSearch
{
    public class DdexPreSearchManager
    {
        private const string splitTokens = " ,.;&|/\\";
        const string connString = "Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWidSubmit; Server=193.178.146.103\\IPSDATA,60675";
        //const string connString = @"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWidSubmit; Server=IPS-TESTS\\IPSDATA,60675";

        private int _ddexReportId;
        private int _blockSeqNr;

        private List<ReportWork> _reportWorks;

        public DdexPreSearchManager(int ddexReportId, int blockSeqNr)
        {
            _ddexReportId = ddexReportId;
            _blockSeqNr = blockSeqNr;
        }

        public static List<string> GetReportsList()
        {
            try
            {
                using var conn = new SqlConnection(connString);
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = @"
                    select t1.id, t2.year, t2.quarter, t2.month, t1.FileType
                    from Ddex..DdexReport t1
                        join Ddex..DdexReportingPeriod t2 on t1.ddexReportingPeriodId = t2.Id
                    order by t2.year desc, quarter desc, month desc
                    ";
                cmd.Parameters.Clear();
                using var r = cmd.ExecuteReader();
                var retVal = new List<string>();
                while (r.Read())
                {
                    var quarter = r.IsDBNull(2) ? "" : $", Q{r.GetInt32(2)}";
                    var month = r.IsDBNull(3) ? "" : $", M{r.GetInt32(3)}";
                    var reportString = $"{r.GetInt32(0)}, {r.GetInt32(1)}{quarter}{month}, {r.GetString(4)}";
                    retVal.Add(reportString);
                }
                return retVal;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ReportWork> GetReportWorks()
        {
            return _reportWorks;
        }

        public void PrepareData()
        {
            var exists = CheckBlockExists();
            if(!exists)
            {
                CreateData();
            }
            LoadData();
        }
        private void CreateData()
        {
            SqlTransaction tran = null;
            try
            {
                using var conn = new SqlConnection(connString);
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandTimeout = 0;

                tran = conn.BeginTransaction();
                cmd.Transaction = tran;

                FillDdexPreSearchReportWorks(cmd);
                LoadReportWorks(cmd);
                TranslitReportWorks(cmd);
                SearchAllInMs(cmd);
                SearchInWid(cmd);
                CleanFoundAuthors(cmd);
                CleanFoundPerformers(cmd);

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw;
            }
        }

        private void LoadData()
        {
            try
            {
                using var conn = new SqlConnection(connString);
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandTimeout = 0;

                LoadReportWorks(cmd);
                LoadFoundWorks(cmd);
                FindAuthorPerformerMatches();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool CheckBlockExists()
        {
            using var conn = new SqlConnection(connString);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = "select top 1 Id from DDEX_MW_SEARCH..DdexPreSearchReportWorks where DdexReportId = @ddexReportId and BlockSeqNr = @blockSeqNr";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            cmd.Parameters.AddWithValue("@blockSeqNr", _blockSeqNr);
            using var r = cmd.ExecuteReader();
            return r.HasRows;
        }

        private void FillDdexPreSearchReportWorks(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DDEX_MW_SEARCH..spFillDdexPreSearchReportWorks";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            cmd.Parameters.AddWithValue("@blockSeqNr", _blockSeqNr);
            cmd.ExecuteNonQuery();
        }


        private void LoadReportWorks(SqlCommand cmd)
        {
            cmd.CommandText = @"select Id, MwId, Album, Name, Authors, Performers, AlbumT, NameT, AuthorsT, PerformersT
                from DDEX_MW_SEARCH..DdexPreSearchReportWorks
                where DdexReportId = @ddexReportId and BlockSeqNr = @blockSeqNr
                order by MwId";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            cmd.Parameters.AddWithValue("@blockSeqNr", _blockSeqNr);
            using var r = cmd.ExecuteReader();
            _reportWorks = new List<ReportWork>();
            while (r.Read())
            {
                var idx = 0;
                var reportWork = new ReportWork();
                reportWork.Id = r.GetInt32(idx++);
                reportWork.MwId = r.GetInt32(idx++);
                reportWork.Album = r.GetString(idx++);
                reportWork.Name = r.GetString(idx++);
                reportWork.Authors = r.GetString(idx++);
                reportWork.Performers = r.GetString(idx++);
                reportWork.AlbumT = r.GetString(idx++);
                reportWork.NameT = r.GetString(idx++);
                reportWork.AuthorsT = r.GetString(idx++);
                reportWork.PerformersT = r.GetString(idx++);
                reportWork.FoundWorks = new List<FoundWork>();
                _reportWorks.Add(reportWork);
            }
        }

        private void TranslitReportWorks(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"
                update DDEX_MW_SEARCH..DdexPreSearchReportWorks
                set 
                      AlbumT = @AlbumT
                    , NameT = @NameT
                    , AuthorsT = @AuthorsT
                    , PerformersT = @PerformersT
                where Id = @id";
            _reportWorks.ForEach(x =>
            {
                x.AlbumT = Translit.FromUkr(x.Album);
                x.NameT = Translit.FromUkr(x.Name);
                x.AuthorsT = Translit.FromUkr(x.Authors);
                x.PerformersT = Translit.FromUkr(x.Performers);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", x.Id);
                cmd.Parameters.AddWithValue("@AlbumT", x.AlbumT);
                cmd.Parameters.AddWithValue("@NameT", x.NameT);
                cmd.Parameters.AddWithValue("@AuthorsT", x.AuthorsT);
                cmd.Parameters.AddWithValue("@PerformersT", x.PerformersT);

                cmd.ExecuteNonQuery();
            });
        }

        private void SearchInMs(SqlCommand cmd, bool useAlbum, bool searchAlt, bool useTranslit)
        {
            var sourceCol = useAlbum ? "A" : "N";
            var sourceColName = useAlbum ? "Album" : "Name";
            var targetTbl = searchAlt ? "Alt" : "Main";
            if (useTranslit)
            {
                sourceCol += 'T';
                sourceColName += 'T';
            }

            var joinText = searchAlt ?
                $@"join MediaService..SeekObject t3 on t1.{sourceColName} = t3.name and t3.codeI = 1
                    join MediaService..ObjectRight t2 on t3.ObjId = t2.ObjId"
                :
                $@"join MediaService..ObjectRight t2 on t1.{sourceColName} = t2.name";

            cmd.CommandText = $@"
                insert DDEX_MW_SEARCH..DdexPreSearchFoundWorks (
                      DdexPreSearchReportWorkId
                    , Name
                    , Authors
                    , Performers
                    , SourceCol
                    , TargetDb
                    , TargetTbl
                    , FoundId
                )
                select 
                      t1.Id as DdexPreSearchReportWorkId
                    , left(t2.Name, 1000) as Name
                    , left(t2.Author, 1000) as Authors
                    , left(t2.performer, 1000) as Performers
                    , '{sourceCol}' as SourceCol
                    , 'MS' as TargetDb
                    , '{targetTbl}' as TargetTbl
                    , t2.objId as FoundId
                from DDEX_MW_SEARCH..DdexPreSearchReportWorks t1
                    {joinText}
                where t1.DdexReportId = @ddexReportId
                    and t1.BlockSeqNr = @blockSeqNr
                    and t1.{sourceColName} <> ''
                    and t2.ObjId not in (select FoundId from DDEX_MW_SEARCH..DdexPreSearchFoundWorks tt where tt.DdexPreSearchReportWorkId = t1.Id)
                ";
            cmd.ExecuteNonQuery();
        }

        private void SearchAllInMs(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            cmd.Parameters.AddWithValue("@blockSeqNr", _blockSeqNr);
            SearchInMs(cmd, false, false, false);
            SearchInMs(cmd, false, false, true);
            SearchInMs(cmd, false, true, false);
            SearchInMs(cmd, false, true, true);
            SearchInMs(cmd, true, false, false);
            SearchInMs(cmd, true, false, true);
            SearchInMs(cmd, true, true, false);
            SearchInMs(cmd, true, true, true);
        }

        private void SearchInWid(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DDEX_MW_SEARCH..spFillDdexPreSearchWidFoundWorks";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            cmd.Parameters.AddWithValue("@blockSeqNr", _blockSeqNr);
            cmd.ExecuteNonQuery();
        }

        private void CleanFoundAuthors(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"
                update t1
                set t1.Authors = ''
                from DDEX_MW_SEARCH..DdexPreSearchFoundWorks t1
                    join DDEX_MW_SEARCH..DdexPreSearchReportWorks t2 on t1.DdexPreSearchReportWorkId = t2.Id
                where t1.Authors is null
                    and t2.DdexReportId = @ddexReportId
                    and t2.BlockSeqNr = @blockSeqNr
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            cmd.Parameters.AddWithValue("@blockSeqNr", _blockSeqNr);
            cmd.ExecuteNonQuery();
        }

        private void CleanFoundPerformers(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"
                update t1
                set t1.Performers = ''
                from DDEX_MW_SEARCH..DdexPreSearchFoundWorks t1
                    join DDEX_MW_SEARCH..DdexPreSearchReportWorks t2 on t1.DdexPreSearchReportWorkId = t2.Id
                where t1.Performers is null
                    and t2.DdexReportId = @ddexReportId
                    and t2.BlockSeqNr = @blockSeqNr
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            cmd.Parameters.AddWithValue("@blockSeqNr", _blockSeqNr);
            cmd.ExecuteNonQuery();
        }

        private void LoadFoundWorks(SqlCommand cmd)
        {
            cmd.CommandText = @"
                select
                  t1.DdexPreSearchReportWorkId
                , t1.Name
                , t1.Authors
                , t1.Performers
                , t1.SourceCol
                , t1.TargetDb
                , t1.TargetTbl
                , t1.FoundId
            from DDEX_MW_SEARCH..DdexPreSearchFoundWorks t1
                join DDEX_MW_SEARCH..DdexPreSearchReportWorks t2 on t1.DdexPreSearchReportWorkId = t2.Id
            where t2.DdexReportId = @ddexReportId
                and t2.BlockSeqNr = @blockSeqNr
            ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
            cmd.Parameters.AddWithValue("@blockSeqNr", _blockSeqNr);
            using var r = cmd.ExecuteReader();

            ReportWork curReportWork = null;
            while (r.Read())
            {
                var newReportWorkId = r.GetInt32(0);
                if(curReportWork == null || curReportWork.Id != newReportWorkId)
                {
                    curReportWork = _reportWorks.Single(x => x.Id == newReportWorkId);
                }
                var idx = 1;
                var foundWork = new FoundWork();
                foundWork.Name = r.GetString(idx++);
                foundWork.Authors = r.GetString(idx++);
                foundWork.Performers = r.GetString(idx++);
                foundWork.SourceCol = r.GetString(idx++);
                foundWork.TargetDb = r.GetString(idx++);
                foundWork.TargetTbl = r.GetString(idx++);
                foundWork.FoundId = r.GetInt32(idx++);
                curReportWork.FoundWorks.Add(foundWork);
            }
        }

        private void FindAuthorPerformerMatches()
        {
            _reportWorks.ForEach(reportWork =>
            {
                SearchMatchesInFoundWorks(reportWork);
            });
        }

        private bool SearchMatchesInFoundWork(string[] words, FoundWork foundWork)
        {
            for (int idx = 0; idx < words.Length; idx++)
            {
                var word = words[idx].Trim();
                if (word.Length < 3)
                {
                    continue;
                }

                var foundAuthorsT = Translit.FromUkr(foundWork.Authors);
                var foundPerformersT = Translit.FromUkr(foundWork.Performers);

                if (foundWork.Authors.Contains(word) || foundWork.Performers.Contains(word)
                     || foundAuthorsT.Contains(word) || foundPerformersT.Contains(word))
                {
                    foundWork.IsMatching = true;
                    return true;
                }
            }
            foundWork.IsMatching = false;
            return false;
        }

        private void SearchMatchesInFoundWorks(ReportWork reportWork)
        {
            reportWork.HasMatchingWorks = false;
            var authors = reportWork.Authors.Split(splitTokens);
            var performers = reportWork.Performers.Split(splitTokens);
            var authorsT = reportWork.AuthorsT.Split(splitTokens);
            var performersT = reportWork.PerformersT.Split(splitTokens);
            var words = authors
                .Union(performers)
                .Union(authorsT)
                .Union(performersT)
                .ToArray();
            reportWork.FoundWorks.ForEach(x =>
            {
                if (SearchMatchesInFoundWork(words, x))
                {
                    reportWork.HasMatchingWorks = true;
                }
            });
        }
    }
}
