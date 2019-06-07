using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using LicenseForPlace = ipsFormsDesign.Model.License;

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight
{
    public partial class CabinetSmallRight : UserControl
    {
        private const string AcceptDeleteAgrMsg = "Ліцензія буде закрита та автоматично видалена. Підтвердити дію?";
        private const string AcceptDeleteTitle = "Підтвердження";
        private const string SuccessDeleteAgrMsg = "Ліцензію закрито та невдовзі буде видалено!";
        private const string ErrorDeleteAgrMsg = "Не можливо видалити ліцензію!";

        private const string ChangeLicenseStatusAcceptSuccess = "Ліцензійний договір переведено в статус \"Активний\"!";
        private const string ChangeLicenseStatusDenySuccess = "Ліцензійний договір переведено в статус \"Відхилений\"!";
        private const string ChangeLicenseStatusError = "Неможливо змінити статус ліцензійного договору!";

        private const string AgreementDataAuditWarning = "Неможливо змінити статус! Заповніть всі необхідні дані договору!";

        private const string LicenseCloseSuccess = "Ліцензію закрито!";
        private const string LicenseCloseError = "Неможливо закрити ліцензію!";
        private const string LicenseCloseQuestion = "Ліцензійний договір буде закритий та автоматично видалений. Підтвердити дію?";

        private const string ExistProlongationAgreement = "Версія договору для пролонгації вже існує! Відкрити для перегляду/редагування?";
        private const string ExistEditAgreement = "Змінена версія договору вже існує! Відкрити для перегляду/редагування?";

        private Customer _customer;
        private readonly AnketaDictionaties _dictionaties;
        private readonly AnketaConsumer _anketaConsumerJur;
        private readonly AnketaConsumerPhis _anketaConsumerPhis;

        public event SaveCustomerEventHandler SaveCustomer;
        public event UpdateCustomerDataEventHandler UpdateData;
        public event LicenseStatusChangeEventHandler OnChangeLicenseStatus;

        public event ReturnObjectEventHandler<Customer> GetPartner;
        public event SetPartnerEventHandler OnSetPartner;
        public event SetPartnerEventHandler OnRemovePartner;
        public event ChangePartnerEventHandler OnChangePartner;
        public event GetPartnerList OnGetPartnerListNeed;

        public event MiddleControlCabinetFiles.AddNewDocumentHandler OnAddNewFile;
        public event MiddleControlCabinetFiles.ViewDocumentHandler OnViewCurrentFile;
        public event ActionByIdDelegate OnDeleteCurrentFile;

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        /// <summary>
        /// Тип прав (великі або малі права)
        /// </summary>
        public TypeRights Rights { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CabinetSmallRight()
        {
            InitializeComponent();
            _anketaConsumerJur = new AnketaConsumer
            {
                Dock = DockStyle.Fill,
                TypeRights = TypeRights.SmallRights
            };
            _anketaConsumerPhis = new AnketaConsumerPhis
            {
                Dock = DockStyle.Fill,
            };

            pvMain.SelectedPage = pvAnketa;
            ctrlTabNavigation.SetDefaultState(null, FLoadType.Edit);
            ctrlTabNavigation.SaveClick += OnSaveCommentNeed;
            ctrlTabNavigation.CancelClick += UpdateCustomer;
            
            ctrlAgrDetailInfo.OnSaveCommentNeed += OnSaveCommentNeed;
            ctrlAgrDetailInfoMore.OnSaveCommentNeed += OnSaveCommentNeed;
            ctrlPartner.OnGetPartnerListNeed += CtrlPartner_OnGetPartnerListNeed;
            ctrlPartner.OnSetPartner += CtrlPartner_OnSetPartner;
            ctrlPartner.OnChangePartner += CtrlPartner_OnChangePartner;
            ctrlPartner.OnRemovePartner += CtrlPartner_OnRemovePartner;
            calculationCtrl.UpdateData += UpdateCustomer;
            ctrlFiles.UpdateData += UpdateCustomer;
            ctrlFiles.AddNewFile += AddNewFile;
            ctrlFiles.ViewCurrentFile += ViewCurrentFile;
            ctrlFiles.DeleteCurrentFile += DeleteCurrentFile;

            if (!IsDesignMode)
                _dictionaties = IpsGlobal.AnketaDictionaties;
        }

        private bool DeleteCurrentFile(int id)
        {
            return OnDeleteCurrentFile?.Invoke(id) ?? false;
        }

        private void ViewCurrentFile(int custId, int typeDocument, string fileName)
        {
            OnViewCurrentFile?.Invoke(custId, typeDocument, fileName);
        }

        private void AddNewFile(int custId, int typeDocument, string fileName, string comment)
        {
            OnAddNewFile?.Invoke(custId, typeDocument, fileName, comment);
        }

        // оновлдення даних
        private void UpdateCustomer()
        {
            UpdateData?.Invoke(_customer.CustId);
        }

        //присвоїти представника
        private bool CtrlPartner_OnSetPartner(int clientId, int partnerId)
        {
            var result = OnSetPartner?.Invoke(clientId, partnerId) ?? false;
            if(result)
                ctrlPartner.SetPartnerData(GetPartner?.Invoke(_customer.CustId), _customer.CustId);
            return result;
        }

        //змінити представника
        private bool CtrlPartner_OnChangePartner(int clientId, int partnerId, int oldPartnerId)
        {
            var result = OnChangePartner?.Invoke(clientId, partnerId, oldPartnerId) ?? false;
            if (result)
                ctrlPartner.SetPartnerData(GetPartner?.Invoke(_customer.CustId), _customer.CustId);
            return result;
        }

        //відкріптии представника
        private bool CtrlPartner_OnRemovePartner(int clientId, int partnerId)
        {
            var result = OnRemovePartner?.Invoke(clientId, partnerId) ?? false;
            if (result)
                ctrlPartner.SetPartnerData(GetPartner?.Invoke(_customer.CustId), _customer.CustId);
            return result;
        }

        private List<Customer> CtrlPartner_OnGetPartnerListNeed()
        {
            return OnGetPartnerListNeed?.Invoke();
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * //

        #region * * * PUBLIC METHODS * * *

        /// <summary>
        /// Встановлення даних
        /// </summary>
        /// <param name="customer"></param>
        public void SetCustomerData(Customer customer)
        {
            _customer = customer;
            anketaPanel.Controls.Clear();
            if (_customer.CustType == 3)
            {
                anketaPanel.Controls.Add(_anketaConsumerJur);
                _anketaConsumerJur.SetDataAndDictionaries(_customer);
                _anketaConsumerJur.InitializeControl(null, null, ConsumerAnketeType.EditAnketa);
            }
            else if (_customer.CustType == 1 || _customer.CustType == 2 )
            {
                anketaPanel.Controls.Add(_anketaConsumerPhis);
                _anketaConsumerPhis.SetData(_customer, ConsumerAnketeType.EditAnketa);
            }

            ctrlHeaderInfo.SetControlTextInfoSmallRight(_customer);
            SetLicenseAgrGridDataSource();
            SetLicenseAgrMoreGridDataSource();
            calculationCtrl.TypeRights = TypeRights.SmallRights;
            calculationCtrl.Customer = _customer;
            ctrlPaysInfo1.Customer = _customer;
            ctrlPartner.SetPartnerData(GetPartner?.Invoke(_customer.CustId), _customer.CustId);
            ctrlFiles.SetAndUpdateData(_customer);
            ctrlClosedAgreements.SetClosedLicenses(_customer);
        }

        #endregion

        //кнопка [Додати договір] (ОБИДВІ ВКЛАДКИ)
        private void btnAddAgreement_Click(object sender, EventArgs e)
        {
            _customer.Client.LicenseAgreement.Add(new LicenseAgreement
            {
                CustId = _customer.CustId,
                LicVersion = 1,
                LicStatus = 0,
                LicCode = Rights == TypeRights.SmallRights ? 1 : Rights == TypeRights.BigRights ? 10 : default(int),
                LicenseAgrParam = new ObservableListSource<LicenseAgrParam>
                {
                    new LicenseAgrParam
                    {
                        LicVersion = 1,
                        LicStatus = 0,
                    }
                },
                Agr = new AgreementMaster
                {
                    CustId = _customer.CustId,
                    AgrStatus = 0,
                    Version = 1,
                    AgrType = 2,
                }
            });
            var license = _customer?.Client?.LicenseAgreement?.LastOrDefault();
            var licenseParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);
            RunDialogForLicenseAgrParam(license, licenseParam, DialogGoal.forNew, true);
        }

        #region * * * ВКЛАДКА [АКТИВНІ ДОГОВОРИ] * * *

        // конструктор даних для грід
        private void SetLicenseAgrGridDataSource()
        {
            List<GridLicenseAgreementView> source = new List<GridLicenseAgreementView>();
            if (_customer?.Client.LicenseAgreement != null)
                foreach (var item in _customer.Client.LicenseAgreement.Where(rec => rec.LicStatus == 2 && rec.LicClass == 0))
                {
                    //якщо з малими правами, пропустити
                    if (Rights == TypeRights.BigRights && _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == item.LicCode)?.UsesKind != 1) continue;

                    var licenseParam = item.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == item.LicVersion);

                    source.Add(new GridLicenseAgreementView
                    {
                        Id = item.AgrId,
                        LicId = item.LicId,
                        License = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == item.LicCode)?.Name,
                        Series = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == item.LicCode)?.Series,
                        AgrNumber = licenseParam?.LicNum ?? string.Empty,
                        DateBegin = licenseParam?.DateBegin?.ToShortDateString() ?? string.Empty,
                        DateEnd = licenseParam?.DateEnd?.ToShortDateString() ?? string.Empty,
                        MinAmount = licenseParam?.MinAmount ?? default(decimal),
                        MinRate = licenseParam?.RateAmount ?? default(decimal),
                        State = _dictionaties.agreementStatus.SingleOrDefault(rec => rec.CodeI == licenseParam?.LicStatus)?.Name ?? string.Empty,
                        PeriodPayment = _dictionaties.period?.SingleOrDefault(p => p.CodeI == licenseParam?.PeriodCode)?.Name ?? string.Empty,
                        DateLastPayment = "",
                        LicenseAgreement = item,
                        IsAutoprolog = licenseParam?.IsAutoprolog ?? false,
                    });
                }

            bsGridLicenseAgreementView.DataSource = source;
            bsGridLicenseAgreementView.ResetBindings(false);
        }

        bool _inCurrentRowChanged = false;
        // при зміні рядка грід
        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (_inCurrentRowChanged) return;
            if (!(e?.CurrentRow?.DataBoundItem is GridLicenseAgreementView curRow))
            {
                ctrlAgrDetailInfo.ClearData();
                return;
            }
            _inCurrentRowChanged = true;
            SetAgrInfoData(curRow.LicId, GridCallMethod.ActiveAgreementGrid);
            currentAgreementController1?.ChangeCurrentLicenseAgreement(this, curRow.LicenseAgreement);
            _inCurrentRowChanged = false;

        }

        // кнопка [Пролонгувати договір]
        private void btnProlongation_Click(object sender, EventArgs e)
        {
            var licId = (gvLicenseAgr?.CurrentRow?.DataBoundItem as GridLicenseAgreementView)?.LicId;
            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.LicId == licId).SingleOrDefault();
            if (license == null)
                return;

            var prolongLicense = license.LicenseAgrParam.SingleOrDefault(rec => rec?.LicVersion == license.ProlongVersion);

            // Кількість доп угод з версією більшою за поточну > 0 //якщо є хоча б одна угода для пролонгації
            if (prolongLicense != null)
            {
                if(MessageShow.ConfirmAction(ExistProlongationAgreement) == DialogResult.Yes)
                    RunDialogForLicenseAgrParam(license, prolongLicense, DialogGoal.forExistProlongation, false);
            }
            // Інакше == 0
            else
            {
                // поточний договір
                var licParam = license.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);
                var licVersion = (license.LicenseAgrParam.Max(rec => rec?.LicVersion) ?? 0) + 1;

                // створити новий для
                var newProlongLicense = new LicenseAgrParam
                {
                    License = new ObservableListSource<LicenseForPlace>(),
                    LicVersion = licVersion,
                };

                newProlongLicense.SetFields(licParam, new []{ "LicDate", "DateBegin", "DateEnd", "LicVersion" });

                if (licParam?.DateEnd != null)
                {
                    newProlongLicense.LicDate = licParam.DateEnd.Value.AddDays(1);
                    newProlongLicense.DateBegin = licParam.DateEnd.Value.AddDays(1);
                    newProlongLicense.DateEnd = new DateTime(newProlongLicense.DateBegin.Value.Year, 12, 31);
                }

                if (licParam != null && licParam.License.Any())
                    SyncLicensePlaces(newProlongLicense.License, licParam.License, newProlongLicense.LicVersion);

                license.ProlongVersion = newProlongLicense.LicVersion;
                license.LicenseAgrParam?.Add(newProlongLicense);

                RunDialogForLicenseAgrParam(license, newProlongLicense, DialogGoal.forProlongation, true);
            }
        }

        // кнопка [Змінити договір]
        private void btnChangeAgreement_Click(object sender, EventArgs e)
        {
            var licId = (gvLicenseAgr.CurrentRow.DataBoundItem as GridLicenseAgreementView)?.LicId;
            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.LicId == licId).SingleOrDefault();

            if (license == null)
                return;

            // Кількість доп угод з версією більшою за поточну > 0
            var listDopAgr = license.LicenseAgrParam.Where(rec => rec.LicStatus < 4 && rec.LicVersion > license.LicVersion).ToList();

            var currentAgreement = listDopAgr.SingleOrDefault(rec => rec.LicVersion != license.ProlongVersion);

            if (currentAgreement != null)
            {
                if (MessageShow.ConfirmAction(ExistEditAgreement) == DialogResult.Yes)
                    RunDialogForLicenseAgrParam(license, currentAgreement, DialogGoal.forChange, false);
            }
            // Інакше == 0
            else
            {
                // поточна версія
                var licParam = license.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);

                // збільшити версію на 1
                int licVersion = (license.LicenseAgrParam.Max(rec => rec?.LicVersion) ?? 0) + 1;

                // створити нову
                var changeLicense = new LicenseAgrParam
                {
                    License = new ObservableListSource<LicenseForPlace>(),
                    LicDate = DateTime.Today,
                    DateBegin = DateTime.Today,
                    DateEnd = licParam?.DateEnd.EndYearDate(),
                    LicStatus = 0,
                    LicVersion = licVersion,
                };
                
                changeLicense.SetFields(licParam, new []{ "LicDate", "DateBegin", "DateEnd", "LicStatus", "LicVersion" });

                // синхронізувати ліцензії по бізнес-точках
                if (licParam != null && licParam.License.Any())
                    SyncLicensePlaces(changeLicense.License, licParam.License, changeLicense.LicVersion);
                 
                license.LicenseAgrParam?.Add(changeLicense);

                RunDialogForLicenseAgrParam(license, changeLicense, DialogGoal.forChange, true);
            }
        }

        /// <summary>
        /// Cинхронізувати ліцензії по бізнес-точкам
        /// </summary>
        /// <param name="destination">ліцензії нового договору</param>
        /// <param name="source">ліцензії існуючого договору</param>
        /// <param name="licVersion">версія нового договору</param>
        private void SyncLicensePlaces(ICollection<LicenseForPlace> destination, ICollection<LicenseForPlace> source, int licVersion)
        {
            foreach (var licPlace in source)
            {
                var lic = new LicenseForPlace
                {
                    LNum = "0" + (DateTime.Today.Year - 2000) + @"/" + (DateTime.Today.DayOfYear),
                    LDate = DateTime.Today,
                    LicVersion = licVersion
                };

                lic.SetFields(licPlace, new[] { "LId", "LNum", "LDate", "LicVersion" });

                destination.Add(lic);
            }
        }

        // кнопка [Закрити договір]
        private void btnCloseAgr_Click(object sender, EventArgs e)
        {
            if (!(gvLicenseAgr?.CurrentRow?.DataBoundItem is GridLicenseAgreementView curRow))
                return;

            var license = _customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec.LicId == curRow.LicId);
            if (license == null)
                return;

            if (MessageShow.ConfirmAction(LicenseCloseQuestion) == DialogResult.Yes)
            {
                var result = OnChangeLicenseStatus?.Invoke(license, license.LicVersion ?? default(int), 4, false) ?? false;
                if (result)
                    UpdateCustomer();
                
                MessageShow.ShowInfoByResult(LicenseCloseSuccess, LicenseCloseError, result);
            }
        }

        // кнопка [Друкувати договір]
        private void PrintAgreement(int licId)
        {
            var lic = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licId);
            var print = new ViewAndPrintAgreementForm(_customer,lic);
            print.ShowDialog();
        }

        #endregion

        // * * * * * * * * * * * * * * * * * * * * * * * * //

        #region * * * ВКЛАДКА [НЕ ПІДТВЕРДЖЕНІ ДОГОВОРИ] * * *
        
        // конструктор даних для грід
        private void SetLicenseAgrMoreGridDataSource()
        {
            List<GridLicenseAgreementView> source = new List<GridLicenseAgreementView>();
            if (_customer?.Client.LicenseAgreement != null)
            {
                foreach (var license in _customer.Client.LicenseAgreement.Where(rec => rec.LicStatus != 4 && rec.LicStatus != 9 && rec.LicClass == 0).ToList())
                {
                    if (license.LicenseAgrParam.Count == 1 && license.LicStatus == 2)
                        continue;

                    if (license.LicenseAgrParam.Count == 1 && license.LicStatus != 2)
                    {
                        var agrParam = license.LicenseAgrParam?.SingleOrDefault();
                        if(agrParam?.LicStatus == 10)
                            continue;
                        source.Add(new GridLicenseAgreementView
                        {
                            Id = license.AgrId,
                            LicVersion = agrParam?.LicVersion,
                            LicId = license.LicId,
                            License = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license.LicCode)?.Name,
                            Series = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == license.LicCode)?.Series,
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
                        if (agrParam.LicStatus != 10 && agrParam.LicVersion > license.LicVersion)
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
            }

            bsGridLicenseAgreementViewNoAccept.DataSource = source;
            bsGridLicenseAgreementViewNoAccept.ResetBindings(false);
        }

        // при зміні рядка грід
        private void gvMoreLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (!(e?.CurrentRow?.DataBoundItem is GridLicenseAgreementView curRow))
            {
                ctrlAgrDetailInfoMore.ClearData();
                btnAccept.Enabled = false;
                btnDenied.Enabled = false;
                return;
            }

            btnDenied.Enabled = curRow.Status == 1;
            btnAccept.Enabled = (curRow.Status == 0 || curRow.Status == 1);
            SetAgrInfoData(curRow.LicId, GridCallMethod.NotActiveAgreementGrid);
        }

        /// <summary>
        /// Змінити статусу договору
        /// </summary>
        /// <param name="status"></param>
        private void ChangeStatusAgreement(int status)
        {
            if (gvMoreLicenseAgr.CurrentRow.DataBoundItem is GridLicenseAgreementView item)
            {
                bool result = false;
                var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId);
                if(status == 2)
                {
                    result = OnChangeLicenseStatus?.Invoke(license, license?.LicenseAgrParam?.LastOrDefault()?.LicVersion ?? 0, status, true) ?? false;
                    MessageShow.ShowInfoByResult(ChangeLicenseStatusAcceptSuccess, ChangeLicenseStatusError, result);
                }
                else if(status == 5)
                {
                    result = OnChangeLicenseStatus?.Invoke(license, license?.LicenseAgrParam?.LastOrDefault()?.LicVersion ?? 0, status, false) ?? false;
                    MessageShow.ShowInfoByResult(ChangeLicenseStatusDenySuccess, ChangeLicenseStatusError, result);
                }
                if(result)
                    UpdateCustomer();
            }
        }

        // кнопка [Підтвердити договір]
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (AgreementDataAudit())
            {
                ChangeStatusAgreement(2);
                return;
            }
            MessageShow.ShowWarning(AgreementDataAuditWarning);
        }

        // кнопка [Відхилити договір]
        private void btnDenied_Click(object sender, EventArgs e)
        {
            ChangeStatusAgreement(5);
        }

        #endregion

        // * * * * * * * * * * * * * * * * * * * * * * * * //

        #region * * * PRIVATE METHODS * * * 
        
        /// <summary>
        /// Перевірка наявності необхідних даних ліцензійної угоди
        /// </summary>
        /// <returns>Результат перевірки: true - необхідні дані наявні; false - необхідні дані відсутні</returns>
        private bool AgreementDataAudit()
        {
            if (!(gvMoreLicenseAgr.CurrentRow.DataBoundItem is GridLicenseAgreementView item))
                return false;
            var license = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == item.LicId);
            var licParam = license?.LicenseAgrParam?.LastOrDefault();
            var success = !string.IsNullOrEmpty(licParam?.LicNum)
                          && licParam.LicDate != null
                          && licParam.DateBegin != null
                          && licParam.DateEnd != null
                          && licParam.PeriodCode != null
                          && licParam.MinAmount != null
                          && licParam.RateAmount != null;
            return success;
        }

        // кнопка на гріду [Видалити договір]
        private void ColumnDeleteClick()
        {
            if (!(gvMoreLicenseAgr?.CurrentRow?.DataBoundItem is GridLicenseAgreementView curRow)) return;
            var license = _customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec.LicId == curRow.LicId);
            if (license == null) return;

            if (MessageBox.Show(AcceptDeleteAgrMsg, AcceptDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                var result = OnChangeLicenseStatus?.Invoke(license, curRow.LicVersion ?? default(int), 10, false) ?? false;
                if (result)
                    UpdateCustomer();
                MessageShow.ShowInfoByResult(SuccessDeleteAgrMsg, ErrorDeleteAgrMsg, result);
            }
        }

        // кнопка [Редагувати договір]
        private void ColumnEditClick()
        {
            if (!(gvMoreLicenseAgr?.CurrentRow?.DataBoundItem is GridLicenseAgreementView curRow)) return;

            //поточна ліцензія
            var license = _customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec.LicId == curRow.LicId);
            if (license == null)
                return;

            //редагування нового
            if (license.LicenseAgrParam.Count == 1)
            {
                RunDialogForLicenseAgrParam(license, license.LicenseAgrParam.SingleOrDefault(), DialogGoal.forEdit, false);
                return;
            }

            var listDopAgr = license.LicenseAgrParam.Where(rec => rec.LicStatus < 4 && rec.LicVersion > license.LicVersion).ToList();
            //редагування зміненого
            if (listDopAgr.Any(rec => rec.LicVersion == curRow.LicVersion && rec.LicVersion != license.ProlongVersion))
            {
                var licAgrParam = listDopAgr.SingleOrDefault(rec => rec.LicVersion == curRow.LicVersion && rec.LicVersion != license.ProlongVersion);
                //var licAgrParam = license.LicenseAgrParam.Where(rec => rec.LicVersion > license.LicVersion).SingleOrDefault(rec => rec.LicVersion != license.ProlongVersion);
                RunDialogForLicenseAgrParam(license, licAgrParam, DialogGoal.forChange, false);
                return;
            }
            //редагування пролонгованого
            if (listDopAgr.Any(rec => rec.LicVersion == curRow.LicVersion && rec.LicVersion == license.ProlongVersion))
            {
                var licAgrParam = license.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.ProlongVersion);
                RunDialogForLicenseAgrParam(license, licAgrParam, DialogGoal.forProlongation, false);
            }
        }

        // оновити дані коли рядок на грід ліцензій змінено / Інформація по договору
        private void SetAgrInfoData(int? idItem, GridCallMethod methodType)
        {
            if (idItem == null) return;

            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.LicId == idItem).FirstOrDefault(rec => rec.LicStatus < 4);
            var licenseParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);
            switch (methodType)
            {
                case GridCallMethod.ActiveAgreementGrid:
                    ctrlAgrDetailInfo.SetDataInfo(licenseParam);
                    break;
                case GridCallMethod.NotActiveAgreementGrid:
                    ctrlAgrDetailInfoMore.SetDataInfo(licenseParam);
                    break;
            }
        }

        //збереження Customer
        private void OnSaveCommentNeed(object sender, EventArgs e)
        {
            var result = SaveCustomer?.Invoke(_customer) ?? false;
            if (result)
                UpdateCustomer();
            MessageShow.ShowInfoAfterChanges(result);
        }

        /// <summary>
        /// Виклик діалогової форми зміни/пролонгації договору
        /// </summary>
        /// <param name="license"></param>
        /// <param name="licenseParam"></param>
        /// <param name="goal"></param>
        /// <param name="isNewAgreement"></param>
        private void RunDialogForLicenseAgrParam(LicenseAgreement license, LicenseAgrParam licenseParam, DialogGoal goal, bool isNewAgreement)
        {
            var agreementForm = new AgreementActionsForm(licenseParam, license, _customer, goal, Rights)
            {
                Text = goal == DialogGoal.forEdit ? "Редагування договору"
                    : goal == DialogGoal.forProlongation ? "Пролонгація договору"
                    : goal == DialogGoal.forNew ? "Додавання нового договору"
                    : goal == DialogGoal.forExistProlongation ? "Перегляд/редагування пролонгованого договору"
                    : goal == DialogGoal.forChange || goal == DialogGoal.forExistChange ? "Внесення змін до активного договору"
                    : string.Empty,
                IsNewAgreement = isNewAgreement,
            };

            if (agreementForm.ShowDialog() == DialogResult.OK)
            {
                var result = SaveCustomer?.Invoke(_customer) ?? false;
                UpdateCustomer();
                MessageShow.ShowInfoAfterChanges(result);
            }
        }

        #endregion

        // * * * * * * * * * * * * * * * * * * * * * * * * //

        #region * * * ENUMS * * *

        /// <summary>
        /// Тип гріда, який викликає метод оновлення даних
        /// </summary>
        private enum GridCallMethod
        {
            /// <summary>
            /// Активні договори
            /// </summary>
            ActiveAgreementGrid,
            /// <summary>
            /// Не підтверджені договори
            /// </summary>
            NotActiveAgreementGrid
        }

        #endregion

        private void currentAgreementController1_CurrentLicenseAgreementChanged(object sender, LicenseAgreement e)
        {
            if (_inCurrentRowChanged) return;
            _inCurrentRowChanged = true;

            var row = gvLicenseAgr.Rows.FirstOrDefault(rec => (rec.DataBoundItem as GridLicenseAgreementView)?.LicId == e.LicId);
            if (row != null && row.IsCurrent != true)
                row.IsCurrent = true;

            _inCurrentRowChanged = false;
        }

        // грід не підтверджених договорів [кнопки]
        private void gvMoreLicenseAgr_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "printBtn":
                    int licId = (e?.Row?.DataBoundItem as GridLicenseAgreementView)?.LicId ?? 0;
                    PrintAgreement(licId);
                    break;
                case "editBtn":
                    ColumnEditClick();
                    break;
                case "deleteBtn":
                    ColumnDeleteClick();
                    break;
            }
        }

        // друк грід ліцензій
        private void gvLicenseAgr_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int licId = (e?.Row?.DataBoundItem as GridLicenseAgreementView)?.LicId ?? 0;
            PrintAgreement(licId);
        }
    }
}