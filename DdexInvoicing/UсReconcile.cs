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
using static InvoicingLib.IdentReconciler;

namespace DdexInvoicing
{
    public partial class UсReconcile : UserControl
    {
        private int _ddexReportId;
        private IdentReconciler _ir;

        public UсReconcile()
        {
            InitializeComponent();
        }

        public void SetReport(int ddexReportId)
        {
            _ddexReportId = ddexReportId;
        }

        private void UсReconcile_Load(object sender, EventArgs e)
        {
            labPrompt.Text = "В процесі автоматичної ідентифікації за кодом ISWC можливе невірне пов'язання рядків звітів з музичними творами в базі даних WID.\r\n" +
                "З метою перевірки поставте відповідні відмітки навпроти творів, що наводяться нижче. " +
                "Відмітки заносяться одразу в робочу таблицю і не потребують спеціальних дій, щоб іх запам'ятати.\r\n" +
                "Для того, щоб результати перевірки були застосовані до ідентифікаційної інформації, натисніть на Застосувати. " +
                "Це варто робити після того, як не залишиться неопрацьованих рядків.\r\n" +
                "Оброблені твори після застосування не показуються.";

            ConfigureGridRecords();
            ConfigureStatistics();

            int i = 0;
            panelPages.Pages[i++].Name = "All";
            panelPages.Pages[i++].Name = "Unprocessed";
            panelPages.Pages[i++].Name = "Confirmed";
            panelPages.Pages[i++].Name = "Autoconfirmed";
            panelPages.Pages[i++].Name = "Rejected";
            panelPages.Pages[i++].Name = "NeedReident";

            panelPages.Pages[0].Controls.Add(gridRecords);
            panelPages.SelectedPage = panelPages.Pages[0];

            timerLoad.Enabled = true; ;
        }

        private void ConfigureStatistics()
        {
            int i = 0;
            gridStatistics.Columns[i++].FieldName = "scope";
            gridStatistics.Columns[i++].FieldName = "total";
            gridStatistics.Columns[i++].FieldName = "unprocessed";
            gridStatistics.Columns[i++].FieldName = "confirmed";
            gridStatistics.Columns[i++].FieldName = "autoconfirmed";
            gridStatistics.Columns[i++].FieldName = "rejected";
            gridStatistics.Columns[i++].FieldName = "needsident";
        }

        private void FillStatistics()
        {
            var stt = _ir.GetStatistics(cbFilter.SelectedIndex);

            var dt = new DataTable();
            dt.Columns.Add("scope");
            dt.Columns.Add("total");
            dt.Columns.Add("unprocessed");
            dt.Columns.Add("confirmed");
            dt.Columns.Add("autoconfirmed");
            dt.Columns.Add("rejected");
            dt.Columns.Add("needsident");

            var dr = dt.NewRow();
            dr["scope"] = "Для звіту в цілому";
            dr["total"] = stt.Total.ToString();
            dr["unprocessed"] = stt.Unprocessed.ToString();
            dr["confirmed"] = stt.Confirmed.ToString();
            dr["autoconfirmed"]=  stt.AutoConfirmed.ToString();
            dr["rejected"] = stt.Rejected.ToString();
            dr["needsident"] = stt.NeedsReident.ToString();
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["scope"] = "Для обраних записів";
            dr["total"] = stt.TotalInBlock.ToString();
            dr["unprocessed"] = stt.UnprocessedInBlock.ToString();
            dr["confirmed"] = stt.ConfirmedInBlock.ToString();
            dr["autoconfirmed"] = stt.AutoConfirmedInBlock.ToString();
            dr["rejected"] = stt.RejectedInBlock.ToString();
            dr["needsident"] = stt.NeedsReidentInBlock.ToString();
            dt.Rows.Add(dr);

            gridStatistics.DataSource = dt;
        }

        private void ConfigureGridRecords()
        {
            var gmtCols = gridRecords.MasterTemplate.Columns;
            gmtCols.Clear();
            gmtCols.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
                new GridViewTextBoxColumn {
                    Name = "SeqNr",
                    HeaderText = "№",
                    FieldName = "SeqNr",
                    WrapText = true,
                    ReadOnly = true,
                    AutoSizeMode = BestFitColumnMode.AllCells,
                },
                new GridViewTextBoxColumn {
                    Name = "MwId",
                    HeaderText = "MwId",
                    FieldName = "MwId",
                    WrapText = true,
                    ReadOnly = true,
                    IsVisible = false,
                    AutoSizeMode = BestFitColumnMode.AllCells,
                },
                new GridViewTextBoxColumn {
                    Name = "Title",
                    HeaderText = "Назва у звіті",
                    FieldName = "Title",
                    WrapText = true,
                    ReadOnly = true,
                    AutoSizeMode = BestFitColumnMode.AllCells,
                    AllowResize = true,
                },
                new GridViewTextBoxColumn {
                    Name = "TitleFromIswcInWid",
                    HeaderText = "Назва у WID",
                    FieldName = "TitleFromIswcInWid",
                    WrapText = true,
                    ReadOnly = true,
                    AutoSizeMode = BestFitColumnMode.AllCells,
                    AllowResize = true,
                },
                new GridViewTextBoxColumn {
                    Name = "Artist",
                    HeaderText = "Виконавець",
                    FieldName = "Artist",
                    WrapText = true,
                    ReadOnly = true,
                    AutoSizeMode = BestFitColumnMode.AllCells,
                    AllowResize = true,
                },
                new GridViewTextBoxColumn {
                    Name = "IsAutoConfirmed",
                    HeaderText = "Пцдтверджено автоматично",
                    FieldName = "IsAutoConfirmed",
                    TextAlignment = ContentAlignment.MiddleCenter,
                    WrapText = true,
                    ReadOnly = true,
                    AllowResize = false,
                    Width = 100,
                },
                new GridViewCheckBoxColumn {
                    Name = "IsConfirmed",
                    HeaderText = "Підтвердити",
                    FieldName = "IsConfirmed",
                    WrapText = true,
                    ReadOnly = true,
                    AllowResize = false,
                    Width = 100,
                },
                new GridViewCheckBoxColumn {
                    Name = "IsRejected",
                    HeaderText = "Відхилити",
                    FieldName = "IsRejected",
                    WrapText = true,
                    ReadOnly = true,
                    AllowResize = false,
                    Width = 100,
                },
                new GridViewCheckBoxColumn {
                    Name = "NeedsReIdent",
                    HeaderText = "Ідентифікувати в ручну",
                    FieldName = "NeedsReIdent",
                    WrapText = true,
                    ReadOnly = true,
                    AllowResize = false,
                    Width = 100,
                },
            });

            gridRecords.Visible = false;
        }

       private void panelPages_SelectedPageChanged(object sender, EventArgs e)
        {
            panelPages.SelectedPage.Controls.Add(gridRecords);
            switch (panelPages.SelectedPage.Name)
            {
                case "All":
                    RefreshGridRecords(_ir.GetAllEntries(cbFilter.SelectedIndex));
                    break;
                case "Unprocessed":
                    RefreshGridRecords(_ir.GetUnprocessedEntries(cbFilter.SelectedIndex));
                    break;
                case "Confirmed":
                    RefreshGridRecords(_ir.GetConfirmedEntries(cbFilter.SelectedIndex));
                    break;
                case "Autoconfirmed":
                    RefreshGridRecords(_ir.GetAutoconfirmedEntries(cbFilter.SelectedIndex));
                    break;
                case "Rejected":
                    RefreshGridRecords(_ir.GetRejectedEntries(cbFilter.SelectedIndex));
                    break;
                case "NeedReident":
                    RefreshGridRecords(_ir.GetNeedReidentEntries(cbFilter.SelectedIndex));
                    break;
            }
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            timerLoad.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            _ir = new IdentReconciler(_ddexReportId, ConfigurationManager.AppSettings["ConnectionStringDdex"]);
            _ir.Load();

            int pageCount = _ir.GetEntriesCount() / 1001 + 1;
            for (int pgIndex = 0; pgIndex < pageCount; pgIndex++)
            {
                cbFilter.Items.Add((pgIndex * 1000 + 1).ToString());
            }
            cbFilter.SelectedIndex = 0;

            FillStatistics();
            RefreshGridRecords(_ir.GetAllEntries(0));
            gridRecords.Visible = true;
            Cursor.Current = Cursors.Default;
        }

        private void cbFilter_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            panelPages.SelectedPage = panelPages.Pages[0];
            FillStatistics();
            RefreshGridRecords(_ir.GetAllEntries(e.Position));
        }

        private void RefreshGridRecords(List<IdentReconciler.ReconcileEntry> dataSource)
        {
            Cursor.Current = Cursors.WaitCursor;
            gridRecords.DataSource = dataSource;
            foreach (GridViewColumn column in gridRecords.Columns)
            {
                if (column.AllowResize)
                {
                    column.BestFit();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void ToggleCheckBox(string columnName)
        {
            IdentReconciler.ReconcileEntry curEntry = (IdentReconciler.ReconcileEntry)gridRecords.CurrentRow.DataBoundItem;
            bool newValue;
            switch (columnName)
            {
                case "IsConfirmed":
                    newValue = !curEntry.IsConfirmed;
                    break;
                case "IsRejected":
                    newValue = !curEntry.IsRejected;
                    break;
                case "NeedsReIdent":
                    newValue = !curEntry.NeedsReIdent;
                    break;
                default:
                    return;
            }

            Cursor.Current = Cursors.WaitCursor;
            List<ReconcileEntry> changedEntries = new List<ReconcileEntry>();
            gridRecords.SelectedRows.ToList().ForEach(x =>
            {
                IdentReconciler.ReconcileEntry entry = (IdentReconciler.ReconcileEntry)x.DataBoundItem;
                switch (columnName)
                {
                    case "IsConfirmed":
                        entry.IsConfirmed = newValue;
                        if (newValue)
                        {
                            entry.IsRejected = false;
                            entry.NeedsReIdent = false;
                        }
                        break;
                    case "IsRejected":
                        entry.IsRejected = newValue;
                        if (newValue)
                        {
                            entry.IsConfirmed = false;
                            entry.NeedsReIdent = false;
                        }
                        break;
                    case "NeedsReIdent":
                        entry.NeedsReIdent = newValue;
                        if (newValue)
                        {
                            entry.IsConfirmed = false;
                            entry.IsRejected = false;
                        }
                        break;
                    default:
                        return;
                }
                changedEntries.Add(entry);
                x.InvalidateRow();
            });
            _ir.SaveFlagsIntoDb(changedEntries);
        }

        private void gridRecords_CellClick(object sender, GridViewCellEventArgs e)
        {
            ToggleCheckBox(e.Column.Name);
            gridRecords.Refresh();
            Cursor.Current = Cursors.Default;
        }

        private void gridRecords_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            return;
        }

        private void gridRecords_CellValueChanged(object sender, GridViewCellEventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {

            var stt = _ir.GetStatistics(0);
            var prompt = stt.Unprocessed > 0 ? "Залишились необроблені записи. Все одно застосувати?" : "Застосувати?";
            if (MessageBox.Show(prompt,
                    "Перевірка автоматичної ідентифікації"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            Cursor.Current = Cursors.WaitCursor;
            _ir.ApplyToReport();
            _ir.Load();
            panelPages.SelectedPage = panelPages.Pages[0];
            RefreshGridRecords(_ir.GetAllEntries(cbFilter.SelectedIndex));
            Cursor.Current = Cursors.Default;
        }

        private void btnRefreshStatistics_Click(object sender, EventArgs e)
        {
            FillStatistics();
        }

        private void gridRecords_KeyDown(object sender, KeyEventArgs e)
        {
            ReconcileEntry entry = (ReconcileEntry)gridRecords.CurrentRow.DataBoundItem;
            switch (e.KeyCode)
            {
                case Keys.D1:
                case Keys.NumPad1:
                    entry.IsConfirmed = true;
                    entry.IsRejected = false;
                    entry.NeedsReIdent = false;
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    entry.IsConfirmed = false;
                    entry.IsRejected = true;
                    entry.NeedsReIdent = false;
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    entry.IsConfirmed = false;
                    entry.IsRejected = false;
                    entry.NeedsReIdent = true;
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    entry.IsConfirmed = false;
                    entry.IsRejected = false;
                    entry.NeedsReIdent = false;
                    break;
                default:
                    return;
            }
            _ir.SaveFlagsIntoDb(new List<ReconcileEntry> { entry });
            gridRecords.CurrentRow.InvalidateRow();
            gridRecords.Refresh();
        }
    }
}
