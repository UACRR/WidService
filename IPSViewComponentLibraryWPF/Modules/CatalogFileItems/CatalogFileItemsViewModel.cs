using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IPSViewComponentLibraryWPF.Modules.CatalogFileItems.Controls.PubCatalogItem;
using IPSViewComponentLibraryWPF.Modules.CatalogFileItems.Enums;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.CatalogFileItems
{
    public class CatalogFileItemsViewModel : ViewModelBase
    {
        private RightholderRegisterService _rightholderRegisterService;
        private RightholderCatalogService _rightholderCatalogService;
        private List<object[]> _objectsList;

        public CatalogFileItemsViewModel() { }

        #region * * * PROPERTIES FOR SETTINGS * * *

        public CatalogFileType CatalogFileType { get; set; } = CatalogFileType.None;

        private string _titleName;

        public string TitleName
        {
            get => _titleName;
            set
            {
                _titleName = value;
                OnPropertyChanged(() => TitleName);
            }
        }

        public string Language { get; set; } = "en-US";

        #endregion

        #region * * * Grid busy state * * *

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;
                OnPropertyChanged(() => IsBusy);
            }
        }

        private string _busyContent = string.Empty;
        public string BusyContent
        {
            get => _busyContent;
            set
            {
                _busyContent = value;
                OnPropertyChanged(() => BusyContent);
            }
        }

        private void ChangeBusyContent(int currentIteration, int count)
        {
            // x% = ( n * 100 ) / a
            var percent = currentIteration * 100 / count;
            BusyContent = $"Exported: {percent}%";
        }

        #endregion

        #region * * * GridView Items Source * * *

        ObservableCollection<PubCatalogItemModel> _pubCatalogItemList;
        public ObservableCollection<PubCatalogItemModel> ItemsSourcePubCatalog
        {
            get => _pubCatalogItemList;
            set
            {
                _pubCatalogItemList = value;
                OnPropertyChanged(() => ItemsSourcePubCatalog);
            }
        }

        private ObservableCollection<RhcatalogItem> _rhcatalogItemList;
        public ObservableCollection<RhcatalogItem> ItemsSourceRhCatalogItem
        {
            get => _rhcatalogItemList;
            set
            {
                _rhcatalogItemList = value;
                OnPropertyChanged(() => ItemsSourceRhCatalogItem);
            }
        }

        #endregion

        private async void LoadData()
        {
            IsBusy = true;

            ClearData();

            if (CatalogFileType == CatalogFileType.PublisherCatalog)
            {
                var listPubCatalog = await _rightholderCatalogService.GetItemsForExportAsync(_catalogFile.FileId);
                ConvertToPubCatalogItems(listPubCatalog);
            }
            else if (CatalogFileType == CatalogFileType.RightholderRegister)
            {
                var listRhCatalog = await _rightholderRegisterService.GetCatalogFileItems(_catalogFile.FileId);
                ItemsSourceRhCatalogItem = new ObservableCollection<RhcatalogItem>(listRhCatalog);
            }

            IsBusy = false;
        }

        private void ConvertToPubCatalogItems(ICollection<object[]> items)
        {
            _objectsList = items.ToList();

            var itemList = new ObservableCollection<PubCatalogItemModel>();
            foreach (var item in items)
            {
                itemList.Add(new PubCatalogItemModel
                {
                    ItemCode = item[0] as string,
                    Iswc = item[1] as string,
                    ObjName = item[2] as string,
                    GenreName = item[3] as string,
                    Performer = item[4] as string,
                    AuthorMusic = item[5] as string,
                    AuthorText = item[6] as string,
                    RoleName = item[7] as string,
                    RhName = item[8] as string,
                    Rate = (decimal?)(item[9] as double?),
                    DateBegin = item[10] as DateTime?,
                    DateEnd = item[11] as DateTime?,
                    ErrComment = item[12] as string,
                });
            }

            ItemsSourcePubCatalog = itemList;
        }

        private void ClearData()
        {
            ItemsSourcePubCatalog = new ObservableCollection<PubCatalogItemModel>();
            ItemsSourceRhCatalogItem = new ObservableCollection<RhcatalogItem>();
            GC.Collect();
        }

        private CatalogFile _catalogFile = new CatalogFile
        {
            Comment = "Коментарій. Наявні дублі записів",
            CountErr = 12,
            CountOk = 343,
            CountZap = 355,
            CreateDate = new DateTime(2019, 06, 21, 5, 25, 44),
            UserId = "Батя =)",
            StatusNavigation = new CatalogStatus { CodeI = 1, Name = "Статус файлу" },

        };
        public CatalogFile CatalogFile
        {
            get => _catalogFile;
            set
            {
                _catalogFile = value;

                _rightholderRegisterService = RightholderRegisterService.GetInstance();
                _rightholderCatalogService = RightholderCatalogService.GetInstance();

                if (value != null)
                    LoadData();

                OnPropertyChanged(() => CatalogFile);
            }
        }

    }
}
