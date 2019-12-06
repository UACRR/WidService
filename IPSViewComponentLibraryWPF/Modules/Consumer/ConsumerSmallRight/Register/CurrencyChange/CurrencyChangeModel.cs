using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.IntermediaryTypes;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.CurrencyChange
{
    public class CurrencyChangeModel : ViewModelBase
    {
        private decimal _regRoyalty;
        public decimal RegRoyalty
        {
            get => _regRoyalty;
            set
            {
                _regRoyalty = value;
                CheckDataValid?.Invoke(value > 0);
                OnPropertyChanged(() => RegRoyalty);
            }
        }

        private decimal _exchangeRate;
        public decimal ExchangeRate
        {
            get => _exchangeRate;
            set
            {
                _exchangeRate = value;
                CheckDataValid?.Invoke(value > 0);
                OnPropertyChanged(() => ExchangeRate);
            }
        }

        private decimal _currencyAmount;
        public decimal CurrencyAmount
        {
            get => _currencyAmount;
            set
            {
                _currencyAmount = value;
                OnPropertyChanged(() => CurrencyAmount);
            }
        }

        private string _currencyType;
        public string CurrencyType
        {
            get => _currencyType;
            set
            {
                _currencyType = value;
                CheckDataValid?.Invoke(!string.IsNullOrEmpty(value));
                OnPropertyChanged(() => CurrencyType);
            }
        }

        private RegisterCCIDCurrencyData _registerCcidCurrencyData;
        public RegisterCCIDCurrencyData RegisterCcidCurrencyData
        {
            get => _registerCcidCurrencyData;
            set
            {
                _registerCcidCurrencyData = value;
                RegRoyalty = value.RegRoyalty ?? 0m;
                ExchangeRate = value.ExchangeRate ?? 0m;
                CurrencyAmount = value.AmountCur ?? 0m;
                CurrencyType = value.R030;
            }
        }

        public void UpdateData()
        {
            _registerCcidCurrencyData.RegRoyalty = RegRoyalty;
            _registerCcidCurrencyData.ExchangeRate = ExchangeRate;
            _registerCcidCurrencyData.R030 = CurrencyType;
        }

        public Action<bool> CheckDataValid { get; set; }

    }
}
