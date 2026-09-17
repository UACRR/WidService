using System;
using System.Threading;
using System.Threading.Tasks;
using IpiUpdatesLib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SharedLib;
using WidAdminLib;
using static WidReplicationServiceLib.IWidReplicationService;

namespace IpiReplSvc.Services
{
    public class IpiTasksRunnerService : BackgroundService
    {
        public static EventWaitHandle taskAddedHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
        public IpiTasksRunnerService(ILoggerFactory loggerFactory,
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
            Logger.WriteLine("TasksRunnerService is starting.");

            stoppingToken.Register(() => Logger.WriteLine("WidTasksRunnerService is stopping."));

            var thread = new Thread(() =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    Logger.WriteLine("TasksRunnerService is executing next task.");
                    TryCatch.Run(() =>
                    {
                        var runner = new TaskRunner();
                        //runner.WidTaskCompleted += Runner_WidTaskCompleted;
                        switch (runner.RunPendingTask())
                        {
                            case TaskRunner.TaskResult.NoTasks:
                                taskAddedHandle.WaitOne(TimeSpan.FromHours(1));
                                break;
                            case TaskRunner.TaskResult.Completed:
                                Thread.Sleep(TimeSpan.FromSeconds(1));
                                break;
                            case TaskRunner.TaskResult.Failed:
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
            IpiTasksPlannerService.taskStatusChangedHandle.Set();
        }
    }
}
