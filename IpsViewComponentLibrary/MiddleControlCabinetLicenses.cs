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
using IpsViewComponentLibrary.ConsumerDialogForms;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetLicenses : UserControl
    {

        private Customer _customer;
        private AnketaDictionaties _dictionaties;
        public event LisenseStatusChangeEventHandler OnLicenseCloseAndDelete;
        public event SaveCustomerEventHandler OnSaveCustomer;
        private MainGridConsumerBigRightView _gridMainView;


        private ButtonFunctionType _functionType;
        private Dictionary<ButtonFunctionType, string> _btnDictionary = new Dictionary<ButtonFunctionType, string>{
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
        }

        public void SetDictionary(AnketaDictionaties dictionaties)
        {
            _dictionaties = dictionaties;
        }

        public void SetData(Customer customer, object sourceGrid)
        {
            _customer = customer;
            gvViewLicences.DataSource = sourceGrid;

        }

        private void gvViewLicences_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if(gvViewLicences.Rows.Count == 0 || e?.CurrentRow?.DataBoundItem == null)
            {
                ctrlAgrDetailInfo.ClearData();
                pageView.Enabled = false;
                return;
            }

            if (pageView.Enabled == false)
                pageView.Enabled = true;

            btnToProlongation.Enabled = (e.CurrentRow?.DataBoundItem as LicenseAgreementBigRightView)?.LicStatus == 2;

            var agrStatus = (e.CurrentRow?.DataBoundItem as LicenseAgreementBigRightView)?.LicStatus ?? -1;
            btnToAccept.Enabled = (agrStatus == 0 || agrStatus == 1);
            SetBtnFunc(agrStatus == 0 ? ButtonFunctionType.Agree : agrStatus == 1 ? ButtonFunctionType.Accept : ButtonFunctionType.None);
            //оновлення інфи
            if (!(e?.CurrentRow?.DataBoundItem is LicenseAgreementBigRightView lic)) return;
            var licAgrParam = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == lic.LicId)?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == lic.LicVersion);
            if(licAgrParam == null) return;
            ctrlAgrDetailInfo.SetDataInfo(licAgrParam, lic);
        }

        private void SetBtnFunc(ButtonFunctionType type)
        {
            _functionType = type;
            if(type != ButtonFunctionType.None)
            btnToAccept.Text = _btnDictionary[type];
        }

        #region FILTERING (пошук)

        private void gvViewConsumers_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            //пустий фільтер - всі дані
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvViewLicences.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvViewLicences.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }

                gvViewLicences.EndUpdate(false);
                return;
            }

            //фільтр не пустий
            gvViewLicences.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvViewLicences.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearch.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    e.Visible = true;
                    e.Row.Cells[i].Style.CustomizeFill = true;
                    e.Row.Cells[i].Style.DrawFill = true;
                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                }
                else
                {
                    e.Row.Cells[i].Style.Reset();
                }

                gvViewLicences.EndUpdate(false);
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvViewLicences.MasterTemplate.Refresh();
        }

        #endregion

        private void btnCloseAgr_Click(object sender, EventArgs e)
        {
            if (gvViewLicences?.CurrentRow?.DataBoundItem is LicenseAgreementBigRightView item)
            {
                if (MessageBox.Show("Ліцензія буде закрита та автоматично видалена. Підтвердити дію?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    if (OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 4, false) ?? false)
                        ExtensionUtils.ShowInfoMessage("Ліцензію закрито", "Успішно", MessageBoxIcon.Information);
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
                    ExtensionUtils.ShowInfoMessage("Ліцензійний договір пролонговано!","Успішно", MessageBoxIcon.Information);
                else
                    ExtensionUtils.ShowInfoMessage("Неможливо пролонгувати ліцензійний договір!", "Помилка", MessageBoxIcon.Error);
            }
        }

        // на підтвердження / акцептування
        private void btnToAccept_Click(object sender, EventArgs e)
        {
            if (gvViewLicences?.CurrentRow?.DataBoundItem is LicenseAgreementBigRightView item)
                switch (_functionType)
                {
                    case ButtonFunctionType.None:
                        break;
                    case ButtonFunctionType.Accept:
                    {
                        if (OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 0, false) ?? false)
                            ExtensionUtils.ShowInfoMessage("Акцептовано!", "Успішно", MessageBoxIcon.Information);
                        else
                            ExtensionUtils.ShowInfoMessage("Не можливо акцептувати", "Помилка!", MessageBoxIcon.Error);
                    }
                        break;
                    case ButtonFunctionType.Agree:
                    {
                        if (OnLicenseCloseAndDelete?.Invoke(_customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId), item.LicVersion, 3, false) ?? false)
                            ExtensionUtils.ShowInfoMessage("Відправлено на погодження!", "Успішно", MessageBoxIcon.Information);
                        else
                            ExtensionUtils.ShowInfoMessage("Не можливо відправити на погодження", "Помилка!", MessageBoxIcon.Error);
                    }
                        break;
                }
        }

        private void gvViewLicences_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var licId = (e.Row.DataBoundItem as LicenseAgreementBigRightView)?.LicId;
            RequestForm viewLicenseForm = new RequestForm(_customer, _gridMainView, _dictionaties, FormType.View, licId)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            viewLicenseForm.ShowDialog();
        }
    }
}
