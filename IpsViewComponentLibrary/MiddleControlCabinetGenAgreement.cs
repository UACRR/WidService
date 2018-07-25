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
        public MiddleControlCabinetGenAgreement()
        {
            InitializeComponent();
        }

        public void SetAndUpdateData(Customer customer, ConsumerBigRightView bigRightView, IList<BigRightMasterGenAgr> genAgrs)
        {
            _customer = customer;
            _bigRightView = bigRightView;
            SetBigRightHeaderData();
            ctrlFooterInfo.DataSourceLicense = bigRightView;
            gvGenAgrLicences.DataSource = genAgrs;
        }

        private void SetBigRightHeaderData()
        {
            var head = _customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 1);
            var contactPerson = _customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 3);
          

            ctrlHeaderInfo.NameInfo = _bigRightView.Name;
            ctrlHeaderInfo.Edrpou = _bigRightView.Innokpo;
            ctrlHeaderInfo.PibContactPerson = contactPerson?.Empl?.FirstName + " " + contactPerson?.Empl?.LastName + " " + contactPerson?.Empl?.SurName;
            ctrlHeaderInfo.PhoneContactPerson = contactPerson?.Empl?.PhoneNumber;
            ctrlHeaderInfo.EmailContactPerson = contactPerson?.Empl?.Email;
            ctrlHeaderInfo.PibManager = head?.Empl?.FirstName + " " + head?.Empl?.LastName + " " + head?.Empl?.SurName;
            ctrlHeaderInfo.PhoneManager = head?.Empl?.PhoneNumber;
            ctrlHeaderInfo.EmailManager = head?.Empl?.Email;

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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //TODO: підтвердження гененерального договору
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

        private void btnAgrClose_Click(object sender, EventArgs e)
        {
            if (RadMessageBox.Show("Закрити генеральний договір?", "Підтвердження", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                //TODO закривання договору
            }
        }
    }
}
