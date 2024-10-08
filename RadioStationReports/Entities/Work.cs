using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioStationReports
{
    public class Work
    {
        public int      Id               { get; set; }
        public string   Name             { get; set; }
        public string   Authors          { get; set; }
        public string   Performers       { get; set; }
        public string   NameT            { get; set; }
        public string   AuthorsT         { get; set; }
        public string   PerformersT      { get; set; }
        public bool     HasMatchingWorks { get; set; }
        public string   FoundIn          { get; set; }
        public int?     FoundCde         { get; set; }
        public string   Iswc             { get; set; }
        public decimal? Share            { get; set; }

        public List<MatchingWork> MatchingWorks { get; set; }

        public static Work CreateFromDb(SqlCommand cmd, int reportId, int lineNr)
        {
            cmd.CommandText = $@"
                select t2.Id, t2.Name, t2.Authors, t2.Performers, t2.NameT, t2.AuthorsT, t2.PerformersT, t2.FoundIn, t2.FoundCde, t2.Iswc,t2.Share
                from ReportLines t1
                    join Works t2 on t1.WorkId = t2.Id
                where t1.ReportId = @reportId and t1.LineNr = @lineNr
            ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reportId", reportId);
            cmd.Parameters.AddWithValue("@lineNr", lineNr);
            using var r = cmd.ExecuteReader();
            var work = new Work();
            r.Read();
            var idx = 0;
            work.Id = r.GetInt32(idx++);
            work.Name = r.GetString(idx++);
            work.Authors = r.GetString(idx++);
            work.Performers = r.GetString(idx++);
            work.NameT = r.IsDBNull(idx) ? "" : r.GetString(idx);
            idx++;
            work.AuthorsT = r.IsDBNull(idx) ? "" : r.GetString(idx);
            idx++;
            work.PerformersT = r.IsDBNull(idx) ? "" : r.GetString(idx);
            idx++;
            work.FoundIn = r.IsDBNull(idx) ? "" : r.GetString(idx);
            idx++;
            work.FoundCde = r.IsDBNull(idx) ? (int?)null : r.GetInt32(idx);
            idx++;
            work.Iswc = r.IsDBNull(idx) ? "" : r.GetString(idx);
            idx++;
            work.Share = r.IsDBNull(idx) ? (decimal?)null : r.GetDecimal(idx);
            return work;
        }
    }
}
