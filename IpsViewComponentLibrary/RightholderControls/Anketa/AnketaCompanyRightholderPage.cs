using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using IpsViewComponentLibrary.Utilities;
using ipsFormsDesign.Data;
using System;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

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

        private void txtInterCode_Leave(object sender, EventArgs e)
        {
            // Тільки нові правовласники
            RightHolder cust = bsRightHolder.DataSource as RightHolder;
            if (cust == null || cust.CustId != 0)
                return;

            if (!IpsGlobal.Instances.Keys.Contains(typeof(IUniqueChecker)))
                return;

            IUniqueChecker checker = IpsGlobal.Instances[typeof(IUniqueChecker)] as IUniqueChecker;
            if (checker != null)
                lblIPIExists.Visible = !checker.CheckIPIIsUnique( txtInterCode.Text );
        }
    }
}
