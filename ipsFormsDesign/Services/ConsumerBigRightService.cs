using ipsFormsDesign.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Services
{
    public class ConsumerBigRightService : ConsumerService
    {
        private static ConsumerBigRightService _service;

        private ConsumerBigRightService() { }

        public static ConsumerBigRightService GetInstance()
        {
            if (_service == null)
                _service = new ConsumerBigRightService();

            if (IpsGlobal.AnketaDictionaties == null)
                IpsGlobal.SetAnketaDictionaties(_service.GetDictionary());

            return _service;
        }
    }
}
