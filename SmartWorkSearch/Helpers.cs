using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkSearch
{
    public static class Helpers
    {
        public delegate void RunSql(SqlCommand cmd);

        public static void RunSqlBase(string connString, RunSql runSql)
        {
            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        runSql(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public static void RunSqlBaseT(string connString, RunSql runSql)
        {
            SqlTransaction tran = null; ;
            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = tran;
                        runSql(cmd);
                        tran.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                throw;
            }

        }

        public static void RunSqlSmartWorkSearch(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["SmartWorkSearch"].ConnectionString;
            RunSqlBase(connString, runSql);
        }

        public static void RunSqlSmartWorkSearchT(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["SmartWorkSearch"].ConnectionString;
            RunSqlBaseT(connString, runSql);
        }

    }

}
