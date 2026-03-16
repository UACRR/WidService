using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidSubmit
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Helpers.DecompressFile(@"D:\Tmp\WID2023040708242611300140.021.gz", @"D:\Tmp\WID2023040708242611300140.021");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
            //Application.Run(new FormTest());
            //Application.Run(new FormSubmissionRightHolders());
        }
    }
}
