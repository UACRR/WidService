
using System.ComponentModel;

namespace ipsFormsDesign.ViewModels.Fixations
{
    public class RegisterCountViewModel : INotifyPropertyChanged
    {
        public decimal RegCntId { get; set; }
        public int RegId { get; set; }
        public int RegIitemId { get; set; }
        public int ObjId { get; set; }
        public int CustId { get; set; }
        public decimal OwnershipRate { get; set; }
        public string Name { get; set; }
        public string CreativeRoles { get; set; }
        public decimal _rate;
        public decimal Rate
        {
            get { return _rate; }
            set
            {
                _rate = value;
                OnPropertyChanged(nameof(Rate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
