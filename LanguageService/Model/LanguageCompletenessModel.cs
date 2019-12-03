using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
