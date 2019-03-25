using System;
using System.Linq;
using System.Windows.Forms;

namespace PartnersWorkplace
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var partnersWorkplace = new PartnersWorkplace();
            Application.Run(partnersWorkplace);
        }
    }
}