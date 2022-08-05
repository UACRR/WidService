using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public partial class DdexReport
    {
        public void SplitAuthors()
        {
            try
            {
                Logger.WriteLine("Ідентифікацію авторів розпочато");
                const int incr = 10000;
                int maxBlockId = (int)SqlHelpers.GetSingleValue(ConnectString
                    , "select max(cast(blockid as int)) from DdexRecordAs where ddexReportId = @p0"
                    , ddexReportId);
                int firstBlockId = (int)SqlHelpers.GetSingleValue(ConnectString
                    , "select isnull(max(cast(blockid as int)), 1) from DdexAuthorsSplitted where ddexReportId = @p0"
                    , ddexReportId);
                int lastBlockId = firstBlockId + incr;
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    conn.Open();
                    while (lastBlockId < maxBlockId + 1)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "spDdexCreateAuthorsSplitted";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.AddWithValue("@DdexReportId", ddexReportId);
                            cmd.Parameters.AddWithValue("@firstBlockId", firstBlockId);
                            cmd.Parameters.AddWithValue("@lastBlockId", lastBlockId);
                            cmd.ExecuteNonQuery();
                            Logger.WriteLine($"Оброблено {lastBlockId -1} блоків");
                            firstBlockId = lastBlockId;
                            lastBlockId = firstBlockId + incr;
                        }
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
