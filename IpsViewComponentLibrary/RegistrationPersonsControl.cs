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
        private bool _residencySelected = false,
                     _citizenshipSelected = false;

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => iAnketaPersonBindingSource.DataSource;
            set => iAnketaPersonBindingSource.DataSource = value;
        }

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

        private void rDropListCitizenship_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            _citizenshipSelected = rDropListCitizenship.SelectedItem.Index != 0;
        }

        private void rDropDownListResidency_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            _residencySelected = rDropDownListResidency.SelectedItem.Index != 0;
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

            if (!_citizenshipSelected)
            {
                lblCitizenship.ForeColor = Color.FromArgb(180, 255, 0, 2); ;
                isValid = false;
            }
            else 
                lblCitizenship.ForeColor = Color.Black;

            if (!_residencySelected)
            {
                lblResidency.ForeColor= Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblResidency.ForeColor = Color.Black;

            return isValid;
        }

        private void Setter()
        {
            //rDropListCitizenship.Items[0].
        }
    }
}
