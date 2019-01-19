using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Model;
using WebAPIConnector;
using ipsFormsDesign.Dictionary;
using sysAdminwp.ComplexDictionaryControls;

namespace sysAdminwp.viewPageDictionaryControls
{
    public partial class ComplexDictionaryControl : UserControl
    {
        //initialize connector
        private readonly ApiConnector _connector;

        private const string PrefixUpdate = "dictionary/complex/update/";
        private const string PrefixCreate = "dictionary/complex/addnew/";
        private const string PrefixDelete = "dictionary/complex/delete/";

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

        private CopyRightKindDictionaryControl _copyRightKindControl;
        private CountryDictionaryControl _countryDictionaryControl;
        private CreativeRoleTypeDictionaryControl _creativeRoleDictionaryControl;
        private GenreTypeDictionaryControl _genreTypeDictionaryControl;
        private Klr030DictionaryControl _klrDictionaryControl;

        // objects for new items
        private CopyrightKind _copyrightKind;
        private Country _country;
        private CreativeRoleType _creativeRoleType;
        private GenreType _genreType;
        private KlR030 _klR030;

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

        public ViewTable CurrentGridRow => gvComplexDictionariesList.CurrentRow.DataBoundItem as ViewTable;

        public ComplexDictionaryControl(ApiConnector connector)
        {
            InitializeComponent();
            _connector = connector;
            //fill treeView
            SetTreeViewComplexDictionaryDataSource();

            //setup search action into grid for element
            txtSearchComplex.SetUsageGrid(gvComplexDictionariesList);

            //set current enabled states for elements
            ElementsEnabledStatesControler();
            //hide buttons save/cancel into edit panel
            ChangeEnabledStateButtonsEditPanels(false);
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
                            NameRu = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                            NameEn = item.CopyrightKindTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                        });
                    }
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
                    break;
            }
            //return all data for fill grid
            return view;
        }

        private void gvComplexDictionariesList_SelectionChanged(object sender, EventArgs e)
        {
            //method for update Edit panel
            UpdateEditPanelComplex();
            //conditions for choosing control
            switch (ComplexDictionaryName.ToLower())
            {
                //if current - copyrightkind
                case "copyrightkind":
                    //get data for copyRightKind object
                    var copyrightKind = _copyrightKindList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    _copyRightKindControl.CopyrightKindDataSource = copyrightKind;
                    break;
                //if current - country
                case "country":
                    // get data for country object
                    var country = _countryList?.SingleOrDefault(result => result.ContinentCode == Convert.ToInt32(CurrentGridRow.Code));
                    _countryDictionaryControl.CountryDataSource = country;
                    break;
                //if current - creativeroletype
                case "creativeroletype":
                    //get data for creativeRoleType object
                    var creativeroletype = _creativeRoleTypeList?.SingleOrDefault(obj => obj.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    _creativeRoleDictionaryControl.CreativeRoleTypeDataSource = creativeroletype;
                    break;
                //if current - genretype
                case "genretype":
                    //get data for GenreType object
                    var genretype = _genreTypeList?.SingleOrDefault(res => res.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    _genreTypeDictionaryControl.GenreTypeDataSource = genretype;
                    break;
                //if current - klr030
                case "klr030":
                    //get data for KlR030 object
                    var klr030 = _klR030List?.SingleOrDefault(getObj => getObj.NOmin == Convert.ToInt32(CurrentGridRow.Code));
                    _klrDictionaryControl.KlR030DataSource = klr030;
                    break;
            }
        }

        //changes when select complex dictionary into complexTreeView
        private void complexTreeView_SelectedNodeChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            switch (ComplexDictionaryName.ToLower())
            {
                case "copyrightkind":
                    var baseDictsCopyRight = _connector.GetList<DictBaseTypeI>("dictionary/base/CrkindGroup");
                    if (_copyRightKindControl == null)
                        _copyRightKindControl = new CopyRightKindDictionaryControl(baseDictsCopyRight);
                    controlsParamPanel.Controls.Clear();
                    controlsParamPanel.Controls.Add(_copyRightKindControl);
                    break;
                case "country":
                    var baseDictsCountry = _connector.GetList<DictBaseTypeI>("dictionary/base/Continent");
                    if (_countryDictionaryControl == null)
                        _countryDictionaryControl = new CountryDictionaryControl(baseDictsCountry);
                    controlsParamPanel.Controls.Clear();
                    controlsParamPanel.Controls.Add(_countryDictionaryControl);
                    break;
                case "creativeroletype":
                    var baseDictsCreative = _connector.GetList<DictBaseTypeI>("dictionary/base/Category");
                    var baseDictsCopyRightType = _connector.GetList<DictBaseTypeI>("dictionary/base/CopyrightType");
                    if (_creativeRoleDictionaryControl == null)
                        _creativeRoleDictionaryControl = new CreativeRoleTypeDictionaryControl(baseDictsCreative, baseDictsCopyRightType);
                    controlsParamPanel.Controls.Clear();
                    controlsParamPanel.Controls.Add(_creativeRoleDictionaryControl);
                    break;
                case "genretype":
                    var baseDictsGenreType = _connector.GetList<DictBaseTypeI>("dictionary/base/Category");
                    if (_genreTypeDictionaryControl == null)
                        _genreTypeDictionaryControl = new GenreTypeDictionaryControl(baseDictsGenreType);
                    controlsParamPanel.Controls.Clear();
                    controlsParamPanel.Controls.Add(_genreTypeDictionaryControl);
                    break;
                case "klr030":
                    var customDictKlr030 = _connector.GetList<DictBaseTypeI>("dictionary/base/Country");
                    if (_klrDictionaryControl == null)
                        _klrDictionaryControl = new Klr030DictionaryControl(customDictKlr030);
                    controlsParamPanel.Controls.Clear();
                    controlsParamPanel.Controls.Add(_klrDictionaryControl);
                    break;
            }
            //load data to the grid about current complex dictionaries
            //initialize variable with result data for grid
            var returnedList = GetComplexDictionariesData();
            //bind data for grid
            gvComplexDictionariesList.DataSource = returnedList;
        }
        //method control enable state next elements - 
        //editPanel, txtsearchComplex, btnAddComplex, btnDeleteComplex
        private void ElementsEnabledStatesControler()
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
            ElementsEnabledStatesControler();
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
            ChangeEnabledStateButtonsEditPanels(true);

            switch (ComplexDictionaryName.ToLower())
            {
                case "copyrightkind":
                    _copyrightKind = new CopyrightKind() {CrGroupCode = 1, };
                    _copyRightKindControl.CopyrightKindDataSource = _copyrightKind;
                    break;
                case "country":
                    _country = new Country();
                    _countryDictionaryControl.CountryDataSource = _country;
                    break;
                case "creativeroletype":
                    _creativeRoleType = new CreativeRoleType();
                    _creativeRoleDictionaryControl.CreativeRoleTypeDataSource = _creativeRoleType;
                    break;
                case "genretype":
                    _genreType = new GenreType();
                    _genreTypeDictionaryControl.GenreTypeDataSource = _genreType;
                    break;
                case "klr030":
                    _klR030 = new KlR030();
                    _klrDictionaryControl.KlR030DataSource = _klR030;
                    break;
            }
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
            ChangeEnabledStateButtonsEditPanels(true);
        }
        //method for enabled state buttons save and cancel into edit panel
        private void ChangeEnabledStateButtonsEditPanels(bool isEnable)
        {
            //button save
            btnSave.Enabled = isEnable;
            //button cancel
            btnCancel.Enabled = isEnable;
        }
        //event for save data into edit panel
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Додати")
            {
                //save new row
                if(!SaveAddNewRow())
                    return;
                btnSave.Text = "Зберегти";
            }
            else
            {
                //save changes row
                SaveUpdate();
            }

            //hide buttons save/cancel into edit panel
            ChangeEnabledStateButtonsEditPanels(false);
            //show other elements
            ChangeEnableElementsWhenAdd(true);

            //set last position into grid
            gvComplexDictionariesList.CurrentRow = gvComplexDictionariesList.Rows[indexValueGrid];
        }
        //event for cancel all changes into textboxes edit panel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //hide buttons save/cancel into edit panel
            ChangeEnabledStateButtonsEditPanels(false);
            //show other elements
            ChangeEnableElementsWhenAdd(true);
        }

        //method for save new row
        public bool SaveAddNewRow()
        {
            if (string.IsNullOrEmpty(txtCodeComplex.Text))
            {
                MessageBox.Show("Поле \"Код\" не повинно бути пустим!", "Заповніть поле!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            try
            {
                // запакувать
                switch (ComplexDictionaryName.ToLower())
                {
                    // with codeI
                    case "copyrightkind":
                        if (!int.TryParse(txtCodeComplex.Text, out int code))
                        {
                            MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                        _copyrightKind.Name = txtNameUaComplex.Text;
                        _copyrightKind.CodeI = code;
                        _copyrightKind.CopyrightKindTr.Add(new CopyrightKindTr
                        {
                            CodeI = _copyrightKind.CodeI,
                            Name = txtNameUaComplex.Text,
                            Lang = "Uk"
                        });
                        _copyrightKind.CopyrightKindTr.Add(new CopyrightKindTr
                        {
                            CodeI = _copyrightKind.CodeI,
                            Name = txtNameRuComplex.Text,
                            Lang = "Ru"
                        });
                        _copyrightKind.CopyrightKindTr.Add(new CopyrightKindTr
                        {
                            CodeI = _copyrightKind.CodeI,
                            Name = txtNameEnComplex.Text,
                            Lang = "En"
                        });
                        _connector.NewItem(string.Concat(PrefixCreate, ComplexDictionaryName.ToLower()), _copyrightKind);
                        break;
                    case "country":
                        //check posibility convert to int
                        if (!int.TryParse(txtCodeComplex.Text, out int countryCode))
                        {
                            MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                        //save data for 'CountryName' from textbox
                        _country.CountryName = txtNameUaComplex.Text;
                        //save data for 'CodeI' from converted variable
                        _country.CountryCode = txtCodeComplex.Text;
                        //add data for 'Uk'
                        _country.CountryTr.Add(new CountryTr
                        {
                            CountryCode = _country.CountryCode,
                            CountryName = txtNameUaComplex.Text,
                            Lang = "Uk"
                        });
                        //add data for 'Ru'
                        _country.CountryTr.Add(new CountryTr
                        {
                            CountryCode = _country.CountryCode,
                            CountryName = txtNameRuComplex.Text,
                            Lang = "Ru"
                        });
                        //add data for 'En'
                        _country.CountryTr.Add(new CountryTr
                        {
                            CountryCode = _country.CountryCode,
                            CountryName = txtNameEnComplex.Text,
                            Lang = "En"
                        });
                        //send new country to controller
                        _connector.NewItem(string.Concat(PrefixCreate, ComplexDictionaryName.ToLower()), _country);
                        break;
                    case "creativeroletype":
                        //check posibility convert to int
                        if (!int.TryParse(txtCodeComplex.Text, out int creativeCode))
                        {
                            MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                        //save data for 'Name' from textbox
                        _creativeRoleType.Name = txtNameUaComplex.Text;
                        //save data for 'CodeI' from convert variable
                        _creativeRoleType.CodeI = creativeCode;
                        //add data for 'Uk'
                        _creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr
                        {
                            CodeI = _creativeRoleType.CodeI,
                            Name = txtNameUaComplex.Text,
                            Lang = "Uk"
                        });
                        //add data for 'Ru'
                        _creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr
                        {
                            CodeI = _creativeRoleType.CodeI,
                            Name = txtNameRuComplex.Text,
                            Lang = "Ru"
                        });
                        //add data for 'En'
                        _creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr
                        {
                            CodeI = _creativeRoleType.CodeI,
                            Name = txtNameEnComplex.Text,
                            Lang = "En"
                        });
                        //send new creativeroletype to controller
                        _connector.NewItem(string.Concat(PrefixCreate, ComplexDictionaryName.ToLower()), _creativeRoleType);
                        break;
                    case "genretype":
                        //check posibility convert to int
                        if (!int.TryParse(txtCodeComplex.Text, out int genreCode))
                        {
                            MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                        //save data for 'Name' from textbox
                        _genreType.Name = txtNameUaComplex.Text;
                        //save data for 'CodeI' from convert variable
                        _genreType.CodeI = genreCode;
                        //add data for 'Uk'
                        _genreType.GenreTypeTr.Add(new GenreTypeTr
                        {
                            CodeI = _genreType.CodeI,
                            Name = txtNameUaComplex.Text,
                            Lang = "Uk"
                        });
                        //add data for 'Ru'
                        _genreType.GenreTypeTr.Add(new GenreTypeTr
                        {
                            CodeI = _genreType.CodeI,
                            Name = txtNameRuComplex.Text,
                            Lang = "Ru"
                        });
                        //add data for 'En'
                        _genreType.GenreTypeTr.Add(new GenreTypeTr
                        {
                            CodeI = _genreType.CodeI,
                            Name = txtNameEnComplex.Text,
                            Lang = "En"
                        });
                        //send new genretype to controller
                        _connector.NewItem(string.Concat(PrefixCreate, ComplexDictionaryName.ToLower()), _genreType);
                        break;
                    case "klr030":
                        //check posibility convert to int
                        if (!int.TryParse(txtCodeComplex.Text, out int klrCode))
                        {
                            MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                        //save data for 'R030Name' from textbox
                        _klR030.R030Name = txtNameUaComplex.Text;
                        //save data for 'R030' from convert variable
                        _klR030.R030 = txtCodeComplex.Text;
                        //add data for 'Uk'
                        _klR030.KlR030tr.Add(new KlR030tr
                        {
                            R030 = _klR030.R030,
                            Lang = "Uk",
                            R030Name = txtNameUaComplex.Text
                        });
                        //add data for 'Ru'
                        _klR030.KlR030tr.Add(new KlR030tr
                        {
                            R030 = _klR030.R030,
                            Lang = "Ru",
                            R030Name = txtNameRuComplex.Text
                        });
                        //add data for 'En'
                        _klR030.KlR030tr.Add(new KlR030tr
                        {
                            R030 = _klR030.R030,
                            Lang = "En",
                            R030Name = txtNameEnComplex.Text
                        });
                        //send new klt030 to controller
                        _connector.NewItem(string.Concat(PrefixCreate, ComplexDictionaryName.ToLower()), _klR030);
                        break;
                }
                //bool result = _connector.NewItem(UrlForComplexDictionaries, new object());

                gvComplexDictionariesList.DataSource = GetComplexDictionariesData();
                UpdateEditPanelComplex();
                ChangeEnableElementsWhenAdd(true);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
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

        //метод збереження змін !! null code
        public void SaveUpdate()
        {
            if (txtCodeComplex.TextLength == 0 && Convert.ToInt32(txtCodeComplex.Text).GetType() != typeof(int))
                txtCodeComplex.Text = gvComplexDictionariesList.CurrentRow.Cells["Code"].Value.ToString();

            switch (ComplexDictionaryName.ToLower())
            {
                case "copyrightkind":
                    var copyrightKind = _copyrightKindList.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    copyrightKind.CodeI = Convert.ToInt32(txtCodeComplex.Text);
                    copyrightKind.Name = txtNameUaComplex.Text;
                    var uk = copyrightKind.CopyrightKindTr.SingleOrDefault(rec => rec.Lang == "Uk");
                    if (uk == null)
                        copyrightKind.CopyrightKindTr.Add(new CopyrightKindTr
                        {
                            CodeI = copyrightKind.CodeI,
                            Name = txtNameUaComplex.Text,
                            Lang = "Uk",
                        });
                    else
                    {
                        uk.Name = txtNameUaComplex.Text;
                        uk.CodeI = copyrightKind.CodeI;
                    }

                    var ru = copyrightKind.CopyrightKindTr.SingleOrDefault(rec => rec.Lang == "Ru");
                    if (ru == null)
                        copyrightKind.CopyrightKindTr.Add(new CopyrightKindTr
                        {
                            CodeI = copyrightKind.CodeI,
                            Name = txtNameRuComplex.Text,
                            Lang = "Ru",
                        });
                    else
                    {
                        ru.Name = txtNameRuComplex.Text;
                        ru.CodeI = copyrightKind.CodeI;
                    }

                    var en = copyrightKind.CopyrightKindTr.SingleOrDefault(rec => rec.Lang == "En");
                    if (en == null)
                        copyrightKind.CopyrightKindTr.Add(new CopyrightKindTr
                        {
                            CodeI = copyrightKind.CodeI,
                            Name = txtNameEnComplex.Text,
                            Lang = "En",
                        });
                    else
                    {
                        en.Name = txtNameEnComplex.Text;
                        en.CodeI = copyrightKind.CodeI;
                    }

                    _connector.UpdateItem(string.Concat(PrefixUpdate, ComplexDictionaryName.ToLower()), copyrightKind.CodeI.ToString(), copyrightKind);
                    break;
                case "country":
                    var country = _countryList.SingleOrDefault(rec => Convert.ToInt32(rec.CountryCode) == Convert.ToInt32(CurrentGridRow.Code));
                    country.CountryName = txtNameUaComplex.Text;
                    var ukCountry = country.CountryTr.SingleOrDefault(rec => rec.Lang == "Uk");
                    if (ukCountry == null)
                        country.CountryTr.Add(new CountryTr
                        {
                            CountryCode = country.CountryCode,
                            CountryName = txtNameUaComplex.Text,
                            Lang = "Uk",
                        });
                    else
                        ukCountry.CountryName = txtNameUaComplex.Text;

                    var ruCountry = country.CountryTr.SingleOrDefault(rec => rec.Lang == "Ru");
                    if (ruCountry == null)
                        country.CountryTr.Add(new CountryTr
                        {
                            CountryCode = country.CountryCode,
                            CountryName = txtNameRuComplex.Text,
                            Lang = "Ru",
                        });
                    else
                        ruCountry.CountryName = txtNameRuComplex.Text;

                    var enCountry = country.CountryTr.SingleOrDefault(rec => rec.Lang == "En");
                    if (enCountry == null)
                        country.CountryTr.Add(new CountryTr
                        {
                            CountryCode = country.CountryName,
                            CountryName = txtNameEnComplex.Text,
                            Lang = "En",
                        });
                    else
                        enCountry.CountryName = txtNameEnComplex.Text;

                    _connector.UpdateItem(string.Concat(PrefixUpdate, ComplexDictionaryName.ToLower()), country.CountryCode.ToString(), country);
                    break;
                case "creativeroletype":
                    var creativeRoleType = _creativeRoleTypeList.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    creativeRoleType.Name = txtNameUaComplex.Text;
                    var ukCreative = creativeRoleType.CreativeRoleTypeTr.SingleOrDefault(rec => rec.Lang == "Uk");
                    if (ukCreative == null)
                        creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr
                        {
                            CodeI = creativeRoleType.CodeI,
                            Name = txtNameUaComplex.Text,
                            Lang = "Uk",
                        });
                    else
                        ukCreative.Name = txtNameUaComplex.Text;

                    var ruCreative = creativeRoleType.CreativeRoleTypeTr.SingleOrDefault(rec => rec.Lang == "Ru");
                    if (ruCreative == null)
                        creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr
                        {
                            CodeI = creativeRoleType.CodeI,
                            Name = txtNameRuComplex.Text,
                            Lang = "Ru",
                        });
                    else
                        ruCreative.Name = txtNameRuComplex.Text;

                    var enCreative = creativeRoleType.CreativeRoleTypeTr.SingleOrDefault(rec => rec.Lang == "En");
                    if (enCreative == null)
                        creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr
                        {
                            CodeI = creativeRoleType.CodeI,
                            Name = txtNameEnComplex.Text,
                            Lang = "En",
                        });
                    else
                        enCreative.Name = txtNameEnComplex.Text;

                    _connector.UpdateItem(string.Concat(PrefixUpdate, ComplexDictionaryName.ToLower()), creativeRoleType.CodeI.ToString(), creativeRoleType);
                    break;
                case "genretype":
                    var genre = _genreTypeList.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    genre.Name = txtNameUaComplex.Text;
                    var ukGenre = genre.GenreTypeTr.SingleOrDefault(rec => rec.Lang == "Uk");
                    if (ukGenre== null)
                        genre.GenreTypeTr.Add(new GenreTypeTr
                        {
                            CodeI = genre.CodeI,
                            Name = txtNameUaComplex.Text,
                            Lang = "Uk",
                        });
                    else
                        ukGenre.Name = txtNameUaComplex.Text;

                    var ruGenre = genre.GenreTypeTr.SingleOrDefault(rec => rec.Lang == "Ru");
                    if (ruGenre == null)
                        genre.GenreTypeTr.Add(new GenreTypeTr
                        {
                            CodeI = genre.CodeI,
                            Name = txtNameRuComplex.Text,
                            Lang = "Ru",
                        });
                    else
                        ruGenre.Name = txtNameRuComplex.Text;

                    var enGenre = genre.GenreTypeTr.SingleOrDefault(rec => rec.Lang == "En");
                    if (enGenre == null)
                        genre.GenreTypeTr.Add(new GenreTypeTr
                        {
                            CodeI = genre.CodeI,
                            Name = txtNameEnComplex.Text,
                            Lang = "En",
                        });
                    else
                        enGenre.Name = txtNameEnComplex.Text;

                    _connector.UpdateItem(string.Concat(PrefixUpdate, ComplexDictionaryName.ToLower()), genre.CodeI.ToString(), genre);
                    break;
                case "klr030":
                    var klr = _klR030List.SingleOrDefault(rec => Convert.ToInt32(rec.CountryCode) == Convert.ToInt32(CurrentGridRow.Code));
                    klr.R030Name = txtNameUaComplex.Text;
                    var ukKlr = klr.KlR030tr.SingleOrDefault(rec => rec.Lang == "Uk");
                    if (ukKlr == null)
                        klr.KlR030tr.Add(new KlR030tr
                        {
                            R030 = klr.R030,
                            R030Name = txtNameUaComplex.Text,
                            Lang = "Uk",
                        });
                    else
                        ukKlr.R030Name = txtNameUaComplex.Text;

                    var ruKlr = klr.KlR030tr.SingleOrDefault(rec => rec.Lang == "Ru");
                    if (ruKlr == null)
                        klr.KlR030tr.Add(new KlR030tr
                        {
                            R030 = klr.R030,
                            R030Name = txtNameRuComplex.Text,
                            Lang = "Ru",
                        });
                    else
                        ruKlr.R030Name = txtNameRuComplex.Text;

                    var enKlr = klr.KlR030tr.SingleOrDefault(rec => rec.Lang == "En");
                    if (enKlr == null)
                        klr.KlR030tr.Add(new KlR030tr 
                        {
                            R030 = klr.R030,
                            R030Name= txtNameEnComplex.Text,
                            Lang = "En",
                        });
                    else
                        enKlr.R030Name = txtNameEnComplex.Text;

                    _connector.UpdateItem(string.Concat(PrefixUpdate, ComplexDictionaryName.ToLower()), klr.R030.ToString(), klr);
                    MessageBox.Show("klr030");
                    break;
            }
            
            gvComplexDictionariesList.DataSource = GetComplexDictionariesData();
            UpdateEditPanelComplex();
        }

        private void btnDeleteComplex_Click(object sender, EventArgs e)
        {
            //save index
            indexValueGrid = gvComplexDictionariesList.CurrentRow.Index;
            var result = _connector.DeleteItem(string.Concat(PrefixDelete, ComplexDictionaryName.ToLower()), CurrentGridRow.Code);

            gvComplexDictionariesList.DataSource = GetComplexDictionariesData();
            UpdateEditPanelComplex();
            //set focus
            gvComplexDictionariesList.CurrentRow = gvComplexDictionariesList.Rows[indexValueGrid - 1];
        }
    }
}
