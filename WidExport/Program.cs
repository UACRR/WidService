using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidExport.Entities;

namespace WidExport
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //FileValidator.Validate(@"D:\UACRR\WID\Sources\WidService\WidExport\OutFiles\WID2023040708242611300140.021");
            //FileValidator.ValidateWorkNamesInMs();
            //return;
            //Tests.CreateInDb();
            //Tests.ReadWiaFromDb();
            //Tests.CreateSubmFile();
            //Tests.FillWidSubmWorkState();

            //var o = new RespFilePresenter(17, 875083);
            //var html = o.GetHtml();

            /*
            var service = new WidSubmGroupPreProcService();
            service.ProcessNames(6, false);
            return;
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new FormMain());
            //Application.Run(new FormWidSubmGroupChangedWorks());

        }
    }
}
