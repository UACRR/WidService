using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SharedLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WidAdminLib.Entities;
using WidServiceLib;

namespace WidAdminLib
{
    public class WidTaskPlanner
    {
        class UpdFileInfo
        {
            public string FileName { get; set; }
            public DateTime UpdDt { get; set; }
    }

        private WidAdminDbContext _dbContext;
        private WidConfigurationEntity _widConfig;
        private WidUpdatePeriodEntity _currentPeriod;

        private bool _isTaskAdded;
        public bool PlanTasks()
        {
            _isTaskAdded = false;
            _dbContext = new WidAdminDbContext();
            Logger.WriteLine("Reading wid configuration from database.");
            GetWidConfiguration();
            Logger.WriteLine("Loading current period");
            LoadCurrentPeriod();

            using (var tran = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Logger.WriteLine("Updating statuses");
                    UpdateStatuses();

                    if (_currentPeriod == null) // Create initial period with all tasks
                    {
                        Logger.WriteLine("Planning tasks for initial replication from dump");
                        // Initial period starts from unknown wid dump date
                        CreateWidUpdatePeriod(null, null);

                        // Load created period with all nested objects
                        LoadCurrentPeriod();

                        // Create tasks
                        var lastTaskId = CreateInitFromDumpTasks();
                        CreateCalcInitDumpTsTasks(lastTaskId);

                        // No more tasks are to be planned here
                    }
                    else if (_currentPeriod.WidDumpTs == null) // this is initial period
                    {
                        Logger.WriteLine("Initial replication is not completed, no new tasks are planned");
                        // TODO: although hardly possible in practice need to check that WID dump was not changed
                        // during its applying to database, so in such case we need to reset tasks to repead upload tasks and those that followed
                        // NOT IMPLEMENTED

                        // No new tasks should be added in this case
                    }
                    else if (_currentPeriod.WidTaskSubjects.Any( x => x.WidTaskSubjectTypeId == (int)WidTaskSubjectTypeCodeEnum.InitNewDump)) // tasks for period completion are planned
                    {
                        if(!_currentPeriod.WidTaskSubjects.Any(x => x.WidTaskSubjectTypeId == (int)WidTaskSubjectTypeCodeEnum.UpdateFromNewDump))
                        {
                            Logger.WriteLine("Planning tasks for ");
                            CreateUpdateFromNewDumpTasks();
                        }
                        else
                        {
                            Logger.WriteLine("Period is being finalized, no new tasks are planned");
                            // No new tasks should be added in this case
                        }
                    }
                    else
                    {
                        Logger.WriteLine("Planning tasks for replication from new dump");
                        // Plan tasks for new dump upload
                        _currentPeriod.NewWidDumpFilesTotalSize = GetWidDumpFilesTotalSize();
                        if (_currentPeriod.NewWidDumpFilesTotalSize != _currentPeriod.WidDumpFilesTotalSize
                            && !_currentPeriod.WidTaskSubjects.Any(subject => subject.WidTaskSubjectTypeId == (int)WidTaskSubjectTypeCodeEnum.InitNewDump)
                        )
                        {
                            Logger.WriteLine("    New tasks are planned");
                            // This function creates also subject for new new update time stamp calculation
                            CreateInitNewDumpTasks();
                        }
                        else
                        {
                            Logger.WriteLine("    No tasks are planned");
                        }

                        Logger.WriteLine("Planning tasks for replication from update files");
                        // Plan update tasks (both from files and new dump), do not plan new tasks while new update is not uploaded
                        var isInitNewDumpPending = _currentPeriod.WidTaskSubjects
                            .Any(x => x.WidTaskSubjectTypeId == (int)WidTaskSubjectTypeCodeEnum.CalcNewDumpTs && x.WidTaskStatusId != (int)WidTaskStatusCodeEnum.Completed);
                        if (!isInitNewDumpPending)
                        {
                            Logger.WriteLine("    New tasks are being planned");
                            // This includes also planning updates from new dump
                            CreateUpdateFromTranFilesTasks();
                        }
                        else
                        {
                            Logger.WriteLine("    No tasks are to be planned this time");
                        }
                    }

                    tran.Commit();
                }
                catch(Exception ex)
                {
                    Logger.WriteLine($"ERROR: {ex.Message}");
                    tran.Rollback();
                }
            }
            return _isTaskAdded;
        }

        private void GetWidConfiguration()
        {
            _widConfig = _dbContext.WidConfigurations.FirstOrDefault();
        }

        private void LoadCurrentPeriod()
        {
            _currentPeriod = _dbContext.WidUpdatePeriods
                .Include(x => x.WidTaskSubjects)
               .ThenInclude(x => x.WidTaskObjects)
               .ThenInclude(x => x.WidTasks)
               .SingleOrDefault(x => x.WidTaskStatusId != (int)WidTaskStatusCodeEnum.Completed);
        }
        private void UpdateStatuses()
        {
            // For current period (tasks of previos periods are never updated)
            // Note: next period is not created until current period is completed

            // !!! Need to work with local copy of current period
            var period = _dbContext.WidUpdatePeriods
               .Include(x => x.WidTaskSubjects)
               .ThenInclude(x => x.WidTaskObjects)
               .ThenInclude(x => x.WidTasks)
               .SingleOrDefault(x => x.WidTaskStatusId != (int)WidTaskStatusCodeEnum.Completed);

            if (period == null)
            {
                return;
            }

            // TaksRunner does not deal with surrounding information, updates of status, startDate and endDate are done here

            // For Subjects
            period.WidTaskSubjects.ToList().ForEach(subj =>
            {
                // For Objects from Tasks
                subj.WidTaskObjects.ToList().ForEach(obj => {
                    // For object from task
                    obj.StartedAt = obj.WidTasks.Min(x => x.StartedAt);
                    obj.EndedAt = obj.WidTasks.Max(x => x.EndedAt);
                    if(obj.WidTasks.Any(x => x.WidTaskStatusId == (int)WidTaskStatusCodeEnum.Failed))
                    {
                        obj.WidTaskStatusId = (int)WidTaskStatusCodeEnum.Failed;
                    }
                    else if (obj.WidTasks.Any(x => x.WidTaskStatusId == (int)WidTaskStatusCodeEnum.InProgress))
                    {
                        obj.WidTaskStatusId = (int)WidTaskStatusCodeEnum.InProgress;
                    }
                    else if (obj.WidTasks.Any(x => x.WidTaskStatusId == (int)WidTaskStatusCodeEnum.Pending))
                    {
                        if (obj.WidTasks.Any(x => x.WidTaskStatusId == (int)WidTaskStatusCodeEnum.Completed))
                            obj.WidTaskStatusId = (int)WidTaskStatusCodeEnum.InProgress;
                        else
                            obj.WidTaskStatusId = (int)WidTaskStatusCodeEnum.Pending;
                    }
                    else if(obj.WidTasks.Count > 0)
                    {
                        obj.WidTaskStatusId = (int)WidTaskStatusCodeEnum.Completed;
                    }
                });

                // For Subject from objects
                subj.StartedAt = subj.WidTaskObjects.Min(x => x.StartedAt);
                subj.EndedAt = subj.WidTaskObjects.Max(x => x.EndedAt);
                if (subj.WidTaskObjects.Any(x => x.WidTaskStatusId == (int)WidTaskStatusCodeEnum.Failed))
                {
                    subj.WidTaskStatusId = (int)WidTaskStatusCodeEnum.Failed;
                }
                else if (subj.WidTaskObjects.Any(x => x.WidTaskStatusId == (int)WidTaskStatusCodeEnum.InProgress))
                {
                    subj.WidTaskStatusId = (int)WidTaskStatusCodeEnum.InProgress;
                }
                else if (subj.WidTaskObjects.Any(x => x.WidTaskStatusId == (int)WidTaskStatusCodeEnum.Pending))
                {
                    subj.WidTaskStatusId = (int)WidTaskStatusCodeEnum.Pending;
                }
                else if (subj.WidTaskObjects.Count > 0)
                {
                    subj.WidTaskStatusId = (int)WidTaskStatusCodeEnum.Completed;
                }
            });

            period.StartedAt = period.WidTaskSubjects.Min(x => x.StartedAt);
            period.EndedAt = period.WidTaskSubjects.Max(x => x.EndedAt);
            if (period.WidTaskSubjects.Any(x => x.WidTaskStatusId == (int)WidTaskStatusCodeEnum.Failed))
            {
                period.WidTaskStatusId = (int)WidTaskStatusCodeEnum.Failed;
            }
            else if (period.WidTaskSubjects.Any(x => x.WidTaskStatusId == (int)WidTaskStatusCodeEnum.InProgress))
            {
                period.WidTaskStatusId = (int)WidTaskStatusCodeEnum.InProgress;
            }
            else if (period.WidTaskSubjects.Any(x => x.WidTaskStatusId == (int)WidTaskStatusCodeEnum.Pending))
            {
                period.WidTaskStatusId = (int)WidTaskStatusCodeEnum.Pending;
            }
            else
            {
                if (period.WidTaskSubjects.Any(x => x.WidTaskSubjectTypeId == (int)WidTaskSubjectTypeCodeEnum.InitFromDump
                     || x.WidTaskSubjectTypeId == (int)WidTaskSubjectTypeCodeEnum.UpdateFromNewDump))
                {
                    period.WidTaskStatusId = (int)WidTaskStatusCodeEnum.Completed;
                }
                else
                {
                    period.WidTaskStatusId = (int)WidTaskStatusCodeEnum.Pending;
                }
            }

            _dbContext.SaveChanges();

            // If period becomes completed, create next period
            if(period.WidTaskStatusId == (int)WidTaskStatusCodeEnum.Completed)
            {
                Logger.WriteLine("Creating new update period");
                var lastIpiTs = GetLastIpiUpdateTs(period);
                if(lastIpiTs == null)
                {
                    lastIpiTs = period.NewWidDumpTs;
                }
                var newPeriodId = CreateWidUpdatePeriod(period.NewWidDumpTs, lastIpiTs);
                //CreateWidTaskSubject(newPeriodId, WidTaskSubjectTypeCodeEnum.UpdateFromTranFiles, "WID", null);
            }

            LoadCurrentPeriod();

        }

        private DateTime? GetLastIpiUpdateTs(WidUpdatePeriodEntity period)
        {
            var dbContext = new WidAdminDbContext();
            using (var conn = dbContext.Database.GetDbConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        set transaction isolation level read uncommitted
                        select max(t2.ObjectInfo)
                        from  WidTaskSubjects t1
                            join WidTaskObjects t2 on t1.Id = t2.WidTaskSubjectId
                        where t1.WidTaskSubjectTypeId = 3
                            and t1.Db = 'IPI'
                    ";
                    var fileName = cmd.ExecuteScalar().ToString();
                    if(string.IsNullOrEmpty(fileName))
                    {
                        return null;
                    }
                    return new DateTime(int.Parse(fileName.Substring(0, 4)), int.Parse(fileName.Substring(4, 2)), int.Parse(fileName.Substring(6, 2)));
                }
            }
       }

        private int CreateWidUpdatePeriod(DateTime? widDumpTs, DateTime? ipiDumpTs)
        {
            var widUpdatePeriod = new WidUpdatePeriodEntity
            {
                WidTaskStatusId = (int)WidTaskStatusCodeEnum.Pending,
                WidDumpTs = widDumpTs,
                NewWidDumpTs = null,
                IpiDumpTs = ipiDumpTs,
                NewIpiDumpTs = null,
                WidDumpFilesTotalSize = GetWidDumpFilesTotalSize(),
                NewWidDumpFilesTotalSize = 0,
                StartedAt = null,
                EndedAt = null,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            _dbContext.Add(widUpdatePeriod);
            _dbContext.SaveChanges();

            return widUpdatePeriod.Id;
        }
        private int CreateWidTaskSubject(int widUpdatePeriodId, WidTaskSubjectTypeCodeEnum subjectType, string db, DateTime? taskDate)
        {
            var subject = new WidTaskSubjectEntity
            {
                WidUpdatePeriodId = widUpdatePeriodId,
                WidTaskSubjectTypeId = (int)subjectType,
                WidTaskStatusId = (int)WidTaskStatusCodeEnum.Pending,
                Db = db,
                TasksDate = taskDate,
                StartedAt = null,
                EndedAt = null,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            _dbContext.Add(subject);
            _dbContext.SaveChanges();
            return subject.Id;
        }
        private int CreateWidTaskObject(int widTaskSubjectId, string objectInfo)
        {
            var widTaskObject = new WidTaskObjectEntity
            {
                WidTaskSubjectId = widTaskSubjectId,
                WidTaskStatusId = (int)WidTaskStatusCodeEnum.Pending,
                ObjectInfo = objectInfo,
                ObjectFileTs = null,
                StartedAt = null,
                EndedAt = null,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            _dbContext.Add(widTaskObject);
            _dbContext.SaveChanges();
            return widTaskObject.Id;
        }
        private int CreateWidTask(int widTaskObjectId, WidTaskTypeCodeEnum taskType, int? prevWidTaskId)
        {
            WidTaskEntity prevTask = null;
            if (prevWidTaskId != null)
            {
                prevTask = _dbContext.WidTasks.Single(x => x.Id == prevWidTaskId);
            }

            var widTask = new WidTaskEntity
            {
                WidTaskObjectId = widTaskObjectId,
                WidTaskTypeId = (int)taskType,
                WidTaskStatusId = (int)WidTaskStatusCodeEnum.Pending,
                PrevWidTaskId = prevWidTaskId,
                NextWidTaskId = null,
                PercentDone = 0,
                ErrMsg = "",
                LastTransLineIdx = null,
                ScheduledAt = prevTask == null ? DateTime.Now : ((DateTime)prevTask.ScheduledAt).AddSeconds(1),
                StartedAt = null,
                EndedAt = null,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            _dbContext.Add(widTask);
            _dbContext.SaveChanges();

            if(prevTask != null)
            {
                prevTask.NextWidTaskId = widTask.Id;
                _dbContext.SaveChanges();
            }

            _isTaskAdded = true;
            return widTask.Id;
        }

        private int? CreateInitFromDumpTasks()
        {
            int? lastTaskId = null;

            var subjectId = CreateWidTaskSubject(_currentPeriod.Id, WidTaskSubjectTypeCodeEnum.InitFromDump, "WID", null);
            //int i = 0;
            var taskTypes = new List<WidTaskTypeCodeEnum> {
                WidTaskTypeCodeEnum.FileDownload,
                WidTaskTypeCodeEnum.FileUnzip,
                WidTaskTypeCodeEnum.FileZipDelete,
                WidTaskTypeCodeEnum.FileApplyToDb,
                WidTaskTypeCodeEnum.CreateHistRecords,
                WidTaskTypeCodeEnum.FileDelete,
            };
            EntityInfo.GetEntityNames().ForEach(entityName =>
            {
                //if (++i > 4)
                    //return;
                var widTaskObjectId = CreateWidTaskObject(subjectId, entityName);
                taskTypes.ForEach(taskType =>
                {
                    lastTaskId = CreateWidTask(widTaskObjectId, taskType, lastTaskId);
                });
            });

            subjectId = CreateWidTaskSubject(_currentPeriod.Id, WidTaskSubjectTypeCodeEnum.InitFromDump, "IPI", null);
            var ftpClient = new FtpClient(_widConfig.IpiFtpUrl, _widConfig.IpiFtpLogin, _widConfig.IpiFtpPassword, true);
            var ftpIpiDirectory = ftpClient.ReadDirectory(_widConfig.IpiFtpDumpPath);
            var ftpDirNames = new List<string>();
            ftpIpiDirectory.ForEach(x => ftpDirNames.Add(x.Split(' ').Last()));
            var folderName = ftpDirNames.Where(x => x != "." && x != ".." && x != "Domains").OrderByDescending(x => x).FirstOrDefault();
            var ipiDumpFileNameDir = ftpClient.ReadDirectory($"{_widConfig.IpiFtpDumpPath}/{folderName}");
            var ipiDumpFileNames = new List<string>();
            ipiDumpFileNameDir.ForEach(x => ipiDumpFileNames.Add(x.Split(' ').Last()));
            taskTypes = new List<WidTaskTypeCodeEnum> {
                    WidTaskTypeCodeEnum.FileDownload,
                    WidTaskTypeCodeEnum.FileUnzip,
                    WidTaskTypeCodeEnum.FileZipDelete,
                    WidTaskTypeCodeEnum.FileApplyToDb,
                    WidTaskTypeCodeEnum.FileDelete,
                };
            ipiDumpFileNames
                .Where(x => x.EndsWith(".zip"))
                .OrderBy(x => x)
                .ToList()
                .ForEach(fileName =>
            {
                var widTaskObjectId = CreateWidTaskObject(subjectId, $"{folderName}/{fileName}");
                taskTypes.ForEach(taskType =>
                {
                    lastTaskId = CreateWidTask(widTaskObjectId, taskType, lastTaskId);
                });
            });
            var ipiDomainTaskObjectId = CreateWidTaskObject(subjectId, $"Domains/DOMAINS.zip");
            taskTypes.ForEach(taskType =>
            {
                lastTaskId = CreateWidTask(ipiDomainTaskObjectId, taskType, lastTaskId);
            });
            
            var period = _dbContext.WidUpdatePeriods
               .SingleOrDefault(x => x.WidTaskStatusId != (int)WidTaskStatusCodeEnum.Completed);
            period.IpiDumpTs = new DateTime(
                int.Parse(folderName.Substring(0, 4)),
                int.Parse(folderName.Substring(4, 2)),
                int.Parse(folderName.Substring(6, 2))
            );
            _dbContext.SaveChanges();

            LoadCurrentPeriod();
            return lastTaskId;
        }

        private int? CreateCalcInitDumpTsTasks(int? lastTaskId)
        {
            var calcInitDumpTsSubjectId = CreateWidTaskSubject(_currentPeriod.Id, WidTaskSubjectTypeCodeEnum.CalcInitDumpTs, "WID", null);
            var widTaskObjectId = CreateWidTaskObject(calcInitDumpTsSubjectId, "AllWidTables");
            LoadCurrentPeriod();
            return CreateWidTask(widTaskObjectId, WidTaskTypeCodeEnum.CalcWidDumpTs, lastTaskId);
        }

 /*
        private void CreateUpdateFromTranFilesTasks()
        {
            string lastUpdateFileName = null;
            var updateFromTranFilesSubject = _currentPeriod.WidTaskSubjects
                .SingleOrDefault(x => x.WidTaskSubjectTypeId == (int)WidTaskSubjectTypeCodeEnum.UpdateFromTranFiles);

            // Just guard
            if (updateFromTranFilesSubject == null)
            {
                return; // This is initial period
            }

            lastUpdateFileName = updateFromTranFilesSubject.WidTaskObjects.Max(x => x.ObjectInfo);
            if(lastUpdateFileName == null) // No updates are planned for current period yet
            {
                // Build file name from period wid-dump date
                DateTime ts = (DateTime)_currentPeriod.WidDumpTs;
                lastUpdateFileName = $"WID{ts.ToString("yyyyMMddhhmmss")}000300.021";
            }

            var maxUpdateFileName = "WID99990000000000000000.021";
            if(_currentPeriod.NewWidDumpTs != null) // new dump is already loaded ind its time stamp is known
            {
                maxUpdateFileName = $"WID{((DateTime)_currentPeriod.NewWidDumpTs).ToString("yyyyMMddhhmmss")}000300.021";
            }

            Logger.WriteLine($"    Search files between {lastUpdateFileName} and {maxUpdateFileName} at {_widConfig.WidFtpUpdatesPath}");

            var allDirFileNames = ReadFtpDirectory(_widConfig.WidFtpUpdatesPath)
                .ConvertAll(x => x.Split(' ').Last());

            // Updates to be added to the current period
            var newUpdateFiles = allDirFileNames
                .Where(x => x.CompareTo(lastUpdateFileName) > 0 && x.CompareTo(maxUpdateFileName) < 0)
                .OrderBy(x => x)
                .ToList();

            if(newUpdateFiles.Count > 0) // not all updates were planned for the current period
            {
                Logger.WriteLine("    New files to add are found, creating tasks");
                var lastWidTaskId = GetLastTaskId();
                newUpdateFiles.ForEach(x =>
                {
                    Logger.WriteLine($"        Creating object {x} for subject {updateFromTranFilesSubject.Id}");
                    var widTaskObjectId = CreateWidTaskObject(updateFromTranFilesSubject.Id, x);
                    Logger.WriteLine($"        Creating FileDownload task for object {widTaskObjectId}");
                    lastWidTaskId = CreateWidTask(widTaskObjectId, WidTaskTypeCodeEnum.FileDownload, lastWidTaskId);
                    Logger.WriteLine($"        Creating FileUnzip task for object {widTaskObjectId}");
                    lastWidTaskId = CreateWidTask(widTaskObjectId, WidTaskTypeCodeEnum.FileUnzip, lastWidTaskId);
                    Logger.WriteLine($"        Creating FileZipDelete task for object {widTaskObjectId}");
                    lastWidTaskId = CreateWidTask(widTaskObjectId, WidTaskTypeCodeEnum.FileZipDelete, lastWidTaskId);
                    Logger.WriteLine($"        Creating FileApplyToSocDb task for object {widTaskObjectId}");
                    lastWidTaskId = CreateWidTask(widTaskObjectId, WidTaskTypeCodeEnum.FileApplyToSocDb, lastWidTaskId);
                    Logger.WriteLine($"        Creating FileApplyToDb task for object {widTaskObjectId}");
                    lastWidTaskId = CreateWidTask(widTaskObjectId, WidTaskTypeCodeEnum.FileApplyToDb, lastWidTaskId);
                    Logger.WriteLine($"        Creating FileDelete task for object {widTaskObjectId}");
                    lastWidTaskId = CreateWidTask(widTaskObjectId, WidTaskTypeCodeEnum.FileDelete, lastWidTaskId);
                });
            }
            else
            {
                Logger.WriteLine("    No new files to add are found");
            }

            // Note: at this point it is possible that updates applicaple for next period are already planned within this period.
            // We do nothing special here and let them be applied. The logic would make them be planned for the new period after update from the new dump.

            // If all updates applicable for the current period are planned we create "update from new dump" tasks if not planned yet
            if(allDirFileNames.Any(x => x.CompareTo(maxUpdateFileName) >= 0) &&
                !_currentPeriod.WidTaskSubjects.Any(x => x.WidTaskSubjectTypeId == (int)WidTaskSubjectTypeCodeEnum.UpdateFromNewDump))
            {
                CreateUpdateFromNewDumpTasks();
            }

            LoadCurrentPeriod();
        }
 */

        private void CreateUpdateFromTranFilesTasks()
        {
            var ipiUpdSubjList = _currentPeriod
                .WidTaskSubjects
                .Where(x => x.Db == "IPI" && x.WidTaskSubjectTypeId == (int)WidTaskSubjectTypeCodeEnum.UpdateFromTranFiles)
                .OrderBy(x => x.TasksDate)
                .ToList();
            var widUpdSubjList = _currentPeriod
                .WidTaskSubjects
                .Where(x => x.Db == "WID" && x.WidTaskSubjectTypeId == (int)WidTaskSubjectTypeCodeEnum.UpdateFromTranFiles)
                .OrderBy(x => x.TasksDate)
                .ToList();
            var ipiUpdFileInfoList = ReadIpiUpdateFilesInfo();
            var widUpdFileInfoList = ReadWidUpdateFilesInfo();

            var ipiDumpTs = (DateTime)_currentPeriod.IpiDumpTs;
            var widDumpTs = (DateTime)_currentPeriod.WidDumpTs;
            ipiUpdFileInfoList = ipiUpdFileInfoList.Where(x => x.UpdDt.Date > ipiDumpTs.Date).ToList();
            widUpdFileInfoList = widUpdFileInfoList.Where(x => x.UpdDt.Date > widDumpTs.Date).ToList();

            var ipiLastPlannedTs = GetIpiLastPlannedTs(ipiUpdSubjList, ipiDumpTs.Date);
            var widLastPlannedTs = GetWidLastPlannedTs(widUpdSubjList, widDumpTs.Date);

            // Plan updates to fill the gap between IPI and WID dump dates
            var gapIsFilledIn = false;
            if (ipiDumpTs.Date < widDumpTs.Date)
            {
                var lastGapDate = widDumpTs.Date;
                if (ipiLastPlannedTs > lastGapDate)
                {
                    gapIsFilledIn = true;
                }
                else
                {
                    ipiUpdFileInfoList
                        .Where(x => x.UpdDt.Date > ipiLastPlannedTs.Date && x.UpdDt.Date <= lastGapDate)
                        .OrderBy(x => x.UpdDt)
                        .ToList()
                        .ForEach(x =>
                        {
                            CreateUpdateFromTranFilesSubject(x, "IPI");
                            ipiLastPlannedTs = x.UpdDt;
                        });
                    if(ipiUpdFileInfoList.Any(x => x.UpdDt.Date > lastGapDate))
                    {
                        gapIsFilledIn = true;
                    }
                }
            }
            else if(ipiDumpTs.Date > widDumpTs.Date)
            {
                var lastGapDate = ipiDumpTs.Date;
                if (widLastPlannedTs.Date > lastGapDate)
                {
                    gapIsFilledIn = true;
                }
                else
                {
                    var pendingFiles = widUpdFileInfoList.Where(x => x.UpdDt > widLastPlannedTs && x.UpdDt.Date <= lastGapDate).OrderBy(x => x.UpdDt).ToList();
                    var newWidLastPlannedTs = PlanWidUpdateTasks(pendingFiles, widUpdSubjList);
                    if(newWidLastPlannedTs != null)
                    {
                        widLastPlannedTs = (DateTime)newWidLastPlannedTs;
                    }
                    if (widUpdFileInfoList.Any(x => x.UpdDt.Date > lastGapDate))
                    {
                        gapIsFilledIn = true;
                    }
                }
            }
            else
            {
                gapIsFilledIn = true;
            }

            // Plan update tasks for IPI and WID synchroneosely
            if (gapIsFilledIn)
            {
                // First we plan remaining WID update tasks for last planned IPI update
                var planNextDates = true;
                if (ipiLastPlannedTs.Date > ipiDumpTs.Date)
                {
                    PlanWidUpdateTasks(widUpdFileInfoList.Where(x => x.UpdDt.Date == ipiLastPlannedTs.Date).OrderBy(x => x.UpdDt).ToList(), widUpdSubjList);
                    // Check that all WID updates are planned
                    if(!widUpdFileInfoList.Any(x => x.UpdDt > ipiLastPlannedTs))
                    {
                        planNextDates = false;
                    }
                }

                // Now we plan tasks for subsequent dates provided that WID update for subsequent dates exist
                if (planNextDates)
                {
                    for (var nextDate = ipiLastPlannedTs.Date + TimeSpan.FromDays(1); ; nextDate += TimeSpan.FromDays(1))
                    {
                        var ipiFileInfo = ipiUpdFileInfoList.SingleOrDefault(x => x.UpdDt.Date == nextDate);

                        // Plan updates for both IPI and WID
                        if (ipiFileInfo != null)
                        {
                            CreateUpdateFromTranFilesSubject(ipiFileInfo, "IPI");
                            PlanWidUpdateTasks(widUpdFileInfoList.Where(x => x.UpdDt.Date == nextDate.Date).OrderBy(x => x.UpdDt).ToList(), widUpdSubjList);
                            // If we are not sure that all WID updates for nextDate are planned postpone subsequent dates processing
                            if (!widUpdFileInfoList.Any(x => x.UpdDt.Date > nextDate))
                            {
                                break;
                            }
                        }
                        // Plan updates for WID only (hardly possible by IPI updates for some dates may not be available)
                        else if (ipiUpdFileInfoList.Any(x => x.UpdDt.Date > nextDate))
                        {
                            PlanWidUpdateTasks(widUpdFileInfoList.Where(x => x.UpdDt.Date == nextDate.Date).OrderBy(x => x.UpdDt).ToList(), widUpdSubjList);
                            // If we are not sure that all WID updates for nextDate are planned postpone subsequent dates processing
                            if (!widUpdFileInfoList.Any(x => x.UpdDt.Date > nextDate))
                            {
                                break;
                            }
                        }
                        // Nothing known about IPI updates for nextDate
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private DateTime GetWidLastPlannedTs(List<WidTaskSubjectEntity> subjList, DateTime defValue)
        {
            var lastPlannedFileName = subjList.Max(x => x.WidTaskObjects.Max(y => y.ObjectInfo) ?? "") ?? "";
            return lastPlannedFileName == "" ? defValue : ParseWidFileTs(lastPlannedFileName);
        }

        private DateTime GetIpiLastPlannedTs(List<WidTaskSubjectEntity> subjList, DateTime defValue)
        {
            var lastPlannedFileName = subjList.Max(x => x.WidTaskObjects.Max(y => y.ObjectInfo) ?? "") ?? "";
            return lastPlannedFileName == "" ? defValue : ParseIpiFileTs(lastPlannedFileName);
        }

        private DateTime? PlanWidUpdateTasks(List<UpdFileInfo> fileInfoList, List<WidTaskSubjectEntity> subjects)
        {
            DateTime? lastPlannedTs = null;
            var subjId = 0;
            var taskDate = new DateTime(1900, 1, 1);
            fileInfoList.ForEach(x =>
            {
                var subj = subjects.SingleOrDefault(y => y.TasksDate == x.UpdDt.Date);
                if (subj != null)
                {
                    subjId = subj.Id;
                }
                else if (taskDate != x.UpdDt.Date)
                {
                    taskDate = x.UpdDt.Date;
                    subjId =
                        CreateWidTaskSubject(_currentPeriod.Id, WidTaskSubjectTypeCodeEnum.UpdateFromTranFiles, "WID", taskDate);
                }
                if(subj == null || !subj.WidTaskObjects.Any(y => y.ObjectInfo == x.FileName))
                {
                    CreateUpdateFromTranFileTasks(subjId, x, true);
                }
                lastPlannedTs = x.UpdDt;
            });
            return lastPlannedTs;
        }

        private int CreateUpdateFromTranFilesSubject(UpdFileInfo updFileInfo, string db)
        {
            var subjId = CreateWidTaskSubject(_currentPeriod.Id, WidTaskSubjectTypeCodeEnum.UpdateFromTranFiles, db, updFileInfo.UpdDt.Date);
            CreateUpdateFromTranFileTasks(subjId, updFileInfo, db == "WID");
            return subjId;
        }

        private int CreateUpdateFromTranFileTasks(int subjId, UpdFileInfo updFileInfo, bool includeUnzip)
        {
            var lastTaskId = GetLastTaskId();
            Logger.WriteLine($"        Creating object {updFileInfo.FileName} for subject {subjId}");
            var newObjId = CreateWidTaskObject(subjId, updFileInfo.FileName);

            Logger.WriteLine($"        Creating FileDownload task for object {lastTaskId}");
            lastTaskId = CreateWidTask(newObjId, WidTaskTypeCodeEnum.FileDownload, lastTaskId);

            if (includeUnzip)
            {
                Logger.WriteLine($"        Creating FileUnzip task for object {lastTaskId}");
                lastTaskId = CreateWidTask(newObjId, WidTaskTypeCodeEnum.FileUnzip, lastTaskId);

                Logger.WriteLine($"        Creating FileZipDelete task for object {lastTaskId}");
                lastTaskId = CreateWidTask(newObjId, WidTaskTypeCodeEnum.FileZipDelete, lastTaskId);
            }

            Logger.WriteLine($"        Creating FileApplyToSocDb task for object {lastTaskId}");
            lastTaskId = CreateWidTask(newObjId, WidTaskTypeCodeEnum.FileApplyToSocDb, lastTaskId);

            Logger.WriteLine($"        Creating FileApplyToDb task for object {lastTaskId}");
            lastTaskId = CreateWidTask(newObjId, WidTaskTypeCodeEnum.FileApplyToDb, lastTaskId);

            Logger.WriteLine($"        Creating FileDelete task for object {lastTaskId}");
            lastTaskId = CreateWidTask(newObjId, WidTaskTypeCodeEnum.FileDelete, lastTaskId);

            return (int)lastTaskId;
        }

        private void CreateInitNewDumpTasks()
        {
            int? lastTaskId = GetLastTaskId();

            var subjectId = CreateWidTaskSubject(_currentPeriod.Id, WidTaskSubjectTypeCodeEnum.InitNewDump, "WID", null);

            EntityInfo.GetEntityNames().ForEach(entityName =>
            {
                var objectId = CreateWidTaskObject(subjectId, entityName);
                var taskTypes = new List<WidTaskTypeCodeEnum> {
                    WidTaskTypeCodeEnum.FileDownload,
                    WidTaskTypeCodeEnum.FileUnzip,
                    WidTaskTypeCodeEnum.FileZipDelete,
                    WidTaskTypeCodeEnum.FileApplyToDb,
                    WidTaskTypeCodeEnum.FileDelete,
                };
                taskTypes.ForEach(taskType =>
                {
                    lastTaskId = CreateWidTask(objectId, taskType, lastTaskId);
                });
            });

            subjectId = CreateWidTaskSubject(_currentPeriod.Id, WidTaskSubjectTypeCodeEnum.CalcNewDumpTs, "WID", null);
            var objectId = CreateWidTaskObject(subjectId, "AllWidTables");
            lastTaskId = CreateWidTask(objectId, WidTaskTypeCodeEnum.CalcWidDumpTs, lastTaskId);

            LoadCurrentPeriod();
        }

        private void CreateUpdateFromNewDumpTasks()
        {
            int? lastTaskId = GetLastTaskId();

            var subjectId = CreateWidTaskSubject(_currentPeriod.Id, WidTaskSubjectTypeCodeEnum.UpdateFromNewDump, "WID", null);
            var objectId = CreateWidTaskObject(subjectId, "WidDatabases");
            lastTaskId = CreateWidTask(objectId, WidTaskTypeCodeEnum.RenSocWidToSocWid_, lastTaskId);
            lastTaskId = CreateWidTask(objectId, WidTaskTypeCodeEnum.RenSocWidInitialToSocWid, lastTaskId);
            lastTaskId = CreateWidTask(objectId, WidTaskTypeCodeEnum.RenSocWid_ToSocWidInitial, lastTaskId);

            LoadCurrentPeriod();
        }

        private List<string> ReadFtpDirectory(string targetPath)
        {
            Logger.WriteLine($"    Reading directory lines from {_widConfig.WidFtpUrl}/{targetPath}");
            var ftpClient = new FtpClient(_widConfig.WidFtpUrl, _widConfig.WidFtpLogin, _widConfig.WidFtpPassword);
            return ftpClient.ReadDirectory(targetPath);
        }

        private List<UpdFileInfo> ReadWidUpdateFilesInfo()
        {
            var targetPath = _widConfig.WidFtpUpdatesPath;
            Logger.WriteLine($"    Reading directory lines from {_widConfig.WidFtpUrl}/{targetPath}");
            var ftpClient = new FtpClient(_widConfig.WidFtpUrl, _widConfig.WidFtpLogin, _widConfig.WidFtpPassword);
            var dirLines = ftpClient.ReadDirectory(targetPath);
            var retVal = new List<UpdFileInfo>();
            dirLines.ForEach(x => {
                var fileName = x.Split(' ').Last();
                var updDt = ParseWidFileTs(fileName);
                retVal.Add(new UpdFileInfo
                {
                    FileName = fileName,
                    UpdDt = updDt,
                });
            });
            return retVal;
        }

        private DateTime ParseWidFileTs(string fileName)
        {
            return new DateTime
            (
                int.Parse(fileName.Substring(3, 4)),
                int.Parse(fileName.Substring(7, 2)),
                int.Parse(fileName.Substring(9, 2)),
                int.Parse(fileName.Substring(11, 2)),
                int.Parse(fileName.Substring(13, 2)),
                int.Parse(fileName.Substring(5, 2))
            );
        }

        private List<UpdFileInfo> ReadIpiUpdateFilesInfo()
        {
            var targetPath = _widConfig.IpiFtpUpdatesPath;
            Logger.WriteLine($"    Reading directory lines from {_widConfig.IpiFtpUrl}/{targetPath}");
            var ftpClient = new FtpClient(_widConfig.IpiFtpUrl, _widConfig.IpiFtpLogin, _widConfig.IpiFtpPassword, true);
            var dirLines = ftpClient.ReadDirectory(targetPath);
            var retVal = new List<UpdFileInfo>();
            dirLines.Where(x => x.EndsWith(".IPI")).ToList().ForEach(x =>
            {
                var fileName = x.Split(' ').Last();
                var updDt = ParseIpiFileTs(fileName);
                retVal.Add(new UpdFileInfo
                {
                    FileName = fileName,
                    UpdDt = updDt,
                });
            });
            return retVal;
        }

        private DateTime ParseIpiFileTs(string fileName)
        {
            return new DateTime
            (
                int.Parse(fileName.Substring(0, 4)),
                int.Parse(fileName.Substring(4, 2)),
                int.Parse(fileName.Substring(6, 2))
            );
        }

        private long GetWidDumpFilesTotalSize()
        {
            var dirEntries = ReadFtpDirectory(_widConfig.WidFtpDumpPath);
            return dirEntries
                .Where(x => x.Split(' ').Last().EndsWith(".zip"))
                .ToList()
                .ConvertAll(x => long.Parse(x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[4]))
                .Sum(x => x); ;
        }

        private int? GetLastTaskId()
        {
            return _dbContext.WidTasks.Single(x => x.NextWidTaskId == null).Id;
        }
    }
}
