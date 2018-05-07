using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsmedserviceapp.Model;
namespace ipsTestExp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new MainForm();
            var mainModel = new MainModel();
            var presenter = new Presenter(form, mainModel, 139);
            Application.Run(form);
        }
    }
}
