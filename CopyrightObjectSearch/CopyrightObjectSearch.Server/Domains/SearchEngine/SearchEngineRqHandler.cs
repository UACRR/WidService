using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace CopyrightObjectSearch.Server
{
    public class SearchEngineRqHandler
    {
        private readonly Mapper _mapper;

        private readonly CopyrightObjectSearchDbContext _dbContext;

        public SearchEngineRqHandler(CopyrightObjectSearchDbContext dbContext)
        {
            _dbContext = dbContext;

            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<ExternalObject, ExternalObjectDto>();
            }));

        }
        public IEnumerable<ExternalObjectDto> GetExternalObjects()
        {
            var externalObjects = _dbContext
                .ExternalObjects
                .Where(x => x.FoundObjId != 0 || x.FoundWic != 0)
                .Take(100)
                .ToArray();
            return _mapper.Map<ExternalObject[], ExternalObjectDto[]>(externalObjects);
        }

        public GetFoundObjectsRsp GetFoundObjects(SearchParamsDto searchParamsDto)
        {
            var retVal = new GetFoundObjectsRsp();
            try
            {
                var searcher = new MwSearchWid(_dbContext, searchParamsDto.SearchConditions.ToList());
                retVal.FoundNameAuthorsPerformers = searcher.Search();
            }
            catch(SqlException ex)
            {
                retVal.ErrorText = "Не вдалось завершити пошук за відведені 30 сек";
            }
            catch(Exception ex)
            {
                retVal.ErrorText = ex.Message;
            }
            return retVal;
        }

        private void SetObjId(int externalObjectId, int objId)
        {
            _dbContext.Database.ExecuteSqlRaw("exec spSetExternalObjectObjId {0}, {1}", externalObjectId, objId);
        }

        private void SetWic(int externalObjectId, int wic)
        {
            _dbContext.Database.ExecuteSqlRaw("exec spSetExternalObjectWic {0}, {1}", externalObjectId, wic);
        }

        private void SetIswc(int externalObjectId, string iswc)
        {
            _dbContext.Database.ExecuteSqlRaw("exec spSetExternalObjectIswc {0}, {1}", externalObjectId, iswc);
        }

        public SetWorkCodeRsp SetWorkCode(SetWorkCodeRq setWorkCodeRq)
        {
            var code = setWorkCodeRq.WorkCode;
            if (code[0] == 'M')
            {
                var intCode = int.Parse(code.Substring(2, code.Length - 2));
                SetObjId(setWorkCodeRq.ExternalObjectId, intCode);
            }
            else if (code[0] == 'W')
            {
                var intCode = int.Parse(code.Substring(2, code.Length - 2));
                SetWic(setWorkCodeRq.ExternalObjectId, intCode);
            }
            else if (code[0] == 'T')
            {
                SetIswc(setWorkCodeRq.ExternalObjectId, code);
            }

            var codes = _dbContext.ExternalObjects
                .Single(x => x.Id == setWorkCodeRq.ExternalObjectId );

            var retVal = new SetWorkCodeRsp {
                ExternalObjectId = codes.Id,
                ObjId = codes.FoundObjId,
                Wic = codes.FoundWic,
                Iswc = codes.FoundIswc
            };

            if (code[0] == 'M')
            {
                var intCode = int.Parse(code.Substring(2, code.Length - 2));
                if(intCode != retVal.ObjId)
                {
                    retVal.ErrorText = "Невірний код - не знайдено твору з таким кодом";
                }
            }
            else if (code[0] == 'W')
            {
                var intCode = int.Parse(code.Substring(2, code.Length - 2));
                if(intCode != retVal.Wic)
                {
                    retVal.ErrorText = "Невірний код - не знайдено твору з таким кодом";
                }
            }

            return retVal;
        }
    }
}
