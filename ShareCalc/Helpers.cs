using System;
using System.Collections.Generic;
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

namespace ShareCalc
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

        public static void RunSqlShareCalc(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["ShareCalc"].ConnectionString;
            RunSqlBase(connString, runSql);
        }

        public static void RunSqlShareCalcT(RunSql runSql)
        {
            var connString = ConfigurationManager.ConnectionStrings["ShareCalc"].ConnectionString;
            RunSqlBaseT(connString, runSql);
        }

        public static void RunProtected(ProtectedBlock block, bool keepWaitCursor = false)
        {
            try
            {
                SetWaitCursor();
                block();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(!keepWaitCursor) UnsetWaitCursor();
            }
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

        public static bool ShowFileInFolder(string fileFullName)
        {
            if (!File.Exists(fileFullName))
            {
                return false;
            }

            var argument = $"/select, \"{fileFullName}\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
            return true;
        }

        public static void DecompressFile(string sourceFile, string targetFile)
        {
            using (FileStream sourceFileStream = File.OpenRead(sourceFile))
            {
                using (FileStream targetFileStream = File.Create(targetFile))
                {
                    using (GZipStream decompressionStream = new GZipStream(sourceFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetFileStream);
                    }
                }
            }
        }

        public static void SetWaitCursor()
        {
            _waitCursorCnt++;
            if(_waitCursorCnt == 1) Cursor.Current = Cursors.WaitCursor;
        }

        public static void UnsetWaitCursor()
        {
            _waitCursorCnt--;
            if(_waitCursorCnt == 0) Cursor.Current = Cursors.Default;
        }

        public static bool IsDesignMode()
        {
            return System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower() == "devenv";
        }

        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static List<T> CreateListFromCmd<T>(SqlCommand cmd)
        {
            var list = new List<T>();
            var elementProps = typeof(T).GetProperties();
            using(var r =  cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    var obj = (T)Activator.CreateInstance(typeof(T));
                    for (int propIdx = 0; propIdx < elementProps.Length; propIdx++)
                    {
                        var prop = elementProps[propIdx];
                        switch(prop.PropertyType.Name.ToLower())
                        {
                            case "string":
                                prop.SetValue(obj, r.IsDBNull(propIdx) ? "" : r.GetString(propIdx));
                                break;
                            case "int32":
                                prop.SetValue(obj, r.IsDBNull(propIdx) ? 0 : r.GetInt32(propIdx));
                                break;
                            case "decimal":
                                prop.SetValue(obj, r.IsDBNull(propIdx) ? 0 : r.GetDecimal(propIdx));
                                break;
                            case "datetime":
                                prop.SetValue(obj, r.IsDBNull(propIdx) ? (DateTime?)null : r.GetDateTime(propIdx));
                                break;
                            case "boolean":
                                prop.SetValue(obj, r.IsDBNull(propIdx) ? (bool?)null : r.GetBoolean(propIdx));
                                break;
                            default:
                                break;
                        }
                    }
 
                    list.Add(obj);
                }
            }
            return list;
        }

        public delegate bool SkipListViewItem<T>(T obj);
        public static void FillListView<T>(List<T> list, ListView lv, SkipListViewItem<T> skipObj = null)
        {
            lv.BeginUpdate();
            var elementProps = typeof(T).GetProperties();
            lv.Items.Clear();
            for (int idx = 0; idx < list.Count; idx++)
            {
                var obj = list[idx];
                if(skipObj != null && skipObj(obj))
                    continue;
                var lvItem = new ListViewItem((idx + 1).ToString());
                for (int propIdx = 0; propIdx < elementProps.Length; propIdx++)
                {
                    var prop = elementProps[propIdx];
                    lvItem.SubItems.Add(prop.GetValue(obj).ToString());
                }
                lvItem.Tag = obj;
                lv.Items.Add(lvItem);
            }
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lv.EndUpdate();
        }

        public static void ConfigureListView(ListView lv, params string[] colTitles)
        {
            lv.FullRowSelect = true;
            lv.GridLines = true;
            lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lv.MultiSelect = false;
            lv.View = View.Details;
            lv.Columns.Clear();
            lv.Columns.Add("№");
            colTitles.ToList().ForEach(x => lv.Columns.Add(x));

            lv.MouseDown += (sender, e) => CopyCellValue(e, (ListView)sender);
        }
    }
}
