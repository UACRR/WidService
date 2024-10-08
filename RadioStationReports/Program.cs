using System;
using System.Collections.Generic;
using System.Linq;
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

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var m = new RadioPreSearchManager();
            // m.LoadReport(@"D:\UACRR\«‚≥ÚË ‡‰≥Ó\«‚≥Ú_¿“ŒÀÀ_”¿¿—œ_1 Í‚. 2023.xlsx");
            //return;

            //var excelConnector = new ExcelConnector();
            //excelConnector.SaveReport(@"D:\UACRR\«‚≥ÚË ‡‰≥Ó\¬Ëı≥‰Ì≥\«‚≥Ú_¿–“_”¿¿—œ_1 Í‚. 2023.xlsx");
            //return;

            Configuration.Load();
            Application.Run(new FormMainReports());
        }
    }
}
