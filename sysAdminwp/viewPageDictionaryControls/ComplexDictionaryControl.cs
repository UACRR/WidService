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
            gvComplexDictionariesList.DataSource = returnedList;
            //bind data for grid
        }
    }
}
