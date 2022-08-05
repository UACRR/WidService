using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Model;
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

        /// <summary>
        /// Отримати список зв'язаних видавництв/субвидавництв
        /// </summary>
        /// <returns></returns>
        public List<PublisherAndSubpublisherView> GetPublisherAndSubpublisherList()
        {
            string url = $"{Prefix}/list/links";
            var result = _apiConnector.GetList<PublisherAndSubpublisherView>(url);
            return result;
        }

        /// <summary>
        /// Отримати список зв'язаних видавництв з субвидавництвом по ID
        /// </summary>
        /// <returns></returns>
        public List<PublisherAndSubpublisherView> GetPublisherAndSubpublisherList(int custId)
        {
            string url = $"{Prefix}/list/links/{custId}";
            var result = _apiConnector.GetList<PublisherAndSubpublisherView>(url);
            return result;
        }

        /// <summary>
        /// Отримати список видавництв
        /// </summary>
        /// <returns></returns>
        public List<PublishersView> GetPublishersList()
        {
            string url = $"{Prefix}/list/publishers";
            var result = _apiConnector.GetList<PublishersView>(url);
            return result;
        }

        /// <summary>
        /// Отримати список субвидавництв
        /// </summary>
        /// <returns></returns>
        public List<PublishersView> GetSubPublishersList()
        {
            string url = $"{Prefix}/list/subpublishers";
            var result = _apiConnector.GetList<PublishersView>(url);
            return result;
        }

        /// <summary>
        /// Створити зв'язок видавництва/субвидавництва
        /// </summary>
        /// <param name="relSubPublish"></param>
        /// <returns></returns>
        public bool CreatePublisherSubpublisherLink(RelSubPublish relSubPublish)
        {
            string url = $"{Prefix}/link/create";
            var result = _apiConnector.NewItem(url, relSubPublish);
            return result;
        }

        /// <summary>
        /// Оновити зв'язок видавництва/субвидавництва
        /// </summary>
        /// <param name="relSubPublish"></param>
        /// <returns></returns>
        public bool UpdatePublisherSubpublisherLink(RelSubPublish relSubPublish)
        {
            string url = $"{Prefix}/link/update";
            var result = _apiConnector.UpdateItem(url, null, relSubPublish);
            return result;
        }

        /// <summary>
        /// Отримати субвидавництво в Україні
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public PublisherAndSubpublisherView GetSubpublisherUkraine(int custId)
        {
            string url = $"{Prefix}/ukrainesubpublisher";
            var result = _apiConnector.GetItemById<PublisherAndSubpublisherView>(url, custId.ToString());
            return result;
        }
    }
}
