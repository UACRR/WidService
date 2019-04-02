using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.RightholderControls.Anketa
{
    public partial class AnketaExternalRightholderControl : UserControl
    {
        public AnketaExternalRightholderControl()
        {
            InitializeComponent();
            if (IpsGlobal.AnketaDictionaties != null)
                bsCountry.DataSource = IpsGlobal.AnketaDictionaties.country;

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
