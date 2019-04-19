using System.Collections.Generic;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using WebAPIConnector;
using sysAdminwp.ComplexDictionariesBaseControls;

namespace sysAdminwp.viewPageDictionaryControls
{
    public partial class ComplexDictionaryControl : UserControl
    {
        private readonly ApiConnector _connector;

        private const string PrefixUpdate = "dictionary/complex/update/";
        private const string PrefixCreate = "dictionary/complex/addnew/";
        private const string PrefixDelete = "dictionary/complex/delete/";

        private List<DictCategory> _dictionaryCategories;
        private List<CopyrightKind> _copyrightKindList;
        private List<Country> _countryList;
        private List<CreativeRoleType> _creativeRoleTypeList;
        private List<GenreType> _genreTypeList;
        private List<KlR030> _klR030List;
        private List<SystemConstant> _systemConstantList;
        private List<TypePlace> _typePlaceList;

        private CopyrightKind _copyrightKind;
        private Country _country;
        private CreativeRoleType _creativeRoleType;
        private GenreType _genreType;
        private KlR030 _klR030;
        private SystemConstant _systemConstant;
        private TypePlace _typePlace;
        private int SaveNode;

        //for saved complex dictionaries from DictionaryForm and use for
        //- UrlForComplexDictionaries
        //- ComplexDictionaryName
        private List<DicCategoryItems> complexDictionary;
        public List<DicCategoryItems> ComplexDictionarySaved
        {
            get { return complexDictionary; }
            set
            {
                if (value != null)
                    complexDictionary = value;
            }
        }
        
        //mass for color setting for textBox color
        private byte[] borderDefault = new byte[4];
        //sequence of complex dictionaries
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
                var currentDataComplexdictionary = ComplexDictionarySaved[nodeComplexDictionary.Index];
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
                var currentDataDictionary = ComplexDictionarySaved[node.Index];
                if (currentDataDictionary == null) return string.Empty;
                return currentDataDictionary.DicName;
            }
        }
        public ComplexDictionaryControl(ApiConnector connector, List<DicCategoryItems> complexDictionaries)
        {
            InitializeComponent();
            //initialize connector
            _connector = connector;
            //save for NodeSelected property
            ComplexDictionarySaved = complexDictionaries;
            //initialize data for TreeView
            SetComplexDictionaryToTree(complexDictionaries);
        }

        //initialize sequence complex dictionaries for 'TreeView' element
        private void SetComplexDictionaryToTree(List<DicCategoryItems> complexDictionaries)
        {
            //set data for element
            complexTreeView.DataSource = complexDictionaries;
            complexTreeView.DisplayMember = "Name";
        }

        //initialize data for grid of the selected dictionary
        private void complexTreeView_SelectedNodeChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {        
            switch (ComplexDictionaryName.ToLower())
            {
                case "copyrightkind":
                    //revome other controls
                    tableLayout_MarkupElement.Controls.Remove(tableLayout_MarkupElement.GetControlFromPosition(1, 0));
                    //initialize base control 'CopyrightKind'
                    BaseCopyrightKindControl baseCopyrightKind = new BaseCopyrightKindControl(_connector, UrlForComplexDictionaries) { Dock = DockStyle.Fill };
                    tableLayout_MarkupElement.Controls.Add(baseCopyrightKind, 1, 0);
                    break;
                case "country":
                    //revome other controls
                    tableLayout_MarkupElement.Controls.Remove(tableLayout_MarkupElement.GetControlFromPosition(1, 0));
                    //initialize base control 'Country'
                    BaseCountryControl baseCountry = new BaseCountryControl(_connector, UrlForComplexDictionaries) { Dock = DockStyle.Fill };
                    tableLayout_MarkupElement.Controls.Add(baseCountry, 1, 0);
                    break;
                case "creativeroletype":
                    //revome other controls
                    tableLayout_MarkupElement.Controls.Remove(tableLayout_MarkupElement.GetControlFromPosition(1, 0));
                    //initialize base control 'Creativeroletype'
                    BaseCreativeroleTypeControl baseCreativeroleType = new BaseCreativeroleTypeControl(_connector, UrlForComplexDictionaries) { Dock = DockStyle.Fill };
                    tableLayout_MarkupElement.Controls.Add(baseCreativeroleType, 1, 0);
                    break;
                case "genretype":
                    //revome other controls
                    tableLayout_MarkupElement.Controls.Remove(tableLayout_MarkupElement.GetControlFromPosition(1, 0));
                    //initialize base control 'GenreType'
                    BaseGenreTypeControl baseGenreType = new BaseGenreTypeControl(_connector, UrlForComplexDictionaries) { Dock = DockStyle.Fill };
                    tableLayout_MarkupElement.Controls.Add(baseGenreType, 1, 0);
                    break;
                case "kl_r030":
                    //revome other controls
                    tableLayout_MarkupElement.Controls.Remove(tableLayout_MarkupElement.GetControlFromPosition(1, 0));
                    //initialize base control 'GenreType'
                    BaseKlr030Control baseKlr030 = new BaseKlr030Control(_connector, UrlForComplexDictionaries) { Dock = DockStyle.Fill };
                    tableLayout_MarkupElement.Controls.Add(baseKlr030, 1, 0);
                    break;
                case "systemconstant":
                    //revome other controls
                    tableLayout_MarkupElement.Controls.Remove(tableLayout_MarkupElement.GetControlFromPosition(1, 0));
                    //initialize base control 'GenreType'
                    BaseSystemConstantControl baseSystemConstant = new BaseSystemConstantControl(_connector, UrlForComplexDictionaries) { Dock = DockStyle.Fill };
                    tableLayout_MarkupElement.Controls.Add(baseSystemConstant, 1, 0);
                    break;
                case "typeplace":
                    //revome other controls
                    tableLayout_MarkupElement.Controls.Remove(tableLayout_MarkupElement.GetControlFromPosition(1, 0));
                    //initialize base control 'TypePlace'
                    BaseTypePlaceControl baseTypePlace = new BaseTypePlaceControl(_connector, UrlForComplexDictionaries) { Dock = DockStyle.Fill };
                    tableLayout_MarkupElement.Controls.Add(baseTypePlace, 1, 0);
                    break;
            }
        }

        private void ddlEditKeyField_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (e.Position == -1)
            {
                return;
            }

        }
    }
}
