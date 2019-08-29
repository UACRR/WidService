using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.ViewModels.Other;
using IpsCommonTypes.Wrappers;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class PublisherAndSubpublisherSevice
    {
        private const string Prefix = "PublisherAndSubpublisher";
        private readonly ApiConnector _apiConnector;
        private static PublisherAndSubpublisherSevice _sevice;

        private PublisherAndSubpublisherSevice()
        {
            _apiConnector = new ApiConnector();
        }

        public static PublisherAndSubpublisherSevice GetInstance()
        {
            if (_sevice == null)
                _sevice = new PublisherAndSubpublisherSevice();

            return _sevice;
        }

        public List<PublisherAndSubpublisherView> GetPublisherAndSubpublisherList()
        {
            string url = $"{Prefix}/list";
            var result = _apiConnector.GetList<PublisherAndSubpublisherView>(url);
            return result;
        }
    }
}
