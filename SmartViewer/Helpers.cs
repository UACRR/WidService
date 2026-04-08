using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartViewer
{
    public static class Helpers
    {
        public delegate void RunSql(SqlCommand cmd);
        public delegate void ProtectedBlock();

        private static int _waitCursorCnt;

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

        public static void RunSqlMediaService(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["MediaService"].ConnectionString;
            RunSqlBase(connString, runSql);
        }

        public static void CopyCellValue(MouseEventArgs e, ListView listView)
        {
            if(e.Button == MouseButtons.Right)
            {
                var htInfo = listView.HitTest(new Point(e.X, e.Y));
                if (htInfo == null || htInfo.SubItem == null) return;
                var text = htInfo.SubItem.Text;
                var menu = new ContextMenu();
                menu.MenuItems.Add("Копіювати значення");
                menu.MenuItems[0].Click += ((s, ev) =>
                {
                    if(!string.IsNullOrEmpty(text))
                        Clipboard.SetText(text);
                });
                menu.Show(listView, new Point(e.X, e.Y));
            }
        }

        
    }
}
