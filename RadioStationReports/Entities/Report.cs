using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioStationReports
{
    public class Report
    {
        public int          Id                          { get; set; }
        public int?         RadioStationId              { get; set; }
        public string       RadioStationName            { get; set; }
        public int?         StartYear		            { get; set; }
        public int?         StartMonth	                { get; set; }
        public int?         EndYear		                { get; set; }
        public int?         EndMonth                    { get; set; }
        public string       FileName                    { get; set; }
        public string       FilePath                    { get; set; }
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
            report.FilePath = r.GetString(idx);
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
                cmd.CommandText = "select * from Reports where Id = @ReportId";
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
                cmd.CommandText = "select * from Reports where Id = @ReportId";
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
            targetReport.FileName                       = sourceReport.FileName                     ;
            targetReport.FilePath                       = sourceReport.FilePath                     ;
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
    }
}
