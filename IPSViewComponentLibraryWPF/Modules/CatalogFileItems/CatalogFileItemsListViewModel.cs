using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using IpsCommonTypes.Enums;
using IpsCommonTypes.Wrappers;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Services.Interfaces;
using ipsFormsDesign.Utilities;
using IPSViewComponentLibraryWPF.IPSExtensions;
using IPSViewComponentLibraryWPF.Modules.CatalogFileItems.Controls.PubCatalogItem;
using IPSViewComponentLibraryWPF.Modules.CatalogFileItems.Enums;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.CatalogFileItems
{
    public class CatalogFileItemsListViewModel : ViewModelBase
    {
        private const string ValidateSuccessMsg = "Контроль виконано!";
        private const string FileExportCompleteMsg = "Експорт файлу завершено!";

        private ICatalogFileItemsService _catalogFileІService;
        private List<object[]> _objectsList;

        public CatalogFileItemsListViewModel() { }

        #region * * * INTERNAL PROPERTIES * * *

        private CatalogFileType _catalogFileType = CatalogFileType.None;
        public CatalogFileType CatalogFileType
        {
            get => _catalogFileType;
            set
            {
                _catalogFileType = value;

                if (value == CatalogFileType.PublisherCatalog)
                    _catalogFileІService = RightholderCatalogService.GetInstance();
                else if (value == CatalogFileType.RightholderRegister)
                    _catalogFileІService = RightholderRegisterService.GetInstance();
            }
        }

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

        #endregion

        #region * * * Grid busy HANDLERS * * *

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

        /// <summary>
        /// Calculate how much percent is exported
        /// </summary>
        /// <param name="currentIteration"></param>
        /// <param name="count"></param>
        private void ChangeBusyContent(int currentIteration, int count)
        {
            // x% = ( n * 100 ) / a
            var percent = currentIteration * 100 / count;
            BusyContent = $"Exported: {percent}%";
        }

        #endregion

        #region * * * GridView Items Source PROPERTIES * * *

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

        #region * * * DATA HANDLERS * * *

        private CatalogFile _catalogFile;
        public CatalogFile CatalogFile
        {
            get => _catalogFile;
            set
            {
                _catalogFile = value;
                CanExecuteValidateCommand = _catalogFile?.Status != 3;
                CanExecuteBeginPerformProcess = _catalogFile?.Status == 1;

                if (value != null)
                    UpdateDataItems();

                OnPropertyChanged(() => CatalogFile);
            }
        }

        /// <summary>
        /// Load and update items of CatalogFile
        /// </summary>
        private async void UpdateDataItems()
        {
            IsBusy = true;

            ClearData();

            if (CatalogFileType == CatalogFileType.PublisherCatalog)
            {
                var listPubCatalog = await RightholderCatalogService.GetInstance().GetItemsForExportAsync(_catalogFile.FileId);
                ConvertToPubCatalogItems(listPubCatalog);
                TitleName = $"Перегляд каталогу «{_catalogFile.FileName}»";
            }
            else if (CatalogFileType == CatalogFileType.RightholderRegister)
            {
                var listRhCatalog = await RightholderRegisterService.GetInstance().GetCatalogFileItems(_catalogFile.FileId);
                ItemsSourceRhCatalogItem = new ObservableCollection<RhcatalogItem>(listRhCatalog);
                TitleName = $"Перегляд реєстру «{_catalogFile.FileName}»";
            }

            IsBusy = false;
        }

        /// <summary>
        /// Clear old reference and execute GC.Collect() method
        /// </summary>
        private void ClearData()
        {
            ItemsSourcePubCatalog = new ObservableCollection<PubCatalogItemModel>();
            ItemsSourceRhCatalogItem = new ObservableCollection<RhcatalogItem>();
            GC.Collect();
        }

        /// <summary>
        /// Convert data collection of object array to internal model
        /// </summary>
        /// <param name="items"></param>
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

        #endregion

        #region * * * COMMANDS * * *

        public ICommand ValidateCommand => new IPSDelegateCommand(OnValidateCommandExecute, (obj) => CanExecuteValidateCommand);

        /// <summary>
        /// Check calatog file for error records (not valid data)
        /// </summary>
        /// <param name="o"></param>
        private async void OnValidateCommandExecute(object o)
        {
            IsBusy = true;
            ExecSqlResponse<CatalogFile>  result = await _catalogFileІService.ValidateCatalogFileItemsAsync(_catalogFile);
            IsBusy = false;

            if (result == null)
            {
                ShowMessage.ShowError("Unknown error!");
                return;
            }

            var boolResult = result.StatusCode == ExecSqlResponceStatus.Successed;

            CatalogFile = result.Data;

            UpdateEventHandlerUtility<PubCatalogItem>.InvokeEvent();
            ShowMessage.ShowInfoByResult($"{ValidateSuccessMsg} {result.Message}", result.Message, boolResult);
        }

        private bool CanExecuteValidateCommand { get; set; }

        public ICommand ExportToExcelCommand => new IPSDelegateCommand(OnExportToExcelCommandExecute);

        /// <summary>
        /// Export CatalogFile items to Excel
        /// </summary>
        /// <param name="o"></param>
        private async void OnExportToExcelCommandExecute(object o)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog()
            {
                FileName = $"{_catalogFile.FileName.Replace(".xlsx", "")}_export",
                Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
            };

            var dialogResult = dialog.ShowDialog() == true;

            if (dialogResult)
            {
                var count = _objectsList.Count;
                IsBusy = true;
                
                if (CatalogFileType == CatalogFileType.PublisherCatalog)
                    await PubCatalogItemExport.ExcelExportAsync(dialog, _objectsList, _pubCatalogItemList, (i) => InvokeOnUIThread(() => ChangeBusyContent(i, count)));
                else if (CatalogFileType == CatalogFileType.RightholderRegister)
                    throw new NotImplementedException();
                //TODO: implement

                IsBusy = false;

                ShowMessage.ShowInfo(FileExportCompleteMsg);
            }
        }

        public ICommand BeginPerformProcessCommand => new IPSDelegateCommand(OnBeginPerformProcessCommandExecute, (obj) => CanExecuteBeginPerformProcess);

        /// <summary>
        /// Begin perform process for CatalogFile items on server
        /// </summary>
        /// <param name="o"></param>
        private async void OnBeginPerformProcessCommandExecute(object o)
        {
            IsBusy = true;
            ExecSqlResponse<CatalogFile> result = await _catalogFileІService.ProcessCatalogFileItemsAsync(_catalogFile);
            IsBusy = false;

            if (result == null)
            {
                ShowMessage.ShowError("Unknown error!");
                return;
            }

            var boolResult = result.StatusCode == ExecSqlResponceStatus.Successed;

            CatalogFile = result.Data;

            UpdateEventHandlerUtility<PubCatalogItem>.InvokeEvent();
            ShowMessage.ShowInfoByResult(result.Message, result.Message, boolResult);
        }

        private bool CanExecuteBeginPerformProcess { get; set; }

        #endregion
    }
}
