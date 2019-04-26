using ipsFormsDesign.Model;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ipsFormsDesign.Services
{
    public class ExcelEngine
    {
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
                if(excelApp != null)
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

        private string GetFirst( object sors, int length = 0)
        {
            if (sors == null)
                return string.Empty;

            var sorsStr = sors.ToString().Trim();

            if (length != 0)
                sorsStr = sorsStr.Substring(0, Math.Min(sorsStr.Length, length));

            return sorsStr;
        }

        private TimeSpan GetDuration( object source)
        {
            if (source is string)
                return TimeSpan.Parse((string)source);
            if (source is double)
                return TimeSpan.FromDays((double)source);

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
                // excelRange.EntireColumn.NumberFormat = "@";

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
                    if (!(dim?[index, 1] is double)) continue;

                    // RegisterItem registerItem = newItems[regitemid];
                    RegisterItem registerItem = new RegisterItem
                    {
                        RegIitemId = 1 + regitemid++,
                        CategoryCode = 5, //parse
                        ModifyLogin = null, //parse
                                            //                     registerItem.RegIitemId = Convert.ToInt32(dim[1, 1]);
                        ItemName = GetFirst(dim[index, 2], 100 ),
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
                        registerItem.DurationUse = TimeSpan.FromTicks( curTime.Ticks  * registerItem.CountUse ?? 1 );
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
                throw new ApplicationException( $"{excp.Message} on row = {index}");    
            }
            finally
            {
                excelAppWorkbook?.Close(false);
                Marshal.ReleaseComObject(excelAppWorkbook);
            }
            return list;
        }

        public List<List<string>> ReadData(string FileName)
        {
            // TODO: extract OpenWorkbook(), CloseWorkbook() methods

            var list = new List<List<string>>();
            var i = 0;

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

                maxCol = excelRange.Columns.Count;
                maxRow = excelRange.Rows.Count;

                var dim = excelRange.Value;

                for (i = 1; i <= maxRow; i++)
                {
                    if (dim?[i, 1] == null) continue;
                    if (!(dim?[i, 1] is double)) continue;

                    var rowList = new List<string>();

                    for (var j = 1; j <= maxCol; j++)
                    {
                        rowList.Add(GetFirst(dim[i, j]));
                    }

                    list.Add(rowList);
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ApplicationException($"{excp.Message} on row = {i}");
            }
            finally
            {
                excelAppWorkbook?.Close(false);
                Marshal.ReleaseComObject(excelAppWorkbook);
            }
            return list;
        }
    }
}
