using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WidAdminLib;

namespace IpiReplSvc.Services
{
    public class WidTasksPlannerService : BackgroundService
    {
        public static EventWaitHandle taskStatusChangedHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
        public WidTasksPlannerService(ILoggerFactory loggerFactory,
            IConfiguration configuration)
        {
            //Logger = loggerFactory.CreateLogger<WidTasksRunnerService>();
            Configuration = configuration;
        }

        //public ILogger Logger { get; }
        private IConfiguration Configuration { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.WriteLine("WidTasksPlannerService is starting.");

            stoppingToken.Register(() => Logger.WriteLine("WidTasksPlannerService is stopping."));

            var thread = new Thread(() =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    Logger.WriteLine("WidTasksPlannerService is planning next tasks.");
                    try
                    {
                        var planner = new WidTaskPlanner();
                        if(planner.PlanTasks())
                        {
                            WidTasksRunnerService.taskAddedHandle.Set();
                        }
                        //Thread.Sleep(TimeSpan.FromSeconds(10));
                        taskStatusChangedHandle.WaitOne(TimeSpan.FromHours(1));
                        //Thread.Sleep(TimeSpan.FromSeconds(10));
                        //await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                    }
                    catch(Exception ex)
                    {
                        Logger.WriteLine($"ERROR: {ex.Message}");
                    }
                }
            });
            thread.Start();
        }
    }
}
