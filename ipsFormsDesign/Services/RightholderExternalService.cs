using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Model;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class RightholderExternalService
    {
        private const string Prefix = "RightholderExternal";
        private readonly ApiConnector _apiConnector;
        private static RightholderExternalService _service;

        private RightholderExternalService()
        {
            _apiConnector = new ApiConnector();
        }

        public static RightholderExternalService GetInstance()
        {
            if (_service == null)
                _service = new RightholderExternalService();

            return _service;
        }

        /// <summary>
        /// Перевести зовнішнього правовласника у внітрішнього
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool TransferExternalRHToInternal(Customer customer)
        {
            var url = $"{Prefix}/transfer";
            var result = _apiConnector.UpdateItem<object>(url, customer.CustId.ToString(), null);
            return result;
        }
    }
}
