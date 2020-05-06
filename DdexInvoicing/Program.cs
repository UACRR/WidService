using InvoicingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicing
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*
            FormDdexInvoicing form = new FormDdexInvoicing();
            form.ddexReportId = 27;
            form.ddexReportingPeriodId = 21;
            Application.Run(form);*/

            
            //Meta.Load();
            //DdexDownloadActions.Init();
            Application.Run(new DdexInvoicingForm());

            //Application.Run(new FormExceptionSets());

            //Application.Run(new FormExceptionSet(13));
            //Application.Run(new FormObjectChooser());
        }
    }
}
