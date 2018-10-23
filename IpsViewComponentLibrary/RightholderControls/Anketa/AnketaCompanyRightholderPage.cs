using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using IpsViewComponentLibrary.Utilities;
using ipsFormsDesign.Data;
using System;

namespace IpsViewComponentLibrary.RightholderControls.Anketa
{
    public partial class AnketaCompanyRightholderPage : UserControl
    {
        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object AnketaCompanyDataSource
        {
            get => bsAnketaCompany.DataSource;
            set => bsAnketaCompany.DataSource = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object RightholderDataSource
        {
            get => bsRightHolder.DataSource;
            set => bsRightHolder.DataSource = value;
        }

        public AnketaCompanyRightholderPage()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                SetDictionaries();
            }
        }

        private void SetDictionaries()
        {
            ddlRightholderType.SetDataSource(IpsGlobal.AnketaDictionaties.rholderType.Where(t => t.CodeI != 1));
        }

        public bool Validator()
        {
            return ctrlAnketaCompany.Validator() & ctrlRegistrationsCompany.Validator();
        }
    }
}
