using System;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model
{
    public class RightholderInfoModel : ViewModelBase
    {
        public int CustId { get; set; }
        public string RightholderCode { get; set; }
        public string IPI { get; set; }
        public string RightholderName { get; set; }

        private decimal _rightholderRate;
        public decimal RightholderRate
        {
            get => _rightholderRate;
            set
            {
                _rightholderRate = value;
                
                if (_rightholderRate > 100)
                    _rightholderRate = 100m;
                
                if (_rightholderRate < 0)
                    _rightholderRate = 0;

                OnPropertyChanged(() => RightholderRate);
            }
        }
    }
}
