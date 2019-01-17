using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using WebAPIConnector;
using ipsFormsDesign.Dictionary;
using sysAdminwp.ComplexDictionaryControls;

namespace sysAdminwp.viewPageDictionaryControls
{
    public partial class ComplexDictionaryControl : UserControl
    {
        //initialize connector
        private readonly ApiConnector _connector = new ApiConnector();

        //variable for all dictionaries
        private List<DictCategory> _dictionaryCategories;
        //variable only for complex dictionaries
        private List<DicCategoryItems> _complexDictionary;
        //variable for - copyrightkind dictionary
        private List<CopyrightKind> _copyrightKindList;
        //variable for - country
        private List<Country> _countryList;
        //variable for - creativeroletypelist
        private List<CreativeRoleType> _creativeRoleTypeList;
        //variable for - genretype
        private List<GenreType> _genreTypeList;
        //variable for - klr030
        private List<KlR030> _klR030List;
        //variable for detect started complex dictionary controls for next set clear
        private static string StartingTypeForInitializeControl = null;
        //strings for complex dictionaries
        private readonly List<string> _complexDictionaryList = new List<string>
        {
            "copyrightkind",
            "country",
            "creativeroletype",
            "genretype",
            "klr030"
        };
        //variable for position focus select into grid
        private static int indexValueGrid = 0;

        //define Url value for complexTreeView
        public string UrlForComplexDictionaries
        {
            get
            {
                //select current position into complexTreeView
                var nodeComplexDictionary = complexTreeView.SelectedNode;
                //if position is null, then return empty string
                if (nodeComplexDictionary == null) return string.Empty;
                //get data for current selected object
                var currentDataComplexdictionary = _complexDictionary[nodeComplexDictionary.Index];
                //if data isn't exist, then rturn empty string
                if (currentDataComplexdictionary == null) return string.Empty;
                //return Url for current object
                return currentDataComplexdictionary.Url;
            }
        }

        //get current selected complex dictionary
        public string ComplexDictionaryName
        {
            get
            {
                //current select position into complexTreeView
                var node = complexTreeView.SelectedNode;
                //if current select is null, then return Empty string
                if (node == null) return string.Empty;
                //get data about current select position
                var currentDataDictionary = _complexDictionary[node.Index];
                //if not have data, then return Empty string
                if (currentDataDictionary == null) return string.Empty;
                return currentDataDictionary.DicName;
            }
        }
        public ComplexDictionaryControl()
        {
            InitializeComponent();
            //fill treeView
            SetTreeViewComplexDictionaryDataSource();

            //setup search action into grid for element
            txtSearchComplex.SetUsageGrid(gvComplexDictionariesList);

            //set current enabled states for elements
            elementsEnabledStatesControler();
            //hide buttons save/cancel into edit panel
            changeEnabledStateButtonsEditPanels(false);
        }

        //method for get data about complex dictionaries
        private void SetTreeViewComplexDictionaryDataSource()
        {
            //initialize variable with new dictionaries
            _dictionaryCategories = _connector.GetList<DictCategory>("dictionary/list");//дерево
            //initialize empty variable for next save complex dictionaries
            _complexDictionary = new List<DicCategoryItems>();
            //read every dictionaries
            foreach (var category in _dictionaryCategories)
            {
                //select only complex dictionaries
                var items = category.DicCategoryItems.Where(rec => rec.DicLevel == 2).ToList();
                //if new items is not empty then
                if (items.Any())
                {
                    //add sorted complex dictionaries into variable for complex dictionaries
                    _complexDictionary.AddRange(items);
                }
            }
            //sort by name all complex dicitonaries
            _complexDictionary = _complexDictionary.OrderBy(i => i.Name).ToList();
            //set complex dictionaries as like source for treeViewList
            complexTreeView.DataSource = _complexDictionary;
            //show only data field 'Name'
            complexTreeView.DisplayMember = "Name";
        }

        //method for get complex dicitonary data return List<ViewTable> for grid
        private List<ViewTable> GetComplexDictionariesData()
        {
            //initialize empty variable for return all complex dictionaries
            var view = new List<ViewTable>();
            //conditions for current complex dictionary
            switch (ComplexDictionaryName.ToLower())
            {
                //if current - copyrightkind
                case "copyrightkind":
                    //initialize variable with all complex dictionaries type - CopyRightKind
                    _copyrightKindList = _connector.GetList<CopyrightKind>(UrlForComplexDictionaries);
                    //set data for grid
                    //read every dictionary
                    foreach (var item in _copyrightKindList)
                    {
                        //initialize object with data for every column
                        view.Add(new ViewTable
                        {
                            Code = item.CodeI.ToString(),
                            NameUk = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                            NameRu = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "RU")?.Name,
                            NameEn = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                        });
                    }
                    //save current complex dictionary type, for next remove current control before initialize other control
                    StartingTypeForInitializeControl = "copyrightkind";
                    break;
                //if current - country
                case "country":
                    //initialize variable with all complex dictionaries type - Country
                    _countryList = _connector.GetList<Country>(UrlForComplexDictionaries);
                    //set data for grid
                    //read every dictionary
                    foreach (var item in _countryList)
                    {
                        //initialize object with data for every column
                        view.Add(new ViewTable
                        {
                            Code = item.CountryCode,
                            NameUk = item.CountryTr?.SingleOrDefault(i => i?.Lang == "Uk")?.CountryName ?? item.CountryName,
                            NameRu = item.CountryTr?.SingleOrDefault(i => i?.Lang == "Ru")?.CountryName,
                            NameEn = item.CountryTr?.SingleOrDefault(i => i?.Lang == "En")?.CountryName,
                        });
                        
                    }
                    //save current complex dictionary type
                    StartingTypeForInitializeControl = "country";
                    break;
                //if current - creativeroletype
                case "creativeroletype":
                    //initialize variable with all complex dictionaries type - CreativeRoleType
                    _creativeRoleTypeList = _connector.GetList<CreativeRoleType>(UrlForComplexDictionaries);
                    //read every dictionary
                    foreach (var item in _creativeRoleTypeList)
                    {
                        //initialize object with data for every column
                        view.Add(new ViewTable
                        {
                            Code = item.CodeI.ToString(),
                            NameUk = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                            NameRu = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                            NameEn = item.CreativeRoleTypeTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                        });
                    }
                    //save current complex dictionary type
                    StartingTypeForInitializeControl = "creativeroletype";
                    break;
                //if current - genretype
                case "genretype":
                    //initialize variable with all complex dictionaries type - GenreType
                    _genreTypeList = _connector.GetList<GenreType>(UrlForComplexDictionaries);
                    //read every dictionary
                    foreach (var item in _genreTypeList)
                    {
                        //initialize object with data for every column
                        view.Add(new ViewTable
                        {
                            Code = item.CodeI.ToString(),
                            NameUk = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                            NameRu = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                            NameEn = item.GenreTypeTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                        });
                    }
                    //save current complex dictionary type
                    StartingTypeForInitializeControl = "genretype";
                    break;
                //if current - klr030
                case "klr030":
                    //initialize variable with all complex dictionaries type - KLR030
                    _klR030List = _connector.GetList<KlR030>(UrlForComplexDictionaries);
                    //read every dictionary
                    foreach (var item in _klR030List)
                    {
                        //initialize object with data for every column
                        view.Add(new ViewTable
                        {
                            Code = item.R030,
                            NameUk = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Uk")?.R030Name ?? item.R030Name,
                            NameRu = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Ru")?.R030Name,
                            NameEn = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "En")?.R030Name,
                        });
                    }
                    //save current complex dictionary type
                    StartingTypeForInitializeControl = "klr030";
                    break;
            }
            //return all data for fill grid
            return view;
        }

        private void gvComplexDictionariesList_SelectionChanged(object sender, EventArgs e)
        {
            //method for update Edit panel
            UpdateEditPanelComplex();
            //get data about current selected row
            var row = gvComplexDictionariesList.CurrentRow.DataBoundItem as ViewTable;
            //conditions for choosing control
            switch (StartingTypeForInitializeControl)
            {
                //if current - copyrightkind
                case "copyrightkind":
                    //get data for copyRightKind object
                    var copyrightKind = _copyrightKindList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(row.Code));
                    //get data list CrkindGroup - changed to DictBaseTypeI
                    var baseDictsCopyRight = _connector.GetList<DictBaseTypeI>("dictionary/base/CrkindGroup");
                    //initialize control CopyRightKindDictionaryControl
                    CopyRightKindDictionaryControl copyRightKindControl = new CopyRightKindDictionaryControl(copyrightKind, baseDictsCopyRight)
                    { Dock = DockStyle.Fill };
                    controlsParamPanel.Controls.Clear();
                    controlsParamPanel.Controls.Add(copyRightKindControl);
                    break;
                //if current - country
                case "country":
                    // get data for country object
                    var country = _countryList?.SingleOrDefault(result => result.ContinentCode == Convert.ToInt32(row.Code));
                    //get data list Continent - changed to DictBaseTypeI
                    var baseDictsCountry = _connector.GetList<DictBaseTypeI>("dictionary/base/Continent");
                    //initialize control CountryDictionaryControl
                    CountryDictionaryControl countryDictionaryControl = new CountryDictionaryControl(country, baseDictsCountry)
                    { Dock = DockStyle.Fill };
                    controlsParamPanel.Controls.Clear();
                    controlsParamPanel.Controls.Add(countryDictionaryControl);
                    break;
                //if current - creativeroletype
                case "creativeroletype":
                    //get data for creativeRoleType object
                    var creativeroletype = _creativeRoleTypeList?.SingleOrDefault(obj => obj.CodeI == Convert.ToInt32(row.Code));
                    //get data list Category - changed to DictBaseTypeI
                    var baseDictsCreative = _connector.GetList<DictBaseTypeI>("dictionary/base/Category");
                    //Initialize control CreativeRoleTypeDictionary
                    CreativeRoleTypeDictionaryControl creativeRoleDictionaryControl = new CreativeRoleTypeDictionaryControl(creativeroletype, baseDictsCreative, new List<CopyrightType>())
                    { Dock = DockStyle.Fill };
                    controlsParamPanel.Controls.Clear();
                    controlsParamPanel.Controls.Add(creativeRoleDictionaryControl);
                    break;
                //if current - genretype
                case "genretype":
                    //get data for GenreType object
                    var genretype = _genreTypeList?.SingleOrDefault(res => res.CodeI == Convert.ToInt32(row.Code));
                    //get data list Category - changed to DictBaseTypeI
                    var baseDictsGenreType = _connector.GetList<DictBaseTypeI>("dictionary/base/Category");
                    //initialize control GenretypeDictionaryControl
                    GenreTypeDictionaryControl genreTypeDictionaryControl = new GenreTypeDictionaryControl(genretype, baseDictsGenreType)
                    { Dock = DockStyle.Fill };
                    controlsParamPanel.Controls.Clear();
                    controlsParamPanel.Controls.Add(genreTypeDictionaryControl);
                    break;
                //if current - klr030
                case "klr030":
                    //get data for KlR030 object
                    var klr030 = _klR030List?.SingleOrDefault(getObj => getObj.NOmin == Convert.ToInt32(row.Code));
                    //get data list Country - changed to DictBaseTypeI
                    var customDictKlr030 = _connector.GetList<DictBaseTypeI>("dictionary/base/Country");
                    //initialize control Klr030DictionaryControl
                    Klr030DictionaryControl klrDictionaryControl = new Klr030DictionaryControl(klr030, customDictKlr030)
                    { Dock = DockStyle.Fill };
                    controlsParamPanel.Controls.Clear();
                    controlsParamPanel.Controls.Add(klrDictionaryControl);
                    break;
            }

        }
        //changes when select complex dictionary into complexTreeView
        private void complexTreeView_SelectedNodeChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            //if index is exist into selected complex dictionary
            if (e.Node?.Index == null)
            {
                //show defult panel settings

                return;
            }
            //initialize variable with selected complex dictionary
            var categoryItem = _complexDictionary[e.Node.Index];
            //if data dictionary is null
            if (categoryItem == null)
            {
                //show default panel settings

                return;
            }
            //load data to the grid about current complex dictionaries
            //initialize variable with result data for grid
            var returnedList = GetComplexDictionariesData();
            //bind data for grid
            gvComplexDictionariesList.DataSource = returnedList;
        }
        //method control enable state next elements - 
        //editPanel, txtsearchComplex, btnAddComplex, btnDeleteComplex
        private void elementsEnabledStatesControler()
        {
            //initialize current grid state for next reaction elements states
            bool stateEnabled = gvComplexDictionariesList.RowCount != 0;
            //search text element
            txtSearchComplex.Enabled = stateEnabled;
            //button for add new object
            btnAddComplex.Enabled = stateEnabled;
            //button for delete object
            btnDeleteComplex.Enabled = stateEnabled;
            //panel for parameters complex dictionaries
            controlsParamPanel.Enabled = stateEnabled;
            //edit Panel
            editPanel.Enabled = stateEnabled;

        }
        //event for control current enabled states for elements
        private void gvComplexDictionariesList_DataBindingComplete(object sender, Telerik.WinControls.UI.GridViewBindingCompleteEventArgs e)
        {
            //check current state data into grid
            elementsEnabledStatesControler();
        }
        //event for add new row
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            indexValueGrid = gvComplexDictionariesList.CurrentRow.Index;
            //set new Text for save button
            btnSave.Text = "Додати";
            //clear editPanel
            ChangeEnableElementsWhenAdd(false);
            txtCodeComplex.Clear();
            txtNameUaComplex.Clear();
            txtNameRuComplex.Clear();
            txtNameEnComplex.Clear();
            editPanel.Enabled = true;
            //enable save/cancel buttons into edit panel
            changeEnabledStateButtonsEditPanels(true);
        }

        //method for change current enabled state for next elements
        private void ChangeEnableElementsWhenAdd(bool isEnable)
        {
            complexTreeView.Enabled = isEnable;
            txtSearchComplex.Enabled = isEnable;
            gvComplexDictionariesList.Enabled = isEnable;
            btnAddComplex.Enabled = isEnable;
            btnDeleteComplex.Enabled = isEnable;
        }

        //event for detect changes into textboxes
        private void txtCodeComplex_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            //hide other elements
            ChangeEnableElementsWhenAdd(false);
            //show parameters
            controlsParamPanel.Enabled = true;
            //show editPanel
            editPanel.Enabled = true;
            //enabled save/cancel buttons into editPanel
            changeEnabledStateButtonsEditPanels(true);
        }
        //method for enabled state buttons save and cancel into edit panel
        private void changeEnabledStateButtonsEditPanels(bool isEnable)
        {
            //button save
            btnSave.Enabled = isEnable;
            //button cancel
            btnCancel.Enabled = isEnable;
        }
        //event for save data into edit panel
        private void btnSave_Click(object sender, EventArgs e)
        {
            //hide buttons save/cancel into edit panel
            changeEnabledStateButtonsEditPanels(false);
            //show other elements
            ChangeEnableElementsWhenAdd(true);

            if (btnSave.Text == "Додати")
            {
                //save new row
                SaveAddNewRow();
            }
            else
            {
                //save changes row

            }
            //set last position into grid
            gvComplexDictionariesList.CurrentRow = gvComplexDictionariesList.Rows[indexValueGrid];
        }
        //event for cancel all changes into textboxes edit panel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //hide buttons save/cancel into edit panel
            changeEnabledStateButtonsEditPanels(false);
            //show other elements
            ChangeEnableElementsWhenAdd(true);
        }

        //method for save new row
        public void SaveAddNewRow()
        {
            if (txtCodeComplex.Text != string.Empty)
            {
                if ((Convert.ToInt32(txtCodeComplex.Text)).GetType() != typeof(int))
                    txtCodeComplex.Text = gvComplexDictionariesList.CurrentRow.Cells["Code"].Value.ToString();

                btnSave.Text = "Зберегти";
                
                try
                {
                    DictBaseTypeI dataI = PackDataI();
                    bool result = _connector.NewItem(UrlForComplexDictionaries, dataI);

                    gvComplexDictionariesList.DataSource = GetComplexDictionariesData();
                    UpdateEditPanelComplex();
                    ChangeEnableElementsWhenAdd(true);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {//radLabelCode.Text
                MessageBox.Show("Поле '" + "" + "' не повинно бути пустим!",
                    "Заповніть поле!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        //метод оновлення для панелі редагування
        private void UpdateEditPanelComplex()
        {
            //відписуємось від події - обрали інший рядок, зміни не внесено
            txtCodeComplex.TextChanging -= txtCodeComplex_TextChanging;
            txtNameUaComplex.TextChanging -= txtCodeComplex_TextChanging;
            txtNameRuComplex.TextChanging -= txtCodeComplex_TextChanging;
            txtNameEnComplex.TextChanging -= txtCodeComplex_TextChanging;

            if (gvComplexDictionariesList.CurrentRow?.DataBoundItem is ViewTable items)
            {
                if (_complexDictionaryList.Contains(ComplexDictionaryName.ToLower()))
                {
                    // TODO: для складних довідників підтягнути додаткові потрібні словники, сформувати інтерфейс
                    // біндінг даних
                    switch (ComplexDictionaryName.ToLower())
                    {
                        case "copyrightkind":
                            var copyrightKind = _copyrightKindList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                            txtCodeComplex.Text = copyrightKind?.CodeI.ToString();
                            txtNameUaComplex.Text = copyrightKind?.CopyrightKindTr?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                            txtNameRuComplex.Text = copyrightKind?.CopyrightKindTr?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                            txtNameEnComplex.Text = copyrightKind?.CopyrightKindTr?.SingleOrDefault(i => i.Lang == "En")?.Name;
                            break;
                        case "country":
                            var country = _countryList?.SingleOrDefault(rec => rec.CountryCode == items.Code);
                            txtCodeComplex.Text = country?.CountryCode;
                            txtNameUaComplex.Text = country?.CountryTr?.SingleOrDefault(i => i.Lang == "Uk")?.CountryName;
                            txtNameRuComplex.Text = country?.CountryTr?.SingleOrDefault(i => i.Lang == "Ru")?.CountryName;
                            txtNameEnComplex.Text = country?.CountryTr?.SingleOrDefault(i => i.Lang == "En")?.CountryName;
                            break;
                        case "creativeroletype":
                            var creativeRoleType = _creativeRoleTypeList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                            txtCodeComplex.Text = creativeRoleType?.CodeI.ToString();
                            txtNameUaComplex.Text = creativeRoleType?.CreativeRoleTypeTr?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                            txtNameRuComplex.Text = creativeRoleType?.CreativeRoleTypeTr?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                            txtNameEnComplex.Text = creativeRoleType?.CreativeRoleTypeTr?.SingleOrDefault(i => i.Lang == "En")?.Name;
                            break;
                        case "genretype":
                            var genreType = _genreTypeList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                            txtCodeComplex.Text = genreType?.CodeI.ToString();
                            txtNameUaComplex.Text = genreType?.GenreTypeTr?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                            txtNameRuComplex.Text = genreType?.GenreTypeTr?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                            txtNameEnComplex.Text = genreType?.GenreTypeTr?.SingleOrDefault(i => i.Lang == "En")?.Name;
                            break;
                        case "klr030":
                            var klR030 = _klR030List?.SingleOrDefault(rec => rec.R030 == items.Code);
                            txtCodeComplex.Text = klR030?.R030;
                            txtNameUaComplex.Text = klR030?.KlR030tr?.SingleOrDefault(i => i.Lang == "Uk")?.R030Name;
                            txtNameRuComplex.Text = klR030?.KlR030tr?.SingleOrDefault(i => i.Lang == "Ru")?.R030Name;
                            txtNameEnComplex.Text = klR030?.KlR030tr?.SingleOrDefault(i => i.Lang == "En")?.R030Name;
                            break;
                    }
                }
                //else
                //{
                //    var item = _list?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                //    txtCodeComplex.Text = item?.CodeI.ToString();
                //    txtNameUaComplex.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                //    txtNameRuComplex.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                //    txtNameEnComplex.Text = item?.DictTrI?.SingleOrDefault(i => i.Lang == "En")?.Name;
                //}
            }
            else
            {
                txtCodeComplex.Text = default(string);
                txtNameUaComplex.Text = default(string);
                txtNameRuComplex.Text = default(string);
                txtNameEnComplex.Text = default(string);
            }

            txtCodeComplex.TextChanging += txtCodeComplex_TextChanging;
            txtNameUaComplex.TextChanging += txtCodeComplex_TextChanging;
            txtNameRuComplex.TextChanging += txtCodeComplex_TextChanging;
            txtNameEnComplex.TextChanging += txtCodeComplex_TextChanging;
            // hide default string
            gvComplexDictionariesList.TableElement.Text = "";
        }
        private DictBaseTypeI PackDataI()
        {
            DictBaseTypeI dataI = new DictBaseTypeI();
            var dataTrI = new DictTrI[3];
            dataTrI[0] = new DictTrI() { CodeI = Convert.ToInt32(txtCodeComplex.Text), Lang = "En", Name = txtNameEnComplex.Text };
            dataTrI[1] = new DictTrI() { CodeI = Convert.ToInt32(txtCodeComplex.Text), Lang = "Ru", Name = txtNameRuComplex.Text };
            dataTrI[2] = new DictTrI() { CodeI = Convert.ToInt32(txtCodeComplex.Text), Lang = "Uk", Name = txtNameUaComplex.Text };

            dataI.CodeI = dataTrI[0].CodeI;
            dataI.Name = txtNameUaComplex.Text;
            dataI.DictTrI = new List<DictTrI>
            {
                dataTrI[0],dataTrI[1],dataTrI[2]
            };
            return dataI;
        }
        //метод збереження змін !! null code
        public void SaveUpdate()
        {
            if ((txtCodeComplex.TextLength == 0) && (Convert.ToInt32(txtCodeComplex.Text)).GetType() != typeof(int))
                txtCodeComplex.Text = gvComplexDictionariesList.CurrentRow.Cells["Code"].Value.ToString();

            DictBaseTypeI dataI = PackDataI();
            // TODO: use result
            bool result = _connector.UpdateItem<DictBaseTypeI>(UrlForComplexDictionaries, dataI.CodeI.ToString(), (DictBaseTypeI)dataI);

            gvComplexDictionariesList.DataSource = GetComplexDictionariesData();
            UpdateEditPanelComplex();
        }

        private void btnDeleteComplex_Click(object sender, EventArgs e)
        {
            //save index
            indexValueGrid = gvComplexDictionariesList.CurrentRow.Index;
            var row = gvComplexDictionariesList.CurrentRow.DataBoundItem as ViewTable;
            var result = _connector.DeleteItem(UrlForComplexDictionaries, row.Code);

            gvComplexDictionariesList.DataSource = GetComplexDictionariesData();
            UpdateEditPanelComplex();
            //set focus
            gvComplexDictionariesList.CurrentRow = gvComplexDictionariesList.Rows[indexValueGrid - 1];
        }
    }
}
