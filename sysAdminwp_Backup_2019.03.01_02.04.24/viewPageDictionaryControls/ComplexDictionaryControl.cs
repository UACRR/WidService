using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using WebAPIConnector;
using ipsFormsDesign.Dictionary;
using sysAdminwp.ComplexDictionaryControls;
using System.Drawing;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace sysAdminwp.viewPageDictionaryControls
{
    public partial class ComplexDictionaryControl : UserControl
    {
        private readonly ApiConnector _connector;

        private const string PrefixUpdate = "dictionary/complex/update/";
        private const string PrefixCreate = "dictionary/complex/addnew/";
        private const string PrefixDelete = "dictionary/complex/delete/";

        private List<DictCategory> _dictionaryCategories;
        private List<DicCategoryItems> _complexDictionary;
        private List<CopyrightKind> _copyrightKindList;
        private List<Country> _countryList;
        private List<CreativeRoleType> _creativeRoleTypeList;
        private List<GenreType> _genreTypeList;
        private List<KlR030> _klR030List;
        private List<SystemConstant> _systemConstantList;
        private List<TypePlace> _typePlaceList;

        private CopyRightKindDictionaryControl _copyRightKindControl;
        private CountryDictionaryControl _countryDictionaryControl;
        private CreativeRoleTypeDictionaryControl _creativeRoleDictionaryControl;
        private GenreTypeDictionaryControl _genreTypeDictionaryControl;
        private Klr030DictionaryControl _klrDictionaryControl;
        private SystemConstantDictionaryControl _systemConstantDictionaryControl;
        private TypePlaceDictionaryControl _typePlaceDictionaryControl;

        private CopyrightKind _copyrightKind;
        private Country _country;
        private CreativeRoleType _creativeRoleType;
        private GenreType _genreType;
        private KlR030 _klR030;
        private SystemConstant _systemConstant;
        private TypePlace _typePlace;
        private int SaveNode;
        private byte[] borderDefault = new byte[4];
        private readonly List<string> _complexDictionaryList = new List<string>
        {
            "copyrightkind",
            "country",
            "creativeroletype",
            "genretype",
            "klr030",
            "systemconstant",
            "typeplace"
        };
        private static int indexValueGrid = 0;

        public string UrlForComplexDictionaries
        {
            get
            {
                var nodeComplexDictionary = complexTreeView.SelectedNode;
                if (nodeComplexDictionary == null) return string.Empty;
                var currentDataComplexdictionary = _complexDictionary[nodeComplexDictionary.Index];
                if (currentDataComplexdictionary == null) return string.Empty;
                return currentDataComplexdictionary.Url;
            }
        }

        public string ComplexDictionaryName
        {
            get
            {
                var node = complexTreeView.SelectedNode;
                if (node == null) return string.Empty;
                var currentDataDictionary = _complexDictionary[node.Index];
                if (currentDataDictionary == null) return string.Empty;
                return currentDataDictionary.DicName;
            }
        }
        
        public ViewTable CurrentGridRow => gvComplexDictionariesList.CurrentRow.DataBoundItem as ViewTable;
        public ComplexDictionaryControl() { }
        public ComplexDictionaryControl(ApiConnector connector)
        {
            InitializeComponent();
            _connector = connector;
            SetTreeViewComplexDictionaryDataSource();

            txtSearchComplex.SetUsageGrid(gvComplexDictionariesList);

            ElementsEnabledStatesControler();
            ChangeEnabledStateButtonsEditPanels(false);
            
        }

        private void SetTreeViewComplexDictionaryDataSource()
        {
            _dictionaryCategories = _connector.GetList<DictCategory>("dictionary/list");//дерево
            _complexDictionary = new List<DicCategoryItems>();
            foreach (var category in _dictionaryCategories)
            {
                var items = category.DicCategoryItems.Where(rec => rec.DicLevel == 2).ToList();
                if (items.Any())
                {
                    _complexDictionary.AddRange(items);
                }
            }
            _complexDictionary = _complexDictionary.OrderBy(i => i.Name).ToList();
            complexTreeView.DataSource = _complexDictionary;
            complexTreeView.DisplayMember = "Name";
        }

        private List<ViewTable> GetComplexDictionariesData()
        {
            var view = new List<ViewTable>();
            switch (ComplexDictionaryName.ToLower())
            {
                case "copyrightkind":
                    _copyrightKindList = _connector.GetList<CopyrightKind>(UrlForComplexDictionaries);
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
                    _countryList = _connector.GetList<Country>(UrlForComplexDictionaries);
                    foreach (var item in _countryList)
                    {
                        view.Add(new ViewTable
                        {
                            Code = item.CountryCode,
                            NameUk = item.CountryTr?.SingleOrDefault(i => i?.Lang == "Uk")?.CountryName ?? item.CountryName,
                            NameRu = item.CountryTr?.SingleOrDefault(i => i?.Lang == "Ru")?.CountryName,
                            NameEn = item.CountryTr?.SingleOrDefault(i => i?.Lang == "En")?.CountryName,
                        });
                        
                    }
                    break;
                case "creativeroletype":
                    _creativeRoleTypeList = _connector.GetList<CreativeRoleType>(UrlForComplexDictionaries);
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
                    _genreTypeList = _connector.GetList<GenreType>(UrlForComplexDictionaries);
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
                    _klR030List = _connector.GetList<KlR030>(UrlForComplexDictionaries);
                    foreach (var item in _klR030List)
                    {
                        view.Add(new ViewTable
                        {
                            Code = item.R030,
                            NameUk = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Uk")?.R030Name ?? item.R030Name,
                            NameRu = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "Ru")?.R030Name,
                            NameEn = item.KlR030tr?.SingleOrDefault(i => i?.Lang == "En")?.R030Name,
                        });
                    }
                    break;
                case "systemconstant":
                    _systemConstantList = _connector.GetList<SystemConstant>(UrlForComplexDictionaries);
                    foreach (var item in _systemConstantList)
                    {
                        view.Add(new ViewTable
                        {
                            Code = item.CodeI.ToString(),
                            NameUk = item.SystemConstantTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                            NameRu = item.SystemConstantTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                            NameEn = item.SystemConstantTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                        });
                    }
                    break;
                case "typeplace":
                    _typePlaceList = _connector.GetList<TypePlace>(UrlForComplexDictionaries);
                    foreach (var item in _typePlaceList)
                    {
                        view.Add(new ViewTable
                        {
                            Code = item.CodeI.ToString(),
                            NameUk = item.TypePlaceTr?.SingleOrDefault(i => i?.Lang == "Uk")?.Name ?? item.Name,
                            NameRu = item.TypePlaceTr?.SingleOrDefault(i => i?.Lang == "Ru")?.Name,
                            NameEn = item.TypePlaceTr?.SingleOrDefault(i => i?.Lang == "En")?.Name,
                        });
                    }
                    break;
            }
            return view;
        }

        private void gvComplexDictionariesList_SelectionChanged(object sender, EventArgs e)
        {
            UpdateEditPanelComplex();
            switch (ComplexDictionaryName.ToLower())
            {
                case "copyrightkind":
                    var copyrightKind = _copyrightKindList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    _copyRightKindControl.CopyrightKindDataSource = copyrightKind;
                    break;
                case "country":
                    var country = _countryList?.SingleOrDefault(result => result.ContinentCode == Convert.ToInt32(CurrentGridRow.Code));
                    _countryDictionaryControl.CountryDataSource = country;
                    break;
                case "creativeroletype":
                    var creativeroletype = _creativeRoleTypeList?.SingleOrDefault(obj => obj.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    _creativeRoleDictionaryControl.CreativeRoleTypeDataSource = creativeroletype;
                    break;
                case "genretype":
                    var genretype = _genreTypeList?.SingleOrDefault(res => res.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    _genreTypeDictionaryControl.GenreTypeDataSource = genretype;
                    break;
                case "klr030":
                    var klr030 = _klR030List?.SingleOrDefault(getObj => getObj.NOmin == Convert.ToInt32(CurrentGridRow.Code));
                    _klrDictionaryControl.KlR030DataSource = klr030;
                    break;
                case "systemconstant":
                    var systemConstant = _systemConstantList?.SingleOrDefault(getObj => getObj.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    _systemConstantDictionaryControl.SystemConstantSource = systemConstant;
                    break;
                case "typeplace":
                    var typePlace = _typePlaceList?.SingleOrDefault(getObj => getObj.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    _typePlaceDictionaryControl.TypePlaceSource = typePlace;
                    break;
            }
        }

        private void complexTreeView_SelectedNodeChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            var obj = SaveNode;
            try
            {
                SaveNode = complexTreeView.SelectedNode.Index;
            } catch (NullReferenceException) {
                SaveNode = obj;
            }
            controlsParamPanel.Controls.Clear();
            switch (ComplexDictionaryName.ToLower())
            {
                case "copyrightkind":
                    var baseDictsCopyRight = _connector.GetList<DictBaseTypeI>("dictionary/base/CrkindGroup");
                    var baseDictsPortalSupportRights = _connector.GetList<DictBaseTypeI>("dictionary/base/PortalSupportRights");
                    if (_copyRightKindControl == null)
                    {
                        _copyRightKindControl = new CopyRightKindDictionaryControl(baseDictsCopyRight, baseDictsPortalSupportRights);
                        _copyRightKindControl.HideElements += OnHideElements;

                    }
                    controlsParamPanel.Controls.Add(_copyRightKindControl);
                    break;
                case "country":
                    var baseDictsContinent = _connector.GetList<DictBaseTypeI>("dictionary/base/Continent");
                    if (_countryDictionaryControl == null)
                    {
                        _countryDictionaryControl = new CountryDictionaryControl(baseDictsContinent);
                        _countryDictionaryControl.HideElem += OnHideElements;
                    }
                    controlsParamPanel.Controls.Add(_countryDictionaryControl);
                    break;
                case "creativeroletype":
                    var baseDictsCategory = _connector.GetList<DictBaseTypeI>("dictionary/base/Category");
                    var baseDictsCopyRightType = _connector.GetList<DictBaseTypeI>("dictionary/base/CopyrightType");
                    if (_creativeRoleDictionaryControl == null)
                    {
                        _creativeRoleDictionaryControl = new CreativeRoleTypeDictionaryControl(baseDictsCategory, baseDictsCopyRightType);
                        _creativeRoleDictionaryControl.HideElem += OnHideElements;
                    }
                    controlsParamPanel.Controls.Add(_creativeRoleDictionaryControl);
                    break;
                case "genretype":
                    var baseDictsGenreType = _connector.GetList<DictBaseTypeI>("dictionary/base/Category");
                    if (_genreTypeDictionaryControl == null)
                    {
                        _genreTypeDictionaryControl = new GenreTypeDictionaryControl(baseDictsGenreType);
                        _genreTypeDictionaryControl.HideElem += OnHideElements;
                    }
                    controlsParamPanel.Controls.Add(_genreTypeDictionaryControl);
                    break;
                case "klr030":
                    var customDictCountry = _connector.GetList<DictBaseTypeI>("dictionary/base/Country");
                    var customDictKlR031 = _connector.GetList<DictBaseTypeI>("dictionary/base/KlR031");
                    if (_klrDictionaryControl == null)
                    {
                        _klrDictionaryControl = new Klr030DictionaryControl(customDictCountry, customDictKlR031);
                        _klrDictionaryControl.HideElem += OnHideElements;
                    }
                    controlsParamPanel.Controls.Add(_klrDictionaryControl);
                    break;
                case "systemconstant":
                    var baseDictsSystemConstant = _connector.GetList<DictBaseTypeI>("dictionary/base/SystemConstant");
                    if (_systemConstantDictionaryControl == null)
                        _systemConstantDictionaryControl = new SystemConstantDictionaryControl(baseDictsSystemConstant);
                    controlsParamPanel.Controls.Add(_systemConstantDictionaryControl);
                    break;
                case "typeplace":
                    var baseDictsTypePlace = _connector.GetList<DictBaseTypeI>("dictionary/base/TypePlace");
                    var baseDictsTypePlaceParam = _connector.GetList<DictBaseTypeI>("dictionary/base/TypePlaceParam");
                    if (_typePlaceDictionaryControl == null)
                    {
                        _typePlaceDictionaryControl = new TypePlaceDictionaryControl(baseDictsTypePlace, baseDictsTypePlaceParam);
                        _typePlaceDictionaryControl.HideElem += OnHideElements;
                    }
                    controlsParamPanel.Controls.Add(_typePlaceDictionaryControl);
                    break;
            }
            var returnedList = GetComplexDictionariesData();
            gvComplexDictionariesList.DataSource = returnedList;
            
        }

        private void OnHideElements(object sender, EventArgs e)
        {
            ChangeEnableElementsWhenAdd(false);
            ChangeEnabledStateButtonsEditPanels(true);
        }

        private void ElementsEnabledStatesControler()
        {
            bool stateEnabled = gvComplexDictionariesList.RowCount != 0;
            txtSearchComplex.Enabled = stateEnabled;
            btnAddComplex.Enabled = stateEnabled;
            btnDeleteComplex.Enabled = stateEnabled;
            controlsParamPanel.Enabled = stateEnabled;
            editPanel.Enabled = stateEnabled;
        }
        private void gvComplexDictionariesList_DataBindingComplete(object sender, Telerik.WinControls.UI.GridViewBindingCompleteEventArgs e)
        {
            ElementsEnabledStatesControler();
        }
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            indexValueGrid = gvComplexDictionariesList.CurrentRow.Index;
            btnSave.Text = "Додати";
            ChangeEnableElementsWhenAdd(false);
            txtCodeComplex.Clear();
            txtNameUaComplex.Clear();
            txtNameRuComplex.Clear();
            txtNameEnComplex.Clear();
            editPanel.Enabled = true;
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
                case "systemconstant":
                    _systemConstant = new SystemConstant();
                    _systemConstantDictionaryControl.SystemConstantSource = _systemConstant;
                    break;
                case "typeplace":
                    _typePlace = new TypePlace();
                    _typePlaceDictionaryControl.TypePlaceSource = _typePlace;
                    break;
            }
        }

        private void ChangeEnableElementsWhenAdd(bool isEnable)
        {
            complexTreeView.Enabled = isEnable;
            txtSearchComplex.Enabled = isEnable;
            gvComplexDictionariesList.Enabled = isEnable;
            btnAddComplex.Enabled = isEnable;
            btnDeleteComplex.Enabled = isEnable;
        }

        private void txtCodeComplex_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            indexValueGrid = gvComplexDictionariesList.CurrentRow.Index;
            if (borderDefault[0] == 0 &&
                borderDefault[1] == 0 && 
                borderDefault[2] == 0 &&
                borderDefault[3] == 0)
            {
                borderDefault[0] = txtCodeComplex.TextBoxElement.Border.ForeColor.A;
                borderDefault[1] = txtCodeComplex.TextBoxElement.Border.ForeColor.R;
                borderDefault[2] = txtCodeComplex.TextBoxElement.Border.ForeColor.G;
                borderDefault[3] = txtCodeComplex.TextBoxElement.Border.ForeColor.B;
            }
            if (!int.TryParse(txtCodeComplex.Text, out int codeCheck)) {
                txtCodeComplex.TextBoxElement.Border.ForeColor = Color.Red;
            } else
            {
                txtCodeComplex.TextBoxElement.Border.ForeColor = Color.FromArgb(borderDefault[0], borderDefault[1], borderDefault[2], borderDefault[3]);
            }
            ChangeEnableElementsWhenAdd(false);
            controlsParamPanel.Enabled = true;
            editPanel.Enabled = true;
            ChangeEnabledStateButtonsEditPanels(true);
        }
        private void ChangeEnabledStateButtonsEditPanels(bool isEnable)
        {
            btnSave.Enabled = isEnable;
            btnCancel.Enabled = isEnable;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Додати")
            {
                if(!SaveAddNewRow())
                    return;
                btnSave.Text = "Зберегти";
                ChangeEnabledStateButtonsEditPanels(false);
                gvComplexDictionariesList.CurrentRow = gvComplexDictionariesList.Rows[gvComplexDictionariesList.RowCount - 1];
            }
            else
            {
                if (SaveUpdate())
                {
                    ChangeEnabledStateButtonsEditPanels(false);
                    ChangeEnableElementsWhenAdd(true);
                    gvComplexDictionariesList.CurrentRow = gvComplexDictionariesList.Rows[indexValueGrid];
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var node = SaveNode;
            SetTreeViewComplexDictionaryDataSource();
            
            GetComplexDictionariesData();
            UpdateEditPanelComplex();
            complexTreeView.SelectedNode = complexTreeView.Nodes[node];

            txtCodeComplex.TextBoxElement.Border.ForeColor = Color.FromArgb(borderDefault[0], borderDefault[1], borderDefault[2], borderDefault[3]);
            ChangeEnabledStateButtonsEditPanels(false);
            ChangeEnableElementsWhenAdd(true);
            //complexTreeView.SelectedNode = saveNode;
        }

        public bool SaveAddNewRow()
        {
            if (string.IsNullOrEmpty(txtCodeComplex.Text))
            {
                MessageBox.Show("Поле \"Код\" не повинно бути пустим!", "Заповніть поле!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            try
            {
                switch (ComplexDictionaryName.ToLower())
                {
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
                        _country.CountryName = txtNameUaComplex.Text;
                        _country.CountryCode = txtCodeComplex.Text;
                        _country.CountryTr.Add(new CountryTr
                        {
                            CountryCode = _country.CountryCode,
                            CountryName = txtNameUaComplex.Text,
                            Lang = "Uk"
                        });
                        _country.CountryTr.Add(new CountryTr
                        {
                            CountryCode = _country.CountryCode,
                            CountryName = txtNameRuComplex.Text,
                            Lang = "Ru"
                        });
                        _country.CountryTr.Add(new CountryTr
                        {
                            CountryCode = _country.CountryCode,
                            CountryName = txtNameEnComplex.Text,
                            Lang = "En"
                        });
                        _connector.NewItem(string.Concat(PrefixCreate, ComplexDictionaryName.ToLower()), _country);
                        break;
                    case "creativeroletype":
                        if (!int.TryParse(txtCodeComplex.Text, out int creativeCode))
                        {
                            MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                        _creativeRoleType.Name = txtNameUaComplex.Text;
                        _creativeRoleType.CodeI = creativeCode;
                        _creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr
                        {
                            CodeI = _creativeRoleType.CodeI,
                            Name = txtNameUaComplex.Text,
                            Lang = "Uk"
                        });
                        _creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr
                        {
                            CodeI = _creativeRoleType.CodeI,
                            Name = txtNameRuComplex.Text,
                            Lang = "Ru"
                        });
                        _creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr
                        {
                            CodeI = _creativeRoleType.CodeI,
                            Name = txtNameEnComplex.Text,
                            Lang = "En"
                        });
                        _connector.NewItem(string.Concat(PrefixCreate, ComplexDictionaryName.ToLower()), _creativeRoleType);
                        break;
                    case "genretype":
                        if (!int.TryParse(txtCodeComplex.Text, out int genreCode))
                        {
                            MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                        _genreType.Name = txtNameUaComplex.Text;
                        _genreType.CodeI = genreCode;
                        _genreType.GenreTypeTr.Add(new GenreTypeTr
                        {
                            CodeI = _genreType.CodeI,
                            Name = txtNameUaComplex.Text,
                            Lang = "Uk"
                        });
                        _genreType.GenreTypeTr.Add(new GenreTypeTr
                        {
                            CodeI = _genreType.CodeI,
                            Name = txtNameRuComplex.Text,
                            Lang = "Ru"
                        });
                        _genreType.GenreTypeTr.Add(new GenreTypeTr
                        {
                            CodeI = _genreType.CodeI,
                            Name = txtNameEnComplex.Text,
                            Lang = "En"
                        });
                        _connector.NewItem(string.Concat(PrefixCreate, ComplexDictionaryName.ToLower()), _genreType);
                        break;
                    case "klr030":
                        _klR030.R030Name = txtNameUaComplex.Text;
                        _klR030.R030 = txtCodeComplex.Text;
                        _klR030.KlR030tr.Add(new KlR030tr
                        {
                            R030 = _klR030.R030,
                            Lang = "Uk",
                            R030Name = txtNameUaComplex.Text
                        });
                        _klR030.KlR030tr.Add(new KlR030tr
                        {
                            R030 = _klR030.R030,
                            Lang = "Ru",
                            R030Name = txtNameRuComplex.Text
                        });
                        _klR030.KlR030tr.Add(new KlR030tr
                        {
                            R030 = _klR030.R030,
                            Lang = "En",
                            R030Name = txtNameEnComplex.Text
                        });
                        _connector.NewItem(string.Concat(PrefixCreate, ComplexDictionaryName.ToLower()), _klR030);
                        break;
                    case "systemconstant":
                        if (!int.TryParse(txtCodeComplex.Text, out int systemConstantCode))
                        {
                            MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        _systemConstant.Name = txtNameUaComplex.Text;
                        _systemConstant.CodeI = systemConstantCode;
                        _systemConstant.SystemConstantTr.Add(new SystemConstantTr
                        {
                            CodeI = _systemConstant.CodeI,
                            Lang = "Uk",
                            Name = txtNameUaComplex.Text
                        });
                        _systemConstant.SystemConstantTr.Add(new SystemConstantTr
                        {
                            CodeI = _systemConstant.CodeI,
                            Lang = "Ru",
                            Name = txtNameRuComplex.Text
                        });
                        _systemConstant.SystemConstantTr.Add(new SystemConstantTr
                        {
                            CodeI = _systemConstant.CodeI,
                            Lang = "En",
                            Name = txtNameEnComplex.Text
                        });
                        _connector.NewItem(string.Concat(PrefixCreate, ComplexDictionaryName.ToLower()), _systemConstant);
                        break;
                    case "typeplace":
                        if (!int.TryParse(txtCodeComplex.Text, out int typePlaceCode))
                        {
                            MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                        _typePlace.Name = txtNameUaComplex.Text;
                        _typePlace.CodeI = typePlaceCode;
                        _typePlace.TypePlaceTr.Add(new TypePlaceTr
                        {
                            CodeI = _typePlace.CodeI,
                            Lang = "Uk",
                            Name = txtNameUaComplex.Text
                        });
                        _typePlace.TypePlaceTr.Add(new TypePlaceTr
                        {
                            CodeI = _typePlace.CodeI,
                            Lang = "Ru",
                            Name = txtNameRuComplex.Text
                        });
                        _typePlace.TypePlaceTr.Add(new TypePlaceTr
                        {
                            CodeI = _typePlace.CodeI,
                            Lang = "En",
                            Name = txtNameEnComplex.Text
                        });
                        _connector.NewItem(string.Concat(PrefixCreate, ComplexDictionaryName.ToLower()), _typePlace);
                        break;
                }
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
                        case "systemconstant":
                            var systemConstant = _systemConstantList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                            txtCodeComplex.Text = systemConstant?.CodeI.ToString();
                            txtNameUaComplex.Text = systemConstant?.SystemConstantTr?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                            txtNameRuComplex.Text = systemConstant?.SystemConstantTr?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                            txtNameEnComplex.Text = systemConstant?.SystemConstantTr?.SingleOrDefault(i => i.Lang == "En")?.Name;
                            break;
                        case "typeplace":
                            var typePlace = _typePlaceList?.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(items.Code));
                            txtCodeComplex.Text = typePlace?.CodeI.ToString();
                            txtNameUaComplex.Text = typePlace?.TypePlaceTr?.SingleOrDefault(i => i.Lang == "Uk")?.Name;
                            txtNameRuComplex.Text = typePlace?.TypePlaceTr?.SingleOrDefault(i => i.Lang == "Ru")?.Name;
                            txtNameEnComplex.Text = typePlace?.TypePlaceTr?.SingleOrDefault(i => i.Lang == "En")?.Name;
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
            gvComplexDictionariesList.TableElement.Text = "";
        }

        //метод збереження змін !! null code
        public bool SaveUpdate()
        {
            if (txtCodeComplex.TextLength == 0 && Convert.ToInt32(txtCodeComplex.Text).GetType() != typeof(int))
                txtCodeComplex.Text = gvComplexDictionariesList.CurrentRow.Cells["Code"].Value.ToString();
            switch (ComplexDictionaryName.ToLower())
            {
                case "copyrightkind":
                    if (!int.TryParse(txtCodeComplex.Text, out int codeKind))
                    {
                        MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    var copyrightKind = _copyrightKindList.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    copyrightKind.CodeI = codeKind;
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
                    if (!int.TryParse(txtCodeComplex.Text, out int codeCountry))
                    {
                        MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    var country = _countryList.SingleOrDefault(rec => rec.CountryCode == CurrentGridRow.Code);
                    country.CountryCode = codeCountry.ToString();
                    country.CountryName = txtNameUaComplex.Text;
                    var ukCountry = country.CountryTr.SingleOrDefault(rec => rec.Lang == "Uk");
                    if (ukCountry == null)
                    {
                        country.CountryTr.Add(new CountryTr
                        {
                            CountryCode = country.CountryCode,
                            CountryName = txtNameUaComplex.Text,
                            Lang = "Uk",
                        });
                    }
                    else
                    {
                        ukCountry.CountryName = txtNameUaComplex.Text;
                        ukCountry.CountryCode = country.CountryCode;
                    }
                    var ruCountry = country.CountryTr.SingleOrDefault(rec => rec.Lang == "Ru");
                    if (ruCountry == null)
                    {
                        country.CountryTr.Add(new CountryTr
                        {
                            CountryCode = country.CountryCode,
                            CountryName = txtNameRuComplex.Text,
                            Lang = "Ru",
                        });
                    }
                    else
                    {
                        ruCountry.CountryName = txtNameRuComplex.Text;
                        ruCountry.CountryCode = country.CountryCode;
                    }
                    var enCountry = country.CountryTr.SingleOrDefault(rec => rec.Lang == "En");
                    if (enCountry == null)
                    {
                        country.CountryTr.Add(new CountryTr
                        {
                            CountryCode = country.CountryCode,
                            CountryName = txtNameEnComplex.Text,
                            Lang = "En",
                        });
                    }
                    else
                    {
                        enCountry.CountryName = txtNameEnComplex.Text;
                        enCountry.CountryCode = country.CountryCode;
                    }
                    _connector.UpdateItem(string.Concat(PrefixUpdate, ComplexDictionaryName.ToLower()), country.CountryCode, country);
                    break;
                case "creativeroletype":
                    if (!int.TryParse(txtCodeComplex.Text, out int codeCreative))
                    {
                        MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    var creativeRoleType = _creativeRoleTypeList.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    creativeRoleType.CodeI = codeCreative;
                    creativeRoleType.Name = txtNameUaComplex.Text;
                    var uaCreative = creativeRoleType.CreativeRoleTypeTr.SingleOrDefault(rec => rec.Lang == "Uk");
                    if (uaCreative == null)
                    {
                        creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr
                        {
                            CodeI = creativeRoleType.CodeI,
                            Name = txtNameUaComplex.Text,
                            Lang = "Uk",
                        });
                    }
                    else
                    {
                        uaCreative.Name = txtNameUaComplex.Text;
                        uaCreative.CodeI = creativeRoleType.CodeI;
                    }
                    var ruCreative = creativeRoleType.CreativeRoleTypeTr.SingleOrDefault(rec => rec.Lang == "Ru");
                    if (ruCreative == null)
                    {
                        creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr
                        {
                            CodeI = creativeRoleType.CodeI,
                            Name = txtNameRuComplex.Text,
                            Lang = "Ru",
                        });
                    }
                    else
                    {
                        ruCreative.Name = txtNameRuComplex.Text;
                        ruCreative.CodeI = creativeRoleType.CodeI;
                    }
                    var enCreative = creativeRoleType.CreativeRoleTypeTr.SingleOrDefault(rec => rec.Lang == "En");
                    if (enCreative == null)
                    {
                        creativeRoleType.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr
                        {
                            CodeI = creativeRoleType.CodeI,
                            Name = txtNameEnComplex.Text,
                            Lang = "En",
                        });
                    }
                    else
                    {
                        enCreative.Name = txtNameEnComplex.Text;
                        enCreative.CodeI = creativeRoleType.CodeI;
                    }
                    _connector.UpdateItem(string.Concat(PrefixUpdate, ComplexDictionaryName.ToLower()), creativeRoleType.CodeI.ToString(), creativeRoleType);
                    break;
                case "genretype":
                    if (!int.TryParse(txtCodeComplex.Text, out int codeGenre))
                    {
                        MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    var genreType = _genreTypeList.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    genreType.CodeI = codeGenre;
                    genreType.Name = txtNameUaComplex.Text;
                    var uaGenre = genreType.GenreTypeTr.SingleOrDefault(rec => rec.Lang == "Uk");
                    if (uaGenre == null)
                    {
                        genreType.GenreTypeTr.Add(new GenreTypeTr
                        {
                            CodeI = genreType.CodeI,
                            Name = txtNameUaComplex.Text,
                            Lang = "Uk",
                        });
                    }
                    else
                    {
                        uaGenre.Name = txtNameUaComplex.Text;
                        uaGenre.CodeI = genreType.CodeI;
                    }
                    var ruGenre = genreType.GenreTypeTr.SingleOrDefault(rec => rec.Lang == "Uk");
                    if (ruGenre == null)
                    {
                        genreType.GenreTypeTr.Add(new GenreTypeTr
                        {
                            CodeI = genreType.CodeI,
                            Name = txtNameRuComplex.Text,
                            Lang = "Ru",
                        });
                    }
                    else
                    {
                        ruGenre.Name = txtNameRuComplex.Text;
                        ruGenre.CodeI = genreType.CodeI;
                    }
                    var enGenre = genreType.GenreTypeTr.SingleOrDefault(rec => rec.Lang == "En");
                    if (enGenre == null)
                    {
                        genreType.GenreTypeTr.Add(new GenreTypeTr
                        {
                            CodeI = genreType.CodeI,
                            Name = txtNameEnComplex.Text,
                            Lang = "En",
                        });
                    }
                    else
                    {
                        enGenre.Name = txtNameEnComplex.Text;
                        enGenre.CodeI = genreType.CodeI;
                    }
                    _connector.UpdateItem(string.Concat(PrefixUpdate, ComplexDictionaryName.ToLower()), genreType.CodeI.ToString(), genreType);
                    break;
                case "klr030":
                    if (!int.TryParse(txtCodeComplex.Text, out int codeKLR))
                    {
                        MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    var klr = _klR030List.SingleOrDefault(rec => rec.R030 == CurrentGridRow.Code);
                    klr.R030 = codeKLR.ToString();
                    klr.R030Name = txtNameUaComplex.Text;
                    var uaKlr = klr.KlR030tr.SingleOrDefault(rec => rec.Lang == "Uk");
                    if (uaKlr == null)
                    {
                        klr.KlR030tr.Add(new KlR030tr
                        {
                            R030 = klr.R030,
                            R030Name = txtNameUaComplex.Text,
                            Lang = "Uk",
                        });
                    }
                    else
                    {
                        uaKlr.R030Name = txtNameUaComplex.Text;
                        uaKlr.R030 = klr.R030;
                    }
                    var ruKlr = klr.KlR030tr.SingleOrDefault(rec => rec.Lang == "Ru");
                    if (ruKlr == null)
                    {
                        klr.KlR030tr.Add(new KlR030tr
                        {
                            R030 = klr.R030,
                            R030Name = txtNameRuComplex.Text,
                            Lang = "Ru",
                        });
                    }
                    else
                    {
                        ruKlr.R030Name = txtNameRuComplex.Text;
                        ruKlr.R030 = klr.R030;
                    }
                    var enKlr = klr.KlR030tr.SingleOrDefault(rec => rec.Lang == "En");
                    if (enKlr == null)
                    {
                        klr.KlR030tr.Add(new KlR030tr
                        {
                            R030 = klr.R030,
                            R030Name = txtNameEnComplex.Text,
                            Lang = "En",
                        });
                    }
                    else
                    {
                        enKlr.R030Name = txtNameEnComplex.Text;
                        enKlr.R030 = klr.R030;
                    }
                    _connector.UpdateItem(string.Concat(PrefixUpdate, ComplexDictionaryName.ToLower()), klr.R030, klr);
                    break;
                case "systemconstant":
                    if (!int.TryParse(txtCodeComplex.Text, out int code))
                    {
                        MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    var systemConstant = _systemConstantList.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    systemConstant.CodeI = code;
                    systemConstant.Name = txtNameUaComplex.Text;
                    var uaSystemConstant = systemConstant.SystemConstantTr.SingleOrDefault(rec => rec.Lang == "Uk");
                    if (uaSystemConstant == null)
                    {
                        systemConstant.SystemConstantTr.Add(new SystemConstantTr
                        {
                            CodeI = systemConstant.CodeI,
                            Name = systemConstant.Name,
                            Lang = "Uk"
                        });
                    }
                    else
                    {
                        uaSystemConstant.Name = txtNameUaComplex.Text;
                        uaSystemConstant.CodeI = systemConstant.CodeI;
                    }
                    var ruSystemConstant = systemConstant.SystemConstantTr.SingleOrDefault(rec => rec.Lang == "Ru");
                    if (ruSystemConstant == null)
                    {
                        systemConstant.SystemConstantTr.Add(new SystemConstantTr
                        {
                            CodeI = systemConstant.CodeI,
                            Name = systemConstant.Name,
                            Lang = "Ru"
                        });
                    }
                    else
                    {
                        ruSystemConstant.Name = txtNameUaComplex.Text;
                        ruSystemConstant.CodeI = systemConstant.CodeI;
                    }
                    var enSystemConstant = systemConstant.SystemConstantTr.SingleOrDefault(rec => rec.Lang == "En");
                    if (enSystemConstant == null)
                    {
                        systemConstant.SystemConstantTr.Add(new SystemConstantTr
                        {
                            CodeI = systemConstant.CodeI,
                            Name = systemConstant.Name,
                            Lang = "En"
                        });
                    }
                    else
                    {
                        enSystemConstant.Name = txtNameUaComplex.Text;
                        enSystemConstant.CodeI = systemConstant.CodeI;
                    }
                    _connector.UpdateItem(string.Concat(PrefixUpdate, ComplexDictionaryName.ToLower()), systemConstant.CodeI.ToString(), systemConstant);
                    break;
                case "typeplace":
                    if (!int.TryParse(txtCodeComplex.Text, out int codeType))
                    {
                        MessageBox.Show("Поле \"Код\" повинно бути цілим числом!", "Помилка формату!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                    var typePlace = _typePlaceList.SingleOrDefault(rec => rec.CodeI == Convert.ToInt32(CurrentGridRow.Code));
                    typePlace.CodeI = codeType;
                    typePlace.Name = txtNameUaComplex.Text;
                    var uaType = typePlace.TypePlaceTr.SingleOrDefault(rec => rec.Lang == "Uk");
                    if (uaType == null)
                    {
                        typePlace.TypePlaceTr.Add(new TypePlaceTr
                        {
                            CodeI = typePlace.CodeI,
                            Name = typePlace.Name,
                            Lang = "Uk",
                        });
                    }
                    else
                    {
                        uaType.Name = txtNameUaComplex.Text;
                        uaType.CodeI = typePlace.CodeI;
                    }
                    var ruType = typePlace.TypePlaceTr.SingleOrDefault(rec => rec.Lang == "Ru");
                    if (ruType == null)
                    {
                        typePlace.TypePlaceTr.Add(new TypePlaceTr
                        {
                            CodeI = typePlace.CodeI,
                            Name = txtNameRuComplex.Text,
                            Lang = "Ru",
                        });
                    }
                    else
                    {
                        ruType.Name = txtNameRuComplex.Text;
                        ruType.CodeI = typePlace.CodeI;
                    }
                    var enType = typePlace.TypePlaceTr.SingleOrDefault(rec => rec.Lang == "En");
                    if (enType == null)
                    {
                        typePlace.TypePlaceTr.Add(new TypePlaceTr
                        {
                            CodeI = typePlace.CodeI,
                            Name = txtNameEnComplex.Text,
                            Lang = "En",
                        });
                    }
                    else
                    {
                        enType.Name = txtNameEnComplex.Text;
                        enType.CodeI = typePlace.CodeI;
                    }
                    _connector.UpdateItem(string.Concat(PrefixUpdate, ComplexDictionaryName.ToLower()), typePlace.CodeI.ToString(), typePlace);

                    break;
            }
            gvComplexDictionariesList.DataSource = GetComplexDictionariesData();
            UpdateEditPanelComplex();
            return true;
        }

        private void btnDeleteComplex_Click(object sender, EventArgs e)
        {
            indexValueGrid = gvComplexDictionariesList.CurrentRow.Index;
            var result = _connector.DeleteItem(string.Concat(PrefixDelete, ComplexDictionaryName.ToLower()), CurrentGridRow.Code);

            gvComplexDictionariesList.DataSource = GetComplexDictionariesData();
            UpdateEditPanelComplex();
            gvComplexDictionariesList.CurrentRow = gvComplexDictionariesList.Rows[indexValueGrid - 1];
        }
    }
}
