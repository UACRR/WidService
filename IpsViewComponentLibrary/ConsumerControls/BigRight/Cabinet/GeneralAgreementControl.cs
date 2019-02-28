using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerDialogForms;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerControls.BigRight.Cabinet
{
    public partial class GeneralAgreementControl : UserControl
    {
        private const string ProlongationAgr = "Пролонгація генерального договору";
        private const string EditAgr = "Редагування генерального договору";

        private const string CloseAgreementMsgQuestion = "Закрити генеральний договір?";
        private const string CloseAgreementSuccess = "Генеральний договір закрито!";
        private const string CloseAgreementError = "Неможливо закрити генеральний договір!";

        private const string ProlongationSuccess = "Генеральний договір пролонговано!";
        private const string ProlongationError = "Неможливо пролонгувати генеральний договір!";

        private Customer _customer;
        public event LisenseStatusChangeEventHandler OnLicStatusChange;
        public event SaveObjectByIdEventHandler<LicenseAgreement> GeneralAgreementSaveChanges;
        public event EmptyEventHandler UpdateData;

        public GeneralAgreementControl()
        {
            InitializeComponent();
        }

        public void SetAndUpdateData(Customer customer, MainGridConsumerBigRightView bigRightView, IList<GeneralAgreementBigRightView> genAgrs)
        {
            _customer = customer;
            ctrlGeneralAgrDetailInfoBr.DataSourceLicense = bigRightView;
            gvGenAgrLicences.DataSource = genAgrs;
        }

        private void gvGenAgrLicences_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            var status = (e?.CurrentRow?.DataBoundItem as GeneralAgreementBigRightView)?.AgrStatus ?? -1;

            if (status == 0 || status == 5)
                btnChangeGenAgr.Enabled = true;
            else
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
            var row = e.Row.DataBoundItem as GeneralAgreementBigRightView;
            var licenseAgreement = _customer.Client.LicenseAgreement.SingleOrDefault(r => r.LicId == row?.LicId);
            var print = new ViewAndPrintAgreementForm(_customer, licenseAgreement);
            print.ShowDialog();
        }

        #region * * * дії з генеральним договором * * *

        // кнопка підтвердити договір
        private void btnStatusAcceptGenAgr_Click(object sender, EventArgs e)
        {
            if (!(gvGenAgrLicences.CurrentRow?.DataBoundItem is GeneralAgreementBigRightView licrow))
                return;

            var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licrow?.LicId);
            OnLicStatusChange?.Invoke(license, licrow.Version, 2, false);
            UpdateData?.Invoke();
        }

        // кнопка закрити генеральний договір
        private void btnStatusClosedGenAgr_Click(object sender, EventArgs e)
        {
            if (!(gvGenAgrLicences.CurrentRow?.DataBoundItem is GeneralAgreementBigRightView licrow))
                return;

            if (MessageShow.ConfirmAction(CloseAgreementMsgQuestion) == DialogResult.Yes)
            {
                var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licrow?.LicId);
                var result = OnLicStatusChange?.Invoke(license, licrow.Version, 4, false) ?? false;
                if(result)
                    UpdateData?.Invoke();
                MessageShow.ShowInfoByResult(CloseAgreementSuccess, CloseAgreementError, result);
            }
        }

        /// <summary>
        /// Редагування/пролонгація генерального догвору
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        private bool? ChangeAgreement(string formName = null)
        {
            if (!(gvGenAgrLicences.CurrentRow.DataBoundItem is GeneralAgreementBigRightView item))
                return null;

            var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId);
            var agreementBr = license?.Agr?.AgreementAddBr?.SingleOrDefault(rec => rec.Version == item.Version);

            if (agreementBr == null)
                return null;

            var agreementBrForm = new GeneralAgreementBrForm(agreementBr, formName);
            if (agreementBrForm.ShowDialog() == DialogResult.OK)
            {
                var resust = GeneralAgreementSaveChanges?.Invoke(license.AgrId, license) ?? false;
                return resust;
            }

            return null;
        }

        // кнопка пролонгувати
        private void btnProlongationGenAgr_Click(object sender, EventArgs e)
        {
            var result = ChangeAgreement(ProlongationAgr);
            if(result == null) return;
            if ((bool)result)
                UpdateData?.Invoke();

            MessageShow.ShowInfoByResult(ProlongationSuccess, ProlongationError, (bool)result);
        }

        // кнопка змінити/редагувати договір
        private void btnEditGenAgr_Click(object sender, EventArgs e)
        {
            var result = ChangeAgreement(EditAgr);
            if (result == null)
                return;

            if ((bool)result)
                UpdateData?.Invoke();

            ExtensionUtils.ShowMessage((bool)result, MessageType.GeneralAgreementChange);
        }

        #endregion
    }
}
