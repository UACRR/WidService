using DdexInvoicing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicingStarter
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            var files = Directory.GetFiles(@"D:\IPS\DDEX_FILES\Deezer\InputFiles");
            files.OrderBy(x => x).ToList().ForEach(x =>
           {
               Console.WriteLine($"\"{Path.GetFileNameWithoutExtension(x).Split('_')[2]}\",");
           });
           */
            //try
            //{
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new FormAutoSearch(1496));
                //Application.Run(new FormDspResourceAnalyser());

                Application.Run(new DdexInvoicingForm());

                //Application.Run((new FormReportVsFoundWork()).SetWork(1510, 27581885, "2510CUA902677321319037172771"));
                //Application.Run((new FormReportVsFoundWork()).SetWork(32260192));

                //Application.Run(new FormMwSearch());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            // Application.Run(new FormMwSearch());
        }
    }
}
