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
using Telerik.WinControls.UI;
using System.IO;
using ipsFormsDesign.Dictionary;
using sysAdminwp.Properties;
using WebAPIConnector;
using ipsFormsDesign.Model;

namespace sysAdminwp
{
    public partial class RadForm1 : RadForm
    {
        private readonly ApiConnector _connector = new ApiConnector();
        private List<DictBaseTypeI> _list;
        private List<DictCategory> _dictionaryCategories = null;
        public string Url { get; set; }
        //index row
        private int _indexRow;

        public RadForm1()
        {
            InitializeComponent();
            SetDataSource();
            
            UpdateEditPanel();

            radTxtBoxSearchData.TextChanged += RadTxtBoxSearchData_TextChanged;
            radGridView1.CustomFiltering += RadGridView1_CustomFiltering;
            radGridView1.CurrentRowChanged += RadGridView1_CurrentRowChanged;
            

            radPanelChange.Enabled = false;
            radTxtBoxSearchData.Enabled = false;
            radBtnAdd.Enabled = false;
            radBtnRemove.Enabled = false;
            _dictionaryCategories = _connector.GetList<DictCategory>("dictionary/list");
            
        }

        #region Методи

        //метод встановлення джерела даних для дерева
        private void SetDataSource()
        {
            var dictCategory = _connector.GetList<DictCategory>("dictionary/list");//дерево
            List<DicCategoryItems> categoryItems = new List<DicCategoryItems>();
            foreach (var category in dictCategory)
            {
                categoryItems.AddRange(category.DicCategoryItems.OrderBy(i => i.Name).ToList());
                category.DicCategoryItems.Clear();
                foreach (var i in categoryItems)
                    category.DicCategoryItems.Add(i);
                categoryItems.Clear();
            }
            radTreeViewList.DataSource = dictCategory;
            radTreeViewList.ChildMember = "DictCategory\\DicCategoryItems";
            radTreeViewList.DisplayMember = "Name\\Name";
        }

        /// <summary>
        /// Отримати дані у вигляді виведення на grid
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        private List<ViewTable> GetData(List<DictBaseTypeI> l)
        {
            var view = new List<ViewTable>();
            foreach (var items in l)
            {
                view.Add(new ViewTable
                {
                    Code = items.CodeI,
                    NameUk = items.DictTrI?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? items.Name,
                    NameRu = items.DictTrI?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                    NameEn = items.DictTrI?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                });
            }
            return view;
        }


        private DictBaseTypeI PackDataI()
        {
            DictBaseTypeI dataI = new DictBaseTypeI();
            var dataTrI = new DictTrI[3];
            dataTrI[0] = new DictTrI() { CodeI = Convert.ToInt32(radTBCode.Text), Lang = "En", Name = radTBNameEn.Text };
            dataTrI[1] = new DictTrI() { CodeI = Convert.ToInt32(radTBCode.Text), Lang = "Ru", Name = radTBNameRu.Text };
            dataTrI[2] = new DictTrI() { CodeI = Convert.ToInt32(radTBCode.Text), Lang = "Uk", Name = radTBNameUa.Text };

            dataI.CodeI = dataTrI[0].CodeI;
            dataI.Name = radTBNameUa.Text;
            dataI.DictTrI = new List<DictTrI>
            {
                dataTrI[0],dataTrI[1],dataTrI[2]
            };
            return dataI;
        }

        //метод збереження змін !! null code
        public void SaveUpdate()
        {
            if ((radTBCode.TextLength == 0) && (Convert.ToInt32(radTBCode.Text)).GetType()!=typeof(int))
                radTBCode.Text = radGridView1.CurrentRow.Cells["Code"].Value.ToString();

            DictBaseTypeI dataI = PackDataI();
            bool retCode = _connector.UpdateItem<DictBaseTypeI>(Url,dataI.CodeI.ToString(),(DictBaseTypeI)dataI);
            _list = _connector.GetList<DictBaseTypeI>(Url);
            radGridView1.DataSource = GetData(_list);
            UpdateEditPanel();
        }

        public void SaveAddNewRow()
        {
            if (radTBCode.Text != string.Empty)
            {
                if ((Convert.ToInt32(radTBCode.Text)).GetType() != typeof(int))
                    radTBCode.Text = radGridView1.CurrentRow.Cells["Code"].Value.ToString();
                radBtnSave.Text = "Зберегти";
                try
                {
                    DictBaseTypeI dataI = PackDataI();
                    bool retCode = _connector.NewItem(Url, dataI);
                    _list = _connector.GetList<DictBaseTypeI>(Url);
                    radGridView1.DataSource = GetData(_list);
                    UpdateEditPanel();
                    ChangeEnableElementsWhenAdd(true);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Поле '" + radLabelCode.Text + "' не повинно бути пустим!", 
                    "Заповніть поле!", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        //метод оновлення для панелі редагування
        private void UpdateEditPanel()
        {
            //відписуємось від події - обрали інший рядок, зміни не внесено
            radTBCode.TextChanging -= TextBox_TextChanging;
            radTBNameUa.TextChanging -= TextBox_TextChanging;
            radTBNameRu.TextChanging -= TextBox_TextChanging;
            radTBNameEn.TextChanging -= TextBox_TextChanging;

            if (radGridView1?.CurrentRow?.DataBoundItem is ViewTable items)
            {
                var item = _list.SingleOrDefault(rec => rec.CodeI == items.Code);
                radTBCode.Text = item?.CodeI.ToString();
                radTBNameUa.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                radTBNameRu.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                radTBNameEn.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang == "En")?.Name;
            }
            else
            {
                radTBCode.Text = default(string);
                radTBNameUa.Text = default(string);
                radTBNameRu.Text = default(string);
                radTBNameEn.Text = default(string);
            }
            
            radTBCode.TextChanging += TextBox_TextChanging;
            radTBNameUa.TextChanging += TextBox_TextChanging;
            radTBNameRu.TextChanging += TextBox_TextChanging;
            radTBNameEn.TextChanging += TextBox_TextChanging;
            // hide default string
            radGridView1.TableElement.Text = "";
        }

        /// <summary>
        /// Метод зміни стану увімкненості компонентів
        /// </summary>
        /// <param name="isEnable">Якщо true - компонент активний</param>
        private void ChangeEnableElementsWhenEdit(bool isEnable)
        {
            radGridView1.Enabled = isEnable;
            radTreeViewList.Enabled = isEnable;
            radBtnAdd.Enabled = isEnable;
            radBtnRemove.Enabled = isEnable;
            radTxtBoxSearchData.Enabled = isEnable;
            radTxtBoxFilter.Enabled = isEnable;
        }

        private void ChangeEnableElementsWhenAdd(bool isEnable)
        {
            radBtnAdd.Enabled = isEnable;
            radTxtBoxSearchData.Enabled = isEnable;
            radTreeViewList.Enabled = isEnable;
            radTxtBoxFilter.Enabled = isEnable;
            radGridView1.Enabled = isEnable;
            radBtnRemove.Enabled = isEnable;
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
        //method for save last position cursor
        private void GetLstCurs()
        {
            //save position
            _indexRow = radGridView1.CurrentRow.Index;
        }

        //method for set saved position cursor
        private void SetLstCurs()
        {
            //set position
            radGridView1.CurrentRow = radGridView1.Rows[_indexRow];
        }

        //додавання нового рядка
        private void radBtnAdd_Click(object sender, EventArgs e)
        {
            //use last selected row
            GetLstCurs();
            radBtnSave.Text = "Додати";
            ChangeEnableElementsWhenAdd(false);
            radTBCode.Clear();
            radTBNameEn.Clear();
            radTBNameRu.Clear();
            radTBNameUa.Clear();
            radPanelChange.Enabled = true;
        }
        
        //кнопка видалення рядка в grid
        private void radBtnRemove_Click(object sender, EventArgs e)
        {
            var result = _connector.DeleteItem(Url, radGridView1.CurrentRow.Cells["Code"].Value.ToString());
            
            _list = _connector.GetList<DictBaseTypeI>(Url);
            radGridView1.DataSource = GetData(_list);
            UpdateEditPanel();
        }

        //кнопка збереження
        private void radBtnSave_Click(object sender, EventArgs e)
        {
            if (radBtnSave.Text == "Додати")
            {
                SaveAddNewRow();
            }
            else
            {
                SaveUpdate();
                ChangeEnableElementsWhenEdit(true);
            }
            //set last row focus
            SetLstCurs();
        }

        //кнопка відміни внесених змін
        private void radBtnCancel_Click(object sender, EventArgs e)
        {
            UpdateEditPanel();
            ChangeEnableElementsWhenEdit(true);
        }

        //фільтр елементів дерева
        private void radTxtBoxFilter_TextChanged(object sender, EventArgs e)
        {
            radTreeViewList.Filter = radTxtBoxFilter.Text;
        }
        
        //зміни при виборі елементу з дерева
        private void radTreeViewList_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            foreach (var item in _dictionaryCategories)
            {
                foreach (var catItem in item.DicCategoryItems)
                {
                    if (catItem.Name == e.Node.Name)
                    {
                        Url = catItem.Url;
                        var returnedList = _connector.GetList<DictBaseTypeI>(catItem.Url);
                        bool isNotNull = returnedList != null;
                        radPanelChange.Enabled = isNotNull;
                        radTxtBoxSearchData.Enabled = isNotNull;
                        radBtnRemove.Enabled = isNotNull;

                        if (isNotNull)
                        {
                            _list = returnedList;
                            radGridView1.DataSource = GetData(_list);
                            LoadOverviewCfg();
                        }
                        else
                        {
                            radGridView1.DataSource = default(DataGrid);
                            UpdateEditPanel();
                        }
                        
                        radBtnAdd.Enabled = true;
                        return;
                    }
                }

                radGridView1.DataSource = null;
                UpdateEditPanel();
                radPanelChange.Enabled = false;
                radTxtBoxSearchData.Enabled = false;
                radBtnAdd.Enabled = false;
                radBtnRemove.Enabled = false;
            }
        }

        //подія при редагуванні даних в текстбоксах
        private void TextBox_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            //save last position
            GetLstCurs();
            ChangeEnableElementsWhenEdit(false);
        }

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

