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
using ipsFormsDesign.Dictionary;
using sysAdminwp.Properties;
using WebAPIConnector;

namespace sysAdminwp
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        private readonly ApiConnector connector = new ApiConnector("http://localhost:54867/");
        private List<DictBaseTypeI> list;
        private List<ViewTable> view;
        public string Url { get; set; }

        public RadForm1()
        {
            InitializeComponent();
            SetDataSource();
            radGridView1.CurrentRowChanged += RadGridView1_CurrentRowChanged;
            radGridView1.CustomFiltering += RadGridView1_CustomFiltering;
            radTxtBoxSearchData.TextChanged += RadTxtBoxSearchData_TextChanged;
            UpdateEditPanel();
            
        }

        #region Методи
        
        //метод встановлення джерела даних
        private void SetDataSource()
        {
            var dictCategory = connector.GetList<DictCategory>("api/dictionary/list");//дерево
            radTreeViewList.DataSource = dictCategory;
            radTreeViewList.ChildMember = "DictCategory\\DicCategoryItems";
            radTreeViewList.DisplayMember = "Name\\Name";

            //на грід
            //list = connector.GetList<DictBaseTypeI>("api/dictionary/base/activitytype");
            //radGridView1.DataSource = GetData(list);

        }

        /// <summary>
        /// Отримати дані у вигляді виведення на grid
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        private List<ViewTable> GetData(List<DictBaseTypeI> l)
        {
            List<ViewTable> view = new List<ViewTable>();
            ViewTable temp;
            foreach (var items in l)
            {
                temp = new ViewTable();
                temp.Code = items.CodeI;
                foreach (var itemName in items.DictTrI)
                {
                    if (itemName.Lang == "Uk")
                        temp.NameUk = itemName.Name;
                    if (itemName.Lang == "Ru")
                        temp.NameRu = itemName.Name;
                    if (itemName.Lang == "En")
                        temp.NameEn = itemName.Name;
                }
                view.Add(temp);
            }

            return view;
        }



        //метод збереження змін
        public void SaveChangesTest()
        {
            try
            {
                radGridView1.CurrentRow.Cells["Code"].Value = Convert.ToInt32(radTBCode.Text);
            }
            catch (Exception)
            {
                radTBCode.Text = radGridView1.CurrentRow.Cells["Code"].Value.ToString();
            }
            radGridView1.CurrentRow.Cells["NameUk"].Value = radTBNameUa.Text;
            radGridView1.CurrentRow.Cells["NameEn"].Value = radTBNameEn.Text;
            radGridView1.CurrentRow.Cells["NameRu"].Value = radTBNameRu.Text;

            
            DictBaseTypeI dataI = new DictBaseTypeI();
                var dataTrI = new DictTrI[3];
                dataTrI[0] = new DictTrI() {CodeI = Convert.ToInt32(radTBCode.Text),Lang = "En",Name = radTBNameEn.Text};
                dataTrI[1] = new DictTrI() {CodeI = Convert.ToInt32(radTBCode.Text),Lang = "Ru",Name = radTBNameRu.Text};
                dataTrI[2] = new DictTrI() {CodeI = Convert.ToInt32(radTBCode.Text),Lang = "Uk",Name = radTBNameUa.Text};

            dataI.CodeI = dataTrI[0].CodeI;
            dataI.Name = radTBNameUa.Text;
            dataI.DictTrI = new List<DictTrI>
            {
                dataTrI[0],dataTrI[1],dataTrI[2]
            };

            connector.UpdateItem<DictBaseTypeI>(Url, dataI.CodeI.ToString(), (DictBaseTypeI) dataI);

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
                     radTBCode.Text = radGridView1.CurrentRow.Cells["Code"].Value.ToString();
                     radTBNameUa.Text = radGridView1.CurrentRow.Cells["NameUk"].Value.ToString();
                     radTBNameRu.Text = radGridView1.CurrentRow.Cells["NameRu"].Value.ToString();
                     radTBNameEn.Text = radGridView1.CurrentRow.Cells["NameEn"].Value.ToString();
                 }
                 catch (Exception)
                 {
                     radTBCode.Text = default(string);
                     radTBNameUa.Text = default(string);
                     radTBNameRu.Text = default(string);
                     radTBNameEn.Text = default(string);
                 }
            this.radTBCode.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.radTBCode_TextChanging);
            this.radTBNameUa.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.radTBNameUa_TextChanging);
            this.radTBNameRu.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.radTBNameRu_TextChanging);
            this.radTBNameEn.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.radTBNameEn_TextChanging);
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

        //додавання нового рядка
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
            this.SaveChangesTest();
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
                             Url = catItem.Url;
                             list = connector.GetList<DictBaseTypeI>(catItem.Url);
                             radGridView1.DataSource = GetData(list);
                             radPanelChange.Enabled = true;
                             radTxtBoxSearchData.Enabled = true;
                             radBtnAdd.Enabled = true;
                             radBtnRemove.Enabled = true;
                             LoadOverviewCfg();
                        }
                         catch (Exception ex)
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

        //збереження конфігурації
        private void radMenuItemSaveConfig_Click(object sender, EventArgs e)
        {
            string s = "overviewconfig.xml";
            radGridView1.SaveLayout(s);
        }

        //завантаження конфігурації вигляду в грід
        private void LoadOverviewCfg()
        {
            string s = "overviewconfig.xml", 
                   def = "defaultoverviewconfig.xml";
            if(File.Exists(s))
                radGridView1.LoadLayout(s);
            else if (File.Exists(def))
            {
                radGridView1.LoadLayout(def);
            }
            else
            {
                radGridView1.SaveLayout(def);
                radGridView1.LoadLayout(def);
            }
        }

        //встановлення стандартних налаштувань вигляду грід
        private void radMenuItemsSetDefaultSett_Click(object sender, EventArgs e)
        {
            if (File.Exists("defaultoverviewconfig.xml"))
            {
                radGridView1.LoadLayout("defaultoverviewconfig.xml");
                radGridView1.SaveLayout("overviewconfig.xml");
            }
            else
            {
                MessageBox.Show("Неможливо автоматично відновити стандартні налаштування! " +
                                "Видаліть файл конфігурації '"+Path.GetFullPath("overviewconfig.xml") +"' та перезапустіть програму.",
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
    }

}

