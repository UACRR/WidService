using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Patterns.Notifier;
using ipsFormsDesign.Services;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Model;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register
{
    public class RegisterViewModel : ViewModelBase, ISubscriber
    {
        private const string RegisterRatedListButtonContentFull = "Розрахунковий лист";
        private const string RegisterRatedListButtonContentShort = "Р/Л";

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
                RegisterRatedList = new RegisterRatedListModel
                {
                    RegisterRatedList = value?.PaidPeriod?.RegisterRatedList.FirstOrDefault(),
                };

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
                foreach (var period in CurrentLicenseAgreement.LicenseAgreement.PaidPeriod)
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
            CurrencyExchangeVisible = false;
            RemoveRegisterVisible = true;
            RegisterAmountVisible = false;
        }

        private void SwitchToRRLReportType()
        {
            IsRegisterRatedList = true;
            RegisterRatedListPanelVisible = Visibility.Visible;
            CurrencyExchangeVisible = false;
            RemoveRegisterVisible = true;
            RegisterAmountVisible = false;
        }

        private void SwitchToExternalReportType()
        {
            IsRegisterRatedList = false;
            RegisterRatedListPanelVisible = Visibility.Collapsed;
            CurrencyExchangeVisible = true;
            RemoveRegisterVisible = false;
            RegisterAmountVisible = true;
        }

        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadDataCommand => new IPSDelegateCommand(LoadDataCommandExecute);
        private void LoadDataCommandExecute(object o)
        {
            ApplicationCustomerData.GetInstance().Subscribe(this);
            _service = ConsumerRegisterService.GetInstance();
            LoadData();
        }

        public ICommand CreatePeriodCommand => new IPSDelegateCommand(CreatePeriodCommandExecute, (o) => CanExecuteCreatePeriodCommand);
        private void CreatePeriodCommandExecute(object o)
        {

        }

        public bool CanExecuteCreatePeriodCommand { get; set; }

        public ICommand CreateRegisterRatedListCommand => new IPSDelegateCommand(CreateRegisterRatedListCommandExecute, (o) => CanExecuteCreateRegisterRatedListCommand);
        private void CreateRegisterRatedListCommandExecute(object o)
        {

        }

        public bool CanExecuteCreateRegisterRatedListCommand { get; set; }

        public ICommand EditRegisterRatedListCommand => new IPSDelegateCommand(EditRegisterRatedListCommandExecute, (o) => CanExecuteEditRegisterRatedListCommand);
        private void EditRegisterRatedListCommandExecute(object o)
        {

        }

        public bool CanExecuteEditRegisterRatedListCommand { get; set; }

        public ICommand CreateRegisterManuallyCommand => new IPSDelegateCommand(CreateRegisterManuallyCommandExecute, o => CanExecuteCreateRegisterManuallyCommand);
        private void CreateRegisterManuallyCommandExecute(object o)
        {

        }

        public bool CanExecuteCreateRegisterManuallyCommand { get; set; }

        public ICommand CreateRegisterFromFileCommand => new IPSDelegateCommand(CreateRegisterFromFileCommandExecute, o => CanExecuteCreateRegisterFromFileCommand);
        private void CreateRegisterFromFileCommandExecute(object o)
        {

        }

        public bool CanExecuteCreateRegisterFromFileCommand { get; set; }

        public ICommand SendRegisterToAcceptCommand => new IPSDelegateCommand(SendRegisterToAcceptCommandExecute, o => CanExecuteSendRegisterToAcceptCommand);
        private void SendRegisterToAcceptCommandExecute(object o)
        {

        }

        public bool CanExecuteSendRegisterToAcceptCommand { get; set; }

        public ICommand FixingRegisterListCommand => new IPSDelegateCommand(FixingRegisterListCommandExecute, o => CanExecuteFixingRegisterListCommand);
        private void FixingRegisterListCommandExecute(object o)
        {

        }

        public bool CanExecuteFixingRegisterListCommand { get; set; }

        public ICommand OpenRegisterCommand => new IPSDelegateCommand(OpenRegisterCommandExecute);
        private void OpenRegisterCommandExecute(object o)
        {

        }


        public ICommand RemoveRegisterCommand => new IPSDelegateCommand(RemoveRegisterCommandExecute, o => CanExecuteRemoveRegisterCommand);
        private void RemoveRegisterCommandExecute(object o)
        {

        }

        public bool CanExecuteRemoveRegisterCommand { get; set; }

        public ICommand ChangeCurrencyExchangeCommand => new IPSDelegateCommand(ChangeCurrencyExchangeCommandExecute);
        private void ChangeCurrencyExchangeCommandExecute(object o)
        {

        }

        #endregion

    }
}
