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
            radGridView1.CustomFiltering += RadGridView1_CustomFiltering;
            radTxtBoxSearchData.TextChanged += RadTxtBoxSearchData_TextChanged;
            Upd();
        }

        private void RadTxtBoxSearchData_TextChanged(object sender, EventArgs e)
        {
            radGridView1.MasterTemplate.Refresh();
        }

        private void RadGridView1_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            if (string.IsNullOrEmpty(radTxtBoxSearchData.Text))
            {
                radGridView1.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < radGridView1.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                radGridView1.EndUpdate(false);
                return;
            }
            //

            radGridView1.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < radGridView1.ColumnCount; i++)
            {
                try
                {
                    string text = e.Row.Cells[i].Value.ToString();
                    if (text.IndexOf(radTxtBoxSearchData.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        e.Visible = true;
                        e.Row.Cells[i].Style.CustomizeFill = true;
                        e.Row.Cells[i].Style.DrawFill = true;
                        e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                    }
                    else
                    {
                        e.Row.Cells[i].Style.Reset();
                    }

                    radGridView1.EndUpdate(false);
                }
                catch (Exception)
                {
                    
                }
                
            }
            //
        }

        private void setDataSource()
        {
            var dictCategory = connector.GetList<DictCategory>("api/dictionary/list");
            list = connector.GetList<Category>("api/dictionary/base/category");
            radGridView1.DataSource = list;
            radTreeViewList.DataSource = dictCategory;
            radTreeViewList.ChildMember = "DictCategory\\DicCategoryItems";
            radTreeViewList.DisplayMember = "Name\\Name";
            

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


        private void radTxtBoxFilter_TextChanged(object sender, EventArgs e)
        {
            radTreeViewList.Filter = radTxtBoxFilter.Text;
        }

        private void radTxtBoxSearchData_TextChanged(object sender, EventArgs e)
        {
            // = radTxtBoxSearchData.Text;
        }



        private void radTreeViewList_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            var urlCategories = connector.GetList<DictCategory>("api/dictionary/list");
            
             foreach (var item in urlCategories)
             {
                 foreach (var catItem in item.DicCategoryItems)
                 {
                    if (catItem.Name == e.Node.Name)
                     {
                         try
                         {
                             list = connector.GetList<Category>(catItem.Url);
                             radGridView1.DataSource = list;
                             radPanelChange.Enabled = true;
                         }
                         catch (Exception)
                         {
                             radGridView1.DataSource = default(DataGrid);
                             Upd();
                             radPanelChange.Enabled = false;
                         }
                     }
                 }
             }            
        }
    }
}
