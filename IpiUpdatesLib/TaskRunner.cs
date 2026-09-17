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
            var step = _dbc.RpnJobTaskSteps
                .Include(x => x.RpnJobTask)
                .Include(x => x.RpnJobTask.RpnJob)
                .Include(x => x.RpnJobTask.RpnJob.RpnPeriod)
                .Where(x => x.EndedAt == null)
                .OrderBy(x => x.SeqNr)
                .FirstOrDefault();

            if (step == null)
                return TaskResult.NoTasks;

            step.StartedAt = DateTime.Now;
            _dbc.SaveChanges();

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
                case (int)RpnJobTaskStepTypeEnum.ApplyFile:
                    ApplyFile(step);
                    break;
                case (int)RpnJobTaskStepTypeEnum.DeleteFile:
                    DeleteFile(step);
                    break;
            }

            step.EndedAt = DateTime.Now;
            _dbc.SaveChanges();

            return TaskResult.Completed;
        }

        private void DownloadFile(RpnJobTaskStep step)
        {
            _ftpClient.DownloadFile("", step.FileName, _settings.WorkFilesRootPath);
        }

        private void UnzipFile(RpnJobTaskStep step)
        {
            ZipFile.ExtractToDirectory(Path.Combine(_settings.WorkFilesRootPath, step.FileName), _settings.WorkFilesRootPath);
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
        }

        private void ApplyFileIpi(RpnJobTaskStep step)
        {
        }

        private void ApplyFileUpdate(RpnJobTaskStep step)
        {
        }

        private void DeleteFile(RpnJobTaskStep step)
        {
            File.Delete(Path.Combine(_settings.WorkFilesRootPath, step.FileName));
        }
    }
}
