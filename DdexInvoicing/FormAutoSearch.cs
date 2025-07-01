using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicing
{
    public partial class FormAutoSearch : Form
    {
        private int _ddexReportId;
        public FormAutoSearch(int ddexReportId)
        {
            InitializeComponent();
            _ddexReportId = ddexReportId;
        }

        private void FormAutoSearch_Load(object sender, EventArgs e)
        {
            Configure();
            FillLvSteps();
        }

        private void Configure()
        {
            lvSteps.FullRowSelect = true;
            lvSteps.View = View.Details;
            lvSteps.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvSteps.HideSelection = false;
            lvSteps.MultiSelect = false;
            lvSteps.Columns.Add("Дія", 300);
            lvSteps.Columns.Add("Деталі", 300);
        }

        private void FillLvSteps()
        {
            lvSteps.Items.Clear();
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "select Id, Name, Status from AutoSearch..SearchSteps order by Id";
                using (var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        var item = lvSteps.Items.Add(r.GetString(1));
                        var status = r.GetInt32(2);
                        var statusText = status == 0 ?
                            "" : status == 1 ? "Виконується ..." : "Завершено";
                        item.SubItems.Add(statusText);
                    }
                }
            });
        }
    }
}
