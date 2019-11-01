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
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Common.Enums;
using IpsViewComponentLibrary.ConsumerControls.SmallRight.InternalModel;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight
{
    public sealed partial class LicenseAgreementNotActiveControl : UserControl
    {
        private const string ChangeLicenseStatusAcceptSuccess = "Ліцензійний договір переведено в статус \"Активний\"!";
        private const string ChangeLicenseStatusDenySuccess = "Ліцензійний договір переведено в статус \"Відхилений\"!";
        private const string ChangeLicenseStatusError = "Неможливо змінити статус ліцензійного договору!";

        private const string AgreementDataAuditWarning = "Неможливо змінити статус! Заповніть всі необхідні дані договору!";

        private const string AcceptDeleteAgrMsg = "Ліцензія буде закрита та автоматично видалена. Підтвердити дію?";
        private const string SuccessDeleteAgrMsg = "Ліцензію закрито та невдовзі буде видалено!";
        private const string ErrorDeleteAgrMsg = "Не можливо видалити ліцензію!";

        private readonly ConsumerAgreementService _agreementService;
        private readonly AnketaDictionaties _dictionaties;

        private Customer _customer;
        private ObservableListSource<LicenseAgreement> _licenseAgreements;

        public event Action UpdateDataNeed;

        private bool IsDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;

        public LicenseAgreementNotActiveControl()
        {
            InitializeComponent();

            ctrlAgrDetailInfoMore.OnSaveCommentNeed += SaveAgreementComment;

            if (!IsDesignMode)
            {
                _dictionaties = IpsGlobal.AnketaDictionaties;
                _agreementService = ConsumerAgreementService.GetInstance();
            }
        }

        /// <summary>
        /// Завантажити дані на control
        /// </summary>
        /// <param name="customer"></param>
        public void LoadData(Customer customer)
        {
            _customer = customer;
            _licenseAgreements = customer.Client.LicenseAgreement;

            if (_licenseAgreements.Any())
                ConvertToCurrentGridModel();
        }

        /// <summary>
        /// Перетворити список об'єктів БД для GridView
        /// </summary>
        private void ConvertToCurrentGridModel()
        {
            List<GridLicenseAgreementView> source = new List<GridLicenseAgreementView>();
            foreach (var license in _licenseAgreements.Where(rec => rec.LicStatus != 4 && rec.LicStatus != 9 && rec.LicClass == 0).ToList())
            {
                if (license.LicenseAgrParam.Count == 1 && license.LicStatus == 2)
                    continue;

                if (license.LicenseAgrParam.Count == 1 && license.LicStatus != 2)
                {
                    var agrParam = license.LicenseAgrParam?.SingleOrDefault();
                    if (agrParam?.LicStatus == 10)
                        continue;

                    var agrLicenseType = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license.LicCode);
                    source.Add(new GridLicenseAgreementView
                    {
                        Id = license.AgrId,
                        LicVersion = agrParam?.LicVersion,
                        LicId = license.LicId,
                        License = agrLicenseType?.Name,
                        Series = agrLicenseType?.Series,
                        SchemaId = agrLicenseType?.SchemaId,
                        MinAmount = agrParam?.MinAmount ?? default(decimal),
                        MinRate = agrParam?.RateAmount ?? default(decimal),
                        AgrNumber = agrParam?.LicNum ?? string.Empty,
                        AgrMasterNumber = license.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion)?.LicNum,
                        DateBegin = agrParam?.DateBegin?.ToShortDateString() ?? string.Empty,
                        DateEnd = agrParam?.DateEnd?.ToShortDateString() ?? string.Empty,
                        State = _dictionaties?.agreementStatus?.SingleOrDefault(rec => rec.CodeI == license.LicenseAgrParam?.SingleOrDefault()?.LicStatus)?.Name ?? string.Empty,
                        Status = agrParam?.LicStatus,
                        PeriodPayment = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == license.LicenseAgrParam?.SingleOrDefault()?.PeriodCode)?.Name ?? string.Empty,
                        IsAutoprolog = agrParam?.IsAutoprolog ?? false,

                    });
                    continue;
                }

                foreach (var agrParam in license.LicenseAgrParam)
                {
                    if (agrParam.LicStatus != 10 && (agrParam.LicVersion == license.ProlongVersion || agrParam.LicVersion > license.LicVersion))
                        source.Add(new GridLicenseAgreementView
                        {
                            Id = license.AgrId,
                            LicId = license.LicId,
                            LicVersion = agrParam.LicVersion,
                            License = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license.LicCode)?.Name,
                            Series = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license.LicCode)?.Series,
                            MinAmount = agrParam.MinAmount ?? default(decimal),
                            MinRate = agrParam.RateAmount ?? default(decimal),
                            AgrNumber = agrParam.LicNum ?? string.Empty,
                            AgrMasterNumber = license.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion)?.LicNum,
                            DateBegin = agrParam.DateBegin?.ToShortDateString() ?? string.Empty,
                            DateEnd = agrParam.DateEnd?.ToShortDateString() ?? string.Empty,
                            State = _dictionaties?.agreementStatus?.SingleOrDefault(rec => rec.CodeI == agrParam?.LicStatus)?.Name ?? string.Empty,
                            Status = agrParam.LicStatus,
                            PeriodPayment = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == agrParam?.PeriodCode)?.Name ?? string.Empty,
                            IsAutoprolog = agrParam.IsAutoprolog ?? false,
                        });
                }
            }

            bsGridLicenseAgreementViewNotActive.DataSource = source;
            bsGridLicenseAgreementViewNotActive.ResetBindings(false);
        }

        /// <summary>
        /// Зберегти примітку
        /// </summary>
        /// <param name="obj"></param>
        private void SaveAgreementComment(LicenseAgrParam obj)
        {
            var result = _agreementService.SaveAgreementComment(obj);
            MessageShow.ShowInfoAfterChanges(result);
        }

        /// <summary>
        /// Обробка зміни рядка GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvMoreLicenseAgr_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (!(e.CurrentRow?.DataBoundItem is GridLicenseAgreementView row))
            {
                ctrlAgrDetailInfoMore.ClearData();
                btnAccept.Enabled = false;
                btnDenied.Enabled = false;
                return;
            }

            btnDenied.Enabled = row.Status == 1;
            btnAccept.Enabled = row.Status == 0 || row.Status == 1;

            var license = _licenseAgreements?.Where(rec => rec.LicId == row.LicId).FirstOrDefault(rec => rec.LicStatus < 4);
            var licenseParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == row.LicVersion);

            ctrlAgrDetailInfoMore.SetDataInfo(licenseParam);
        }

        /// <summary>
        /// Обробка командних кнопок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void gvMoreLicenseAgr_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            // TODO: add async handler for print agreement
            switch (e.Column.FieldName)
            {
                case "printBtn":
                    // ReSharper disable once PossibleInvalidOperationException
                    int licId = (int)(e.Row?.DataBoundItem as GridLicenseAgreementView)?.LicId;
                    var licenseAgreement = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licId);
                    LicenseAgreementActions.GetInstance().PrintAgreement(_customer, licenseAgreement);
                    break;
                case "editBtn":
                    EditAgreement();
                    break;
                case "deleteBtn":
                    CloseLicenseAgreement();
                    break;
            }
        }

        /// <summary>
        /// Редагувати ліцензійний договір
        /// </summary>
        private void EditAgreement()
        {
            if (!(gvMoreLicenseAgr.CurrentRow?.DataBoundItem is GridLicenseAgreementView curRow))
                return;

            //поточна ліцензія
            var license = _customer.Client.LicenseAgreement?.SingleOrDefault(rec => rec.LicId == curRow.LicId);
            if (license == null)
                return;

            bool finded = false;
            LicenseAgrParam licenseAgrParam = null;

            // редагування нового
            if (license.LicenseAgrParam.Count == 1)
            {
                licenseAgrParam = license.LicenseAgrParam.SingleOrDefault();
                finded = true;
            }

            // редагування зміненого
            var listDopAgr = license.LicenseAgrParam.Where(rec => rec.LicStatus < 4 && rec.LicVersion > license.LicVersion).ToList();
            if (!finded && listDopAgr.Any(rec => rec.LicVersion == curRow.LicVersion && rec.LicVersion != license.ProlongVersion))
            {
                licenseAgrParam = listDopAgr.SingleOrDefault(rec => rec.LicVersion == curRow.LicVersion && rec.LicVersion != license.ProlongVersion);
                finded = true;
            }

            // редагування пролонгованого
            if (!finded && listDopAgr.Any(rec => rec.LicVersion == curRow.LicVersion && rec.LicVersion == license.ProlongVersion))
            {
                licenseAgrParam = license.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.ProlongVersion);
                finded = true;
            }

            if (!finded)
                return;

            var isOK = LicenseAgreementActions.GetInstance().EditLicenseAgreement(_customer, license, licenseAgrParam, AgreementModifyType.EditAgreementOrVersion);
            if (isOK)
            {
                var result = _agreementService.UpdateAgreement(licenseAgrParam);
                MessageShow.ShowInfoAfterChanges(result);
            }
            UpdateDataNeed?.Invoke();
        }

        /// <summary>
        /// Закрити (видалити через статус) ліцензіний договір
        /// </summary>
        private void CloseLicenseAgreement()
        {
            if (!(gvMoreLicenseAgr?.CurrentRow?.DataBoundItem is GridLicenseAgreementView row))
                return;

            if (MessageShow.ConfirmAction(AcceptDeleteAgrMsg) == DialogResult.Yes)
            {
                // ReSharper disable once PossibleInvalidOperationException
                var result = _agreementService.ChangeLicenseAgreementStatus(row.LicId, (int)row.LicVersion, 10, false);
                UpdateDataNeed?.Invoke();
                MessageShow.ShowInfoByResult(SuccessDeleteAgrMsg, ErrorDeleteAgrMsg, result);
            }
        }

        /// <summary>
        /// Додати ліцензійний договір
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewAgrMore_Click(object sender, EventArgs e)
        {
            var license = LicenseAgreementActions.GetInstance().CreateAgreement(_customer);
            if (license == null)
                return;

            var result = _agreementService.CreateAgreement(license);
            MessageShow.ShowInfoAfterChanges(result);
            UpdateDataNeed?.Invoke();
        }

        /// <summary>
        ///  Підтвердити ліцензійний договір
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (AgreementDataAudit())
            {
                ChangeStatusAgreement(2);
                return;
            }
            MessageShow.ShowWarning(AgreementDataAuditWarning);
        }

        /// <summary>
        /// Перевірка наявності необхідних даних ліцензійного договору
        /// </summary>
        /// <returns>Результат перевірки: true - необхідні дані наявні; false - необхідні дані відсутні</returns>
        private bool AgreementDataAudit()
        {
            if (!(gvMoreLicenseAgr.CurrentRow?.DataBoundItem is GridLicenseAgreementView item))
                return false;

            var schemaType = _dictionaties.schemaType.SingleOrDefault(rec => rec.CodeI == item.SchemaId);
            bool minAmountValid(LicenseAgrParam param)
            {
                bool minAmountWithoutValue = schemaType?.IsMinAmount == 0;

                if (minAmountWithoutValue)
                    param.MinAmount = 0;

                return minAmountWithoutValue || param.MinAmount.HasValue && param.MinAmount.Value > 0;
            }

            bool rateAmountValid(LicenseAgrParam param)
            {
                bool rateAmountWithoutValue = schemaType?.IsRateAmount == 0;

                if (rateAmountWithoutValue)
                    param.RateAmount = 0;

                return rateAmountWithoutValue || param.RateAmount.HasValue && param.RateAmount.Value > 0;
            }

            var license = _licenseAgreements.SingleOrDefault(rec => rec.LicId == item.LicId);
            var licParam = license?.LicenseAgrParam?.LastOrDefault();
            var success = !string.IsNullOrEmpty(licParam?.LicNum)
                          && licParam.LicDate.HasValue
                          && licParam.DateBegin.HasValue
                          && licParam.DateEnd.HasValue
                          && licParam.PeriodCode.HasValue
                          && minAmountValid(licParam)
                          && rateAmountValid(licParam);

            return success;
        }

        /// <summary>
        /// Відхилити ліцензійний договір
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDenied_Click(object sender, EventArgs e)
        {
            ChangeStatusAgreement(5);
        }

        /// <summary>
        /// Змінити статусу договору
        /// </summary>
        /// <param name="status"></param>
        private void ChangeStatusAgreement(int status)
        {
            if (!(gvMoreLicenseAgr.CurrentRow?.DataBoundItem is GridLicenseAgreementView item))
                return;

            bool result;

            if (status == 2)
            {

                // ReSharper disable once PossibleInvalidOperationException
                result = _agreementService.ChangeLicenseAgreementStatus(item.LicId, (int)item.LicVersion, status, true);
                MessageShow.ShowInfoByResult(ChangeLicenseStatusAcceptSuccess, ChangeLicenseStatusError, result);
            }
            else if (status == 5)
            {
                // ReSharper disable once PossibleInvalidOperationException
                result = _agreementService.ChangeLicenseAgreementStatus(item.LicId, (int)item.LicVersion, status, false);
                MessageShow.ShowInfoByResult(ChangeLicenseStatusDenySuccess, ChangeLicenseStatusError, result);
            }

            UpdateDataNeed?.Invoke();
        }
    }
}
