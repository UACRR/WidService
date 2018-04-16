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
using sysAdminwp.Properties;
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
            SetDataSource();
            radGridView1.CurrentRowChanged += RadGridView1_CurrentRowChanged;
            radGridView1.CustomFiltering += RadGridView1_CustomFiltering;
            radTxtBoxSearchData.TextChanged += RadTxtBoxSearchData_TextChanged;
            UpdateEditPanel();
            InitializeColumnSize();

        }

        #region Методи
        
        //метод встановлення джерела даних
        private void SetDataSource()
        {
            var dictCategory = connector.GetList<DictCategory>("api/dictionary/list");
            list = connector.GetList<Category>("api/dictionary/base/category");
            radGridView1.DataSource = list;
            radTreeViewList.DataSource = dictCategory;
            radTreeViewList.ChildMember = "DictCategory\\DicCategoryItems";
            radTreeViewList.DisplayMember = "Name\\Name";
        }

        //метод збереження змін
        private void SaveChanges()
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

        //метод оновлення для панелі редагування
        private void UpdateEditPanel()
        {
            //відписуємось від події - обрали інший рядок, зміни не внесено
            this.radTBCode.TextChanging -= new Telerik.WinControls.TextChangingEventHandler(this.radTBCode_TextChanging);
            this.radTBNameUa.TextChanging -= new Telerik.WinControls.TextChangingEventHandler(this.radTBNameUa_TextChanging);
            this.radTBNameRu.TextChanging -= new Telerik.WinControls.TextChangingEventHandler(this.radTBNameRu_TextChanging);
            this.radTBNameEn.TextChanging -= new Telerik.WinControls.TextChangingEventHandler(this.radTBNameEn_TextChanging);
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
            this.radTBCode.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.radTBCode_TextChanging);
            this.radTBNameUa.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.radTBNameUa_TextChanging);
            this.radTBNameRu.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.radTBNameRu_TextChanging);
            this.radTBNameEn.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.radTBNameEn_TextChanging);

        }

        private void InitializeColumnSize()
        {
            radGridView1.Columns[0].Width = 50;
            radGridView1.Columns[1].Width = 300;
            radGridView1.Columns[2].Width = 200;
            radGridView1.Columns[3].Width = 200;
            //подумать...
        }
        #endregion


        //зміна даних в grid при написанні пошукового слова
        private void RadTxtBoxSearchData_TextChanged(object sender, EventArgs e)
        {
            radGridView1.MasterTemplate.Refresh();
        }

        //пошук по записах в grid
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

            radGridView1.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < radGridView1.ColumnCount; i++)
            {   
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;
                    
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
        }


        //оновлення панелі редагування
        private void RadGridView1_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
                UpdateEditPanel();
        }

        private void radBtnAdd_Click(object sender, EventArgs e)
        {
            radGridView1.AllowEditRow = !radGridView1.AllowEditRow;
            radGridView1.AllowAddNewRow = !radGridView1.AllowAddNewRow;
        }

        //кнопка видалення рядка в grid
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

        //кнопка збереження
        private void radBtnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
            ChangeEnableElements(true);
        }



        //кнопка відміни внесених змін
        private void radBtnCancel_Click(object sender, EventArgs e)
        {
            UpdateEditPanel();
            ChangeEnableElements(true);
        }

        //фільтр елементів дерева
        private void radTxtBoxFilter_TextChanged(object sender, EventArgs e)
        {
            radTreeViewList.Filter = radTxtBoxFilter.Text;
        }
        //зміни при виборі елементу з дерева
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
                             radTxtBoxSearchData.Enabled = true;
                             radBtnAdd.Enabled = true;
                             radBtnRemove.Enabled = true;
                         }
                         catch (Exception)
                         {
                             radGridView1.DataSource = default(DataGrid);
                             UpdateEditPanel();
                             radPanelChange.Enabled = false;
                             radTxtBoxSearchData.Enabled = false;
                             radBtnAdd.Enabled = false;
                             radBtnRemove.Enabled = false;
                         }
                     }
                 }
             }

            //перевірити!
            //foreach (dynamic item in urlCategories)
            //{
            //    if (item.Name == e.Node.Name)
            //    {
            //        try
            //        {
            //            list = connector.GetList<Category>(item.Url);
            //            radGridView1.DataSource = list;
            //            radPanelChange.Enabled = true;
            //            radTxtBoxSearchData.Enabled = true;
            //            radBtnAdd.Enabled = true;
            //            radBtnRemove.Enabled = true;
            //        }
            //        catch (Exception)
            //        {
            //            radGridView1.DataSource = default(DataGrid);
            //            UpdateEditPanel();
            //            radPanelChange.Enabled = false;
            //            radTxtBoxSearchData.Enabled = false;
            //            radBtnAdd.Enabled = false;
            //            radBtnRemove.Enabled = false;
            //        }
            //    }
            //}
            
        }


        #region події при редагуванні даних на панелі
        private void radTBCode_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            ChangeEnableElements(false);
        }

        private void radTBNameUa_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            ChangeEnableElements(false);
        }

        private void radTBNameEn_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            ChangeEnableElements(false);
        }

        private void radTBNameRu_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            ChangeEnableElements(false);
        }

        /// <summary>
        /// Метод зміни стану увімкненості компонентів
        /// </summary>
        /// <param name="isEnable">Якщо true - компонент активний</param>
        private void ChangeEnableElements(bool isEnable)
        {
            radGridView1.Enabled = isEnable;
            radTreeViewList.Enabled = isEnable;
            radBtnAdd.Enabled = isEnable;
            radBtnRemove.Enabled = isEnable;
            radTxtBoxSearchData.Enabled = isEnable;
            radTxtBoxFilter.Enabled = isEnable;
        }



        #endregion

        private void radMenuItemSaveConfig_Click(object sender, EventArgs e)
        {


            string s = "overviewconfig.xml";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            dialog.Title = "Select a xml file";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                s = dialog.FileName;
            }
            radGridView1.SaveLayout(s);

            //radGridView1.Columns[0].Width = Properties.Settings.Default.column0_width;
            //DataGridView gv = new DataGridView();
            //gv.Columns[0].DisplayIndex = Properties.Settings.Default.column0_width;
            //radGridView1.Columns.Move(radGridView1.Columns["col"], Properties.Settings.Default.col_dis_index0);
        }

        private void OpenSettings()
        {
            string s = "overviewconfig.xml", def = "defaultoverviewconfig.xml";
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                dialog.Title = "Select a xml file";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    s = dialog.FileName;
                }

                if (s != null)
                    radGridView1.LoadLayout(s);
                else
                    radGridView1.LoadLayout(def);
            }

            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            //dialog.Title = "Select a xml file";
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    s = dialog.FileName;
            //}
            //
            //if (s!=null)
            //    radGridView1.LoadLayout(s);
            //else 
            //    radGridView1.LoadLayout(def);
            //
        }

        private void LoadOverviewCfg()
        {
            string s = "overviewconfig.xml", def = "defaultoverviewconfig.xml";
            try
            {
                radGridView1.LoadLayout(s);
            }
            catch (Exception e)
            {
                radGridView1.SaveLayout(def);
                radGridView1.LoadLayout(def);
                //MessageBox.Show(e.Message, "Error load overview!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void radMenuItemsSetDefaultSett_Click(object sender, EventArgs e)
        {
            OpenSettings();
        }
    }
}
