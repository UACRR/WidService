using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IpsViewComponentLibrary.Utilities;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Interfaces;

namespace IpsViewComponentLibrary
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

            if (!IsDesignMode)
            {
                ddlCitizenship.SetDataSource(IpsGlobal.AnketaDictionaties.country, "CountryCode", "CountryName");
                ddlResidency.SetDataSource(IpsGlobal.AnketaDictionaties.residentType);
            }
        }

        private void rtxtBoxIPN_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        public bool Validator()
        {
            bool isValid = !lblINNPresent.Visible;

            if (rtxtBoxIPN.Text == string.Empty)
            {
                lblipn.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblipn.ForeColor = Color.Black;


            return isValid;
        }

        private void rtxtBoxIPN_Leave(object sender, EventArgs e)
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
                lblINNPresent.Visible = !checker.CheckINNIsUnique(rtxtBoxIPN.Text, anketa.CustId);
        }
    }
}
