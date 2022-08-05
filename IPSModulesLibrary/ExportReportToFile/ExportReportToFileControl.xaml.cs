using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ipsFormsDesign.Services;
using IPSModulesLibrary.Annotations;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Microsoft.Win32;
using Telerik.Documents.SpreadsheetStreaming;

namespace IPSModulesLibrary.ExportReportToFile
{
    /// <summary>
    /// Interaction logic for ExportReportToFileControl.xaml
    /// </summary>
    public sealed partial class ExportReportToFileControl : UserControl, INotifyPropertyChanged
    {
        private bool _isBusy;

        public ExportReportToFileControl()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void ExportReportToFileControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            IsBusy = true;
            var dictionary = await ExportReportToFileService.GetInstance().GetCustomRegisterTypes();

            var customRegisters = dictionary.Select(item => new CustomRegister {Id = item.Key, Name = item.Value});
            CustomRegisterItemSource = new ObservableCollection<CustomRegister>(customRegisters);

            IsBusy = false;
        }

        public class CustomRegister
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private ObservableCollection<CustomRegister> _customRegisterItemSource = new ObservableCollection<CustomRegister>
        {
            //new CustomRegister{Id = 1, Name = "1"},
            //new CustomRegister{Id = 2, Name = "2"},
            //new CustomRegister{Id = 3, Name = "3"},
            //new CustomRegister{Id = 4, Name = "4"},
        };
        public ObservableCollection<CustomRegister> CustomRegisterItemSource
        {
            get => _customRegisterItemSource;
            set
            {
                _customRegisterItemSource = value;
                OnPropertyChanged(nameof(CustomRegisterItemSource));
            }
        }

        private CustomRegister _selectedCustomRegister;
        public CustomRegister SelectedCustomRegister
        {
            get => _selectedCustomRegister;
            set
            {
                _selectedCustomRegister = value;
                OnPropertyChanged(nameof(SelectedCustomRegister));
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        private int? _registerId;
        public int? RegisterId
        {
            get => _registerId;
            set
            {
                _registerId = value;
                OnPropertyChanged(nameof(RegisterId));
            }
        }

        private DateTime? _dateTimeFrom;
        public DateTime? DateTimeFrom
        {
            get => _dateTimeFrom;
            set
            {
                _dateTimeFrom = value;
                OnPropertyChanged(nameof(DateTimeFrom));
            }
        }

        private DateTime? _dateTimeTo;
        public DateTime? DateTimeTo
        {
            get => _dateTimeTo;
            set
            {
                _dateTimeTo = value;
                OnPropertyChanged(nameof(DateTimeTo));
            }
        }

        /// <summary>
        /// завантажити ддех звіт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportDDEXRegisterById_OnClick(object sender, RoutedEventArgs e)
        {
            if (!RegisterId.HasValue || RegisterId == 0)
            {
                ShowMessage.ShowWarning("Введіть ідентифікатор!");
                return;
            }

            ExportDataFromServerToFile($"export_ddex_register_ID_{RegisterId.Value}_{DateTime.Now:d}_{DateTime.Now:HH-mm-ss}", async () =>
            {
                var currentCulture = CultureInfo.CurrentCulture;
                return await ExportReportToFileService.GetInstance().ExportDDEXRegisterById(RegisterId.Value, currentCulture);
            });


            //return;

            //var fd = new SaveFileDialog()
            //{
            //    FileName = $"export_file_{DateTime.Now:d}",
            //    Filter = "Report files (*.csv)|*.csv|All files (*.*)|*.*",
            //};

            //if (fd.ShowDialog() == true)
            //{
            //    IsBusy = true;

            //    var currentCulture = System.Globalization.CultureInfo.CurrentCulture;
            //    System.Net.ServicePointManager.Expect100Continue = true;
            //    HttpResponseMessage response = await ExportReportToFileService.GetInstance().ExportDDEXRegisterById(104, currentCulture);

            //    using (Stream stream = fd.OpenFile())
            //    {
            //        using (Stream contentStreamResult = await response.Content.ReadAsStreamAsync())
            //        {
            //            contentStreamResult.Position = 0;
            //            await contentStreamResult.CopyToAsync(stream);

            //            await contentStreamResult.FlushAsync();
            //            contentStreamResult.Close();
            //        }

            //        await stream.FlushAsync();
            //        stream.Close();
            //    }

            //    IsBusy = false;
            //}
        }

        /// <summary>
        /// завантажити простий звіт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportDefaultRegisterById_OnClick(object sender, RoutedEventArgs e)
        {
            if (!RegisterId.HasValue || RegisterId == 0)
            {
                ShowMessage.ShowWarning("Введіть ідентифікатор!");
                return;
            }

            ExportDataFromServerToFile($"export_register_ID_{RegisterId.Value}_{DateTime.Now:d}_{DateTime.Now:HH-mm-ss}", async () =>
            {
                var currentCulture = CultureInfo.CurrentCulture;
                return await ExportReportToFileService.GetInstance().ExportDefaultRegisterById(RegisterId.Value, currentCulture);
            });
        }

        /// <summary>
        /// звіт за період
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportOperationDataByPeriodDates_OnClick(object sender, RoutedEventArgs e)
        {
            if (!DateTimeFrom.HasValue || !DateTimeTo.HasValue)
            {
                ShowMessage.ShowWarning("Введіть дати періоду!");
                return;
            }

            ExportDataFromServerToFile($"export_operation_info_by_period_date-from_{DateTimeFrom:d}_to_{DateTimeTo:d}", async () =>
            {
                var currentCulture = CultureInfo.CurrentCulture;
                return await ExportReportToFileService.GetInstance().ExportOperationDataByPeriodDates(DateTimeFrom.Value, DateTimeTo.Value, currentCulture);
            });
        }

        /// <summary>
        /// обрати звіт та завантажити
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportCustomRegister_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedCustomRegister == null)
            {
                ShowMessage.ShowWarning("Оберіть тип реєстру!");
                return;
            }

            ExportDataFromServerToFile($"export_custom_register_type_{SelectedCustomRegister.Id}", async () =>
            {
                var currentCulture = CultureInfo.CurrentCulture;
                return await ExportReportToFileService.GetInstance().GetRegisterByCustomType(SelectedCustomRegister.Id, currentCulture);
            });
        }


        private async void ExportDataFromServerToFile(string fileName, Func<Task<HttpResponseMessage>> request)
        {
            try
            {
                var fd = new SaveFileDialog()
                {
                    FileName = fileName,
                    Filter = "Report files (*.csv)|*.csv|All files (*.*)|*.*",
                };

                if (fd.ShowDialog() == true)
                {
                    IsBusy = true;

                    System.Net.ServicePointManager.Expect100Continue = true;
                    
                    HttpResponseMessage response = await request.Invoke();

                    using (Stream stream = fd.OpenFile())
                    {
                        using (Stream contentStreamResult = await response.Content.ReadAsStreamAsync())
                        {
                            contentStreamResult.Position = 0;
                            await contentStreamResult.CopyToAsync(stream);

                            await contentStreamResult.FlushAsync();
                            contentStreamResult.Close();
                        }

                        await stream.FlushAsync();
                        stream.Close();
                    }

                    ShowMessage.ShowInfo("Процес завершено!");
                }
            }
            catch (Exception e)
            {
                ShowMessage.ShowError(e);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #region ooo

        private static readonly int[] _columnWidths = { 15, 15, 28, 15, 40, 55, 55, 28, 27, 12, 12, 12, 38 };
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
            "%",
            "діє \"з\"",
            "діє \"по\"",
            "Повідомлення про помилку",
        };


        public static async Task ExcelExportAsync(SaveFileDialog dialog, DataTable dataTable, Action<int> changeBusyContent = null)
        {
            await Task.Factory.StartNew(() =>
            {
                using (Stream stream = dialog.OpenFile())
                {
                    using (IWorkbookExporter workbookExporter = SpreadExporter.CreateWorkbookExporter(SpreadDocumentFormat.Xlsx, stream))
                    {
                        using (IWorksheetExporter worksheetExporter = workbookExporter.CreateWorksheetExporter("Worksheet"))
                        {
                            foreach (DataColumn dataTableColumn in dataTable.Columns)
                            {
                                using (IColumnExporter columnExporter = worksheetExporter.CreateColumnExporter())
                                {
                                    var maxLength = dataTableColumn.MaxLength == -1 ? 40 : dataTableColumn.MaxLength;
                                    columnExporter.SetWidthInCharacters(maxLength <= 70 ? maxLength : 70);
                                }
                            }

                            SpreadCellFormat format = new SpreadCellFormat
                            {
                                IsBold = true,
                                Fill = SpreadPatternFill.CreateSolidFill(new SpreadColor(200, 200, 200)),
                                ForeColor = new SpreadThemableColor(new SpreadColor(255, 255, 255)),
                                HorizontalAlignment = SpreadHorizontalAlignment.Center,
                                VerticalAlignment = SpreadVerticalAlignment.Center
                            };
                            using (IRowExporter rowExporter = worksheetExporter.CreateRowExporter())
                            {
                                foreach (DataColumn dataTableColumn in dataTable.Columns)
                                {
                                    using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                                    {
                                        cellExporter.SetValue(dataTableColumn.ColumnName);
                                        cellExporter.SetFormat(format);
                                    }
                                }
                            }

                            foreach (DataRow arrayObjects in dataTable.Rows)
                            {
                                using (IRowExporter rowExporter = worksheetExporter.CreateRowExporter())
                                {
                                    foreach (object item in arrayObjects.ItemArray)
                                    {
                                        ExportItem(rowExporter, item);
                                    }
                                }

                                var index = dataTable.Rows.IndexOf(arrayObjects);
                                if (index % 100 == 0)
                                    changeBusyContent?.Invoke(index);
                            }
                        }
                    }
                }
            });
        }

        private static readonly SpreadCellFormat normalFormat = new SpreadCellFormat
        {
            FontSize = 10,
            VerticalAlignment = SpreadVerticalAlignment.Center,
            HorizontalAlignment = SpreadHorizontalAlignment.Left
        };

        private static readonly SpreadCellFormat normalFormatCenterAlignment = new SpreadCellFormat
        {
            FontSize = 10,
            VerticalAlignment = SpreadVerticalAlignment.Center,
            HorizontalAlignment = SpreadHorizontalAlignment.Center
        };

        private static readonly SpreadCellFormat dateFormat = new SpreadCellFormat
        {
            FontSize = 10,
            VerticalAlignment = SpreadVerticalAlignment.Center,
            HorizontalAlignment = SpreadHorizontalAlignment.Center,
            NumberFormat = "dd.MM.yyyy"
        };

        private static readonly SpreadCellFormat numberFormat = new SpreadCellFormat
        {
            FontSize = 10,
            VerticalAlignment = SpreadVerticalAlignment.Center,
            HorizontalAlignment = SpreadHorizontalAlignment.Left,
            NumberFormat = "0"
        };

        private static readonly SpreadCellFormat doubleFormat = new SpreadCellFormat
        {
            FontSize = 10,
            VerticalAlignment = SpreadVerticalAlignment.Center,
            HorizontalAlignment = SpreadHorizontalAlignment.Right,
            NumberFormat = "#0.00"
        };

        private static void ExportHeaderRows(IWorksheetExporter worksheetExporter)
        {
            using (IRowExporter rowExporter = worksheetExporter.CreateRowExporter())
            {
                SpreadCellFormat format = new SpreadCellFormat
                {
                    IsBold = true,
                    Fill = SpreadPatternFill.CreateSolidFill(new SpreadColor(200, 200, 200)),
                    ForeColor = new SpreadThemableColor(new SpreadColor(255, 255, 255)),
                    HorizontalAlignment = SpreadHorizontalAlignment.Center,
                    VerticalAlignment = SpreadVerticalAlignment.Center
                };

                foreach (string header in _columnHeaders)
                {
                    using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
                    {
                        cellExporter.SetFormat(format);
                        cellExporter.SetValue(header);
                    }
                }
            }
        }

        private static void ExportItem(IRowExporter rowExporter, object item)
        {

            using (ICellExporter cellExporter = rowExporter.CreateCellExporter())
            {
                if (item is string stringItem)
                {
                    cellExporter.SetValue(stringItem);
                    cellExporter.SetFormat(normalFormat);
                }
                else if (item is int intItem)
                {
                    cellExporter.SetValue(intItem);
                    cellExporter.SetFormat(numberFormat);
                }
                else if (item is double doubleItem)
                {
                    cellExporter.SetValue(doubleItem);
                    cellExporter.SetFormat(doubleFormat);
                }
                else if (item is DateTime dateTimeItem)
                {
                    cellExporter.SetValue(dateTimeItem);
                    cellExporter.SetFormat(dateFormat);
                }
            }
        }
        #endregion

    }
}
