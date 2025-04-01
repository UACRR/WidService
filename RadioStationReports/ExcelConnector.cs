using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;       //microsoft Excel 14 object in references-> COM tab


namespace RadioStationReports
{
    public class ExcelConnector
    {
        public class OutputReportRowData
        {
            public int LineNr { get; set; }
            public string FoundIn { get; set; }
            public string FoundCde { get; set; }
            public string Share { get; set; }
        }

        public class ReportRow
        {
            public string Name { get; set; }
            public string Performer { get; set; }
        }

        public void SaveReport(string inputFileFullName, string outputFileFullName, int reportId)
        {
            var data = new List<OutputReportRowData>();
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandText = @"
                    select 
	                      t1.LineNr
	                    , t2.FoundIn
	                    , case 
		                    when t2.FoundIn = 'M' then t2.ObjId
		                    when t2.FoundIn = 'W' then t2.Wic
		                    else null
		                    end as FoundCde
	                    , t2.Share
                    from ReportLines t1
                        join Works t2 on t1.WorkId = t2.Id
                    where t1.ReportId = @reportId
                ";
                cmd.Parameters.AddWithValue("@reportId", reportId);
                using var r = cmd.ExecuteReader();
                while(r.Read())
                {
                    data.Add(new OutputReportRowData
                    {
                        LineNr = r.GetInt32(0),
                        FoundIn = r.IsDBNull(1) ? "" : r.GetString(1),
                        FoundCde = r.IsDBNull(2) ? "" : r.GetInt32(2).ToString(),
                        Share = r.IsDBNull(3) ? "" : r.GetDecimal(3).ToString(),
                    });
                }
            });

            File.Copy(inputFileFullName, outputFileFullName, true);

            //Create COM Objects. Create a COM object for everything that is referenced
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(outputFileFullName);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = (Excel._Worksheet)xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            var cell = (Excel.Range)xlWorksheet.Cells[3, 7];
            cell.Value2 = "Знайдено в БД";

            cell = (Excel.Range)xlWorksheet.Cells[3, 8];
            cell.Value2 = "Код";

            cell = (Excel.Range)xlWorksheet.Cells[3, 9];
            cell.Value2 = "Проценти";

            data.ForEach(x =>
            {
                cell = (Excel.Range)xlWorksheet.Cells[x.LineNr, 7];
                cell.Value2 = x.FoundIn;

                cell = (Excel.Range)xlWorksheet.Cells[x.LineNr, 8];
                cell.Value2 = x.FoundCde;

                cell = (Excel.Range)xlWorksheet.Cells[x.LineNr, 9];
                cell.Value2 = x.Share; ;
            });

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
            xlWorkbook.Save();
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
