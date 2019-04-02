using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.Shared.Controls
{
    public partial class ContactsPersonControl : UserControl
    {

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => bsAnketaPerson.DataSource;
            set => bsAnketaPerson.DataSource = value;
        }

        public ContactsPersonControl()
        {
            InitializeComponent();
            rtxtBoxMobPhone.MaxLength = 13;
            rtxtBoxMobPhoneSecond.MaxLength = 13;
            rtxtBoxHomePhone.MaxLength = 14;
        }

        public bool Validator()
        {
            bool isValid = true;

            if (rtxtBoxMobPhone.Text == string.Empty)
            {
                lblMobPhone.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblMobPhone.ForeColor = Color.Black;

            return isValid;
        }
    }
}
