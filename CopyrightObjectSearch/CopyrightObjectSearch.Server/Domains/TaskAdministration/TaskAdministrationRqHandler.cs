using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace CopyrightObjectSearch.Server
{
    public class TaskAdministrationRqHandler
    {
        private readonly Mapper _mapper;

        private readonly CopyrightObjectSearchDbContext _dbContext;

        public TaskAdministrationRqHandler(CopyrightObjectSearchDbContext dbContext)
        {
            _dbContext = dbContext;

            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<PartnerWork, PartnerWorkDto>();
            }));
        }

        public IEnumerable<GetPartnerWorkSourcesRsp> GetPartnerWorkSources(GetPartnerWorkSourcesRq rq)
        {
            var quarter = (rq.Month - 1) / 3 + 1;
            var partnerWorkSources = _dbContext
                .PartnerWorkSources
                .Include(x => x.Partner)
                .Include(x => x.SourceType)
                .Select(x => new GetPartnerWorkSourcesRsp
                {
                    PartnerWorkSourceId = x.Id,
                    Title               = x.Title,
                    PartnerId           = x.PartnerId,
                    PartnerName         = x.Partner.Description??"",
                    SourceId            = x.SourceId,
                    SourceTypeId        = x.SourceTypeId,
                    SourceTypeName      = x.SourceType.Description,
                    Year                = x.Year,
                    Month               = x.Month,
                    Quarter             = x.Quarter,
                })
                .Where(x => x.PartnerId == rq.PartnerId &&
                    x.SourceTypeId == rq.SourceTypeId &&
                    x.Year == rq.Year &&
                    (x.Month == rq.Month || x.Quarter == quarter)
                )
                .OrderBy(x => x.Title)
                .ToArray();
            
            return partnerWorkSources;
        }

        public GetPartnerWorkFilterInfoRsp GetPartnerWorkFilterInfo()
        {
            var partners = _dbContext
                .Partners
                .Include(x => x.PartnerToSourceType)
                .ToList();

            var partnerToSourceType = _dbContext
                .PartnerToSourceType
                .Include(x => x.SourceType)
                .ToList();

            var partnerDtoList = new List<GetPartnerWorkFilterInfoRsp.PartnerDto>();

            partners.ForEach(x =>
            {
                var sourceTypesSourceTypes = partnerToSourceType
                    .Where(y => y.PartnerId == x.Id)
                    .Select(y => new GetPartnerWorkFilterInfoRsp.SourceTypeDto
                    {
                        SourceTypeId    = y.SourceTypeId,
                        SourceTypeName  = y.SourceType == null ? "" : y.SourceType.Description,
                    })
                    .ToList(); 
                
                var partnerDto = new GetPartnerWorkFilterInfoRsp.PartnerDto
                {
                    PartnerId = x.Id,
                    PartnerName = x.Description ?? "",
                    SourceTypes = sourceTypesSourceTypes,

                };

                partnerDtoList.Add(partnerDto);
            });

            var minYear = _dbContext.PartnerWorkSources.Min(x => x.Year);
            var maxYear = _dbContext.PartnerWorkSources.Max(x => x.Year);

            return new GetPartnerWorkFilterInfoRsp { 
                Partners = partnerDtoList,
                MinYear = minYear,
                MaxYear = maxYear,
            };
        }

        public GetPlannedTaskNameRsp GetPlannedTaskName(GetPlannedTaskNameRq rq)
        {
            var partnerWorkSource = _dbContext
                .PartnerWorkSources
                .Include(x => x.Partner)
                .Include(x => x.SourceType)
                .Single(x => x.Id == rq.PartnerWorkSourceId);

            int partnerWorksRange = 1;
            if(_dbContext.UserTasks.Any(x => x.PartnerWorkSourceId == rq.PartnerWorkSourceId))
            {
                partnerWorksRange = _dbContext
                    .UserTasks
                    .Where(x => x.PartnerWorkSourceId == rq.PartnerWorkSourceId)
                    .Max(x => x.PartnerWorksRange) + 1;
            }

            var partnerName = partnerWorkSource.Partner.Description;
            var sourceTypeName = partnerWorkSource.SourceType.Description;
            var year = partnerWorkSource.Year;
            var q_m_text = "";
            if(partnerWorkSource.Quarter != 0)
            {
                q_m_text = $"квартал_{partnerWorkSource.Quarter}";
            }
            else
            {
                q_m_text = $"місяць_{partnerWorkSource.Month}";
            }

            return new GetPlannedTaskNameRsp
            {
                TaskTitle = $"{partnerName}_{sourceTypeName}_{year}_{q_m_text}_блок_{partnerWorksRange}",
            };
        }
    }
}
