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

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight
{
    public partial class AgreementPhis : UserControl
    {
        public AgreementPhis()
        {
            InitializeComponent();
            ddlTypeAutoProl.Enabled = false;
            txtPercentAutoProl.Enabled = false;
            txtPercentAutoProl.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            txtRateAmount.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            txtMinAmount.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
        }

        public object LicenseAgreementDataSource
        {
            get => bsLicenseAgreement.DataSource;
            set
            {
                bsDictLicenseType.DataSource = IpsGlobal.AnketaDictionaties.licenseType;
                bsDictPeriod.DataSource = IpsGlobal.AnketaDictionaties.period;
                bsLicenseAgreement.DataSource = value;
                bsLicenseAgrParam.DataSource = (value as LicenseAgreement)?.LicenseAgrParam;
            }
        }

        private void ddlTypeAutoProl_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            switch (ddlTypeAutoProl.SelectedItem.Index)
            {
                case 0:
                    if(bsLicenseAgrParam.DataSource is LicenseAgrParam indxInfl)
                        indxInfl.IndxInfl = 0m;
                    txtPercentAutoProl.DataBindings.Clear();
                    txtPercentAutoProl.DataBindings.Add("Text", bsLicenseAgrParam, "AddRate", true, DataSourceUpdateMode.OnPropertyChanged, 0m);
                    break;
                case 1:
                    if (bsLicenseAgrParam.DataSource is LicenseAgrParam addRate)
                        addRate.AddRate = 0m;
                    txtPercentAutoProl.DataBindings.Clear();
                    txtPercentAutoProl.DataBindings.Add("Text", bsLicenseAgrParam, "IndxInfl", true, DataSourceUpdateMode.OnPropertyChanged, 0m);
                    break;
            }
        }

        private void checkAutoprolongation_CheckStateChanged(object sender, EventArgs e)
        {

            ddlTypeAutoProl.Enabled = checkAutoprolongation.Checked;
            txtPercentAutoProl.Enabled = checkAutoprolongation.Checked;

            if (checkAutoprolongation.Checked)
            {
                txtPercentAutoProl.Clear();
            }
        }

        public bool Validator()
        {
            bool isValid = true;

            if (txtRateAmount.Text == string.Empty)
            {
                isValid = false;
                radLabel1.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else
                radLabel1.ForeColor = Color.Black;

            if (txtPercentAutoProl.Text == string.Empty)
            {
                isValid = false;
                radLabel2.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else
                radLabel2.ForeColor = Color.Black;


            return isValid;
        }
    }
}
