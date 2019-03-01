using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerDialogForms;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.ConsumerControls.BigRight.Cabinet
{
    public partial class LicensesControl : UserControl
    {
        private const string AcceptSuccess = "Акцептовано!";
        private const string AcceptError = "Неможливо акцептувати!";
        private const string SendConfirmationSuccess = "Відправлено на погодження!";
        private const string SendConfirmationError = "Неможливо відправити на погодження!";
        private const string CloseLicenseQuestion = "Ліцензія буде закрита та автоматично видалена! Підтвердити дію?";
        private const string CloseLicenseSuccess = "Ліцензію закрито!";
        private const string CloseLicenseError = "Неможливо закрити ліцензію!";
        private const string ProlongationSuccess = "Ліцензійний договір пролонговано!";
        private const string ProlongationError = "Неможливо пролонгувати ліцензійний договір!";

        private Customer _customer;
        public event LisenseStatusChangeEventHandler OnLicenseCloseAndDelete;
        public event SaveCustomerEventHandler OnSaveCustomer;
        private MainGridConsumerBigRightView _gridMainView;
        public event EmptyEventHandler UpdateData;


        private BRLicenseButtonActionType _functionType;
        private readonly Dictionary<BRLicenseButtonActionType, string> _btnDictionary = new Dictionary<BRLicenseButtonActionType, string>{
            {BRLicenseButtonActionType.Accept, "Акцептувати"},
            {BRLicenseButtonActionType.Confirm, "На погодження"},
            {BRLicenseButtonActionType.None, string.Empty}
        };
        public LicensesControl()
        {
            InitializeComponent();
            ctrlAgrDetailInfo.OnSaveCommentNeed += CtrlAgrDetailInfo_OnSaveCommentNeed;
        }

        private void CtrlAgrDetailInfo_OnSaveCommentNeed(object sender, EventArgs e)
        {
            var result = OnSaveCustomer?.Invoke(_customer);
            if (result ?? false)
                MessageShow.ShowInfo("Примітку збережено!");
        }

        /// <summary>
        /// Джерело даних шапки
        /// </summary>
        /// <param name="comsumerBigRightView"></param>
        public void SetDataSources(MainGridConsumerBigRightView comsumerBigRightView)
        {
            _gridMainView = comsumerBigRightView;
            ctrlAgrInfo.DataSource = _gridMainView;
            ctrlSearch.SetUsageGrid(gvViewLicences);
        }

        public void SetData(Customer customer, List<LicenseAgreementBigRightView> sourceGrid)
        {
            _customer = customer;
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
            btnToAccept.Enabled = lic?.LicStatus == 0 || lic?.LicStatus == 1;

            SetBtnFunc(lic?.LicStatus == 0 ? BRLicenseButtonActionType.Confirm : lic?.LicStatus == 1 ? BRLicenseButtonActionType.Accept : BRLicenseButtonActionType.None);

            //оновлення інфи
            var licAgrParam = _customer.Client.LicenseAgreement
                .SingleOrDefault(rec => rec.LicId == lic?.LicId)?
                .LicenseAgrParam
                .SingleOrDefault(rec => rec.LicVersion == lic?.LicVersion);
            if(licAgrParam == null) return;
            ctrlAgrDetailInfo.SetDataInfo(licAgrParam, lic);
        }

        private void SetBtnFunc(BRLicenseButtonActionType type)
        {
            _functionType = type;
            if(type != BRLicenseButtonActionType.None)
                btnToAccept.Text = _btnDictionary[type];
        }

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

        // на підтвердження / акцептування
        private void btnToAccept_Click(object sender, EventArgs e)
        {
            if (!(gvViewLicences?.CurrentRow?.DataBoundItem is LicenseAgreementBigRightView item))
                return;

            bool result = false;
            var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId);

            switch (_functionType)
            {
                case BRLicenseButtonActionType.Accept:
                    result = OnLicenseCloseAndDelete?.Invoke(license, item.LicVersion, 0, false) ?? false;
                    MessageShow.ShowInfoByResult(AcceptSuccess, AcceptError, result);
                    break;

                case BRLicenseButtonActionType.Confirm:
                    result = OnLicenseCloseAndDelete?.Invoke(license, item.LicVersion, 3, false) ?? false;
                    MessageShow.ShowInfoByResult(SendConfirmationSuccess, SendConfirmationError, result);
                    break;
            }
            if (result)
                UpdateData?.Invoke();
        }


        private void gvViewLicences_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (!(e.Row.DataBoundItem is LicenseAgreementBigRightView item))
                return;

            switch (e.Column.FieldName)
            {
                case "viewBtn":
                    var viewLicenseForm = new RequestForm(_customer, _gridMainView, ScopeOfUseForm.View, item.LicId);
                    viewLicenseForm.ShowDialog();
                    break;
                case "printBtn":
                    var licenseAgreement = _customer.Client.LicenseAgreement.SingleOrDefault(r => r.LicId == item.LicId);
                    var print = new ViewAndPrintAgreementForm(_customer, licenseAgreement);
                    print.ShowDialog();
                    break;
            }
        }

        // кнопка оновлення даних
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData?.Invoke();
        }
    }
}
