using System;
using System.Linq;
using System.Windows.Forms;

namespace ipsAnketaClient
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
            AnketaClientView form = new AnketaClientView();
            ConsumerModel model = new ConsumerModel();
            Presenter control = new Presenter(form,model,134);
            Application.Run(form);
        }
    }
}