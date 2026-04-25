using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CcidViewer
{
    public partial class UcListViewBase : UserControl
    {
        public class ItemSelectedEventArgs : EventArgs
        {
            public ListViewItem ListViewItem { get; }

            public ItemSelectedEventArgs(ListViewItem listViewItem)
            {
                ListViewItem = listViewItem;
            }
}

        private string _sqlCommandText { get; set; }
        private List<object> _sqlCommandParams;

        private bool _isDirty;

        public event EventHandler ItemSelected;

        public UcListViewBase()
        {
            InitializeComponent();
        }

        private void UcListViewBase_Load(object sender, EventArgs e)
        {
            lvData.View = View.Details;
            lvData.GridLines = true;
            lvData.FullRowSelect = true;

            _isDirty = true;

        }

        public void SetSqlQuery(string sqlCommandText)
        {
            _sqlCommandText = sqlCommandText;
        }

        public void SetSqlCommandParams(params object[] sqlCommandParams)
        {
            _sqlCommandParams = sqlCommandParams.ToList();
        }

        public void UpdateContent()
        {
            LoadData();
        }

        public void ClearContent()
        {
            lvData.Items.Clear();
            _isDirty = true;
        }

        private void LoadData()
        {
            if(!_isDirty)  return;

            Helpers.RunSqlMediaService(cmd =>
            {
                SqlDataAdapter adapter = new SqlDataAdapter(_sqlCommandText, cmd.Connection);
                for(int idx = 0; idx < _sqlCommandParams.Count;)
                {
                    adapter.SelectCommand.Parameters.AddWithValue(_sqlCommandParams[idx].ToString(), _sqlCommandParams[idx + 1]);
                    idx += 2;
                }

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                
                lvData.BeginUpdate();
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

                lvData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent );
                lvData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                lvData.EndUpdate();
            });

            _isDirty = false;
        }

        public ListViewItem GetSelectedItem()
        {
            return lvData.SelectedItems.Count == 0 ? null : lvData.SelectedItems[0];
        }

        public decimal GetSumInColDecimal(int colIndex)
        {
            decimal retVal = 0;

            foreach(ListViewItem item in lvData.Items)
            {
                var val = decimal.Parse(item.SubItems[colIndex].Text);
                retVal += val;
            }

            return retVal;
        }

        protected virtual void OnItemSelected(ItemSelectedEventArgs e)
        {
            ItemSelected?.Invoke(this, e);
        }

        private void lvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvData.SelectedItems.Count == 0)
            {
                OnItemSelected(null);
            }
            else
            {
                OnItemSelected(new ItemSelectedEventArgs(lvData.SelectedItems[0]));
            }
        }

        private void lvData_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvData);
        }
    }
}
