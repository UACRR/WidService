using ipsmedserviceapp.Model;
using ipsmedserviceapp.Model.SQLViewsData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Repositories
{
    public class RightholderRepository
    {
        private readonly MediaServiceContext _dbContext;

        public RightholderRepository(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public RightHolder GetRightholderById(int custId, DateTime? includeCopyrightsOnDate = null)
        {
            var query = _dbContext.RightHolder;

            var rightholder = query.FirstOrDefault(r => r.CustId == custId);

            if (includeCopyrightsOnDate != null)
            {
                var checkDate = new DateTime(includeCopyrightsOnDate.Value.Year,
                    includeCopyrightsOnDate.Value.Month,
                    includeCopyrightsOnDate.Value.Day);

                var copyrights = _dbContext.Entry(rightholder).Collection(r => r.CopyRight)
                    .Query()
                    .Where(cr => cr.BeginDate <= includeCopyrightsOnDate.Value && cr.EndDate >= includeCopyrightsOnDate.Value)
                    .ToList();
            }

            return rightholder;
        }

        public List<RightholderMainView> GetRightholders(IEnumerable<int> ids = null)
        {
            var query = _dbContext.RightholderMainView
                .FromSql("select * from vTsk_1_ListRightHolder01");

            if (ids != null)
                query = query.Where(r => ids.Contains(r.CustId));

            return query.ToList();
        }
    }
}
