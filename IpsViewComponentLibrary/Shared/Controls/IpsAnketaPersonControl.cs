using System;
using System.Drawing;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.Shared.Controls
{
    public partial class IpsAnketaPersonControl : UserControl
    {
        public event Action<string> CustomerNameChanged;

        private bool _birthDateSelected;

        public IpsAnketaPersonControl()
        {
            InitializeComponent();
            if (IpsGlobal.AnketaDictionaties != null)
                bsSexType.DataSource = IpsGlobal.AnketaDictionaties.sexType;

            dtBirthDay.ValueChanged += dtBirthDay_ValueChanged;
            dtBirthDay.SetUserCalendarSettings();
        }

        public object DataSourceAnketa
        {
            get => bsAnketaPerson.DataSource;
            set => bsAnketaPerson.DataSource = value;
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

            if (txtFirstName.Text == string.Empty)
            {
                lblFirstName.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblFirstName.ForeColor = Color.Black;

            if (txtLastName.Text == string.Empty)
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

        private void dtBirthDay_ValueChanged(object sender, EventArgs e)
        {
            _birthDateSelected = true;
        }

        private void Name_Leave(object sender, EventArgs e)
        {
            string customerName;

            if (string.IsNullOrEmpty(txtLastName.Text) && string.IsNullOrEmpty(txtFirstName.Text) && string.IsNullOrEmpty(txtSurName.Text))
                customerName = string.Empty;
            else
                customerName = $"{txtLastName.Text} {txtFirstName.Text} {txtSurName.Text}";

            CustomerNameChanged?.Invoke(customerName);
        }
    }
}
