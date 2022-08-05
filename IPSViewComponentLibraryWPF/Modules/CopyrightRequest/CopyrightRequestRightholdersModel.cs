using System;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.CopyrightRequest
{
    public class CopyrightRequestRightholdersModel : ViewModelBase
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
            get => _workDateRH;
            set
            {
                _workDateRH = value;
                OnPropertyChanged(() => WorkDateRH);
            }
        }
    }
}
