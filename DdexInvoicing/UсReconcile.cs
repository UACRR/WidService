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
                "Відмітки заносяться одразу в робочій таблиці і не потребують спеціальних дій, щоб іх запам'ятати.\r\n" +
                "Для того, щоб результати перевірки були застосовані до ідентифікаційної інформації, натисніть на Застосувати. " +
                "Це варто робити після того, як не залишиться неопрацьованих рядків.";

            ConfigureGridRecords();

            FillStatistics();

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

        private void FillStatistics()
        {
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
            dr["total"] = "356";
            dr["unprocessed"] = "356";
            dr["confirmed"] = "356";
            dr["autoconfirmed"] = "11";
            dr["rejected"] = "23";
            dr["needsident"] = "40";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["scope"] = "Для обраних записів";
            dr["total"] = "356";
            dr["unprocessed"] = "34";
            dr["confirmed"] = "34";
            dr["autoconfirmed"] = "2231";
            dr["rejected"] = "11";
            dr["needsident"] = "24";
            dt.Rows.Add(dr);

            int i = 0;
            gridStatistics.Columns[i++].FieldName = "scope";
            gridStatistics.Columns[i++].FieldName = "total";
            gridStatistics.Columns[i++].FieldName = "confirmed";
            gridStatistics.Columns[i++].FieldName = "unprocessed";
            gridStatistics.Columns[i++].FieldName = "autoconfirmed";
            gridStatistics.Columns[i++].FieldName = "rejected";
            gridStatistics.Columns[i++].FieldName = "needsident";
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
                    AutoSizeMode = BestFitColumnMode.AllCells,
                },
                new GridViewTextBoxColumn {
                    Name = "MwId",
                    HeaderText = "MwId",
                    FieldName = "MwId",
                    WrapText = true,
                    IsVisible = false,
                    AutoSizeMode = BestFitColumnMode.AllCells,
                },
                new GridViewTextBoxColumn {
                    Name = "Title",
                    HeaderText = "Назва у звіті",
                    FieldName = "Title",
                    WrapText = true,
                    AutoSizeMode = BestFitColumnMode.AllCells,
                    AllowResize = true,
                },
                new GridViewTextBoxColumn {
                    Name = "TitleFromIswcInWid",
                    HeaderText = "Назва у WID",
                    FieldName = "TitleFromIswcInWid",
                    WrapText = true,
                    AutoSizeMode = BestFitColumnMode.AllCells,
                    AllowResize = true,
                },
                new GridViewTextBoxColumn {
                    Name = "Artist",
                    HeaderText = "Виконавець",
                    FieldName = "Artist",
                    WrapText = true,
                    AutoSizeMode = BestFitColumnMode.AllCells,
                    AllowResize = true,
                },
                new GridViewCheckBoxColumn {
                    Name = "IsAutoConfirmed",
                    HeaderText = "Пцдтверджено автоматично",
                    FieldName = "IsAutoConfirmed",
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
                    AllowResize = false,
                    Width = 100,
                },
                new GridViewCheckBoxColumn {
                    Name = "IsRejected",
                    HeaderText = "Відхилити",
                    FieldName = "IsRejected",
                    WrapText = true,
                    AllowResize = false,
                    Width = 100,
                },
                new GridViewCheckBoxColumn {
                    Name = "NeedsReIdent",
                    HeaderText = "Ідентифікувати в ручну",
                    FieldName = "NeedsReIdent",
                    WrapText = true,
                    AllowResize = false,
                    Width = 100,
                },
            });

            gridRecords.Visible = false;
        }

        private void gridStatistics_Click(object sender, EventArgs e)
        {

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

            RefreshGridRecords(_ir.GetEntriesPage(0));
            gridRecords.Visible = true;
            Cursor.Current = Cursors.Default;
        }

        private void cbFilter_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            RefreshGridRecords(_ir.GetEntriesPage(e.Position));
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
    }
}
