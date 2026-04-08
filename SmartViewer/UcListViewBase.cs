using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SmartViewer
{
    public partial class UcListViewBase : UserControl
    {
        public class Data
        {
            public string CustId { get; set; }
            public string Customer { get; set; }
            public string Publisher { get; set; }
        }

        public string SqlSelect { get; set; }

        private List<Data> _data;

        public UcListViewBase()
        {
            InitializeComponent();
        }

        private void UcListViewBase_Load(object sender, EventArgs e)
        {
            Configure();
        }

        public void UpdateContent()
        {
            LoadData();
        }

        public void ClearContent()
        {
            lvData.Items.Clear();
        }

        private void Configure()
        {

        }

        private void LoadData()
        {
            Helpers.RunSqlMediaService(cmd =>
            {
                SqlDataAdapter adapter = new SqlDataAdapter(SqlSelect, cmd.Connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                lvData.View = View.Details;
                lvData.GridLines = true;
                lvData.FullRowSelect = true;

                lvData.Columns.Clear();
                lvData.Items.Clear();

                var colIdx = 0;
                foreach (DataColumn col in dataTable.Columns)
                {
                    lvData.Columns.Add(col.ColumnName, -1);
                    colIdx++;
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    for (int i = 1; i < dataTable.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvData.Items.Add(item);
                }

                lvData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            });
        }

        private void FillData()
        {

        }
    }
}
