using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.IO;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using WebAPIConnector;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using sysAdminwp.Model;
using sysAdminwp.viewPageDictionaryControls;

namespace sysAdminwp
{
    public partial class DictionaryForm : RadForm
    {
        private readonly ApiConnector _connector = new ApiConnector();
        private List<DictBaseTypeI> _list;
        private List<DictCategory> _dictionaryCategories;
        private List<DicCategoryItems> _complexDictionary;
        //current position of the grid
        private int _currentPosition;
        private List<ViewTable> _dataGrid;
        //define new position for grid
        private int _updatePosition;

        //defined enable state for elements
        private bool _enableStateElements;
        public bool EnableSateElements
        {
            get => _enableStateElements;
            set
            {
                _enableStateElements = value;
                //add new element button
                btnAdd.Enabled = value;
                //search field
                txtSearchData.Enabled = value;
                //left treeView element
                treeViewList.Enabled = value;
                //search field for treeView element
                txtTreeFilter.Enabled = value;
                //grid
                gvDictionariesList.Enabled = value;
                //delete buttom
                btnRemove.Enabled = value;
                //save button
                btnSave.Enabled = !value;
                //cancel button
                btnCancel.Enabled = !value;
            }
        }

        /// <summary>
        /// URL довідника
        /// </summary>
        public string Url
        {
            get
            {
                var node = treeViewList.SelectedNode;
                if (node?.Parent == null) return string.Empty;
                var categoryItem = _dictionaryCategories[node.Parent.Index].DicCategoryItems[node.Index];
                if (categoryItem == null) return string.Empty;
                return categoryItem.Url;
            }
        }

        public DictionaryForm()
        {
            _enableStateElements = false;
            InitializeComponent();
            IpsGlobal.SetAnketaDictionaties(DictionaryService.GetInstance().GetAnketaDictionaties());
            IpsGlobal.SetObjectRightDictionaries(DictionaryService.GetInstance().GetObjectRightDictionaries());
            SetTreeViewDataSource();
            UpdateEditPanel();
            ctrlComplexDictionary.SetDictionaryCategories(_complexDictionary);
            ctrlSimpleDictionary.SetDictionaryCategories(_dictionaryCategories);
        }

        #region * * * Методи * * *

        /// <summary>
        /// Встановлення джерела даних для Tree View
        /// </summary>
        /// get method for complex dictionary
        private void SetTreeViewDataSource()
        {
            // дерево
            _dictionaryCategories = _connector.GetList<DictCategory>("dictionary/list");
            // show simple dictionaries
            treeViewList.DataSource = _dictionaryCategories;
            treeViewList.ChildMember = "DictCategory\\DicCategoryItems";
            treeViewList.DisplayMember = "Name\\Name";

            _complexDictionary = new List<DicCategoryItems>();
            foreach (var category in _dictionaryCategories)
            {
                var items = category.DicCategoryItems.Where(rec => rec.DicLevel == 2).ToList();
                if(items.Any())
                {
                    _complexDictionary.AddRange(items);
                    foreach (var item in items)
                        category.DicCategoryItems.Remove(item);
                }

                var categoryItems = new List<DicCategoryItems>();
                categoryItems.AddRange(category.DicCategoryItems.OrderBy(i => i.Name).ToList());
                category.DicCategoryItems.Clear();
                foreach (var i in categoryItems)
                    category.DicCategoryItems.Add(i);
            }
            _complexDictionary = _complexDictionary.OrderBy(i => i.Name).ToList();
        }

        /// <summary>
        /// Конвертація даних для відображення на грід
        /// </summary>
        /// <returns></returns>
        private List<ViewTable> GetData()
        {
            var view = new List<ViewTable>();
            // прості словники
            {
                var baseDicts = _connector.GetList<DictBaseTypeI>(Url);
                if (baseDicts == null)
                    baseDicts = new List<DictBaseTypeI> { };
                _list = baseDicts;
                foreach (var item in baseDicts)
                {
                    view.Add(new ViewTable
                    {
                        Code = item.CodeI.ToString(),
                        NameUk = item.DictTrI?.SingleOrDefault(i => i?.Lang.TrimEnd() == "Uk")?.Name ?? item.Name,
                        NameRu = item.DictTrI?.SingleOrDefault(i => i?.Lang.TrimEnd() == "Ru")?.Name,
                        NameEn = item.DictTrI?.SingleOrDefault(i => i?.Lang.TrimEnd() == "En")?.Name,
                    });
                }
            }
            return view;
        }

        private DictBaseTypeI PackDataI()
        {
            DictBaseTypeI dataI = new DictBaseTypeI();
            var dataTrI = new DictTrI[3];
            dataTrI[0] = new DictTrI() { CodeI = Convert.ToInt32(txtCode.Text), Lang = "En", Name = txtNameEn.Text };
            dataTrI[1] = new DictTrI() { CodeI = Convert.ToInt32(txtCode.Text), Lang = "Ru", Name = txtNameRu.Text };
            dataTrI[2] = new DictTrI() { CodeI = Convert.ToInt32(txtCode.Text), Lang = "Uk", Name = txtNameUa.Text };

            dataI.CodeI = dataTrI[0].CodeI;
            dataI.Name = txtNameUa.Text;
            dataI.DictTrI = new List<DictTrI>
            {
                dataTrI[0],dataTrI[1],dataTrI[2]
            };
            return dataI;
        }

        //метод збереження змін !! null code
        public void SaveUpdate()
        {
            if ((txtCode.TextLength == 0) && (Convert.ToInt32(txtCode.Text)).GetType()!=typeof(int))
                txtCode.Text = gvDictionariesList.CurrentRow.Cells["Code"].Value.ToString();

            DictBaseTypeI dataI = PackDataI();
            //catch crkindGroup for recall
            var catchedUrl = UrlCrKindGroup(Url);
            // TODO: use result
            bool result = _connector.UpdateItem<DictBaseTypeI>(catchedUrl, dataI.CodeI.ToString(),(DictBaseTypeI)dataI);
            //update current data and select for grid
            ControlCurrentPosition(result, dataI);
            //update bottom panel
            UpdateEditPanel();
        }
        
        //
        private string UrlCrKindGroup(string url)
        {
            if (url.Contains("crkindgroup"))
                url = url.Replace("base", "extra");
            return url;
        }

        //method for control current position into grid
        private void ControlCurrentPosition(bool resultAction, DictBaseTypeI mutableItem)
        {
            //save current position into grid
            _currentPosition = gvDictionariesList.CurrentRow.Index;
            //get data for grid
            _dataGrid = GetData();
            //set data for grid
            gvDictionariesList.DataSource = _dataGrid;
            //get field 'CodeI' of the mutable item
            string forSearchItem = mutableItem.CodeI.ToString();
            //define new active position for grid
            _updatePosition = _dataGrid.FindIndex(el => el.Code == forSearchItem);
            //set select item for grid
            gvDictionariesList.CurrentRow = resultAction ? gvDictionariesList.Rows[_updatePosition]
                                                         : gvDictionariesList.Rows[_currentPosition];
        }

        public void SaveAddNewRow()
        {
            if (txtCode.Text != string.Empty)
            {
                if ((Convert.ToInt32(txtCode.Text)).GetType() != typeof(int))
                    txtCode.Text = gvDictionariesList.CurrentRow.Cells["Code"].Value.ToString();

                btnSave.Text = "Зберегти";
                try
                {
                    DictBaseTypeI dataI = PackDataI();
                    //result after add new item
                    bool result = _connector.NewItem(Url, dataI);
                    //update current data and select for grid
                    ControlCurrentPosition(result, dataI);
                    UpdateEditPanel();
                    EnableSateElements = true;
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
            txtCode.TextChanging -= TextBox_TextChanging;
            txtNameUa.TextChanging -= TextBox_TextChanging;
            txtNameRu.TextChanging -= TextBox_TextChanging;
            txtNameEn.TextChanging -= TextBox_TextChanging;

            if (gvDictionariesList.CurrentRow?.DataBoundItem is ViewTable items)
            {
                var item = _list?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                txtCode.Text = item?.CodeI.ToString();
                txtNameUa.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang.TrimEnd() == "Uk")?.Name;
                txtNameRu.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang.TrimEnd() == "Ru")?.Name;
                txtNameEn.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang.TrimEnd() == "En")?.Name;
            }
            else
            {
                txtCode.Text = default(string);
                txtNameUa.Text = default(string);
                txtNameRu.Text = default(string);
                txtNameEn.Text = default(string);
            }
            
            txtCode.TextChanging += TextBox_TextChanging;
            txtNameUa.TextChanging += TextBox_TextChanging;
            txtNameRu.TextChanging += TextBox_TextChanging;
            txtNameEn.TextChanging += TextBox_TextChanging;
            // hide default string
            gvDictionariesList.TableElement.Text = "";
        }
        
        #endregion

        //зміна даних в grid при написанні пошукового слова
        private void RadTxtBoxSearchData_TextChanged(object sender, EventArgs e)
        {
            gvDictionariesList.MasterTemplate.Refresh();
        }

        //пошук по записах в grid
        private void RadGridView1_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchData.Text))
            {
                gvDictionariesList.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvDictionariesList.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvDictionariesList.EndUpdate(false);
                return;
            }

            gvDictionariesList.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvDictionariesList.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;
                    
                    string text = e.Row.Cells[i].Value.ToString();
                    if (text.IndexOf(txtSearchData.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
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
                    gvDictionariesList.EndUpdate(false);
            }
        }

        //оновлення панелі редагування
        private void RadGridView1_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            EnableSateElements = true;
            UpdateEditPanel();
        }

        //додавання нового рядка
        private void radBtnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Додати";
            EnableSateElements = false;
            txtCode.Clear();
            txtNameEn.Clear();
            txtNameRu.Clear();
            txtNameUa.Clear();
        }
        
        //кнопка видалення рядка в grid
        private void radBtnRemove_Click(object sender, EventArgs e)
        {
            var row = gvDictionariesList.CurrentRow.DataBoundItem as ViewTable;
            bool result = _connector.DeleteItem(Url, row.Code);
            //get last selected item
            int currentPosition = gvDictionariesList.CurrentRow.Index;
            //get data for grid
            gvDictionariesList.DataSource = GetData();
            gvDictionariesList.CurrentRow = result ? gvDictionariesList.Rows[currentPosition - 1]
                                                   : gvDictionariesList.Rows[0];
            UpdateEditPanel();
        }

        //кнопка збереження
        private void radBtnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Додати")
            {
                SaveAddNewRow();
            }
            else
            {
                SaveUpdate();
            }
            EnableSateElements = true;
        }

        //кнопка відміни внесених змін
        private void btnCancel_Click(object sender, EventArgs e)
        {
            UpdateEditPanel();
            EnableSateElements = true;
        }

        //фільтр елементів дерева
        private void radTxtBoxFilter_TextChanged(object sender, EventArgs e)
        {
            treeViewList.Filter = txtTreeFilter.Text;
        }
        
        //зміни при виборі елементу з дерева
        private void radTreeViewList_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            if (e.Node?.Parent?.Index == null)
            {
                DefaultPanel();
                return;
            }
            var categoryItem = _dictionaryCategories[e.Node.Parent.Index]?.DicCategoryItems[e.Node.Index];
            if(categoryItem == null)
            {
                DefaultPanel();
                return;
            }

            var returnedList = GetData();
            gvDictionariesList.DataSource = returnedList;
            

            radPanelChange.Enabled = returnedList != null;
            txtSearchData.Enabled = returnedList != null;
            btnRemove.Enabled = returnedList != null;
            gvDictionariesList.Enabled = returnedList != null;
            
            if (returnedList != null)
            {
                LoadOverviewCfg();
            }
            else
            {
                gvDictionariesList.DataSource = default(DataGrid);
                UpdateEditPanel();
            }
            
            btnAdd.Enabled = true;
        }
        

        private void DefaultPanel()
        {
            gvDictionariesList.DataSource = null;
            UpdateEditPanel();
            radPanelChange.Enabled = false;
            txtSearchData.Enabled = false;
            btnAdd.Enabled = false;
            btnRemove.Enabled = false;
        }

        //подія при редагуванні даних в текстбоксах
        private void TextBox_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            EnableSateElements = false;
        }

        //збереження конфігурації
        private void radMenuItemSaveConfig_Click(object sender, EventArgs e)
        {
            string s = "overviewconfig.xml";
            gvDictionariesList.SaveLayout(s);
        }

        //завантаження конфігурації вигляду в грід
        private void LoadOverviewCfg()
        {
            string s = "overviewconfig.xml", 
                   def = "defaultoverviewconfig.xml";
            if(File.Exists(s))
                gvDictionariesList.LoadLayout(s);
            else if (File.Exists(def))
            {
                gvDictionariesList.LoadLayout(def);
            }
            else
            {
                gvDictionariesList.SaveLayout(def);
                gvDictionariesList.LoadLayout(def);
            }
        }

        //встановлення стандартних налаштувань вигляду грід
        private void radMenuItemsSetDefaultSett_Click(object sender, EventArgs e)
        {
            if (File.Exists("defaultoverviewconfig.xml"))
            {
                gvDictionariesList.LoadLayout("defaultoverviewconfig.xml");
                gvDictionariesList.SaveLayout("overviewconfig.xml");
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