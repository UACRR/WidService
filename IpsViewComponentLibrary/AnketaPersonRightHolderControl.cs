using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugFormForControls
{
    public partial class AnketaPersonRightHolderControl : UserControl
    {
        private bool _birthDateSelected = false,
            _sexSelected = false;

        public string FirstName => rtxtBoxFirstName.Text;
        public string LastName => rtxtBoxLastName.Text;
        public string MidleName => rtxtBoxMidleName.Text;
        public DateTime BirthDate => rdtPickerBirth.Value;
        public string Sex { get; private set; }
        public string Pseudonym => rtxtBoxPseudonym.Text;

        public AnketaPersonRightHolderControl()
        {
            InitializeComponent();
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

            if (!_sexSelected)
            {
                lblSex.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblSex.ForeColor = Color.Black;

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
            rRadioBtnSexMale.IsChecked = false;
            rRadioBtnSexFemale.IsChecked = false;
            _sexSelected = false;
            _birthDateSelected = false;
        }

        private void rRadioBtnSexMale_CheckStateChanged(object sender, EventArgs e)
        {
            if (rRadioBtnSexMale.IsChecked)
            {
                _sexSelected = true;
                rRadioBtnSexFemale.IsChecked = false;
                Sex = "Male";
            }
        }

        private void rRadioBtnSexFemale_CheckStateChanged(object sender, EventArgs e)
        {
            if (rRadioBtnSexFemale.IsChecked)
            {
                _sexSelected = true;
                rRadioBtnSexMale.IsChecked = false;
                Sex = "Female";
            }
        }

        private void rdtPickerBirth_ValueChanged(object sender, EventArgs e)
        {
            _birthDateSelected = true;
        }
    }
}
