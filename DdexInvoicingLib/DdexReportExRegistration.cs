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
        private static void InsertDsrHead(SqlCommand cmd, int ddexReportId, string fullFileName)
        {
            cmd.Parameters.Clear();
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
                        cmd.CommandText = $@"
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

                        cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);

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
        }

        private static void InsertSrmfHead(SqlCommand cmd, int ddexReportId, string fullFileName)
        {
            var fileParts = Path.GetFileNameWithoutExtension(fullFileName).Split('_');
            var tsStr = fileParts[6];
            var startTimeStr = fileParts[5];
            var ts = new DateTime(
                int.Parse(tsStr.Substring(0, 4)),
                int.Parse(tsStr.Substring(4, 2)),
                int.Parse(tsStr.Substring(6, 2)),
                int.Parse(tsStr.Substring(8, 2)),
                int.Parse(tsStr.Substring(10, 2)),
                int.Parse(tsStr.Substring(12, 2))
            );

            int year = int.Parse(startTimeStr.Substring(0, 4));
            int month = int.Parse(startTimeStr.Substring(4, 2));
            var startTime = new DateTime(year, month, 1);
            var endTime = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            cmd.CommandText = $@"
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

            cmd.Parameters.AddWithValue("@ddexReportId",            ddexReportId            );
            cmd.Parameters.AddWithValue("@MessageVersion",          "srmf"                  );
            cmd.Parameters.AddWithValue("@Profile",                 ""                      );
            cmd.Parameters.AddWithValue("@ProfileVersion",          ""                      );
            cmd.Parameters.AddWithValue("@MessageId",               ""                      );
            cmd.Parameters.AddWithValue("@MessageCreatedDateTime",  ts                      );
            cmd.Parameters.AddWithValue("@FileNumber",              1                       );
            cmd.Parameters.AddWithValue("@NumberofFiles",           1                       );
            cmd.Parameters.AddWithValue("@UsageStartDate",          startTime               );
            cmd.Parameters.AddWithValue("@UsageEndDate",            endTime                 );
            cmd.Parameters.AddWithValue("@SenderPartyId",           "PADPIDA2013020802I"    );
            cmd.Parameters.AddWithValue("@SenderName",              "YouTube"               );
            cmd.Parameters.AddWithValue("@ServiceDescription",      "PreClaim"              );
            cmd.Parameters.AddWithValue("@RecipientPartyId",        ""                      );
            cmd.Parameters.AddWithValue("@RecipientName",           "UACRR-CS"              );
            cmd.Parameters.AddWithValue("@RepresentedRepertoire",   ""                      );

            cmd.ExecuteNonQuery();
        }

        private static void InsertDdexReportRecord(SqlCommand cmd,
            string agreementReportType,
            string fullFileName,
            int licId,
            int custId,
            decimal exchRate,
            int ddexReportingPeriodId
            )
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@status", 0);
            cmd.Parameters.AddWithValue("@substatus", 0);
            cmd.Parameters.AddWithValue("@filetype", agreementReportType);
            cmd.Parameters.AddWithValue("@DdexSourceFolder", "DdexSourceFolder");
            cmd.Parameters.AddWithValue("@DdexSourceFolderValue", Path.GetDirectoryName(fullFileName) + "\\");
            cmd.Parameters.AddWithValue("@licId", licId);
            cmd.Parameters.AddWithValue("@custId", custId);
            cmd.Parameters.AddWithValue("@exchRate", exchRate);
            cmd.Parameters.AddWithValue("@ddexReportingPeriodId", ddexReportingPeriodId);
            cmd.Parameters.AddWithValue($"@OptionName1", $"DdexFile1");
            cmd.Parameters.AddWithValue($"@FileName1", Path.GetFileName(fullFileName));

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

                            {GetAgreementParametersSqlInsertCols(agreementReportType)}

                            , exchRate
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

                            {GetAgreementParametersSqlInsertValues(agreementReportType)}

                            , @exchRate
                        )
                        set @DdexReportId = SCOPE_IDENTITY();
                        insert into DdexReportProcessingData(DdexReportId, DataGroup, DataName, DataValue) 
                            values(@DdexReportId, 0, @DdexSourceFolder, @DdexSourceFolderValue);
                        insert into DdexReportProcessingData(DdexReportId, DataGroup, DataName, DataValue) 
                            values(@DdexReportId, 0, @OptionName1, @FileName1);
                        select @DdexReportId;
                    ";
            int ddexReportId = (int)cmd.ExecuteScalar();

            DoInsertHead(cmd, agreementReportType, ddexReportId, fullFileName);
        }

        public static void RegisterSingleFileReport(int licId, int custId, string agreementReportType, string fullFileName)
        {
            int ddexReportingPeriodId = CreateReportingPeriod(agreementReportType, fullFileName);
            var fExchRate = GetExchangeRate(licId, custId, agreementReportType, fullFileName);
            decimal exchRate = fExchRate == null ? 0M : (decimal)fExchRate;
            Helpers.RunSqlOperationDdexT(cmd =>
            {
                InsertDdexReportRecord(cmd, agreementReportType, fullFileName, licId, custId, exchRate, ddexReportingPeriodId);
            }, true);
        }

        public static void RegisterMultiFileReport(int licId, int custId, string agreementReportType, string firstFileFullName)
        {
            int ddexReportingPeriodId = CreateReportingPeriod(agreementReportType, firstFileFullName);
            var fExchRate = GetExchangeRate(licId, custId, agreementReportType, firstFileFullName);
            decimal exchRate = fExchRate == null ? 0M : (decimal)fExchRate;
            var serviceNames = GetServiceNames(agreementReportType);
            var fullFolderName = Path.GetDirectoryName(firstFileFullName);
            Helpers.RunSqlOperationDdexT(cmd =>
            {
                foreach (var serviceName in serviceNames)
                {
                    var filter = GetFileNameWildcardForService(agreementReportType, serviceName);
                    var files = Directory.GetFiles(fullFolderName, filter);
                    var fullFileName = files[0];
                    InsertDdexReportRecord(cmd, agreementReportType, fullFileName, licId, custId, exchRate, ddexReportingPeriodId);
                }
            }, true);
        }

    }
}
