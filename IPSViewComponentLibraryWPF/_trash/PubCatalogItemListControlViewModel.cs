using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IPSViewComponentLibraryWPF.Modules.CatalogFileItems.Controls.PubCatalogItem;
using Telerik.Documents.SpreadsheetStreaming;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF
{
    public class PubCatalogItemListControlViewModel: ViewModelBase
    {
        // TODO: REMOVE CLASS
        List<object[]> _objectsList;

        private string _fileName;

        private readonly int[] _columnWidths = { 15, 15, 28, 15, 40, 55, 55, 28, 27, 12, 12, 12, 38 };
        private readonly string[] _columnHeaders =
        {
            "Шифр твору",
            "ISWC",
            "Назва твору",
            "Жанр твору",
            "Виконавець",
            "Композитор(и)",
            "Автор(и) тексту",
            "Творча роль правовласника",
            "Назва Правовласника",
            "%",
            "діє \"з\"",
            "діє \"по\"",
            "Повідомлення про помилку",
        };

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

        ObservableCollection<PubCatalogItemModel> _pubCatalogItemList;
        public ObservableCollection<PubCatalogItemModel> ItemsSource
        {
            get => _pubCatalogItemList;
            set
            {
                _pubCatalogItemList = value;
                OnPropertyChanged(() => ItemsSource);
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


        public void ClearData()
        {
            ItemsSource = new ObservableCollection<PubCatalogItemModel>();
            GC.Collect();
        }

        public void LoadData(ICollection<object[]> items)
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

            //gvItemList.ItemsSource = itemList;
            ItemsSource = itemList;
        }

        public async void Export(string fileName)
        {
            _fileName = fileName;

            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog()
            {
                FileName = _fileName,
                Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
            };


            var dialogResult = dialog.ShowDialog() == true;

            if (dialogResult)
            {
                IsBusy = true;
                await RunExportAsync(dialog, ChangeBusyContent);
                IsBusy = false;
            }
            
            // message
        }

        private void ChangeBusyContent(int currentIteration, int count)
        {
            // x% = ( n * 100 ) / a
            var percent = currentIteration * 100 / count;
            BusyContent = $"Exported: {percent}%";
        }

        private async Task RunExportAsync(Microsoft.Win32.SaveFileDialog dialog, Action<int, int> changeBusyContent = null)
        {
            await Task.Factory.StartNew(() =>
            {
                using (Stream stream = dialog.OpenFile())
                {
                    using (IWorkbookExporter workbookExporter = SpreadExporter.CreateWorkbookExporter(SpreadDocumentFormat.Xlsx, stream))
                    {
                        using (IWorksheetExporter worksheetExporter = workbookExporter.CreateWorksheetExporter("Worksheet"))
                        {
                            for (int i = 0; i < _columnWidths.Length; i++)
                            {
                                using (IColumnExporter columnExporter = worksheetExporter.CreateColumnExporter())
                                {
                                    columnExporter.SetWidthInCharacters(_columnWidths[i]);
                                }
                            }

                            ExportHeaderRows(worksheetExporter);

                            for (int rowIndex = 0; rowIndex < _objectsList.Count; rowIndex++)
                            {
                                using (IRowExporter rowExporter = worksheetExporter.CreateRowExporter())
                                {
                                    var item = _pubCatalogItemList[rowIndex];

                                    var normalFormat = new SpreadCellFormat();
                                    normalFormat.FontSize = 10;
                                    normalFormat.VerticalAlignment = SpreadVerticalAlignment.Center;
                                    normalFormat.HorizontalAlignment = SpreadHorizontalAlignment.Left;

                                    var normalFormatCenterAlignment = new SpreadCellFormat();
                                    normalFormatCenterAlignment.FontSize = 10;
                                    normalFormatCenterAlignment.VerticalAlignment = SpreadVerticalAlignment.Center;
                                    normalFormatCenterAlignment.HorizontalAlignment = SpreadHorizontalAlignment.Center;

                                    var dateFormat = new SpreadCellFormat();
                                    dateFormat.FontSize = 10;
                                    dateFormat.VerticalAlignment = SpreadVerticalAlignment.Center;
                                    dateFormat.HorizontalAlignment = SpreadHorizontalAlignment.Center;
                                    dateFormat.NumberFormat = "dd.MM.yyyy";

                                    ExportItemCode(rowExporter, item, normalFormatCenterAlignment);
                                    ExportIswc(rowExporter, item, normalFormatCenterAlignment);
                                    ExportObjName(rowExporter, item, normalFormat);
                                    ExportGenreName(rowExporter, item, normalFormat);
                                    ExportPerformer(rowExporter, item, normalFormat);
                                    ExportAuthorMusic(rowExporter, item, normalFormat);
                                    ExportAuthorText(rowExporter, item, normalFormat);
                                    ExportRoleName(rowExporter, item, normalFormat);
                                    ExportRhName(rowExporter, item, normalFormat);
                                    ExportRate(rowExporter, item);
                                    ExportDateBegin(rowExporter, item, dateFormat);
                                    ExportDateEnd(rowExporter, item, dateFormat);
                                    ExportErrComment(rowExporter, item, normalFormat);
                                }

                                var index = rowIndex;
                                InvokeOnUIThread(() => changeBusyContent?.Invoke(index, _objectsList.Count));
                            }
                        }
                    }
                }
            });
        }

        private void ExportHeaderRows(IWorksheetExporter worksheetExporter)
        {
            using (IRowExporter rowExporter = worksheetExporter.CreateRowExporter())
            {
                SpreadCellFormat format = new SpreadCellFormat();
                format.IsBold = true;
                format.Fill = SpreadPatternFill.CreateSolidFill(new SpreadColor(200, 200, 200));
                format.ForeColor = new SpreadThemableColor(new SpreadColor(255, 255, 255));
                format.HorizontalAlignment = SpreadHorizontalAlignment.Center;
                format.VerticalAlignment = SpreadVerticalAlignment.Center;

                for (int i = 0; i < _columnHeaders.Length; i++)
                {
                    using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                    {
                        cellExporter.SetFormat(format);
                        cellExporter.SetValue(_columnHeaders[i]);
                    }
                }
            }
        }

        private void ExportItemCode(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.ItemCode ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }

        private void ExportIswc(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.Iswc ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }

        private void ExportObjName(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.ObjName ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }

        private void ExportGenreName(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.GenreName ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }

        private void ExportPerformer(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.Performer ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }

        private void ExportAuthorMusic(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.AuthorMusic ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }

        private void ExportAuthorText(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.AuthorText ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }

        private void ExportRoleName(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.RoleName ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }

        private void ExportRhName(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.RhName ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }

        private void ExportRate(IRowExporter rowExporter, PubCatalogItemModel item)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                SpreadCellFormat percentFormat = new SpreadCellFormat();
                percentFormat.FontSize = 10;
                percentFormat.VerticalAlignment = SpreadVerticalAlignment.Center;
                percentFormat.HorizontalAlignment = SpreadHorizontalAlignment.Center;
                percentFormat.NumberFormat = "#0.00";

                cellExporter.SetValue((double)(item.Rate ?? 0m));
                cellExporter.SetFormat(percentFormat);
            }
        }

        private void ExportDateBegin(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat dateFormat)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                if (item.DateBegin.HasValue)
                    cellExporter.SetValue(item.DateBegin.Value);
                else
                    cellExporter.SetValue(string.Empty);

                cellExporter.SetFormat(dateFormat);
            }
        }

        private void ExportDateEnd(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat dateFormat)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                if (item.DateEnd.HasValue)
                    cellExporter.SetValue(item.DateEnd.Value);
                else
                    cellExporter.SetValue(string.Empty);

                cellExporter.SetFormat(dateFormat);
            }
        }

        private void ExportErrComment(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.ErrComment ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }
    }
}
