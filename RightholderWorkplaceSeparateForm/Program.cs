using RightholderWorkplaceSeparateForm.Services;
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

            var viewStack = ViewStack.GetInstance();
            var view = new MainView();
            var presenter = new MainViewPresenter(view, viewStack);
            presenter.Run();
        }
    }
}