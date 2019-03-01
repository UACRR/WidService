using ipsFormsDesign.Data;
using ipsFormsDesign.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace sysAdminwp
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
            var rightholderService = new RightholderService();
            IpsGlobal.SetAnketaDictionaties(rightholderService.GetDictionary());
            Application.Run(new DictionaryForm());
        }
    }
}