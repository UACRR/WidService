using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IpsViewComponentLibrary;
using Telerik.WinControls.UI;
using ipsFormsDesign.Model;
using ipsFormsDesign.Interfaces;
using IpsViewComponentLibrary.RightholderControls;

namespace DebugFormForControls
{
    public partial class AnketaPersonRightHolderControl : UserControl
    {
        private bool _birthDateSelected = false;
        //_sexSelected = false;

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSourceAnketa
        {
            get => anketaPersonBindingSource.DataSource;
            set
            {
                if (anketaPersonBindingSource.DataSource != value)
                {
                    anketaPersonBindingSource.DataSource = value;
                }
            }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSourceCustomer
        {
            get => customerBindingSource.DataSource;
            set
            {
                if (customerBindingSource.DataSource != value)
                {
                    customerBindingSource.DataSource = value;
                }
            }
        }

        #region Sex type dictionary

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object SexTypeDataSource
        {
            get { return radDropDownListSex.DataSource; }
            set
            {
                if (radDropDownListSex.DataSource != value)
                    radDropDownListSex.DataSource = value;
            }
        }

        [Category("Dictionaries")]
        public string SexTypeDataMember
        {
            get { return radDropDownListSex.DataMember; }
            set { radDropDownListSex.DataMember = value; }
        }

        [Category("Dictionaries")]
        public string SexTypeDisplayMember
        {
            get { return radDropDownListSex.DisplayMember; }
            set { radDropDownListSex.DisplayMember = value; }
        }

        [Category("Dictionaries")]
        public string SexTypeValueMember
        {
            get { return radDropDownListSex.ValueMember; }
            set { radDropDownListSex.ValueMember = value; }
        }

        #endregion

        public AnketaPersonRightHolderControl()
        {
            InitializeComponent();
            rdtPickerBirth.SetUserCalendarSettingsm();
        }

        #region Edit controls

        public RadDateTimePicker dtBirthDate
        {
            get
            {
                return rdtPickerBirth;
            }
        }

        #endregion

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

            if (rtxtBoxFirstName.Text == string.Empty)
            {
                lblFirstName.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblFirstName.ForeColor = Color.Black;

            if (rtxtBoxLastName.Text == string.Empty)
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
            rtxtBoxFirstName.Clear();
            rtxtBoxLastName.Clear();
            rtxtBoxMidleName.Clear();
            rtxtBoxPseudonym.Clear();
            rdtPickerBirth.SetToNullValue();
            //_sexSelected = false;
            _birthDateSelected = false;
        }

        //private void radDropDownListSex_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        //{
        //    _sexSelected = radDropDownListSex.SelectedItem.Index != 0;
        //}

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
            var customer = customerBindingSource.Current as Customer;

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
            var customer = customerBindingSource.Current as Customer;

            using (var moreNames = new AnketaAddNamesView(customer.AnketaAddName))
            {
                moreNames.ShowDialog();
            }
        }

        private void AddNicksUpdated(object sender, ICollection<AnketaAddNick> anketaAddNicks)
        {
            var customer = customerBindingSource.Current as Customer;

            customer.RightHolder.AnketaAddNick = new ObservableListSource<AnketaAddNick>(anketaAddNicks.ToList());
        }
    }
}
