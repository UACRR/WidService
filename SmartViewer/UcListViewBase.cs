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
        public class ItemSelectedEventArgs : EventArgs
        {
            public ListViewItem Item { get; set; }
        }
        public event EventHandler<ItemSelectedEventArgs> ItemSelected;

        public string SqlSelect { get; set; }

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
            ClearContent();
            FillData(LoadData());
        }

        public void UpdateContent(SqlCommand cmd)
        {
            ClearContent();
            FillData( LoadData(cmd));
        }

        public void ClearContent()
        {
            lvData.Items.Clear();
        }

        private void Configure()
        {

        }

        private DataTable LoadData()
        {
            DataTable dataTable = new DataTable();
                
            Helpers.RunSqlMediaService(cmd =>
            {
                SqlDataAdapter adapter = new SqlDataAdapter(SqlSelect, cmd.Connection);
                adapter.Fill(dataTable);
            });
            return dataTable;
        }

        private DataTable LoadData(SqlCommand cmd)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            return dataTable;
        }

        private void FillData(DataTable dataTable)
        {
            lvData.BeginUpdate();
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
            lvData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvData.EndUpdate();

        }

        private void lvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemSelected?.Invoke(this, new ItemSelectedEventArgs {
                Item = lvData.SelectedItems.Count == 0 ? null : lvData.SelectedItems[0] 
            });
        }
    }
}
