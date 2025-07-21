using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SharedLib;
using System;
using WidUpdatesLib;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WidAdminLib.Entities;
using WidServiceLib;
using WidReplicationServiceLib;
using Microsoft.Extensions.Configuration;

namespace WidAdminLib
{
    public class WidTaskRunner
    {
        public enum TaskResult
        {
            Completed = 0,
            Failed = 1,
            NoTasks = 2,
        }

        public event EventHandler WidTaskCompleted;

        private WidAdminDbContext _dbContext;
        private WidConfigurationEntity _widConfig;
        private WidTaskEntity _currentTask;

        public TaskResult RunPendingTask()
        {
            _dbContext = new WidAdminDbContext();
            _widConfig = _dbContext.WidConfigurations.FirstOrDefault();
            if (_widConfig == null)
            {
                return TaskResult.Failed;
            }

            _currentTask = _dbContext.WidTasks
                .Include(x => x.WidTaskObject)
                .ThenInclude(x => x.WidTaskSubject)
                .ThenInclude(x => x.WidUpdatePeriod)
                .OrderBy(x => x.ScheduledAt)
                .FirstOrDefault(x => x.WidTaskStatusId != (int)WidTaskStatusCodeEnum.Completed);

            if(_currentTask == null)
            {
                return TaskResult.NoTasks;
            }

            TryCatch.Run(() =>
            {
                var objectInfo = _currentTask.WidTaskObject.ObjectInfo;
                //IWidReplicationService service = new WidReplicationServiceDummy
                IWidReplicationService service = new WidReplicationService
                {
                    WidFtpUrl = _widConfig.WidFtpUrl,
                    WidFtpPort = _widConfig.WidFtpPort,
                    WidFtpLogin = _widConfig.WidFtpLogin,
                    WidFtpPassword = _widConfig.WidFtpPassword,
                    WidFtpUseSftp = _widConfig.WidFtpUseSftp,
                    WidFtpUseSsl = _widConfig.WidFtpUseSsl,
                    WidFtpDumpPath = _widConfig.WidFtpDumpPath,
                    WidFtpUpdatesPath = _widConfig.WidFtpUpdatesPath,
                    WidWorkFilesRootPath = _widConfig.WidWorkFilesRootPath,

                    IpiFtpUrl = _widConfig.IpiFtpUrl,
                    IpiFtpPort = _widConfig.IpiFtpPort,
                    IpiFtpLogin = _widConfig.IpiFtpLogin,
                    IpiFtpPassword = _widConfig.IpiFtpPassword,
                    IpiFtpUseSftp = _widConfig.IpiFtpUseSftp,
                    IpiFtpUseSsl = _widConfig.WidFtpUseSsl,
                    IpiFtpDumpPath = _widConfig.IpiFtpDumpPath,
                    IpiFtpUpdatesPath = _widConfig.IpiFtpUpdatesPath,
                    IpiWorkFilesRootPath = _widConfig.IpiWorkFilesRootPath,
                    ConnectionString = (new WidAdminDbContext()).Database.GetConnectionString(),
                };

                service.ActionStatusChanged += Service_ActionStatusChanged;
                if (_currentTask.WidTaskObject.WidTaskSubject.Db == "WID")
                {
                    RunWidTask(service);
                }
                else
                {
                    RunIpiTask(service);
                }

            }, ex =>
            {
                _currentTask.WidTaskStatusId = (int)WidTaskStatusCodeEnum.Failed;
                _currentTask.ErrMsg = ex.Message;
                _dbContext.SaveChanges();
            });

            return _currentTask.WidTaskStatusId == (int)WidTaskStatusCodeEnum.Failed ? TaskResult.Failed : TaskResult.Completed;
        }

        private void RunWidTask(IWidReplicationService service)
        {
            var objectInfo = _currentTask.WidTaskObject.ObjectInfo;
            var subject = _currentTask.WidTaskObject.WidTaskSubject;
            switch ((WidTaskSubjectTypeCodeEnum)subject.WidTaskSubjectTypeId)
            {
                case WidTaskSubjectTypeCodeEnum.InitFromDump:
                    switch ((WidTaskTypeCodeEnum)_currentTask.WidTaskTypeId)
                    {
                        case WidTaskTypeCodeEnum.FileDownload:
                            service.RunWidFileDownload(_widConfig.WidFtpDumpPath, WidServiceLib.EntityInfo.GetEntityZipFileName(objectInfo));
                            break;
                        case WidTaskTypeCodeEnum.FileUnzip:
                            service.RunWidFileUnzip(WidServiceLib.EntityInfo.GetEntityZipFileName(objectInfo));
                            break;
                        case WidTaskTypeCodeEnum.FileZipDelete:
                            service.RunWidFileZipDelete(WidServiceLib.EntityInfo.GetEntityZipFileName(objectInfo));
                            break;
                        case WidTaskTypeCodeEnum.FileApplyToDb:
                            service.RunWidDumpFileApplyToDb(objectInfo, "SocWid");
                            break;
                        case WidTaskTypeCodeEnum.CreateHistRecords:
                            service.RunWidCreateHistRecords(objectInfo, "SocWid");
                            break;
                        case WidTaskTypeCodeEnum.FileDelete:
                            service.RunWidFileDelete(WidServiceLib.EntityInfo.GetEntityFileName(objectInfo));
                            break;
                        default:
                            throw new Exception($"Wrong task type {_currentTask.WidTaskTypeId}");
                    }
                    break;
                case WidTaskSubjectTypeCodeEnum.CalcInitDumpTs:
                    service.RunWidCalcDumpTs("SocWid");
                    break;
                case WidTaskSubjectTypeCodeEnum.UpdateFromTranFiles:
                    switch ((WidTaskTypeCodeEnum)_currentTask.WidTaskTypeId)
                    {
                        case WidTaskTypeCodeEnum.FileDownload:
                            service.RunWidFileDownload(_widConfig.WidFtpUpdatesPath, objectInfo);
                            break;
                        case WidTaskTypeCodeEnum.FileUnzip:
                            service.RunWidFileUnzip(_currentTask.WidTaskObject.ObjectInfo);
                            break;
                        case WidTaskTypeCodeEnum.FileZipDelete:
                            service.RunWidFileZipDelete(_currentTask.WidTaskObject.ObjectInfo);
                            break;
                        case WidTaskTypeCodeEnum.FileApplyToDb:
                            service.RunWidUpdateFileApplyToDb(objectInfo, _currentTask.LastTransLineIdx);
                            break;
                        case WidTaskTypeCodeEnum.FileApplyToSocDb:
                            service.RunWidFileApplyToSocDb(objectInfo);
                            break;
                        case WidTaskTypeCodeEnum.FileDelete:
                            service.RunWidFileDelete(objectInfo);
                            break;
                        default:
                            throw new Exception($"Wrong task type {_currentTask.WidTaskTypeId}");
                    }
                    break;
                case WidTaskSubjectTypeCodeEnum.InitNewDump:
                    switch ((WidTaskTypeCodeEnum)_currentTask.WidTaskTypeId)
                    {
                        case WidTaskTypeCodeEnum.FileDownload:
                            service.RunWidFileDownload(_widConfig.WidFtpDumpPath, WidServiceLib.EntityInfo.GetEntityZipFileName(objectInfo));
                            break;
                        case WidTaskTypeCodeEnum.FileUnzip:
                            service.RunWidFileUnzip(WidServiceLib.EntityInfo.GetEntityZipFileName(objectInfo));
                            break;
                        case WidTaskTypeCodeEnum.FileZipDelete:
                            service.RunWidFileZipDelete(WidServiceLib.EntityInfo.GetEntityZipFileName(objectInfo));
                            break;
                        case WidTaskTypeCodeEnum.FileApplyToDb:
                            service.RunWidDumpFileApplyToDb(objectInfo, "SocWidInitial");
                            break;
                        case WidTaskTypeCodeEnum.FileDelete:
                            service.RunWidFileDelete(WidServiceLib.EntityInfo.GetEntityFileName(objectInfo));
                            break;
                        default:
                            throw new Exception($"Wrong task type {_currentTask.WidTaskTypeId}");
                    }
                    break;
                case WidTaskSubjectTypeCodeEnum.CalcNewDumpTs:
                    service.RunWidCalcDumpTs("SocWidInitial");
                    break;
                case WidTaskSubjectTypeCodeEnum.UpdateFromNewDump:
                    switch ((WidTaskTypeCodeEnum)_currentTask.WidTaskTypeId)
                    {
                        case WidTaskTypeCodeEnum.RenSocWidToSocWid_:
                            service.RunWidDbRename("SocWid", "SocWid_");
                            break;
                        case WidTaskTypeCodeEnum.RenSocWidInitialToSocWid:
                            service.RunWidDbRename("SocWidInitial", "SocWid");
                            break;
                        case WidTaskTypeCodeEnum.RenSocWid_ToSocWidInitial:
                            service.RunWidDbRename("SocWid_", "SocWidInitial");
                            break;
                        default:
                            throw new Exception($"Wrong task type {_currentTask.WidTaskTypeId}");
                    }
                    break;
                default:
                    throw new Exception($"Unknown task subject type {_currentTask.WidTaskObject.WidTaskSubjectId}");
            }
        }

        private void RunIpiTask(IWidReplicationService service)
        {
            var objectInfo = _currentTask.WidTaskObject.ObjectInfo;
            var subject = _currentTask.WidTaskObject.WidTaskSubject;
            switch ((WidTaskSubjectTypeCodeEnum)subject.WidTaskSubjectTypeId)
            {
                case WidTaskSubjectTypeCodeEnum.InitFromDump:
                    switch ((WidTaskTypeCodeEnum)_currentTask.WidTaskTypeId)
                    {
                        case WidTaskTypeCodeEnum.FileDownload:
                            service.RunIpiFileDownload(_widConfig.IpiFtpDumpPath, objectInfo);
                            break;
                        case WidTaskTypeCodeEnum.FileUnzip:
                            service.RunIpiFileUnzip(objectInfo);
                            break;
                        case WidTaskTypeCodeEnum.FileZipDelete:
                            service.RunIpiFileZipDelete(objectInfo);
                            break;
                        case WidTaskTypeCodeEnum.FileApplyToDb:
                            { 
                                var fileName = Path.GetFileName(objectInfo);
                                if(fileName.Equals("DOMAINS.zip", StringComparison.OrdinalIgnoreCase))
                                {
                                    fileName = "DOMAINS.EDI.zip";
                                    service.RunIpiFileApplyToSocDb(Path.Combine(_widConfig.IpiWorkFilesRootPath, Path.GetFileNameWithoutExtension(fileName)));
                                }
                                else
                                {
                                    service.RunIpiDumpFileApplyToDb(Path.Combine(_widConfig.IpiWorkFilesRootPath, Path.GetFileNameWithoutExtension(fileName)));
                                }
                            }   
                            break;
                        case WidTaskTypeCodeEnum.FileDelete:
                            {
                                var fileName = Path.GetFileName(objectInfo);
                                service.RunIpiFileDelete(Path.Combine(_widConfig.IpiWorkFilesRootPath, Path.GetFileNameWithoutExtension(fileName)));
                            }
                            break;
                        default:
                            throw new Exception($"Wrong task type {_currentTask.WidTaskTypeId}");
                    }
                    break;
                case WidTaskSubjectTypeCodeEnum.UpdateFromTranFiles:
                    switch ((WidTaskTypeCodeEnum)_currentTask.WidTaskTypeId)
                    {
                        case WidTaskTypeCodeEnum.FileDownload:
                            service.RunIpiFileDownload(_widConfig.IpiFtpUpdatesPath, objectInfo);
                            break;
                        case WidTaskTypeCodeEnum.FileApplyToDb:
                            {
                                var fileName = Path.GetFileName(objectInfo);
                                service.RunIpiUpdateFileApplyToDb(Path.Combine(_widConfig.IpiWorkFilesRootPath, fileName));
                            }
                            break;
                        case WidTaskTypeCodeEnum.FileApplyToSocDb:
                            {
                                var fileName = Path.GetFileName(objectInfo);
                                service.RunIpiFileApplyToSocDb(Path.Combine(_widConfig.IpiWorkFilesRootPath, fileName));
                            }
                            break;
                        case WidTaskTypeCodeEnum.FileDelete:
                            {
                                var fileName = Path.GetFileName(objectInfo);
                                service.RunIpiFileDelete(Path.Combine(_widConfig.IpiWorkFilesRootPath, fileName));
                            }
                            break;
                        default:
                            throw new Exception($"Wrong task type {_currentTask.WidTaskTypeId}");
                    }
                    break;
                default:
                    throw new Exception($"Unknown task subject type {_currentTask.WidTaskObject.WidTaskSubjectId}");
            }

        }

        private void Service_ActionStatusChanged(object sender, WidReplicationServiceLib.IWidReplicationService.ActionStatusChangedArgs e)
        {
            var oldWidTaskStatusId = _currentTask.WidTaskStatusId;
            switch (e.EventType)
            {
                case IWidReplicationService.ActionEventType.Started:
                    _currentTask.WidTaskStatusId = (int)WidTaskStatusCodeEnum.InProgress;
                    _currentTask.StartedAt = DateTime.Now;
                    break;
                case IWidReplicationService.ActionEventType.InProgress:
                    _currentTask.WidTaskStatusId = (int)WidTaskStatusCodeEnum.InProgress;
                    _currentTask.PercentDone = Convert.ToDecimal(e.EventInfo);
                    break;
                case IWidReplicationService.ActionEventType.Completed:
                    _currentTask.WidTaskStatusId = (int)WidTaskStatusCodeEnum.Completed;
                    _currentTask.EndedAt = DateTime.Now;
                    _currentTask.PercentDone = 100M;
                    switch ((WidTaskTypeCodeEnum)_currentTask.WidTaskTypeId)
                    {
                        case WidTaskTypeCodeEnum.CalcWidDumpTs:
                            _currentTask.WidTaskObject.WidTaskSubject.WidUpdatePeriod.NewWidDumpTs = Convert.ToDateTime(e.EventInfo);
                            break;
                    }
                    break;
                case IWidReplicationService.ActionEventType.Failed:
                    _currentTask.WidTaskStatusId = (int)WidTaskStatusCodeEnum.Failed;
                    _currentTask.ErrMsg = (string)e.EventInfo;
                    break;
                case IWidReplicationService.ActionEventType.TransStarted:
                    _currentTask.LastTransLineIdx = (int)e.EventInfo;
                    break;
                default:
                    throw new Exception($"Unknown event type {e.EventType}");
            }
            _dbContext.SaveChanges();

            if (oldWidTaskStatusId != _currentTask.WidTaskStatusId && _currentTask.WidTaskStatusId == (int)WidTaskStatusCodeEnum.Completed)
            { 
                WidTaskCompleted?.Invoke(this, EventArgs.Empty); 
            }
        }
    }
}
