using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Telerik.WinControls.UI;
using System.IO;
using WebAPIConnector;

namespace sysAdminwp
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {

        private ApiConnector connector = new ApiConnector("http://localhost:54867/");
        private List<Category> list;

        public RadForm1()
        {
            InitializeComponent();
            setDataSource();
            radGridView1.CurrentRowChanged += RadGridView1_CurrentRowChanged;
            Upd();
        }

        private void setDataSource()
        {
            var dictCategory = connector.GetList<DictCategory>("api/dictionary/list");
            list = connector.GetList<Category>("api/dictionary/base/category");
            radGridView1.DataSource = list;
            radTreeView1.DataSource = dictCategory;
            radTreeView1.ChildMember = "DictCategory\\DicCategoryItems";
            radTreeView1.DisplayMember = "Name\\Name";


        }

        private void RadGridView1_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            Upd();
        }

        private void radBtnAdd_Click(object sender, EventArgs e)
        {
            radGridView1.AllowEditRow = !radGridView1.AllowEditRow;
            radGridView1.AllowAddNewRow = !radGridView1.AllowAddNewRow;

        }

        private void radBtnRemove_Click(object sender, EventArgs e)
        {
            using (GridViewDataRowInfo gvdri = radGridView1.CurrentRow as GridViewDataRowInfo)
            {
                if (gvdri!=null)
                {
                    radGridView1.Rows.Remove(gvdri);
                    
                }
            }
        }

        private void radBtnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                radGridView1.CurrentRow.Cells[0].Value = Convert.ToInt32(radTBCode.Text);
            }
            catch (Exception)
            {
                radTBCode.Text = radGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            
            radGridView1.CurrentRow.Cells[1].Value = radTBNameUa.Text;
        }

        private void Upd()
        {
            try
            {
                radTBCode.Text = radGridView1.CurrentRow.Cells[0].Value.ToString();
                radTBNameUa.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                radTBCode.Text = default(string);
                radTBNameUa.Text = default(string);
            }
        }

        private void radBtnCancel_Click(object sender, EventArgs e)
        {
            Upd();
        }

        public void LoadData()
        {
            foreach (var node in list)
            {
                RadTreeNode rtn = radTreeViewList.Nodes.Add(node.CategoryCode.ToString());
                rtn.Nodes.Add(node.CategoryName);
            }
            
        }

        private void radTxtBoxFilter_TextChanged(object sender, EventArgs e)
        {
            radTreeViewList.Filter = radTxtBoxFilter.Text;
        }

        private void radTxtBoxSearchData_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
