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

        public static DataTable GetReportingPeriods(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var dt = new DataTable();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from DdexReportingPeriod order by Year desc, Quarter desc";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetRegisteredReports(string connectionString, int ddexReportingPeriodId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var dt = new DataTable();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from DdexReport where ddexReportingPeriodID = @ddexReportingPeriodId";
                cmd.Parameters.AddWithValue("@ddexReportingPeriodId", ddexReportingPeriodId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        struct FileIdentification
        {
            public string Type;
            public string Period;
        }

        public static void RegisterReports(string connectionString, string reportsFolder)
        {
            Dictionary<FileIdentification, List<string>> fileTypes = new Dictionary<FileIdentification, List<string>>();
            //foreach (var fullFileName in Directory.EnumerateFiles(reportsFolder, "DSR_UACRR-CS_YouTube_Usage-AdSupport-Music-*.tsv", SearchOption.TopDirectoryOnly))
            
            // REPORTS FROM GOOGLE
            foreach (var fullFileName in Directory.EnumerateFiles(reportsFolder, "DSR_*.tsv", SearchOption.TopDirectoryOnly))
            {
                string fileName = Path.GetFileName(fullFileName);
                string[] fileParts = fileName.Split('_');
                FileIdentification fi = new FileIdentification
                {
                    Type = fileParts[3], //.Split('-')[3],
                    Period = fileParts[4]
                };
                if (fileTypes.ContainsKey(fi))
                {
                    List<string> files = fileTypes[fi];
                    files.Add(fileName);
                }
                else
                {
                    List<string> files = new List<string>();
                    files.Add(fileName);
                    fileTypes.Add(fi, files);
                }
            }

            // REPORTS FROM APPLE
            foreach (var fullFileName in Directory.EnumerateFiles(reportsFolder, "AppleMusic_ContentReport_*_UKR*.tsv", SearchOption.TopDirectoryOnly))
            {
                string fileName = Path.GetFileName(fullFileName);
                string[] fileParts = fileName.Split('_');
                FileIdentification fi = new FileIdentification
                {
                    Type = fileParts[0], //.Split('-')[3],
                    Period = fileParts[2].Substring(0, 4) + '-' + fileParts[2].Substring(4, 2)
                };
                if (fileTypes.ContainsKey(fi))
                {
                    List<string> files = fileTypes[fi];
                    files.Add(fileName);
                }
                else
                {
                    List<string> files = new List<string>();
                    files.Add(fileName);
                    fileTypes.Add(fi, files);
                }
            }

            Helpers.RunSqlOperationDdexT(cmd =>
            {
                foreach (var pair in fileTypes)
                {
                    FileIdentification fi = pair.Key;
                    bool isAppleFile = fi.Type.Equals("AppleMusic", StringComparison.OrdinalIgnoreCase);
                    string[] yq = fi.Period.Split('-');
                    int year = int.Parse(yq[0]);
                    int quarter = int.Parse(yq[1][1].ToString());
                    string fileType = fi.Type;

                    cmd.CommandText = $@"
                                declare @DdexReportId int;
                                declare @DdexReportingPeriodId int;
                                if not exists (select null from DdexReportingPeriod where year = @year and quarter = @quarter)
                                begin
	                                insert into DdexReportingPeriod (status, substatus, [year], [quarter]) values (@status, @substatus, @year, @quarter)
                                end
                                select @DdexReportingPeriodId = Id from DdexReportingPeriod where year = @year and quarter = @quarter

                                if not exists (select null from DdexReport where DdexReportingPeriodId = @DdexReportingPeriodId and filetype = @filetype)
                                begin
                                    insert into DdexReport (ddexReportingPeriodId, status, substatus, SourceUri, TargetFolder, filetype) 
                                                    values (@ddexReportingPeriodId, @status, @substatus, '', '', @filetype)
                                    set @DdexReportId = SCOPE_IDENTITY();
                                    insert into DdexReportProcessingData(DdexReportId, DataGroup, DataName, DataValue) 
                                                                  values(@DdexReportId, 0, @DdexSourceFolder, @DdexSourceFolderValue);
                                ";
                    cmd.Parameters.AddWithValue("@status", 0);
                    cmd.Parameters.AddWithValue("@substatus", 0);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@quarter", quarter);
                    cmd.Parameters.AddWithValue("@filetype", fileType);
                    cmd.Parameters.AddWithValue("@DdexSourceFolder", "DdexSourceFolder");
                    cmd.Parameters.AddWithValue("@DdexSourceFolderValue", reportsFolder);

                    foreach (var fileName in pair.Value)
                    {
                        int fileIndex;
                        if (isAppleFile)
                            fileIndex = 1;
                        else
                        {
                            string[] fileNameParts = fileName.Split('_');
                            string fileIndexOfTotal = fileNameParts[6];
                            fileIndex = int.Parse(fileIndexOfTotal.Split('o')[0]);
                        }

                        cmd.CommandText += $@"
                                insert into DdexReportProcessingData(DdexReportId, DataGroup, DataName, DataValue) values(@DdexReportId, 0, @OptionName{fileIndex}, @FileName{fileIndex})";
                        cmd.Parameters.AddWithValue($"@OptionName{fileIndex}", $"DdexFile{fileIndex}");
                        cmd.Parameters.AddWithValue($"@FileName{fileIndex}", fileName);

                        if (fileIndex == 1)
                        {
                            using (FileStream fileStream = new FileStream(reportsFolder + fileName, FileMode.Open, FileAccess.Read))
                            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                            {
                                while (!streamReader.EndOfStream)
                                {
                                    var line = streamReader.ReadLine();
                                    var fields = line.Split('\t');
                                    var recordType = fields[0];
                                    if (recordType.Equals("HEAD"))
                                    {
                                        cmd.CommandText += $@"
                                                insert into DdexRecordHead
                                                    values (@DdexReportId
                                                      , @MessageVersion
                                                      , @Profile
                                                      , @ProfileVersion
                                                      , @MessageId
                                                      , @MessageCreatedDateTime
                                                      , @FileNumber
                                                      , @NumberofFiles
                                                      , @UsageStartDate
                                                      , @UsageEndDate
                                                      , @SenderPartyId
                                                      , @SenderName
                                                      , @ServiceDescription
                                                      , @RecipientPartyId
                                                      , @RecipientName
                                                      , @RepresentedRepertoire)";

                                        DdexRecordBase record;
                                        if (isAppleFile)
                                            record = new HEADRecordApple();
                                        else
                                            record = new HEADRecordGoogle();
                                        record.fields = fields;

                                        int i = 1;
                                        cmd.Parameters.AddWithValue("@MessageVersion", record.ConvertField(i++));
                                        cmd.Parameters.AddWithValue("@Profile", isAppleFile ? "" : record.ConvertField(i++));
                                        cmd.Parameters.AddWithValue("@ProfileVersion", record.ConvertField(i++));
                                        cmd.Parameters.AddWithValue("@MessageId", record.ConvertField(i++));
                                        cmd.Parameters.AddWithValue("@MessageCreatedDateTime", record.ConvertField(i++));
                                        cmd.Parameters.AddWithValue("@FileNumber", isAppleFile ? 0 : record.ConvertField(i++));
                                        cmd.Parameters.AddWithValue("@NumberofFiles", record.ConvertField(i++));
                                        cmd.Parameters.AddWithValue("@UsageStartDate", record.ConvertField(i++));
                                        cmd.Parameters.AddWithValue("@UsageEndDate", record.ConvertField(i++));
                                        cmd.Parameters.AddWithValue("@SenderPartyId", record.ConvertField(i++));
                                        cmd.Parameters.AddWithValue("@SenderName", record.ConvertField(i++));
                                        if (!isAppleFile)
                                        {
                                            cmd.Parameters.AddWithValue("@ServiceDescription", record.ConvertField(i++));
                                            cmd.Parameters.AddWithValue("@RecipientPartyId", record.ConvertField(i++));
                                            cmd.Parameters.AddWithValue("@RecipientName", record.ConvertField(i++));
                                            cmd.Parameters.AddWithValue("@RepresentedRepertoire", record.ConvertField(i++));
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@ServiceDescription", "AppleMusic");
                                            cmd.Parameters.AddWithValue("@RecipientPartyId", "");
                                            cmd.Parameters.AddWithValue("@RecipientName", "");
                                            cmd.Parameters.AddWithValue("@RepresentedRepertoire", "");
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    cmd.CommandText += @"
                            end";

                    cmd.ExecuteNonQuery();
                }
            });
        }

        public static decimal PreRegisterReport(int licId, int custId, string clientName, string targetReportType, string fullFileName)
        {
            object exchRate = null; // Return Value
            string fileName = Path.GetFileName(fullFileName);
            string[] fileParts = fileName.Split('_');
            string actualReportType;
            int year;
            int quarter;
            
            string[] fileTypeParts = fileParts[3].Split('-');
            actualReportType = $"{fileTypeParts[1]}-{fileTypeParts[2]}";
            year = int.Parse(fileParts[4].Substring(0, 4));
            quarter = int.Parse(fileParts[4].Substring(6, 1));

            if (!targetReportType.Equals(actualReportType))
                throw new Exception("Тип вибраного файлу не відповідає параметрам договору");

            Helpers.RunSqlOperationDdexT(cmd =>
            {
                cmd.Parameters.AddWithValue("@status", 0);
                cmd.Parameters.AddWithValue("@substatus", 0);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@quarter", quarter);
                cmd.Parameters.AddWithValue("@month", 3 * quarter - 2);
                cmd.Parameters.AddWithValue("@filetype", targetReportType);
                cmd.Parameters.AddWithValue("@DdexSourceFolder", "DdexSourceFolder");
                cmd.Parameters.AddWithValue("@DdexSourceFolderValue", Path.GetDirectoryName(fullFileName) + "\\");
                cmd.Parameters.AddWithValue("@licId", licId);
                cmd.Parameters.AddWithValue("@custId", custId);

                if(!actualReportType.Equals("AdSupport-Music", StringComparison.OrdinalIgnoreCase))
                {
                    cmd.CommandText = $@"
                        select exchRate
                        from CcidExchangeRate
                        where licId = @licId and custId = @custId and year = @year and month = @month
                    ";

                    exchRate = cmd.ExecuteScalar();
                    if (exchRate == null || exchRate == DBNull.Value)
                        throw new Exception("Не визначений курс обміну, необхідний для обробки звіту. "
                            + "Зайдіть на форму конфігурації договору і внесіть потрібне значення");
                }

                cmd.CommandText = $@"
                    declare @DdexReportId int;
                    declare @DdexReportingPeriodId int;
                    if not exists (select null from DdexReportingPeriod where year = @year and quarter = @quarter)
                    begin
	                    insert into DdexReportingPeriod (status, substatus, [year], [quarter]) values (@status, @substatus, @year, @quarter)
                    end
                    select Id from DdexReportingPeriod where year = @year and quarter = @quarter
                    ";
                int ddexReportingPeriodId = (int)cmd.ExecuteScalar();
                cmd.Parameters.AddWithValue("@ddexReportingPeriodId", ddexReportingPeriodId);

                cmd.CommandText = $@"if not exists (select null from DdexReport where DdexReportingPeriodId = @DdexReportingPeriodId and filetype = @filetype)
                            select 0
                            else
                            select 1";
                int reportExists = (int)cmd.ExecuteScalar();
                if (reportExists == 1)
                    throw new Exception("Вибраний файл вже зарейєстрований в системі");
            }, true);
            return Convert.ToDecimal(exchRate);
        }

        public static void RegisterReport(int licId, int custId, string clientName, string targetReportType, string fullFileName, decimal exchRate)
        {
            string fileName = Path.GetFileName(fullFileName);
            string[] fileParts = fileName.Split('_');
            int year;
            int quarter;
            year = int.Parse(fileParts[4].Substring(0, 4));
            quarter = int.Parse(fileParts[4].Substring(6, 1));

            Helpers.RunSqlOperationDdexT(cmd =>
            {
                cmd.Parameters.AddWithValue("@status", 0);
                cmd.Parameters.AddWithValue("@substatus", 0);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@quarter", quarter);
                cmd.Parameters.AddWithValue("@month", 3 * quarter - 2);
                cmd.Parameters.AddWithValue("@filetype", targetReportType);
                cmd.Parameters.AddWithValue("@DdexSourceFolder", "DdexSourceFolder");
                cmd.Parameters.AddWithValue("@DdexSourceFolderValue", Path.GetDirectoryName(fullFileName) + "\\");
                cmd.Parameters.AddWithValue("@licId", licId);
                cmd.Parameters.AddWithValue("@custId", custId);
                cmd.Parameters.AddWithValue("@exchRate", exchRate);

                cmd.CommandText = $@"
                    declare @DdexReportId int;
                    declare @DdexReportingPeriodId int;
                    if not exists (select null from DdexReportingPeriod where year = @year and quarter = @quarter)
                    begin
	                    insert into DdexReportingPeriod (status, substatus, [year], [quarter]) values (@status, @substatus, @year, @quarter)
                    end
                    select Id from DdexReportingPeriod where year = @year and quarter = @quarter
                    ";
                int ddexReportingPeriodId = (int)cmd.ExecuteScalar();
                cmd.Parameters.AddWithValue("@ddexReportingPeriodId", ddexReportingPeriodId);

                int fileIndex = 1;
                cmd.CommandText = $@"
                        declare @DdexReportId int;
                        insert into DdexReport (
                              ddexReportingPeriodId
                            , status
                            , substatus
                            , SourceUri
                            , TargetFolder
                            , filetype
                            , licId
                            , custId

                            , musicRate
                            , geRate
                            , mechSplit
                            , perfSplit
                            , musicPSM
                            , gePSM
                            , exchRate
                            , royaltyThreshold
                        ) 
                        values (
                              @ddexReportingPeriodId
                            , @status
                            , @substatus
                            , ''
                            , ''
                            , @filetype
                            , @licId
                            , @custId

                            , (select cast(paramValue as decimal(5,2)) from AgreementParam where paramId = 1 and licId = @licId and custId = @custId)
                            , (select cast(paramValue as decimal(5,2)) from AgreementParam where paramId = 2 and licId = @licId and custId = @custId)
                            , (select cast(paramValue as decimal(5,2)) from AgreementParam where paramId = 3 and licId = @licId and custId = @custId)
                            , (select cast(paramValue as decimal(5,2)) from AgreementParam where paramId = 4 and licId = @licId and custId = @custId)
                            , (select cast(paramValue as decimal(5,2)) from AgreementParam where paramId = 5 and licId = @licId and custId = @custId)
                            , (select cast(paramValue as decimal(5,2)) from AgreementParam where paramId = 6 and licId = @licId and custId = @custId)
                            , @exchRate
                            , (select cast(isnull(paramValue, 0) as decimal(20, 6)) from AgreementParam where paramId = 9 and licId = @licId and custId = @custId)
                        )
                        set @DdexReportId = SCOPE_IDENTITY();
                        insert into DdexReportProcessingData(DdexReportId, DataGroup, DataName, DataValue) 
                                                        values(@DdexReportId, 0, @DdexSourceFolder, @DdexSourceFolderValue);
                    ";
                cmd.CommandText += $@"
                        insert into DdexReportProcessingData(DdexReportId, DataGroup, DataName, DataValue) values(@DdexReportId, 0, @OptionName{fileIndex}, @FileName{fileIndex})";
                cmd.Parameters.AddWithValue($"@OptionName{fileIndex}", $"DdexFile{fileIndex}");
                cmd.Parameters.AddWithValue($"@FileName{fileIndex}", fileName);

                using (FileStream fileStream = new FileStream(fullFileName, FileMode.Open, FileAccess.Read))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var fields = line.Split('\t');
                        var recordType = fields[0];
                        if (recordType.Equals("HEAD"))
                        {
                            cmd.CommandText += $@"
                                    insert into DdexRecordHead
                                        values (@DdexReportId
                                            , @MessageVersion
                                            , @Profile
                                            , @ProfileVersion
                                            , @MessageId
                                            , @MessageCreatedDateTime
                                            , @FileNumber
                                            , @NumberofFiles
                                            , @UsageStartDate
                                            , @UsageEndDate
                                            , @SenderPartyId
                                            , @SenderName
                                            , @ServiceDescription
                                            , @RecipientPartyId
                                            , @RecipientName
                                            , @RepresentedRepertoire)";

                            DdexRecordBase record;
                            record = new HEADRecordGoogle();
                            record.fields = fields;

                            int i = 1;
                            cmd.Parameters.AddWithValue("@MessageVersion", record.ConvertField(i++));
                            cmd.Parameters.AddWithValue("@Profile", record.ConvertField(i++));
                            cmd.Parameters.AddWithValue("@ProfileVersion", record.ConvertField(i++));
                            cmd.Parameters.AddWithValue("@MessageId", record.ConvertField(i++));
                            cmd.Parameters.AddWithValue("@MessageCreatedDateTime", record.ConvertField(i++));
                            cmd.Parameters.AddWithValue("@FileNumber", record.ConvertField(i++));
                            cmd.Parameters.AddWithValue("@NumberofFiles", record.ConvertField(i++));
                            cmd.Parameters.AddWithValue("@UsageStartDate", record.ConvertField(i++));
                            cmd.Parameters.AddWithValue("@UsageEndDate", record.ConvertField(i++));
                            cmd.Parameters.AddWithValue("@SenderPartyId", record.ConvertField(i++));
                            cmd.Parameters.AddWithValue("@SenderName", record.ConvertField(i++));
                            cmd.Parameters.AddWithValue("@ServiceDescription", record.ConvertField(i++));
                            cmd.Parameters.AddWithValue("@RecipientPartyId", "");
                            cmd.Parameters.AddWithValue("@RecipientName", "");
                            cmd.Parameters.AddWithValue("@RepresentedRepertoire", "");
                            break;
                        }
                    }
                }

                cmd.ExecuteNonQuery();
            });

        }

    }
}
