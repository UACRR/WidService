using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwrTools
{
    public static class CwrConfig
    {
        public static string FilesRootFolder { get; set; }
        public static string InputQueuePath { get; set; }
        public static string OutputQueuePath { get; set; }
        public static string InputFilesPath { get; set; }
        public static string OutputFilesPath { get; set; }
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
            });
        }
    }
}
