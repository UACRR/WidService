using ipsFormsDesign.Model;
using ipsFormsDesign.Model.SQLViewsData;
using System.Collections.Generic;
using WebAPIConnector;


namespace ipsFormsDesign.Services
{
    public class DbfService
    {
        private readonly string _prefix = "expay/";

        private readonly ApiConnector _webApi;
        private static DbfService _service;

        private DbfService()
        {
            _webApi = new ApiConnector();
        }

        public static DbfService GetInstance()
        {
            if (_service == null)
                _service = new DbfService();

            return _service;
        }

        public List<ExternalPay> GetUnlinkPays()
        {
            string url = string.Concat(_prefix, "unlink");
            var list = _webApi.GetList<ExternalPay>(url);

            return list;
        }

        public List<ExternalPay> SaveListLinkedPays( List<ExternalPay> list )
        {
            string url = string.Concat(_prefix, "unlink");
            List<ExternalPay> retList = null;
            var result = _webApi.UpdateListItemWithReturn(url, null, list, out retList );

            if (result == false)
                return null;

            return retList;

        }

        public ExternalPay SaveLinkedPay( ExternalPay pay )
        {
            string url = string.Concat(_prefix, "unlink");
            var result = _webApi.UpdateItemWithResult(url, pay.PaidId.ToString(), pay);

            return result;
        }

        public InputFile CheckInputFile( InputFile file )
        {
            string url = string.Concat(_prefix, "file");
            var result = _webApi.NewItemWithResult(url, file);

            return result;

        }

        public InputFile SaveInputFile( InputFile file )
        {

            string url = string.Concat(_prefix, "file");
            var result = _webApi.UpdateItemWithResult(url, file.FileId.ToString(), file);

            return result;
        }

        public bool DeleteInputFile( InputFile file )
        {
            string url = string.Concat(_prefix, "file");
            return _webApi.DeleteItem(url, file.FileId.ToString());

        }

        public List<vCustomer> GetListOfConsumers()
        {
            string url = string.Concat(_prefix, "vCustomers");
            return _webApi.GetList<vCustomer>(url);

        }
    }
}
