using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidSubmit
{
    public static class Helpers
    {
        public delegate void RunSql(SqlCommand cmd);
        public delegate void ProtectedBlock();

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

        public static void RunSqlSocWidSubmitEx(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["SocWidSubmitEx"].ConnectionString;
            RunSqlBase(connString, runSql);
        }

        public static void RunSqlSocWidSubmitExT(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["SocWidSubmitEx"].ConnectionString;
            RunSqlBaseT(connString, runSql);
        }

        public static void RunProtected(ProtectedBlock block)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                block();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
