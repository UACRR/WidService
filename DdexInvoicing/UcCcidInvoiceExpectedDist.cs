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
    public partial class UcCcidInvoiceExpectedDist : UserControl
    {
        public UcCcidInvoiceExpectedDist()
        {
            InitializeComponent();
        }

        public void Init(int fileId)
        {
            lvResult.Columns.Clear();
            lvResult.Columns.Add("№пп", 70, HorizontalAlignment.Center);
            lvResult.Columns.Add("Код в СМАРТ", 70, HorizontalAlignment.Center);
            lvResult.Columns.Add("Міжнародний код", 120);
            lvResult.Columns.Add("Тип правовласності", 100, HorizontalAlignment.Center);
            lvResult.Columns.Add("Товариство", 60, HorizontalAlignment.Center);
            lvResult.Columns.Add("Сума", 60, HorizontalAlignment.Center);
            lvResult.Columns.Add("Назва правовласника", 260, HorizontalAlignment.Center);

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"select custId, IpBaseNr, rgtType, soc, amount, name
                    from CcidInFileTestExpectedDist
                    where fileId = @fileId
                    order by amount desc";
                cmd.Parameters.AddWithValue("@fileId", fileId);

                using (var r = cmd.ExecuteReader())
                {
                    var idx = 1;
                    while(r.Read())
                    {
                        var item = lvResult.Items.Add(idx.ToString());
                        item.SubItems.Add(r.GetInt32(0) == 0 ? "" : r.GetInt32(0).ToString());
                        item.SubItems.Add(r.IsDBNull(1) ? "" : r.GetString(1).ToString());
                        item.SubItems.Add(r.IsDBNull(2) ? "" : r.GetString(2).ToString());
                        item.SubItems.Add(r.IsDBNull(3) ? "" : r.GetInt32(3).ToString());
                        item.SubItems.Add(r.IsDBNull(4) ? "" : r.GetDecimal(4).ToString());
                        item.SubItems.Add(r.IsDBNull(5) ? "" : r.GetString(5).ToString());
                        idx++;
                    }
                }

            });
        }

        private void radBtnCopy_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            for(var idx = 0; idx < lvResult.Columns.Count; idx++)
            {
                if(idx != 0)
                {
                    sb.Append('\t');
                }
                sb.Append(lvResult.Columns[idx].Text);
            }
            sb.Append($"\r\n");

            foreach(ListViewItem item in lvResult.Items)
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
    }
}
