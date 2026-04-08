using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwrTools
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var fs = new CwrFileSplitter(@"D:\OlegM\CWR\Відправлені файли\CW250003140_000.V22", 10000);
            //fs.SplitFile();
            //return;

            MetaData.Load();
            CwrConfig.Load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormRightHolderRoles());
            Application.Run(new FormMain());
        }
    }
}
