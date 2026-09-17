using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Pqc.Crypto.NtruPrime;
using SocFtpClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using static IpiUpdatesLib.IpiUpdatesDbContext;

namespace IpiUpdatesLib
{
    public class TaskPlanner
    {
        private IpiUpdatesDbContext _dbc;
        private RpnSettings _settings;
        private FtpClient _ftpClient;

        private int _seqNrJob;
        private int _seqNrTask;
        private int _seqNrStep;

        public TaskPlanner() {
            _dbc = new IpiUpdatesDbContext();
            _settings = _dbc.RpnSettings.Single();
            _ftpClient = new FtpClient(
                _settings.FtpUrl, 
                _settings.FtpLogin, 
                _settings.FtpPassword,
                _settings.FtpPort,
                _settings.FtpUseSftp,
                _settings.FtpUseSsl);
            _seqNrJob = _dbc.RpnJobs.Any() ? _dbc.RpnJobs.Max(x => x.SeqNr) : 0;
            _seqNrTask = _dbc.RpnJobTasks.Any() ? _dbc.RpnJobTasks.Max(x => x.SeqNr) : 0;
            _seqNrStep = _dbc.RpnJobTaskSteps.Any() ? _dbc.RpnJobTaskSteps.Max(x => x.SeqNr) : 0;
        }

        public bool PlanTasks()
        {
            if(!_dbc.RpnPeriods.Any())
            {
                PlanInitialTasks();
                PlanDailyTasks();
            }
            else
            {
                PlanDailyTasks();
            }
            return true;
        }

        private void PlanInitialTasks()
        {
            var completeIpiDir = _ftpClient
                .ReadDirectory(_settings.FtpDumpPath)
                .Where(x => char.IsDigit(x[0]))
                .OrderByDescending(x => x)
                .First();

            var per = new RpnPeriod {
                IpiCompleteDate = DateTime.ParseExact(completeIpiDir, "yyyyMMdd", CultureInfo.InvariantCulture),
                CreatedAt = DateTime.Now,
                RpnJobs = new List<RpnJob>
                {
                    CreateJobLoadDict(completeIpiDir),
                    CreateJobLoadIpi(completeIpiDir),
                    CreateJobApplyUpdates(),
                },
            };

            _dbc.Add(per);
            _dbc.SaveChanges();
            
        }

        private void PlanDailyTasks()
        {
            // Останній запланований файл
            var lastStep = _dbc.RpnJobTaskSteps
                .Where(x => 
                    x.RpnJobTask.RpnJobTaskTypeId == (int)RpnJobTaskTypeEnum.ApplyUpdateFile &&
                    x.RpnJobTaskStepTypeId == (int)RpnJobTaskStepTypeEnum.ApplyFile
                )
                .OrderByDescending(x => x.SeqNr)
                .FirstOrDefault();

            var periodStartDate = _dbc.RpnPeriods
                .OrderByDescending (x => x.IpiCompleteDate)
                .First()
                .IpiCompleteDate.ToString("yyyyMMdd");
            var startFileName = $"{periodStartDate}.EDI";

            var lastFileName = lastStep == null ? startFileName : lastStep.FileName;

            var files = _ftpClient.ReadDirectoryFiles(_settings.FtpUpdatesPath)
                .Where(x => string.Compare(x, lastFileName) > 0)
                .ToList();

            var job = _dbc.RpnJobs
                .Include(x => x.RpnJobTasks)
                .Single(x => x.RpnJobTypeId == (int)RpnJobTypeEnum.ApplyUpdates);

            files.ForEach(x =>
            {
                job.RpnJobTasks.Add(CreateTaskApplyUpdateFile (_settings.FtpUpdatesPath, x));
            });

            _dbc.SaveChanges();
        }

        private List<RpnJobTaskStep> CreateFileSteps(
            string remotePath,
            string remoteFileName,
            string localFileName
        )
        {
            var steps = new List<RpnJobTaskStep>();
            steps.Add(CreateFileStep(RpnJobTaskStepTypeEnum.DownloadFile, Path.Combine(remotePath, remoteFileName)));
            if(localFileName != remoteFileName)
            {
                steps.Add(CreateFileStep(RpnJobTaskStepTypeEnum.UnzipFile, remoteFileName));
                steps.Add(CreateFileStep(RpnJobTaskStepTypeEnum.DeleteZipFile, remoteFileName));
            }
            steps.Add(CreateFileStep(RpnJobTaskStepTypeEnum.ApplyFile, localFileName));
            steps.Add(CreateFileStep(RpnJobTaskStepTypeEnum.DeleteFile, localFileName));
            return steps;
        }

        private RpnJobTaskStep CreateFileStep (
            RpnJobTaskStepTypeEnum stepType,
            string fileName
        )   
        {
            return new RpnJobTaskStep { 
                SeqNr = ++_seqNrStep,
                RpnJobTaskStepTypeId = (int)stepType,
                FileName = fileName,
                ErrMsg = "",
                CreatedAt = DateTime.Now
            };
            
        }

        private RpnJobTask CreateTaskApplyDict ()
        {
            return new RpnJobTask
            {
                SeqNr = ++_seqNrTask,
                RpnJobTaskTypeId = (int)RpnJobTaskTypeEnum.ApplyDict,
                CreatedAt = DateTime.Now,
                RpnJobTaskSteps = CreateFileSteps(Path.Combine(_settings.FtpDumpPath, "Domains"), "DOMAINS.zip", "DOMAINS.EDI")
            };
        }

        private RpnJobTask CreateTaskApplyIpiFile (string completeIpiDir, string remoteFileName)
        {
            return new RpnJobTask
            {
                SeqNr = ++_seqNrTask,
                RpnJobTaskTypeId = (int)RpnJobTaskTypeEnum.ApplyIpiFile,
                CreatedAt = DateTime.Now,
                RpnJobTaskSteps = CreateFileSteps(
                    Path.Combine(_settings.FtpDumpPath, completeIpiDir),
                    remoteFileName,
                    Path.GetFileNameWithoutExtension(remoteFileName)
                )
            };
        }

        private RpnJobTask CreateTaskApplyUpdateFile (string completeIpiDir, string remoteFileName)
        {
            return new RpnJobTask
            {
                SeqNr = ++_seqNrTask,
                RpnJobTaskTypeId = (int)RpnJobTaskTypeEnum.ApplyUpdateFile,
                CreatedAt = DateTime.Now,
                RpnJobTaskSteps = CreateFileSteps(
                    _settings.FtpUpdatesPath,
                    remoteFileName,
                    remoteFileName
                )
            };
        }

        private RpnJob CreateJobLoadDict (string completeIpiDir)
        {
            return new RpnJob
            {
                SeqNr = ++_seqNrJob,
                RpnJobTypeId = (int)RpnJobTypeEnum.LoadDict,
                CreatedAt = DateTime.Now,
                RpnJobTasks = new List<RpnJobTask> () { CreateTaskApplyDict() }
            };
        }

        private RpnJob CreateJobLoadIpi (string completeIpiDir)
        {
            var files = _ftpClient
                .ReadDirectoryFiles(Path.Combine(_settings.FtpDumpPath, completeIpiDir))
                .Where(x => x.StartsWith("IPI", StringComparison.OrdinalIgnoreCase))
                .OrderBy(x => x)
                .ToList();
            var tasks = new List<RpnJobTask>();
            files.ForEach(x => {
                tasks.Add(CreateTaskApplyIpiFile(completeIpiDir, x));
            });
            return new RpnJob
            {
                SeqNr = ++_seqNrJob,
                RpnJobTypeId = (int)RpnJobTypeEnum.LoadIpi,
                CreatedAt = DateTime.Now,
                RpnJobTasks = tasks,
            };
        }

        private RpnJob CreateJobApplyUpdates ()
        {
            return new RpnJob
            {
                SeqNr = ++_seqNrJob,
                RpnJobTypeId = (int)RpnJobTypeEnum.ApplyUpdates,
                CreatedAt = DateTime.Now,
                RpnJobTasks = new List<RpnJobTask> (),
            };
        }

        private RpnPeriod CreatePeriod(DateTime ipiCompleteDate)
        {
            return new RpnPeriod
            {
                IpiCompleteDate = ipiCompleteDate,
                CreatedAt = DateTime.Now,
                RpnJobs = new List<RpnJob> (),
            };
        }
    }
}
