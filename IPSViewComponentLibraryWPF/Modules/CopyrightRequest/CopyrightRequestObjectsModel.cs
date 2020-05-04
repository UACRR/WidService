using System;
using System.Linq;
using ipsFormsDesign.Data;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.CopyrightRequest
{
    public class CopyrightRequestObjectsModel : ViewModelBase
    {
        public Action SelectedChanged { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                SelectedChanged?.Invoke();
                OnPropertyChanged(() => IsSelected);
            }
        }
        public int CRightId { get; set; }
        public int CustId { get; set; }
        public int ObjId { get; set; }
        public string ObjName { get; set; }
        public string GenreName { get; set; }
        public string Duration { get; set; }
        public string RoleName { get; set; }
        public string SpecName { get; set; }
        public decimal Rate { get; set; }
        public string Performer { get; set; }

        private string _workCommentRH;
        public string WorkCommentRH
        {
            get => _workCommentRH;
            set
            {
                _workCommentRH = value;
                OnPropertyChanged(() => WorkCommentRH);
            }
        }

        public DateTime? WorkDateRH { get; set; }
        
        private int? _workTypeRH;
        public int? WorkTypeRH
        {
            get => _workTypeRH;
            set
            {
                _workTypeRH = value;
                WorkTypeRHName = IpsGlobal.AnketaDictionaties?.workType.SingleOrDefault(rec => rec.CodeI == value)?.Name;
                OnPropertyChanged(() => WorkTypeRH);
            }
        }

        private string _workTypeRHName;
        public string WorkTypeRHName
        {
            get => _workTypeRHName;
            set
            {
                if (_workTypeRHName == value)
                    return;

                _workTypeRHName = value;
                OnPropertyChanged(() => WorkTypeRHName);
            }
        }
    }
}
