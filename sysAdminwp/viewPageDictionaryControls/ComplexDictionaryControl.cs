using System.Collections.Generic;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using WebAPIConnector;
using sysAdminwp.ComplexDictionariesBaseControls;
using sysAdminwp.PresenterComplexDictionaries;

namespace sysAdminwp.viewPageDictionaryControls
{
    public partial class ComplexDictionaryControl : UserControl
    {
        //sequence of complex dictionaries
        private readonly List<string> _complexDictionaryList = new List<string>
        {
            "copyrightkind",
            "country",
            "creativeroletype",
            "genretype",
            "kl_r030",
            "systemconstant",
            "typeplace"
        };

        private readonly BaseCopyrightKindControl _baseCopyrightKind;
        private readonly BaseCountryControl _baseCountry;
        private readonly BaseCreativeroleTypeControl _baseCreativeroleType;
        private readonly BaseGenreTypeControl _baseGenreType;
        private readonly BaseKlr030Control _baseKlr030;
        private readonly BaseSystemConstantControl _baseSystemConstant;
        private readonly BaseTypePlaceControl _baseTypePlace;

        private const string PrefixUpdate = "dictionary/complex/update/";
        private const string PrefixCreate = "dictionary/complex/addnew/";
        private const string PrefixDelete = "dictionary/complex/delete/";

        public ComplexDictionaryControl()
        {
            InitializeComponent();
            _baseCopyrightKind = new BaseCopyrightKindControl();
            _baseCountry = new BaseCountryControl();
            _baseCreativeroleType = new BaseCreativeroleTypeControl();
            _baseGenreType = new BaseGenreTypeControl();
            _baseKlr030 = new BaseKlr030Control();
            _baseSystemConstant = new BaseSystemConstantControl();
            _baseTypePlace = new BaseTypePlaceControl();
        }

        //for saved complex dictionaries from DictionaryForm and use for
        public List<DicCategoryItems> ComplexDictionaryList { get; set; }

        public string UrlForComplexDictionaries
        {
            get
            {
                var nodeComplexDictionary = complexTreeView.SelectedNode;
                if (nodeComplexDictionary == null)
                    return string.Empty;

                var currentDataComplexdictionary = ComplexDictionaryList[nodeComplexDictionary.Index];
                if (currentDataComplexdictionary == null)
                    return string.Empty;

                return currentDataComplexdictionary.Url;
            }
        }

        public string ComplexDictionaryName
        {
            get
            {
                var node = complexTreeView.SelectedNode;
                if (node == null) return string.Empty;
                var currentDataDictionary = ComplexDictionaryList[node.Index];

                if (currentDataDictionary == null)
                    return string.Empty;

                return currentDataDictionary.DicName;
            }
        }

        /// <summary>
        /// Initialize sequence complex dictionaries for 'TreeView' element
        /// </summary>
        /// <param name="complexDictionaries"></param>
        public void SetComplexDictionaryForTreeView(List<DicCategoryItems> complexDictionaries)
        {
            ComplexDictionaryList = complexDictionaries;
            complexTreeView.DataSource = complexDictionaries;
            complexTreeView.ValueMember = "Code";
            complexTreeView.DisplayMember = "Name";
        }

        //initialize data for grid of the selected dictionary
        private void complexTreeView_SelectedNodeChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            controlPanel.Controls.Clear();

            switch (ComplexDictionaryName.ToLower())
            {
                case "copyrightkind":
                    //DirectorLayers<CopyrightKind> directorCopyright = new DirectorLayers<CopyrightKind>();
                    //BaseCopyrightKindControl baseCopyrightKind = (BaseCopyrightKindControl)directorCopyright.InitCommon(_connector, UrlForComplexDictionaries);
                    controlPanel.Controls.Add(_baseCopyrightKind);
                    _baseCopyrightKind.SetDataByDictionaryURL(UrlForComplexDictionaries);
                    break;
                case "country":
                    //DirectorLayers<Country> directorCountry = new DirectorLayers<Country>();
                    //BaseCountryControl baseCountry = (BaseCountryControl)directorCountry.InitCommon(_connector, UrlForComplexDictionaries);
                    controlPanel.Controls.Add(_baseCountry);
                    break;
                case "creativeroletype":
                    //DirectorLayers<CreativeRoleType> directorCreative = new DirectorLayers<CreativeRoleType>();
                    //BaseCreativeroleTypeControl baseCreativeroleType = (BaseCreativeroleTypeControl)directorCreative.InitCommon(_connector, UrlForComplexDictionaries);
                    controlPanel.Controls.Add(_baseCreativeroleType);
                    break;
                case "genretype":
                    //DirectorLayers<GenreType> directorGenre = new DirectorLayers<GenreType>();
                    //BaseGenreTypeControl baseGenreType = (BaseGenreTypeControl)directorGenre.InitCommon(_connector, UrlForComplexDictionaries);
                    controlPanel.Controls.Add(_baseGenreType);
                    break;
                case "kl_r030":
                    //DirectorLayers<KlR030> directorKlr = new DirectorLayers<KlR030>();
                    //BaseKlr030Control baseKlr030 = (BaseKlr030Control)directorKlr.InitCommon(_connector, UrlForComplexDictionaries);
                    controlPanel.Controls.Add(_baseKlr030);
                    break;
                case "systemconstant":
                    //DirectorLayers<SystemConstant> directorSystem = new DirectorLayers<SystemConstant>();
                    //BaseSystemConstantControl baseSystemConstant = (BaseSystemConstantControl)directorSystem.InitCommon(_connector, UrlForComplexDictionaries);
                    controlPanel.Controls.Add(_baseSystemConstant);
                    break;
                case "typeplace":
                    //DirectorLayers<TypePlace> directorType = new DirectorLayers<TypePlace>();
                    //BaseTypePlaceControl baseTypePlace = (BaseTypePlaceControl)directorType.InitCommon(_connector, UrlForComplexDictionaries);
                    controlPanel.Controls.Add(_baseTypePlace);
                    break;
            }
        }
    }
}


