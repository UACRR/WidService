using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class ObjectRightBrInfoControl : UserControl
    {
        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object ObjectRightDataSource
        {
            get { return objectRightBindingSource.DataSource; }
            set
            {
                if (objectRightBindingSource.DataSource != value)
                {
                    objectRightBindingSource.DataSource = value;
                }
            }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object LicenseBigRDataSource
        {
            get { return licenseBigRBindingSource.DataSource; }
            set
            {
                if (licenseBigRBindingSource.DataSource != value)
                {
                    licenseBigRBindingSource.DataSource = value;
                }
            }
        }

        public ObjectRightBrInfoControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                SetDictionaries();

                ddlLangCode.SelectedValue = "uk";
            }
        }

        private void SetDictionaries()
        {
            ddlGenreType.ValueMember = "CodeI";
            ddlGenreType.DisplayMember = "Name";
            ddlGenreType.DataSource = IpsGlobal.ObjectRightDictionaries.genreType.Where(g => g.CategoryCode == 6);

            ddlLangCode.ValueMember = "CodeS";
            ddlLangCode.DisplayMember = "Name";
            ddlLangCode.DataSource = IpsGlobal.AnketaDictionaties.language;
        }
    }
}
