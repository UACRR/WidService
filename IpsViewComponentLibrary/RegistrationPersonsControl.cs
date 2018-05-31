using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    public partial class RegistrationPersonsControl : UserControl
    {
        //private bool _residencySelected = false,
        //             _citizenshipSelected = false;

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => iAnketaPersonBindingSource.DataSource;
            set
            {
                iAnketaPersonBindingSource.DataSource = value;

                rDropListCitizenship.DataBindings.Clear();
                rDropListCitizenship.DataBindings.Add("SelectedValue", iAnketaPersonBindingSource, "Citizenship", true);

                rDropDownListResidency.DataBindings.Clear();
                rDropDownListResidency.DataBindings.Add("SelectedValue", iAnketaPersonBindingSource, "Residency", true);
            }
        }

        #region Resident type dictionary

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object ResidentTypesDataSource
        {
            get { return rDropDownListResidency.DataSource; }
            set
            {
                if (rDropDownListResidency.DataSource != value)
                    rDropDownListResidency.DataSource = value;
            }
        }

        [Category("Dictionaries")]
        public string ResidentTypesDataMember
        {
            get { return rDropDownListResidency.DataMember; }
            set { rDropDownListResidency.DataMember = value; }
        }

        [Category("Dictionaries")]
        public string ResidentTypesDisplayMember
        {
            get { return rDropDownListResidency.DisplayMember; }
            set { rDropDownListResidency.DisplayMember = value; }
        }

        [Category("Dictionaries")]
        public string ResidentTypesValueMember
        {
            get { return rDropDownListResidency.ValueMember; }
            set { rDropDownListResidency.ValueMember = value; }
        }

        #endregion

        #region Country dictionary

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object CountriesDataSource
        {
            get { return rDropListCitizenship.DataSource; }
            set
            {
                if (rDropListCitizenship.DataSource != value)
                    rDropListCitizenship.DataSource = value;
            }
        }

        [Category("Dictionaries")]
        public string CountriesDataMember
        {
            get { return rDropListCitizenship.DataMember; }
            set { rDropListCitizenship.DataMember = value; }
        }

        [Category("Dictionaries")]
        public string CountriesDisplayMember
        {
            get { return rDropListCitizenship.DisplayMember; }
            set { rDropListCitizenship.DisplayMember = value; }
        }

        [Category("Dictionaries")]
        public string CountriesValueMember
        {
            get { return rDropListCitizenship.ValueMember; }
            set { rDropListCitizenship.ValueMember = value; }
        }

        #endregion

        public RegistrationPersonsControl()
        {
            InitializeComponent();
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
            bool isValid = true;

            if (rtxtBoxIPN.Text == string.Empty)
            {
                lblipn.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblipn.ForeColor = Color.Black;

            //if (!_citizenshipSelected)
            //{
            //    lblCitizenship.ForeColor = Color.FromArgb(180, 255, 0, 2); ;
            //    isValid = false;
            //}
            //else 
            //    lblCitizenship.ForeColor = Color.Black;

            //if (!_residencySelected)
            //{
            //    lblResidency.ForeColor= Color.FromArgb(180, 255, 0, 2);
            //    isValid = false;
            //}
            //else
            //    lblResidency.ForeColor = Color.Black;

            return isValid;
        }

        private void Setter()
        {
            //rDropListCitizenship.Items[0].
        }
    }
}
