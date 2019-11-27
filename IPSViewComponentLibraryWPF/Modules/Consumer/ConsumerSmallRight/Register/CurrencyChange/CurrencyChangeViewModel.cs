using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using IpsCommonTypes.IntermediaryTypes;
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
            };

            //CurrentCurrencyType = CurrencyTypeItemSource.SingleOrDefault(rec => rec.R030 == CurrencyChangeData.CurrencyType);
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

            var result = await ConsumerRegisterService.GetInstance().ChangeCCIDRegisterCurrency(CurrencyChangeData.RegisterCcidCurrencyData);
            ShowMessage.ShowInfoByResult(result.Message, result.IsSuccess);

            window.DialogResult = true;
            window.Close();
        }

        private bool CanExecuteChangeCurrencyCommand { get; set; }

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
