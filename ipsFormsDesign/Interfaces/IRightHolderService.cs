using ipsFormsDesign.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ipsFormsDesign.Interfaces
{
    public class RightholderMainView
    {
        public int CustId { get; set; }
        public int CustStatus { get; set; }
        public string InnerCode { get; set;  }
        public string InterCode { get; set; }
        public string Name { get; set; }
        public DateTime RegistrDate { get; set; }
        public int  CntObj { get; set; }
        public decimal YearProfit { get; set; }
        public string Community_Name { get; set; }
        public string Country { get; set; }
        public int? CustType { get; set; }
    }

    public class RightolderWithNotAcceptedCopyrightViewModel : INotifyPropertyChanged
    {
        public int CustId { get; set; }
        public string InnerCode { get; set; }
        public string InterCode { get; set; }
        public string Name { get; set; }
        public int CntObj { get; set; }
        public DateTime? RegistrDate { get; set; }
        private DateTime? _workDateRH;
        public DateTime? WorkDateRH
        {
            get { return _workDateRH; }
            set
            {
                _workDateRH = value;
                OnPropertyChanged(nameof(WorkDateRH));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var args = new PropertyChangedEventArgs(propertyName);

            PropertyChanged?.Invoke(this, args);
        }
    }

    public interface IRightHolderService : IModel
    {
        IList<RightholderMainView> GetMainView();
        IList<RightholderMainView> GetMainViewByStatus(RightholderStatusType rightholderStatus);
    }
}
