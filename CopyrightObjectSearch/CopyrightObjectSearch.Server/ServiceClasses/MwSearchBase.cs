using System;
using System.Collections.Generic;
using System.Text;
using static CopyrightObjectSearch.Server.SearchParamsDto;

namespace CopyrightObjectSearch.Server
{
    public class MwSearchBase
    {
        protected CopyrightObjectSearchDbContext _dbContext;
        protected List<SearchConditionDto> _searchConditions;

        protected MwSearchBase(CopyrightObjectSearchDbContext dbContext,
            List<SearchConditionDto> searchConditions)
        {
            _dbContext = dbContext;
            _searchConditions = searchConditions;
        }
    }
}
