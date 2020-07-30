using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.IntermediaryTypes;
using IpsCommonTypes.Types;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class ExportReportToFileService
    {
        private ApiConnector _apiConnector;
        private const string prefix = "ExportReportToFile";
        private static ExportReportToFileService _service;

        private ExportReportToFileService()
        {
            _apiConnector = new ApiConnector();
        }

        public static ExportReportToFileService GetInstance()
        {
            if (_service == null)
                _service = new ExportReportToFileService();
            
            return _service;
        }

        public async Task<Dictionary<int, string>> GetCustomRegisterTypes()
        {
            string url = $"{prefix}/customRegisterTypes";
            return await _apiConnector.GetRequestAsync<Dictionary<int, string>>(url);
        }


        public async Task<HttpResponseMessage> ExportDDEXRegisterById(int id, CultureInfo cultureInfo)
        {
            string url = $"{prefix}/DDEXRegister/{id}/{cultureInfo.Name}";
            return await _apiConnector.GetRequestAsync(url);
        }

        public async Task<HttpResponseMessage> ExportDefaultRegisterById(int id, CultureInfo cultureInfo)
        {
            string url = $"{prefix}/DefaultRegister/{id}/{cultureInfo.Name}";
            return await _apiConnector.GetRequestAsync(url);
        }

        public async Task<HttpResponseMessage> ExportOperationDataByPeriodDates(DateTime dateBegin, DateTime dateEnd, CultureInfo cultureInfo)
        {
            OperationDataByPeriodResource resource = new OperationDataByPeriodResource
            {
                DateBegin = dateBegin,
                DateEnd = dateEnd,
            };
            string url = $"{prefix}/OperationDataByPeriod/{cultureInfo.Name}";
            return await _apiConnector.PostRequestAsync(url, resource);
        }

        public async Task<HttpResponseMessage> GetRegisterByCustomType(int type, CultureInfo cultureInfo)
        {
            string url = $"{prefix}/RegisterByCustomType/{type}/{cultureInfo.Name}";
            return await _apiConnector.GetRequestAsync(url);
        }
    }
}
