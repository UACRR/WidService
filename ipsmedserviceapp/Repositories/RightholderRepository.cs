using ipsmedserviceapp.Model;
using ipsmedserviceapp.Model.SQLViewsData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using RightholderMainView = ipsmedserviceapp.Model.SQLViewsData.RightholderMainView;

namespace ipsmedserviceapp.Repositories
{
    public class RightholderRepository
    {
        private readonly MediaServiceContext _dbContext;

        public RightholderRepository(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public RightHolder GetRightholderById(int custId, DateTime? includeCopyrightsOnDate = null, int[] copyRightIds = null)
        {
            var query = _dbContext.RightHolder;

            var rightholder = query.FirstOrDefault(r => r.CustId == custId);

            if (includeCopyrightsOnDate != null)
            {
                var checkDate = new DateTime(includeCopyrightsOnDate.Value.Year,
                    includeCopyrightsOnDate.Value.Month,
                    includeCopyrightsOnDate.Value.Day);

                if (rightholder != null)
                {
                    List<CopyRight> copyrights = null;
                    if(copyRightIds != null && copyRightIds.Any())
                    {
                        copyrights = _dbContext.Entry(rightholder)
                            .Collection(r => r.CopyRight).Query()
                            .Where(cr => cr.BeginDate <= includeCopyrightsOnDate.Value
                                         && cr.EndDate >= includeCopyrightsOnDate.Value
                                         && copyRightIds.Contains(cr.CRightId))
                            .ToList();
                    }
                    else
                    {
                        copyrights = _dbContext.Entry(rightholder)
                            .Collection(r => r.CopyRight).Query()
                            .Where(cr => cr.BeginDate <= includeCopyrightsOnDate.Value
                                         && cr.EndDate >= includeCopyrightsOnDate.Value)
                            .ToList();
                    }
                }
            }

            return rightholder;
        }

        public List<RightholderMainView> GetRightholders(IEnumerable<int> ids = null)
        {
            var query = "select * from vTsk_1_ListRightHolder01";
            List<RightholderMainView> list;

            // ReSharper disable once PossibleMultipleEnumeration
            if (ids != null && ids.Any())
            {
                var enumerable = ids.ToArray();
                query += $" where custId in (@ids)";
                var param = new SqlParameter("@ids", $"{string.Join(", ", enumerable)}");
                list = _dbContext.RightholderMainView.FromSql(query, param).ToList();
            }
            else
            {
                list = _dbContext.RightholderMainView.FromSql(query).ToList();
            }

            return list;
        }
    }
}
