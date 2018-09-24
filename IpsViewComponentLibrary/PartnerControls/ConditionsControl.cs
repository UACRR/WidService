using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class ConditionsControl : UserControl
    {
        public ConditionsControl()
        {
            InitializeComponent();
            txtSrFirstRate.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            txtSrMounthRate.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            txtPfFirstRate.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            txtPfMounthRate.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            txtCourtRate.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            txtNoCourtRate.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            txtCourtCompRate.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;

        }

        /// <summary>
        /// Джерело даних для "Умови договору"
        /// </summary>
        public object AgreementAddPartnerDataSource
        {
            get => bsAgreementAddPartner.DataSource;
            set => bsAgreementAddPartner.DataSource = value;
        }
    }
}
