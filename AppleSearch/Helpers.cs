using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleSearch
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

        public static void RunSqlApple(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["Apple"].ConnectionString;
            RunSqlBase(connString, runSql);
        }

        public static void RunSqlAppleT(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["Apple"].ConnectionString;
            RunSqlBaseT(connString, runSql);
        }

    }

}
