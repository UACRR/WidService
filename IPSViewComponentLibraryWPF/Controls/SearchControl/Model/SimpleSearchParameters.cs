using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.Enums;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Controls.SearchControl.Model
{
    public class SimpleSearchParameters : ViewModelBase
    {
        private string _searchText;
        private bool _isEqualSelected;
        private bool _isLikeSelected;
        private bool _isContainsSelected;

        public SimpleSearchParameters()
        {
            IsEqualSelected = true;
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(() => SearchText);
            }
        }

        public MatchTextOfSearch MatchTextOfSearch
        {
            get
            {
                if (IsEqualSelected)
                    return MatchTextOfSearch.Equal;

                if (IsLikeSelected)
                    return MatchTextOfSearch.Like;

                if (IsContainsSelected)
                    return MatchTextOfSearch.Contains;

                throw new ArgumentOutOfRangeException();
            }
        }

        public bool IsEqualSelected
        {
            get => _isEqualSelected;
            set
            {
                _isEqualSelected = value;
                OnPropertyChanged(() => IsEqualSelected);
            }
        }

        public bool IsLikeSelected
        {
            get => _isLikeSelected;
            set
            {
                _isLikeSelected = value;
                OnPropertyChanged(() => IsLikeSelected);
            }
        }

        public bool IsContainsSelected
        {
            get => _isContainsSelected;
            set
            {
                _isContainsSelected = value; 
                OnPropertyChanged(() => IsContainsSelected);
            }
        }
    }
}
