using IpsViewComponentLibrary.Utilities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace TestControls
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DialogService ds = new DialogService();
            try
            {
                Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new MainForm());
                Application.Run(new WpfControls());
                //Application.Run(new GridTestForm());

            }
            catch( Exception ex )
            {
                ds.ShowError("Помилка запуску додатку, зверніться до адміністратора",ex.Message);
            }
        }
    }
}