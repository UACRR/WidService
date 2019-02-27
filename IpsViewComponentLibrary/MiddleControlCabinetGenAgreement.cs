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
using IpsViewComponentLibrary.ConsumerDialogForms;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetGenAgreement : UserControl
    {
        private const string ProlongAgr = "Пролонгація генерального договору";
        private const string EditAgr = "Редагування генерального договору";


        private Customer _customer;
        public event LisenseStatusChangeEventHandler OnLicStatusChange;
        public event SaveObjectByIdEventHandler<LicenseAgreement> GeneralAgreementSaveChanges;
        public event EmptyEventHandler UpdateData;


        public MiddleControlCabinetGenAgreement()
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
            //switch (e.Column.FieldName)

            //case "printBtn":
            var row = e.Row.DataBoundItem as GeneralAgreementBigRightView;
            var licenseAgreement = _customer.Client.LicenseAgreement.SingleOrDefault(r => r.LicId == row?.LicId);
            var print = new ViewAndPrintAgreement(_customer, licenseAgreement)
            {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen
            };
            print.ShowDialog();
        }

        #region * * * дії з генеральним договором * * *

        // кнопка підтвердити договір
        private void btnStatusAcceptGenAgr_Click(object sender, EventArgs e)
        {
            if (gvGenAgrLicences.CurrentRow.DataBoundItem is GeneralAgreementBigRightView licrow)
            {
                var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licrow?.LicId);
                OnLicStatusChange?.Invoke(license, licrow.Version, 2, false);
                UpdateData?.Invoke();
            }
        }

        // кнопка закрити генеральний договір
        private void btnStatusClosedGenAgr_Click(object sender, EventArgs e)
        {
            if (RadMessageBox.Show("Закрити генеральний договір?", "Підтвердження", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                if (gvGenAgrLicences.CurrentRow.DataBoundItem is GeneralAgreementBigRightView licrow)
                {
                    var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licrow?.LicId);
                    var result = OnLicStatusChange?.Invoke(license, licrow.Version, 4, false);
                    UpdateData?.Invoke();
                }
            }
        }

        // універсальний метод для редагування / пролонгації генерального догвору
        private bool? ChangeAgreement(string formName = null)
        {
            var id = (gvGenAgrLicences.CurrentRow.DataBoundItem as GeneralAgreementBigRightView)?.LicId;
            var version = (gvGenAgrLicences.CurrentRow.DataBoundItem as GeneralAgreementBigRightView)?.Version;

            var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == id);
            var agreementBr = license?.Agr.AgreementAddBr.SingleOrDefault(rec => rec.Version == version);
            var anketaComp = _customer?.Company?.AnketaCompany.SingleOrDefault(rec => rec.Version == _customer.AnkVersion);

            var agreementBrForm = new GeneralAgreementBrForm(IpsGlobal.AnketaDictionaties, agreementBr, formName)
            {
                StartPosition = FormStartPosition.CenterParent
            };
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
            var result = ChangeAgreement(ProlongAgr);
            if(result == null) return;
            if ((bool)result)
            {
                ExtensionUtils.ShowInfoMessage("Генеральний договір пролонговано!", "Успішно", MessageBoxIcon.Information);
                UpdateData?.Invoke();
            }
            else
                ExtensionUtils.ShowInfoMessage("Неможливо пролонгувати генеральний договір!", "Помилка", MessageBoxIcon.Error);
        }

        // кнопка змінити/редагувати договір
        private void btnEditGenAgr_Click(object sender, EventArgs e)
        {
            var result = ChangeAgreement(EditAgr);
            if (result == null) return;
            ExtensionUtils.ShowMessage((bool)result, MessageType.GeneralAgreementChange);
            UpdateData?.Invoke();
        }

        #endregion
    }
}
