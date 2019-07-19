using System.Collections.Generic;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using WebAPIConnector;
using sysAdminwp.ComplexDictionariesBaseControls;
using sysAdminwp.PresenterComplexDictionaries;

namespace sysAdminwp.viewPageDictionaryControls
{
    public partial class ComplexDictionaryControl : UserControl
    {
        private readonly CopyrightKindControl _ctrlCopyrightKind;
        private readonly RelGenrePercentControl _ctrlRelGenrePercent;
        private readonly BaseCountryControl _baseCountry;
        private readonly BaseCreativeroleTypeControl _baseCreativeroleType;
        private readonly BaseGenreTypeControl _baseGenreType;
        private readonly BaseKlr030Control _baseKlr030;
        private readonly BaseSystemConstantControl _baseSystemConstant;
        private readonly BaseTypePlaceControl _baseTypePlace;

        public ComplexDictionaryControl()
        {
            InitializeComponent();
            _ctrlCopyrightKind = new CopyrightKindControl();
            _ctrlRelGenrePercent = new RelGenrePercentControl();
            _baseCountry = new BaseCountryControl();
            _baseCreativeroleType = new BaseCreativeroleTypeControl();
            _baseGenreType = new BaseGenreTypeControl();
            _baseKlr030 = new BaseKlr030Control();
            _baseSystemConstant = new BaseSystemConstantControl();
            _baseTypePlace = new BaseTypePlaceControl();
        }

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
                    controlPanel.Controls.Add(_ctrlCopyrightKind);
                    _ctrlCopyrightKind.SetDataByDictionaryURL(UrlForComplexDictionaries);
                    break;
                case "country":
                    controlPanel.Controls.Add(_baseCountry);
                    _baseCountry.SetDataByDictionaryURL(UrlForComplexDictionaries);
                    break;
                case "creativeroletype":
                    controlPanel.Controls.Add(_baseCreativeroleType);
                    _baseCreativeroleType.SetDataByDictionaryURL(UrlForComplexDictionaries);
                    break;
                case "genretype":
                    controlPanel.Controls.Add(_baseGenreType);
                    _baseGenreType.SetDataByDictionaryURL(UrlForComplexDictionaries);
                    break;
                case "kl_r030":
                    controlPanel.Controls.Add(_baseKlr030);
                    _baseKlr030.SetDataByDictionaryURL(UrlForComplexDictionaries);
                    break;
                case "systemconstant":
                    controlPanel.Controls.Add(_baseSystemConstant);
                    _baseSystemConstant.SetDataByDictionaryURL(UrlForComplexDictionaries);
                    break;
                case "typeplace":
                    controlPanel.Controls.Add(_baseTypePlace);
                    _baseTypePlace.SetDataByDictionaryURL(UrlForComplexDictionaries);
                    break;
                case "relgenrepercent":
                    controlPanel.Controls.Add(_ctrlRelGenrePercent);
                    _ctrlRelGenrePercent.SetDataByDictionaryURL(UrlForComplexDictionaries);
                    break;
            }
        }
    }
}


