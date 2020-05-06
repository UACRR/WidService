using InvoicingLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{

    public partial class DdexReport
    {
        public HashSet<string> RecordsToCorrect { get; private set; }

        private string filesPath;
        private List<string> fileNames = new List<string>();
        private int curFileIndex = 0;

        // Settings
        public int ddexReportId;
        public string ConnectString { get; private set; }

        //
        private int lastProcessedBlockId = 0;

        public DdexReport(string connectString, int ddexReportId)
        {
            this.ConnectString = connectString;
            this.ddexReportId = ddexReportId;
        }

        public bool IsFirstFile()
        {
            return curFileIndex == 0;
        }

        public bool IsLastFile()
        {
            return curFileIndex == fileNames.Count - 1;
        }

        public void ProcessFiles(DdexReportActionBase action)
        {
            try
            {
                Logger.WriteLine($"{action.GetDescription()} розпочато");

                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    conn.Open();

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        // read records that require corrections
                        RecordsToCorrect = new HashSet<string>();
                        cmd.Parameters.Add(new SqlParameter("@DdexReportId", ddexReportId));
                        cmd.Connection = conn;
                        cmd.CommandText = @"select BlockId, RecordType, RecordIndex from DdexFileErrors where DdexReportId = @DdexReportId";

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    RecordsToCorrect.Add($"{reader.GetString(0)}-{reader.GetString(1)}");
                                }
                            }
                        }

                        // read files path
                        filesPath = (string)SqlHelpers.GetSingleValue(ConnectString
                                , @"select DataValue from DdexReportProcessingData where DdexReportId = @p0 and DataName = 'DdexSourceFolder'"
                                , ddexReportId);

                        // read file names
                        fileNames = new List<string>();
                        cmd.CommandText = @"select DataValue from DdexReportProcessingData where DdexReportId = @DdexReportId and DataName like 'DdexFile%'";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    fileNames.Add(reader.GetString(0));
                                }
                            }
                        }
                    }
                }

                // initialize action
                action.Init(this);
                lastProcessedBlockId = action.GetLastProcessedBlockId();

                curFileIndex = 0;
                foreach (var fileName in fileNames)
                {
                    ProcessFile(filesPath + fileName, action);
                    curFileIndex++;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }

        public void ProcessAdjustment(DdexReportActionBase action, string fileFullName)
        {
            try
            {
                action.Init(this);
                ProcessFile(fileFullName, action);
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }

        public void ProcessFile(string fileName, DdexReportActionBase action)
        {
            Logger.WriteLine($"Обробка файлу {fileName}");
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();

                    if (line[0] != '#')
                    {
                        var fields = line.Split('\t');
                        var recordType = fields[0];
                        if (recordType.Equals("HEAD"))
                        {
                            Logger.WriteLine($"Обробка запису {fields[0]}");
                            //HEADRecordGoogle record = new HEADRecordGoogle();
                            //record.fields = fields;
                            //action.ProcessHead(record);
                        }
                        else if (recordType.Equals("SY02.02"))
                        {
                            Logger.WriteLine($"Обробка запису {fields[0]}");
                            SYRecord_02_02 record = new SYRecord_02_02();
                            record.fields = fields;
                            action.ProcessSY_02_02(record);
                        }
                        else if (recordType.Equals("SY04.01"))
                        {
                            Logger.WriteLine($"Обробка запису {fields[0]}");
                            SYRecord_04_01 record = new SYRecord_04_01();
                            record.fields = fields;
                            action.ProcessSY_04_01(record);
                        }
                        else if (recordType.Equals("SY05.02"))
                        {
                            Logger.WriteLine($"Обробка запису {fields[0]}");
                            SYRecord_05_02 record = new SYRecord_05_02();
                            record.fields = fields;
                            action.ProcessSY_05_02(record);
                        }
                        else if (recordType.Equals("AP02"))
                        {
                            APRecord record = new APRecord();
                            record.fields = fields;
                            action.ProcessAP(record);
                        }
                        else if (recordType.Equals("SY09"))
                        {
                            // do nothing
                        }
                        else
                        {
                            // Process blocks until FOOT record is found. In this case block.Init returns false
                            while (true)
                            {
                                try
                                {
                                    var block = new DdexReportBlock(this, action.DoFiltering());
                                    if (!block.Init(streamReader, ref line))
                                        break;
                                    if (int.Parse(block.asRecord.BlockId) < lastProcessedBlockId)
                                        continue;
                                    block.Process(action, streamReader, ref line);
                                }
                                catch (Exception ex)
                                {
                                    Logger.WriteLine(ex.Message);
                                    throw;
                                }
                            }
                            // Process foot
                            Logger.WriteLine($"Обробка запису FOOT");
                            FOOTRecord record = new FOOTRecord();
                            record.fields = line.Split('\t');
                            if (record.fields != null)
                            {
                                action.ProcessFoot(record);
                            }
                        }
                    }
                }
            }
        }

    }
}
