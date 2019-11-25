using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Patterns.Notifier;
using ipsFormsDesign.Services;
using IPSViewComponentLibraryWPF.IPSExtensions;
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Model;
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.RegisterItemCCIDType;
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Utility;
using Microsoft.Win32;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register
{
    public class RegisterViewModel : ViewModelBase, ISubscriber
    {
        private const string RegisterRatedListButtonContentFull = "Розрахунковий лист";
        private const string RegisterRatedListButtonContentShort = "Р/Л";

        private const string DifferentAmountsWarningMsg = "Сума авторської винагороди по Р/Л не співпадає з загальною сумою по введеним рапортичкам! Виконайте необхідні коригування суми!";
        private const string HasInvalidRegisterStatusWarningMsg = "Наявний звіт зі статусом «Новий» або «На погодженні»!";
        private const string HasInvalidRegisterStatusSchema3WarningMsg = "Всі звіти повинні бути в стані «Погоджено. Сконвертовано.» або «Синхронізація виконано. До розподілу.»!";

        private ConsumerRegisterService _service;

        public RegisterViewModel() {}

        #region * * * BEHAVIOR PROPERTIES * * *

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

                CanExecuteCreateRegisterFromFileCommand = value != null && CurrentLicenseAgreement.SchemaTypeId == 1;
                CanExecuteCreateRegisterManuallyCommand = value != null;
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
        private async void LoadData()
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
            LoadData();
        }

        /// <summary>
        /// Оновити список періодів по обраній ліцензії
        /// </summary>
        private void UpdatePeriodList()
        {
            var periodList = new ObservableCollection<RegisterPeriodModel>();

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

            PeriodsOfLicenseItemSource = periodList;
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
            int?[] validStatus = {7, 12};
            bool hasInvalidStatus = RegisterRatedList.RegisterRatedList.Register.Any(rec => !validStatus.Contains(rec.RgStatus));

            if (!hasInvalidStatus)
                return true;

            ShowMessage.ShowWarning(HasInvalidRegisterStatusSchema3WarningMsg);
            return false;
        }

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
                
                case 3: ShowItemDataExternalType();
                    return;
            }
        }

        private async void ShowItemDataDefaultType()
        {
            IsBusy = true;
            var items = await _service.GetRegisterItems(CurrentRegister.Register);
            IsBusy = false;
        }

        private async void ShowItemDataRrlType()
        {
            IsBusy = true;
            var items = await _service.GetRegisterItems(CurrentRegister.Register);
            IsBusy = false;
        }

        private async void ShowItemDataExternalType()
        {
            IsBusy = true;
            var items = await _service.GetRegisterItems(CurrentRegister.Register);
            RegisterItemCCIDWindow window = new RegisterItemCCIDWindow(items, CurrentRegister.FileName);
            IsBusy = false;
            window.ShowDialog();
        }

        #endregion



        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadDataCommand => new IPSDelegateCommand(LoadDataCommandExecute);
        private void LoadDataCommandExecute(object o)
        {
            ApplicationCustomerData.GetInstance().Subscribe(this);
            _service = ConsumerRegisterService.GetInstance();

            RrlCreateButtonVisibility = Visibility.Collapsed;
            RrlEditButtonVisibility = Visibility.Collapsed;
            RrlSaveButtonVisibility = Visibility.Collapsed;
            RrlCancelButtonVisibility = Visibility.Collapsed;

            LoadData();
        }

        /// <summary>
        /// Створити період до обраної ліцензії
        /// </summary>
        public ICommand CreatePeriodCommand => new IPSDelegateCommand(CreatePeriodCommandExecute, (o) => CanExecuteCreatePeriodCommand);
        private void CreatePeriodCommandExecute(object o)
        {

        }

        public bool CanExecuteCreatePeriodCommand { get; set; }

        /// <summary>
        /// Створити розрахунковий лист для періода
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

        public ICommand EditRegisterRatedListCommand => new IPSDelegateCommand(EditRegisterRatedListCommandExecute);
        private void EditRegisterRatedListCommandExecute(object o)
        {
            RrlEditButtonVisibility = Visibility.Collapsed;
            RrlSaveButtonVisibility = Visibility.Visible;
            RrlCancelButtonVisibility = Visibility.Visible;
            RegisterRatedListReadOnly = false;
            IsEnabledGrid = false;
        }

        public ICommand SaveRegisterRatedListCommand => new IPSDelegateCommand(SaveRegisterRatedListCommandExecute);
        private void SaveRegisterRatedListCommandExecute(object o)
        {
            RegisterRatedListReadOnly = true;
            RegisterRatedList.UpdateData();

            object result = null;
            
            if (IsCreateRegisterRated)
                result = _service.CreateRegisterRatedList(RegisterRatedList.RegisterRatedList);
            else
                result = _service.UpdateRegisterRatedList(RegisterRatedList.RegisterRatedList);

            IsCreateRegisterRated = false;
            IsEnabledGrid = true;
            RrlSaveButtonVisibility = Visibility.Collapsed;
            RrlCancelButtonVisibility = Visibility.Collapsed;
            LoadData();
        }

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

            var period = CurrentPeriodOfLicense;

            string identityName = new WindowsPrincipal(WindowsIdentity.GetCurrent()).Identity?.Name;
            RegisterRatedList tempRegisterRatedList = null;

            if (!CurrentPeriodOfLicense.PaidPeriod.RegisterRatedList.Any())
            {
                tempRegisterRatedList = CurrentPeriodOfLicense.PaidPeriod.RegisterRatedList.First();
            }
            else
            {
                //CurrentPeriodOfLicense.PaidPeriod.RegisterRatedList.Add();
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
            };

            // рапортичка
            if (CurrentLicenseAgreement.SchemaTypeId == 2)
            {
                var progReportBigRight = new ReportExtendedForm(register)
                {
                    HeaderInfoCustomerName = GetCustomerName(),
                    HeaderInfoLicenseNumberString = ((IAgreementData)gvLicenseAgr.CurrentRow.DataBoundItem).AgrNumber,
                    HeaderInfoPeriodName = period.PeriodName,
                    HeaderInfoRatedListNumber = period.RegisterRatedList.SingleOrDefault()?.RmId.ToString()
                };

                if (progReportBigRight.ShowDialog() == DialogResult.OK)
                {
                    period.RegisterRatedList.SingleOrDefault()?.Register.Add(register);
                    bindingReports.Add(register);

                    var result = SaveRegisterRatedListExecuted?.Invoke(period.RegisterRatedList.SingleOrDefault()) ?? false;
                    MessageShow.ShowInfoByResult(SaveReportSuccessMsg, SaveReportErrorMsg, result);
                }
            }
            // не рапотричка
            else
            {
                var viewForm = new ReportExcelForm(register, true);
                if (viewForm.ShowDialog() == DialogResult.OK)
                {
                    period.RegisterRatedList.SingleOrDefault()?.Register.Add(register);
                    bindingReports.Add(register);
                    var result = SaveRegisterRatedListExecuted?.Invoke(period.RegisterRatedList.SingleOrDefault()) ?? false;
                    MessageShow.ShowInfoByResult(SaveReportSuccessMsg, SaveReportErrorMsg, result);
                }
            }

            // ok
            register.RmId = tempRegisterRatedList.RmId;
            register.Rm = tempRegisterRatedList;

            // send
            var result0 = await _service.CreateRegister(register);

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

                    string identityName = new WindowsPrincipal(WindowsIdentity.GetCurrent()).Identity?.Name;

                    if (!CurrentPeriodOfLicense.PaidPeriod.RegisterRatedList.Any())
                    {
                        CurrentPeriodOfLicense.PaidPeriod.RegisterRatedList.Add(new RegisterRatedList
                        {
                            PeriodId = CurrentPeriodOfLicense.PeriodId,
                            UserId = identityName,
                            Status = 0
                        });
                    }

                    var registerRatedList = CurrentPeriodOfLicense.PaidPeriod.RegisterRatedList.First();

                    // Створення Звіту
                    register = new ipsFormsDesign.Model.Register
                    {
                        RgStatus = 0,
                        FileName = Path.GetFileName(dialog.FileName),
                        CustId = CurrentLicenseAgreement.CustId,
                        PeriodId = CurrentPeriodOfLicense.PeriodId,
                        RmId = registerRatedList.RmId,
                        Rm = registerRatedList,
                        LicId = CurrentPeriodOfLicense.LicId,
                        SchemaId = CurrentLicenseAgreement?.SchemaTypeId ?? 1,
                        AlgorithmId = CurrentLicenseAgreement?.AlgorithmId ?? 1,
                        UserId = identityName
                    };

                    foreach (var item in list)
                        register.RegisterItem.Add(item);

                });

                var result = await _service.CreateRegister(register);

                IsBusy = false;
                ShowMessage.ShowInfo(result.Message);
            }
        }

        public bool CanExecuteCreateRegisterFromFileCommand { get; set; }

        /// <summary>
        /// Відправити на погодження
        /// </summary>
        public ICommand SendRegisterToAcceptCommand => new IPSDelegateCommand(SendRegisterToAcceptCommandExecute, o => CanExecuteSendRegisterToAcceptCommand);
        private void SendRegisterToAcceptCommandExecute(object o)
        {
            var result = _service.SendRegisterToAccept(CurrentRegister.Register);
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
        private void RemoveRegisterCommandExecute(object o)
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
                var result = _service.DeleteRegister(e.Register);
                // update
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
