using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleSearch
{
    public class ReportLoader
    {

        public void LoadFile(string fileFullName)
        {
            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = "truncate table AppleContentReportNew";
                cmd.ExecuteNonQuery();

                var bulkLoader = new BulkUploadToSql();
                bulkLoader.conn = cmd.Connection;
                bulkLoader.TableName = "AppleContentReportNew";
                using (StreamReader sr = File.OpenText(fileFullName))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        if(!line.StartsWith("AP02"))
                        {
                            continue;
                        }
                        string[] fields = line.Split('\t');
                        if(fields.Length != 23)
                        {
                            throw new Exception("???");
                        }

                        var data = new List<object>();
                        foreach(var field in fields)
                        {
                            data.Add(field);
                        }
                        bulkLoader.AddData(data);
                    }
                
                    bulkLoader.Flush();
                }
            });
        }
    }
}
