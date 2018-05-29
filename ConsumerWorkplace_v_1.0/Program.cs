using ipsFormsDesign.Services;
using System;
using System.Linq;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConsumerWorkplace form = new ConsumerWorkplace();
            ConsumerService model = new ConsumerService();
            FormPresenter control = new FormPresenter(form, model);

            Application.Run(form);
        }
    }
}