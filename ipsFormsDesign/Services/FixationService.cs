using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using ipsFormsDesign.ViewModels.Fixations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class FixationService
    {
        private readonly ApiConnector _webApi;

        public FixationService()
        {
            _webApi = new ApiConnector();
        }

        public List<FixationListViewModel> GetFixations(FixationQuery query)
        {
            var list = _webApi.GetList<FixationListViewModel>("fixations", query.ToKeyValuePair());
            return list;
        }

        public Task<List<FixationListViewModel>> GetFixationsAsync(FixationQuery query)
        {
            return Task.Factory.StartNew(() => GetFixations(query));
        }

        public Fixation New()
        {
            var now = DateTime.Now;
            var beginMonth = new DateTime(now.Year, now.Month, 1);
            var endMonth = new DateTime(now.Year, now.Month, beginMonth.AddMonths(1).AddDays(-1).Day);

            var fixation = new Fixation { StageStatus = 1, UsesType = 1 };

            fixation.Lic = new LicenseAgreement { LicType = 1, LicStatus = 2, LicVersion = 1, LicCode = 29 };
            fixation.Lic.Agr = new AgreementMaster { AgrStatus = 2, AgrType = 2 };
            var paidPeriod = new PaidPeriod { BeginDate = beginMonth, EndDate = endMonth, Status = 4, PeriodType = 1, PeriodName = $"{beginMonth.ToShortDateString()} - {endMonth.ToShortDateString()}" };
            fixation.Lic.PaidPeriod.Add(paidPeriod);
            var registerRatedList = new RegisterRatedList { Status = 1 };
            paidPeriod.RegisterRatedList.Add(registerRatedList);
            var register = new Register { SchemaId = 1, AlgorithmId = 2 };
            registerRatedList.Register.Add(register);

            return fixation;
        }

        public FixationModel GetById(int fixId)
        {
            var item = _webApi.GetItemById<FixationModel>("fixations", fixId.ToString());
            return item;
        }

        public bool Save(Fixation fixation)
        {
            if (fixation.FixId == 0)
            {
                return _webApi.NewItem("fixations", fixation);
            }
            else
            {
                return _webApi.UpdateItem("fixations", fixation.FixId.ToString(), fixation);
            }
        }

        public bool SetStatus(int fixId, FixationStageStatuses newStageStatus)
        {
            return _webApi.UpdateItem($"fixations/{fixId}/stagestatus", null, newStageStatus);
        }
    }
}
