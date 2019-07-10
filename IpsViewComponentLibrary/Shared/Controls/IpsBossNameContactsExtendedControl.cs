using System.Windows.Forms;

namespace IpsViewComponentLibrary.Shared.Controls
{
    public partial class IpsBossNameContactsExtendedControl : UserControl
    {
        public IpsBossNameContactsExtendedControl()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            get => bsEmpl.DataSource;
            set
            {
                bsEmpl.DataSource = value;
                ctrlContactPerson.DataSource = value;
            }
        }

        public bool Validator()
        {
            return ctrlContactPerson.Validator();
        }
    }
}