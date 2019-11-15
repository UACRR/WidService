using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Model;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register
{
    public class RegisterViewModel : ViewModelBase
    {
        public RegisterViewModel()
        {
            
        }

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

        private Visibility _registerRatedListPanelVisible = Visibility.Visible;
        public Visibility RegisterRatedListPanelVisible
        {
            get => _registerRatedListPanelVisible;
            set
            {
                _registerRatedListPanelVisible = value;
                OnPropertyChanged(() => RegisterRatedListPanelVisible);
            }
        }

        private bool _currencyExchangeVisible;
        public bool CurrencyExchangeVisible
        {
            get => _currencyExchangeVisible;
            set
            {
                _currencyExchangeVisible = value;
                OnPropertyChanged(() => CurrencyExchangeVisible);
            }
        }

        private bool _removeRegisterVisible;

        public bool RemoveRegisterVisible
        {
            get => _removeRegisterVisible;
            set
            {
                _removeRegisterVisible = value;
                OnPropertyChanged(() => RemoveRegisterVisible);
            }
        }


        #endregion

        #region * * * DATA PROPERTIES * * *

        public ObservableCollection<RegisterLicenseAgreementModel> LicenseAgreementsItemSource { get; set; }

        public RegisterLicenseAgreementModel CurrentLicenseAgreement { get; set; }

        public RegisterRatedListModel RegisterRatedList { get; set; }

        public ObservableCollection<RegisterPeriodModel> LicensePeriodsItemSource { get; set; }

        public RegisterPeriodModel CurrentLicensePeriod { get; set; }

        public ObservableCollection<RegisterModel> RegistersItemSource { get; set; }

        #endregion

        #region * * * METHODS * * *



        #endregion

        #region * * * COMMANDS * * *

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
