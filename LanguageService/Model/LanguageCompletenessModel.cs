using Telerik.Windows.Controls;

namespace LanguageService.Model
{
    public class LanguageCompletenessModel : ViewModelBase
    {
        private int _allCategoryCountItems;
        public int AllCategoryCountItems
        {
            get => _allCategoryCountItems;
            set
            {
                _allCategoryCountItems = value;
                OnPropertyChanged(() => AllCategoryCountItems);
            }
        }

        private int _allCategoryIncompletenessCountItems;
        public int AllCategoryIncompletenessCountItems
        {
            get => _allCategoryIncompletenessCountItems;
            set
            {
                _allCategoryIncompletenessCountItems = value;
                OnPropertyChanged(() => AllCategoryIncompletenessCountItems);
            }
        }

        private int _buttonsCategoryCount;
        public int ButtonsCategoryCount
        {
            get => _buttonsCategoryCount;
            set
            {
                _buttonsCategoryCount = value;
                OnPropertyChanged(() => ButtonsCategoryCount);
            }
        }

        private int _buttonsCategoryIncompletenessCount;
        public int ButtonsCategoryIncompletenessCount
        {
            get => _buttonsCategoryIncompletenessCount;
            set
            {
                _buttonsCategoryIncompletenessCount = value;
                OnPropertyChanged(() => ButtonsCategoryIncompletenessCount);
            }
        }

        private int _staticTextCategoryCount;
        public int StaticTextCategoryCount
        {
            get => _staticTextCategoryCount;
            set
            {
                _staticTextCategoryCount = value;
                OnPropertyChanged(() => StaticTextCategoryCount);
            }
        }

        private int _staticTextCategoryIncompletenessCount;
        public int StaticTextCategoryIncompletenessCount
        {
            get => _staticTextCategoryIncompletenessCount;
            set
            {
                _staticTextCategoryIncompletenessCount = value;
                OnPropertyChanged(() => StaticTextCategoryIncompletenessCount);
            }
        }

        private int _columnCategoryCount;
        public int ColumnCategoryCount
        {
            get => _columnCategoryCount;
            set
            {
                _columnCategoryCount = value;
                OnPropertyChanged(() => ColumnCategoryCount);
            }
        }

        private int _columnCategoryIncompletenessCount;
        public int ColumnCategoryIncompletenessCount
        {
            get => _columnCategoryIncompletenessCount;
            set
            {
                _columnCategoryIncompletenessCount = value;
                OnPropertyChanged(() => ColumnCategoryIncompletenessCount);
            }
        }

        private int _menuAndTabCategoryCount;
        public int MenuAndTabCategoryCount
        {
            get => _menuAndTabCategoryCount;
            set
            {
                _menuAndTabCategoryCount = value;
                OnPropertyChanged(() => MenuAndTabCategoryCount);
            }
        }

        private int _menuAndTabCategoryIncompletenessCount;
        public int MenuAndTabCategoryIncompletenessCount
        {
            get => _menuAndTabCategoryIncompletenessCount;
            set
            {
                _menuAndTabCategoryIncompletenessCount = value;
                OnPropertyChanged(() => MenuAndTabCategoryIncompletenessCount);
            }
        }

        private int _systemMessagesCategoryCount;
        public int SystemMessagesCategoryCount
        {
            get => _systemMessagesCategoryCount;
            set
            {
                _systemMessagesCategoryCount = value;
                OnPropertyChanged(() => SystemMessagesCategoryCount);
            }
        }

        private int _systemMessagesCategoryIncompletenessCount;
        public int SystemMessagesCategoryIncompletenessCount
        {
            get => _systemMessagesCategoryIncompletenessCount;
            set
            {
                _systemMessagesCategoryIncompletenessCount = value;
                OnPropertyChanged(() => SystemMessagesCategoryIncompletenessCount);
            }
        }

        private int _toolTipTextCategoryCount;
        public int ToolTipTextCategoryCount
        {
            get => _toolTipTextCategoryCount;
            set
            {
                _toolTipTextCategoryCount = value;
                OnPropertyChanged(() => ToolTipTextCategoryCount);
            }
        }

        private int _toolTipTextCategoryIncompletenessCount;
        public int ToolTipTextCategoryIncompletenessCount
        {
            get => _toolTipTextCategoryIncompletenessCount;
            set
            {
                _toolTipTextCategoryIncompletenessCount = value;
                OnPropertyChanged(() => ToolTipTextCategoryIncompletenessCount);
            }
        }

        private int _otherCategoryCount;
        public int OtherCategoryCount
        {
            get => _otherCategoryCount;
            set
            {
                _otherCategoryCount = value;
                OnPropertyChanged(() => OtherCategoryCount);
            }
        }

        private int _otherCategoryIncompletenessCount;
        public int OtherCategoryIncompletenessCount
        {
            get => _otherCategoryIncompletenessCount;
            set
            {
                _otherCategoryIncompletenessCount = value;
                OnPropertyChanged(() => OtherCategoryIncompletenessCount);
            }
        }
    }
}
