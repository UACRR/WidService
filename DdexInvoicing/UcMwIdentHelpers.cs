using InvoicingLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicing
{
    public partial class UcMwIdent : UserControl
    {
        public static string Truncate(string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }
            return source;
        }

        public static void RunSqlOperationDdex(SqlOperation oper)
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
            }
        }
        public static void RunSqlOperationWid(SqlOperation oper)
        {
            try
            {
                using (var waitCursor = new WaitCursor())
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringWid"]))
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

        public static DataTable SearchByColName(string colName, List<string> variants, SearchScope searchScope, SearchMethod searchMethod)
        {
            switch (searchScope)
            {
                case SearchScope.Wid: return SearchWidByColName(colName, variants, searchMethod);
                case SearchScope.Ms: return SearchMsByColName(colName, variants, searchMethod);
                case SearchScope.Both:
                    DataTable dt = SearchWidByColName(colName, variants, searchMethod);
                    dt.Merge(SearchMsByColName(colName, variants, searchMethod));
                    return dt;
                default: return null;
            }
        }
        public static DataTable SearchWidByColName(string colName, List<string> variants, SearchMethod searchMethod)
        {
            var dt = new DataTable();
            RunSqlOperationWid(cmd =>
            {
                cmd.CommandTimeout = 0;

                string filter = "";
                for (int i = 0; i < variants.Count; i++)
                {
                    string text = variants[i];
                    if (colName.Equals("name", StringComparison.OrdinalIgnoreCase))
                        text = Truncate(text, 60);
                    filter += i == 0 ? " where " : " or ";
                    if (searchMethod == SearchMethod.Exact)
                        filter += $"{colName} = @text{i} \r\n";
                    else if (searchMethod == SearchMethod.Like)
                        filter += $"{colName} like '%' + @text{i} + '%'\r\n";
                    else
                        filter += $"({colName} like '% ' + @text{i} or {colName} like @text{i} + ' %' or {colName} like @text{i} + '.' or {colName} like '% ' + @text{i} + ' %')\r\n";

                    cmd.Parameters.AddWithValue($"@text{i}", text);
                    //Console.WriteLine($",@text{i}  varchar(100) = '{text.Replace("'", "''")}'");
                }
                cmd.CommandText = $@"
                    select Wic
                          , null ObjId
                          , name
                          , authors
                          , performers
                          , 'Вибрати' action
                    from wObject
                    {filter}
                    OPTION(RECOMPILE)
                    ";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            });
            return dt;
        }
        public static DataTable SearchMsByColName(string colName, List<string> variants, SearchMethod searchMethod)
        {
            var dt = new DataTable();
            RunSqlOperationMs(cmd =>
            {
                cmd.CommandTimeout = 0;

                string filter = "";
                for (int i = 0; i < variants.Count; i++)
                {
                    string text = variants[i];
                    if (colName.Equals("name", StringComparison.OrdinalIgnoreCase))
                        text = Truncate(text, 200);
                    filter += i == 0 ? " where " : " or ";
                    if (searchMethod == SearchMethod.Exact)
                        filter += $"{colName} = @text{i} \r\n";
                    else if (searchMethod == SearchMethod.Like)
                        filter += $"{colName} like '%' + @text{i} + '%'\r\n";
                    else
                        filter += $"({colName} like '% ' + @text{i} or {colName} like @text{i} + ' %' or {colName} like @text{i} + '.' or {colName} like '% ' + @text{i} + ' %')\r\n";
                    cmd.Parameters.AddWithValue($"@text{i}", text);
                }
                cmd.CommandText = $@"
                    select null Wic
                          , ObjId
                          , name
                          , author authors
                          , performer performers
                          , 'Вибрати' action
                    from ObjectRight
                    {filter}
                    OPTION(RECOMPILE)
                    ";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            });
            return dt;
        }

        public static DataTable SearchByAltTitle(List<string> variants, SearchScope searchScope)
        {
            switch (searchScope)
            {
                case SearchScope.Wid: return SearchWidByAltTitle(variants);
                case SearchScope.Ms: return SearchMsByAltTitle(variants);
                case SearchScope.Both:
                    DataTable dt = SearchWidByAltTitle(variants);
                    dt.Merge(SearchMsByAltTitle(variants));
                    return dt;
                default: return null;
            }
        }
        public static DataTable SearchWidByAltTitle(List<string> variants)
        {
            var dt = new DataTable();
            RunSqlOperationWid(cmd =>
            {
                cmd.CommandTimeout = 0;

                string filter = "";
                for (int i = 0; i < variants.Count; i++)
                {
                    string text = variants[i];
                    text = Truncate(text, 60);
                    if (i == 0)
                    {
                        filter += $" where t1.AltTtl = @text0 \r\n";
                        cmd.Parameters.AddWithValue("@text0", text);
                    }
                    else
                    {
                        filter += $" or t1.AltTtl = @text{i} \r\n";
                        cmd.Parameters.AddWithValue($"@text{i}", text);
                    }
                }
                cmd.CommandText = $@"
                    select 
                      t2.Wic
                    , null ObjId
                    , t1.AltTtl name
                    , t2.authors
                    , t2.performers
                    , 'Вибрати' action
                    from TblAltTtl t1 join wObject t2 on t1.Wic = t2.Wic
                    {filter}
                    ";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            });
            return dt;
        }
        public static DataTable SearchMsByAltTitle(List<string> variants)
        {
            var dt = new DataTable();
            RunSqlOperationMs(cmd =>
            {
                cmd.CommandTimeout = 0;

                string filter = "";
                for (int i = 0; i < variants.Count; i++)
                {
                    string text = variants[i];
                    text = Truncate(text, 200);
                    if (i == 0)
                    {
                        filter += $" and (t1.name = @text0 \r\n";
                        cmd.Parameters.AddWithValue("@text0", text);
                    }
                    else
                    {
                        filter += $" or t1.name = @text{i} \r\n";
                        cmd.Parameters.AddWithValue($"@text{i}", text);
                    }
                }
                if (variants.Count > 0)
                    filter += $") \r\n";
                cmd.CommandText = $@"
                    select 
                      null Wic
                    , t2.ObjId
                    , t1.name
                    , t2.author authors
                    , t2.performer performers
                    , 'Вибрати' action
                    from SeekObject t1 join ObjectRight t2 on t1.ObjId = t2.ObjId
                    where CodeI = 1
                    {filter}
                    ";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            });
            return dt;
        }

        public static DataTable SearchByIswc(string iswc, SearchMethod searchMethod)
        {
            var dt = new DataTable();
            RunSqlOperationWid(cmd =>
            {
                string filter = searchMethod == SearchMethod.Exact ? "t1.iswc = @iswc" :
                                searchMethod == SearchMethod.Like ? "t1.iswc like '%' +  @iswc + '%'"
                                    : "(t1.iswc like '% ' + @iswc or t1.iswc like @iswc +' %' or t1.iswc like @iswc + '.' or t1.iswc like '% ' + @iswc +' %')";

                cmd.CommandTimeout = 0;

                cmd.CommandText = $@"
                    select 
                      t2.Wic
                    , null ObjId
                    , t2.name name
                    , t2.authors
                    , t2.performers
                    , 'Вибрати' action
                    from TblISWC t1 join wObject t2 on t1.Wic = t2.Wic
                    where {filter}
                    ";
                cmd.Parameters.AddWithValue("@iswc", iswc);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            });
            return dt;
        }

        public static DataTable SearchByPerformer(string performer, SearchScope searchScope, SearchMethod searchMethod)
        {
            switch (searchScope)
            {
                case SearchScope.Wid: return SearchWidByPerformer(performer, searchMethod);
                case SearchScope.Ms: return SearchMsByPerformer(performer, searchMethod);
                case SearchScope.Both:
                    DataTable dt = SearchWidByPerformer(performer, searchMethod);
                    dt.Merge(SearchMsByPerformer(performer, searchMethod));
                    return dt;
                default: return null;
            }
        }
        public static DataTable SearchWidByPerformer(string performer, SearchMethod searchMethod)
        {
            var dt = new DataTable();
            RunSqlOperationWid(cmd =>
            {
                string filter = searchMethod == SearchMethod.Exact ? "t1.LstNa = @performer" :
                                searchMethod == SearchMethod.Like ? "t1.LstNa like '%' +  @performer + '%'"
                                    : "(t1.LstNa like '% ' + @performer or t1.LstNa like @performer +' %' or t1.LstNa like @performer + '.' or t1.LstNa like '% ' + @performer +' %')";

                cmd.CommandTimeout = 0;

                cmd.CommandText = $@"
                    select t3.wic Wic
                        , null ObjId
                        , t3.Name name
                        , t3.Authors authors
                        , t3.Performers performers
                        , 'Вибрати' action
                    from TblArtist t1 
                        join TblTitle t2 on t1.wic = t2.wic
                        join wObject t3 on t3.wic = t2.wic
                    where {filter}
                    order by t3.Name
                    ";
                cmd.Parameters.AddWithValue("@performer", performer);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            });
            return dt;
        }
        public static DataTable SearchMsByPerformer(string performer, SearchMethod searchMethod)
        {
            var dt = new DataTable();
            RunSqlOperationMs(cmd =>
            {
                string filter = searchMethod == SearchMethod.Exact ? "t1.name = @performer" :
                                searchMethod == SearchMethod.Like ? "t1.name like '%' +  @performer + '%'"
                                    : "(t1.name like '% ' + @performer or t1.name like @performer +' %' or t1.name like @performer + '.' or t1.name like '% ' + @performer +' %')";

                cmd.CommandTimeout = 0;

                cmd.CommandText = $@"
                    select distinct
                          null Wic
                        , t2.ObjId ObjId
                        , t2.name name
                        , t2.author authors
                        , t2.performer performers
                        , 'Вибрати' action
                    from SeekObject t1 join ObjectRight t2 on t1.ObjId = t2.ObjId
                    where t1.CodeI = 2 and {filter}
                    order by t2.name
                    ";
                cmd.Parameters.AddWithValue("@performer", performer);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            });
            return dt;
        }

        private static string GetPreferredWord(string source)
        {
            var parts = source.Split(' ', '\\', '[', ']', ',', '.', ',', '/', ':', ';', '|');
            var retVal = "";
            foreach (var part in parts)
            {
                if (Regex.IsMatch(part, @"\p{IsCyrillic}") || Regex.IsMatch(part, "[a-zA-Z]"))
                {
                    if (part.Length > retVal.Length && !part.Equals("UNKNOWN", StringComparison.OrdinalIgnoreCase)
                         && !part.Equals("WRITER", StringComparison.OrdinalIgnoreCase)
                         && !part.Equals("READER", StringComparison.OrdinalIgnoreCase))
                        retVal = part;
                }
            }
            return retVal;
        }

        public static string GetAuthorForMatch(string authors, string performers)
        {
            string retVal = GetPreferredWord(authors);
            if (retVal != "")
                return retVal;
            return GetPreferredWord(performers);
        }
    }

    public class WaitCursor : IDisposable
        {
            public WaitCursor()
            {
                Cursor.Current = Cursors.WaitCursor;
            }

            public void Dispose()
            {
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
}
