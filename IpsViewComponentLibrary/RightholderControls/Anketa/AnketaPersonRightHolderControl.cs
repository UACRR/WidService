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
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.Utilities;

namespace IpsViewComponentLibrary.RightholderControls.Anketa
{
    public partial class AnketaPersonRightHolderControl : UserControl
    {
        private bool _birthDateSelected = false;

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSourceAnketa
        {
            get => bsAnketaPerson.DataSource;
            set
            {
                if (bsAnketaPerson.DataSource != value)
                {
                    bsAnketaPerson.DataSource = value;
                }
            }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSourceCustomer
        {
            get => bsCustomer.DataSource;
            set
            {
                if (bsCustomer.DataSource != value)
                {
                    bsCustomer.DataSource = value;
                }
            }
        }

        public AnketaPersonRightHolderControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                dtBirthDate.SetUserCalendarSettings();
                ddlSexType.SetDataSource(IpsGlobal.AnketaDictionaties.sexType);
            }
        }

        /// <summary>
        /// Перевірка на правильність введених даних
        /// </summary>
        /// <returns></returns>
        public bool Validator()
        {
            bool isValid = true;

            if (!_birthDateSelected)
            {
                lblBirthDate.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblBirthDate.ForeColor = Color.Black;

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                lblFirstName.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblFirstName.ForeColor = Color.Black;

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                lblLastName.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblLastName.ForeColor = Color.Black;

            //if (!_sexSelected)
            //{
            //    lblSex.ForeColor = Color.FromArgb(180, 255, 0, 2);
            //    isValid = false;
            //}
            //else
            //    lblSex.ForeColor = Color.Black;

            return isValid;
        }

        /// <summary>
        /// Очищення введених даних
        /// </summary>
        public void ClearData()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMidleName.Clear();
            txtPseudonym.Clear();
            dtBirthDate.SetToNullValue();
            //_sexSelected = false;
            _birthDateSelected = false;
        }

        private void btnMoreName_Click(object sender, EventArgs e)
        {
            ShowEditAddNamesView();
        }

        private void btnMoreLastName_Click(object sender, EventArgs e)
        {
            ShowEditAddNamesView();
        }

        private void btnMoreSurName_Click(object sender, EventArgs e)
        {
            ShowEditAddNamesView();
        }

        private void btnMorePseudonym_Click(object sender, EventArgs e)
        {
            var customer = bsCustomer.Current as Customer;

            using (var moreNicks = new AnketaAddNickView(customer.RightHolder.AnketaAddNick))
            {
                moreNicks.AddNicksUpdated += AddNicksUpdated;
                moreNicks.ShowDialog();
            }
        }

        private void dtPickerBirth_ValueChanged(object sender, EventArgs e)
        {
            _birthDateSelected = true;
        }

        private void ShowEditAddNamesView()
        {
            var customer = bsCustomer.Current as Customer;

            using (var moreNames = new AnketaAddNamesView(customer.AnketaAddName))
            {
                moreNames.ShowDialog();
            }
        }

        private void AddNicksUpdated(object sender, ICollection<AnketaAddNick> anketaAddNicks)
        {
            var customer = bsCustomer.Current as Customer;

            customer.RightHolder.AnketaAddNick = new ObservableListSource<AnketaAddNick>(anketaAddNicks.ToList());
        }
    }
}
