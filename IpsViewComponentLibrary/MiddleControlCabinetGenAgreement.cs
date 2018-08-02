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
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetGenAgreement : UserControl
    {
        private Customer _customer;
        private ConsumerBigRightView _bigRightView;
        public event LisenseStatusChangeEventHandler OnLicStatusChange;

        public MiddleControlCabinetGenAgreement()
        {
            InitializeComponent();
        }

        public void SetAndUpdateData(Customer customer, ConsumerBigRightView bigRightView, IList<BigRightMasterGenAgr> genAgrs)
        {
            _customer = customer;
            _bigRightView = bigRightView;
            ctrlHeaderInfo.SetHeaderInfoBigRight(_customer,_bigRightView);
            ctrlFooterInfo.DataSourceLicense = bigRightView;
            gvGenAgrLicences.DataSource = genAgrs;
        }

        private void gvGenAgrLicences_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            var status = (e?.CurrentRow?.DataBoundItem as BigRightMasterGenAgr)?.AgrStatus ?? -1;

            if (status != 4)
                btnEditAgr.Enabled = true;
            else if (btnEditAgr.Enabled)
                btnEditAgr.Enabled = false;

            if (status == 0 || status == 1)
                btnAccept.Enabled = true;
            else if(btnAccept.Enabled)
                btnAccept.Enabled = false;

            if (status == 2)
                btnAgrClose.Enabled = true;
            else if (btnAgrClose.Enabled)
                btnAgrClose.Enabled = false;
        }

        private void btnEditAgr_Click(object sender, EventArgs e)
        {
            var id = (gvGenAgrLicences.CurrentRow.DataBoundItem as BigRightMasterGenAgr)?.LicId;
            var version = (gvGenAgrLicences.CurrentRow.DataBoundItem as BigRightMasterGenAgr)?.Version;

            var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == id);
            var agreementBr = license?.Agr.AgreementAddBr.SingleOrDefault(rec => rec.Version == version);
            var anketaComp = _customer?.Company?.AnketaCompany.SingleOrDefault(rec => rec.Version == _customer.AnkVersion);

            AddGeneralAgreementBrForm agreementBrForm = new AddGeneralAgreementBrForm(IpsGlobal.AnketaDictionaties, license, agreementBr, anketaComp);

            if (agreementBrForm.ShowDialog() == DialogResult.OK)
            {
                ;
            }
        }
        
        //перегляд договору
        private void btnView_Click(object sender, EventArgs e)
        {
            var id = (gvGenAgrLicences.CurrentRow.DataBoundItem as BigRightMasterGenAgr)?.LicId;
            var licence = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == id);
            ViewAndPrintAgreement print = new ViewAndPrintAgreement(dictionaties: IpsGlobal.AnketaDictionaties, customer: _customer, licenseAgreement: licence)
            {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen
            };
            print.ShowDialog();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (gvGenAgrLicences.CurrentRow.DataBoundItem is BigRightMasterGenAgr licrow)
            {
                var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licrow?.LicId);
                OnLicStatusChange?.Invoke(license, licrow.Version, 2, false);
            }
        }

        private void btnAgrClose_Click(object sender, EventArgs e)
        {
            if (RadMessageBox.Show("Закрити генеральний договір?", "Підтвердження", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                if(gvGenAgrLicences.CurrentRow.DataBoundItem is BigRightMasterGenAgr licrow)
                {
                    var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licrow?.LicId);
                    OnLicStatusChange?.Invoke(license, licrow.Version, 4, false);
                }
            }
        }
    }
}
