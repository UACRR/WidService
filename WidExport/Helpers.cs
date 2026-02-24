using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidExport.Entities;

namespace WidExport
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

        public static int InsertEntityInDb(SqlCommand cmd, object entity)
        {
            var t = entity.GetType();
            var piList = t.GetProperties();
            var tableName = ((TableAttribute)t.GetCustomAttributes().Single(x => x.GetType() == typeof(TableAttribute))).Name;
            var colsText = piList[1].Name;
            var paramsText = $"@{piList[1].Name}";
            for (int i = 2; i < piList.Count(); i++)
            {
                colsText += $", {piList[i].Name}";
                paramsText += $", @{piList[i].Name}";
            }
            var sql = $"insert into {tableName} (\r\n{colsText}\r\n) values (\r\n{paramsText}) \r\nselect scope_identity()";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            for (int i = 1; i < piList.Count(); i++)
            {
                cmd.Parameters.AddWithValue($"@{piList[i].Name}", piList[i].GetValue(entity));
            }
            var retVal = cmd.ExecuteScalar();
            return Convert.ToInt32(retVal);
        }
        public static int InsertSubmFileInDb(SqlCommand cmd)
        {
            var now = DateTime.Now;
            var entity = new SubmFile
            {
                
                Name = $"WidSubmission{now.ToString("yyyyMMdd")}.021",
                Year = now.Year,
                Month = now.Month,
                Day = now.Day,
            };
            return InsertEntityInDb(cmd, entity);
        }
        public static int InsertHdrInDb(SqlCommand cmd, int submFileId, DateTime dt)
        {
            var entity = new RecHdr
            {
                SubmFileId = submFileId,
                RecType = "HDR",
                SenderType = "SO",
                SenderId = "000000140",
                SenderName = "UACRR                                        ",
                StdVerNr = "02.10",
                CreD = dt.ToString("yyyyMMdd"),
                CreT = dt.ToString("yyyyMMdd"),
                TransmitD = dt.ToString("hhmmss"),
            };
            return InsertEntityInDb(cmd, entity);
        }
        public static int InsertTrlInDb(SqlCommand cmd, int submFileId)
        {
            var entity = new RecTrl
            {
                SubmFileId = submFileId,
                RecType = "TRL",
                GrCnt = "00000",
                TransCnt = "00000000",
                RecCnt = "00000000",
            };
            return InsertEntityInDb(cmd, entity);
        }
        public static bool IsGroupPublishInProgress(int groupId)
        {
            var retVal = false;
            try
            {
                Helpers.RunSqlSocWidSubmit(cmd => {
                    cmd.CommandText = "select dbo.fnCheckGroupPublishInProgress(@groupId)";
                    cmd.Parameters.AddWithValue("@groupId", groupId);
                    retVal = (bool)cmd.ExecuteScalar();
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    $"Помилка серверу БД - {ex.Message}\r\nДодаток буде закрито, споробуйте пізніше.",
                    "Оновлення інформації для групи",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return retVal;
        }
        public static bool IsGroupReadOnly(int groupId)
        {
            return IsGroupPublishInProgress(groupId);
        }
    }
}
