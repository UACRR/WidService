using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.Utilities;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class RegistrationPersonsControl : UserControl
    {
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => bsAnketaPerson.DataSource;
            set
            {
                bsAnketaPerson.DataSource = value;

                ddlCitizenship.DataBindings.Clear();
                ddlCitizenship.DataBindings.Add("SelectedValue", bsAnketaPerson, "Citizenship", true);

                ddlResidency.DataBindings.Clear();
                ddlResidency.DataBindings.Add("SelectedValue", bsAnketaPerson, "Residency", true);
            }
        }

        public RegistrationPersonsControl()
        {
            InitializeComponent();
            txtIPN.KeyPress += ExtensionUtils.TextBoxNumeric_KeyPressEvent;

            if (!IsDesignMode)
            {
                ddlCitizenship.SetDataSource(IpsGlobal.AnketaDictionaties.country, "CountryCode", "CountryName");
                ddlResidency.SetDataSource(IpsGlobal.AnketaDictionaties.residentType);
            }
        }

        public bool Validator()
        {
            bool isValid = !lblINNPresent.Visible;

            if (txtIPN.Text == string.Empty)
            {
                lblipn.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblipn.ForeColor = Color.Black;


            return isValid;
        }

        private void txtIPN_Leave(object sender, EventArgs e)
        {
            var anketa = bsAnketaPerson.Current as AnketaPerson;
            if (anketa == null)
            {
                lblINNPresent.Visible = false;
                return;
            }

            if (!IpsGlobal.Instances.Keys.Contains(typeof(IUniqueChecker)))
                return;

            IUniqueChecker checker = IpsGlobal.Instances[typeof(IUniqueChecker)] as IUniqueChecker;
            if (checker != null)
                lblINNPresent.Visible = !checker.CheckINNIsUnique(txtIPN.Text, anketa.CustId);
        }
    }
}
