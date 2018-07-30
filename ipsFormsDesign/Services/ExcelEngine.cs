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

        public ExcelEngine()
        {
            GetApp().GetAwaiter();
        }

        ~ExcelEngine()
        {
            lock (this)
                excelApp?.Quit();
            excelApp = null;
        }

        private async Task<Excel.Application> GetApp()
        {
            return await Task.Run(() =>
            {
                lock (this)
                {
                    if (excelApp != null)
                        return excelApp;
                    excelApp = new Excel.Application();
                    return excelApp;
                }
            });
        }

        private string GetFirst( object sors, int length )
        {
            if (sors == null)
                return string.Empty;

            var sorsStr = sors.ToString().Trim();
            return sorsStr.Substring(0, Math.Min(sorsStr.Length, length));
        }
        public List<RegisterItem> GetReportItems(string FileName)
        {
            Excel.Workbook excelAppWorkbook = null;
            List<RegisterItem> list = new List<RegisterItem>();
            try
            {

                excelAppWorkbook = Task.Run(() => GetApp()).GetAwaiter().GetResult().Workbooks.Open(FileName, 0, true, 5, null, null, false,
                Excel.XlPlatform.xlWindows, null, null, null);
                var excelAppWorksheets = excelAppWorkbook.Worksheets;
                var excelSheet = (Excel.Worksheet)excelAppWorksheets.Item[1];


                Excel.Range excelRange = excelSheet.UsedRange;
                // excelRange.EntireColumn.NumberFormat = "@";

                int maxCol;
                int maxRow;

                try
                {
                    maxCol = excelRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;
                    maxRow = excelRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
                }
                catch (Exception)
                {
                    maxCol = excelRange.Columns.Column;
                    maxRow = excelRange.Rows.Row;
                }

                var dim = excelRange.Value;
                int regitemid = 0;
                TimeSpan curTime;

                // RegisterItem[] newItems = new RegisterItem[maxRow];
                double curDouble;

                for (int i = 1; i <= maxRow; i++)
                {
                    if (dim?[i, 1] == null) continue;
                    if (!(dim?[i, 1] is double)) continue;

                    // RegisterItem registerItem = newItems[regitemid];
                    RegisterItem registerItem = new RegisterItem
                    {
                        RegIitemId = 1 + regitemid++,
                        CategoryCode = 0, //parse
                        ModifyLogin = null, //parse
                                            //                     registerItem.RegIitemId = Convert.ToInt32(dim[1, 1]);
                        ItemName = GetFirst(dim[i, 2], 100 ),
                        Performer = GetFirst(dim[i, 3], 100),
                        AuthorMusic = GetFirst(dim[i, 4], 100),
                        AuthorText = GetFirst(dim[i, 5], 100),
                        CountUse = Convert.ToInt32(dim[i, 7]),
                        CodeItem = 1 // 1   Звичайний розподіл 
                };
                    try
                    {
                        curTime = TimeSpan.FromDays(Convert.ToDouble(dim[i, 6]));
                        registerItem.DurationItem = curTime;
                        curTime = TimeSpan.FromDays(Convert.ToDouble(dim[i, 8]));
                        registerItem.DurationUse = curTime;
                        registerItem.Ticks = (int)(curTime.Ticks / 10000);
                    }
                    catch
                    {
                        registerItem.DurationItem = new TimeSpan(0);
                        registerItem.DurationUse = new TimeSpan(0);
                        registerItem.Ticks = 0;
                    }


                    list.Add(registerItem);
                }

            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<RegisterItem>();
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
