using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Model;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class ConsumerRegisterService
    {
        private const string Prefix = "ConsumerRegister";
        private static ConsumerRegisterService _service;
        private readonly ApiConnector _apiConnector;

        private ConsumerRegisterService()
        {
            _apiConnector = new ApiConnector();
        }

        public static ConsumerRegisterService GetInstance()
        {
            if (_service == null)
                _service = new ConsumerRegisterService();

            return _service;
        }

        public async Task<List<LicenseAgreement>> GetLicenseAgreementList(int custId)
        {
            string url = $"{Prefix}/licenses/{custId}";
            var result = await _apiConnector.GetListAsync<LicenseAgreement>(url);
            return result;
        }
    }
}
