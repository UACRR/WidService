using System;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model
{
    public class TransferedObjectsRightModel : ViewModelBase
    {
        public TransferedObjectsRightModel()
        {
            Rightholders = new ObservableCollection<RightholderInfoModel>();
        }

        public int ObjId { get; set; }
        public int? CRightId { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }

        public decimal? RateRh { get; set; }

        private bool _isAutoDistributionPercent = true;
        public bool IsAutoDistributionPercent
        {
            get => _isAutoDistributionPercent;
            set
            {
                _isAutoDistributionPercent = value;
                
                UpdateDistributionPercents();
                
                OnPropertyChanged(() => IsAutoDistributionPercent);
            }
        }

        private ObservableCollection<RightholderInfoModel> _rightholders;
        public ObservableCollection<RightholderInfoModel> Rightholders
        {
            get => _rightholders;
            set
            {
                _rightholders = value;
                OnPropertyChanged(() => Rightholders);
            }
        }

        public void UpdateDistributionPercents()
        {
            if (!IsAutoDistributionPercent)
                return;

            const decimal MinDelta = 0.01m;
            decimal delta = 0m;
            decimal rate = 0m;
            decimal remainder = 0m;

            if (!Rightholders.Any() || !RateRh.HasValue)
                return;

            decimal inputRate = (decimal) RateRh;
            int count = Rightholders.Count;

            // рівномірний розподіл
            if (inputRate % count == 0m)
            {
                rate = inputRate / count;
            }
            else
            {
                // визначаємо основу % та розбиваємо на частинки залишок
                decimal z = inputRate % count;
                rate = (inputRate - z) / count;

                decimal parts = z / MinDelta;

                if (parts % count == 0m)
                {
                    delta = parts / count * MinDelta;
                }
                else
                {
                    remainder = parts % count;
                    delta = (parts - remainder) / count * MinDelta;
                }
            }

            rate += delta;
            remainder *= MinDelta;
            foreach (var rightholder in Rightholders)
            {
                rightholder.RightholderRate = rate;
            }

            if (remainder > 0)
            {
                foreach (var rightholder in Rightholders)
                {
                    rightholder.RightholderRate += MinDelta;

                    remainder -= MinDelta;
                    if (remainder <= 0)
                        break;
                }
            }

            var summ = Rightholders.Sum(rec => rec.RightholderRate);
            bool b =  summ == RateRh;
            if (!b)
                ;
        }
    }
}
