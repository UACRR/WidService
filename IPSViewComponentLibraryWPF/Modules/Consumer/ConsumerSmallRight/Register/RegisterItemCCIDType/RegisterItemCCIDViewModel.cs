using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.RegisterItemCCIDType
{
    public class RegisterItemCCIDViewModel : ViewModelBase
    {
        private const string DefaultTitle = "Перегляд звіту";
        public RegisterItemCCIDViewModel() { }

        private string _title = DefaultTitle;
        public string Title
        {
            get => _title;
            set
            {
                _title = value == null ? DefaultTitle : $"{DefaultTitle} - {value}";
                OnPropertyChanged(() => Title);
            }
        }

        private ObservableCollection<RegisterItemCCIDModel> _registerItemsItemSource;
        public ObservableCollection<RegisterItemCCIDModel> RegisterItemsItemSource
        {
            get => _registerItemsItemSource;
            set
            {
                _registerItemsItemSource = value;
                OnPropertyChanged(() => RegisterItemsItemSource);
            }
        }

        public void ConvertToInternalModel(ICollection<object[]> collection)
        {

        }
    }
}
