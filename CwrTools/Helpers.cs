using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CwrTools
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
                    using(var cmd = conn.CreateCommand())
                    {
                        runSql(cmd);
                    }
                }
            }
            catch(Exception)
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
                        cmd.CommandTimeout = 0;
                        cmd.Transaction = tran;
                        runSql(cmd);
                        tran.Commit();
                    }
                }
            }
            catch (Exception)
            {
                if(tran != null)
                {
                    tran.Rollback();
                }
                throw;
            }

        }

        public static void RunSqlCwr(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["CWR"].ConnectionString;
            RunSqlBase(connString, runSql);
        }

        public static void RunSqlCwrT(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["CWR"].ConnectionString;
            RunSqlBaseT(connString, runSql);
        }
            public static bool IsDesignMode()
            {
                return System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower() == "devenv";
            }
        }
}
