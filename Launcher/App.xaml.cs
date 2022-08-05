using System;
using System.Windows;
using IpsViewComponentLibrary.Utilities;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs exceptionEventArg)
        {
            HandleException((Exception)exceptionEventArg.ExceptionObject);
        }

        private static void HandleException(Exception e)
        {
            var message = $"Application was thrown unhandled exception! Send this message to developers! \r\n{e.Message}";
            new DialogService().ShowErrorByException(message, e.ToString());
        }
    }
}
