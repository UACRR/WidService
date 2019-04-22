using sysAdminwp.ComplexDictionariesBaseControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebAPIConnector;

namespace sysAdminwp.PresenterComplexDictionaries
{
    class DirectorLayers<T> where T : class
    {
        private IDictionaryActions<T> _activeDictionary;
        public DirectorLayers(IDictionaryActions<T> activeDictionary)
        {
            _activeDictionary = activeDictionary;
        }

        private UserControl InitControl(ApiConnector connector, string url)
        {
            UserControl control = new UserControl();
            switch(url)
            {
                case "creativeroletype":
                    control = new BaseCreativeroleTypeControl(connector, url);
                    break;
            }
            return control;
        }
    }
}
