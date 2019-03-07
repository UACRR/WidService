using System.ComponentModel;
using System.Windows.Forms;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class PassportInternationalControl : UserControl
    {
        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => bsAnketaPerson.DataSource;
            set
            {
                if (bsAnketaPerson.DataSource != value)
                    bsAnketaPerson.DataSource = value;
            }
        }

        public PassportInternationalControl()
        {
            InitializeComponent();
            dtIssuedDate.SetUserCalendarSettingsm();
            dtValidityDate.SetUserCalendarSettingsm();
        }
    }
}
