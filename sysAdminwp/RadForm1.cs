using System;
using System.CodeDom;
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
using System.Reflection;
using ipsFormsDesign.Dictionary;
using sysAdminwp.Properties;
using WebAPIConnector;
using ipsFormsDesign.Model;

namespace sysAdminwp
{
    public partial class RadForm1 : RadForm
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
        private List<DictCategory> _dictionaryCategories = null;

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

        public RadForm1()
        {
            InitializeComponent();
            SetTreeViewDataSource();
            
            UpdateEditPanel();

            radTxtBoxSearchData.TextChanged += RadTxtBoxSearchData_TextChanged;
            radGridView1.CustomFiltering += RadGridView1_CustomFiltering;
            radGridView1.CurrentRowChanged += RadGridView1_CurrentRowChanged;
            
            radPanelChange.Enabled = false;
            radTxtBoxSearchData.Enabled = false;
            radBtnAdd.Enabled = false;
            radBtnRemove.Enabled = false;
        }

        #region * * * Методи * * *

        /// <summary>
        /// Встановлення джерела даних для Tree View
        /// </summary>
        private void SetTreeViewDataSource()
        {
            _dictionaryCategories = _connector.GetList<DictCategory>("dictionary/list");//дерево
            foreach (var category in _dictionaryCategories)
            {
                var categoryItems = new List<DicCategoryItems>();
                categoryItems.AddRange(category.DicCategoryItems.OrderBy(i => i.Name).ToList());
                category.DicCategoryItems.Clear();
                foreach (var i in categoryItems)
                    category.DicCategoryItems.Add(i);
            }
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

            // складні словники
            if (_complexDictionaryList.Contains(DictionaryName.ToLower()))
            {
                switch (DictionaryName.ToLower())
                {
                    case "copyrightkind":
                        _copyrightKindList = _connector.GetList<CopyrightKind>(Url);
                        foreach (var item in _copyrightKindList)
                        {
                            view.Add(new ViewTable
                            {
                                Code = item.CodeI.ToString(),
                                NameUk = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                                NameRu = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                                NameEn = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                            });
                        }
                        break;
                    case "country":
                        _countryList = _connector.GetList<Country>(Url);
                        foreach (var item in _countryList)
                        {
                            view.Add(new ViewTable
                            {
                                Code = item.CountryCode,
                                NameUk = item.CountryTr?.SingleOrDefault(i => i?.Lang == "Uk")?.CountryName?? item.CountryName,
                                NameRu = item.CountryTr?.SingleOrDefault(i => i?.Lang == "Ru")?.CountryName,
                                NameEn = item.CountryTr?.SingleOrDefault(i => i?.Lang == "En")?.CountryName,
                            });
                        }
                        break;
                    case "creativeroletype":
                        _creativeRoleTypeList = _connector.GetList<CreativeRoleType>(Url);
                        foreach (var item in _creativeRoleTypeList)
                        {
                            view.Add(new ViewTable
                            {
                                Code = item.CodeI.ToString(),
                                NameUk = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                                NameRu = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                                NameEn = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                            });
                        }
                        break;
                    case "genretype":
                        _genreTypeList = _connector.GetList<GenreType>(Url);
                        foreach (var item in _genreTypeList)
                        {
                            view.Add(new ViewTable
                            {
                                Code = item.CodeI.ToString(),
                                NameUk = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                                NameRu = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                                NameEn = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                            });
                        }
                        break;
                    case "klr030":
                        _klR030List = _connector.GetList<KlR030>(Url);
                        foreach (var item in _klR030List)
                        {
                            view.Add(new ViewTable
                            {
                                Code = item.R030,
                                NameUk = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Uk")?.R030Name?? item.R030Name,
                                NameRu = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Ru")?.R030Name,
                                NameEn = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "En")?.R030Name,
                            });
                        }
                        break;
                }
            }
            // прості словники
            else
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
            // TODO: use result
            bool result = _connector.UpdateItem<DictBaseTypeI>(Url,dataI.CodeI.ToString(),(DictBaseTypeI)dataI);

            radGridView1.DataSource = GetData();
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
                    bool result = _connector.NewItem(Url, dataI);

                    radGridView1.DataSource = GetData();
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

            if (radGridView1.CurrentRow?.DataBoundItem is ViewTable items)
            {
                if (_complexDictionaryList.Contains(DictionaryName.ToLower()))
                {
                    // TODO: для складних довідників підтягнути додаткові потрібні словники, сформувати інтерфейс
                    // біндінг даних
                    switch (DictionaryName.ToLower())
                    {
                        case "copyrightkind":
                            var copyrightKind = _copyrightKindList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                            radTBCode.Text = copyrightKind?.CodeI.ToString();
                            radTBNameUa.Text = copyrightKind?.CopyrightKindTr?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                            radTBNameRu.Text = copyrightKind?.CopyrightKindTr?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                            radTBNameEn.Text = copyrightKind?.CopyrightKindTr?.SingleOrDefault(i => i.Lang == "En")?.Name;
                            break;
                        case "country":
                            var country = _countryList?.SingleOrDefault(rec => rec.CountryCode == items.Code);
                            radTBCode.Text = country?.CountryCode;
                            radTBNameUa.Text = country?.CountryTr?.SingleOrDefault(i => i.Lang == "Uk")?.CountryName;
                            radTBNameRu.Text = country?.CountryTr?.SingleOrDefault(i => i.Lang == "Ru")?.CountryName;
                            radTBNameEn.Text = country?.CountryTr?.SingleOrDefault(i => i.Lang == "En")?.CountryName;
                            break;
                        case "creativeroletype":
                            var creativeRoleType = _creativeRoleTypeList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                            radTBCode.Text = creativeRoleType?.CodeI.ToString();
                            radTBNameUa.Text = creativeRoleType?.CreativeRoleTypeTr?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                            radTBNameRu.Text = creativeRoleType?.CreativeRoleTypeTr?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                            radTBNameEn.Text = creativeRoleType?.CreativeRoleTypeTr?.SingleOrDefault(i => i.Lang == "En")?.Name;
                            break;
                        case "genretype":
                            var genreType = _genreTypeList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                            radTBCode.Text = genreType?.CodeI.ToString();
                            radTBNameUa.Text = genreType?.GenreTypeTr?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                            radTBNameRu.Text = genreType?.GenreTypeTr?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                            radTBNameEn.Text = genreType?.GenreTypeTr?.SingleOrDefault(i => i.Lang == "En")?.Name;
                            break;
                        case "klr030":
                            var klR030 = _klR030List?.SingleOrDefault(rec => rec.R030 == items.Code);
                            radTBCode.Text = klR030?.R030;
                            radTBNameUa.Text = klR030?.KlR030tr?.SingleOrDefault(i => i.Lang == "Uk")?.R030Name;
                            radTBNameRu.Text = klR030?.KlR030tr?.SingleOrDefault(i => i.Lang == "Ru")?.R030Name;
                            radTBNameEn.Text = klR030?.KlR030tr?.SingleOrDefault(i => i.Lang == "En")?.R030Name;
                            break;
                    }
                }
                else
                {
                    var item = _list?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                    radTBCode.Text = item?.CodeI.ToString();
                    radTBNameUa.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                    radTBNameRu.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                    radTBNameEn.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang == "En")?.Name;
                }
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
            treeViewList.Enabled = isEnable;
            radBtnAdd.Enabled = isEnable;
            radBtnRemove.Enabled = isEnable;
            radTxtBoxSearchData.Enabled = isEnable;
            radTxtBoxFilter.Enabled = isEnable;
        }

        private void ChangeEnableElementsWhenAdd(bool isEnable)
        {
            radBtnAdd.Enabled = isEnable;
            radTxtBoxSearchData.Enabled = isEnable;
            treeViewList.Enabled = isEnable;
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
            var row = radGridView1.CurrentRow.DataBoundItem as ViewTable;
            var result = _connector.DeleteItem(Url, row.Code);

            radGridView1.DataSource = GetData();
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
            treeViewList.Filter = radTxtBoxFilter.Text;
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
            radGridView1.DataSource = returnedList;
            

            radPanelChange.Enabled = returnedList != null;
            radTxtBoxSearchData.Enabled = returnedList != null;
            radBtnRemove.Enabled = returnedList != null;
            
            if (returnedList != null)
            {
                LoadOverviewCfg();
            }
            else
            {
                radGridView1.DataSource = default(DataGrid);
                UpdateEditPanel();
            }
            
            radBtnAdd.Enabled = true;
        }

        private void DefaultPanel()
        {
            radGridView1.DataSource = null;
            UpdateEditPanel();
            radPanelChange.Enabled = false;
            radTxtBoxSearchData.Enabled = false;
            radBtnAdd.Enabled = false;
            radBtnRemove.Enabled = false;
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

