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
    class ExcelEngine
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

        public List<RegisterItem> GetReportItems(string FileName)
        {
            Excel.Workbook excelAppWorkbook = null;
            List<RegisterItem> list = new List<RegisterItem>();
            try
            {

                excelAppWorkbook = Task.FromResult(GetApp()).GetAwaiter().GetResult().Result.Workbooks.Open(FileName, 0, true, 5, null, null, false,
                Excel.XlPlatform.xlWindows, null, null, null);
                var excelAppWorksheets = excelAppWorkbook.Worksheets;
                var excelSheet = (Excel.Worksheet)excelAppWorksheets.Item[1];

                Excel.Range excelRange = excelSheet.UsedRange;

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
                for (int i = 1; i <= maxRow; i++)
                {
                    if (dim?[i, 1] == null) continue;

                    RegisterItem registerItem = null;
                    registerItem = new RegisterItem();
                    registerItem.CategoryCode = 0; //parse
                    registerItem.ModifyLogin = null; //parse
                    registerItem.RegIitemId = Convert.ToInt32(dim[1, 1]);
                    registerItem.ItemName = dim[i, 2]?.ToString();
                    registerItem.Performer = dim[i, 3]?.ToString();
                    registerItem.AuthorMusic = dim[i, 4]?.ToString();
                    registerItem.AuthorText = dim[i, 5]?.ToString();
                    registerItem.DurationItem = DateTime.FromOADate((double)dim[i, 6]).TimeOfDay;
                    registerItem.CountUse = Convert.ToInt32(dim[i, 7]);
                    registerItem.DurationUse = DateTime.FromOADate((double)dim[i, 8]).TimeOfDay;

                    list.Add(registerItem);
                }

            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
