using System;
using System.Windows.Forms;
using WebAPIConnector;

namespace ipsAnketaRightHolder
{
    static class Program
    {
        private static readonly ApiConnector connector = new ApiConnector("http://localhost:54867/");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new AnketaCompanyView();
            var model = new ModelCompany();
            var presenter = new AnketaCompanyPresenter(view, model, 139);

            Application.Run(view);
        }
    }
}