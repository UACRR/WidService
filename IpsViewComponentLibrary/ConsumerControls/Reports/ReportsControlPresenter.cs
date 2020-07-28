using System.Collections.Generic;
using System.Linq;
using ipsFormsDesign;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.ConsumerControls.SmallRight;

namespace IpsViewComponentLibrary.ConsumerControls.Reports
{
    public class ReportsControlPresenter
    {
        private readonly ReportsControl _control;
        private readonly ConsumerService _service;

        public ReportsControlPresenter(ReportsControl control, ConsumerService service)
        {
            _control = control;
            _service = service;

            _control.SaveRegisterRatedListExecuted += SaveRegisterRatedListExecuted;
            _control.GetRegisterItems = _service.GetRegisterItems;
            _control.DeleteRegisterExecuted += DeleteRegisterExecuted;
            _control.SaveRegisterExecuted += SaveRegisterExecuted;
            _control.SetRegisterStateExecuted += _control_SetRegisterStateExecuted;
            _control.SetPeriodStateExecuted += _control_SetPeriodStateExecuted;
            _control.SavePariodCommandExecuted += SavePariodCommandExecuted;
            _control.UpdateData += UpdateData;

        }

        private void UpdateData(int custId)
        {
            var mainCust = _service.GetData(custId);
            var regCust = _service.GetRatedListForCust(custId);

            CloneRegisterRL(mainCust, regCust);

            _control.Customer = regCust;
        }

        private void CloneRegisterRL(Customer mainCust, Customer regCust)
        {
            if (mainCust == null || regCust == null)
                return;
            // Прив'язати розрахункові листи до договорів
            foreach (var mainLic in mainCust.Client.LicenseAgreement)
            {
                var destLic = regCust.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == mainLic.LicId);
                if (destLic == null) continue;

                foreach (var mainPeriod in mainLic.PaidPeriod)
                {
                    var destPeriod = destLic.PaidPeriod.SingleOrDefault(rec => rec.PeriodId == mainPeriod.PeriodId);
                    if (destPeriod == null) continue;

                    foreach (var destRl in destPeriod.RegisterRatedList)
                    {
                        var mainRl = mainPeriod.RegisterRatedList.SingleOrDefault(rec => rec.RmId == destRl.RmId);
                        if (mainRl == null)
                            mainPeriod.RegisterRatedList.Add(destRl);
                    }
                }
            }
        }

        private bool SaveRegisterExecuted(Register e)
        {
            return _service.SaveRegister(e);
        }

        private void _control_SetPeriodStateExecuted(object sender, PaidPeriod e)
        {
            if (e == null)
                return;

            _service.SetPeriodState(e);
        }

        private void _control_SetRegisterStateExecuted(object sender, List<Register> e)
        {
            Register first = e.First();
            int state = first.RgStatus ?? 0;
            var retList = _service.SetRegisterState((RegisterState)state, e);
            if (state == 3)
            {
                first.Rm.Status = 1;
                first.Rm.Period.Status = 2;
                _control.RefreshData();
            }
        }

        private bool DeleteRegisterExecuted(Register register)
        {
            return _service.DeleteRegister(register);
        }

        private bool SaveRegisterRatedListExecuted(RegisterRatedList e)
        {
            var result = _service.SaveRegisterRatedList(e, out RegisterRatedList ratedList);
            if (result)
            {
                var dic = ratedList.Register.ToDictionary(rec => rec.FileName);
                e.SetFields(ratedList);
                foreach (var item in e.Register)
                {
                    var sors = dic[item.FileName];
                    item.SetFields(sors);
                    item.RegisterItem.Clear();
                    foreach (var sorsItem in sors.RegisterItem)
                        item.RegisterItem.Add(sorsItem);
                }
            }
            return result;
        }

        private void SavePariodCommandExecuted(object sender, List<PaidPeriod> e)
        {
            int? custId = _control?.Customer?.CustId;
            if (custId == null)
                return;
            List<PaidPeriod> retList = _service.SavePeriods(custId.Value, e);
            if (retList != null)
            {
                var dic = retList.ToDictionary(di => new { di.LicId ,di.PeriodName } );
                foreach (var item in e)
                {
                    var period = dic[new { item.LicId, item.PeriodName}];
                    if (item.PeriodId != period.PeriodId)
                        item.PeriodId = period.PeriodId;
                }
            }
        }
    }
}
