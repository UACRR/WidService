using SmRoPermitClientLib;
using SmRoPermitAdmin;
using SmRoPermitCommonLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmRoPermitAdmin
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] arguments)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string credentials;
            try
            {
                credentials = PermitClient.Login(ConfigurationManager.AppSettings["BaseUri"], arguments);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{Translator.GetText(ex.Message)}{Translator.GetText("WILL_TERMINATE")}", Translator.GetText("ADMIN_CONSOLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            Application.Run(new FormPermitAdminConsole(credentials));
            //Application.Run(new FormLogin());
        }
    }
}
