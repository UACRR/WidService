using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Helpers.BalanceShares(new List<string>());
            //return;
            Logger.Init();
            try
            {
                Logger.WriteLine("Staring");
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //var m = new RadioPreSearchManager();
                // m.LoadReport(@"D:\UACRR\Çâ³òè ðàä³î\Çâ³ò_ÀÒÎËË_ÓÀÀÑÏ_1 êâ. 2023.xlsx");
                //return;

                //var excelConnector = new ExcelConnector();
                //excelConnector.SaveReport(@"D:\UACRR\Çâ³òè ðàä³î\Âèõ³äí³\Çâ³ò_ÀÐÒ_ÓÀÀÑÏ_1 êâ. 2023.xlsx");
                //return;

                /*
                Logger.WriteLine("Loading Configuration");
                Configuration.Load();
                Logger.WriteLine("Running main form");
                var form = new FormSearch();
                    form.SetNamePerformer("Novorichna", 
                    "Liliia Ostapenko/Lileia",
                    x => MessageBox.Show(x));                
                Application.Run(form);
                */
                
                Logger.WriteLine("Loading Configuration");
                Configuration.Load();
                //Application.Run(new FormMainReports());
                Application.Run(new FormMainIntegrated());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
