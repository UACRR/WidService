using ipsFormsDesign.Data;
using ipsFormsDesign.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RightholderWorkplace
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

            var objectrightService = new ObjectRightService();
            IpsGlobal.SetObjectRightDictionaries(objectrightService.GetDictionary());

            RightholderWorkplace form = new RightholderWorkplace();
            RightholderService service = new RightholderService();
            RightholderWorkplacePresenter control = new RightholderWorkplacePresenter(form, service);

            Application.Run(form);
        }
    }
}