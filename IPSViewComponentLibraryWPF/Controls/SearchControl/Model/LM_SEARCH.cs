using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Controls.SearchControl.Model
{
    public class LM_SEARCH : ViewModelBase
    {
        private string _tabSimple = "Пошук з одним параметром";
        private string _tabMulti = "Пошук з окремими параметрами";
        private string _btnSearch = "Пошук";
        private string _checkSearchEnum = "Шукати в таких полях:";
        private string _eqVal = "Точне значення";
        private string _likeVal = "Містить текст";
        private string _containsVal = "Містить слово";
        private string _txtSearchEnum = "Введіть дані в поля, в яких буде здійснюватись пошук:";
        private string _allCheckItem = "Всі поля";

        public string TAB_SIMPLE
        {
            get => _tabSimple;
            set
            {
                _tabSimple = value; 
                OnPropertyChanged(() => TAB_SIMPLE);
            }
        }

        public string TAB_MULTI
        {
            get => _tabMulti;
            set
            {
                _tabMulti = value;
                OnPropertyChanged(() => TAB_MULTI);
            }
        }

        public string BTN_SEARCH
        {
            get => _btnSearch;
            set
            {
                _btnSearch = value;
                OnPropertyChanged(() => BTN_SEARCH);
            }
        }

        public string CHECK_SEARCH_ENUM
        {
            get => _checkSearchEnum;
            set
            {
                _checkSearchEnum = value;
                OnPropertyChanged(() => CHECK_SEARCH_ENUM);
            }
        }

        public string EQ_VAL
        {
            get => _eqVal;
            set
            {
                _eqVal = value;
                OnPropertyChanged(() => EQ_VAL);
            }
        }

        public string LIKE_VAL
        {
            get => _likeVal;
            set
            {
                _likeVal = value;
                OnPropertyChanged(() => LIKE_VAL);
            }
        }

        public string CONTAINS_VAL
        {
            get => _containsVal;
            set
            {
                _containsVal = value;
                OnPropertyChanged(() => CONTAINS_VAL);
            }
        }

        public string TXT_SEARCH_ENUM
        {
            get => _txtSearchEnum;
            set
            {
                _txtSearchEnum = value;
                OnPropertyChanged(() => TXT_SEARCH_ENUM);
            }
        }

        public string ALL_CHECK_ITEM
        {
            get => _allCheckItem;
            set
            {
                _allCheckItem = value;
                OnPropertyChanged(() => ALL_CHECK_ITEM);
            }
        }
    }
}
