using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class CopyrightRequestService
    {
        private readonly ApiConnector _webApi;
        private static CopyrightRequestService _service;

        private CopyrightRequestService()
        {
            _webApi = new ApiConnector();
        }

        public static CopyrightRequestService GetInstance()
        {
            if (_service == null)
                _service = new CopyrightRequestService();

            return _service;
        }

        public async Task<IList<RightolderWithNotAcceptedCopyrightViewModel>> GetCopyrightRequestRightholderList()
        {
            var list = await _webApi.GetListAsync<RightolderWithNotAcceptedCopyrightViewModel>("rh/withNotAcceptedCopyrights");
            return list;
        }

        public async Task<IList<ObjectRightNotAccepted>> GetNotAcceptedObjectsByRightholder(int custId)
        {
            var list = await _webApi.GetListAsync<ObjectRightNotAccepted>($"rh/notAcceptedObjects/{custId}");
            return list;
        }

        public bool UpdateCopyrights(List<CopyRight> copyrighList)
        {
            return _webApi.UpdateItem("rh/updateCopyrights", null, copyrighList);
        }
    }
}
