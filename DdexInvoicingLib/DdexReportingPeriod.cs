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
    public class DdexReportingPeriod
    {
        public enum CcidClFileCkeckResult
        {
            WRONG_FORMAT,
            INVALID_CORRECTION_REFERENCE,
            ALREADY_LOADED,
            VALID
        }

        private string connectString;
        private int ddexReportingPeriodId;
        public DdexReportingPeriod(string connectString, int ddexReportingPeriodId)
        {
            this.connectString = connectString;
            this.ddexReportingPeriodId = ddexReportingPeriodId;
        }

        public void PrepareDataForIdentification(int ddexReportId)
        {
            const int incr = 100000;
            Logger.WriteLine("Підготовку даних для ідентифікацїї творів розпочато");

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@DdexReportId", @ddexReportId);
                        cmd.CommandTimeout = 0;

                        cmd.CommandText = @"select isnull(max(blockId), @0) from [DdexIdentificationBacklog] where ddexReportId = @ddexReportId";
                        int maxBlock = (int)cmd.ExecuteScalar();
                        cmd.CommandText = @"select isnull(max(blockId), @0) + 1 from [DdexIdentificationBacklog] where ddexReportId = @ddexReportId and ExcStatus = 1";
                        int firstBlock = (int)cmd.ExecuteScalar();
                        int lastBlock = firstBlock + incr;
                        cmd.Parameters.AddWithValue("@firstBlock", @firstBlock);
                        cmd.Parameters.AddWithValue("@lastBlock", @lastBlock);
                        cmd.CommandText = @"
                            insert IdentMw (ResourceTitle, @Title, @ComposerAuthor, @DisplayArtistName, @ISWC, @[status])
                            select distinct asTitle, @mwTitle, @t1.composerauthor, @t1.DisplayArtistName, @t1.ISWC, @0
                            from DdexIdentificationBacklog t1 left join
                                IdentMw t2 on 
                                    t2.ResourceTitle = t1.AsTitle 
                                    and t2.Title = t1.mwTitle 
                                    and t2.ComposerAuthor = t1.ComposerAuthor
                                    and t2.DisplayArtistName = t1.DisplayArtistname
                                    and t2.ISWC = t1.ISWC
                            where ddexReportId = @ddexReportId and blockid >= @firstBlock and blockId < @lastBlock and t2.Title is null
                            update [DdexIdentificationBacklog] set ExcStatus = 1 where ddexReportId = @ddexReportId and blockid >= @firstBlock and blockId < @lastBlock
                        ";
                        while (firstBlock <= maxBlock)
                        {
                            cmd.ExecuteNonQuery();
                            int processedBlocks = lastBlock - 1 < maxBlock ? lastBlock - 1 : maxBlock;
                            Logger.WriteLine($"Оброблено {processedBlocks} блоків із {maxBlock}");
                            firstBlock = lastBlock;
                            lastBlock = firstBlock + incr;
                            cmd.Parameters["@firstBlock"].Value = firstBlock;
                            cmd.Parameters["@lastBlock"].Value = lastBlock;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Підготовка даних для ідентифікацїї творів завершилась з помилками");
                throw;
            }

            Logger.WriteLine("Підготовку даних для ідентифікацїї творів завершено");
        }

        public void DoInitialIdentification(int ddexReportId)
        {
            Logger.WriteLine("Попередню ідентафікацію творів розпочато");

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@DdexReportId", @ddexReportId);
                        cmd.CommandTimeout = 0;

                        cmd.CommandText = @"select count(*) from DdexIdentificationBacklog where ddexReportId = @ddexReportId";
                        int totalRowCount = (int)cmd.ExecuteScalar();
                        cmd.CommandText = @"select count(*) from IdentBacklog where ddexReportId = @ddexReportId";
                        int insertedRowCount = (int)cmd.ExecuteScalar();
                        cmd.CommandText = @"select isnull(max(blockId), @0) from [DdexIdentificationBacklog] where ddexReportId = @ddexReportId";
                        int maxBlock = (int)cmd.ExecuteScalar();
                        cmd.CommandText = @"select isnull(max(blockId), @0) + 1 from IdentBacklog where ddexReportId = @ddexReportId";
                        int firstBlock = (int)cmd.ExecuteScalar();
                        int lastBlock = firstBlock + 10000;
                        cmd.Parameters.AddWithValue("@firstBlock", @firstBlock);
                        cmd.Parameters.AddWithValue("@lastBlock", @lastBlock);

                        cmd.CommandText = @"
                            insert IdentBacklog (DdexReportId, @BlockId, @SalesTransactionId, @DspResourceId, @DspReleaseId, @ContentCategory
                                                                , @NetRevenue, @Usages, @ValidityPeriodStart, @ValidityPeriodEnd, @rateTotalPER, @rateTotalMEC, @mwId)
                            select DdexReportId, @BlockId, @SalesTransactionId, @DspResourceId, @DspReleaseId, @ContentCategory
                                    , @NetRevenue, @Usages, @ValidityPeriodStart, @ValidityPeriodEnd, @0, @0, @t2.id
                            from DdexIdentificationBacklog t1 
                                left join IdentMw t2 on 
                                    t2.ResourceTitle = t1.AsTitle 
                                    and t2.Title = t1.mwTitle 
                                    and t2.ComposerAuthor = t1.ComposerAuthor
                                    and t2.DisplayArtistName = t1.DisplayArtistname
                                    and t2.ISWC = t1.ISWC
                            where ddexReportId = @ddexReportId and blockid >= @firstBlock and blockId < @lastBlock
                            select @@ROWCOUNT
                        ";
                        while (firstBlock <= maxBlock)
                        {
                            int rowCount = cmd.ExecuteNonQuery();
                            if (rowCount == 0)
                                break;
                            insertedRowCount += rowCount;
                            Logger.WriteLine($"Додано {insertedRowCount} записів із {totalRowCount}");

                            firstBlock = lastBlock;
                            lastBlock = firstBlock + 10000;
                            cmd.Parameters["@firstBlock"].Value = firstBlock;
                            cmd.Parameters["@lastBlock"].Value = lastBlock;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Попередня ідентафікацію творів завершилась з помилками");
                throw;
            }

            Logger.WriteLine("Попередню ідентафікацію творів завершено");
        }

        public void IdentifyByIswc(int ddexReportId)
        {
            Logger.WriteLine("Ідентифікацію творов за кодом ISWC розпочато");

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        cmd.CommandTimeout = 0;

                        cmd.CommandText = $@"
                            update t1
                            set t1.Wic = t2.Wic, @t1.status = 2
                            from IdentMW t1
                                join {ConfigurationManager.AppSettings["WidDbName"]}.dbo.tblIswc t2 on t1.ISWC = t2.ISWC
                            where t1.status = 0;
                        ";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Ідентифікація творов за кодом ISWC завершилась з помилками");
                throw;
            }

            Logger.WriteLine("Ідентифікацію творов за кодом ISWC завершено");
        }

        public RevShare GetRevShare()
        {
            Logger.WriteLine("Отримання значень процентів за контрактом");

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        cmd.CommandText = @"select top 1 *
                                from RevShare t1 join DdexReportingPeriod t2
                                    on t1.year < t2.year or (t1.year = t2.year and t1.quarter <= t2.quarter )
                                where t2.Id = @ddexReportingPeriodId
                                order by t1.year, t1.quarter";
                        cmd.Parameters.AddWithValue("@DdexReportingPeriodId", @ddexReportingPeriodId);
                        cmd.CommandTimeout = 0;
                        SqlDataReader r = cmd.ExecuteReader();
                        if (!r.HasRows)
                            return null;
                        r.Read();
                        Logger.WriteLine("Отримання значень процентів за контрактом завершено");
                        int i = 2;
                        return new RevShare
                        {
                            MusicRateAdv = r.GetDecimal(i++),
                            GeRateAdv = r.GetDecimal(i++),
                            MusicRateSubscr = r.GetDecimal(i++),
                            GeRateSubscr = r.GetDecimal(i++),
                            MechSplit = r.GetDecimal(i++),
                            PerfSplit = r.GetDecimal(i++),
                            MusicPSM = r.GetDecimal(i++),
                            GePSM = r.GetDecimal(i++),
                            ExchangeRate = r.GetDecimal(i++)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Отримання значень процентів за контрактом завершилось з помилками");
                throw;
            }
        }

        public void ChangeRevShare(RevShare revShare, bool insert)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        if(insert)
                            cmd.CommandText = @"insert RevShare
                                select year, quarter
                                      , @MusicRateAdv
                                      , @GeRateAdv
                                      , @MusicRateSubscr
                                      , @GERateSubscr
                                      , @MechSplit
                                      , @PerfSplit
                                      , @MusicPSM
                                      , @GePSM
                                      , @ExchangeRate
                                from DdexReportingPeriod
                                where Id = @DdexReportingPeriodId";
                        else
                            cmd.CommandText = @"update RevShare
                                set year = t1.year, quarter = t1.quarter
                                      , MusicRateAdv = @MusicRateAdv
                                      , GeRateAdv = @GeRateAdv
                                      , MusicRateSubscr = @MusicRateSubscr
                                      , GERateSubscr = @GERateSubscr
                                      , MechSplit = @MechSplit
                                      , PerfSplit = @PerfSplit
                                      , MusicPSM = @MusicPSM
                                      , GePSM = @GePSM
                                      , ExchangeRate = @ExchangeRate
                                from DdexReportingPeriod t1
                                where Id = @DdexReportingPeriodId";
                        cmd.Parameters.AddWithValue("@DdexReportingPeriodId", @ddexReportingPeriodId);
                        cmd.Parameters.AddWithValue("@MusicRateAdv", @revShare.MusicRateAdv);
                        cmd.Parameters.AddWithValue("@GeRateAdv", @revShare.GeRateAdv);
                        cmd.Parameters.AddWithValue("@MusicRateSubscr", @revShare.MusicRateSubscr);
                        cmd.Parameters.AddWithValue("@GeRateSubscr", @revShare.GeRateSubscr);
                        cmd.Parameters.AddWithValue("@MechSplit", @revShare.MechSplit);
                        cmd.Parameters.AddWithValue("@PerfSplit", @revShare.PerfSplit);
                        cmd.Parameters.AddWithValue("@MusicPSM", @revShare.MusicPSM);
                        cmd.Parameters.AddWithValue("@GePSM", @revShare.GePSM);
                        cmd.Parameters.AddWithValue("@ExchangeRate", @revShare.ExchangeRate);
                        cmd.CommandTimeout = 0;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }

        public void SaveInvoice(string targetPath, bool isFinal)
        {
            Logger.WriteLine("Запис рахунку-фактури в файл розпочато");
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();

                    var ccidHeaderRecord = new CcidHeaderRecord();
                    ccidHeaderRecord.ReadFromDb(conn, @ddexReportingPeriodId);
                    string fileName = ccidHeaderRecord.BuildFileName();

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(targetPath + fileName))
                    {
                        Logger.WriteLine("Обробка заголовка");
                        ccidHeaderRecord.WriteToFile(file);

                        Logger.WriteLine("Обробка рядків деталізацій");
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = @"
                                            select t1.* 
                                            from CcidInDetail t1 join 
                                                ccidInFile t2 on t2.fileId = t1.fileId 
                                            where t2.DdexReportingPeriodId = @ddexReportingPeriodId 
                                                and InstanceIndex = (select max(InstanceIndex) 
                                                    from ccidInFile 
                                                    where DdexReportingPeriodId = @ddexReportingPeriodId)
                                            order by t2.fileId desc";
                            cmd.Parameters.Add(new SqlParameter("@ddexReportingPeriodId", @ddexReportingPeriodId));
                            cmd.CommandTimeout = 0;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                try
                                {
                                    while (reader.Read())
                                    {
                                        var ccidDetailRecord = new CcidDetailRecord();
                                        ccidDetailRecord.ReadFromDb(reader);
                                        ccidDetailRecord.WriteToFile(file);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.WriteLine(ex.Message);
                                    throw;
                                }
                            }
                        }

                        Logger.WriteLine("Запис підсумкового рядка");
                        var ccidTrailerRecord = new CcidTrailerRecord();
                        ccidTrailerRecord.ReadFromDb(conn, @ddexReportingPeriodId);
                        ccidTrailerRecord.WriteToFile(file);

                        /*
                        Logger.WriteLine("Saving name of created file.");
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = @"
                                declare @optionName varchar(1000);
                                select @optionName = 'CcidInFile' + cast((count(*) + 1) as varchar)
                                from DdexReportProcessingData 
                                where DdexReportId = @ddexReportId and DataName like 'CcidInFile%';
                                insert into DdexReportProcessingData(DdexReportId, @DataGroup, @DataName, @DataValue)
                                values(@ddexReportId, @0, @@optionName, @@optionValue)
                                ";
                            cmd.Parameters.AddWithValue("@ddexReportId", @ddexReportingPeriodId);
                            cmd.Parameters.AddWithValue("@optionValue", @targetPath + fileName);
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                Logger.WriteLine(ex.Message);
                            }
                        }
                        */

                        Logger.WriteLine("Запис рахунку-фактури в файл завершено");
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLine(ex.Message);
                    Logger.WriteLine("Запис рахунку-фактури в файл завершився за помилками");
                    throw;
                }
            }
        }

        public CcidClFileCkeckResult IsValidClFile(string fileFullName)
        {
            try
            {
                string ccidId = (string)SqlHelpers.GetSingleValue(connectString
                    , @"declare @instanceIndex int;
                        declare @fileId int;
                        select @instanceIndex = max(InstanceIndex) from CcidInFile where DdexReportingPeriodId = @p0
                        select @fileId = fileId from CcidInFile where DdexReportingPeriodId = @p0 and InstanceIndex = @instanceIndex
                        select ccid_id from CcidInHeader where fileId = @fileId"
                    , @ddexReportingPeriodId);

                string ccidIdCorrectionReference;
                FileStream fs = new FileStream(fileFullName, @FileMode.Open, @FileAccess.Read);
                using (var sr = new StreamReader(fs, @Encoding.UTF8))
                {
                    if (sr.EndOfStream)
                        return CcidClFileCkeckResult.WRONG_FORMAT;
                    string line = sr.ReadLine();
                    string[] fields = line.Split('\t');
                    if (fields.Length != 21)
                        return CcidClFileCkeckResult.WRONG_FORMAT;
                    ccidIdCorrectionReference = fields[13];
                    if (!ccidIdCorrectionReference.Equals(ccidId))
                        return CcidClFileCkeckResult.INVALID_CORRECTION_REFERENCE;

                    bool alreadyLoaded = (bool)SqlHelpers.GetSingleValue(connectString
                    , @"select case 
                        when exists(select null from CcidClHeader where ccid_id_correction_reference = @p0) 
                        then cast(1 as bit) else cast(0  as bit)
                        end"
                    , @ccidId);
                    if (alreadyLoaded)
                        return CcidClFileCkeckResult.ALREADY_LOADED;
                    return CcidClFileCkeckResult.VALID;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void LoadClaim(string fileFullName)
        {
            Logger.WriteLine("Завантаження відповіді від клієнта розпочато");

            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(fileFullName))
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        cmd.CommandText = @"insert into ccidClFile(DdexReportingPeriodId, @InstanceIndex) 
                            values(@DdexReportingPeriodId, @(select 1 + isnull(max(InstanceIndex), @0) from ccidClFile where DdexReportingPeriodId = @DdexReportingPeriodId))
                            select scope_identity()";
                        cmd.Parameters.AddWithValue("@DdexReportingPeriodId", @ddexReportingPeriodId);
                        object newId = cmd.ExecuteScalar();
                        int ccidClFileId = Convert.ToInt32(newId);

                        string line;
                        BulkUploadToSql bulkUploader = new BulkUploadToSql();
                        bulkUploader.TableName = "CcidClDetail";
                        bulkUploader.conn = conn;

                        int lineCount = 0;
                        while ((line = file.ReadLine()) != null)
                        {
                            lineCount++;
                            string[] fields = line.Split('\t');
                            if (fields[0].Equals("HD", @StringComparison.OrdinalIgnoreCase))
                            {
                                CcidHeaderRecord record = new CcidHeaderRecord();
                                record.UploadLine(conn, @ccidClFileId, @fields);
                            }
                            else if (fields[0].Equals("ID", @StringComparison.OrdinalIgnoreCase))
                            {
                                CcidDetailRecord record = new CcidDetailRecord();
                                record.UploadLine(bulkUploader, @ccidClFileId, @fields);
                            }
                            else if (fields[0].Equals("TR", @StringComparison.OrdinalIgnoreCase))
                            {
                                bulkUploader.Flush();
                                CcidTrailerRecord record = new CcidTrailerRecord();
                                record.UploadLine(conn, @ccidClFileId, @fields);
                            }
                            if (lineCount % 10000 == 0)
                                Logger.WriteLine($"Оброблено {lineCount} рядків");
                        }
                    }

                    /*
                    Logger.WriteLine("Saving file name.");
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                                declare @optionName varchar(1000);
                                select @optionName = 'CcidClFile' + cast((count(*) + 1) as varchar)
                                from DdexReportProcessingData 
                                where DdexReportId = @ddexReportId and DataName like 'CcidClFile%';
                                insert into DdexReportProcessingData(DdexReportId, @DataGroup, @DataName, @DataValue)
                                values(@ddexReportId, @0, @@optionName, @@optionValue)
                                ";
                        cmd.Parameters.AddWithValue("@ddexReportId", @ddexReportId);
                        cmd.Parameters.AddWithValue("@optionValue", @fileFullName);
                        cmd.ExecuteNonQuery();
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Завантаження відповіді від клієнта завершилось з помилками");
                throw;
            }

            Logger.WriteLine("Завантаження відповіді від клієнта завершено");
        }

        public void CreateCorrectedInvoice()
        {
            Logger.WriteLine("Стоврення підсумкового рахунку-фактури розпочато");

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = @"spCreateCorrectedInvoice";
                        cmd.Parameters.AddWithValue("@DdexReportingPeriodId", @ddexReportingPeriodId);
                        cmd.CommandTimeout = 0;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                Logger.WriteLine("Стоврення підсумкового рахунку-фактури завершилось з помилками");
                throw;
            }

            Logger.WriteLine("Стоврення підсумкового рахунку-фактури завершено");
        }

    }
}
