using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DdexPreSearch
{
    public static class Helpers
    {

        const string connString = "Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWidSubmit; Server=193.178.146.103\\IPSDATA,60675";

        public delegate void Body(SqlCommand cmd);

        public static void RunSql(Body body)
        {
            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using(var cmd = conn.CreateCommand())
                    {
                        body(cmd);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }
        public static void RunSqlT(Body body)
        {
            SqlTransaction tran = null;
            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = tran;
                        body(cmd);
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
                Console.WriteLine(ex.Message);
                throw;
            }

        }

    }
}
