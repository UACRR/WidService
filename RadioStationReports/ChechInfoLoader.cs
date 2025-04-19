using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using static RadioStationReports.ChechInfoLoader;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace RadioStationReports
{
    public class ChechInfoLoader
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public class CheckInfoLine
        {
            public string Name {  get; set; }
            public string Performers {  get; set; }
            public int CheckValue {  get; set; }
        }

        private List<CheckInfoLine> _checkInfoLines;

        private void LoadCheckInfoFromWorkSheet(Worksheet xlWorksheet,
            int startRow, int nameColIdx, int performersColIdx, int checkValueColIdx)
        {
            Range xlRange = (Range)xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            var fromCell = (Range)xlWorksheet.Cells[1, 1];
            var toCell = (Range)xlWorksheet.Cells[rowCount, 5];
            var values = (object[,])xlWorksheet.get_Range(fromCell, toCell).Value2;

            var rowIdx = startRow;
            try
            {
                for( ; rowIdx <= rowCount; rowIdx++)
                {
                    var Name = Convert.ToString(values[rowIdx, nameColIdx]);
                    var Performers = Convert.ToString(values[rowIdx, performersColIdx]);
                    var CheckValue = Convert.ToInt32(values[rowIdx, checkValueColIdx]);

                    var checkInfoLine = new CheckInfoLine();
                    checkInfoLine.Name = Name;
                    checkInfoLine.Performers = Performers;
                    checkInfoLine.CheckValue = CheckValue;
                        
                    _checkInfoLines.Add(checkInfoLine);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void LoadCheckInfoFromWorkBook()
        {
            Application xlApp = null;
            Workbook xlWorkbook = null;
            var sheets = new List<Worksheet>();
            try
            {
                xlApp = new Application();
                xlWorkbook = xlApp.Workbooks
                    .Open(Path.Combine(Configuration.WorkFilesRootDir, "ВСІ РАДІО В ОДНІЙ ТАБЛИЦІ.xls"));

                _checkInfoLines = new List<CheckInfoLine>();

                LoadCheckInfoFromWorkSheet((Worksheet)xlWorkbook.Sheets[1], 2, 2, 3, 5);
                sheets.Add((Worksheet)xlWorkbook.Sheets[1]);

                LoadCheckInfoFromWorkSheet((Worksheet)xlWorkbook.Sheets[2], 2, 2, 3, 5);
                sheets.Add((Worksheet)xlWorkbook.Sheets[2]);

                LoadCheckInfoFromWorkSheet((Worksheet)xlWorkbook.Sheets[3], 3, 2, 3, 5);
                sheets.Add((Worksheet)xlWorkbook.Sheets[3]);

                LoadCheckInfoFromWorkSheet((Worksheet)xlWorkbook.Sheets[4], 3, 1, 1, 2);
                sheets.Add((Worksheet)xlWorkbook.Sheets[4]);

                LoadCheckInfoFromWorkSheet((Worksheet)xlWorkbook.Sheets[5], 2, 2, 3, 5);
                sheets.Add((Worksheet)xlWorkbook.Sheets[5]);

                LoadCheckInfoFromWorkSheet((Worksheet)xlWorkbook.Sheets[7], 2, 2, 3, 5);
                sheets.Add((Worksheet)xlWorkbook.Sheets[7]);

                LoadCheckInfoFromWorkSheet((Worksheet)xlWorkbook.Sheets[8], 2, 2, 3, 5);
                sheets.Add((Worksheet)xlWorkbook.Sheets[8]);

                LoadCheckInfoFromWorkSheet((Worksheet)xlWorkbook.Sheets[9], 2, 2, 3, 7);
                sheets.Add((Worksheet)xlWorkbook.Sheets[9]);

                LoadCheckInfoFromWorkSheet((Worksheet)xlWorkbook.Sheets[10], 2, 2, 3, 5);
                sheets.Add((Worksheet)xlWorkbook.Sheets[10]);

                Helpers.RunSql(cmd =>
                {
                    cmd.CommandText = @"
                        delete from CheckInfoFromWorkBook
                    ";
                    
                    var bu = new BulkUploadToSql();
                    bu.TableName = "CheckInfoFromWorkBook";
                    bu.conn = cmd.Connection;
                    bu.Init();

                    var id = 1;
                    _checkInfoLines.ForEach(x =>
                    {
                        var data = new List<object>();
                        data.Add(id++);
                        data.Add(x.Name);
                        data.Add(x.Performers);
                        data.Add(x.CheckValue);
                        bu.AddData(data);
                    });

                    bu.Flush();
                });

            }
            catch (Exception ex)
            {
            }
            finally
            {
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //release com objects to fully kill excel process from running in the background
                sheets.ForEach(x =>
                {
                    Marshal.ReleaseComObject((Worksheet)xlWorkbook.Sheets[1]);
                });

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                // Have to kill the process forcefully
                uint processId = 0;
                GetWindowThreadProcessId(new IntPtr(xlApp.Hwnd), out processId);
                var proc = Process.GetProcessById((int)processId);
                proc.Kill();
            }

        }
    }

}
