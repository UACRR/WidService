using ipsFormsDesign.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary;

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
            ConsumerWorkplace form = new ConsumerWorkplace(TypeRights.All);
            ConsumerService model = new ConsumerService();
            FormPresenter control = new FormPresenter(form, model);
            form.WindowState = FormWindowState.Maximized;
            Application.Run(form);

            //LoadCabinet(form.ReturnCustomer());

            //LoadTest();
        }

        private static void LoadCabinet(Customer oo)
        {
            ConsumerCabinet f = new ConsumerCabinet();
            f.WindowState = FormWindowState.Maximized;
            ConsumerService m = new ConsumerService();
            FormPresenter control = new FormPresenter(f, m);
            f.SetData(oo);
            Application.Run(f);
        }

        private static void LoadTest()
        {
            TestForm test = new TestForm();
            Application.Run(test);
        }
    }
}