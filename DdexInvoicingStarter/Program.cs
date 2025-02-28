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
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new FormTraceRoyaltyCalc());
                //Application.Run(new FormDspResourceAnalyser());

                Application.Run(new DdexInvoicingForm());

                //Application.Run(new FormMwSearch());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // Application.Run(new FormMwSearch());
        }
    }
}
