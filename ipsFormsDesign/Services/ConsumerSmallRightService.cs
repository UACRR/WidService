using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Data;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class ConsumerSmallRightService: ConsumerService
    {
        private static ConsumerSmallRightService _service;

        private ConsumerSmallRightService() { }

        public static ConsumerSmallRightService GetInstance()
        {
            if (_service == null)
                _service = new ConsumerSmallRightService();

            if (IpsGlobal.AnketaDictionaties == null)
                IpsGlobal.SetAnketaDictionaties(_service.GetDictionary());

            return _service;
        }
    }
}
