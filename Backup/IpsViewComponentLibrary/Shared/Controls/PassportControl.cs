using System.ComponentModel;
using System.Windows.Forms;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.Shared.Controls
{
    public partial class PassportControl : UserControl
    {
        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => bsAnketaPerson.DataSource;
            set => bsAnketaPerson.DataSource = value;
        }

        public PassportControl()
        {
            InitializeComponent();
            dtPasportIssuedWhen.SetUserCalendarSettingsm();
            txtPasportNumber.KeyPress += ExtensionUtils.TextBoxNumeric_KeyPressEvent;
        }
    }
}
