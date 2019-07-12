using ipsFormsDesign.Model;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using System.Collections;

namespace ipsFormsDesign.Services
{
    public class ExcelEngine
    {
        private const string PercentFormat = "0.00%";

        private Excel.Application excelApp = null;
        private static ExcelEngine _instance;
        protected ExcelEngine()
        {
            // GetApp().GetAwaiter();
        }

        public static ExcelEngine GetInstance()
        {
            if (_instance == null)
                _instance = new ExcelEngine();

            return _instance;
        }

        ~ExcelEngine()
        {
            lock (this)
            {
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                    excelApp = null;
                }
            }
            excelApp = null;
        }

        private Excel.Application GetApp()
        {
            lock (this)
            {
                if (excelApp != null)
                    return excelApp;
                excelApp = new Excel.Application();
                return excelApp;
            }
        }

        private string GetFirst(object sors, int length = 0)
        {
            if (sors == null)
                return string.Empty;

            var sorsStr = sors.ToString().Trim();

            if (length != 0)
                sorsStr = sorsStr.Substring(0, Math.Min(sorsStr.Length, length));

            return sorsStr;
        }

        private TimeSpan GetDuration(object source)
        {
            if (source is string @str_source)
                return TimeSpan.Parse(@str_source);
            if (source is double @dbl_source )
                return TimeSpan.FromDays(@dbl_source);

            return TimeSpan.Zero;
        }
        public List<RegisterItem> GetReportItems(string FileName)
        {
            Excel.Workbook excelAppWorkbook = null;
            List<RegisterItem> list = new List<RegisterItem>();
            int index = 0;
            try
            {

                excelAppWorkbook = GetApp().Workbooks.Open(FileName, 0, true, 5, null, null, false,
                Excel.XlPlatform.xlWindows, null, null, null);
                var excelAppWorksheets = excelAppWorkbook.Worksheets;
                var excelSheet = (Excel.Worksheet)excelAppWorksheets.Item[1];


                Excel.Range excelRange = excelSheet.UsedRange;

                int maxCol;
                int maxRow;

                maxCol = excelRange.Columns.Count;
                maxRow = excelRange.Rows.Count;


                var dim = excelRange.Value;
                int regitemid = 0;
                TimeSpan curTime;

                // RegisterItem[] newItems = new RegisterItem[maxRow];


                for (index = 1; index <= maxRow; index++)
                {
                    if (dim?[index, 1] == null) continue;
                    if ( !double.TryParse( dim?[index, 1].ToString(), out double temp)) continue;

                    // RegisterItem registerItem = newItems[regitemid];
                    RegisterItem registerItem = new RegisterItem
                    {
                        RegIitemId = 1 + regitemid++,
                        CategoryCode = 5, //parse
                        ModifyLogin = null, //parse
                                            // registerItem.RegIitemId = Convert.ToInt32(dim[1, 1]);
                        ItemName = GetFirst(dim[index, 2], 100),
                        Performer = GetFirst(dim[index, 3], 100),
                        AuthorMusic = GetFirst(dim[index, 4], 100),
                        AuthorText = GetFirst(dim[index, 5], 100),
                        CountUse = Convert.ToInt32(dim[index, 7]),
                        CodeItem = 1 // 1   Звичайний розподіл 
                    };
                    try
                    {
                        //curTime = TimeSpan.FromDays(Convert.ToDouble(dim[index, 6]));
                        curTime = GetDuration(dim[index, 6]);
                        registerItem.DurationItem = curTime;
                        // curTime = TimeSpan.FromDays(Convert.ToDouble(dim[index, 8]));
                        registerItem.DurationUse = TimeSpan.FromTicks(curTime.Ticks * registerItem.CountUse ?? 1);
                        registerItem.Ticks = (int)(curTime.Ticks / 10000);
                    }
                    catch
                    {
                        registerItem.DurationItem = TimeSpan.Zero;
                        registerItem.DurationUse = TimeSpan.Zero;
                        registerItem.Ticks = 0;
                    }


                    list.Add(registerItem);
                }

            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ApplicationException($"{excp.Message} on row = {index}");
            }
            finally
            {
                excelAppWorkbook?.Close(false);
                Marshal.ReleaseComObject(excelAppWorkbook);
            }
            return list;
        }

        /// <summary>
        /// Обработка excel range по блокам
        /// </summary>
        /// <param name="range"></param>
        /// <param name="pageSize"></param>
        /// <param name="countColumns"></param>
        /// <returns></returns>
        internal IEnumerable GetBlockData( Range range, int pageSize, int countColumns )
        {
            int maxRow = range.Rows.Count;
            int maxCols = Math.Min(range.Columns.Count, countColumns);
            int countBlock = maxRow / pageSize;

            for ( int i = 0; i <= countBlock; i++ )
            {
                int beginRow = i * pageSize;
                int size = Math.Min(maxRow - beginRow, pageSize);
                var dim = range.Range[range.Cells[beginRow + 1, 1], range.Cells[beginRow + size, maxCols]];
                yield return new { dim, size };
            }
        }

        /// <summary>
        /// Завантаження  Excel в список List<List<string>>
        /// </summary>
        /// <param name="FileName">Повній шлях до файлу</param>
        /// <param name="countCols">Кількість колонок данних які будуть імпортуватися</param>
        /// <returns></returns>
        public List<List<string>> ReadData(string FileName, int countCols = 10)
        {
            // TODO: extract OpenWorkbook(), CloseWorkbook() methods
            bool percentTypeChecked = false;
            int numberColumnPercent = 0;

            var list = new List<List<string>>();
            int i = 0, iter = 1;

            Excel.Workbook excelAppWorkbook = null;
            try
            {
                excelAppWorkbook = GetApp().Workbooks.Open(FileName, 0, true, 5, null, null, false,
                    Excel.XlPlatform.xlWindows, null, null, null);
                var excelAppWorksheets = excelAppWorkbook.Worksheets;
                var excelSheet = (Excel.Worksheet)excelAppWorksheets.Item[1];

                Excel.Range excelRange = excelSheet.UsedRange;

                int maxCol;
                int maxRow;

                maxCol = Math.Min(excelRange.Columns.Count, countCols);
                maxRow = excelRange.Rows.Count;
                // 17-05-2019 блочна обробка excel

                // var dim = ((Range)excelRange.Range[excelRange.Cells[1,1], excelRange.Cells[maxRow, countCols]]).Value;
                foreach (dynamic item in GetBlockData(excelRange, 1000, countCols))
                {
                    dynamic dim = item.dim.Value;
                    int rows = item.size;
                    
                    // перевірити чи в exel % формат по всіх стовбцях
                    if (!percentTypeChecked)
                    {
                        for (byte k = 1; k <= maxCol; k++)
                        {
                            // перший запис, всі стовбці
                            var format = ((Range)item.dim.Cells[1, k]).NumberFormat;
                            if (string.Equals(format, PercentFormat))
                            {
                                numberColumnPercent = k;
                                break;
                            }
                        }
                        percentTypeChecked = true;
                    }

                    //for (i = 1; i <= maxRow; i++)
                    for (i = 1; i <= rows; i++, iter++)
                    {
                        //if (dim?[i, 1] == null)
                        //    continue;

                        if (!(dim?[i, 1] is double))
                            continue;

                        // changed
                        // Патлякевич 10-05-19
                        //if (!(double.TryParse(dim[i, 1].ToString(), out double tmp)))
                        //    continue;

                        var rowList = new List<string>();

                        for (var j = 1; j <= maxCol; j++)
                        {
                            // якщо numberColumnPercent != 0, пошук стовбця з % форматом 
                            if (j == numberColumnPercent)
                            {
                                rowList.Add(GetFirst(dim[i, j] * 100));
                                continue;
                            }

                            //var format = ((Range)item.dim.Cells[i, j]).NumberFormat;
                            //if (string.Equals(format, PercentFormat))
                            //{
                            //    rowList.Add(GetFirst(dim[i, j] * 100));
                            //    continue;
                            //}

                            rowList.Add(GetFirst(dim[i, j]));
                        }

                        list.Add(rowList);
                    }
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ApplicationException($"{excp.Message} on row = {iter}");
            }
            finally
            {
                if ( excelAppWorkbook != null )
                {
                    excelAppWorkbook.Close(false);
                    Marshal.ReleaseComObject(excelAppWorkbook);
                }
            }
            return list;
        }
    }
}
