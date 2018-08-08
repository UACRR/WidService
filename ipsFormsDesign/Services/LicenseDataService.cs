using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class LicenseDataService
    {
        private readonly ApiConnector _webApi;

        public LicenseDataService()
        {
            _webApi = new ApiConnector();
        }

        public IList<BigRightRequests> GetLicenseAgreements(LicenseAgreementQuery query)
        {
            var list = _webApi.GetList<BigRightRequests>("licenseAgreements", query.ToKeyValuePair());

            return list;
        }
    }
}
