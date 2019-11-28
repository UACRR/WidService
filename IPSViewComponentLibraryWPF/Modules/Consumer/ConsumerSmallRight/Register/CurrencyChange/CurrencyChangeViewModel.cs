using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IPSViewComponentLibraryWPF.IPSExtensions;
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Model;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.CurrencyChange
{
    public class CurrencyChangeViewModel : ViewModelBase
    {
        public CurrencyChangeViewModel() { }

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

        #endregion

        #region * * * DATA PROPERTIES * * *

        private CurrencyChangeModel _currencyChangeData;
        public CurrencyChangeModel CurrencyChangeData
        {
            get => _currencyChangeData;
            set
            {
                _currencyChangeData = value;
                OnPropertyChanged(() => CurrencyChangeData);
            }
        }

        private RegisterModel _registerModel;
        public RegisterModel RegisterModel
        {
            get => _registerModel;
            set
            {
                _registerModel = value;
                LoadData();
            }
        }

        private ObservableCollection<KlR030> _currencyTypeItemSource;
        public ObservableCollection<KlR030> CurrencyTypeItemSource
        {
            get => _currencyTypeItemSource;
            set
            {
                _currencyTypeItemSource = value;
                OnPropertyChanged(() => CurrencyTypeItemSource);
            }
        }

        private KlR030 _currentCurrencyType;
        public KlR030 CurrentCurrencyType
        {
            get => _currentCurrencyType;
            set
            {
                _currentCurrencyType = value;
                OnPropertyChanged(() => CurrentCurrencyType);
            }
        }

        #endregion

        #region * * * INTERNAL METHODS * * *

        private async void LoadData()
        {
            if (IpsGlobal.AnketaDictionaties?.klR030 != null)
                CurrencyTypeItemSource = new ObservableCollection<KlR030>(IpsGlobal.AnketaDictionaties.klR030);

            var data = await ConsumerRegisterService.GetInstance().GetCCIDRegisterCurrencyData(RegisterModel.Register);
            CurrencyChangeData = new CurrencyChangeModel
            {
                RegisterCcidCurrencyData = data,
                CheckDataValid = (isValid) =>
                {
                    CanExecuteChangeCurrencyCommand = _errorCount == 0 && isValid;
                }
            };
        }

        private int _errorCount = 0;
        public void HandleValidationError(ValidationErrorEventAction action)
        {
            if (action == ValidationErrorEventAction.Added)
                _errorCount++;
            else if (action == ValidationErrorEventAction.Removed)
                _errorCount--;

            CanExecuteChangeCurrencyCommand = _errorCount == 0;
        }

        private bool ValidateDataCalculation()
        {
            var regRoyalty = CurrencyChangeData.ExchangeRate * CurrencyChangeData.CurrencyAmount;
            var isValid = CurrencyChangeData.RegRoyalty == decimal.Round(regRoyalty, 2, MidpointRounding.AwayFromZero);
            return isValid;
        }

        #endregion

        #region * * * COMMANDS * * *

        /// <summary>
        /// Зберегти зміни
        /// </summary>
        public ICommand ChangeCurrencyCommand => new IPSDelegateCommand(ChangeCurrencyCommandExecute, o => CanExecuteChangeCurrencyCommand);
        private async void ChangeCurrencyCommandExecute(object o)
        {
            var window = o as Window;
            if (window == null)
                return;

            if (!ValidateDataCalculation())
            {
                ShowMessage.ShowWarning("Не коректний курс конвертації або сума звіту!");
                return;
            }

            CurrencyChangeData.UpdateData();
            IsBusy = true;
            var result = await ConsumerRegisterService.GetInstance().ChangeCCIDRegisterCurrency(CurrencyChangeData.RegisterCcidCurrencyData);
            IsBusy = false;
            ShowMessage.ShowInfoByResult(result.Message, result.IsSuccess);

            window.DialogResult = true;
            window.Close();
        }

        public bool CanExecuteChangeCurrencyCommand { get; set; }

        /// <summary>
        /// Закрити вікно
        /// </summary>
        public ICommand CloseWindowCommand => new IPSDelegateCommand(CloseWindowCommandExecue);
        private void CloseWindowCommandExecue(object o)
        {
            var window = o as Window;
            if (window == null)
                return;

            window.DialogResult = false;
            window.Close();
        }

        #endregion
    }
}
