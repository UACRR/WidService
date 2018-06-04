using System;
using System.Linq;
using System.Windows.Forms;

namespace RightholderWorkplaceSeparateForm
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

            var view = new MainView();
            var presenter = new MainViewPresenter(view);
            presenter.Run();
        }
    }
}