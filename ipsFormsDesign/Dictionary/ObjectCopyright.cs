using ipsFormsDesign.Interfaces;
using System.ComponentModel;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectCopyright : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public int ObjId { get; set; }
        public int CustId { get; set; }
        public int RoleCode { get; set; }
        public string InnerCode { get; set; }
        public string InterCode { get; set; }
        public string Name { get; set; }
        private decimal _rate;
        public decimal Rate
        {
            get { return _rate; }
            set
            {
                _rate = value;
                OnPropertyChanged(nameof(Rate));
            }
        }
        public RightholderMainView Rightholder { get; set; }
        public string Error { get; set; }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
