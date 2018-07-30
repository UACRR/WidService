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
    }
}
