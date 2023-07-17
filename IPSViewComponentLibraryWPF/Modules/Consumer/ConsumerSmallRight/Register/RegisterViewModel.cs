using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using IpsCommonTypes.Types;
using IPSComponentLibrary.Extensions;
using IPSComponentLibrary.Forms.Register;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Patterns.Notifier;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.ConsumerControls.Reports.Forms;
using IPSViewComponentLibraryWPF.IPSExtensions;
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.CurrencyChange;
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Model;
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.RegisterItemCCIDType;
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Utility;
using Telerik.Windows.Controls;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register
{
    public class RegisterViewModel : ViewModelBase, ISubscriber
    {
        private const string RegisterRatedListButtonContentFull = "Розрахунковий лист";
        private const string RegisterRatedListButtonContentShort = "Р/Л";

        private const string DifferentAmountsWarningMsg = "Сума авторської винагороди по Р/Л не співпадає з загальною сумою по введеним рапортичкам! Виконайте необхідні коригування суми!";
        private const string HasInvalidRegisterStatusWarningMsg = "Наявний звіт зі статусом «Новий» або «На погодженні»!";
        private const string HasInvalidRegisterStatusSchema3WarningMsg = "Всі звіти повинні бути в стані «Погоджено. Сконвертовано.» або «Синхронізація виконано. До розподілу.»!";
        private readonly TimeSpan MaxDurationUse = TimeSpan.FromSeconds(86399);

        private ConsumerRegisterService _service;

        public RegisterViewModel() {}

        #region * * * BEHAVIOR PROPERTIES * * *

        private XmlLanguage _language;
        public XmlLanguage Language
        {
            get
            {
                if (_language == null)
                    return XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);

                return _language;
            }
            set
            {
                _language = value;
                OnPropertyChanged(() => Language);
            }
        }

        private bool _isBusy;
        /// <summary>
        /// Changing state of busy indicator
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(() => IsBusy);
            }
        }

        // * * * фільтри -не реплізовано-
        private bool _licenseAgreementFilterEnabled;
        public bool LicenseAgreementFilterEnabled
        {
            get => _licenseAgreementFilterEnabled;
            set
            {
                _licenseAgreementFilterEnabled = value;
                LicenseAgreementFilterPanelVisibility = value ? Visibility.Visible : Visibility.Collapsed;
                OnPropertyChanged(() => LicenseAgreementFilterEnabled);
            }
        }

        private Visibility _licenseAgreementFilterPanelVisibility;
        public Visibility LicenseAgreementFilterPanelVisibility
        {
            get => _licenseAgreementFilterPanelVisibility;
            set
            {
                _licenseAgreementFilterPanelVisibility = value;
                OnPropertyChanged(() => LicenseAgreementFilterPanelVisibility);
            }
        }

        private bool _periodFilterEnabled;
        public bool PeriodFilterEnabled
        {
            get => _periodFilterEnabled;
            set
            {
                _periodFilterEnabled = value;
                PeriodFilterPanelVisibility = value ? Visibility.Visible : Visibility.Collapsed;
                OnPropertyChanged(() => PeriodFilterEnabled);
            }
        }

        private Visibility _periodFilterPanelVisibility;
        public Visibility PeriodFilterPanelVisibility
        {
            get => _periodFilterPanelVisibility;
            set
            {
                _periodFilterPanelVisibility = value;
                OnPropertyChanged(() => PeriodFilterPanelVisibility);
            }
        }

        // * * * * *

        private bool _isRegisterRatedList = true;
        /// <summary>
        /// Індикатор того, що звіти типу [рапотричка]
        /// </summary>
        public bool IsRegisterRatedList
        {
            get => _isRegisterRatedList;
            set
            {
                _isRegisterRatedList = value;
                OnPropertyChanged(() => IsRegisterRatedList);
            }
        }

        private bool _isEnabledGrid = true;
        public bool IsEnabledGrid
        {
            get => _isEnabledGrid;
            set
            {
                _isEnabledGrid = value;
                OnPropertyChanged(() => IsEnabledGrid);
            }
        }

        private Visibility _registerRatedListPanelVisible = Visibility.Visible;
        /// <summary>
        /// Видимість всієї панелі розрахункових листів (Р/Л)
        /// </summary>
        public Visibility RegisterRatedListPanelVisible
        {
            get => _registerRatedListPanelVisible;
            set
            {
                _registerRatedListPanelVisible = value;
                IsRegisterRatedList = value == Visibility.Visible;
                OnPropertyChanged(() => RegisterRatedListPanelVisible);
            }
        }

        private bool _registerRatedListReadOnly = true;
        public bool RegisterRatedListReadOnly
        {
            get => _registerRatedListReadOnly;
            set
            {
                _registerRatedListReadOnly = value;

                OnPropertyChanged(() => RegisterRatedListReadOnly);
            }
        }

        private bool _registerRatedListInfoButtonChecked = true;
        public bool RegisterRatedListInfoButtonChecked
        {
            get => _registerRatedListInfoButtonChecked;
            set
            {
                _registerRatedListInfoButtonChecked = value;
                RegisterRatedListInfoMinimize = value ? Visibility.Visible : Visibility.Collapsed;
                RegisterRatedListInfoButtonContent = value ? RegisterRatedListButtonContentFull : RegisterRatedListButtonContentShort;
                OnPropertyChanged(() => RegisterRatedListInfoButtonChecked);
            }
        }

        private Visibility _registerRatedListInfoMinimize = Visibility.Visible;
        public Visibility RegisterRatedListInfoMinimize
        {
            get => _registerRatedListInfoMinimize;
            set
            {
                _registerRatedListInfoMinimize = value;
                OnPropertyChanged(() => RegisterRatedListInfoMinimize);
            }
        }

        private string _registerRatedListInfoButtonContent = RegisterRatedListButtonContentFull;
        public string RegisterRatedListInfoButtonContent
        {
            get => _registerRatedListInfoButtonContent;
            set
            {
                _registerRatedListInfoButtonContent = value;
                OnPropertyChanged(() => RegisterRatedListInfoButtonContent);
            }
        }

        private Visibility _rrlCreateButtonVisibility;
        public Visibility RrlCreateButtonVisibility
        {
            get => _rrlCreateButtonVisibility;
            set
            {
                _rrlCreateButtonVisibility = value;
                OnPropertyChanged(() => RrlCreateButtonVisibility);
            }
        }

        private Visibility _rrlEditButtonVisibility;
        public Visibility RrlEditButtonVisibility
        {
            get => _rrlEditButtonVisibility;
            set
            {
                _rrlEditButtonVisibility = value;
                OnPropertyChanged(() => RrlEditButtonVisibility);
            }
        }

        private Visibility _rrlSaveButtonVisibility;
        public Visibility RrlSaveButtonVisibility
        {
            get => _rrlSaveButtonVisibility;
            set
            {
                _rrlSaveButtonVisibility = value;
                OnPropertyChanged(() => RrlSaveButtonVisibility);
            }
        }

        private Visibility _rrlCancelButtonVisibility;
        public Visibility RrlCancelButtonVisibility
        {
            get => _rrlCancelButtonVisibility;
            set
            {
                _rrlCancelButtonVisibility = value;
                OnPropertyChanged(() => RrlCancelButtonVisibility);
            }
        }

        private Visibility _createReportButtonsVisibility = Visibility.Visible;
        public Visibility CreateReportButtonsVisibility
        {
            get => _createReportButtonsVisibility;
            set
            {
                _createReportButtonsVisibility = value;
                OnPropertyChanged(() => CreateReportButtonsVisibility);
            }
        }

        private bool _currencyExchangeVisible = true;
        public bool CurrencyExchangeVisible
        {
            get => _currencyExchangeVisible;
            set
            {
                _currencyExchangeVisible = value;
                OnPropertyChanged(() => CurrencyExchangeVisible);
            }
        }

        private bool _removeRegisterVisible = true;
        public bool RemoveRegisterVisible
        {
            get => _removeRegisterVisible;
            set
            {
                _removeRegisterVisible = value;
                OnPropertyChanged(() => RemoveRegisterVisible);
            }
        }

        private bool _registerAmountVisible;
        public bool RegisterAmountVisible
        {
            get => _registerAmountVisible;
            set
            {
                _registerAmountVisible = value;
                OnPropertyChanged(() => RegisterAmountVisible);
            }
        }

        #endregion

        #region * * * DATA PROPERTIES * * *

        private ObservableCollection<RegisterLicenseAgreementModel> _licenseAgreementsItemSource;
        /// <summary>
        /// Список ліцензійних договорів (ліцензій)
        /// </summary>
        public ObservableCollection<RegisterLicenseAgreementModel> LicenseAgreementsItemSource
        {
            get => _licenseAgreementsItemSource;
            set
            {
                _licenseAgreementsItemSource = value;
                OnPropertyChanged(() => LicenseAgreementsItemSource);
            }
        }

        private RegisterLicenseAgreementModel _currentLicenseAgreement;
        /// <summary>
        /// Обрана із списку ліцеещія 
        /// </summary>
        public RegisterLicenseAgreementModel CurrentLicenseAgreement
        {
            get => _currentLicenseAgreement;
            set
            {
                _currentLicenseAgreement = value;
                CanExecuteCreatePeriodCommand = value != null;
                ChangeElementVisibleBySchemaType(value?.SchemaTypeId);
                UpdatePeriodList();
                OnPropertyChanged(() => CurrentLicenseAgreement);
            }
        }

        private ObservableCollection<RegisterPeriodModel> _periodsOfLicenseItemSource;
        /// <summary>
        /// Список періодів по обраній ліцензії
        /// </summary>
        public ObservableCollection<RegisterPeriodModel> PeriodsOfLicenseItemSource
        {
            get => _periodsOfLicenseItemSource;
            set
            {
                _periodsOfLicenseItemSource = value;
                OnPropertyChanged(() => PeriodsOfLicenseItemSource);
            }
        }

        private RegisterPeriodModel _currentPeriodOfLicense;
        /// <summary>
        /// Обраний із списку період
        /// </summary>
        public RegisterPeriodModel CurrentPeriodOfLicense
        {
            get => _currentPeriodOfLicense;
            set
            {
                _currentPeriodOfLicense = value;
                var rrl = value?.PaidPeriod?.RegisterRatedList.FirstOrDefault();
                if (rrl == null)
                {
                    RegisterRatedList = null;
                }
                else
                {
                    RegisterRatedList = new RegisterRatedListModel
                    {
                        RegisterRatedList = rrl,
                    };
                }

                // PeriodStatus
                // 1	Прийом звітів
                // 3	Борг
                var validPeriodStatuses = new int[] {1, 3};
                CanExecuteCreateRegisterFromFileCommand = value != null && validPeriodStatuses.Contains(value.PeriodStatus) && CurrentLicenseAgreement.SchemaTypeId == 1;
                CanExecuteCreateRegisterManuallyCommand = value != null && validPeriodStatuses.Contains(value.PeriodStatus);
                CanExecuteFixingRegisterListCommand = value != null && CheckCanFixingRegisterList(value);

                OnPropertyChanged(() => CurrentPeriodOfLicense);
            }
        }

        private RegisterRatedListModel _registerRatedList;
        /// <summary>
        /// Розрахунковий лист періода для звітів
        /// </summary>
        public RegisterRatedListModel RegisterRatedList
        {
            get => _registerRatedList;
            set
            {
                if (!IsCreateRegisterRated)
                {
                    RrlCreateButtonVisibility = value == null ? Visibility.Visible : Visibility.Collapsed;
                    RrlEditButtonVisibility = value != null ? Visibility.Visible : Visibility.Collapsed;
                }

                _registerRatedList = value;
                UpdateRegisterList();
                OnPropertyChanged(() => RegisterRatedList);
            }
        }

        private ObservableCollection<RegisterModel> _registersItemSource;
        /// <summary>
        /// Список звітів обраного періода
        /// </summary>
        public ObservableCollection<RegisterModel> RegistersItemSource
        {
            get => _registersItemSource;
            set
            {
                _registersItemSource = value;
                OnPropertyChanged(() => RegistersItemSource);
            }
        }

        private RegisterModel _currentRegister;
        public RegisterModel CurrentRegister
        {
            get => _currentRegister;
            set
            {
                _currentRegister = value;

                // RegisterStatus
                // 0	Новий
                // 5	Відхилено
                CanExecuteSendRegisterToAcceptCommand = value != null && (value.Register.RgStatus == 0 || value.Register.RgStatus == 5);

                OnPropertyChanged(() => CurrentRegister);
            }
        }

        #endregion

        #region * * * METHODS * * *

        /// <summary>
        /// Завантажити дані з серверу
        /// </summary>
        private async Task LoadData()
        {
            var customer = ApplicationCustomerData.GetInstance().CurrentCustomer;
            if (customer == null)
            {
                ClearData();
                return;
            }

            var list = new ObservableCollection<RegisterLicenseAgreementModel>();

            IsBusy = true;
            var resultList = await _service.GetLicenseAgreementList(customer.CustId);

            foreach (var item in resultList)
            {
                list.Add(new RegisterLicenseAgreementModel
                {
                    LicenseAgreement = item,
                });
            }

            LicenseAgreementsItemSource = list;

            IsBusy = false;
        }

        /// <summary>
        /// Оновити дані після внесених змін та відновити стан
        /// </summary>
        private async void UpdateData()
        {
            var saveCurrentLicense = CurrentLicenseAgreement.LicId;
            var saveCurrentPeriodOfLicense = CurrentPeriodOfLicense?.PeriodId;
            var saveCurrentRegister = CurrentRegister?.RegId;

            var customer = ApplicationCustomerData.GetInstance().CurrentCustomer;
            if (customer == null)
            {
                ClearData();
                return;
            }

            var list = new ObservableCollection<RegisterLicenseAgreementModel>();

            IsBusy = true;
            var resultList = await _service.GetLicenseAgreementList(customer.CustId);

            foreach (var item in resultList)
            {
                list.Add(new RegisterLicenseAgreementModel
                {
                    LicenseAgreement = item,
                });
            }

            LicenseAgreementsItemSource = list;

            IsBusy = false;

            var license = LicenseAgreementsItemSource.SingleOrDefault(rec => rec.LicId == saveCurrentLicense);
            CurrentLicenseAgreement = license;

            var period = PeriodsOfLicenseItemSource.SingleOrDefault(rec => rec.PeriodId == saveCurrentPeriodOfLicense);
            CurrentPeriodOfLicense = period;

            if (RegistersItemSource.Any())
            {
                var register = RegistersItemSource.SingleOrDefault(rec => rec.RegId == saveCurrentRegister);
                // якщо не видалений
                if (register != null)
                    CurrentRegister = register;
            }
        }

        /// <summary>
        /// Очистити дані
        /// </summary>
        private void ClearData()
        {
            //CurrentPeriodOfLicense = null;
            //CurrentLicenseAgreement = null;
            RegistersItemSource = null;
            PeriodsOfLicenseItemSource = null;
            LicenseAgreementsItemSource = null;
        }

        public void UpdateOnNotified()
        {
            Task.Factory.StartNew(() => LoadData());
        }

        /// <summary>
        /// Оновити список періодів по обраній ліцензії
        /// </summary>
        private void UpdatePeriodList()
        {
            var periodList = new List<RegisterPeriodModel>();

            if (CurrentLicenseAgreement?.LicenseAgreement?.PaidPeriod != null)
            {
                foreach (var period in GetPeriodList())
                {
                    periodList.Add(new RegisterPeriodModel
                    {
                        PaidPeriod = period,
                    });
                }
            }
            var result = new ObservableCollection<RegisterPeriodModel>(periodList.OrderBy(rec => rec.BeginDate).ToList());
            PeriodsOfLicenseItemSource = result;
        }

        /// <summary>
        /// Отримати колекцію об'єктів періодів залежно від властивості сортування
        /// </summary>
        /// <returns></returns>
        private IList<PaidPeriod> GetPeriodList()
        {
            if (PeriodsOfLicenseSorting == null)
                return CurrentLicenseAgreement.LicenseAgreement.PaidPeriod;

            Func<PaidPeriod, object> expression = null;

            PaidPeriod p = new PaidPeriod();

            switch (PeriodsOfLicenseSorting.ProperyName)
            {
                case nameof(p.PeriodId):
                    expression = a => a.PeriodId;
                    break;

                case nameof(p.PeriodName):
                    expression = a => a.PeriodName;
                    break;

                case "PeriodStatusName":
                    expression = a => a.Status;
                    break;

                case nameof(p.Amount):
                    expression = a => a.Amount;
                    break;

                case nameof(p.Distribamount):
                    expression = a => a.Distribamount;
                    break;

                case nameof(p.BeginDate):
                    expression = a => a.BeginDate;
                    break;

                case nameof(p.EndDate):
                    expression = a => a.EndDate;
                    break;
            }

            if (expression == null)
                return CurrentLicenseAgreement.LicenseAgreement.PaidPeriod;

            if (PeriodsOfLicenseSorting.SortingState == SortingState.Ascending)
                return CurrentLicenseAgreement.LicenseAgreement.PaidPeriod.OrderBy(expression).ToList();

            if (PeriodsOfLicenseSorting.SortingState == SortingState.Descending)
                return CurrentLicenseAgreement.LicenseAgreement.PaidPeriod.OrderByDescending(expression).ToList();

            return CurrentLicenseAgreement.LicenseAgreement.PaidPeriod;
        }

        /// <summary>
        /// Оновити список звітів по обраному періоду
        /// </summary>
        private void UpdateRegisterList()
        {
            var registerList = new ObservableCollection<RegisterModel>();

            if (RegisterRatedList?.RegisterRatedList != null)
            {
                foreach (var register in RegisterRatedList?.RegisterRatedList.Register)
                {
                    registerList.Add(new RegisterModel
                    {
                        Register = register,
                    });
                }
            }

            RegistersItemSource = registerList;
        }

        #region * зміна відображення компонентів по SchemaType *

        /// <summary>
        /// Змінити вигляд відображених елементів залежно від схеми звітів
        /// </summary>
        /// <param name="schemaType"></param>
        private void ChangeElementVisibleBySchemaType(int? schemaType)
        {
            switch (schemaType)
            {
                case null:
                case 1:
                    SwitchToDefaultReportType();
                    break;
                case 2:
                    SwitchToRRLReportType();
                    break;
                case 3:
                    SwitchToExternalReportType();
                    break;

            }
        }

        private void SwitchToDefaultReportType()
        {
            IsRegisterRatedList = false;
            RegisterRatedListPanelVisible = Visibility.Collapsed;
            CreateReportButtonsVisibility = Visibility.Visible;
            CurrencyExchangeVisible = false;
            RemoveRegisterVisible = true;
            RegisterAmountVisible = false;
        }

        private void SwitchToRRLReportType()
        {
            IsRegisterRatedList = true;
            RegisterRatedListPanelVisible = Visibility.Visible;
            CreateReportButtonsVisibility = Visibility.Visible;
            CurrencyExchangeVisible = false;
            RemoveRegisterVisible = true;
            RegisterAmountVisible = false;
        }

        private void SwitchToExternalReportType()
        {
            IsRegisterRatedList = false;
            RegisterRatedListPanelVisible = Visibility.Collapsed;
            CreateReportButtonsVisibility = Visibility.Collapsed;
            CurrencyExchangeVisible = true;
            RemoveRegisterVisible = false;
            RegisterAmountVisible = true;
        }

        #endregion

        /// <summary>
        /// Перевірити навність необхідних даних для активації кнопки фіксації перекілку звітів
        /// </summary>
        /// <param name="periodModel"></param>
        /// <returns></returns>
        private bool CheckCanFixingRegisterList(RegisterPeriodModel periodModel)
        {
            var registerRatedList = periodModel.PaidPeriod?.RegisterRatedList?.SingleOrDefault();

            bool rrlValid = registerRatedList != null;
            if (!rrlValid)
                return false;

            bool hasRegister = registerRatedList.Register.Any();
            if (!hasRegister)
                return false;



            return true;
        }

        #region * фіксація переліку звітів * 

        /// <summary>
        /// Перевірити дані для фіксації переліку звітів
        /// </summary>
        /// <returns></returns>
        private bool ValidateFixingRegisterList()
        {
            switch (CurrentLicenseAgreement.SchemaTypeId)
            {
                case 1: return ValidateDefaultReportType();
                case 2: return ValidateRrlReportType();
                case 3: return ValidateExternalReportType();
            }

            return false;
        }

        private bool ValidateDefaultReportType()
        {
            if (!RegisterRatedList.RegisterRatedList.Register.Any(rec => rec.RgStatus < 2))
                return true;

            ShowMessage.ShowWarning(HasInvalidRegisterStatusWarningMsg);
            return false;
        }

        private bool ValidateRrlReportType()
        {
            var amounrRatedList = RegisterRatedList.Amount;
            var registersAmount = RegisterRatedList.RegisterRatedList.Register.Sum(rec => rec.RegAmount);
            
            if (amounrRatedList == registersAmount)
                return true;
            
            ShowMessage.ShowWarning(DifferentAmountsWarningMsg); 
            return false;
        }

        private bool ValidateExternalReportType()
        {
            // RegisterStatus
            // 7    Синхронізація виконано. До розподілу.
            // 12   Погоджено.Сконвертовано
            // 13   Розполділ розраховано
            int?[] validStatus = {7, 12, 13};
            bool hasInvalidStatus = RegisterRatedList.RegisterRatedList.Register.Any(rec => !validStatus.Contains(rec.RgStatus));

            if (!hasInvalidStatus)
                return true;

            ShowMessage.ShowWarning(HasInvalidRegisterStatusSchema3WarningMsg);
            return false;
        }

        #endregion

        #region * перегляд/редагування звіту *

        /// <summary>
        /// Запустити форму перегляду вмісту звіту
        /// </summary>
        private void ShowRegisterItemData()
        {
            switch (CurrentLicenseAgreement.SchemaTypeId)
            {
                case 1: ShowItemDataDefaultType();
                    return;
                
                case 2: ShowItemDataRrlType();
                    return;
                
                case 3: ShowItemDataCCIDType();
                    return;
            }
        }

        /// <summary>
        /// Звіт звичайного типу
        /// </summary>
        private async void ShowItemDataDefaultType()
        {
            IsBusy = true;
            var items = await _service.GetDefaultRegisterItems(CurrentRegister.Register);
            IsBusy = false;

            CurrentRegister.Register.RegisterItem.Clear();
            items.ForEach(item =>
            {
                if (item.DurationItem.HasValue && item.CountUse.HasValue)
                    item.DurationUse = TimeSpan.FromSeconds(item.DurationItem.Value.TotalSeconds * item.CountUse.Value);
                
                CurrentRegister.Register.RegisterItem.Add(item);
            });

            bool isEdit = CurrentRegister.Register.RgStatus == 0 || CurrentRegister.Register.RgStatus == 5;

            var registerExcelTypeForm = new ReportExcelForm(CurrentRegister.Register, isEdit);
            if (registerExcelTypeForm.ShowDialog() == DialogResult.OK)
            {
                TrimDurations(CurrentRegister.Register.RegisterItem);
                var result = await _service.UpdateRegister(CurrentRegister.Register);
                ShowMessage.ShowInfoByResult(result.Message, result.IsSuccess);
            }

            if (!registerExcelTypeForm.IsDisposed)
                registerExcelTypeForm.Dispose();

            UpdateData();
        }

        private void TrimDurations(ICollection<RegisterItem> items)
        {
            foreach (var item in items)
            {
                if (item.DurationUse.HasValue && item.DurationUse > MaxDurationUse)
                    item.DurationUse = MaxDurationUse;
            }
        }

        /// <summary>
        /// Звіт - рапртичка
        /// </summary>
        private async void ShowItemDataRrlType()
        {
            IsBusy = true;
            var items = await _service.GetDefaultRegisterItems(CurrentRegister.Register);
            IsBusy = false;

            CurrentRegister.Register.RegisterItem.Clear();
            items.ForEach(item => CurrentRegister.Register.RegisterItem.Add(item));

            bool isEdit = CurrentRegister.Register.RgStatus == 0 || CurrentRegister.Register.RgStatus == 5;

            var registerRrlTypeForm = new ReportExtendedForm(CurrentRegister.Register, isEdit)
            {
                HeaderInfoCustomerName = ApplicationCustomerData.GetInstance().CustomerName,
                HeaderInfoLicenseNumberString = CurrentLicenseAgreement.AgrNumber,
                HeaderInfoPeriodName = CurrentPeriodOfLicense.PeriodName,
                HeaderInfoRatedListNumber = RegisterRatedList?.RmId.ToString()
            };

            if (registerRrlTypeForm.ShowDialog() == DialogResult.OK)
            {
                var result = await _service.UpdateRegister(CurrentRegister.Register);
                ShowMessage.ShowInfoByResult(result.Message, result.IsSuccess);
            }

            if (!registerRrlTypeForm.IsDisposed)
                registerRrlTypeForm.Dispose();

            UpdateData();
        }

        /// <summary>
        /// Звіт CCID типу
        /// </summary>
        private async void ShowItemDataCCIDType()
        {
            IsBusy = true;
            var items = await _service.GetCCIDRegisterItems(CurrentRegister.Register);
            RegisterItemCCIDWindow window = new RegisterItemCCIDWindow(items, CurrentRegister.FileName);
            IsBusy = false;
            window.ShowDialog();
        }

        #endregion

        /// <summary>
        /// Створити шаблон нового звіту
        /// </summary>
        /// <returns></returns>
        private ipsFormsDesign.Model.Register GetRegisterTemplate()
        {
            string identityName = new WindowsPrincipal(WindowsIdentity.GetCurrent()).Identity?.Name;

            RegisterRatedList tempRegisterRatedList;

            if (CurrentPeriodOfLicense.PaidPeriod.RegisterRatedList.Any())
            {
                tempRegisterRatedList = CurrentPeriodOfLicense.PaidPeriod.RegisterRatedList.First();
            }
            else
            {
                // RegisterRatedList is empty, create
                tempRegisterRatedList = new RegisterRatedList
                {
                    PeriodId = CurrentPeriodOfLicense.PeriodId,
                    UserId = identityName,
                    Status = 0
                };
            }


            //об'єкт звіт
            var register = new ipsFormsDesign.Model.Register
            {
                RgStatus = 0,
                FileName = string.Empty,
                CustId = CurrentLicenseAgreement.CustId,
                LicId = CurrentPeriodOfLicense.LicId,
                AlgorithmId = CurrentLicenseAgreement.AlgorithmId,
                PeriodId = CurrentPeriodOfLicense.PeriodId,
                SchemaId = CurrentLicenseAgreement.SchemaTypeId,
                UserId = identityName,

                Rm = tempRegisterRatedList,
                RmId = tempRegisterRatedList.RmId,
            };

            return register;
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadDataCommand => new IPSDelegateCommand(LoadDataCommandExecute);
        private async void LoadDataCommandExecute(object o)
        {
            Language = XmlLanguage.GetLanguage(ApplicationSettings.GetInstance().ApplicationCulture.Name);

            ApplicationCustomerData.GetInstance().Subscribe(this);
            _service = ConsumerRegisterService.GetInstance();

            RrlCreateButtonVisibility = Visibility.Collapsed;
            RrlEditButtonVisibility = Visibility.Collapsed;
            RrlSaveButtonVisibility = Visibility.Collapsed;
            RrlCancelButtonVisibility = Visibility.Collapsed;

            await LoadData();
        }

        public ICommand EditPeriodCommand => new IPSDelegateCommand(EditPeriodCommandExecute);
        private void EditPeriodCommandExecute(object o)
        {
            if (!(o is RegisterPeriodModel item))
                return;

            EditPaidPeriod.EditPaidPeriod window = new EditPaidPeriod.EditPaidPeriod(item.PaidPeriod);
            window.ShowDialog();
            UpdateData();
        }

        public ICommand DeletePeriodCommand => new IPSDelegateCommand(DeletePeriodCommandExecute);
        private async void DeletePeriodCommandExecute(object o)
        {
            if (!(o is RegisterPeriodModel item))
                return;

            var confirm = MessageShow.ConfirmAction($"Видалити період [ID:{item.PeriodId}] '{item.PeriodName}'?");
            if (confirm == DialogResult.Yes)
            {
                ResponseOfRequest result = await _service.DeletePaidPeriod(item.PeriodId);
                MessageShow.ShowInfoByResult(result);
                UpdateData();
            }
        }

        /// <summary>
        /// Створити період до обраної ліцензії
        /// </summary>
        public ICommand CreatePeriodCommand => new IPSDelegateCommand(CreatePeriodCommandExecute, (o) => CanExecuteCreatePeriodCommand);
        private void CreatePeriodCommandExecute(object o)
        {
            var agrLicenseType = IpsGlobal.AnketaDictionaties.agrLicenseType.Single(rec => rec.CodeI == CurrentLicenseAgreement.LicenseAgreement.LicCode);
            CurrentLicenseAgreement.LicenseAgreement.LicCodeNavigation = agrLicenseType;

            var window = new CreatePaidPeriod.CreatePaidPeriod(CurrentLicenseAgreement.LicenseAgreement);
            if (window.IsDataValid)
                window.ShowDialog();

            UpdateData();
        }

        public bool CanExecuteCreatePeriodCommand { get; set; }

        /// <summary>
        /// Режим створення розрахункового листа для періода
        /// </summary>
        public ICommand CreateRegisterRatedListCommand => new IPSDelegateCommand(CreateRegisterRatedListCommandExecute);
        private void CreateRegisterRatedListCommandExecute(object o)
        {
            IsCreateRegisterRated = true;
            RrlCreateButtonVisibility = Visibility.Collapsed;
            RrlSaveButtonVisibility = Visibility.Visible;
            RrlCancelButtonVisibility= Visibility.Visible;
            RegisterRatedListReadOnly = false;
            IsEnabledGrid = false;

            TempRegisterRatedList = new RegisterRatedList
            {
                PeriodId = CurrentPeriodOfLicense.PeriodId,
            };

            RegisterRatedList = new RegisterRatedListModel
            {
                RegisterRatedList = TempRegisterRatedList,
            };
        }

        /// <summary>
        /// Режим редагування розрахункового листа для періода
        /// </summary>
        public ICommand EditRegisterRatedListCommand => new IPSDelegateCommand(EditRegisterRatedListCommandExecute);
        private void EditRegisterRatedListCommandExecute(object o)
        {
            RrlEditButtonVisibility = Visibility.Collapsed;
            RrlSaveButtonVisibility = Visibility.Visible;
            RrlCancelButtonVisibility = Visibility.Visible;
            RegisterRatedListReadOnly = false;
            IsEnabledGrid = false;
        }

        /// <summary>
        /// Зберегти створений/змінений розрахунковий лист
        /// </summary>
        public ICommand SaveRegisterRatedListCommand => new IPSDelegateCommand(SaveRegisterRatedListCommandExecute);
        private async void SaveRegisterRatedListCommandExecute(object o)
        {
            RegisterRatedListReadOnly = true;
            RegisterRatedList.UpdateData();

            ResponseOfRequest result;
            
            if (IsCreateRegisterRated)
                result = await _service.CreateRegisterRatedList(RegisterRatedList.RegisterRatedList);
            else
                result = await _service.UpdateRegisterRatedList(RegisterRatedList.RegisterRatedList);

            IsCreateRegisterRated = false;
            IsEnabledGrid = true;
            RrlSaveButtonVisibility = Visibility.Collapsed;
            RrlCancelButtonVisibility = Visibility.Collapsed;
            MessageShow.ShowInfoByResult(result.Message, result.IsSuccess);
            UpdateData();
        }

        /// <summary>
        /// Скасувати зміни розрахункового листа
        /// </summary>
        public ICommand CancelChangesRegisterRatedListCommand=>new IPSDelegateCommand(CancelChangesRegisterRatedListCommandExecute);
        private void CancelChangesRegisterRatedListCommandExecute(object o)
        {
            RegisterRatedListReadOnly = true;

            if (IsCreateRegisterRated)
            {
                IsCreateRegisterRated = false;
                RegisterRatedList = null;
                RrlCreateButtonVisibility = Visibility.Visible;
            }
            else
            {
                RegisterRatedList.ResetData();
                RrlEditButtonVisibility = Visibility.Visible;
            }
            IsEnabledGrid = true;
            RrlSaveButtonVisibility = Visibility.Collapsed;
            RrlCancelButtonVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Створити звіт через введення вручну
        /// </summary>
        public ICommand CreateRegisterManuallyCommand => new IPSDelegateCommand(CreateRegisterManuallyCommandExecute, o => CanExecuteCreateRegisterManuallyCommand);
        private async void CreateRegisterManuallyCommandExecute(object o)
        {
            //об'єкт звіт
            var register = GetRegisterTemplate();
            bool saveNeed;

            // рапортичка
            if (CurrentLicenseAgreement.SchemaTypeId == 2)
            {
                var progReportBigRight = new ReportExtendedForm(register)
                {
                    HeaderInfoCustomerName = ApplicationCustomerData.GetInstance().CustomerName,
                    HeaderInfoLicenseNumberString = CurrentLicenseAgreement.AgrNumber,
                    HeaderInfoPeriodName = CurrentPeriodOfLicense.PeriodName,
                    HeaderInfoRatedListNumber = RegisterRatedList?.RmId.ToString(),
                };

                saveNeed = progReportBigRight.ShowDialog() == DialogResult.OK;
            }
            // не рапотричка
            else
            {
                var viewForm = new ReportExcelForm(register, true);
                saveNeed = viewForm.ShowDialog() == DialogResult.OK;
            }

            if (saveNeed)
            {
                IsBusy = true;
                var result = await _service.CreateRegister(register);
                IsBusy = false;

                ShowMessage.ShowInfoByResult(result.Message, result.IsSuccess);
                UpdateData();
            }
        }

        public bool CanExecuteCreateRegisterManuallyCommand { get; set; }

        /// <summary>
        /// Створити звіт з файлу Excel
        /// </summary>
        public ICommand CreateRegisterFromFileCommand => new IPSDelegateCommand(CreateRegisterFromFileCommandExecute, o => CanExecuteCreateRegisterFromFileCommand);
        private async void CreateRegisterFromFileCommandExecute(object o)
        {
            var dialog = new OpenFileDialog { AddExtension = true, DefaultExt = "xlsx", Filter = "Excel Files(*.xlsx;*xls)|*.xls;*.xlsx" };
            var dialogResult = dialog.ShowDialog() ?? false;
            if (dialogResult)
            {
                ipsFormsDesign.Model.Register register = null;
                bool repeatableRecordExist = false;

                IsBusy = true;

                await Task.Factory.StartNew(() =>
                {
                    var excelEngine = ExcelEngine.GetInstance();
                    var list = excelEngine.GetReportItems(dialog.FileName);

                    repeatableRecordExist = RegisterUtility.CheckRepeatableRecords(list);
                    if (repeatableRecordExist)
                        return;

                    register = GetRegisterTemplate();
                    
                    TrimDurations(list);
                    list.ForEach(i => register.RegisterItem.Add(i));

                    register.FileName = dialog.SafeFileName;
                });

                if (repeatableRecordExist)
                {
                    IsBusy = false;
                    return;
                }

                var result = await _service.CreateRegister(register);
                IsBusy = false;

                UpdateData();
                ShowMessage.ShowInfoByResult(result.Message, result.IsSuccess);
            }
        }

        public bool CanExecuteCreateRegisterFromFileCommand { get; set; }

        /// <summary>
        /// Відправити на погодження
        /// </summary>
        public ICommand SendRegisterToAcceptCommand => new IPSDelegateCommand(SendRegisterToAcceptCommandExecute, o => CanExecuteSendRegisterToAcceptCommand);
        private async void SendRegisterToAcceptCommandExecute(object o)
        {
            var result = await _service.SendRegisterToAccept(CurrentRegister.Register);
            MessageShow.ShowInfoByResult(result.Message, result.IsSuccess);
        }

        public bool CanExecuteSendRegisterToAcceptCommand { get; set; }

        /// <summary>
        /// Зафіксувати перелік звітів
        /// </summary>
        public ICommand FixingRegisterListCommand => new IPSDelegateCommand(FixingRegisterListCommandExecute, o => CanExecuteFixingRegisterListCommand);
        private async void FixingRegisterListCommandExecute(object o)
        {
            if (!ValidateFixingRegisterList())
                return;

            var result = await _service.FixateRegistersList(RegisterRatedList.RegisterRatedList);
            MessageShow.ShowInfoByResult(result.Message, result.IsSuccess);
            UpdateData();
        }

        public bool CanExecuteFixingRegisterListCommand { get; set; }

        /// <summary>
        /// Редагувати/переглянути звіт
        /// </summary>
        public ICommand OpenRegisterCommand => new IPSDelegateCommand(OpenRegisterCommandExecute);
        private void OpenRegisterCommandExecute(object o)
        {
            if (!(o is RegisterModel e))
                return;

            CurrentRegister = e;

            ShowRegisterItemData();
        }

        /// <summary>
        /// Видалити звіт
        /// </summary>
        public ICommand RemoveRegisterCommand => new IPSDelegateCommand(RemoveRegisterCommandExecute);
        private async void RemoveRegisterCommandExecute(object o)
        {
            if (!(o is RegisterModel e))
                return;

            CurrentRegister = e;

            // RegisterStatus
            // 0	Новий
            // 5	Відхилено
            bool yes = (e.RgStatus == 0 || e.RgStatus == 5) && ShowMessage.ConfirmAction("Видалити обраний звіт?") == MessageBoxResult.Yes;

            if (yes)
            {
                IsBusy = true;
                var result = await _service.DeleteRegister(e.Register);
                IsBusy = false;
                MessageShow.ShowInfoByResult(result.Message, result.IsSuccess);
                UpdateData();
            }
        }

        /// <summary>
        /// Відкрити вікно для реданування курсу валюти обраного звіту
        /// </summary>
        public ICommand ChangeCurrencyExchangeCommand => new IPSDelegateCommand(ChangeCurrencyExchangeCommandExecute);
        private void ChangeCurrencyExchangeCommandExecute(object o)
        {
            if (!(o is RegisterModel e))
                return;

            CurrentRegister = e;

            var window = new CurrencyChangeWindow(CurrentRegister);
            bool result = window.ShowDialog() ?? false;
            
            if (result)
                UpdateData();
        }

        #endregion

        #region * * * EVENT COMMANDS * * *

        public ICommand SortedPeriodsOfLicenseCommand => new IPSDelegateCommand(SortedPeriodsOfLicenseCommandExecute);
        private void SortedPeriodsOfLicenseCommandExecute(object o)
        {
            if (!(o is GridViewSortedEventArgs e))
                return;

            if (e.Column.SortingState == SortingState.None)
            {
                PeriodsOfLicenseSorting = null;
            }
            else
            {
                PeriodsOfLicenseSorting = new SortingProperty
                {
                    SortingState = e.Column.SortingState, 
                    ProperyName = e.Column.UniqueName
                };
            }
        }

        #endregion

        #region * * * INTERNAL PROPERTIES * * *

        public SortingProperty PeriodsOfLicenseSorting { get; set; }

        private bool IsCreateRegisterRated { get; set; }

        private RegisterRatedList TempRegisterRatedList { get; set; }

        #endregion
    }
}