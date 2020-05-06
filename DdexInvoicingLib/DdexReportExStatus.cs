using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public partial class DdexReport
    {
        public enum Status
        {
            CREATED, ERROR_DETECTED, FIELD_SIZES_CHECKED, RAW_DATA_LOADED, AUTHORS_REGISTERED
            , INITIAL_INVOICE_CREATED, INITIAL_INVOICE_FILE_CREATED, INITIAL_INVOICE_FILE_SENT
            , RESPONCE_UPLOADED
            , FINAL_INVOICE_CREATED, FINAL_INVOICE_FILE_CREATED, FINAL_INVOICE_FILE_SENT
            , AMOUNT_DISTRIBUTED
        }

        public enum SubStatus
        {
            IDLE, IN_PROGRESS, FAILED, SUCCEEDED
        }

        public static int GetReportStatus(string connectionString, int ddexReportId)
        {
            try
            {
                return (int)SqlHelpers.GetSingleValue(connectionString
                    , "select status from DdexReport where Id = @p0"
                    , ddexReportId);
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }

        public static int GetReportSubStatus(string connectionString, int ddexReportId)
        {
            try
            {
                return (int)SqlHelpers.GetSingleValue(connectionString
                    , "select substatus from DdexReport where Id = @p0"
                    , ddexReportId);
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }

        public static int GetPeriodStatus(string connectionString, int ddexReportId)
        {
            try
            {
                return (int)SqlHelpers.GetSingleValue(connectionString
                    , "select t1.status from DdexReportingPeriod t1 join DdexReport t2 on t2.ddexReportingPeriodId = t1.Id where t2.Id = @p0"
                    , ddexReportId);
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }
        public static int GetPeriodSubStatus(string connectionString, int ddexReportId)
        {
            try
            {
                return (int)SqlHelpers.GetSingleValue(connectionString
                    , "select t1.substatus from DdexReportingPeriod t1 join DdexReport t2 on t2.ddexReportingPeriodId = t1.Id where t2.Id = @p0"
                    , ddexReportId);
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }

        public static bool IsPeriodProcessingStarted(string connectionString, int ddexReportingPeriodId)
        {
            try
            {
                int cnt = (int)SqlHelpers.GetSingleValue(connectionString
                    , @"select isnull(count(*), 0) from DdexReport where ddexReportingPeriodId = @p0
                            and (status > @p1 or status = @p1 and substatus > @p2)"
                    , ddexReportingPeriodId, Status.RAW_DATA_LOADED, SubStatus.IDLE);
                return cnt > 0;
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
