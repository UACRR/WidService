using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoicingLib
{
    public class DdexReportActionLoadMediaLinksYouTube : DdexReportActionBase
    {
        // work data
        private SqlConnection conn;
        private int lastProcessedBlockId;
        private int recordIndexSy_04_01 = 1;
        private int recordIndexSy_05_02 = 1;
        private int pseudoBlockId = 1;
        private double royaltyThreshold;

        // variables for SVOD calculations
        private bool isFirstBlock = true;
        private bool isSWOD = false;
        private double musicRate = 0;
        private double geRate = 0;
        private double mechSplit = 0;
        private double perfSplit = 0;
        private double constantPSMRoyaltyValue = 0;
        private double constantGrossRevenueValue = 0;
        private double totalRevSharePayable = 0;
        private double totalPSMPayable = 0;
        private double blendedRevshareRate = 0;

        // load statistics
        private int cntSalesInFile = 0;
        private int cntMwInFile = 0;
        private int cntSalesLoaded = 0;
        private int cntMwLoaded = 0;

        // Work data
        Dictionary<string, BulkUploadToSql> bulkUploaders = new Dictionary<string, BulkUploadToSql>();
        HashSet<string> recordsToCorrect;

        public DdexReportActionLoadMediaLinksYouTube()
        {

        }

        private void RegisterBulkUploader(string tableName)
        {
            var bulkUploader = new BulkUploadToSql
            {
                TableName = tableName,
                conn = conn
            };
            bulkUploaders.Add(tableName, bulkUploader);
        }

        public override string GetDescription() { return "Завантаження даних для ідентифікації із звіту"; }

        public override void Init(DdexReport report)
        {
            this.report = report;
            try
            {
                conn = new SqlConnection(report.ConnectString);
                conn.Open();
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }

            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    cmd.CommandText = "delete from IdentBacklogLinksWrk";
                    cmd.ExecuteNonQuery();

                    recordsToCorrect = new HashSet<string>();
                    cmd.CommandText = @"select BlockId, RecordType, RecordIndex from DdexFileErrors where DdexReportId = @DdexReportId";
                    cmd.Parameters.AddWithValue("@DdexReportId", report.ddexReportId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                recordsToCorrect.Add($"{reader.GetString(0)}-{reader.GetString(1)}-{reader.GetInt32(2)}");
                            }
                        }
                    }

                    cmd.CommandText = @"
                        select 
                              royaltyThreshold
                            , musicRate
                            , geRate
                        from DdexReport 
                        where id = @ddexReportId";
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        r.Read();
                        royaltyThreshold = Convert.ToDouble(r.GetDecimal(0));
                        musicRate = Convert.ToDouble(r.GetDecimal(1)) * 0.01;
                        geRate = Convert.ToDouble(r.GetDecimal(2)) * 0.01;
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLine(ex.Message);
                    throw;
                }
            }

            RegisterBulkUploader("IdentBacklogLinksWrk");
        }

        public override int GetLastProcessedBlockId()
        {
            return 0;
        }

        private void InsertRecord(string dspResourceId, string link, int usages)
        {
            try
            {
                BulkUploadToSql bulkUploader = bulkUploaders["IdentBacklogLinksWrk"];
                var data = new List<object>();
                data.Add(dspResourceId);
                data.Add(link);
                data.Add(usages);
                bulkUploader.AddData(data);
            }
            catch (Exception ex)
            {
               throw;
            }
        }

        public override void ProcessFoot(FOOTRecord record)
        {
            foreach (var bulkUploader in bulkUploaders.Values)
                bulkUploader.Flush();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                }
                catch (Exception ex)
                {
                    Logger.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        private double CalcRoyalty(DdexReportBlock blockBase)
        {
            var block = blockBase as DdexReportBlockYouTube;
            double royalty = 0;
            if (!isSWOD)
            {
                royalty = block.suRecords.Sum(x =>
                    Formatter.ToDouble(x.NetRevenue) *
                    (x.ContentCategory.Equals("Music", StringComparison.OrdinalIgnoreCase) ? musicRate : geRate));
            }
            else
            {
                if (totalRevSharePayable > totalPSMPayable)
                {
                    royalty = block.suRecords.Sum(x =>
                        blendedRevshareRate * double.Parse(x.Usages, CultureInfo.InvariantCulture) * constantGrossRevenueValue);
                }
                else
                {
                    royalty = block.suRecords.Sum(x =>
                        constantPSMRoyaltyValue * double.Parse(x.Usages, CultureInfo.InvariantCulture));
                }
            }
            return royalty;
        }

        public override void ProcessBlock(DdexReportBlock blockBase)
        {
            var block = blockBase as DdexReportBlockYouTube;
            cntSalesInFile += block.suRecords.Count;
            cntMwInFile++;
            if (isFirstBlock)
            {
                isFirstBlock = false;
                if(isSWOD)
                {
                    foreach (var bulkUploader in bulkUploaders.Values)
                        bulkUploader.Flush();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        try
                        {
                            cmd.CommandText = @"spCreateCcidParamsForSubscr";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@DdexReportId", report.ddexReportId));
                            cmd.Parameters.Add(new SqlParameter("@musicRate", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@geRate", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@mechSplit", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@perfSplit", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@totalRevSharePayable", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@totalPSMPayable", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@constantGrossRevenueValue", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@constantPSMRoyaltyValue", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@blendedRevshareRate", SqlDbType.Float) { Direction = ParameterDirection.Output });

                            cmd.ExecuteNonQuery();

                            musicRate = (double)cmd.Parameters["@musicRate"].Value;
                            geRate = (double)cmd.Parameters["@geRate"].Value;
                            mechSplit = (double)cmd.Parameters["@mechSplit"].Value;
                            perfSplit = (double)cmd.Parameters["@perfSplit"].Value;
                            totalRevSharePayable = (double)cmd.Parameters["@totalRevSharePayable"].Value;
                            totalPSMPayable = (double)cmd.Parameters["@totalPSMPayable"].Value;
                            constantGrossRevenueValue = (double)cmd.Parameters["@constantGrossRevenueValue"].Value;
                            constantPSMRoyaltyValue = (double)cmd.Parameters["@constantPSMRoyaltyValue"].Value;
                            blendedRevshareRate = (double)cmd.Parameters["@blendedRevshareRate"].Value;
                        }
                        catch (Exception ex)
                        {
                            Logger.WriteLine(ex.Message);
                            throw;
                        }
                    }
                }
            }

            //if (CalcRoyalty(block) < Convert.ToDouble(royaltyThreshold))
                //return;

            cntMwLoaded++;
            try
            {
                foreach (var ruRecord in block.ruRecords)
                {
                    var links = ruRecord.DspReleaseId.Split('|');
                    var usages = ruRecord.Usages.Split('|');
                    for(var idx = 0; idx < links.Length; idx++)
                    {
                        InsertRecord(block.asRecord.DspResourceId, links[idx], int.Parse(usages[idx]));
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
