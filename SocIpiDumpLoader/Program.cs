using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SocIpiDumpLoader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Started");
            var ipiDumpLoader = new IpiDumpLoader();
            ipiDumpLoader.IpiFtpUrl             = "ftp.suisa.ch";
            ipiDumpLoader.IpiFtpPort            = 22;
            ipiDumpLoader.IpiFtpLogin           = "UACRR";
            ipiDumpLoader.IpiFtpPassword        = "S0c-74084lXY-?";
            ipiDumpLoader.IpiFtpUseSftp         = true;
            ipiDumpLoader.IpiFtpUseSsl          = false;
            ipiDumpLoader.CompleteIpiDir        = "IPI/IPI_Pub/Complete_IPI";
            ipiDumpLoader.CompleteIpiDate       = new DateTime(2025, 08, 30);
            ipiDumpLoader.LocalWorkFilesDir     = "D:/Tmp";


            ipiDumpLoader.ResetDatabase();
        }
    }
}
