using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.IO;
using ipsFormsDesign.Dictionary;
using WebAPIConnector;
using ipsFormsDesign.Model;
using ipsFormsDesign.Data;
using sysAdminwp.viewPageDictionaryControls;

namespace sysAdminwp
{
    public partial class DictionaryForm : RadForm
    {
        private readonly ApiConnector _connector = new ApiConnector();
        private readonly List<string> _complexDictionaryList = new List<string>
        {
            "copyrightkind",
            "country",
            "creativeroletype",
            "genretype",
            "klr030"
        };
        private List<DictBaseTypeI> _list;
        private List<CopyrightKind> _copyrightKindList;
        private List<Country> _countryList;
        private List<CreativeRoleType> _creativeRoleTypeList;
        private List<GenreType> _genreTypeList;
        private List<KlR030> _klR030List;
        private List<DictCategory> _dictionaryCategories;
        private List<DicCategoryItems> _complexDictionary;
        //variable for detect started complex dictionary controls for next set clear
        private static string StringTypeForInitializeControl = null;

        /// <summary>
        /// URL словника
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
        /// <summary>
        /// Найменування довідника
        /// </summary>
        public string DictionaryName
        {
            get
            {
                var node = treeViewList.SelectedNode;
                if (node?.Parent == null) return string.Empty;
                var categoryItem = _dictionaryCategories[node.Parent.Index].DicCategoryItems[node.Index];
                if (categoryItem == null) return string.Empty;
                return categoryItem.DicName;
            }
        }

        // index selected row
        private int _indexRow;

        public DictionaryForm()
        {
            InitializeComponent();
            SetTreeViewDataSource();
            
            UpdateEditPanel();

            txtSearchData.TextChanged += RadTxtBoxSearchData_TextChanged;
            gvDictionariesList.CustomFiltering += RadGridView1_CustomFiltering;
            gvDictionariesList.CurrentRowChanged += RadGridView1_CurrentRowChanged;

            //txtSearchData.SetUsageGrid(gvDictionariesList);


            radPanelChange.Enabled = false;
            txtSearchData.Enabled = false;
            btnAdd.Enabled = false;
            btnRemove.Enabled = false;

            //initialize object for complex dictionaries
            ComplexDictionaryControl complexDictionaryControl = new ComplexDictionaryControl(_connector, _complexDictionary)
            {
                Dock = DockStyle.Fill,
            };
            //add new control for complex dictionaries
            radPageViewPage2.Controls.Add(complexDictionaryControl);


        }

        #region * * * Методи * * *

        /// <summary>
        /// Встановлення джерела даних для Tree View
        /// </summary>
        /// get method for complex dictionary
        private void SetTreeViewDataSource()
        {
            _dictionaryCategories = _connector.GetList<DictCategory>("dictionary/list");//дерево
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

            treeViewList.DataSource = _dictionaryCategories;
            treeViewList.ChildMember = "DictCategory\\DicCategoryItems";
            treeViewList.DisplayMember = "Name\\Name";
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
                _list = baseDicts;

                foreach (var item in baseDicts)
                {
                    view.Add(new ViewTable
                    {
                        Code = item.CodeI.ToString(),
                        NameUk = item.DictTrI?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                        NameRu = item.DictTrI?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                        NameEn = item.DictTrI?.SingleOrDefault(i => i?.Lang == "En")?.Name,
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
            // TODO: use result
            bool result = _connector.UpdateItem<DictBaseTypeI>(Url,dataI.CodeI.ToString(),(DictBaseTypeI)dataI);

            gvDictionariesList.DataSource = GetData();
            UpdateEditPanel();
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
                    bool result = _connector.NewItem(Url, dataI);

                    gvDictionariesList.DataSource = GetData();
                    //select last item(new) into grid
                    gvDictionariesList.CurrentRow = result ? gvDictionariesList.Rows[gvDictionariesList.RowCount - 1] :
                                                             gvDictionariesList.Rows[0];
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
            txtCode.TextChanging -= TextBox_TextChanging;
            txtNameUa.TextChanging -= TextBox_TextChanging;
            txtNameRu.TextChanging -= TextBox_TextChanging;
            txtNameEn.TextChanging -= TextBox_TextChanging;

            if (gvDictionariesList.CurrentRow?.DataBoundItem is ViewTable items)
            {
                if (_complexDictionaryList.Contains(DictionaryName.ToLower()))
                {
                    // TODO: для складних довідників підтягнути додаткові потрібні словники, сформувати інтерфейс
                    // біндінг даних
                    switch (DictionaryName.ToLower())
                    {
                        case "copyrightkind":
                            var copyrightKind = _copyrightKindList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                            txtCode.Text = copyrightKind?.CodeI.ToString();
                            txtNameUa.Text = copyrightKind?.CopyrightKindTr?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                            txtNameRu.Text = copyrightKind?.CopyrightKindTr?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                            txtNameEn.Text = copyrightKind?.CopyrightKindTr?.SingleOrDefault(i => i.Lang == "En")?.Name;
                            break;
                        case "country":
                            var country = _countryList?.SingleOrDefault(rec => rec.CountryCode == items.Code);
                            txtCode.Text = country?.CountryCode;
                            txtNameUa.Text = country?.CountryTr?.SingleOrDefault(i => i.Lang == "Uk")?.CountryName;
                            txtNameRu.Text = country?.CountryTr?.SingleOrDefault(i => i.Lang == "Ru")?.CountryName;
                            txtNameEn.Text = country?.CountryTr?.SingleOrDefault(i => i.Lang == "En")?.CountryName;
                            break;
                        case "creativeroletype":
                            var creativeRoleType = _creativeRoleTypeList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                            txtCode.Text = creativeRoleType?.CodeI.ToString();
                            txtNameUa.Text = creativeRoleType?.CreativeRoleTypeTr?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                            txtNameRu.Text = creativeRoleType?.CreativeRoleTypeTr?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                            txtNameEn.Text = creativeRoleType?.CreativeRoleTypeTr?.SingleOrDefault(i => i.Lang == "En")?.Name;
                            break;
                        case "genretype":
                            var genreType = _genreTypeList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                            txtCode.Text = genreType?.CodeI.ToString();
                            txtNameUa.Text = genreType?.GenreTypeTr?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                            txtNameRu.Text = genreType?.GenreTypeTr?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                            txtNameEn.Text = genreType?.GenreTypeTr?.SingleOrDefault(i => i.Lang == "En")?.Name;
                            break;
                        case "klr030":
                            var klR030 = _klR030List?.SingleOrDefault(rec => rec.R030 == items.Code);
                            txtCode.Text = klR030?.R030;
                            txtNameUa.Text = klR030?.KlR030tr?.SingleOrDefault(i => i.Lang == "Uk")?.R030Name;
                            txtNameRu.Text = klR030?.KlR030tr?.SingleOrDefault(i => i.Lang == "Ru")?.R030Name;
                            txtNameEn.Text = klR030?.KlR030tr?.SingleOrDefault(i => i.Lang == "En")?.R030Name;
                            break;
                    }
                }
                else
                {
                    var item = _list?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                    txtCode.Text = item?.CodeI.ToString();
                    txtNameUa.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang.TrimEnd() == "Uk")?.Name;
                    txtNameRu.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang.TrimEnd() == "Ru")?.Name;
                    txtNameEn.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang.TrimEnd() == "En")?.Name;
                }
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

        /// <summary>
        /// Метод зміни стану увімкненості компонентів
        /// </summary>
        /// <param name="isEnable">Якщо true - компонент активний</param>
        private void ChangeEnableElementsWhenEdit(bool isEnable)
        {
            gvDictionariesList.Enabled = isEnable;
            treeViewList.Enabled = isEnable;
            btnAdd.Enabled = isEnable;
            btnRemove.Enabled = isEnable;
            txtSearchData.Enabled = isEnable;
            txtTreeFilter.Enabled = isEnable;
        }

        private void ChangeEnableElementsWhenAdd(bool isEnable)
        {
            btnAdd.Enabled = isEnable;
            txtSearchData.Enabled = isEnable;
            treeViewList.Enabled = isEnable;
            txtTreeFilter.Enabled = isEnable;
            gvDictionariesList.Enabled = isEnable;
            btnRemove.Enabled = isEnable;
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
            UpdateEditPanel();
        }
        //method for save last position cursor
        private void GetLstCurs()
        {
            //save position
            _indexRow = gvDictionariesList.CurrentRow.Index;
        }

        //method for set saved position cursor
        private void SetLstCurs()
        {
            //set position
            gvDictionariesList.CurrentRow = gvDictionariesList.Rows[_indexRow];
        }
        //method for set position after delete
        private void SetPositionAfterDelete()
        {
            //set last position
            gvDictionariesList.CurrentRow = gvDictionariesList.Rows[gvDictionariesList.RowCount - 1];
        }
        //method for set position after added
        private void SetPositionAfterAdded()
        {
            //set last position
            gvDictionariesList.CurrentRow = gvDictionariesList.Rows[gvDictionariesList.RowCount - 1];
        }

        //додавання нового рядка
        private void radBtnAdd_Click(object sender, EventArgs e)
        {
            //use last selected row
            GetLstCurs();
            btnSave.Text = "Додати";
            ChangeEnableElementsWhenAdd(false);
            txtCode.Clear();
            txtNameEn.Clear();
            txtNameRu.Clear();
            txtNameUa.Clear();
            radPanelChange.Enabled = true;
        }
        
        //кнопка видалення рядка в grid
        private void radBtnRemove_Click(object sender, EventArgs e)
        {
            var row = gvDictionariesList.CurrentRow.DataBoundItem as ViewTable;
            var result = _connector.DeleteItem(Url, row.Code);

            gvDictionariesList.DataSource = GetData();
            UpdateEditPanel();
            //set last position for cursor
            SetPositionAfterDelete();
        }

        //кнопка збереження
        private void radBtnSave_Click(object sender, EventArgs e)
        {
            if (_complexDictionaryList.Contains(DictionaryName.ToLower()))
            {
                var row = gvDictionariesList.CurrentRow.DataBoundItem as ViewTable;

                switch (DictionaryName.ToLower())
                {
                    case "copyrightkind":
                        var copyrightKind = _copyrightKindList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(row.Code));
                        // CrkindGroup
                        var customDict = (List<DictBaseTypeI>)IpsGlobal.AnketaDictionaties.crkindGroup;
                        //initialize object form with parameters
                        //ComplexDictionaryParamForm formComplex = new ComplexDictionaryParamForm(copyrightKind, customDict);
                        MessageBox.Show($"Before: {copyrightKind.CrGroupCode}");
                        //open form with current data complexive dictionaries
                        //if(formComplex.ShowDialog() == DialogResult.OK)
                        //{
                        //    MessageBox.Show($"After: {copyrightKind.CrGroupCode}");
                        //}
                        break;
                    case "country":
                        var country = _countryList?.SingleOrDefault(result => result.ContinentCode == Convert.ToInt32(row.Code));
                        var customDictCountry = (List<DictBaseTypeI>)IpsGlobal.AnketaDictionaties.country;
                        //initialize object form with parameters
                        //ComplexDictionaryParamForm formComParam = new ComplexDictionaryParamForm(country: country, continent: customDictCountry);
                        //open form with current data complexive dictionaries

                        break;
                    case "creativeroletype":
                        var creativeroletype = _creativeRoleTypeList?.SingleOrDefault(obj => obj.CodeI == Convert.ToInt32(row.Code));
                        var customDictCreateRoleType = (List<DictBaseTypeI>)IpsGlobal.AnketaDictionaties.creativeRoleType;

                        //initialize object form with parameters
                        //ComplexDictionaryParamForm formCoPar = new ComplexDictionaryParamForm(roleType: creativeroletype, listRoleType: customDictCreateRoleType);
                        //open from with current data complexive dictionaries

                        break;
                    case "genretype":
                        var genretype = _genreTypeList?.SingleOrDefault(res => res.CodeI == Convert.ToInt32(row.Code));
                        var customDictGenreType = (List<DictBaseTypeI>)IpsGlobal.AnketaDictionaties.genreType;
                        //initialize object form with parameters
                        //ComplexDictionaryParamForm formCP = new ComplexDictionaryParamForm(genreType: genretype, listGenreType: customDictGenreType);
                        //open from with current data complexive dictionaries

                        break;
                    case "klr030":
                        var klr030 = _klR030List?.SingleOrDefault(getObj => getObj.NOmin == Convert.ToInt32(row.Code));
                        var customDictKlr030 = (List<Country>)IpsGlobal.AnketaDictionaties.klR030;
                        //initialize object form with parameters
                        //ComplexDictionaryParamForm formCoParam = new ComplexDictionaryParamForm(klr030: klr030, klr030List: customDictKlr030);
                        //open form with current data complexive dictionaries

                        break;
                }
            }
            else
            {
                if (btnSave.Text == "Додати")
                {
                    SaveAddNewRow();
                }
                else
                {
                    SaveUpdate();
                    ChangeEnableElementsWhenEdit(true);
                }
            }

            ////set last row focus
            //SetLstCurs();
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
            //save last position
            GetLstCurs();
            ChangeEnableElementsWhenEdit(false);
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