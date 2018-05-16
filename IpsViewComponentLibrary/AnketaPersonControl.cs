using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace DebugFormForControls
{
    public partial class AnketaPersonControl : UserControl
    {
        private bool _birthDateSelected = false,
                     _sexSelected = false;

        public object DataSource { get; set; }

        public AnketaPersonControl()
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
            rdtPickerBirth.SetToNullValue();
            _sexSelected = false;
            _birthDateSelected = false;
        }

        // * * * вибір дати народження
        private void rdtPickerBirth_ValueChanged(object sender, EventArgs e)
        {
            _birthDateSelected = true;
        }
    }
}
