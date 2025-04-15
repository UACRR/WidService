using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Range = Microsoft.Office.Interop.Excel.Range;

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
            Application xlApp = new Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open(fileFullName);
            _Worksheet xlWorksheet = (_Worksheet)xlWorkbook.Sheets[1];
            Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            if(colCount < 8)
            {
                CloseExcelSession(xlApp, xlWorkbook, xlWorksheet, xlRange);
                throw new Exception("Wrong file");
            }

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 2; i <= rowCount; i++)
            {

                var cell = (Range)xlWorksheet.Cells[i, 1];
                var seqNrStr = cell.Text;
                int seqNr;
                if (!int.TryParse((string)seqNrStr, out seqNr))
                {
                    break;
                }

                cell = (Range)xlWorksheet.Cells[i, 2];
                string name = Convert.ToString(cell.Text == null ? "" : cell.Text);
                name = name.Trim().Replace('\t', ' ');

                cell = (Range)xlWorksheet.Cells[i, 3];
                string performer = Convert.ToString(cell.Text == null ? "" : cell.Text);
                performer = performer.Trim().Replace('\t', ' ');

                cell = (Range)xlWorksheet.Cells[i, 4];
                string musicAuthor = Convert.ToString(cell.Text == null ? "" : cell.Text);
                musicAuthor = musicAuthor.Trim().Replace('\t', ' ');

                cell = (Range)xlWorksheet.Cells[i, 5];
                string textAuthor = Convert.ToString(cell.Text == null ? "" : cell.Text);
                textAuthor = textAuthor.Trim().Replace('\t', ' ');

                cell = (Range)xlWorksheet.Cells[i, 6];
                string duratrion = Convert.ToString(cell.Text == null ? "" : cell.Text);
                duratrion = duratrion.Trim().Replace('\t', ' ');

                cell = (Range)xlWorksheet.Cells[i, 7];
                string countUses = Convert.ToString(cell.Text == null ? "" : cell.Text);
                countUses = countUses.Trim().Replace('\t', ' ');

                cell = (Range)xlWorksheet.Cells[i, 8];
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

            CloseExcelSession(xlApp, xlWorkbook, xlWorksheet, xlRange);
        }

        private void CloseExcelSession(Application xlApp,
            Workbook xlWorkbook,
            _Worksheet xlWorksheet,
            Range xlRange)
        {
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
                cmd.CommandText = "spInsertReportLine";
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

        private static string GetReportFilePostfix(ReportParameters reportParameters)
        {
            var postfix = "";
            var path = FormatWorkFilesPath(reportParameters);
            
            if (Directory.Exists(path))
            {
                var idx = 0;
                while(true)
                {
                    var fileName = FormatSourceFileCopyName(reportParameters, postfix);
                    if(!File.Exists(Path.Combine(path, fileName)))
                    {
                        break;
                    }
                    idx++;
                    postfix = $"({idx})";
                }
            }
            return postfix;
        }

        private bool CheckReportExists(string fileName)        
        {
            var exists = false;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select min(Id) 
                    from Reports 
                    where FileName = @FileName
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@FileName", fileName);
                var reportId = cmd.ExecuteScalar();

                if (reportId != DBNull.Value)
                {
                    exists = true;
                }
            });
            return exists;
        }

        public int LoadReport(
            string fileFullName,
            ReportParameters reportParameters
        )
        {
            var reportId = 0;

            var fileName = Path.GetFileName(fileFullName);
            var filePath = Path.GetDirectoryName(fileFullName);
            if(CheckReportExists(fileName))
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

            var postfix = GetReportFilePostfix(reportParameters);

            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandText = @"
                    insert Reports (
                          RadioStationId 
                        , StartYear      
                        , StartMonth     
                        , EndYear        
                        , EndMonth       
                        , FileName
                        , FilePath
                        , WorkFilesPath
                        , SourceFileCopyName
                        , SearchFileName
                        , DistributionFileName
                        , CheckFileName
                        , CreatedAt
                        , UpdatedAt
                    )
                    values (
                          @RadioStationId 
                        , @StartYear      
                        , @StartMonth     
                        , @EndYear        
                        , @EndMonth       
                        , @fileName
                        , @filePath
                        , @WorkFilesPath
                        , @SourceFileCopyName
                        , @SearchFileName
                        , @DistributionFileName
                        , @CheckFileName
                        , getdate()
                        , getdate()
                    )
                    select scope_identity()";
                
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@RadioStationId"       , reportParameters.RadioStationId);
                cmd.Parameters.AddWithValue("@StartYear"            , reportParameters.StartYear);
                cmd.Parameters.AddWithValue("@StartMonth"           , reportParameters.StartMonth);
                cmd.Parameters.AddWithValue("@EndYear"              , reportParameters.EndYear);
                cmd.Parameters.AddWithValue("@EndMonth"             , reportParameters.EndMonth);
                cmd.Parameters.AddWithValue("@fileName"             , fileName);
                cmd.Parameters.AddWithValue("@filePath"             , filePath);
                cmd.Parameters.AddWithValue("@WorkFilesPath"        , FormatWorkFilesPath(reportParameters));
                cmd.Parameters.AddWithValue("@SourceFileCopyName"   , FormatSourceFileCopyName(reportParameters, postfix));
                cmd.Parameters.AddWithValue("@SearchFileName"       , "");
                cmd.Parameters.AddWithValue("@DistributionFileName" , "");
                cmd.Parameters.AddWithValue("@CheckFileName"        , "");

                reportId = Convert.ToInt32(cmd.ExecuteScalar());

                InsertReportLinesIntoDb(cmd, Convert.ToInt32(reportId));

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

                CreateFilesSpace(reportParameters, filePath, fileName, postfix);

            });

            return reportId;
        }

        private void CreateFilesSpace(ReportParameters reportParameters, string sourceFilePath, string sourceFileName, string postfix)
        {
            var targetFileFullName = Path.Combine(FormatWorkFilesPath(reportParameters), FormatSourceFileCopyName(reportParameters, postfix));
            var sourceFileFullName = Path.Combine(sourceFilePath, sourceFileName);

            var workFilesRoot = Path.GetDirectoryName(targetFileFullName);
            Directory.CreateDirectory(workFilesRoot);

            File.Copy(sourceFileFullName, targetFileFullName, true);
        }

        public static void MoveFilesSpace(Report report, ReportParameters newReportParameters)
        {
            Logger.WriteLine("> MoveFilesSpace");
            var oldReportParameters = new ReportParameters
            {
                RadioStationId      = report.RadioStationId     == null ? 0  : (int)report.RadioStationId,
                RadioStationName    = report.RadioStationName   == null ? "" : report.RadioStationName,
                StartYear           = report.StartYear          == null ? 0  : (int)report.StartYear,
                StartMonth          = report.StartMonth         == null ? 0  : (int)report.StartMonth,
                EndYear             = report.EndYear            == null ? 0  : (int)report.EndYear,
                EndMonth            = report.EndMonth           == null ? 0  : (int)report.EndMonth,
            };

            var isFromWorkDir = oldReportParameters.RadioStationId != 0;

            // Create work directory
            var workFilesRoot = FormatWorkFilesPath(newReportParameters);
            Directory.CreateDirectory(workFilesRoot);
            Logger.WriteLine($"    Створено робочу папку {workFilesRoot}");

            // Old files root dir
            var oldFilesRootDir = isFromWorkDir ? FormatWorkFilesPath(oldReportParameters) : report.FilePath;
            Logger.WriteLine($"   Папка звідки переміщаються файли {oldFilesRootDir}");

            // Source Report File
            var fromSourceFileCopyFullName = "";
            if(isFromWorkDir && !string.IsNullOrEmpty(report.SourceFileCopyName))
            {
                fromSourceFileCopyFullName = Path.Combine(oldFilesRootDir, report.SourceFileCopyName);
            }
            else if(!isFromWorkDir && !string.IsNullOrEmpty(report.FileName))
            {
                fromSourceFileCopyFullName = Path.Combine(oldFilesRootDir, report.FileName);
            }
            if(!File.Exists(fromSourceFileCopyFullName))
            {
                fromSourceFileCopyFullName = "";
            }
            Logger.WriteLine($"   Файл звіту {fromSourceFileCopyFullName}");

            // Search File
            var fromSearchFileFullName = Path.Combine(oldFilesRootDir, report.SearchFileName);
            if (!File.Exists(fromSearchFileFullName))
            {
                fromSearchFileFullName = "";
            }
            Logger.WriteLine($"   Файл пошуку {fromSearchFileFullName}");

            // Distribution File
            var fromDistributionFileFullName = Path.Combine(oldFilesRootDir, report.DistributionFileName);
            if (!File.Exists(fromDistributionFileFullName))
            {
                fromDistributionFileFullName = "";
            }
            Logger.WriteLine($"   Файл розподілу {fromDistributionFileFullName}");

            // Check File
            var fromCheckFileFullName = Path.Combine(oldFilesRootDir, report.CheckFileName);
            if (!File.Exists(fromCheckFileFullName))
            {
                fromCheckFileFullName = "";
            }
            Logger.WriteLine($"   Файл перевірки {fromCheckFileFullName}");

            var postfix = GetReportFilePostfix(newReportParameters);

            // Target Files
            var toSourceFileCopyName    = fromSourceFileCopyFullName == "" ? "" : FormatSourceFileCopyName(newReportParameters, postfix);
            var toSearchFileName        = fromSearchFileFullName == "" ? "" : FormatSearchFileName(newReportParameters, postfix);
            var toDistributionFileName  = fromDistributionFileFullName == "" ? "" : FormatDistributionFileName(newReportParameters, postfix);
            var toCheckFileName         = fromCheckFileFullName == "" ? "" : FormatCheckFileName(newReportParameters, postfix);
  
            // Copy report file
            if(fromSourceFileCopyFullName != "")
            {
                var toFileFullName = Path.Combine(workFilesRoot, toSourceFileCopyName);
                File.Copy(fromSourceFileCopyFullName, toFileFullName, true);
                if(isFromWorkDir)
                {
                    File.Delete(fromSourceFileCopyFullName);
                }
                Logger.WriteLine($"   Переміщено файл {fromSourceFileCopyFullName} => {toFileFullName}");
            }
 
            // Copy search file
            if (fromSearchFileFullName != "")
            {
                var toFileFullName = Path.Combine(workFilesRoot, toSearchFileName);
                File.Copy(fromSearchFileFullName, toFileFullName, true);
                if(isFromWorkDir)
                {
                    File.Delete(fromSearchFileFullName);
                }
                Logger.WriteLine($"   Переміщено файл {fromSearchFileFullName} => {toFileFullName}");
            }
 
            // Copy distribution file
            if (fromDistributionFileFullName != "")
            {
                var toFileFullName = Path.Combine(workFilesRoot, toDistributionFileName);
                File.Copy(fromDistributionFileFullName, toFileFullName, true);
                if(isFromWorkDir)
                {
                    File.Delete(fromDistributionFileFullName);
                }
                Logger.WriteLine($"   Переміщено файл {fromDistributionFileFullName} => {toFileFullName}");
            }

            // Copy check file
            if (fromCheckFileFullName != "")
            {
                var toFileFullName = Path.Combine(workFilesRoot, toCheckFileName);
                File.Copy(fromCheckFileFullName, toFileFullName, true);
                if(isFromWorkDir)
                {
                    File.Delete(fromCheckFileFullName);
                }
                Logger.WriteLine($"   Переміщено файл {fromCheckFileFullName} => {toFileFullName}");
            }

            // Delete old directory - do not delete, files are deleted, may be reused later
            /*
             * var oldReportFilesPath = report.WorkFilesPath;
            if (isFromWorkDir)
            {
                Directory.Delete(oldReportFilesPath, true);
                Logger.WriteLine($"    Видалено папку {oldReportFilesPath}");
            }
            */

            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    update Reports
                    set 
                          RadioStationId        = @RadioStationId
                        , StartYear             = @StartYear
                        , StartMonth            = @StartMonth
                        , EndYear               = @EndYear
                        , EndMonth              = @EndMonth
                        , WorkFilesPath         = @WorkFilesPath       
                        , SourceFileCopyName    = @SourceFileCopyName  
                        , SearchFileName        = @SearchFileName      
                        , DistributionFileName  = @DistributionFileName
                        , CheckFileName         = @CheckFileName
                    where Id = @ReportId
                ";

                cmd.Parameters.AddWithValue("@ReportId"             , report.Id);
                cmd.Parameters.AddWithValue("@RadioStationId"       , newReportParameters.RadioStationId);
                cmd.Parameters.AddWithValue("@StartYear"            , newReportParameters.StartYear     );
                cmd.Parameters.AddWithValue("@StartMonth"           , newReportParameters.StartMonth    );
                cmd.Parameters.AddWithValue("@EndYear"              , newReportParameters.EndYear       );
                cmd.Parameters.AddWithValue("@EndMonth"             , newReportParameters.EndMonth      );
                cmd.Parameters.AddWithValue("@WorkFilesPath"        , workFilesRoot                     );
                cmd.Parameters.AddWithValue("@SourceFileCopyName"   , toSourceFileCopyName              );
                cmd.Parameters.AddWithValue("@SearchFileName"       , toSearchFileName                  );
                cmd.Parameters.AddWithValue("@DistributionFileName" , toDistributionFileName            );
                cmd.Parameters.AddWithValue("@CheckFileName"        , toCheckFileName                   );

                cmd.ExecuteNonQuery();
            });

            report.RadioStationId       = newReportParameters.RadioStationId  ;
            report.RadioStationName     = newReportParameters.RadioStationName;
            report.StartYear            = newReportParameters.StartYear       ;
            report.StartMonth           = newReportParameters.StartMonth      ;
            report.EndYear              = newReportParameters.EndYear         ;
            report.EndMonth             = newReportParameters.EndMonth        ;
            report.WorkFilesPath        = workFilesRoot                       ;
            report.SourceFileCopyName   = toSourceFileCopyName                ;
            report.SearchFileName       = toSearchFileName                    ;
            report.DistributionFileName = toDistributionFileName              ;
            report.CheckFileName        = toDistributionFileName              ;
        }

        public static List<string> GetReportsList()
        {
            var retVal = new List<string>();

            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select Id, FileName
                    from Reports
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
                    filterText = " and exists (select null from MatchingWorks where WorkId = t2.Id)";
                    break;
                case WorksFilter.hasNoMatches:
                    filterText = " and not exists (select null from MatchingWorks where WorkId = t2.Id)";
                    break;
                case WorksFilter.hasStrongMatches:
                    filterText = " and exists (select null from MatchingWorks where WorkId = t2.Id and IsStrongMatch = 1)";
                    break;
                case WorksFilter.unprocessed:
                    filterText = " and IsProcessed is null";
                    break;
            }
            cmd.CommandText = $@"
                select 
	                  t2.Id
	                , t2.Name
	                , t2.Authors
	                , t2.Performers
	                , t2.NameT
	                , t2.AuthorsT
	                , t2.PerformersT
	                , t2.FoundIn
	                , t2.ObjId
                    , t2.Wic
	                , t2.Share
                from ReportLines t1
                    join Works t2 on t1.WorkId = t2.Id
                where t1.ReportId = @reportId {filterText}
                order by t1.LineNr
            ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reportId", _reportId);
            using var r = cmd.ExecuteReader();
            FillWorks(r);
        }

        public void LoadSingleReportWork(SqlCommand cmd, int reportWorkId)
        {
            cmd.CommandText = $@"
                select 
	                  t2.Id
	                , t2.Name
	                , t2.Authors
	                , t2.Performers
	                , t2.NameT
	                , t2.AuthorsT
	                , t2.PerformersT
	                , t2.FoundIn
	                , case 
		                when t2.FoundIn = 'M' then t2.ObjId
		                when t2.FoundIn = 'W' then t2.Wic
		                else null
		                end as FoundCde
	                , t2.Share
                from ReportLines t1
                    join Works t2 on t1.WorkId = t2.Id
                where t2.Id = @reportWorkId
            ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reportWorkId", reportWorkId);
            using var r = cmd.ExecuteReader();
            FillWorks(r);
        }

        private void FillWorks(SqlDataReader r)
        {
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
                reportWork.ObjId = r.IsDBNull(idx) ? (int?)null : r.GetInt32(idx);
                idx++;
                reportWork.Wic = r.IsDBNull(idx) ? (int?)null : r.GetInt32(idx);
                idx++;
                reportWork.Share = r.IsDBNull(idx) ? (decimal?)null : r.GetDecimal(idx);

                reportWork.MatchingWorks = new List<MatchingWork>();
                _works.Add(reportWork);
            }
        }

        public void LoadReportWorkForLine(SqlCommand cmd, int lineNr)
        {
            cmd.CommandText = $@"
                select
	                  t2.Id
	                , t2.Name
	                , t2.Authors
	                , t2.Performers
	                , t2.NameT
	                , t2.AuthorsT
	                , t2.PerformersT
	                , t2.FoundIn
	                , case 
		                when t2.FoundIn = 'M' then t2.ObjId
		                when t2.FoundIn = 'W' then t2.Wic
		                else null
		                end as FoundCde
	                , t2.Share
                from ReportLines t1
                    join Works t2 on t1.WorkId = t2.Id
                where t1.ReportId = @reportId 
                    and t1.LineNr = @lineNr
            ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reportId", _reportId);
            cmd.Parameters.AddWithValue("@lineNr", lineNr);
            using var r = cmd.ExecuteReader();
            FillWorks(r);
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
                from ReportLines t0
                    join Works t1 on t0.WorkId = t1.Id
                    join MatchingWorks t2 on t1.Id = t2.WorkId
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
                    curReportWork = _works.First(x => x.Id == newReportWorkId);
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
                from Works t1
                    join MatchingWorks t2 on t1.Id = t2.WorkId
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

        private void ClearMatchingWorks(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "truncate table MatchingWorks";
            cmd.ExecuteNonQuery();
        }

        private void TranslitReportWorks(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"
                update Works
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
                insert MatchingWorks (
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
                from ReportLines t0
                    join Works t1 on t0.WorkId = t1.Id
                    {joinText}
                where t0.ReportId = @reportId
                    and t1.{sourceColName} <> ''
                    and t1.IsProcessed is null
                    and t2.ObjId not in (select FoundId from MatchingWorks tt where tt.WorkId = t1.Id)
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
                insert MatchingWorks (
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
                from ReportLines t0
                    join Works t1 on t0.WorkId = t1.Id
                    {joinText}
                where t0.ReportId = @reportId
                    and t1.IsProcessed is null
                    and t1.{sourceColName} <> ''
                    and t2.ObjId not in (select FoundId from MatchingWorks tt where tt.WorkId = t1.Id)
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
            cmd.CommandText = "spSearchMatchingWorksInWid";
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
                from ReportLines t0
                    join MatchingWorks t1 on t0.WorkId = t1.Id
                    join Works t2 on t1.WorkId = t2.Id
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
                from ReportLines t0
                    join MatchingWorks t1 on t0.WorkId = t1.Id
                    join Works t2 on t1.WorkId = t2.Id
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
                cmd.CommandText = "update Works set IsProcessed = 1 where Id = @id";
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
                var word = words[idx].Trim().ToUpper();
                if (word.Length < 3)
                {
                    continue;
                }

                var foundAuthorsT = Translit.FromUkr(foundWork.Authors).ToUpper();
                var foundPerformersT = Translit.FromUkr(foundWork.Performers.ToUpper());

                if (foundWork.Authors.ToUpper().Contains(word) || foundWork.Performers.ToUpper().Contains(word)
                     || foundAuthorsT.ToUpper().Contains(word) || foundPerformersT.ToUpper().Contains(word))
                {
                    foundWork.IsMatchingAuthorPerformer = true;
                    break;
                }
            }

            if(foundWork.IsMatchingAuthorPerformer)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update MatchingWorks set IsStrongMatch = 1 where Id = @id";
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
                    update Works
                    set
                          FoundIn = @foundIn
                        , ObjId = @objId
                        , Wic = @wic
                        , Share = null
                    where Id = @id
                ";
            _works.Where(x => x.HasMatchingWorks).ToList().ForEach(x =>
            {
                var matchingWork = x.MatchingWorks.First(y => y.IsMatchingAuthorPerformer);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", x.Id);
                cmd.Parameters.AddWithValue("@foundIn", matchingWork.FoundInDb);
                cmd.Parameters.AddWithValue("@objId", matchingWork.FoundInDb == "M" ? matchingWork.FoundId : DBNull.Value);
                cmd.Parameters.AddWithValue("@wic",  matchingWork.FoundInDb == "W" ? matchingWork.FoundId : DBNull.Value);
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

        public void CalcLineShares(SqlCommand cmd, int lineNr)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spCreateReportAuthors";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reportId", _reportId);
            cmd.Parameters.AddWithValue("@lineNr", lineNr);
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
                ClearMatchingWorks(cmd);
            });
        }

        public void RecalcShares()
        {
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandTimeout = 0;
                //CleanFoundAuthors(cmd);
                //CleanFoundPerformers(cmd);
                //LoadReportWorks(cmd, WorksFilter.all);
                //LoadMatchingWorks(cmd, false);
                //FindAuthorPerformerMatches(cmd);
                //ApplyMatches(cmd);
                CalcShares(cmd);
                //InsertIswcs(cmd);
            });
        }

        public void RecalcShares(int lineNr)
        {
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandTimeout = 0;
                //CleanFoundAuthors(cmd);
                //CleanFoundPerformers(cmd);
                //LoadSingleReportWork(cmd, workId);
                //LoadMatchingWorks(cmd, false);
                //FindAuthorPerformerMatches(cmd);
                //ApplyMatches(cmd);
                CalcLineShares(cmd, lineNr);
                //InsertIswcs(cmd);
            });
        }

        private static void SetCellValue(_Worksheet xlWorkSheet, int row, int col, string value)
        {
            Range cell = (Range)xlWorkSheet.Cells[row, col];
            cell.Value = value;
        }

        private static void SetCellFormula(_Worksheet xlWorkSheet, int row, int col, string value)
        {
            Range cell = (Range)xlWorkSheet.Cells[row, col];
            cell.Formula = value;
        }

        public static void CreateSearchFile(Report report, List<ReportLine> reportLines)
        {
            var reportParameters = report.GetReportParameters();
            report.SearchFileName = FormatSearchFileName(report);
            var fileFullName = Path.Combine(report.WorkFilesPath, report.SearchFileName);
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
                    dataArray[idxRow, idxCol++] = x.Work.FoundIn == null ? "" : x.Work.FoundIn == "M" ? x.Work.ObjId.ToString() : "";
                    dataArray[idxRow, idxCol++] = x.Work.FoundIn == null ? "" : x.Work.FoundIn == "W" ? x.Work.Wic.ToString() : "";
                    dataArray[idxRow, idxCol++] = x.Work.Iswc;
                    dataArray[idxRow, idxCol++] = x.LineNr.ToString();
                    dataArray[idxRow, idxCol++] = x.Name;
                    dataArray[idxRow, idxCol++] = x.Performer;
                });

                var c1 = (Range)xlWorksheet.Cells[1, 1];
                var c2 = (Range)xlWorksheet.Cells[1 + reportLines.Count, 6];
                var range = xlWorksheet.get_Range(c1, c2);
                range.Value2 = dataArray;

                var cells = xlWorksheet.Cells;
                cells.NumberFormat = "@";
                cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                cells.Borders.Weight = XlBorderWeight.xlThin;

                var row = (Range)xlWorksheet.Rows[1];
                row.Font.Bold = true;
                row.Borders.Weight = XlBorderWeight.xlMedium;

                var col = (Range)xlWorksheet.Columns[1];
                col.ColumnWidth = 20;
                col.Locked = false;
                col = (Range)xlWorksheet.Columns[2];
                col.ColumnWidth = 20;
                col.Locked = false;
                col = (Range)xlWorksheet.Columns[3];
                col.ColumnWidth = 20;
                col.Locked = false;
                col = (Range)xlWorksheet.Columns[4];
                col.ColumnWidth = 8;
                col = (Range)xlWorksheet.Columns[5];
                col.ColumnWidth = 60;
                col = (Range)xlWorksheet.Columns[6];
                col.ColumnWidth = 60;

                xlWorksheet.Application.ActiveWindow.SplitRow = 1;
                xlWorksheet.Application.ActiveWindow.FreezePanes = true;

                xlWorksheet.Protect("111111", true);

            });


        }
    
        public static void CreateCheckFile(Report report, List<ReportLine> reportLines)
        {
            var cntCols = 10;
            var reportParameters = report.GetReportParameters();
            report.CheckFileName = FormatCheckFileName(report);
            var fileFullName = Path.Combine(report.WorkFilesPath, report.CheckFileName);
            Directory.CreateDirectory(report.WorkFilesPath);
            if(File.Exists(fileFullName))
            {
                File.Delete(fileFullName);
            }
            Helpers.CreateExcelFile( fileFullName, xlWorksheet => {
                xlWorksheet.Name = "Рядки звіту";

                var dataArray = new object[reportLines.Count + 1, cntCols];

                var idxRow = 0;
                var idxCol = 0;

                dataArray[idxRow, idxCol++] = "№ п/п";
                dataArray[idxRow, idxCol++] = "Назва публічно сповіщеного твору через мережу Інтернет";
                dataArray[idxRow, idxCol++] = "Виконавець  - П.І.Б. виконавця (співвиконавців) або назва колективу виконавців";
                dataArray[idxRow, idxCol++] = "Автор музики (П.І.Б.)";
                dataArray[idxRow, idxCol++] = "Автор тексту (П.І.Б.)";
                dataArray[idxRow, idxCol++] = "Тривалість звучання твору (год.:хвил.: сек.)";
                dataArray[idxRow, idxCol++] = "Кількість публічних сповіщень твору";
                dataArray[idxRow, idxCol++] = "Загальна Тривалість звучання твору";
                dataArray[idxRow, idxCol++] = "СЦЕПКА";
                dataArray[idxRow, idxCol++] = "% правовласності";

                Helpers.RunSqlT(cmd =>
                {
                    cmd.CommandText = @"
                        select 
	                          cast(t1.LineNr as varchar(10))
	                        , t1.Name
	                        , t1.Performer
	                        , ''
	                        , ''
	                        , concat('''', t1.Duration)
	                        , t1.CountUses
	                        , concat('''', t1.TotalDuration)
	                        , concat(t1.Name, t1.Performer)
	                        , case 
		                        when t2.FoundIn is null then '' 
		                        when t2.Share > 0 then '100'
		                        else '0'
	                          end
                        from ReportLines t1
	                        join Works t2 on t1.WorkId = t2.Id
                        where t1.ReportId = @reportId
                        order by t1.LineNr
                    ";
                    cmd.Parameters.AddWithValue("@reportId", report.Id);

                    using(var r = cmd.ExecuteReader())
                    {
                        idxRow++;
                        while (r.Read())
                        {
                            for(var idxCol = 0; idxCol < cntCols; idxCol++)
                            {
                                dataArray[idxRow, idxCol] = r.GetString(idxCol);
                                //try
                                //{
                                //dataArray[idxRow, idxCol] = r.GetString(idxCol);
                                //
                                //}
                                //catch(Exception ex)
                                //{
                                //    var e = ex.Message;
                                //}
                            }
                            idxRow++;
                        }
                    }
                });

                var c1 = (Range)xlWorksheet.Cells[1, 1];
                var c2 = (Range)xlWorksheet.Cells[1 + reportLines.Count, cntCols];
                var range = xlWorksheet.get_Range(c1, c2);
                range.Value2 = dataArray;

                var cells = xlWorksheet.Cells;
                cells.NumberFormat = "@";
                cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                cells.Borders.Weight = XlBorderWeight.xlThin;

                var row = (Range)xlWorksheet.Rows[1];
                row.Font.Bold = true;
                row.Borders.Weight = XlBorderWeight.xlMedium;

                var col = (Range)xlWorksheet.Columns[1];
                col.ColumnWidth = 20;
                col.Locked = false;
                col = (Range)xlWorksheet.Columns[2];
                col.ColumnWidth = 20;
                col.Locked = false;
                col = (Range)xlWorksheet.Columns[3];
                col.ColumnWidth = 20;
                col.Locked = false;
                col = (Range)xlWorksheet.Columns[4];
                col.ColumnWidth = 8;
                col = (Range)xlWorksheet.Columns[5];
                col.ColumnWidth = 20;
                col = (Range)xlWorksheet.Columns[6];
                col.ColumnWidth = 20;
                col = (Range)xlWorksheet.Columns[7];
                col.ColumnWidth = 20;
                col = (Range)xlWorksheet.Columns[8];
                col.ColumnWidth = 20;
                col = (Range)xlWorksheet.Columns[9];
                col.ColumnWidth = 20;
                col = (Range)xlWorksheet.Columns[10];
                col.ColumnWidth = 20;

                xlWorksheet.Application.ActiveWindow.SplitRow = 1;
                xlWorksheet.Application.ActiveWindow.FreezePanes = true;


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
                Helpers.ReadExcelFile( Path.Combine(report.WorkFilesPath, report.SearchFileName), xlWorksheet => {
                    Range xlRange = xlWorksheet.UsedRange;
                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;

                    ProgressMax = rowCount * 2 + 1;

                    var fromCell = (Range)xlWorksheet.Cells[1, 1];
                    var toCell = (Range)xlWorksheet.Cells[rowCount, 4];
                    var values = (object[,])xlWorksheet.get_Range(fromCell, toCell).Value2;

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
                        
                        importData.Iswc = (string)(iswc == null ? "" : iswc);
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

            var reportParameters = report.GetReportParameters();
            Directory.CreateDirectory(report.WorkFilesPath);
            report.DistributionFileName = FormatDistributionFileName(report);

            var outputFileFullName = Path.Combine(report.WorkFilesPath, report.DistributionFileName);

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

                var c1 = (Range)xlWorksheet.Cells[3, 1];
                var c2 = (Range)xlWorksheet.Cells[3 + data.Count - 1, COL_COUNT];
                var range = xlWorksheet.get_Range(c1, c2);
                range.Value2 = dataArray;

                dataArray = new object[data.Count, 1];
                row = 0;
                data.ForEach(x =>
                {
                    dataArray[row, 0] = $"=K{row + 3}*$F$1";
                    row++;
                });


                c1 = (Range)xlWorksheet.Cells[3, 14];
                c2 = (Range)xlWorksheet.Cells[3 + data.Count - 1, 14];
                range = xlWorksheet.get_Range(c1, c2);
                range.Formula = dataArray;

                dataArray = new object[data.Count, 1];
                row = 0;
                data.ForEach(x =>
                {
                    dataArray[row, 0] = $"=N{row + 3}*P{row + 3}";
                    row++;
                });


                c1 = (Range)xlWorksheet.Cells[3, 17];
                c2 = (Range)xlWorksheet.Cells[3 + data.Count - 1, 17];
                range = xlWorksheet.get_Range(c1, c2);
                range.Formula = dataArray;

                c1 = (Range)xlWorksheet.Cells[ROW_FISRT_DATA, COL_RIGHTHOLDER_SHARE];
                c2 = (Range)xlWorksheet.Cells[ROW_FISRT_DATA + data.Count - 1, COL_RIGHTHOLDER_SHARE_TOPAY];
                range = xlWorksheet.get_Range(c1, c2);
                range.NumberFormat = $"0.00%";

            });

        }

        public static void BallancePercents(Report report)
        {
            Helpers.UpdateExcelFile(Path.Combine(report.WorkFilesPath, report.DistributionFileName), xlWorksheet => {
                const int COL_CODE = 1;
                const int COL_SHARE_TOTAL = 4;
                const int COL_SHARE_TOPAY = 16;
                const int ROW_START = 3;

                Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                var fromCell = (Range)xlWorksheet.Cells[ROW_START, COL_CODE];
                var toCell = (Range)xlWorksheet.Cells[rowCount, COL_CODE];
                object[,] workCodes = (object[,])xlWorksheet.get_Range(fromCell, toCell).Value2;

                fromCell = (Range)xlWorksheet.Cells[ROW_START, COL_SHARE_TOPAY];
                toCell = (Range)xlWorksheet.Cells[rowCount, COL_SHARE_TOPAY];
                object[,] sharesToPay = (object[,])xlWorksheet.get_Range(fromCell, toCell).Value2;

                List<List<double?>> inputShareSets = new List<List<double?>>();
                List<double?> inputShares = null;
                string workCode = "";
                for(var idx = 1; idx <= rowCount - ROW_START + 1; idx++)
                {
                    var curWorkCode = (string)workCodes[idx, 1];
                    var curShare = sharesToPay[idx, 1];
                    if(workCode != curWorkCode)
                    {
                        if(inputShares != null)
                        {
                            inputShareSets.Add(inputShares);
                        }
                        inputShares = new List<double?>();
                        inputShares.Add((double?)curShare);
                        workCode = curWorkCode;
                    }
                    else
                    {
                        inputShares.Add((double?)curShare);
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

                var c1 = (Range)xlWorksheet.Cells[ROW_START, COL_SHARE_TOTAL];
                var c2 = (Range)xlWorksheet.Cells[rowCount, COL_SHARE_TOTAL];
                var range = xlWorksheet.get_Range(c1, c2);
                range.Value2 = dataArraySharesTotal;

                c1 = (Range)xlWorksheet.Cells[ROW_START, COL_SHARE_TOPAY];
                c2 = (Range)xlWorksheet.Cells[rowCount, COL_SHARE_TOPAY];
                range = xlWorksheet.get_Range(c1, c2);
                range.Value2 = dataArrayShares;

            });
        }

        private static string FormatWorkFilesPath(ReportParameters reportParameters)
        {
            try
            {
                var startDate = new DateTime(reportParameters.StartYear, reportParameters.StartMonth, 1);
                var endDate = new DateTime(reportParameters.EndYear, reportParameters.EndMonth, 1);
                var subDirName = $"{startDate:yyyy-MM}_{endDate:yyyy-MM}";

                return Path.Combine(Configuration.WorkFilesRootDir, reportParameters.RadioStationName, subDirName);
            }
            catch
            {
                return "";
            }
        }

        private static string FormatReportFileBaseName(ReportParameters reportParameters, string postfix)
        {
            try
            {
                var startDate   = new DateTime(reportParameters.StartYear, reportParameters.StartMonth, 1);
                var endDate     = new DateTime(reportParameters.EndYear, reportParameters.EndMonth, 1);
                var periodName  = $"{startDate:yyyy-MM}_{endDate:yyyy-MM}";
                return $"{reportParameters.RadioStationName}_{periodName}{postfix}";
            }
            catch
            {
                return "";
            }
        }

        private static string FormatSourceFileCopyName(ReportParameters reportParameters, string postfix)
        {
            var baseName = FormatReportFileBaseName(reportParameters, postfix);
            return baseName != "" ? $"{baseName}.xlsx" : "";
        }

        public static string FormatSearchFileName(ReportParameters reportParameters, string postfix)
        {
            var baseName = FormatReportFileBaseName(reportParameters, postfix);
            return baseName != "" ? $"{baseName}.Пошук.xlsx" : "";
        }

        public static string FormatSearchFileName(Report report)
        {
            return $"{report.SourceFileCopyName}.Пошук.xlsx";
        }

        public static string FormatCheckFileName(Report report)
        {
            var baseName = Path.GetFileNameWithoutExtension(report.FileName);
            return $"{baseName}.Перевірено.xlsx";
        }

        public static string FormatCheckFileName(ReportParameters reportParameters, string postfix)
        {
            var baseName = FormatReportFileBaseName(reportParameters, postfix);
            return baseName != "" ? $"{baseName}.Перевірено.xlsx" : "";
        }

        public static string FormatDistributionFileName(ReportParameters reportParameters, string postfix)
        {
            var baseName = FormatReportFileBaseName(reportParameters, postfix);
            return baseName != "" ? $"{baseName}.Розподіл.xlsx" : "";
        }

        public static string FormatDistributionFileName(Report report)
        {
            var baseName = Path.GetFileNameWithoutExtension(report.FileName);
            return $"{baseName}.Розподіл.xlsx";
        }

        public static string GetSearchFileFullName(Report report)
        {
            if(string.IsNullOrEmpty(report.WorkFilesPath))
            {
                return Path.Combine(report.FilePath, report.SearchFileName);
            }
            else
            {
                return Path.Combine(report.WorkFilesPath, report.SearchFileName);
            }
        }

        public static string GetDistributionFileFullName(Report report)
        {
            if (string.IsNullOrEmpty(report.WorkFilesPath))
            {
                return Path.Combine(report.FilePath, report.DistributionFileName);
            }
            else
            {
                return Path.Combine(report.WorkFilesPath, report.DistributionFileName);
            }
        }

        public static string GetCheckFileFullName(Report report)
        {
            if (string.IsNullOrEmpty(report.WorkFilesPath))
            {
                return Path.Combine(report.FilePath, report.CheckFileName);
            }
            else
            {
                return Path.Combine(report.WorkFilesPath, report.CheckFileName);
            }
        }

    }
}
