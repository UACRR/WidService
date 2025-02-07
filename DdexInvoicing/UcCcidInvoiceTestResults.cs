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

namespace DdexInvoicing
{
    public partial class UcCcidInvoiceTestResults : UserControl
    {
        private int _fileId;
        public UcCcidInvoiceTestResults()
        {
            InitializeComponent();
        }

        public void Init(int fileId)
        {
            _fileId = fileId;

            lvResult.Columns.Clear();
            lvResult.Columns.Add("Код тесту", 70, HorizontalAlignment.Center);
            lvResult.Columns.Add("Зміст тесту", 520);
            lvResult.Columns.Add("Критичний", 100, HorizontalAlignment.Center);
            lvResult.Columns.Add("Успіх", 60, HorizontalAlignment.Center);
            lvResult.Columns.Add("Помилка", 60, HorizontalAlignment.Center);

            FillLvResult();
        }

        private void FillLvResult()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"select t2.code, t2.description, t2.severity, t1.result
                    from CcidInFileTestResult t1
                        join CcidInFileTestType t2 on t1.ccidInFileTestType = t2.code
                    where t1.fileId = @fileId
                    order by t2.code";
                cmd.Parameters.AddWithValue("@fileId", _fileId);

                lvResult.Items.Clear();
                using (var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        var item = lvResult.Items.Add(r.GetInt32(0).ToString());
                        item.SubItems.Add(r.GetString(1));
                        item.SubItems.Add(r.GetInt32(2) == 0 ? "Так" : "Ні");
                        item.SubItems.Add(r.GetBoolean(3) ? "x" : "");
                        item.SubItems.Add(r.GetBoolean(3) ? "" : "x");
                    }
                }
            });
        }

        private void radBtnCopy_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            for (var idx = 0; idx < lvResult.Columns.Count; idx++)
            {
                if (idx != 0)
                {
                    sb.Append('\t');
                }
                sb.Append(lvResult.Columns[idx].Text);
            }
            sb.Append($"\r\n");

            foreach (ListViewItem item in lvResult.Items)
            {
                for (var idx = 0; idx < lvResult.Columns.Count; idx++)
                {
                    if (idx != 0)
                    {
                        sb.Append('\t');
                    }
                    sb.Append(item.SubItems[idx].Text);
                }
                sb.Append($"\r\n");
            }

            Clipboard.SetText(sb.ToString());

            MessageBox.Show("Дані передані в буфер обміну", "Операція завершена");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"
                    declare @ddeReportId int, @setCode int
                    select @ddeReportId = t2.ddexReportId, @setCode = t1.setCode 
                    from CcidInFile t1 join CcidInvoice t2 on t1.ccidInvoiceId = t2.Id where fileId  = @fileId

                    exec spCcidFileOutCheck @ddeReportId, @fileId, @setCode
                ";
                cmd.Parameters.AddWithValue("@fileId", _fileId);
                cmd.ExecuteNonQuery();
            });
            FillLvResult();
        }
    }
}
