using System.Windows.Forms;

namespace IpsViewComponentLibrary.Shared.Controls
{
    public partial class IpsBankAccountControl : UserControl
    {
        public IpsBankAccountControl()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            get => bsBankAccount.DataSource;
            set => bsBankAccount.DataSource = value;
        }

        public bool Validator()
        {
            bool isValid = true;

            //if (rtxtBoxAuthorPaymentPercent.Text == string.Empty)
            //{
            //    isValid = false;
            //    radLabel1.ForeColor = Color.FromArgb(180, 255, 0, 2); ;
            //}
            //else
            //    radLabel1.ForeColor = Color.Black;

            return isValid;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
