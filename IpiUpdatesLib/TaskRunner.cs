using Microsoft.EntityFrameworkCore;
using SocFtpClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using static IpiUpdatesLib.IpiUpdatesDbContext;

namespace IpiUpdatesLib
{
    public class TaskRunner
    {
        public enum TaskResult
        {
            NoTasks,
            Completed,
            Failed
        }

        private IpiUpdatesDbContext _dbc;
        private RpnSettings _settings;
        private FtpClient _ftpClient;

        public TaskRunner()
        {
            _dbc = new IpiUpdatesDbContext();
            _settings = _dbc.RpnSettings.Single();
            _ftpClient = new FtpClient(
                _settings.FtpUrl, 
                _settings.FtpLogin, 
                _settings.FtpPassword,
                _settings.FtpPort,
                _settings.FtpUseSftp,
                _settings.FtpUseSsl);
            _ftpClient.FtpEvent += (sender, e) => {};
        }

        public TaskResult RunPendingTask()
        {
            RpnJobTaskStep step;
            try 
            {
                Logger.SetStepId(0);

                step = _dbc.RpnJobTaskSteps
                    .Include(x => x.RpnJobTask)
                    .Include(x => x.RpnJobTask.RpnJob)
                    .Include(x => x.RpnJobTask.RpnJob.RpnPeriod)
                    .Where(x => x.EndedAt == null)
                    .OrderBy(x => x.SeqNr)
                    .FirstOrDefault();
                if (step == null)
                    return TaskResult.NoTasks;

                SetStartedAt(step);

                switch(step.RpnJobTaskStepTypeId)
                {
                    case (int)RpnJobTaskStepTypeEnum.DownloadFile:
                        DownloadFile(step);
                        break;
                    case (int)RpnJobTaskStepTypeEnum.UnzipFile:
                        UnzipFile(step);
                        break;
                    case (int)RpnJobTaskStepTypeEnum.DeleteZipFile:
                        DeleteZipFile(step);
                        break;
                    case (int)RpnJobTaskStepTypeEnum.LoadFileIntoDb:
                        LoadFileIntoDb(step);
                        break;
                    case (int)RpnJobTaskStepTypeEnum.ApplyFile:
                        ApplyFile(step);
                        break;
                    case (int)RpnJobTaskStepTypeEnum.DeleteFile:
                        DeleteFile(step);
                        break;
                }

                SetEndedAt(step);

                return TaskResult.Completed;

            }
            catch(Exception ex)
            {
                Logger.WriteErr($"ERROR: {ex.Message}");
                return TaskResult.Failed;
            }
        }

        private void SetStartedAt(RpnJobTaskStep step)
        {
            step.StartedAt = DateTime.Now;
            if(step.RpnJobTask.StartedAt == null)
                step.RpnJobTask.StartedAt = DateTime.Now;
            if(step.RpnJobTask.RpnJob.StartedAt == null)
                step.RpnJobTask.RpnJob.StartedAt = DateTime.Now;
            if(step.RpnJobTask.RpnJob.RpnPeriod.StartedAt == null)
                step.RpnJobTask.RpnJob.RpnPeriod.StartedAt = DateTime.Now;
            _dbc.SaveChanges();
        }

        private void SetEndedAt(RpnJobTaskStep step)
        {
            step.EndedAt = DateTime.Now;

            // Завершуємо задачу, якщо крок останній (видалення файлу)
            if(step.RpnJobTaskStepTypeId == (int)RpnJobTaskStepTypeEnum.DeleteFile)
                step.RpnJobTask.EndedAt = DateTime.Now;

            // Заврершення РОБОТИ
            // Початково заплановані всі роботи завантаження повних даних
            // Період і роботу щоденного завантаження не завершуємо
            if(step.RpnJobTask.RpnJobTaskTypeId != (int)RpnJobTaskTypeEnum.ApplyUpdateFile)
            {
                var nextStep = _dbc.RpnJobTaskSteps
                        .Include(x => x.RpnJobTask)
                        .Include(x => x.RpnJobTask.RpnJob)
                        .Include(x => x.RpnJobTask.RpnJob.RpnPeriod)
                        .Where(x => x.SeqNr == step.SeqNr + 1)
                        .OrderBy(x => x.SeqNr)
                        .FirstOrDefault();
                if(nextStep == null || step.RpnJobTask.RpnJob.Id != nextStep.RpnJobTask.RpnJob.Id)
                {
                    step.RpnJobTask.RpnJob.EndedAt = DateTime.Now;
                }
            }

             _dbc.SaveChanges();
        }

        private void DownloadFile(RpnJobTaskStep step)
        {
            _ftpClient.DownloadFile("", step.FileName, _settings.WorkFilesRootPath);
        }

        private void UnzipFile(RpnJobTaskStep step)
        {
            ZipFile.ExtractToDirectory(Path.Combine(_settings.WorkFilesRootPath, step.FileName), _settings.WorkFilesRootPath, true);
        }

        private void DeleteZipFile(RpnJobTaskStep step)
        {
            File.Delete(Path.Combine(_settings.WorkFilesRootPath, step.FileName));
        }

        private void ApplyFile(RpnJobTaskStep step)
        {
            switch(step.RpnJobTask.RpnJob.RpnJobTypeId)
            {
                case (int)RpnJobTypeEnum.LoadDict:
                    ApplyFileDict(step);
                    break;
                case (int)RpnJobTypeEnum.LoadIpi:
                    ApplyFileIpi(step);
                    break;
                case (int)RpnJobTypeEnum.ApplyUpdates:
                    ApplyFileUpdate(step);
                    break;
            }
        }

        private void ApplyFileDict(RpnJobTaskStep step)
        {
            var service =  new IpiDomainService();
            service.ApplyFileDomains();
        }

        private void ApplyFileIpi(RpnJobTaskStep step)
        {
            IpiUpdateService.LoadDumpFile(Path.Combine(_settings.WorkFilesRootPath,step.FileName), x => { });
        }

        private void LoadFileIntoDb(RpnJobTaskStep step)
        {
            IpiUpdateService.LoadUpdFile(Path.Combine(_settings.WorkFilesRootPath,step.FileName), x => { });
        }

        private void ApplyFileUpdate(RpnJobTaskStep step)
        {
            IpiUpdateService.ApplySingleFileUpdates(Path.Combine(_settings.WorkFilesRootPath,step.FileName), x => { });
        }

        private void DeleteFile(RpnJobTaskStep step)
        {
            File.Delete(Path.Combine(_settings.WorkFilesRootPath, step.FileName));
        }
    }
}
