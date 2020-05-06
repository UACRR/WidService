using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoicingLib;
using System.Configuration;
using Telerik.WinControls.UI;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace DdexInvoicing
{
    public partial class UcMwIdent : UserControl
    {
        public UcMwIdent()
        {
            InitializeComponent();
            radGridSales.MasterView.TableSearchRow.ShowCloseButton = false;
            radGridWid.MasterView.TableSearchRow.ShowCloseButton = false;
            radGridWid.MasterTemplate.DataView.BypassSort = true;
        }

        private int ddexReportId = -1;
        private bool isAutoMode = false;

        //DataTable salesDataTable;
        DataTable widDataTable;

        private LoadSettings loadSettings = new LoadSettings
        {
            firstRowIndex = 1
            ,
            lastRowIndex = 1000
            ,
            filterType = FilterType.all
            ,
            filterTypeIndex = 1
            ,
            orderType = OrderType.byRevenue
            ,
            orderDir = OrderDir.desc
        };

        private void UcMwIdent_Load(object sender, EventArgs e)
        {
            FillSearchColumnCombo();
            FillSearchMethodCombo();
            FillFilterByStatusCombo();
            FillFilterSpecialCombo();
        }

        public void SetReport(int ddexReportId)
        {
            this.ddexReportId = ddexReportId;
            radGridSales.DataSource = null;
            radGridWid.DataSource = null;
        }

        private void FillSearchColumnCombo()
        {
            radComboSearchColumn.Items.Add(new RadListDataItem("За назвою твору"));
            radComboSearchColumn.Items.Add(new RadListDataItem("За кодом ISWC"));
            radComboSearchColumn.Items.Add(new RadListDataItem("За виконавцем"));
            radComboSearchColumn.Items[0].Selected = true;
        }
        private void FillSearchMethodCombo()
        {
            radComboSearchMethod.Items.Add(new RadListDataItem("що точно співпадає з"));
            radComboSearchMethod.Items.Add(new RadListDataItem("що містить текст"));
            radComboSearchMethod.Items.Add(new RadListDataItem("що містить слово"));
            radComboSearchMethod.Items[0].Selected = true;
        }
        private void FillFilterByStatusCombo()
        {
            radComboFilterByStatus.Items.Add(new RadListDataItem("Всі твори"));
            radComboFilterByStatus.Items.Add(new RadListDataItem("Тільки необроблені (0)"));
            radComboFilterByStatus.Items.Add(new RadListDataItem("Тільки не ідентифіковані (1)"));
            radComboFilterByStatus.Items.Add(new RadListDataItem("Тільки ідентифіковані (2)"));
            radComboFilterByStatus.Items.Add(new RadListDataItem("Тільки відкладені (3)"));
            radComboFilterByStatus.Items.Add(new RadListDataItem("Назва не знайдена (10)"));
            radComboFilterByStatus.Items.Add(new RadListDataItem("Назва знайдена, автори не знайдені (20)"));
            radComboFilterByStatus.Items.Add(new RadListDataItem("Назва знайдена, один автор знайдений (21)"));
            radComboFilterByStatus.Items.Add(new RadListDataItem("Назва знайдена, кілька авторів знайдено (22)"));
            radComboFilterByStatus.Items.Add(new RadListDataItem("Альтернативна назва знайдена, автори не знайдені (30)"));
            radComboFilterByStatus.Items.Add(new RadListDataItem("Альтернативна назва знайдена, один автор знайдений (31)"));
            radComboFilterByStatus.Items.Add(new RadListDataItem("Альтернативна назва знайдена, кілька авторів знайдено (32)"));
            radComboFilterByStatus.Items[0].Selected = true;
        }
        private void FillFilterSpecialCombo()
        {
            radComboFilterSpecial.Items.Add(new RadListDataItem("Всі рядки"));
            radComboFilterSpecial.Items.Add(new RadListDataItem("Що містять кирилицю "));
            radComboFilterSpecial.Items.Add(new RadListDataItem("Що не містять кирилицю або латиницю"));
            radComboFilterSpecial.Items[0].Selected = true;
        }
        
        private void radBtnLoadData_Click(object sender, EventArgs e)
        {
            var form = new FormDataLoadSettings(loadSettings);
            if (form.ShowDialog() != DialogResult.OK)
                return;
            radLabSearchResult.Text = "";
            radGridWid.DataSource = null;
            widDataTable = null;
            LoadData();
        }

        private void LoadData()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                var dt = new DataTable();
                string filter = loadSettings.filterType == FilterType.all ? "" : " and status = @status";
                string order = "Title";
                switch (loadSettings.orderType)
                {
                    case OrderType.byRevenue: order = "netrevenue"; break;
                    case OrderType.byResourceTitle: order = "ResourceTitle"; break;
                    case OrderType.byTitle: order = "Title"; break;
                    case OrderType.byAuthors: order = "composerauthor"; break;
                    case OrderType.byPerformers: order = "displayartistname"; break;
                }
                string orderDir = loadSettings.orderDir == 0 ? "asc" : "desc";

                cmd.CommandText = $@"
                    select Id, ResourceTitle, displayartistname, title, composerauthor, ISWC, status, wic, objId, t2.netrevenue 
                    from IdentMW t1 join IdentReportMwRecords t2 on t2.mwId = t1.id
                    where t2.ddexReportId = @ddexReportId and t2.PriorityIndex >= @firstRowIndex and t2.PriorityIndex <= @lastRowIndex
                    {filter}
                    order by {order} {orderDir}, Id
                    option(recompile)
                 ";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                cmd.Parameters.AddWithValue("@status", (int)loadSettings.filterType);
                cmd.Parameters.AddWithValue("@firstRowIndex", loadSettings.firstRowIndex);
                cmd.Parameters.AddWithValue("@lastRowIndex", loadSettings.lastRowIndex);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                radGridSales.DataSource = dt;
                widDataTable = dt;
            });

            string filterText = "";
            switch (loadSettings.filterType)
            {
                case FilterType.identified: filterText = "ІДЕНТИФІКОВАНІ твори"; break;
                case FilterType.notIdentified: filterText = "НЕ ІДЕНТИФІКОВАНІ твори"; break;
                case FilterType.notStarted: filterText = "НЕ ОБРОБЛЕНІ твори"; break;
                case FilterType.postponed: filterText = "ВІДКЛАДЕНІ твори"; break;
                case FilterType.notFound: filterText = "твори, ДЕ НАЗВА НЕ ЗНАЙДЕНА"; break;
                case FilterType.nameFoundNoAuthor: filterText = "твори, ДЕ НАЗВА ЗНАЙДЕНА, АВТОР НЕ ЗНАЙДЕНИЙ,"; break;
                case FilterType.nameFoundOneAuthor: filterText = "твори, ДЕ НАЗВА ЗНАЙДЕНА, ЄДИНИЙ АВТОР ЗНАЙДЕНИЙ,"; break;
                case FilterType.nameFoundManyAuthors: filterText = "твори, ДЕ НАЗВА ЗНАЙДЕНА, ДЕКІЛЬКА АВТОРІВ ЗНАЙДЕНО,"; break;
                case FilterType.altNameFoundNoAuthor: filterText = "твори, ДЕ АЛЬТЕРНАТИВНА НАЗВА ЗНАЙДЕНА, АВТОР НЕ ЗНАЙДЕНИЙ,"; break;
                case FilterType.altNameFoundOneAuthor: filterText = "твори, ДЕ АЛЬТЕРНАТИВНА НАЗВА ЗНАЙДЕНА, ЄДИНИЙ АВТОР ЗНАЙДЕНИЙ,"; break;
                case FilterType.altNameFoundManyAuthors: filterText = "твори, ДЕ АЛЬТЕРНАТИВНА НАЗВА ЗНАЙДЕНА, ДЕКІЛЬКА АВТОРІВ ЗНАЙДЕНО,"; break;
                case FilterType.all: filterText = "ВСІ твори"; break;
            }
            string orderText = "";
            switch (loadSettings.orderType)
            {
                case OrderType.byRevenue: orderText = "ПРИБУТКУ"; break;
                case OrderType.byResourceTitle: orderText = "НАЗВИ ЗАПИСУ"; break;
                case OrderType.byTitle: orderText = "НАЗВИ ТВОРУ"; break;
                case OrderType.byAuthors: orderText = "ІМЕНІ АВТОРА"; break;
                case OrderType.byPerformers: orderText = "ВИКОНАВЦЯ"; break;
            }
            string dirText = loadSettings.orderDir == OrderDir.asc ? "ЗРОСТАННЯМ" : "СПАДАННЯМ";
            radSsInfo.Items[0].Text = $"Завантажено {filterText} в діапазоні {loadSettings.firstRowIndex} - {loadSettings.lastRowIndex}.";
            //radLabLoadSettings.Text = $"Завантажено {filterText} в діапазоні {loadSettings.firstRowIndex} - {loadSettings.lastRowIndex}.";

            if (radGridSales.Rows.Count > 0)
                radGridSales.CurrentRow = radGridSales.Rows[0];
        }

        //private void radComboSearchType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        //{
            //radGridWid.DataSource = null;
            //widDataTable = null;
        //}

        private Status DoSearch(string colName, List<string> variants, SearchScope searchScope, SearchMethod searchMethod)
        {
            if (variants.Count == 0)
            {
                if (!isAutoMode)
                    radGridWid.DataSource = null;
                radLabSearchResult.Text = "Музичні твори не знайдені";
                return Status.notFound;
            }

            Status res;
            DataTable dt = SearchByColName(colName, variants, searchScope, searchMethod);
            //DataTable dt = Helpers.SearchMsByColName(colName, variants);

            if (dt.Rows.Count == 0)
            {
                if (colName == "name")
                {
                    dt = SearchByAltTitle(variants, searchScope);
                    //dt = Helpers.SearchMsByAltTitle(variants);
                    if (dt.Rows.Count == 0)
                    {
                        radLabSearchResult.Text = "Музичні твори не знайдені";
                        res = Status.notFound;
                    }
                    else
                    {
                        radLabSearchResult.Text = $"Знайдено {dt.Rows.Count} музичних творів за точним співпадінням альтернативної назви";
                        res = Status.altNameFoundNoAuthor;
                    }
                }
                else
                {
                    radLabSearchResult.Text = "Музичні твори не знайдені";
                    res = Status.notFound;
                }
            }
            else
            {
                if (colName == "name")
                    radLabSearchResult.Text = $"Знайдено {dt.Rows.Count} музичних творів за точним співпадінням назви";
                else
                    radLabSearchResult.Text = $"Знайдено {dt.Rows.Count} музичних творів";
                res = Status.nameFoundNoAuthor;
            }

            if (!isAutoMode)
                radGridWid.DataSource = dt;
            widDataTable = dt;
            return res;
        }

        private void SearchByIswc(SearchMethod searchMethod)
        {
            DataTable dt = SearchByIswc(radComboSearchText.Text, searchMethod);
            radGridWid.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                radLabSearchResult.Text = "Музичні твори не знайдені";
            }
            else
            {
                radLabSearchResult.Text = $"Знайдено {dt.Rows.Count} музичних творів за кодом ISWC";
            }
        }

        private void SearchByPerformer(SearchScope searchScope, SearchMethod searchMethod)
        {
            DataTable dt = SearchByPerformer(radComboSearchText.Text, searchScope, searchMethod);
            radGridWid.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                radLabSearchResult.Text = "Музичні твори не знайдені";
            }
            else
            {
                radLabSearchResult.Text = $"Знайдено {dt.Rows.Count} музичних творів за виконавцем";
            }
        }

        private void radBtnSearch_Click(object sender, EventArgs e)
        {
            if (radGridSales.SelectedRows.Count == 0)
                return;

            string textTrimmed = radComboSearchText.Text.Trim();
            if (string.IsNullOrEmpty(textTrimmed))
            {
                MessageBox.Show("Не введено інформацію для пошуку", "Ідентифікація творів", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SearchScope searchScope;
            if (sender == radBtnSearchWid)
                searchScope = SearchScope.Wid;
            else if (sender == radBtnSearchMs)
                searchScope = SearchScope.Ms;
            else
                searchScope = SearchScope.Both;

            SearchMethod searchMethod;
            switch (radComboSearchMethod.SelectedIndex)
            {
                case 0: searchMethod = SearchMethod.Exact; break;
                case 1: searchMethod = SearchMethod.Like; break;
                case 2: searchMethod = SearchMethod.Includes; break;
                default: searchMethod = SearchMethod.Exact; break;
            }

            if (searchMethod == SearchMethod.Like && textTrimmed.Length < 3)
            {
                if (MessageBox.Show("Текст для пошуку надто короткий і може привести до великої кількості співпадінь, внаслідок чого пошук і відображення результатів може зайняти значний час. Виконати пошук?"
                    , "Ідентифікація творів", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
            }


            radLabSearchResult.Text = "";
            string colName;
            switch (radComboSearchColumn.SelectedIndex)
            {
                case 0: colName = "name"; break;
                case 1: SearchByIswc(searchMethod); return;
                case 2: SearchByPerformer(searchScope, searchMethod); return;
                default: colName = "name"; break;
            }

            List<string> variants = new List<string>();
            //foreach (var item in radComboSearchText.Items)
            //variants.Add(item.Text);
            variants.Add(radComboSearchText.Text);

            DoSearch(colName, variants, searchScope, searchMethod);
        }

        private void radGridSales_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                radGridWid.DataSource = null;
                widDataTable = null;
            }
            catch (Exception) { }
        }

        private void ChangeStatus(Status status, int wic, int objId)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                foreach (var gridRow in radGridSales.SelectedRows)
                {
                    if (!gridRow.IsVisible)
                        continue;
                    var cells = gridRow.Cells;
                    cmd.CommandText = @"
                        update IdentMW
                        set status = @status, wic = @wic, objId = @objId
                        where Id = @Id
                        ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Id", (int)cells["Id"].Value);
                    //cmd.Parameters.AddWithValue("@ResourceTitle", (string)cells["ResourceTitle"].Value);
                    //cmd.Parameters.AddWithValue("@displayartistname", (string)cells["displayartistname"].Value);
                    //cmd.Parameters.AddWithValue("@title", (string)cells["title"].Value);
                    //cmd.Parameters.AddWithValue("@composerauthor", (string)cells["composerauthor"].Value);
                    cmd.Parameters.AddWithValue("@status", (int)status);
                    cmd.Parameters.AddWithValue("@wic", wic);
                    cmd.Parameters.AddWithValue("@objId", objId);
                    cmd.ExecuteNonQuery();

                    cells["status"].Value = (int)status;
                    cells["wic"].Value = wic;
                    cells["objId"].Value = objId;
                }
            });
        }

        private void radGridWid_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column != null && e.Column.Name == "action")
            {
                int wic = radGridWid.CurrentRow == null || radGridWid.CurrentRow.Cells["Wic"].Value is DBNull ? 0 : (int)radGridWid.CurrentRow.Cells["Wic"].Value;
                int objId = radGridWid.CurrentRow == null || radGridWid.CurrentRow.Cells["objId"].Value is DBNull ? 0 : (int)radGridWid.CurrentRow.Cells["objId"].Value;
                ChangeStatus(Status.identified, wic, objId);
            }
        }

        private void radBntReject_Click(object sender, EventArgs e)
        {
            ChangeStatus(Status.notIdentified, 0, 0);
        }

        private void radBntPostpone_Click(object sender, EventArgs e)
        {
            ChangeStatus(Status.postponed, 0, 0);
        }

        private void radGridSales_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
        {
            if (e.NewCell == null)
                return;
            int colIndex = e.NewCell.ColumnInfo.Index;
            if (colIndex > 5 || colIndex == 0)
                return;
            string text = e.NewCell.Value.ToString();
            radComboSearchText.Items.Clear();
            List<string> variants;
            if (colIndex > 2)
                variants = TransLiterator.BuildVariants(GetAuthorForMatch(text, text));
            else
                variants = TransLiterator.BuildVariants(text);
            radComboSearchText.Items.Add(text);
            foreach (var variant in variants)
                radComboSearchText.Items.Add(variant);
            //radComboSearchText.Text = e.NewCell.Value.ToString();
            radComboSearchText.SelectedIndex = radComboSearchText.Items.Count > 1 ? 1 : 0;

            //radComboSearchColumn.SelectedIndex = e.NewCell.ColumnInfo.Index < 3 ? 0 :
            //e.NewCell.ColumnInfo.Index == 3 ? 1 : 2;
            //radComboSearchColumn.SelectedIndex = 0;

            string text1 = e.NewCell.RowInfo.Cells["ComposerAuthor"].Value.ToString();
            string text2 = e.NewCell.RowInfo.Cells["DisplayArtistname"].Value.ToString();
            radGridWid.MasterView.TableSearchRow.Search(TransLiterator.BuildVariants(GetAuthorForMatch(text1, text2))[0]);
        }

        private bool HasCyrillic(GridViewRowInfo row)
        {
            for (int i = 1; i < 5; i++)
            {
                string value = (string)row.Cells[i].Value;
                if (Regex.IsMatch(value, @"\p{IsCyrillic}"))
                    return true;
            }
            return false;
        }

        private bool HasNoLatinOrCyrillic(GridViewRowInfo row)
        {
            for (int i = 1; i < 3; i++)
            {
                string value = (string)row.Cells[i].Value;
                if (Regex.IsMatch(value, @"\p{IsCyrillic}") || Regex.IsMatch(value, "[a-zA-Z]"))
                    return false;
            }
            return true;
        }

        private void radBtnApplyFilter_Click(object sender, EventArgs e)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                foreach (var row in radGridSales.Rows)
                {
                    int rowStatus = (int)row.Cells["Status"].Value;
                    switch (radComboFilterByStatus.SelectedIndex)
                    {
                        case 0: row.IsVisible = true; break;
                        case 1: row.IsVisible = rowStatus == 0; break;
                        case 2: row.IsVisible = rowStatus == 1; break;
                        case 3: row.IsVisible = rowStatus == 2; break;
                        case 4: row.IsVisible = rowStatus == 3; break;
                        case 5: row.IsVisible = rowStatus == 10; break;
                        case 6: row.IsVisible = rowStatus == 20; break;
                        case 7: row.IsVisible = rowStatus == 21; break;
                        case 8: row.IsVisible = rowStatus == 22; break;
                        case 9: row.IsVisible = rowStatus == 30; break;
                        case 10: row.IsVisible = rowStatus == 31; break;
                        case 11: row.IsVisible = rowStatus == 32; break;

                        default: row.IsVisible = true; break;
                    }

                    if (row.IsVisible)
                    {
                        switch (radComboFilterSpecial.SelectedIndex)
                        {
                            case 1: row.IsVisible = HasCyrillic(row); break;
                            case 2: row.IsVisible = HasNoLatinOrCyrillic(row); break;
                            default: row.IsVisible = true; break;
                        }
                    }
                }
                if (radGridSales.CurrentRow != null && !radGridSales.CurrentRow.IsVisible)
                {
                    radComboSearchText.Items.Clear();
                    radComboSearchText.Text = "";
                    radGridSales.CurrentRow = null;
                    radGridWid.DataSource = null;
                    widDataTable = null;
                }

            });
        }

        private void radGridSales_DoubleClick(object sender, EventArgs e)
        {
            //AutoProcessAllRows();
            AutoProcessCurRow();
        }

        private void AutoProcessAllRows()
        {
            if (radGridSales.CurrentRow == null)
                return;
            isAutoMode = true;
            radGridWid.DataSource = null;
            widDataTable = null;
            for (int cycle = 0; cycle < 1; cycle++)
            {
                while (AutoProcessCurRow())
                {
                    int i;
                    for (i = radGridSales.CurrentRow.Index + 1; i < radGridSales.Rows.Count; i++)
                    {
                        if (radGridSales.Rows[i].IsVisible)
                        {
                            radGridSales.Rows[i].IsCurrent = true;
                            radGridSales.Refresh();
                            break;
                        }
                    }
                    if (i == radGridSales.Rows.Count)
                        break;
                }
                //loadSettings.firstRowIndex += 1000;
                //loadSettings.lastRowIndex += 1000;
                //LoadData();
            }
            isAutoMode = false;
        }

        private bool AutoProcessCurRow()
        {
            if (radGridSales.CurrentRow == null)
                return true;
            var cells = radGridSales.CurrentRow.Cells;
            int status = (int)cells["Status"].Value;
            if (status > 0 && status < 3)
                return true;
            string resourceTitle = (string)cells["ResourceTitle"].Value;
            string title = (string)cells["Title"].Value;
            string composerAuthor = (string)cells["ComposerAuthor"].Value;
            string displayArtistName = (string)cells["DisplayArtistName"].Value;

            List<string> resourceTitles = TransLiterator.BuildVariants(resourceTitle);
            resourceTitles.Add(resourceTitle);
            List<string> titles = TransLiterator.BuildVariants(title);
            titles.Add(title);

            string match = "";
            string author = GetAuthorForMatch(composerAuthor, displayArtistName);
            if (author == "")
            {
                ChangeStatus(Status.notFound, 0, 0);
                return true;
            }

            List<string> vnts = TransLiterator.BuildVariants(author);
            match = vnts.Count > 1 ? vnts[1] : vnts[0];
            if (match == "")
            {
                ChangeStatus(Status.notFound, 0, 0);
                return true;
            }

            List<string> variants = new List<string>();
            for (int i = 0; i < resourceTitles.Count; i++)
            {
                string text = resourceTitles[i].Trim();
                if (text == "" || text == "-")
                    continue;
                if (!Regex.IsMatch(text, @"\p{IsCyrillic}") && !Regex.IsMatch(text, "[a-zA-Z]"))
                    continue;
                variants.Add(text);
            }
            for (int i = 0; i < titles.Count; i++)
            {
                string text = titles[i].Trim();
                if (text == "" || text == "-")
                    continue;
                if (!Regex.IsMatch(text, @"\p{IsCyrillic}") && !Regex.IsMatch(text, "[a-zA-Z]"))
                    continue;
                variants.Add(text);
            }

            if (variants.Count == 0)
            {
                ChangeStatus(Status.notIdentified, 0, 0);
                return true;
            }

            Status searchResult = DoSearch("name", variants, SearchScope.Both, SearchMethod.Exact);
            if (searchResult == Status.notFound)
            {
                ChangeStatus(Status.notFound, 0, 0);
                return true;
            }
            else
            {
                int matchCount = 0;
                foreach (DataRow row in widDataTable.Rows)
                {
                    for (int i = 3; i < 5; i++)
                    {
                        string text = row.ItemArray[i] is DBNull ? "" : (string)row.ItemArray[i];
                        if (text.IndexOf(match, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            matchCount++;
                            break; // Only count of rows is of interest
                        }
                    }
                }
                searchResult += matchCount == 0 ? 0 : matchCount == 1 ? 1 : 2;
                ChangeStatus(searchResult, 0, 0);
                if (!isAutoMode)
                    radGridWid.MasterView.TableSearchRow.Search(match);
                return true;
                //else
                //{
                //radGridWid.MasterView.TableSearchRow.Search(match.Substring(0, match.Length - 1));
                //return true;
                //}
            }

        }

        private void radBtnAutoProcessAllRows_Click(object sender, EventArgs e)
        {
            AutoProcessAllRows();
        }

        private void radGridSales_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            radLabSearchResult.Text = "";
            radGridWid.DataSource = null;
            widDataTable = null;
        }

        private void radBtnStatistics_Click(object sender, EventArgs e)
        {
            FormStatistics form = new FormStatistics();
            form.ddexReportId = ddexReportId;
            form.Show();
        }
    }
}
