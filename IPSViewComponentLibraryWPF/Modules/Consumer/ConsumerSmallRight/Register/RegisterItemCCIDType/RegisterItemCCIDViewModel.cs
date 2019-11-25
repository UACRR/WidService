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

        /// <summary>
        /// Сконвертувати масив даних у внутрішню модель
        /// </summary>
        /// <param name="collection"></param>
        public void ConvertToInternalModel(ICollection<object[]> collection)
        {
            var itemsSource = new ObservableCollection<RegisterItemCCIDModel>();

            foreach (var item in collection)
            {
                itemsSource.Add(new RegisterItemCCIDModel
                {
                    ItemName = item[0] as string,
                    Performer = item[1] as string,
                    AuthorMusic = item[2] as string,
                    AuthorText = item[3] as string,

                    AmountPerfCurrency = (decimal?)(item[4] as double?) ?? 0m,
                    AmountPerf = (decimal?)(item[5] as double?) ?? 0m,

                    AmountMechCurrency = (decimal?)(item[6] as double?) ?? 0m,
                    AmountMech = (decimal?)(item[7] as double?) ?? 0m,
                });
            }

            RegisterItemsItemSource = itemsSource;
        }
    }
}
