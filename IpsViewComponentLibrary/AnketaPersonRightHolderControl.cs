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

namespace DebugFormForControls
{
    public partial class AnketaPersonRightHolderControl : UserControl
    {
        private bool _birthDateSelected = false,
                     _sexSelected = false;

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => iAnketaPersonBindingSource.DataSource;
            set
            {
                if (iAnketaPersonBindingSource.DataSource != value)
                    iAnketaPersonBindingSource.DataSource = value;
            }
        }

        public int DataSourceDropList
        {
            get => radDropDownListSex.SelectedIndex;
            set => radDropDownListSex.SelectedIndex = value;
        }


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
            _sexSelected = false;
            _birthDateSelected = false;
        }

        private void radDropDownListSex_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            _sexSelected = radDropDownListSex.SelectedItem.Index != 0;
        }


        private void rBtnMoreName_Click(object sender, EventArgs e)
        {
            ExpandedFormForAnketaPersonRightHolder more = new ExpandedFormForAnketaPersonRightHolder("firstname");
            more.StartPosition = FormStartPosition.CenterScreen;
            more.ShowDialog();
        }


        private void rBtnMoreLastName_Click(object sender, EventArgs e)
        {
            ExpandedFormForAnketaPersonRightHolder more = new ExpandedFormForAnketaPersonRightHolder("lastname");
            more.StartPosition = FormStartPosition.CenterScreen;
            more.ShowDialog();

        }

        private void rBtnMoreSurName_Click(object sender, EventArgs e)
        {
            ExpandedFormForAnketaPersonRightHolder more = new ExpandedFormForAnketaPersonRightHolder("surname");
            more.StartPosition = FormStartPosition.CenterScreen;
            more.ShowDialog();
        }

        private void rBtnMorePseudonym_Click(object sender, EventArgs e)
        {
            ExpandedFormForAnketaPersonRightHolder more = new ExpandedFormForAnketaPersonRightHolder("pseudonym");
            more.StartPosition = FormStartPosition.CenterScreen;
            more.ShowDialog();
        }

        private void rdtPickerBirth_ValueChanged(object sender, EventArgs e)
        {
            _birthDateSelected = true;
        }
    }
}
