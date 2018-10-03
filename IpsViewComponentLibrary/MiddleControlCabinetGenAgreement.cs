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
        private MainGridConsumerBigRightView _bigRightView;
        public event LisenseStatusChangeEventHandler OnLicStatusChange;
        public event SaveCustomerEventHandler OnLicenseSaveNeed;


        public MiddleControlCabinetGenAgreement()
        {
            InitializeComponent();
        }

        public void SetAndUpdateData(Customer customer, MainGridConsumerBigRightView bigRightView, IList<GeneralAgreementBigRightView> genAgrs)
        {
            _customer = customer;
            _bigRightView = bigRightView;
            ctrlGeneralAgrDetailInfoBr.DataSourceLicense = bigRightView;
            gvGenAgrLicences.DataSource = genAgrs;
        }

        private void gvGenAgrLicences_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            var status = (e?.CurrentRow?.DataBoundItem as GeneralAgreementBigRightView)?.AgrStatus ?? -1;

            if (status != 4)
                btnChangeGenAgr.Enabled = true;
            else if (btnChangeGenAgr.Enabled)
                btnChangeGenAgr.Enabled = false;

            if (status == 0 || status == 1)
                btnStatusAcceptGenAgr.Enabled = true;
            else if(btnStatusAcceptGenAgr.Enabled)
                btnStatusAcceptGenAgr.Enabled = false;

            if (status == 2)
                btnStatusClosedGenAgr.Enabled = true;
            else if (btnStatusClosedGenAgr.Enabled)
                btnStatusClosedGenAgr.Enabled = false;
        }

        // кнопки на [грід]
        private void gvGenAgrLicences_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "btnEdit":
                    ViewAgreemet();
                    break;
                case "printBtn":
                    var row = e.Row.DataBoundItem as GeneralAgreementBigRightView;
                    var licenseAgreement = _customer.Client.LicenseAgreement.SingleOrDefault(r => r.LicId == row?.LicId);
                    var print = new ViewAndPrintAgreement(IpsGlobal.AnketaDictionaties, _customer, licenseAgreement)
                    {
                        WindowState = FormWindowState.Maximized,
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    print.ShowDialog();
                    break;
            }
        }

        //редагування догвору
        private void EditAgreement()
        {
            var id = (gvGenAgrLicences.CurrentRow.DataBoundItem as GeneralAgreementBigRightView)?.LicId;
            var version = (gvGenAgrLicences.CurrentRow.DataBoundItem as GeneralAgreementBigRightView)?.Version;

            var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == id);
            var agreementBr = license?.Agr.AgreementAddBr.SingleOrDefault(rec => rec.Version == version);
            var anketaComp = _customer?.Company?.AnketaCompany.SingleOrDefault(rec => rec.Version == _customer.AnkVersion);

            AddGeneralAgreementBrForm agreementBrForm = new AddGeneralAgreementBrForm(IpsGlobal.AnketaDictionaties, license, agreementBr, anketaComp)
            {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterParent
            };
            if (agreementBrForm.ShowDialog() == DialogResult.OK)
            {
                var resust = OnLicenseSaveNeed?.Invoke(_customer) ?? false;
                ExtensionUtils.ShowMessage(resust, MessageType.GeneralAgreementChange);
            }
        }
        
        //перегляд договору
        private void ViewAgreemet()
        {
            var id = (gvGenAgrLicences.CurrentRow.DataBoundItem as GeneralAgreementBigRightView)?.LicId;
            var licence = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == id);
            ViewAndPrintAgreement print = new ViewAndPrintAgreement(dictionaties: IpsGlobal.AnketaDictionaties, customer: _customer, licenseAgreement: licence)
            {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen
            };
            print.ShowDialog();
        }

        //підтвердити договір
        private void btnStatusAcceptGenAgr_Click(object sender, EventArgs e)
        {
            if (gvGenAgrLicences.CurrentRow.DataBoundItem is GeneralAgreementBigRightView licrow)
            {
                var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licrow?.LicId);
                OnLicStatusChange?.Invoke(license, licrow.Version, 2, false);
            }
        }

        //закрити генеральний договір
        private void btnStatusClosedGenAgr_Click(object sender, EventArgs e)
        {
            if (RadMessageBox.Show("Закрити генеральний договір?", "Підтвердження", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                if (gvGenAgrLicences.CurrentRow.DataBoundItem is GeneralAgreementBigRightView licrow)
                {
                    var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licrow?.LicId);
                    var result = OnLicStatusChange?.Invoke(license, licrow.Version, 4, false);
                }
            }
        }

        #region Дії з договором

        //пролонгувати
        private void btnProlongationGenAgr_Click(object sender, EventArgs e)
        {
            //if (!(gvViewLicences.CurrentRow.DataBoundItem is LicenseAgreementBigRightView item)) return;
            //var license = _customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec?.LicId == item.LicId);
            //ProlongationBigRight prolongation = new ProlongationBigRight(_customer, license, item.Name);
            //if (prolongation.ShowDialog() == DialogResult.OK)
            //{
            //    var result = OnSaveCustomer?.Invoke(_customer);
            //    if (result ?? false)
            //        ExtensionUtils.ShowInfoMessage("Ліцензійний договір пролонговано!", "Успішно", MessageBoxIcon.Information);
            //    else
            //        ExtensionUtils.ShowInfoMessage("Неможливо пролонгувати ліцензійний договір!", "Помилка", MessageBoxIcon.Error);
            //}
        }

        //змінити/редагувати договір
        private void btnChangeGenAgr_Click(object sender, EventArgs e)
        {
            //не підтверджений або відхилений
            if (gvGenAgrLicences.CurrentRow.DataBoundItem is GeneralAgreementBigRightView item && (item.AgrStatus == 0 || item.AgrStatus == 5))
                EditAgreement();
        }

        #endregion
    }
}
