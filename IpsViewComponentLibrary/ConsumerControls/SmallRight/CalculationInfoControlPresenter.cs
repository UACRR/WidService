using System.Collections.Generic;
using System.Linq;
using ipsFormsDesign;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight
{
    public class CalculationInfoControlPresenter
    {
        private readonly ConsumerService _service;
        readonly CalculationInfoControl _control;

        public CalculationInfoControlPresenter(CalculationInfoControl control, ConsumerService service)
        {
            _service = service;
            _control = control;
            _control.SaveLinkCommandExecuted += SaveLinkCommandExecuted;
            _control.SavePariodCommandExecuted += SavePariodCommandExecuted;
            _control.SetPeriodStateExecuted += _control_SetPeriodStateExecuted;
        }

        private void _control_SetPeriodStateExecuted(object sender, PaidPeriod e)
        {
            _service.SetPeriodState((PeriodState) e.Status, e);
        }

        private void SaveLinkCommandExecuted(object sender, List<MoneyPeriodLink> e)
        {
            int? custId = _control?.Customer?.CustId;
            if (custId == null)
                return;
            List<MoneyPeriodLink> retList = _service.SaveLink((int)custId, e);
            if (retList != null)
            {
                var dic = retList.ToDictionary(rec => new { rec.PeriodId, rec.PaidId });
                e.ForEach(dest =>
                {
                    var sors = dic[new { dest.PeriodId, dest.PaidId }];
                    dest.SetFields(sors);
                    dest.Paid.SetFields(sors.Paid);
                });
            }
        }

        private void SavePariodCommandExecuted(object sender, List<PaidPeriod> e)
        {
            int? custId = _control?.Customer?.CustId;
            if (custId == null)
                return;
            List<PaidPeriod> retList = _service.SavePeriods((int)custId, e);
            if (retList != null)
            {
                // TODO: MED-662
                var dic = retList.ToDictionary(di => di.PeriodName);
                foreach (var item in e)
                {
                    var period = dic[item.PeriodName];
                    if (item.PeriodId != period.PeriodId)
                        item.PeriodId = period.PeriodId;
                }
            }
        }
    }
}
