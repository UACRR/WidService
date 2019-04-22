using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using sysAdminwp.ComplexDictionariesBaseControls;
using WebAPIConnector;

namespace sysAdminwp.PresenterComplexDictionaries.DefineComplexLayers
{
    class CreativeroleTypeLayer : IDictionaryActions<CreativeRoleType>
    {
        private readonly DictionaryService _dictService = DictionaryService.GetInstance();

        public BaseCreativeroleTypeControl InitControl(ApiConnector connector, string url)
        {
            return new BaseCreativeroleTypeControl(connector, url);
        }

        public CreativeRoleType GetDictionary(int id)
        {
            return _dictService.GetCreativeRoleType(id);
        }

        public CreativeRoleType Create(CreativeRoleType sors)
        {
            return _dictService.CreateCreativeRoleType(sors);
        }

        public CreativeRoleType Update(CreativeRoleType sors)
        {
            return _dictService.UpdateCreativeRoleType(sors);
        }

        public bool Delete(int id)
        {
            return _dictService.DeleteCreativeRoleType(id);
        }
    }
}
