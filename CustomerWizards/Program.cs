using System;
using System.Linq;
using System.Windows.Forms;

namespace CustomerWizards
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

            var view = new WizardCustomerView();
            var model = new WizardCustomerModel();
            var presenter = new WizardCustomerPresenter(view, model, 139);

            Application.Run(view);
        }
    }
}