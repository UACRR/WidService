using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model
{
    public class TransferedObjectsRightModel : ViewModelBase
    {
        public int ObjId { get; set; }
        public int? CRightId { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
        public decimal? RateRh { get; set; }

        private bool _manualDistribution;
        public bool ManualDistribution
        {
            get => _manualDistribution;
            set
            {
                _manualDistribution = value;
                OnPropertyChanged(() =>  ManualDistribution);
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
    }
}
