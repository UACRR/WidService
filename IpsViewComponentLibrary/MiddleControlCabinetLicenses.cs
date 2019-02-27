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
using IpsViewComponentLibrary.ConsumerDialogForms;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetLicenses : UserControl
    {
        private Customer _customer;
        public event LisenseStatusChangeEventHandler OnLicenseCloseAndDelete;
        public event SaveCustomerEventHandler OnSaveCustomer;
        private MainGridConsumerBigRightView _gridMainView;
        public event EmptyEventHandler UpdateData;


        private ButtonFunctionType _functionType;
        private readonly Dictionary<ButtonFunctionType, string> _btnDictionary = new Dictionary<ButtonFunctionType, string>{
            {ButtonFunctionType.Accept, "Акцептувати"},
            {ButtonFunctionType.Agree, "На погодження"},
            {ButtonFunctionType.None, string.Empty}
        };
        public MiddleControlCabinetLicenses()
        {
            InitializeComponent();
            ctrlAgrDetailInfo.OnSaveCommentNeed += CtrlAgrDetailInfo_OnSaveCommentNeed;
        }

        private void CtrlAgrDetailInfo_OnSaveCommentNeed(object sender, EventArgs e)
        {
            var result = OnSaveCustomer?.Invoke(_customer);
            if (result ?? false)
                ExtensionUtils.ShowInfoMessage("Примітку збережено!", "Успішно", MessageBoxIcon.Information);
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
            btnToAccept.Enabled = (lic?.LicStatus == 0 || lic?.LicStatus == 1);

            SetBtnFunc(lic?.LicStatus == 0 ? ButtonFunctionType.Agree : lic?.LicStatus == 1 ? ButtonFunctionType.Accept : ButtonFunctionType.None);

            //оновлення інфи
            var licAgrParam = _customer.Client.LicenseAgreement
                .SingleOrDefault(rec => rec.LicId == lic?.LicId)?
                .LicenseAgrParam
                .SingleOrDefault(rec => rec.LicVersion == lic?.LicVersion);
            if(licAgrParam == null) return;
            ctrlAgrDetailInfo.SetDataInfo(licAgrParam, lic);
        }

        private void SetBtnFunc(ButtonFunctionType type)
        {
            _functionType = type;
            if(type != ButtonFunctionType.None)
                btnToAccept.Text = _btnDictionary[type];
        }

        private void btnCloseAgr_Click(object sender, EventArgs e)
        {
            if (gvViewLicences?.CurrentRow?.DataBoundItem is LicenseAgreementBigRightView item)
            {
                if (MessageBox.Show("Ліцензія буде закрита та автоматично видалена. Підтвердити дію?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    if (OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 4, false) ?? false)
                    {
                        ExtensionUtils.ShowInfoMessage("Ліцензію закрито", "Успішно", MessageBoxIcon.Information);
                        UpdateData?.Invoke();
                    }
                    else
                        ExtensionUtils.ShowInfoMessage("Не можливо закрити ліцензію", "Помилка", MessageBoxIcon.Error);
            }
        }

        // пролонгація
        private void btnToProlongation_Click(object sender, EventArgs e)
        {
            if(!(gvViewLicences.CurrentRow.DataBoundItem is LicenseAgreementBigRightView item)) return;
            var license = _customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec?.LicId == item.LicId);
            ProlongationBigRight prolongation = new ProlongationBigRight(_customer, license, item.Name);
            if (prolongation.ShowDialog() == DialogResult.OK)
            {
                var result = OnSaveCustomer?.Invoke(_customer);
                if (result ?? false)
                {
                    ExtensionUtils.ShowInfoMessage("Ліцензійний договір пролонговано!","Успішно", MessageBoxIcon.Information);
                    UpdateData?.Invoke();
                }
                else
                    ExtensionUtils.ShowInfoMessage("Неможливо пролонгувати ліцензійний договір!", "Помилка", MessageBoxIcon.Error);
            }
        }

        // на підтвердження / акцептування
        private void btnToAccept_Click(object sender, EventArgs e)
        {
            if (gvViewLicences?.CurrentRow?.DataBoundItem is LicenseAgreementBigRightView item)
            {
                bool result = false;
                switch (_functionType)
                {
                    case ButtonFunctionType.None:
                        break;
                    case ButtonFunctionType.Accept:
                    {
                        result = OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 0, false) ?? false;
                        if (result)
                            ExtensionUtils.ShowInfoMessage("Акцептовано!", "Успішно", MessageBoxIcon.Information);
                        else
                            ExtensionUtils.ShowInfoMessage("Не можливо акцептувати", "Помилка!", MessageBoxIcon.Error);
                    }
                        break;
                    case ButtonFunctionType.Agree:
                    {
                        result = OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 3, false) ?? false;
                        if (result)
                            ExtensionUtils.ShowInfoMessage("Відправлено на погодження!", "Успішно", MessageBoxIcon.Information);
                        else
                            ExtensionUtils.ShowInfoMessage("Не можливо відправити на погодження", "Помилка!", MessageBoxIcon.Error);
                    }
                        break;
                }
                if (result)
                    UpdateData?.Invoke();
            }
        }

        private void gvViewLicences_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "viewBtn":
                    var licId = (e.Row.DataBoundItem as LicenseAgreementBigRightView)?.LicId;
                    var viewLicenseForm = new RequestForm(_customer, _gridMainView, FormType.View, licId)
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    viewLicenseForm.ShowDialog();
                    break;
                case "printBtn":
                    var row = e.Row.DataBoundItem as LicenseAgreementBigRightView;
                    var licenseAgreement = _customer.Client.LicenseAgreement.SingleOrDefault(r => r.LicId == row?.LicId);
                    var print = new ViewAndPrintAgreement(_customer, licenseAgreement)
                    {
                        WindowState = FormWindowState.Maximized,
                        StartPosition = FormStartPosition.CenterScreen
                    };
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
