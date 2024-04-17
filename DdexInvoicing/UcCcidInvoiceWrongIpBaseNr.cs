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
    public partial class UcCcidInvoiceWrongIpBaseNr : UserControl
    {
        public UcCcidInvoiceWrongIpBaseNr()
        {
            InitializeComponent();
        }

        public void Init(int fileId)
        {
            lvResult.Columns.Clear();
            lvResult.Columns.Add("Код в СМАРТ", 80, HorizontalAlignment.Center);
            lvResult.Columns.Add("Міжнародний код", 120);

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"select custId, ipBaseNr
                    from CcidInFileTestWrongIpBaseNr
                    where fileId = @fileId
                    order by custId";
                cmd.Parameters.AddWithValue("@fileId", fileId);

                using (var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        var item = lvResult.Items.Add(r.IsDBNull(0) ? "" : r.GetInt32(0).ToString());
                        item.SubItems.Add(r.IsDBNull(1) ? "" : r.GetString(1));
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
    }
}
