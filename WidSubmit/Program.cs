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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
            //var form = new FormCorrectIpiInfo(318350, "", "", "СВІРСЬКИЙ АНДРІЙ БОРИСОВИЧ");
            //Application.Run(form);
            //Application.Run(new FormTestSubmWorkRespErr());
            //Application.Run(new FormTestUcSubmRightHolders());
            //Application.Run(new FormSubmissionRightHolders());
        }
    }
}
