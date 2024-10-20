using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Configuration.Install;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using IpiUpdatesLib;
//using SampleApp.Services;

namespace WidAdminApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            /*
           var ipiInitialLoader = new IpiInitialLoader {
                IpiFtpUrl           = "ftp://ftp.suisa.ch"                   ,
                IpiFtpLogin         = "UACRR"                                ,
                IpiFtpPassword      = "S0c-74084lXY-?"                       ,
                CompleteIpiDir      = "/IPI/IPI_Pub/Complete_IPI/"           ,
                CompleteIpiDate     = new DateTime(2024, 08, 31)             ,
                UpdatesIpiDir       = "/IPI/download"                        ,
                UpdatesLastDate     = new DateTime(2024, 10, 17)             ,
                LocalWorkFilesDir   = @"d:\Tmp"                              ,
            };
            ipiInitialLoader.ResetDatabase();
            return;
            */
            /*
            var service = new WidReplicationServiceLib.WidReplicationService();
            service.ConnectionString = "Persist Security Info = False; User = OlegM; Password = 111111; Server = 193.178.146.103\\IPSDATA,60675";
            service.WidWorkFilesRootPath = @"D:\UACRR\WID_Service\ReplicationWorkFiles\Wid";
            service.RunWidUpdateFileApplyToDb("WID20240328225200399300.021", null);

            return;
            */
            var exeFileFullName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var rootPath = System.IO.Path.GetDirectoryName(exeFileFullName);
            Logger.SetRootPath(Path.Combine(rootPath, "Log"));
            Logger.SetSubFolder("WidAdminApi");
            Logger.WriteLine($"STARTING SERVICE");
            try
            {
                await CreateHostBuilder(args).Build().RunAsync();
            }
            catch(Exception ex)
            {
                Logger.WriteLine($"ERROR: {ex.Message}");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Services.WidTasksPlannerService>();
                    services.AddHostedService<Services.WidTasksRunnerService>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
