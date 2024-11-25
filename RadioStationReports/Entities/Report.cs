using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioStationReports
{
    public class Report
    {
        public const string SelectSql = @"
            select
	              t1.Id                       
	            , t1.RadioStationId           
	            , t2.Name         
	            , t1.StartYear		         
	            , t1.StartMonth	             
	            , t1.EndYear		             
	            , t1.EndMonth                 
	            , t1.FileName                 
	            , t1.FilePath   
                , t1.WorkFilesPath    
                , t1.SourceFileCopyName    
	            , t1.SearchFileName           
	            , t1.DistributionFileName     
	            , t1.IsArchived               
	            , t1.CreatedAt                
	            , t1.UpdatedAt                
	            , t1.AutoSearchFinishedAt     
	            , t1.CalcRoyaltyFinishedAt    
	            , t1.SearchFileCreatedAt      
	            , t1.SearchFileUpdatedAt      
	            , t1.SearchFileImportedAt     
	            , t1.DistributionFileCreatedAt
	            , t1.DistributionFileUpdatedAt
            from Reports t1
	            left join RadioStations t2 on t1.RadioStationId = t2.Id
        ";

        public int          Id                          { get; set; }
        public int?         RadioStationId              { get; set; }
        public string       RadioStationName            { get; set; }
        public int?         StartYear		            { get; set; }
        public int?         StartMonth	                { get; set; }
        public int?         EndYear		                { get; set; }
        public int?         EndMonth                    { get; set; }
        public string       FileName                    { get; set; }
        public string       FilePath                    { get; set; }
        public string       WorkFilesPath               { get; set; }
        public string       SourceFileCopyName          { get; set; }
        public string       SearchFileName              { get; set; }
        public string       DistributionFileName        { get; set; }
        public bool         IsArchived                  { get; set; }
        public DateTime?    CreatedAt                   { get; set; }
        public DateTime?    UpdatedAt                   { get; set; }
        public DateTime?    AutoSearchFinishedAt        { get; set; }
        public DateTime?    CalcRoyaltyFinishedAt       { get; set; }
        public DateTime?    SearchFileCreatedAt         { get; set; }
        public DateTime?    SearchFileUpdatedAt         { get; set; }
        public DateTime?    SearchFileImportedAt        { get; set; }
        public DateTime?    DistributionFileCreatedAt   { get; set; }
        public DateTime?    DistributionFileUpdatedAt   { get; set; }

        public static Report CreateFromDb(SqlDataReader r)
        {
            var idx = 0;
            var report = new Report();
            report.Id = r.GetInt32(idx);
            idx++;
            report.RadioStationId = r.IsDBNull(idx) ? null : r.GetInt32(idx);
            idx++;
            report.RadioStationName = r.IsDBNull(idx) ? null : r.GetString(idx);
            idx++;
            report.StartYear = r.IsDBNull(idx) ? null : r.GetInt32(idx);
            idx++;
            report.StartMonth = r.IsDBNull(idx) ? null : r.GetInt32(idx);
            idx++;
            report.EndYear = r.IsDBNull(idx) ? null : r.GetInt32(idx);
            idx++;
            report.EndMonth = r.IsDBNull(idx) ? null : r.GetInt32(idx);
            idx++;
            report.FileName = r.GetString(idx);
            idx++;
            report.FilePath = r.IsDBNull(idx) ? "" : r.GetString(idx);
            idx++;            
            report.WorkFilesPath = r.IsDBNull(idx) ? "" : r.GetString(idx);
            idx++;
            report.SourceFileCopyName = r.IsDBNull(idx) ? "" : r.GetString(idx);
            idx++;
            report.SearchFileName = r.IsDBNull(idx) ? "" : r.GetString(idx);
            idx++;
            report.DistributionFileName = r.IsDBNull(idx) ? "" : r.GetString(idx);
            idx++;
            report.IsArchived =  r.IsDBNull(idx) ? false : r.GetBoolean(idx);
            idx++;
            report.CreatedAt = r.IsDBNull(idx) ? null : r.GetDateTime(idx);
            idx++;
            report.UpdatedAt = r.IsDBNull(idx) ? null : r.GetDateTime(idx);
            idx++;
            report.AutoSearchFinishedAt = r.IsDBNull(idx) ? null : r.GetDateTime(idx);
            idx++;
            report.CalcRoyaltyFinishedAt = r.IsDBNull(idx) ? null : r.GetDateTime(idx);
            idx++;
            report.SearchFileCreatedAt = r.IsDBNull(idx) ? null : r.GetDateTime(idx);
            idx++;
            report.SearchFileUpdatedAt = r.IsDBNull(idx) ? null : r.GetDateTime(idx);
            idx++;
            report.SearchFileImportedAt = r.IsDBNull(idx) ? null : r.GetDateTime(idx);
            idx++;
            report.DistributionFileCreatedAt = r.IsDBNull(idx) ? null : r.GetDateTime(idx);
            idx++;
            report.DistributionFileUpdatedAt = r.IsDBNull(idx) ? null : r.GetDateTime(idx);
            idx++;
            return report;
        }

        public static Report CreateFromDb(int reportId)
        {
            Report retVal = null;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = $"{SelectSql} where t1.Id = @ReportId";
                cmd.Parameters.AddWithValue("@ReportId", reportId);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    retVal = CreateFromDb(r);
                }
            });
            return retVal;
        }
        public static void UpdateFromDb(Report report)
        {
            Report newReportData = null;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = $"{SelectSql} where t1.Id = @ReportId";
                cmd.Parameters.AddWithValue("@ReportId", report.Id);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    newReportData = CreateFromDb(r);
                }
            });
            AssignData(report, newReportData);
        }

        public static void AssignData(Report targetReport, Report sourceReport)
        {
            targetReport.Id                             = sourceReport.Id                           ;
            targetReport.RadioStationId                 = sourceReport.RadioStationId               ;
            targetReport.RadioStationName               = sourceReport.RadioStationName             ;
            targetReport.StartYear		                = sourceReport.StartYear                    ;
            targetReport.StartMonth	                    = sourceReport.StartMonth                   ;
            targetReport.EndYear		                = sourceReport.EndYear                      ;
            targetReport.EndMonth                       = sourceReport.EndMonth                     ;
            targetReport.FileName                       = sourceReport.FileName                     ;
            targetReport.FilePath                       = sourceReport.FilePath                     ;
            targetReport.WorkFilesPath                  = sourceReport.WorkFilesPath                ;
            targetReport.SourceFileCopyName             = sourceReport.SourceFileCopyName           ;
            targetReport.SearchFileName                 = sourceReport.SearchFileName               ;
            targetReport.DistributionFileName           = sourceReport.DistributionFileName         ;
            targetReport.CreatedAt                      = sourceReport.CreatedAt                    ;
            targetReport.UpdatedAt                      = sourceReport.UpdatedAt                    ;
            targetReport.AutoSearchFinishedAt           = sourceReport.AutoSearchFinishedAt         ;
            targetReport.CalcRoyaltyFinishedAt          = sourceReport.CalcRoyaltyFinishedAt        ;
            targetReport.SearchFileCreatedAt            = sourceReport.SearchFileCreatedAt          ;
            targetReport.SearchFileUpdatedAt            = sourceReport.SearchFileUpdatedAt          ;
            targetReport.SearchFileImportedAt           = sourceReport.SearchFileImportedAt         ;
            targetReport.DistributionFileCreatedAt      = sourceReport.DistributionFileCreatedAt    ;
            targetReport.DistributionFileUpdatedAt      = sourceReport.DistributionFileUpdatedAt    ;
        }
        
        public ReportParameters GetReportParameters()
        {
            return new ReportParameters
            {
                RadioStationId      = RadioStationId   == null ? 0  : (int)RadioStationId  ,
                RadioStationName    = RadioStationName == null ? "" : RadioStationName     ,
                StartYear           = StartYear        == null ? 0  : (int)StartYear       ,
                StartMonth          = StartMonth       == null ? 0  : (int)StartMonth      ,
                EndYear             = EndYear          == null ? 0  : (int)EndYear         ,
                EndMonth            = EndMonth         == null ? 0  : (int)EndMonth        ,
            };
        }
    }
}
