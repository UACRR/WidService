using System.Linq;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Model
{
    public class RegisterRatedListModel : ViewModelBase, IViewModelDataChange
    {
        public int PeriodId { get; set; }
        
        private int _rmId;
        public int RmId
        {
            get => _rmId;
            set
            {
                _rmId = value;
                OnPropertyChanged(() => RmId);
            }
        }

        private decimal? _amount;
        public decimal? Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged(() => Amount);
            }
        }

        private decimal? _royalty;
        public decimal? Royalty
        {
            get => _royalty;
            set
            {
                _royalty = value;
                OnPropertyChanged(() => Royalty);
            }
        }

        private int? _countReport;
        public int? CountReport
        {
            get => _countReport;
            set
            {
                _countReport = value;
                OnPropertyChanged(() => CountReport);
            }
        }

        private int? _status;
        public int? Status
        {
            get => _status;
            set
            {
                _status = value;
                var status = IpsGlobal.AnketaDictionaties?.registerListStatus?.SingleOrDefault(rec => rec.CodeI == value);
                StatusName = status?.Name;
            }
        }

        private string _statusName;
        public string StatusName
        {
            get => _statusName;
            set
            {
                _statusName = value;
                OnPropertyChanged(() => StatusName);
            }
        }

        private RegisterRatedList _registerRatedList;
        public RegisterRatedList RegisterRatedList
        {
            get => _registerRatedList;
            set
            {
                _registerRatedList = value;
                ResetData();
            }
        }

        public void ResetData()
        {
            PeriodId = _registerRatedList?.PeriodId ?? 0;
            RmId = _registerRatedList?.RmId ?? 0;
            Amount = _registerRatedList?.Amount;
            Royalty = _registerRatedList?.Royalty;
            CountReport = _registerRatedList?.CntReport;
            Status = _registerRatedList?.Status;
        }

        public void UpdateData()
        {
            if (_registerRatedList == null)
                return;

            _registerRatedList.RmId = RmId;
            _registerRatedList.Amount = Amount;
            _registerRatedList.Royalty = Royalty;
            _registerRatedList.CntReport = CountReport;
        }
    }
}
