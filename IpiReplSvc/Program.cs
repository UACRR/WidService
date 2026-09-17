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

namespace IpiReplSvc
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IpiUpdatesLib.Logger.SetRootPath(@"D:\UACRR\WID_Service\ReplicationWorkFiles\Ipi");
            IpiUpdatesLib.Logger.SetSubFolder("Log");
            var service =  new IpiDomainService();
            service.ApplyFileDomains();
            return;
            var runner = new TaskRunner();
            runner.RunPendingTask();
            return;
            var exeFileFullName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var rootPath = System.IO.Path.GetDirectoryName(exeFileFullName);
            Logger.SetRootPath(Path.Combine(rootPath, "Log"));
            Logger.SetSubFolder("IpiReplSvc");
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
                    services.AddHostedService<Services.IpiTasksPlannerService>();
                    services.AddHostedService<Services.IpiTasksRunnerService>();
                });
    }
}
