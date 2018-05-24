using ipsFormsDesign.Controls;
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
            ConsumerModel model = new ConsumerModel();
            FormPresenter control = new FormPresenter(form, model);

            Application.Run(form);
        }
    }
}