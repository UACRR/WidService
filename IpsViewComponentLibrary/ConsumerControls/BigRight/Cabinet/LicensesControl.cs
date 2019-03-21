using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerDialogForms;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.Shared.Forms;

namespace IpsViewComponentLibrary.ConsumerControls.BigRight.Cabinet
{
    public partial class LicensesControl : UserControl
    {
        private const string CloseLicenseQuestion = "Ліцензія буде закрита! Підтвердити дію?";
        private const string CloseLicenseSuccess = "Ліцензію закрито!";
        private const string CloseLicenseError = "Неможливо закрити ліцензію!";
        private const string ProlongationSuccess = "Ліцензійний договір пролонговано!";
        private const string ProlongationError = "Неможливо пролонгувати ліцензійний договір!";

        private Customer _customer;
        public event LicenseStatusChangeEventHandler OnLicenseCloseAndDelete;
        public event SaveCustomerEventHandler OnSaveCustomer;
        public event EmptyEventHandler UpdateData;

        public LicensesControl()
        {
            InitializeComponent();
            ctrlAgrDetailInfo.OnSaveCommentNeed += CtrlAgrDetailInfo_OnSaveCommentNeed;
            ctrlSearch.SetUsageGrid(gvViewLicences);
        }

        private void CtrlAgrDetailInfo_OnSaveCommentNeed(object sender, EventArgs e)
        {
            var result = OnSaveCustomer?.Invoke(_customer);
            if (result ?? false)
                MessageShow.ShowInfo("Примітку збережено!");
        }

        public void SetData(Customer customer, List<LicenseAgreementBigRightView> sourceGrid)
        {
            _customer = customer;
            ctrlAgrInfo.DataSource = ViewsSingleton.ConsumerBigRightView;
            gvViewLicences.DataSource = sourceGrid;
        }

        private void gvViewLicences_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if(gvViewLicences.Rows.Count == 0 || e.CurrentRow?.DataBoundItem == null)
            {
                ctrlAgrDetailInfo.ClearData();
                ctrlAgrDetailInfo.Enabled = false;
                btnToProlongation.Enabled = false;
                btnCloseAgr.Enabled = false;
                return;
            }
            
            if (ctrlAgrDetailInfo.Enabled == false)
            {
                ctrlAgrDetailInfo.Enabled = true;
                btnToProlongation.Enabled = true;
                btnCloseAgr.Enabled = true;
            }

            var lic = e.CurrentRow.DataBoundItem as LicenseAgreementBigRightView;

            btnToProlongation.Enabled = lic?.LicStatus == 2;
            btnCloseAgr.Enabled = lic?.LicStatus != 4;

            //оновлення інфи
            var licAgrParam = _customer.Client.LicenseAgreement
                .SingleOrDefault(rec => rec.LicId == lic?.LicId)?
                .LicenseAgrParam
                .SingleOrDefault(rec => rec.LicVersion == lic?.LicVersion);
            if(licAgrParam == null) return;
            ctrlAgrDetailInfo.SetDataInfo(licAgrParam, lic);
        }

        // командні кнопки на грід
        private void gvViewLicences_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (!(e.Row.DataBoundItem is LicenseAgreementBigRightView item))
                return;

            switch (e.Column.FieldName)
            {
                case "viewBtn":
                    var viewLicenseForm = new RequestForm(_customer, ViewsSingleton.ConsumerBigRightView, ScopeOfUseForm.View, item.LicId);
                    viewLicenseForm.ShowDialog();
                    break;
                case "printBtn":
                    var licenseAgreement = _customer.Client.LicenseAgreement.SingleOrDefault(r => r.LicId == item.LicId);
                    var print = new ViewAndPrintAgreementForm(_customer, licenseAgreement);
                    print.ShowDialog();
                    break;
            }
        }

        // закрити ліцензію
        private void btnCloseAgr_Click(object sender, EventArgs e)
        {
            if (!(gvViewLicences?.CurrentRow?.DataBoundItem is LicenseAgreementBigRightView item))
                return;

            if (MessageShow.ConfirmAction(CloseLicenseQuestion) == DialogResult.Yes)
            {
                var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId);
                var result = OnLicenseCloseAndDelete?.Invoke(license, item.LicVersion, 4, false) ?? false;
                if (result)
                    UpdateData?.Invoke();
                MessageShow.ShowInfoByResult(CloseLicenseSuccess, CloseLicenseError, result);
            }
        }

        // пролонгація
        private void btnToProlongation_Click(object sender, EventArgs e)
        {
            if(!(gvViewLicences.CurrentRow.DataBoundItem is LicenseAgreementBigRightView item))
                return;

            var license = _customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec?.LicId == item.LicId);
            var prolongation = new ProlongationBigRight(license, item.Name);

            if (prolongation.ShowDialog() == DialogResult.OK)
            {
                var result = OnSaveCustomer?.Invoke(_customer) ?? false;
                if (result)
                    UpdateData?.Invoke();
                MessageShow.ShowInfoByResult(ProlongationSuccess, ProlongationError, result);
            }
        }

        // кнопка оновлення даних
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData?.Invoke();
        }
    }
}
