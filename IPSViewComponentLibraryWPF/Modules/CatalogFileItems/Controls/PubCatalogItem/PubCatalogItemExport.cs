using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Telerik.Documents.SpreadsheetStreaming;

namespace IPSViewComponentLibraryWPF.Modules.CatalogFileItems.Controls.PubCatalogItem
{
    public static class PubCatalogItemExport
    {
        private static readonly int[] _columnWidths = { 15, 15, 28, 15, 40, 55, 55, 28, 27, 12, 12, 12, 12, 38 };
        private static readonly string[] _columnHeaders =
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
            "% (публ)",
            "% (мех)",
            "діє \"з\"",
            "діє \"по\"",
            "Повідомлення про помилку",
        };

        public static async Task ExcelExportAsync(SaveFileDialog dialog, List<object[]> _objectsList, ICollection<PubCatalogItemModel> pubCatalogItemCollection, Action<int> changeBusyContent)
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

                            var pubCatalogItemList = pubCatalogItemCollection.ToList();

                            for (int rowIndex = 0; rowIndex < _objectsList.Count; rowIndex++)
                            {
                                using (IRowExporter rowExporter = worksheetExporter.CreateRowExporter())
                                {
                                    var item = pubCatalogItemList[rowIndex];

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
                                    ExportRate(rowExporter, item.Rate);
                                    ExportRate(rowExporter, item.RateMech);
                                    ExportDateBegin(rowExporter, item, dateFormat);
                                    ExportDateEnd(rowExporter, item, dateFormat);
                                    ExportErrComment(rowExporter, item, normalFormat);
                                }

                                var index = rowIndex;
                                if (index % 100 == 0)
                                    changeBusyContent?.Invoke(index);
                            }
                        }
                    }
                }
            });
        }

        private static void ExportHeaderRows(IWorksheetExporter worksheetExporter)
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
        private static void ExportItemCode(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.ItemCode ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }
        private static void ExportIswc(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.Iswc ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }
        private static void ExportObjName(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.ObjName ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }
        private static void ExportGenreName(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.GenreName ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }
        private static void ExportPerformer(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.Performer ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }
        private static void ExportAuthorMusic(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.AuthorMusic ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }
        private static void ExportAuthorText(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.AuthorText ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }
        private static void ExportRoleName(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.RoleName ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }
        private static void ExportRhName(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.RhName ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }
        private static void ExportRate(IRowExporter rowExporter, decimal? rate)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                SpreadCellFormat percentFormat = new SpreadCellFormat();
                percentFormat.FontSize = 10;
                percentFormat.VerticalAlignment = SpreadVerticalAlignment.Center;
                percentFormat.HorizontalAlignment = SpreadHorizontalAlignment.Center;
                percentFormat.NumberFormat = "#0.00";

                cellExporter.SetValue((double)(rate ?? 0m));
                cellExporter.SetFormat(percentFormat);
            }
        }
        private static void ExportDateBegin(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat dateFormat)
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
        private static void ExportDateEnd(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat dateFormat)
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
        private static void ExportErrComment(IRowExporter rowExporter, PubCatalogItemModel item, SpreadCellFormat format)
        {
            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                cellExporter.SetValue(item.ErrComment ?? string.Empty);
                cellExporter.SetFormat(format);
            }
        }
    }
}
