using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlAgreementProlVsPlacesType : UserControl
    {
        public delegate void SaveChange();
        public event SaveChange OnSaveChangesClick;

        public delegate void Print();
        public event Print OnPrintClick;

        public MiddleControlAgreementProlVsPlacesType()
        {
            InitializeComponent();
        }

        public string LicenseName
        {
            get => lblTitleLicAgr.Text;
            set => lblTitleLicAgr.Text = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSourceAgreement
        {
            get => bindingSourceAgr.DataSource;
            set => bindingSourceAgr.DataSource = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSourceAnketaCompany
        {
            get => bindingSourceAnketaCompany.DataSource;
            set => bindingSourceAnketaCompany.DataSource = value;
        }

        public LicenseAgrParam LicenseAgrParam
        {
            get => null;
            set
            {
                var licenseParam = value;
                ctrlAgrSecond.DataSourceBinding = licenseParam;
                ctrlAgrSecond.IsAutoprolongation = licenseParam?.IsAutoprolog ?? false;
                ctrlAgrSecond.MinPayment = "MinAmount";
                ctrlAgrSecond.PercentPayment = "RateAmount";

                ctrlAgrSecond.PeriodPaymentDataSource = Dictionaties?.period;
                ctrlAgrSecond.PeriodPaymentValueMember = "codeI";
                ctrlAgrSecond.PeriodPaymentDisplayMember = "name";
                ctrlAgrSecond.PeriodPaymentDataMember = "PeriodCode";
                ctrlAgrSecond.PeriodPaymentSelectedValue = licenseParam?.PeriodCode;

                if (licenseParam?.AddRate == null && licenseParam?.IndxInfl != null)
                    ctrlAgrSecond.SelectedItem = 1;
                else if (licenseParam?.AddRate != null && licenseParam.IndxInfl == null)
                    ctrlAgrSecond.SelectedItem = 0;
                else
                    ctrlAgrSecond.AutoprolongationPercent = null;
            }
            
        }

        public AnketaDictionaties Dictionaties { get; set; }



        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveChangesClick?.Invoke();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            OnPrintClick?.Invoke();
        }
    }
}
