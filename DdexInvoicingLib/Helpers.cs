using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Styles;

namespace InvoicingLib
{
    public class Helpers
    {
        public delegate void ProtectedBlock();

        private static int _waitCursorCnt;

        public static string Truncate(string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }
            return source;
        }

        public static void RunSqlOperationDdex(SqlOperation oper, bool throwException = false)
        {
            try
            {
                using (var waitCursor = new WaitCursor())
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringDdex"]))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandTimeout = 0;
                    oper(cmd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (throwException)
                    throw;
            }
        }

        public static void RunSqlOperationDdexUnprotected(SqlOperation oper)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringDdex"]))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandTimeout = 0;
                oper(cmd);
            }
        }

        public static async Task RunSqlOperationDdexAsync(SqlOperationAsync oper)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringDdex"]))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandTimeout = 0;
                await oper(cmd);
            }
        }

        public static void RunSqlOperationDdexUnsafe(SqlOperation oper, bool throwException = false)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringDdex"]))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandTimeout = 0;
                oper(cmd);
            }
        }

        public static void RunSqlOperationDdexT(SqlOperation oper, bool throwException = false)
        {
            try
            {
                using (var waitCursor = new WaitCursor())
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringDdex"]))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.Transaction = tran;
                                cmd.CommandTimeout = 0;
                                oper(cmd);
                                tran.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (throwException)
                                throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (throwException)
                    throw;
            }
        }
        public static void RunSqlOperationMs(SqlOperation oper)
        {
            try
            {
                using (var waitCursor = new WaitCursor())
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringMs"]))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandTimeout = 0;
                    oper(cmd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void RunSqlOperationMsUnsafe(SqlOperation oper)
        {
            using (var waitCursor = new WaitCursor())
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringMs"]))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandTimeout = 0;
                oper(cmd);
            }
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
    }

    public class Formatter
    {
        private static NumberFormatInfo numberFormat = new NumberFormatInfo()
        {
            NumberDecimalSeparator = "."
            , NumberGroupSeparator = ""
        };

        public static string ToString(decimal value) => value.ToString(numberFormat);
        public static string ToString(decimal? value) => value == null ? "" : ((decimal)value).ToString(numberFormat);
        public static decimal ToDecimal(string value)
        {
            return decimal.Parse(value, numberFormat);
        }
        public static string ToString(double value) => value.ToString(numberFormat);
        public static double ToDouble(string value) => double.Parse(value, numberFormat);
        public static DateTime ToDateTime(string value)
        {
            var dateTimeParts = value.Split(' ');
            var dateParts = dateTimeParts[0].Split('-');
            var timeParts = dateTimeParts[1].Split(':');
            return new DateTime(
                    int.Parse(dateParts[0]),
                    int.Parse(dateParts[1]),
                    int.Parse(dateParts[2]),
                    int.Parse(timeParts[0]),
                    int.Parse(timeParts[1]),
                    int.Parse(timeParts[2])
                );
        }
        public static bool ToBool(string value) => value == "true" ? true : false;
        public static string ToExportString(object value)
        {
            if (value == null)
            {
                return "";
            }
            var valueType = value.GetType();
            if (valueType.Equals(typeof(int)) || valueType.Equals(typeof(int?)))
            {
                return ((int)value).ToString();
            }
            else if (valueType.Equals(typeof(decimal)) || valueType.Equals(typeof(decimal?)))
            {
                return ((decimal)value).ToString(numberFormat);
            }
            else if (valueType.Equals(typeof(string)))
            {
                return (string)value;
            }
            else if (valueType.Equals(typeof(DateTime)) || valueType.Equals(typeof(DateTime?)))
            {
                return ((DateTime)value).ToString("yyyy-MM-dd hh:mm:ss");
            }
            else if (valueType.Equals(typeof(bool)) || valueType.Equals(typeof(bool?)))
            {
                return ((bool)value) ? "true" : "false";
            }
            else
            {
                return "";
            }
        }


        public static bool IsValidDecimal(string value)
        {
            decimal res;
            return decimal.TryParse(value,NumberStyles.Float, numberFormat, out res);
        }

        public static bool IsValidDouble(string value)
        {
            double res;
            return double.TryParse(value, NumberStyles.Float, numberFormat, out res);
        }

    }



    #region DEFINITIONS
    public class WaitCursor : IDisposable
    {
        static int InstanceCount = 0;
        public WaitCursor()
        {
            InstanceCount++;
            Cursor.Current = Cursors.WaitCursor;
        }

        public void Dispose()
        {
            InstanceCount--;
            if(InstanceCount == 0)
                Cursor.Current = Cursors.Default;
        }
    }
    public enum SearchType
    {
        byMwTitle
      , byAsTitle
    }

    public enum Status
    {
          notStarted
        , notIdentified
        , identified
        , postponed
        , notFound = 10
        , nameFoundNoAuthor = 20
        , nameFoundOneAuthor = 21
        , nameFoundManyAuthors = 22
        , altNameFoundNoAuthor = 30
        , altNameFoundOneAuthor = 31
        , altNameFoundManyAuthors = 32
    }

    public enum FilterType
    {
          notStarted = 0
        , notIdentified
        , identified
        , postponed
        , notFound = 10
        , nameFoundNoAuthor = 20
        , nameFoundOneAuthor = 21
        , nameFoundManyAuthors = 22
        , altNameFoundNoAuthor = 30
        , altNameFoundOneAuthor = 31
        , altNameFoundManyAuthors = 32
        , all = 100
    }

    public enum OrderType
    {
        byRevenue
        , byResourceTitle
        , byTitle
        , byAuthors
        , byPerformers
    }

    public enum OrderDir
    {
        asc, desc
    }

    public class LoadSettings
    {
        public int firstRowIndex;
        public int lastRowIndex;
        public FilterType filterType;
        public int filterTypeIndex;
        public OrderType orderType;
        public OrderDir orderDir;
    }

    public enum SearchScope
    {
        Wid, Ms, Both
    }

    public enum SearchMethod
    {
        Exact, Like, Includes
    }

    public delegate void SqlOperation(SqlCommand cmd);
    public delegate Task<VoidStateNode> SqlOperationAsync(SqlCommand cmd);
    #endregion


}
