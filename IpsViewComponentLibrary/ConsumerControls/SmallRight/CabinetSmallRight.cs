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
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Common.Enums;
using IpsViewComponentLibrary.ConsumerControls.SmallRight.Enums;
using IpsViewComponentLibrary.ConsumerControls.SmallRight.InternalModel;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register;
using Telerik.WinControls.UI;
using LicenseForPlace = ipsFormsDesign.Model.License;

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight
{
    public partial class CabinetSmallRight : UserControl
    {
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

        private readonly ConsumerAgreementService _agreementService;

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

            RegisterControl registerControl = new RegisterControl();
            ehRegister.Child = registerControl;

            pvMain.SelectedPage = pvAnketa;
            ctrlTabNavigation.SetDefaultState(null, FLoadType.Edit);
            ctrlTabNavigation.SaveClick += OnSaveCommentNeed;
            ctrlTabNavigation.CancelClick += UpdateCustomer;

            ctrlLicenseAgreementNotActive.UpdateDataNeed += UpdateCustomer;

            ctrlAgrDetailInfo.OnSaveCommentNeed += CtrlAgrDetailInfo_OnSaveCommentNeed;
            //ctrlAgrDetailInfoMore.OnSaveCommentNeed += OnSaveCommentNeed;
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
            {
                _dictionaties = IpsGlobal.AnketaDictionaties;
                _agreementService = ConsumerAgreementService.GetInstance();
            }
        }

        private void CtrlAgrDetailInfo_OnSaveCommentNeed(LicenseAgrParam obj)
        {
            _agreementService.SaveAgreementComment(obj);
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

        #region * * * ПРЕДСТАВНИК * * *

        //присвоїти представника
        private bool CtrlPartner_OnSetPartner(int clientId, int partnerId)
        {
            var result = OnSetPartner?.Invoke(clientId, partnerId) ?? false;
            if (result)
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

        #endregion

        #region * * * PUBLIC METHODS * * *

        /// <summary>
        /// Встановлення даних
        /// </summary>
        /// <param name="customer"></param>
        public void SetCustomerData(Customer customer)
        {
            _customer = customer;
            ctrlLicenseAgreementNotActive.LoadData(customer);

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
            //SetLicenseAgrMoreGridDataSource();
            calculationCtrl.TypeRights = TypeRights.SmallRights;
            calculationCtrl.Customer = _customer;
            ctrlPaysInfo1.Customer = _customer;
            ctrlPartner.SetPartnerData(GetPartner?.Invoke(_customer.CustId), _customer.CustId);
            ctrlFiles.SetAndUpdateData(_customer);
            ctrlClosedAgreements.SetClosedLicenses(_customer);
        }

        #endregion

        //кнопка [Додати договір]
        private void btnAddAgreement_Click(object sender, EventArgs e)
        {
            var license = LicenseAgreementActions.GetInstance().CreateAgreement(_customer);
            if (license == null)
                return;

            var result = _agreementService.CreateAgreement(license);
            if(result)
                UpdateCustomer();
            MessageShow.ShowInfoAfterChanges(result);
        }

        #region * * * ВКЛАДКА [АКТИВНІ ДОГОВОРИ] * * *

        // конструктор даних для грід
        private void SetLicenseAgrGridDataSource()
        {
            List<GridLicenseAgreementView> source = new List<GridLicenseAgreementView>();
            if (_customer.Client.LicenseAgreement != null)
                foreach (var item in _customer.Client.LicenseAgreement.Where(rec => rec.LicStatus == 2 && rec.LicClass == 0))
                {
                    //якщо з малими правами, пропустити
                    if (Rights == TypeRights.BigRights && _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == item.LicCode)?.UsesKind != 1)
                        continue;

                    var licenseParam = item.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == item.LicVersion);

                    source.Add(new GridLicenseAgreementView
                    {
                        Id = item.AgrId,
                        LicId = item.LicId,
                        LicVersion = licenseParam.LicVersion,
                        License = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == item.LicCode)?.Name,
                        Series = _dictionaties.agrLicenseType.SingleOrDefault(rec => rec?.CodeI == item.LicCode)?.Series,
                        AgrNumber = licenseParam.LicNum ?? string.Empty,
                        DateBegin = licenseParam.DateBegin?.ToShortDateString() ?? string.Empty,
                        DateEnd = licenseParam.DateEnd?.ToShortDateString() ?? string.Empty,
                        MinAmount = licenseParam.MinAmount ?? default(decimal),
                        MinRate = licenseParam.RateAmount ?? default(decimal),
                        State = _dictionaties.agreementStatus.SingleOrDefault(rec => rec.CodeI == licenseParam.LicStatus)?.Name ?? string.Empty,
                        PeriodPayment = _dictionaties.period?.SingleOrDefault(p => p.CodeI == licenseParam.PeriodCode)?.Name ?? string.Empty,
                        DateLastPayment = "",
                        LicenseAgreement = item,
                        IsAutoprolog = licenseParam.IsAutoprolog ?? false,
                    });
                }

            bsGridLicenseAgreementView.DataSource = source;
            bsGridLicenseAgreementView.ResetBindings(false);
        }

        bool _inCurrentRowChanged = false;
        // при зміні рядка грід
        private void gvLicenseAgr_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (_inCurrentRowChanged) return;
            if (!(e?.CurrentRow?.DataBoundItem is GridLicenseAgreementView curRow))
            {
                ctrlAgrDetailInfo.ClearData();
                return;
            }
            _inCurrentRowChanged = true;
            
            var license = _customer?.Client?.LicenseAgreement?.Where(rec => rec.LicId == curRow.LicId).FirstOrDefault(rec => rec.LicStatus < 4);
            var licenseParam = license?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);
            ctrlAgrDetailInfo.SetDataInfo(licenseParam);

            currentAgreementController1?.ChangeCurrentLicenseAgreement(this, curRow.LicenseAgreement);
            _inCurrentRowChanged = false;
        }

        /// <summary>
        /// Пролонгувати ліцензійний договір
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if (MessageShow.ConfirmAction(ExistProlongationAgreement) == DialogResult.Yes)
                {
                    //RunDialogForLicenseAgrParam(license, prolongLicense, DialogGoal.forExistProlongation, false);

                    var isOK = LicenseAgreementActions.GetInstance().EditLicenseAgreement(_customer, license, prolongLicense, AgreementModifyType.EditAgreementProlongation);
                    if (isOK)
                    {
                        //var result = SaveCustomer?.Invoke(_customer) ?? false;
                        var result = _agreementService.UpdateAgreement(prolongLicense);
                        UpdateCustomer();
                        MessageShow.ShowInfoAfterChanges(result);
                    }
                }
            }
            else
            {
                // поточний договір
                var licParam = license.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == license.LicVersion);
                var licVersion = (license.LicenseAgrParam.Max(rec => rec?.LicVersion) ?? 0) + 1;

                // створити новий для
                var newProlongLicense = new LicenseAgrParam
                {
                    LicId = license.LicId,
                    License = new ObservableListSource<LicenseForPlace>(),
                    LicVersion = licVersion,
                };

                newProlongLicense.SetFields(licParam, new []{ "LicId", "LicDate", "DateBegin", "DateEnd", "LicVersion" });

                if (licParam?.DateEnd != null)
                {
                    newProlongLicense.LicDate = licParam.DateEnd.Value.AddDays(1);
                    newProlongLicense.DateBegin = licParam.DateEnd.Value.AddDays(1);
                    newProlongLicense.DateEnd = new DateTime(newProlongLicense.DateBegin.Value.Year, 12, 31);
                }

                if (licParam != null && licParam.License.Any())
                    SyncLicensePlaces(newProlongLicense.License, licParam.License, newProlongLicense.LicVersion);

                //license.ProlongVersion = newProlongLicense.LicVersion;
                //license.LicenseAgrParam.Add(newProlongLicense);
                
                //RunDialogForLicenseAgrParam(license, newProlongLicense, DialogGoal.forProlongation, true);
                var isOK = LicenseAgreementActions.GetInstance().EditLicenseAgreement(_customer, license, newProlongLicense, AgreementModifyType.CreateAgreementProlongation);
                if (isOK)
                {
                    //var result = SaveCustomer?.Invoke(_customer) ?? false;
                    var result = _agreementService.CreateAgreementVersion(newProlongLicense, true);
                    UpdateCustomer();
                    MessageShow.ShowInfoAfterChanges(result);
                }
            }
        }

        /// <summary>
        /// Змінити ліцензійний договір
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                {
                    //RunDialogForLicenseAgrParam(license, currentAgreement, DialogGoal.forChange, false);

                    var isOK = LicenseAgreementActions.GetInstance().EditLicenseAgreement(_customer, license, currentAgreement, AgreementModifyType.EditAgreementOrVersion);
                    if (isOK)
                    {
                        //var result = SaveCustomer?.Invoke(_customer) ?? false;
                        var result = _agreementService.UpdateAgreement(currentAgreement);
                        UpdateCustomer();
                        MessageShow.ShowInfoAfterChanges(result);
                    }
                }
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
                    LicId = license.LicId,
                    License = new ObservableListSource<LicenseForPlace>(),
                    LicDate = DateTime.Today,
                    DateBegin = DateTime.Today,
                    DateEnd = licParam?.DateEnd.EndYearDate(),
                    LicStatus = 0,
                    LicVersion = licVersion,
                };
                
                changeLicense.SetFields(licParam, new []{ "LicId", "LicDate", "DateBegin", "DateEnd", "LicStatus", "LicVersion" });

                // синхронізувати ліцензії по бізнес-точках
                if (licParam != null && licParam.License.Any())
                    SyncLicensePlaces(changeLicense.License, licParam.License, changeLicense.LicVersion);

                var isOK = LicenseAgreementActions.GetInstance().EditLicenseAgreement(_customer, license, changeLicense, AgreementModifyType.CreateAgreementVersion);
                if (isOK)
                {
                    //var result = SaveCustomer?.Invoke(_customer) ?? false;
                    var result = _agreementService.CreateAgreementVersion(changeLicense);
                    UpdateCustomer();
                    MessageShow.ShowInfoAfterChanges(result);
                }
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
            if (!(gvLicenseAgr?.CurrentRow?.DataBoundItem is GridLicenseAgreementView row))
                return;

            var license = _customer?.Client?.LicenseAgreement?.SingleOrDefault(rec => rec.LicId == row.LicId);
            if (license == null)
                return;

            if (MessageShow.ConfirmAction(LicenseCloseQuestion) == DialogResult.Yes)
            {
                //var result = OnChangeLicenseStatus?.Invoke(license, license.LicVersion ?? default(int), 4, false) ?? false;

                // ReSharper disable once PossibleInvalidOperationException
                var result = _agreementService.ChangeLicenseAgreementStatus(row.LicId, row.LicVersion.Value, 4, false);
                UpdateCustomer();
                MessageShow.ShowInfoByResult(LicenseCloseSuccess, LicenseCloseError, result);
            }
        }

        #endregion

        #region * * * PRIVATE METHODS * * * 

        //збереження Customer
        private void OnSaveCommentNeed(object sender, EventArgs e)
        {
            var result = SaveCustomer?.Invoke(_customer) ?? false;
            if (result)
                UpdateCustomer();
            MessageShow.ShowInfoAfterChanges(result);
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

        // друк грід ліцензій
        private void gvLicenseAgr_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            // ReSharper disable once PossibleInvalidOperationException
            int licId = (int)(e.Row?.DataBoundItem as GridLicenseAgreementView)?.LicId;
            var licenseAgreement = _customer.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == licId);
            LicenseAgreementActions.GetInstance().PrintAgreement(_customer, licenseAgreement);
        }
    }
}