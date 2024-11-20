using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioStationReports
{
    public static class Configuration
    {
        public static string TemplateFileFullName { get; set; }
        public static string DecimalSep { get; set; }
        public static int StartYear { get; set; }
        public static int EndYear { get; set; }
        public static void Load()
        {
            Helpers.RunSql( cmd =>
            {
                cmd.CommandText = "select * from Configuration";
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    TemplateFileFullName = r.GetString(1);
                    DecimalSep = r.GetString(2);
                    StartYear = r.GetInt32(3);
                    EndYear = r.GetInt32(4);
                }
            });
        }
    }
}
