using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleSearch
{
    public class ReportWriter
    {
        public void CreateClaimedContentReport(string rightType)
        {
            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCreateClaimedContentReport";
                cmd.Parameters.AddWithValue("@rightType", rightType);
                cmd.ExecuteNonQuery();
            });
        }

        public string WriteReport(string folderFullName, string rightType)
        {
            var quarter = (DateTime.Now.Month - 1) / 3 + 1;
            var year = DateTime.Now.ToString("yyyy");
            var timestamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            var fileName = $"UKR_ClaimedContent_UACRR_AppleMusic_{year}Q{quarter}_{timestamp}.{rightType}.csv";
            var fileFullName = Path.Combine(folderFullName, fileName);

            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = "select * from ClaimedContentReport where cast(RepRatio as decimal) > 0";
                using (var r = cmd.ExecuteReader())
                {
                    using (StreamWriter sw = new StreamWriter(fileFullName))
                    {
                        while (r.Read())
                        {
                            sw.Write(r.GetString(0));
                            for (var idx = 1; idx < 6; idx++)
                            {
                                sw.Write(',');
                                sw.Write(r.GetString(idx));
                            }
                            sw.Write("\r\n");
                        }
                    }
                    
                }
            });

            return fileFullName;
        }

        public string TestClaimedContentReport(string fileFullName)
        {
            using (StreamReader sr = File.OpenText(fileFullName))
            {
                var s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Trim() == "")
                        break;
                    var parts = s.Split(',');
                    if (parts.Length != 6)
                        return s;
                }
            }
            return null;
        }
    }
}
