using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            IpiTests.LoadDumpFiles("ftp://ftp.suisa.ch", "UACRR", 
                "S0c-74084lXY-?", 
                "IPI/IPI_Pub/Complete_IPI/20240831",
                @"D:\UACRR\WID\IPI\FtpMirror\IPI\IPI_Pub\Complete_IPI",
                "Persist Security Info=False;Trusted_Connection=yes;Server=localhost;Initial Catalog = SocIpiTesting;");
            IpiTests.LoadDumpFiles("ftp://ftp.suisa.ch", "UACRR", 
                "S0c-74084lXY-?", 
                "IPI/IPI_Pub/Complete_IPI/20240831",
                @"c:\tmp",
                @"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocIpiTesting; Server=193.178.146.103\IPSDATA,60675");
            return;*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
