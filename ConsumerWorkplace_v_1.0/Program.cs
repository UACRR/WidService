using ipsFormsDesign.Services;
using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary;
using IpsViewComponentLibrary.Utilities;

namespace ConsumerWorkplace_v_1._0
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var objectrightService = new ObjectRightService();
            IpsGlobal.SetObjectRightDictionaries(objectrightService.GetDictionary());
            var rightholderService = new RightholderService();
            IpsGlobal.SetAnketaDictionaties(rightholderService.GetDictionary());
            ConsumerWorkplace form = new ConsumerWorkplace(TypeRights.All);
            ConsumerService model = new ConsumerService();
            FormPresenter control = new FormPresenter(form, model);
            form.WindowState = FormWindowState.Maximized;
            form.AutoScaleMode = AutoScaleMode.Font;
            Application.Run(form);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs exceptionEventArg)
        {
            HandleException((Exception)exceptionEventArg.ExceptionObject);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs exceptionEventArg)
        {
            HandleException(exceptionEventArg.Exception);
        }

        private static void HandleException(Exception e)
        {
            var message = String.Format("Вибачте, сталася помилка. \r\n{0}\r\nЗверніться в службу підтримки.", e.Message);

            var dialogService = new DialogService();
            dialogService.ShowError(message, e.ToString());

            Application.Exit();
        }
    }
}