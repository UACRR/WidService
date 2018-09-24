using ipsFormsDesign.Model;
using ipsFormsDesign.ViewModels.Fixations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class FixationService
    {
        private readonly ApiConnector _webApi;

        public FixationService()
        {
            _webApi = new ApiConnector();
        }

        public List<FixationListViewModel> GetFixations(FixationQuery query)
        {
            var list = _webApi.GetList<FixationListViewModel>("fixations", query.ToKeyValuePair());
            return list;
        }

        public Task<List<FixationListViewModel>> GetFixationsAsync(FixationQuery query)
        {
            return Task.Factory.StartNew(() => GetFixations(query));
        }

        public Fixation GetById(int fixId)
        {
            var item = _webApi.GetItemById<Fixation>("fixations", fixId.ToString());
            return item;
        }
    }
}
