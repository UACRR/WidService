using System;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace RadioStationReports
{
    public static class Helpers
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public delegate void Body(SqlCommand cmd);
        public delegate void ExcelBody(_Worksheet xlWorksheet);

        public static void RunSql(Body body)
        {
            var connString = ConfigurationManager.ConnectionStrings["RadioStationReports"].ConnectionString;
            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using(var cmd = conn.CreateCommand())
                    {
                        body(cmd);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }
        public static void RunSqlT(Body body)
        {
            var connString = ConfigurationManager.ConnectionStrings["RadioStationReports"].ConnectionString;
            SqlTransaction tran = null;
            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = tran;
                        body(cmd);
                        tran.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                if(tran != null)
                {
                    tran.Rollback();
                }
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public static void CreateExcelFile(string fileFullName, ExcelBody body)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
           Workbook xlWorkbook = xlApp.Workbooks.Add();
           _Worksheet xlWorksheet = xlWorkbook.ActiveSheet;

            body(xlWorksheet);

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.SaveAs(fileFullName);
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            //xlApp.Quit();
            //Marshal.ReleaseComObject(xlApp);

            // Have to kill the process forcefully
            uint processId = 0;
            GetWindowThreadProcessId(new IntPtr(xlApp.Hwnd), out processId);
            var proc = Process.GetProcessById((int)processId);
            proc.Kill();
        }

        public static void ReadExcelFile(string fileFullName, ExcelBody body)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open(fileFullName);
           _Worksheet xlWorksheet = xlWorkbook.Sheets[1];

            body(xlWorksheet);

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            //xlApp.Quit();
            //Marshal.ReleaseComObject(xlApp);

            // Have to kill the process forcefully
            uint processId = 0;
            GetWindowThreadProcessId(new IntPtr(xlApp.Hwnd), out processId);
            var proc = Process.GetProcessById((int)processId);
            proc.Kill();
        }

        public static void UpdateExcelFile(string inputFileFullName, string outputFileFullName, ExcelBody body)
        {
            File.Copy(inputFileFullName, outputFileFullName, true);
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open(outputFileFullName);
           _Worksheet xlWorksheet = xlWorkbook.Sheets[1];

            body(xlWorksheet);

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background
            Marshal.FinalReleaseComObject(xlWorksheet);

            //close and release
            //xlWorkbook.SaveAs(outputFileFullName);
            xlWorkbook.Save();
            xlWorkbook.Close();
            Marshal.FinalReleaseComObject(xlWorkbook);
            //quit and release
            //xlApp.Quit();
            //Marshal.FinalReleaseComObject(xlApp);

            // Have to kill the process forcefully
            uint processId = 0;
            GetWindowThreadProcessId(new IntPtr(xlApp.Hwnd), out processId);
            var proc = Process.GetProcessById((int)processId);
            proc.Kill();
        }

        public static void UpdateExcelFile(string inputFileFullName, ExcelBody body)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open(inputFileFullName);
           _Worksheet xlWorksheet = xlWorkbook.Sheets[1];

            try
            {
                body(xlWorksheet);
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.FinalReleaseComObject(xlWorksheet);
                xlWorkbook.Save();
                xlWorkbook.Close();
                Marshal.FinalReleaseComObject(xlWorkbook);
                //quit and release
                //xlApp.Quit();
                //Marshal.FinalReleaseComObject(xlApp);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                // Have to kill the process forcefully
                uint processId = 0;
                GetWindowThreadProcessId(new IntPtr(xlApp.Hwnd), out processId);
                var proc = Process.GetProcessById((int)processId);
                proc.Kill();
            }
        }

        public static bool ConfirmAction(string prompt)
        {
            return DialogResult.Yes == MessageBox.Show(prompt, "Звіти Радіостанцій", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        public static void ShowError(string prompt)
        {
            MessageBox.Show(prompt, "Звіти Радіостанцій", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccess(string prompt)
        {
            MessageBox.Show(prompt, "Звіти Радіостанцій", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static decimal BalanceShares(List<double?> sharesInitial, out List<double?> sharesRes)
        {
            // Test values
            /*sharesInitial = new List<string>()
            {
"7.5",
"17.5",
"8.33",
"8.33",
"34.17",
"3.75",
"3.75",
"8.32",
"7.25",
"1.08",
            };*/

            var sharesInt = new List<int>();
            sharesInitial.ForEach(x => {
                sharesInt.Add(Convert.ToInt32(x * 10000));
            });

            var sum = sharesInt.Sum();
            var delta = 10000 - sum;

            if(sum == 0 || delta == 0)
            {
                sharesRes = sharesInitial;
                return (sum / 100);
            }

            var cntPositive = sharesInt.Count(x => x > 0);
            var retValInt = new List<int>();
            sharesInt.ForEach(x =>
            {
                retValInt.Add(x * 10000 / sum);
            });

            var sum1 = retValInt.Sum();
            var delta1 = 10000 - sum1;
            var retValInt1 = new List<int>();
            var cnt = 0;
            foreach(var x in retValInt)
            {
                if(x  > 0)
                {
                    retValInt1.Add(x + (cnt < delta1 ? 1 : 0));
                    cnt++;
                }
                else
                {
                    retValInt1.Add(0);
                }
            };

            var sum2 = retValInt1.Sum();

            var retVal = new List<double?>();
            retValInt1.ForEach(x =>
            {
                retVal.Add(x / 10000.0);
            });

            sharesRes = retVal;

            return (sum2 / 100);
        }
    }
}
