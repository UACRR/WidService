using ipsAnketaRightHolder.Data;
using ipsmedserviceapp.Model;
using System;
using System.Linq;
using System.Windows.Forms;
using WebAPIConnector;

namespace ipsAnketaRightHolder
{
    static class Program
    {
        private static readonly ApiConnector connector = new ApiConnector("http://localhost:54867/");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //CustomerModel model = new CustomerModel();
            //model.AnketaCompany.Add(new AnketaCompanyModel {
            //    ShortName = "Short name",
            //    FaAddress = "Fact address"
            //});

            //AnketaCompanyView view = new AnketaCompanyView();
            //new AnketaCompanyPresenter(model, view);

            var customer = connector.GetItemById<Customer>("api/rh/detail", "139");
            AnketaCompanyView view = new AnketaCompanyView();
            //view.SetData(customer);

            Application.Run(view);
        }
    }
}