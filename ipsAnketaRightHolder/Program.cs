using ipsAnketaRightHolder.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ipsAnketaRightHolder
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

            CustomerModel model = new CustomerModel();
            model.AnketaCompany.Add(new AnketaCompanyModel {
                ShortName = "Short name",
                FaAddress = "Fact address"
            });

            AnketaCompanyView view = new AnketaCompanyView();
            new AnketaCompanyPresenter(model, view);

            Application.Run(view);
        }
    }
}