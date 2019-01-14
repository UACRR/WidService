using ipsFormsDesign.Model;
using System.Collections.Generic;
using WebAPIConnector;


namespace ipsFormsDesign.Services
{
    public class DbfService
    {
        private readonly ApiConnector _webApi = new ApiConnector();
        private readonly string _prefix = "expay/";

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
    }
}
