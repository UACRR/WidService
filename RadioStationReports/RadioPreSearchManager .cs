using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace RadioStationReports
{
    public class RadioPreSearchManager
    {
        private class ImportData
        {
            public int LineNr { get; set; }
            public int? ObjId { get; set; }
            public int? Wic { get; set; }
            public string Iswc { get; set; }
        }

        private class DistributionData
        {
            public string ReportId { get; set; }
            public string LineNr { get; set; }
            public string AuthorSeqNr { get; set; }
            public string WorkCode { get; set; }
            public string Iswc { get; set; }
            public double? TotalShare { get; set; }
            public double? TotalShareToPay { get; set; }
            public string ReportLineName { get; set; }
            public string ReportLinePerformer { get; set; }
            public string ReportLineMusicAuthor { get; set; }
            public string ReportLineTextAuthor { get; set; }
            public string ReportLineDuration { get; set; }
            public string ReportLineCountUses { get; set; }
            public string ReportLineTotalDuration { get; set; }
            
            public string ToBeFilledDurationInSec { get; set; }
            public string ToBeFilledWorkRoyalty { get; set; }
            
            public string FoundRhCustId { get; set; }
            public string FoundRhIpBaseNr { get; set; }
            public string FoundRhIpNameNr { get; set; }
            public string FoundRhName { get; set; }
            
            public double? FoundRhPerShare { get; set; }
            public double? FoundRhPerShareToPay { get; set; }
            public string FoundRhPerSocToPayCde { get; set; }
            public string FoundRhPerSocToPayName { get; set; }
            
            public double? FoundRhMecShare { get; set; }
            public double? FoundRhMecShareToPay { get; set; }
            public string FoundRhMecSocToPayCde { get; set; }
            public string FoundRhMecSocToPayName { get; set; }
            
            public string FoundRhAgreementNr { get; set; }
            public string FoundRhAgreementStatus { get; set; }

            public string SubPublisher { get; set; }
        }

        public enum WorksFilter
        {
            all,
            hasMatches,
            hasNoMatches,
            hasStrongMatches,
            unprocessed,
        }

        private List<ReportLine> _reportLines;

        private const string splitTokens = " ,.;&|/\\";
        //const string connString = "Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = RadioStationReports; Server=193.178.146.103\\IPSDATA,60675";
        //const string connString = @"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWidSubmit; Server=IPS-TESTS\\IPSDATA,60675";

        private List<Work> _works;
        private int _reportId;

        // Status of long operation
        private bool _isInProgress = false;
        private int _progress = 0;
        private int _progressMax = 0;
        private string _errorText = "";
        public bool IsInProgress { 
            get { lock(this) return _isInProgress; }
            set { lock(this) _isInProgress = value; }
        }
        public int Progress { 
            get { lock(this) return _progress; }
            private set { lock(this) _progress = value; }
        }
        public int ProgressMax { 
            get { lock(this) return _progressMax; }
            set { lock(this) _progressMax = value; }
        }
        public string ErrorText { 
            get { lock(this) return _errorText; }
            set { lock(this) _errorText = value; }
        }

        public RadioPreSearchManager(int reportId)
        {
            _reportId = reportId;
        }

        public RadioPreSearchManager()
        {
            _reportId = 0;
        }

        public int GetReportId() => _reportId;

        private void ReadReportLinesFromFile(string fileFullName)
        {
            _reportLines = new List<ReportLine>();

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fileFullName);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            if(colCount != 9)
            {
                throw new Exception("Wrong file");
            }

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 2; i <= rowCount; i++)
            {

                var cell = (Excel.Range)xlWorksheet.Cells[i, 1];
                var seqNrStr = cell.Text;
                int seqNr;
                if (!int.TryParse(seqNrStr, out seqNr))
                {
                    break;
                }

                cell = (Excel.Range)xlWorksheet.Cells[i, 2];
                string name = Convert.ToString(cell.Text == null ? "" : cell.Text);
                name = name.Trim().Replace('\t', ' ');

                cell = (Excel.Range)xlWorksheet.Cells[i, 3];
                string performer = Convert.ToString(cell.Text == null ? "" : cell.Text);
                performer = performer.Trim().Replace('\t', ' ');

                cell = (Excel.Range)xlWorksheet.Cells[i, 4];
                string musicAuthor = Convert.ToString(cell.Text == null ? "" : cell.Text);
                musicAuthor = musicAuthor.Trim().Replace('\t', ' ');

                cell = (Excel.Range)xlWorksheet.Cells[i, 5];
                string textAuthor = Convert.ToString(cell.Text == null ? "" : cell.Text);
                textAuthor = textAuthor.Trim().Replace('\t', ' ');

                cell = (Excel.Range)xlWorksheet.Cells[i, 6];
                string duratrion = Convert.ToString(cell.Text == null ? "" : cell.Text);
                duratrion = duratrion.Trim().Replace('\t', ' ');

                cell = (Excel.Range)xlWorksheet.Cells[i, 7];
                string countUses = Convert.ToString(cell.Text == null ? "" : cell.Text);
                countUses = countUses.Trim().Replace('\t', ' ');

                cell = (Excel.Range)xlWorksheet.Cells[i, 8];
                string totalDuration = Convert.ToString(cell.Text == null ? "" : cell.Text);
                totalDuration = totalDuration.Trim().Replace('\t', ' ');

                _reportLines.Add(new ReportLine
                {
                    LineNr = seqNr,
                    Name = name,
                    Performer = performer,
                    MusicAuthor = musicAuthor,
                    TextAuthor = textAuthor,
                    Duration = duratrion,
                    CountUses = countUses,
                    TotalDuration = totalDuration,
                });
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }

        private void InsertReportLinesIntoDb(SqlCommand cmd, int reportId)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RadioStationReports..spInsertReportLine";
                _reportLines.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ReportId"     , reportId          );
                    cmd.Parameters.AddWithValue("@LineNr"       , x.LineNr          );
                    cmd.Parameters.AddWithValue("@Name"         , x.Name            );
                    cmd.Parameters.AddWithValue("@Performer"    , x.Performer       );
                    cmd.Parameters.AddWithValue("@MusicAuthor"  , x.MusicAuthor     );
                    cmd.Parameters.AddWithValue("@TextAuthor"   , x.TextAuthor      );
                    cmd.Parameters.AddWithValue("@Duration"     , x.Duration        );
                    cmd.Parameters.AddWithValue("@CountUses"    , x.CountUses       );
                    cmd.Parameters.AddWithValue("@TotalDuration", x.TotalDuration   );

                    cmd.ExecuteNonQuery();
                });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int LoadReport(string fileFullName)
        {
            var fileName = Path.GetFileName(fileFullName);
            var filePath = Path.GetDirectoryName(fileFullName);
            var exists = false;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = "select min(Id) from RadioStationReports..Reports where FileName = @fileName";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fileName", fileName);
                var reportId = cmd.ExecuteScalar();

                if (reportId != DBNull.Value)
                {
                    exists = true;
                }
           });

            if(exists)
            {
                throw new Exception("Файл вже завантажений.");
            }


            try
            {
                ReadReportLinesFromFile(fileFullName);
            }
            catch(Exception ex)
            {
                throw new Exception("Файл не відповідає формату звітів від радіостанцій.\r\n" + ex.Message);
            }

            Helpers.RunSqlT(cmd =>
            {
                // Додатова перевірка існування файлу (може трапитись, якшо той самий файл вантажити паралельно)
                exists = false;
                cmd.CommandText = "select min(Id) from Reports where FileName = @fileName";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fileName", fileName);
                var reportId = cmd.ExecuteScalar();

                if (reportId != DBNull.Value)
                {
                    exists = true;
                    return;
                }

                cmd.CommandText = @"
                    insert Reports (
                          FileName
                        , FilePath
                        , SearchFileName
                        , DistributionFileName
                        , CreatedAt
                        , UpdatedAt
                    )
                    values (
                          @fileName
                        , @filePath
                        , ''
                        , ''
                        , getdate()
                        , getdate()
                    )
                    select scope_identity()";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fileName", fileName);
                cmd.Parameters.AddWithValue("@filePath", filePath);
                reportId = cmd.ExecuteScalar();

                InsertReportLinesIntoDb(cmd, Convert.ToInt32(reportId));

                _reportId = Convert.ToInt32(reportId);

                cmd.CommandTimeout = 0;
                LoadReportWorks(cmd, WorksFilter.unprocessed);
                TranslitReportWorks(cmd);
                //SearchAllInMs(cmd);
                //SearchInWid(cmd);
                //CleanFoundAuthors(cmd);
                //CleanFoundPerformers(cmd);
                //LoadReportWorks(cmd, WorksFilter.unprocessed);
                //LoadMatchingWorks(cmd, true);
                //FindAuthorPerformerMatches(cmd);
                //ApplyMatches(cmd);
                //CalcShares(cmd);
            });

            if(exists)
            {
                throw new Exception("Файл вже завантажений.");
            }
            return _reportId;
        }

        public static List<string> GetReportsList()
        {
            var retVal = new List<string>();

            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select Id, FileName
                    from RadioStationReports..Reports
                    order by FileName
                ";
                cmd.Parameters.Clear();
                using var r = cmd.ExecuteReader();
                
                while (r.Read())
                {
                    var reportString = $"{r.GetInt32(0)}, {r.GetString(1)}";
                    retVal.Add(reportString);
                }
            });
            return retVal;
        }

        public List<Work> GetReportWorks()
        {
            return _works;
        }

        public void LoadReportWorks(SqlCommand cmd, WorksFilter filter)
        {
            var filterText = "";
            switch(filter)
            {
                case WorksFilter.hasMatches:
                    filterText = " and exists (select null from RadioStationReports..MatchingWorks where WorkId = t2.Id)";
                    break;
                case WorksFilter.hasNoMatches:
                    filterText = " and not exists (select null from RadioStationReports..MatchingWorks where WorkId = t2.Id)";
                    break;
                case WorksFilter.hasStrongMatches:
                    filterText = " and exists (select null from RadioStationReports..MatchingWorks where WorkId = t2.Id and IsStrongMatch = 1)";
                    break;
                case WorksFilter.unprocessed:
                    filterText = " and IsProcessed is null";
                    break;
            }
            cmd.CommandText = $@"
                select t2.Id, t2.Name, t2.Authors, t2.Performers, t2.NameT, t2.AuthorsT, t2.PerformersT, t2.FoundIn, t2.FoundCde, t2.Share
                from RadioStationReports..ReportLines t1
                    join RadioStationReports..Works t2 on t1.WorkId = t2.Id
                where t1.ReportId = @reportId {filterText}
                order by t1.LineNr
            ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reportId", _reportId);
            using var r = cmd.ExecuteReader();
            _works = new List<Work>();
            while (r.Read())
            {
                var idx = 0;
                var reportWork = new Work();
                reportWork.Id = r.GetInt32(idx++);
                reportWork.Name = r.GetString(idx++);
                reportWork.Authors = r.GetString(idx++);
                reportWork.Performers = r.GetString(idx++);
                reportWork.NameT = r.IsDBNull(idx) ? "" : r.GetString(idx);
                idx++;
                reportWork.AuthorsT = r.IsDBNull(idx) ? "" : r.GetString(idx);
                idx++;
                reportWork.PerformersT = r.IsDBNull(idx) ? "" : r.GetString(idx);
                idx++;
                reportWork.FoundIn = r.IsDBNull(idx) ? "" : r.GetString(idx);
                idx++;
                reportWork.FoundCde = r.IsDBNull(idx) ? (int?)null : r.GetInt32(idx);
                idx++;
                reportWork.Share = r.IsDBNull(idx) ? (decimal?)null : r.GetDecimal(idx);

                reportWork.MatchingWorks = new List<MatchingWork>();
                _works.Add(reportWork);
            }
        }

        public void LoadMatchingWorks(SqlCommand cmd, bool unprocessedOnly)
        {
            var filter = unprocessedOnly ? " and t1.IsProcessed is null" : "";
            cmd.CommandText = $@"
                select
                      t2.WorkId
                    , t2.Id
                    , t2.Name
                    , t2.Authors
                    , t2.Performers
                    , t2.FoundInDb
                    , t2.MainOrAlt
                    , t2.FoundId
                from RadioStationReports..ReportLines t0
                    join RadioStationReports..Works t1 on t0.WorkId = t1.Id
                    join RadioStationReports..MatchingWorks t2 on t1.Id = t2.WorkId
                where t0.ReportId = @reportId
                    {filter}
            ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reportId", _reportId);
            using var r = cmd.ExecuteReader();

            Work curReportWork = null;
            while (r.Read())
            {
                var newReportWorkId = r.GetInt32(0);
                if(curReportWork == null || curReportWork.Id != newReportWorkId)
                {
                    curReportWork = _works.Single(x => x.Id == newReportWorkId);
                }
                var idx = 1;
                var foundWork = new MatchingWork();
                foundWork.Id = r.GetInt32(idx++);
                foundWork.Name = r.GetString(idx++);
                foundWork.Authors = r.IsDBNull(idx) ? "" : r.GetString(idx);
                idx++;
                foundWork.Performers = r.IsDBNull(idx) ? "" : r.GetString(idx);
                idx++;
                foundWork.FoundInDb = r.GetString(idx++);
                foundWork.MainOrAlt = r.GetString(idx++);
                foundWork.FoundId = r.GetInt32(idx++);
                curReportWork.MatchingWorks.Add(foundWork);
            }
        }

        public void LoadMatchingWorks(SqlCommand cmd, Work work)
        {
            cmd.CommandText = @"
                select
                      t2.WorkId
                    , t2.Id
                    , t2.Name
                    , t2.Authors
                    , t2.Performers
                    , t2.FoundInDb
                    , t2.MainOrAlt
                    , t2.FoundId
                    , t2.IsStrongMatch
                from RadioStationReports..Works t1
                    join RadioStationReports..MatchingWorks t2 on t1.Id = t2.WorkId
                where t2.WorkId = @workId
            ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@workId", work.Id);
            using var r = cmd.ExecuteReader();

            work.MatchingWorks.Clear();
            while (r.Read())
            {
                var idx = 1;
                var foundWork = new MatchingWork();
                foundWork.Id = r.GetInt32(idx++);
                foundWork.Name = r.GetString(idx++);
                foundWork.Authors = r.IsDBNull(idx) ? "" : r.GetString(idx);
                idx++;
                foundWork.Performers = r.IsDBNull(idx) ? "" : r.GetString(idx);
                idx++;
                foundWork.FoundInDb = r.GetString(idx++);
                foundWork.MainOrAlt = r.GetString(idx++);
                foundWork.FoundId = r.GetInt32(idx++);
                foundWork.IsMatchingAuthorPerformer = r.GetBoolean(idx++);
                work.MatchingWorks.Add(foundWork);
            }
        }

        private void TranslitReportWorks(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"
                update RadioStationReports..Works
                set 
                      NameT = @NameT
                    , AuthorsT = @AuthorsT
                    , PerformersT = @PerformersT
                where Id = @id ";
            _works.Where(x => x.NameT == "").ToList().ForEach(x =>
            {
                x.NameT = Translit.FromUkr(x.Name);
                x.AuthorsT = Translit.FromUkr(x.Authors);
                x.PerformersT = Translit.FromUkr(x.Performers);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", x.Id);
                cmd.Parameters.AddWithValue("@NameT", x.NameT);
                cmd.Parameters.AddWithValue("@AuthorsT", x.AuthorsT);
                cmd.Parameters.AddWithValue("@PerformersT", x.PerformersT);

                cmd.ExecuteNonQuery();
            });
        }

        private void SearchInMs(SqlCommand cmd, bool searchAlt, bool useTranslit)
        {
            var sourceColName = "Name";
            var mainOrAlt = searchAlt ? "A" : "M";
            if (useTranslit)
            {
                sourceColName += 'T';
            }

            var joinText = searchAlt ?
                $@"join MediaService..SeekObject t3 on t1.{sourceColName} = t3.name and t3.codeI = 1
                    join MediaService..ObjectRight t2 on t3.ObjId = t2.ObjId"
                :
                $@"join MediaService..ObjectRight t2 on t1.{sourceColName} = t2.name";

            cmd.CommandText = $@"
                insert RadioStationReports..MatchingWorks (
                      WorkId
                    , Name
                    , Authors
                    , Performers
                    , FoundInDb
                    , MainOrAlt
                    , FoundId
                    , IsStrongMatch
                )
                select 
                      t1.Id as WorkId
                    , left(t2.Name, 1000) as Name
                    , left(t2.Author, 1000) as Authors
                    , left(t2.performer, 1000) as Performers
                    , 'M' as FoundInDb
                    , '{mainOrAlt}' as MainOrAlt
                    , t2.objId as FoundId
                    , 0 as IsStrongMatch
                from RadioStationReports..ReportLines t0
                    join RadioStationReports..Works t1 on t0.WorkId = t1.Id
                    {joinText}
                where t0.ReportId = @reportId
                    and t1.{sourceColName} <> ''
                    and t1.IsProcessed is null
                    and t2.ObjId not in (select FoundId from RadioStationReports..MatchingWorks tt where tt.WorkId = t1.Id)
                ";
            cmd.ExecuteNonQuery();
        }

        private void SearchInMsPlus(SqlCommand cmd, bool searchAlt, bool useTranslit)
        {
            var sourceColName = "Name";
            var mainOrAlt = searchAlt ? "A" : "M";
            if (useTranslit)
            {
                sourceColName += 'T';
            }

            var joinText = searchAlt ?
                $@"join MediaService..SeekObject t3 on 
                    trim(
			                    substring( t1.{sourceColName}
				                    , 1
				                    , case when charindex('(', t1.{sourceColName}) = 0 then len(t1.{sourceColName}) else charindex('(', t1.{sourceColName}) - 1  end)
		                    )
                    = t3.name and t3.codeI = 1
                    join MediaService..ObjectRight t2 on t3.ObjId = t2.ObjId"
                :
                $@"join MediaService..ObjectRight t2 on
                    trim(
			                    substring( t1.{sourceColName}
				                    , 1
				                    , case when charindex('(', t1.{sourceColName}) = 0 then len(t1.{sourceColName}) else charindex('(', t1.{sourceColName}) - 1  end)
		                    )
 
                    = t2.name";

            cmd.CommandText = $@"
                insert RadioStationReports..MatchingWorks (
                      WorkId
                    , Name
                    , Authors
                    , Performers
                    , FoundInDb
                    , MainOrAlt
                    , FoundId
                    , IsStrongMatch
                )
                select 
                      t1.Id as WorkId
                    , left(t2.Name, 1000) as Name
                    , left(t2.Author, 1000) as Authors
                    , left(t2.performer, 1000) as Performers
                    , 'M' as FoundInDb
                    , '{mainOrAlt}' as MainOrAlt
                    , t2.objId as FoundId
                    , 0 as IsStrongMatch
                from RadioStationReports..ReportLines t0
                    join RadioStationReports..Works t1 on t0.WorkId = t1.Id
                    {joinText}
                where t0.ReportId = @reportId
                    and t1.IsProcessed is null
                    and t1.{sourceColName} <> ''
                    and t2.ObjId not in (select FoundId from RadioStationReports..MatchingWorks tt where tt.WorkId = t1.Id)
                ";
            cmd.ExecuteNonQuery();
        }

        private void SearchAllInMs(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reportId", _reportId);
            SearchInMs(cmd, false, false);
            SearchInMs(cmd, false, true);
            SearchInMs(cmd, true, false);
            SearchInMs(cmd, true, true);

            SearchInMsPlus(cmd, false, false);
            SearchInMsPlus(cmd, false, true);
            SearchInMsPlus(cmd, true, false);
            SearchInMsPlus(cmd, true, true);
        }

        private void SearchInWid(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RadioStationReports..spSearchMatchingWorksInWid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reportId", _reportId);
            cmd.ExecuteNonQuery();
        }

        private void CleanFoundAuthors(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"
                update t1
                set t1.Authors = ''
                from RadioStationReports..ReportLines t0
                    join RadioStationReports..MatchingWorks t1 on t0.WorkId = t1.Id
                    join RadioStationReports..Works t2 on t1.WorkId = t2.Id
                where t1.Authors is null
                    and t0.ReportId = @reportId
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("reportId", _reportId);
            cmd.ExecuteNonQuery();
        }

        private void CleanFoundPerformers(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"
                update t1
                set t1.Performers = ''
                from RadioStationReports..ReportLines t0
                    join RadioStationReports..MatchingWorks t1 on t0.WorkId = t1.Id
                    join RadioStationReports..Works t2 on t1.WorkId = t2.Id
                where t1.Performers is null
                    and t0.ReportId = @reportId
            ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("reportId", _reportId);
            cmd.ExecuteNonQuery();
        }

        private void FindAuthorPerformerMatches(SqlCommand cmd)
        {
            _works.ForEach(reportWork =>
            {
                SearchMatchesInFoundWorks(cmd, reportWork);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update RadioStationReports..Works set IsProcessed = 1 where Id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", reportWork.Id);
                cmd.ExecuteNonQuery();
            });
        }

        private bool SearchMatchesInFoundWork(SqlCommand cmd, string[] words, MatchingWork foundWork)
        {
            foundWork.IsMatchingAuthorPerformer = false;
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
                    foundWork.IsMatchingAuthorPerformer = true;
                    break;
                }
            }

            if(foundWork.IsMatchingAuthorPerformer)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update RadioStationReports..MatchingWorks set IsStrongMatch = 1 where Id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", foundWork.Id);
                cmd.ExecuteNonQuery();
            }

            return foundWork.IsMatchingAuthorPerformer;
        }

        private void SearchMatchesInFoundWorks(SqlCommand cmd, Work reportWork)
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
            reportWork.MatchingWorks.ForEach(x =>
            {
                if (SearchMatchesInFoundWork(cmd, words, x))
                {
                    reportWork.HasMatchingWorks = true;
                }
            });
        }

        public void ApplyMatches(SqlCommand cmd)
        {
            cmd.CommandText = @"
                    update RadioStationReports..Works
                    set FoundIn = @foundIn, FoundCde = @foundCde, Share = null
                    where Id = @id
                ";
            _works.Where(x => x.HasMatchingWorks).ToList().ForEach(x =>
            {
                var matchingWork = x.MatchingWorks.First(y => y.IsMatchingAuthorPerformer);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", x.Id);
                cmd.Parameters.AddWithValue("@foundIn", matchingWork.FoundInDb);
                cmd.Parameters.AddWithValue("@foundCde", matchingWork.FoundId);
                cmd.ExecuteNonQuery();
            });
        }

        public void CalcShares(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spCreateReportAuthors";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reportId", _reportId);
            cmd.ExecuteNonQuery();
        }

        public void InsertIswcs(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spInsertIswcs";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reportId", _reportId);
            cmd.ExecuteNonQuery();
        }

        public void AutoSearch()
        {
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandTimeout = 0;
                LoadReportWorks(cmd, WorksFilter.unprocessed);
                SearchAllInMs(cmd);
                SearchInWid(cmd);
                CleanFoundAuthors(cmd);
                CleanFoundPerformers(cmd);
                LoadReportWorks(cmd, WorksFilter.unprocessed);
                LoadMatchingWorks(cmd, true);
                FindAuthorPerformerMatches(cmd);
                ApplyMatches(cmd);
                CalcShares(cmd);
                InsertIswcs(cmd);
            });
        }

        public void RecalcShares()
        {
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandTimeout = 0;
                //CleanFoundAuthors(cmd);
                //CleanFoundPerformers(cmd);
                LoadReportWorks(cmd, WorksFilter.all);
                //LoadMatchingWorks(cmd, false);
                //FindAuthorPerformerMatches(cmd);
                //ApplyMatches(cmd);
                CalcShares(cmd);
                //InsertIswcs(cmd);
            });
        }

        private static void SetCellValue(Excel._Worksheet xlWorkSheet, int row, int col, string value)
        {
            var cell = xlWorkSheet.Cells[row, col];
            cell.Value = value;
        }

        private static void SetCellFormula(Excel._Worksheet xlWorkSheet, int row, int col, string value)
        {
            var cell = xlWorkSheet.Cells[row, col];
            cell.Formula = value;
        }

        public static void CreateSearchFile(Report report, List<ReportLine> reportLines)
        {
            var fileFullName = Path.Combine(report.FilePath, $"Search_{report.FileName}");
            Helpers.CreateExcelFile( fileFullName, xlWorksheet => {
                xlWorksheet.Name = "Рядки звіту";

                var dataArray = new object[reportLines.Count + 1, 6];

                var idxRow = 0;
                var idxCol = 0;

                dataArray[idxRow, idxCol++] = "ObjId";
                dataArray[idxRow, idxCol++] = "Wic";
                dataArray[idxRow, idxCol++] = "Iswc";
                dataArray[idxRow, idxCol++] = "№";
                dataArray[idxRow, idxCol++] = "Назва";
                dataArray[idxRow, idxCol++] = "Виконавці";

                reportLines.ForEach(x =>
                {
                    idxRow++;
                    idxCol = 0;
                    dataArray[idxRow, idxCol++] = x.Work.FoundIn == null ? "" : x.Work.FoundIn == "M" ? x.Work.FoundCde.ToString() : "";
                    dataArray[idxRow, idxCol++] = x.Work.FoundIn == null ? "" : x.Work.FoundIn == "W" ? x.Work.FoundCde.ToString() : "";
                    dataArray[idxRow, idxCol++] = x.Work.Iswc;
                    dataArray[idxRow, idxCol++] = x.LineNr.ToString();
                    dataArray[idxRow, idxCol++] = x.Name;
                    dataArray[idxRow, idxCol++] = x.Performer;
                });

                var c1 = (Excel.Range)xlWorksheet.Cells[1, 1];
                var c2 = (Excel.Range)xlWorksheet.Cells[1 + reportLines.Count, 6];
                var range = xlWorksheet.get_Range(c1, c2);
                range.Value2 = dataArray;

/*
                SetCellValue(xlWorksheet, idxRow, idxCol++, "ObjId");
                SetCellValue(xlWorksheet, idxRow, idxCol++, "Wic");
                SetCellValue(xlWorksheet, idxRow, idxCol++, "Iswc");
                SetCellValue(xlWorksheet, idxRow, idxCol++, "№");
                SetCellValue(xlWorksheet, idxRow, idxCol++, "Назва");
                SetCellValue(xlWorksheet, idxRow, idxCol++, "Виконавці");

                reportLines.ForEach(x =>
                {
                    idxRow++;
                    idxCol = 1;
                    SetCellValue(xlWorksheet, idxRow, idxCol++, x.Work.FoundIn == null ? "" : x.Work.FoundIn == "M" ? x.Work.FoundCde.ToString() : "");
                    SetCellValue(xlWorksheet, idxRow, idxCol++, x.Work.FoundIn == null ? "" : x.Work.FoundIn == "W" ? x.Work.FoundCde.ToString() : "");
                    SetCellValue(xlWorksheet, idxRow, idxCol++, x.Work.Iswc);
                    SetCellValue(xlWorksheet, idxRow, idxCol++, x.LineNr.ToString());
                    SetCellValue(xlWorksheet, idxRow, idxCol++, x.Name);
                    SetCellValue(xlWorksheet, idxRow, idxCol++, x.Performer);
                });
*/
                var cells = xlWorksheet.Cells;
                cells.NumberFormat = "@";
                cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                cells.Borders.Weight = XlBorderWeight.xlThin;

                var row = (Excel.Range)xlWorksheet.Rows[1];
                row.Font.Bold = true;
                row.Borders.Weight = XlBorderWeight.xlMedium;

                var col = (Excel.Range)xlWorksheet.Columns[1];
                col.ColumnWidth = 20;
                col.Locked = false;
                col = (Excel.Range)xlWorksheet.Columns[2];
                col.ColumnWidth = 20;
                col.Locked = false;
                col = (Excel.Range)xlWorksheet.Columns[3];
                col.ColumnWidth = 20;
                col.Locked = false;
                col = (Excel.Range)xlWorksheet.Columns[4];
                col.ColumnWidth = 8;
                col = (Excel.Range)xlWorksheet.Columns[5];
                col.ColumnWidth = 60;
                col = (Excel.Range)xlWorksheet.Columns[6];
                col.ColumnWidth = 60;

                xlWorksheet.Application.ActiveWindow.SplitRow = 1;
                xlWorksheet.Application.ActiveWindow.FreezePanes = true;

                xlWorksheet.Protect("111111", true);

            });


        }
    
        public void ImportSearchFile(Report report)
        {
            try
            {
                IsInProgress = true;
                Progress = 0;
                ErrorText = "";
                var data = new List<ImportData>();
                Helpers.ReadExcelFile( Path.Combine(report.FilePath, report.SearchFileName), xlWorksheet => {
                    Excel.Range xlRange = xlWorksheet.UsedRange;
                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;

                    ProgressMax = rowCount * 2 + 1;

                    var fromCell = (Excel.Range)xlWorksheet.Cells[1, 1];
                    var toCell = (Excel.Range)xlWorksheet.Cells[rowCount, 4];
                    var values = xlWorksheet.get_Range(fromCell, toCell).Value2;

                    for(var rowIdx = 2; rowIdx <= rowCount; rowIdx++)
                    {
                        Progress++;
                        var objId = Convert.ToInt32(values[rowIdx, 1]);
                        var wic = Convert.ToInt32(values[rowIdx, 2]);
                        var iswc = values[rowIdx, 3];
                        var lineNr =Convert.ToInt32(values[rowIdx, 4]);

                        var importData = new ImportData();
                        importData.LineNr = lineNr;
                        importData.ObjId = objId;
                        importData.Wic = wic;
                        
                        importData.Iswc = iswc == null ? "" : iswc;
                        importData.Iswc = importData.Iswc.Replace("-", "");
                        importData.Iswc = importData.Iswc.Replace(".", "");

                        data.Add(importData);
                    }
                });

                Helpers.RunSql(cmd =>
                {
                    cmd.CommandText = @"
                        delete from SearchFileImportBuf where ReportId = @ReportId
                    ";
                    cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ReportId" , report.Id);
                    cmd.ExecuteNonQuery();

                    var bu = new BulkUploadToSql();
                    bu.TableName = "SearchFileImportBuf";
                    bu.conn = cmd.Connection;
                    bu.Init();

                    data.ForEach(x =>
                    {
                        var data = new List<object>();
                        data.Add(report.Id);
                        data.Add(x.ObjId);
                        data.Add(x.Wic);
                        data.Add(x.Iswc);
                        data.Add(x.LineNr);
                        bu.AddData(data);
                        Progress++;
                    });

                    bu.Flush();
                });

                Helpers.RunSql(cmd =>
                {
                    cmd.CommandText = "spImportReport";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReportId" , report.Id);
                    cmd.ExecuteNonQuery();
                });

                IsInProgress = false;
            }
            catch(Exception ex)
            {
                IsInProgress = false;
                Progress = 0;
                ProgressMax = 0;
                ErrorText = ex.Message;
            }
        }

        private static decimal GetShareFromPercentString(string source)
        {
            decimal retVal;
            source = source.Replace(".", Configuration.DecimalSep);
            if(!decimal.TryParse(source, out retVal))
            {
                retVal = 0;
            }
            return retVal / 100;
        }

        public static void CreateDistributionFile(Report report)
        {
            const int COL_COUNT = 28;

            const int COL_RIGHTHOLDER_SHARE = 15;
            const int COL_RIGHTHOLDER_SHARE_TOPAY = 16;

            const int ROW_FISRT_DATA = 3;

            var data = new List<DistributionData>();
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = "spSelectDistribution";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReportId", report.Id);
                using(var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        var distributionData = new DistributionData();
                        var idx = 0;
                        distributionData.ReportId = r.GetString(idx++);
                        distributionData.LineNr = r.GetString(idx++);
                        distributionData.AuthorSeqNr = r.GetString(idx++);
                        distributionData.WorkCode = r.GetString(idx++);
                        distributionData.Iswc = r.GetString(idx++);
                        distributionData.TotalShare = r.IsDBNull(idx) ? null : Convert.ToDouble(r.GetDecimal(idx)); idx++;
                        distributionData.TotalShareToPay = r.IsDBNull(idx) ? null : Convert.ToDouble(r.GetDecimal(idx)); idx++;


                        distributionData.ReportLineName = r.GetString(idx++);
                        distributionData.ReportLinePerformer = r.GetString(idx++);
                        distributionData.ReportLineMusicAuthor = r.GetString(idx++);
                        distributionData.ReportLineTextAuthor = r.GetString(idx++);
                        distributionData.ReportLineDuration = r.GetString(idx++);
                        distributionData.ReportLineCountUses = r.GetString(idx++);
                        distributionData.ReportLineTotalDuration = r.GetString(idx++);

                        distributionData.ToBeFilledDurationInSec = r.GetString(idx++);
                        distributionData.ToBeFilledWorkRoyalty = r.GetString(idx++);

                        distributionData.FoundRhCustId = r.GetString(idx++);
                        distributionData.FoundRhIpBaseNr = r.GetString(idx++);
                        distributionData.FoundRhIpNameNr = r.GetString(idx++);
                        distributionData.FoundRhName = r.GetString(idx++);

                        distributionData.FoundRhPerShare = r.IsDBNull(idx) ? null : Convert.ToDouble(r.GetDecimal(idx)); idx++;
                        distributionData.FoundRhPerShareToPay = r.IsDBNull(idx) ? null : Convert.ToDouble(r.GetDecimal(idx)); idx++;
                        distributionData.FoundRhPerSocToPayCde = r.GetString(idx++);
                        distributionData.FoundRhPerSocToPayName = r.GetString(idx++);

                        distributionData.FoundRhMecShare = r.IsDBNull(idx) ? null : Convert.ToDouble(r.GetDecimal(idx)); idx++;
                        distributionData.FoundRhMecShareToPay = r.IsDBNull(idx) ? null : Convert.ToDouble(r.GetDecimal(idx)); idx++;
                        distributionData.FoundRhMecSocToPayCde = r.GetString(idx++);
                        distributionData.FoundRhMecSocToPayName = r.GetString(idx++);

                        distributionData.FoundRhAgreementNr = r.GetString(idx++);
                        distributionData.FoundRhAgreementStatus = r.GetString(idx++);

                        distributionData.SubPublisher = r.GetString(idx++);

                        data.Add(distributionData);
                    }
                }
            });

            data = data.OrderBy(x => int.Parse(x.LineNr)).ThenBy(x => int.Parse(x.AuthorSeqNr)).ToList();

            var outputFileFullName = Path.Combine(report.FilePath,  $"Distribution_{report.FileName}");

            Helpers.UpdateExcelFile(Configuration.TemplateFileFullName, outputFileFullName, xlWorksheet => {

                var dataArray = new object[data.Count, COL_COUNT];

                var row = 0;
                data.ForEach(x =>
                {
                    var col = 0;
                    dataArray[row, col++] = x.WorkCode;
                    dataArray[row, col++] = x.Iswc;
                    dataArray[row, col++] = x.TotalShare;
                    dataArray[row, col++] = x.TotalShareToPay;
                    dataArray[row, col++] = x.AuthorSeqNr;
                    dataArray[row, col++] = x.ReportLineName;
                    dataArray[row, col++] = x.ReportLinePerformer;
                    dataArray[row, col++] = x.ReportLineMusicAuthor;
                    dataArray[row, col++] = x.ReportLineTextAuthor;
                    dataArray[row, col++] = x.ReportLineDuration;
                    dataArray[row, col++] = x.ReportLineCountUses;
                    dataArray[row, col++] = x.ReportLineTotalDuration;
                    dataArray[row, col++] = "";
                    dataArray[row, col++] = "";
                    dataArray[row, col++] = x.FoundRhPerShare / 100;
                    dataArray[row, col++] = x.FoundRhPerShareToPay / 100;
                    dataArray[row, col++] = "";
                    dataArray[row, col++] = x.FoundRhPerSocToPayName;
                    dataArray[row, col++] = x.FoundRhName;
                    dataArray[row, col++] = x.FoundRhAgreementNr;
                    dataArray[row, col++] = x.FoundRhIpBaseNr;
                    dataArray[row, col++] = "";
                    dataArray[row, col++] = "";
                    dataArray[row, col++] = "";
                    dataArray[row, col++] = "";
                    dataArray[row, col++] = "";
                    dataArray[row, col++] = x.FoundRhAgreementStatus;
                    dataArray[row, col++] = x.SubPublisher;


                    row++;
                });

                var c1 = (Excel.Range)xlWorksheet.Cells[3, 1];
                var c2 = (Excel.Range)xlWorksheet.Cells[3 + data.Count - 1, COL_COUNT];
                var range = xlWorksheet.get_Range(c1, c2);
                range.Value2 = dataArray;

                dataArray = new object[data.Count, 1];
                row = 0;
                data.ForEach(x =>
                {
                    dataArray[row, 0] = $"=K{row + 3}*$F$1";
                    row++;
                });


                c1 = (Excel.Range)xlWorksheet.Cells[3, 14];
                c2 = (Excel.Range)xlWorksheet.Cells[3 + data.Count - 1, 14];
                range = xlWorksheet.get_Range(c1, c2);
                range.Formula = dataArray;

                dataArray = new object[data.Count, 1];
                row = 0;
                data.ForEach(x =>
                {
                    dataArray[row, 0] = $"=N{row + 3}*P{row + 3}";
                    row++;
                });


                c1 = (Excel.Range)xlWorksheet.Cells[3, 17];
                c2 = (Excel.Range)xlWorksheet.Cells[3 + data.Count - 1, 17];
                range = xlWorksheet.get_Range(c1, c2);
                range.Formula = dataArray;

                c1 = (Excel.Range)xlWorksheet.Cells[ROW_FISRT_DATA, COL_RIGHTHOLDER_SHARE];
                c2 = (Excel.Range)xlWorksheet.Cells[ROW_FISRT_DATA + data.Count - 1, COL_RIGHTHOLDER_SHARE_TOPAY];
                range = xlWorksheet.get_Range(c1, c2);
                range.NumberFormat = $"0.00%";

            });

        }

        public static void BallancePercents(Report report)
        {
            Helpers.UpdateExcelFile(Path.Combine(report.FilePath, report.DistributionFileName), xlWorksheet => {
                const int COL_CODE = 1;
                const int COL_SHARE_TOTAL = 4;
                const int COL_SHARE_TOPAY = 16;
                const int ROW_START = 3;

                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                var fromCell = (Excel.Range)xlWorksheet.Cells[ROW_START, COL_CODE];
                var toCell = (Excel.Range)xlWorksheet.Cells[rowCount, COL_CODE];
                var workCodes = xlWorksheet.get_Range(fromCell, toCell).Value2;

                fromCell = (Excel.Range)xlWorksheet.Cells[ROW_START, COL_SHARE_TOPAY];
                toCell = (Excel.Range)xlWorksheet.Cells[rowCount, COL_SHARE_TOPAY];
                var sharesToPay = xlWorksheet.get_Range(fromCell, toCell).Value2;

                List<List<double?>> inputShareSets = new List<List<double?>>();
                List<double?> inputShares = null;
                string workCode = "";
                for(var idx = 1; idx <= rowCount - ROW_START + 1; idx++)
                {
                    var curWorkCode = workCodes[idx, 1];
                    var curShare = sharesToPay[idx, 1];
                    if(workCode != curWorkCode)
                    {
                        if(inputShares != null)
                        {
                            inputShareSets.Add(inputShares);
                        }
                        inputShares = new List<double?>();
                        inputShares.Add(curShare);
                        workCode = curWorkCode;
                    }
                    else
                    {
                        inputShares.Add(curShare);
                    }
                }

                if(inputShares != null)
                {
                    inputShareSets.Add(inputShares);
                }

                var dataArrayShares = new object[rowCount - ROW_START + 1, 1];
                var dataArraySharesTotal = new object[rowCount - ROW_START + 1, 1];
                var arrRowIdx = 0;
                inputShareSets.ForEach(x =>
                {
                    List<double?> sharesRes;
                    var sum = Helpers.BalanceShares(x, out sharesRes);
                    sharesRes.ForEach(y =>
                    {
                        dataArrayShares[arrRowIdx, 0] = y;
                        dataArraySharesTotal[arrRowIdx, 0] = sum;
                        arrRowIdx++;
                    });
                });

                var c1 = (Excel.Range)xlWorksheet.Cells[ROW_START, COL_SHARE_TOTAL];
                var c2 = (Excel.Range)xlWorksheet.Cells[rowCount, COL_SHARE_TOTAL];
                var range = xlWorksheet.get_Range(c1, c2);
                range.Value2 = dataArraySharesTotal;

                c1 = (Excel.Range)xlWorksheet.Cells[ROW_START, COL_SHARE_TOPAY];
                c2 = (Excel.Range)xlWorksheet.Cells[rowCount, COL_SHARE_TOPAY];
                range = xlWorksheet.get_Range(c1, c2);
                range.Value2 = dataArrayShares;

            });
        }
    }
}
