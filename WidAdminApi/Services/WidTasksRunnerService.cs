using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SharedLib;
using WidAdminLib;
using static WidReplicationServiceLib.IWidReplicationService;

namespace WidAdminApi.Services
{
    public class WidTasksRunnerService : BackgroundService
    {
        public static EventWaitHandle taskAddedHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
        public WidTasksRunnerService(ILoggerFactory loggerFactory,
            IConfiguration configuration)
        {
            //Logger = loggerFactory.CreateLogger<WidTasksRunnerService>();
            Configuration = configuration;
        }

        //public ILogger Logger { get; }
        private IConfiguration Configuration { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //return;
            Logger.WriteLine("WidTasksRunnerService is starting.");

            stoppingToken.Register(() => Logger.WriteLine("WidTasksRunnerService is stopping."));

            var thread = new Thread(() =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    Logger.WriteLine("WidTasksRunnerService is executing next task.");
                    TryCatch.Run(() =>
                    {
                        var runner = new WidTaskRunner();
                        runner.WidTaskCompleted += Runner_WidTaskCompleted;
                        switch (runner.RunPendingTask())
                        {
                            case WidTaskRunner.TaskResult.NoTasks:
                                taskAddedHandle.WaitOne(TimeSpan.FromHours(1));
                                break;
                            case WidTaskRunner.TaskResult.Completed:
                                Thread.Sleep(TimeSpan.FromSeconds(1));
                                break;
                            case WidTaskRunner.TaskResult.Failed:
                                Thread.Sleep(TimeSpan.FromSeconds(10000));
                                break;
                        }
                        //await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);}
                    },  ex =>
                    {
                        Logger.WriteLine($"ERROR: {ex.Message}");
                    });
                }
            }); 
            thread.Start();

       }

        private void Runner_WidTaskCompleted(object sender, EventArgs e)
        {
            WidTasksPlannerService.taskStatusChangedHandle.Set();
        }
    }
}
