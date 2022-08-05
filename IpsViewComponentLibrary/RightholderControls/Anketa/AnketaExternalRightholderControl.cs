using System.Windows.Forms;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.RightholderControls.Anketa
{
    public partial class AnketaExternalRightholderControl : UserControl
    {
        public AnketaExternalRightholderControl()
        {
            InitializeComponent();
            if (IpsGlobal.AnketaDictionaties != null)
                bsDictCountry.DataSource = IpsGlobal.AnketaDictionaties.country;

            txtInnOkpo.KeyPress += ExtensionUtils.TextBoxNumeric_KeyPressEvent;
        }

        public object DataSourceRightHolder
        {
            get => bsRightHolder.DataSource;
            set => bsRightHolder.DataSource = value;
        }

        public object DataSourceAnketaExternal
        {
            get => bsAnketaExternal.DataSource;
            set
            {
                bsAnketaExternal.DataSource = value;
                ddlCountry.SelectedIndex = 0;
            }
        }
    }
}
