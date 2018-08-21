using ipsFormsDesign;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary
{
    public class ReportsControlPresenter
    {
        private readonly ReportsControl _control;
        private readonly ConsumerService _service;
        public ReportsControlPresenter(ReportsControl control, ConsumerService service )
        {
            _control = control;
            _service = service;

            _control.SaveRegisterRatedListExecuted += SaveRegisterRatedListExecuted;
            _control.GetRegisterItems = _service.GetRegisterItems;
            _control.DeleteRegisterExecuted += DeleteRegisterExecuted;
            _control.SaveRegisterExecuted += SaveRegisterExecuted; ;
            _control.SetRegisterStateExecuted += _control_SetRegisterStateExecuted;
            _control.SetPeriodStateExecuted += _control_SetPeriodStateExecuted;
            _control.SavePariodCommandExecuted += SavePariodCommandExecuted;


        }

        private void SaveRegisterExecuted(object sender, Register e)
        {
            _service.SaveRegister(e);
        }

        private void _control_SetPeriodStateExecuted(object sender, PaidPeriod e)
        {
            if( e == null ) return;
            _service.SetPeriodState((ConsumerService.PeriodState)e.Status, e);
        }

        private void _control_SetRegisterStateExecuted(object sender, List<Register> e)
        {
            Register first = e.First();
            int state = first.RgStatus ?? 0;
            var retList = _service.SetRegisterState((ConsumerService.RegisterState)state, e);
            if (state == 3)
            {
                first.RegisterRatedList.Status = 1;
                first.RegisterRatedList.Period.Status = 2;
                _control.RefreshData();
            }
        }

        private void DeleteRegisterExecuted(object sender, Register e)
        {
            _service.DeleteRegister(e);
        }

        private void SaveRegisterRatedListExecuted(object sender, RegisterRatedList e)
        {
            RegisterRatedList ratedList = null;
            if (_service.SaveRegisterRatedList(e, out ratedList) == true)
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
        }

        private void SavePariodCommandExecuted(object sender, List<PaidPeriod> e)
        {
            int? custId = _control?.Customer?.CustId;
            if (custId == null)
                return;
            List<PaidPeriod> retList = _service.SavePeriods((int)custId, e);
            if (retList != null)
            {
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
