using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwrTools
{
    public static class CwrConfig
    {
        private static string FilesRootFolder { get; set; }
        public static string InputQueuePath { get; set; }
        private static string OutputQueuePath { get; set; }
        public static string InputFilesPath { get; set; }
        private static string OutputFilesPath { get; set; }
        public static void Load()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = "select ParamName, ParamValue from Config";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        switch(r.GetString(0))
                        {
                            case "FilesRootFolder":
                                FilesRootFolder = r.GetString(1);
                                break;
                            case "InputQueuePath":
                                InputQueuePath = r.GetString(1);
                                break;
                            case "OutputQueuePath":
                                OutputQueuePath = r.GetString(1);
                                break;
                            case "InputFilesPath":
                                InputFilesPath = r.GetString(1);
                                break;
                            case "OutputFilesPath":
                                OutputFilesPath = r.GetString(1);
                                break;
                        }
                    }
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spFillPeriods";
                cmd.Parameters.AddWithValue("@endYear", DateTime.Now.Year + 1);
                cmd.ExecuteNonQuery();
            });
        }

        public static string GetOutputGroupPath(string groupName)
        {
            return Path.Combine(OutputQueuePath, groupName);
        }

        public static string GetOutputGroupFullFileName(string groupName, string fileName)
        {
            return Path.Combine(GetOutputGroupPath(groupName), fileName);
        }

        public static string GetOutputPartnerPath(string partnerName)
        {
            return Path.Combine(OutputFilesPath, partnerName);
        }

        public static string GetOutputPartnerFullFileName(string partnerName, string fileName)
        {
            return Path.Combine(GetOutputPartnerPath(partnerName), fileName);
        }
    }
}
