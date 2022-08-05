using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Model;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class ConsumerAgreementService
    {
        private const string Prefix = "consumeragreement";
        private static ConsumerAgreementService _service;
        private readonly ApiConnector _apiConnector;

        private ConsumerAgreementService()
        {
            _apiConnector = new ApiConnector();
        }

        public static ConsumerAgreementService GetInstance()
        {
            if (_service == null)
                _service = new ConsumerAgreementService();

            return _service;
        }

        public bool CreateAgreement(LicenseAgreement licenseAgreement)
        {
            string url = $"{Prefix}/create";
            var result = _apiConnector.NewItem(url, licenseAgreement);
            return result;
        }

        public bool CreateAgreementVersion(LicenseAgrParam licenseAgrParam, bool isProlong = false)
        {
            string url = $"{Prefix}/createversion/{isProlong}";
            var result = _apiConnector.NewItem(url, licenseAgrParam);
            return result;
        }

        public bool UpdateAgreement(LicenseAgrParam licenseAgrParam)
        {
            string url = $"{Prefix}/update";
            var result = _apiConnector.UpdateItem(url, null, licenseAgrParam);
            return result;
        }

        public bool ChangeLicenseAgreementStatus(int licenseId, int licenseVersion, int status, bool versionChanging)
        {
            string url = $"{Prefix}/licensestatus/{licenseId}/{licenseVersion}/{status}/{versionChanging}";
            var result = _apiConnector.UpdateItem<object>(url, null, null);
            return result;
        }

        public bool SaveAgreementComment(LicenseAgrParam licenseAgrParam)
        {
            string url = $"{Prefix}/updatecomment";
            var result = _apiConnector.UpdateItem(url, null, licenseAgrParam);
            return result;
        }
    }
}
