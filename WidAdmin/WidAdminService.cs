using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SharedLib;
using SharedLib.Dto;
using SharedLib.Requests;
using SharedLib.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WidAdminLib.Entities;
using WidServiceLib;

namespace WidAdminLib
{
    public class WidAdminService
    {
        private WidConfigurationEntity _defaultConfiguration = new WidConfigurationEntity
        {
            Name = "Development environment",
            WidFtpUrl = "ftp://ftp-aws.fasttrackdcn.net",
            WidFtpLogin = "wid_140",
            WidFtpPassword = "ad1WropKoPhlyb",
            WidFtpDumpPath = "wid-dump",
            WidFtpUpdatesPath = "outbox/SOC",
            WidWorkFilesRootPath = @"D:\UACRR\WID\ReplicationWorkFiles\Wid",

            IpiFtpUrl = "ftp://ftp.suisa.ch",
            IpiFtpLogin = "UACRR",
            IpiFtpPassword = "0RvLrb0M",
            IpiFtpDumpPath = "IPI/IPI_Pub/Complete_IPI",
            IpiFtpUpdatesPath = "IPI/download",
            IpiWorkFilesRootPath = @"D:\UACRR\WID\ReplicationWorkFiles\Ipi",

            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
    private WidAdminDbContext _dbContext;
        private static IMapper _mapper;

        private delegate void TaskRunner(WidTaskEntity task);
        
        private static bool _stop = true;

        private static readonly object _lock = new object();

        public WidAdminService()
        {
            lock (_lock)
            {
                if (_dbContext == null)
                {
                    _dbContext = new WidAdminDbContext();
                }
                if(_mapper == null)
                {
                    _mapper = new MapperConfiguration(cfg => {
                        cfg.CreateMap<WidConfigurationEntity, WidConfigurationDto>();
                        cfg.CreateMap<WidConfigurationDto, WidConfigurationEntity>();
                        cfg.CreateMap<WidUpdatePeriodEntity, WidUpdatePeriodDto>();
                        cfg.CreateMap<WidTaskSubjectEntity, WidTaskSubjectDto>();
                        cfg.CreateMap<WidTaskObjectEntity, WidTaskObjectDto>();
                        cfg.CreateMap<WidTaskEntity, WidTaskDto>();
                    }).CreateMapper();
                }
            }
        }

        public WidConfigurationRsp GetConfiguration()
        {
            var widConfiguration = _dbContext.WidConfigurations.First();

            var retVal = new WidConfigurationRsp
            {
                WidConfiguration = 
                    _mapper.Map<WidConfigurationEntity, WidConfigurationDto>(widConfiguration),
            };

            return retVal;
        }
        public bool UpdateConfiguration(WidConfigurationRq rq)
        {
            if(IsRunning())
            {
                return false;
            }

            if(_dbContext.WidTasks.Any(x => x.WidTaskStatusId == (int)WidTaskStatusCodeEnum.Completed))
            {
                return false;
            }

            var widConfiguration = _dbContext.WidConfigurations
                .Single(x => x.Id == rq.WidConfiguration.Id);
            _mapper.Map(rq.WidConfiguration, widConfiguration);
            _dbContext.SaveChanges();
            return true;
        }
        public WidAllTasksRsp GetWidAllTasks()
        {
            var periods = _dbContext.WidUpdatePeriods
               .Include(x => x.WidTaskSubjects)
               .ThenInclude(x => x.WidTaskObjects)
               .ThenInclude(x => x.WidTasks)
               .ToList();

            periods.ForEach(x =>
            {
                var dto = _mapper.Map<WidUpdatePeriodEntity, WidUpdatePeriodDto>(x);
            });
            return new WidAllTasksRsp
            {
                WidUpdatePeriods =  _mapper.Map<List<WidUpdatePeriodEntity>, List<WidUpdatePeriodDto>>(periods),
            };
        }

        private void SetStarted()
        {
            lock (_lock)
            {
                _stop = false;
            }
        }
        private void SetStopped()
        {
            lock (_lock)
            {
                _stop = true;
            }
        }
        private bool IsRunning()
        {
            lock (_lock)
            {
                return !_stop;
            }
        }

        private int GetFirstWcfgId()
        {
            return _dbContext.WidConfigurations
                .OrderBy(x => x.Id)
                .First()
                .Id;
        }

        public WidConfigurationEntity GetConfiguration(int wcfgId)
        {
            return _dbContext.WidConfigurations
                .Single(x => x.Id == wcfgId);
        }

        private void AddConfiguration(WidConfigurationEntity entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

    }
}
