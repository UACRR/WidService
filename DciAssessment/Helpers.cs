using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DciAssessment
{
    public static class Helpers
    {
        public delegate void RunSql(SqlCommand cmd);
        public delegate void RunSqLite(SQLiteCommand cmd);

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
            catch(Exception ex)
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
                if(tran != null)
                {
                    tran.Rollback();
                }
                throw;
            }

        }

        public static void RunSqlMs(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["MsDb"].ConnectionString;
            RunSqlBase(connString, runSql);
        }

        public static void RunSqlMsT(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["MsDb"].ConnectionString;
            RunSqlBaseT(connString, runSql);
        }

        public static void RunSqLiteBase(string connString, RunSqLite runSql)
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
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
        public static void RunSqLiteBaseT(string connString, RunSqLite runSql)
        {
            SQLiteTransaction tran = null;
            try
            {
                using (var conn = new SQLiteConnection(connString))
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

        public static void RunSqlLite(RunSqLite runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["SqLiteDb"].ConnectionString;
            RunSqLiteBase(connString, runSql);
        }

        public static void RunSqlLiteT(RunSqLite runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["SqLiteDb"].ConnectionString;
            RunSqLiteBaseT(connString, runSql);
        }

        public static void RunSqlSocWidSubmit(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["SocWidSubmit"].ConnectionString;
            RunSqlBase(connString, runSql);
        }

        public static void RunSqlSocWidSubmitT(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["SocWidSubmit"].ConnectionString;
            RunSqlBaseT(connString, runSql);
        }
    }
}
