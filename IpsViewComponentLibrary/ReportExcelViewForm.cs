using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using Telerik.WinControls;
using Excel = Microsoft.Office.Interop.Excel;

namespace IpsViewComponentLibrary
{
    public partial class ReportExcelViewForm : Telerik.WinControls.UI.RadForm
    {
        private readonly string _filePath;
        private List<RegisterItem> datasource = new List<RegisterItem>();

        public string TitleReport
        {
            get => lblTitle.Text.Remove(0,5);
            set => lblTitle.Text = "Звіт " + value;
        }

        public ReportExcelViewForm()
        {
            InitializeComponent();
        }

        public ReportExcelViewForm(string pathString)
        {
            InitializeComponent();
            _filePath = pathString;
            ExcelOpen();
        }

        private void ExcelOpen()
        {
            Excel.Application excelApp = null;
            Excel.Workbook excelAppWorkbook = null;
            try
            {
                excelApp = new Excel.Application();
                excelApp.Visible = false;
                excelAppWorkbook = excelApp.Workbooks.Open(_filePath, 0, true, 5, null, null, false,
                    Excel.XlPlatform.xlWindows,null,null,null);
                var excelAppWorksheets = excelAppWorkbook.Worksheets;
                var excelSheet = (Excel.Worksheet) excelAppWorksheets.Item[1];
                
                Excel.Range excelRange = excelSheet.UsedRange;

                int maxCol;
                int maxRow;

                try
                {
                    maxCol = excelRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;
                    maxRow = excelRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
                }
                catch (Exception e)
                {
                    maxCol = excelRange.Columns.Column;
                    maxRow = excelRange.Rows.Row;
                }

                var dim = excelRange.Value;
                //excelRange.Offset[0, 0].Value
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
                    registerItem.DurationUse =  DateTime.FromOADate((double)dim[i, 8]).TimeOfDay;
                    

                    datasource.Add(registerItem);
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (excelAppWorkbook != null)
                {
                    excelAppWorkbook.Close(false);
                    Marshal.ReleaseComObject(excelAppWorkbook);
                }

                excelApp?.Quit();
            }

            SetGridDataSource();
        }

        private void SetGridDataSource()
        {
            gvReportContentView.DataSource = datasource;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TitleReport);
        }
    }
}
