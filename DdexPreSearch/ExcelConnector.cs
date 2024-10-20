using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace DdexPreSearch
{
    public class ExcelConnector
    {
        public class ReportRow
        {
            public string Name { get; set; }
            public string Performer { get; set; }
        }

        private List<ReportRow> _rows;

        public void LoadReport(string fileFullName, SqlCommand cmd)
        {
            ReadRows(fileFullName);
            InsertRows(cmd);
        }

        public void InsertRows(SqlCommand cmd)
        {
            try
            {
                cmd.CommandText = @"
                    insert RadioReportRows(name, performer)
                    values (@name, @performer)";
                _rows.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@name", x.Name);
                    cmd.Parameters.AddWithValue("@performer", x.Performer);
                    cmd.ExecuteNonQuery();
                });
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void ReadRows(string fileFullName)
        {
            _rows = new List<ReportRow>();

            //Create COM Objects. Create a COM object for everything that is referenced
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fileFullName);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 4; i <= rowCount; i++)
            {

                var cell = (Excel.Range)xlWorksheet.Cells[i, 1];
                var seqNrStr = Convert.ToString(cell.Value2);
                int seqNr;
                if(!int.TryParse(seqNrStr, out seqNr))
                {
                    break;
                }

                cell = (Excel.Range)xlWorksheet.Cells[i, 2];
                var name = cell.Value2;

                cell = (Excel.Range)xlWorksheet.Cells[i, 3];
                var performer = cell.Value2;

                _rows.Add(new ReportRow
                {
                    Name = name,
                    Performer = performer,
                });
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
