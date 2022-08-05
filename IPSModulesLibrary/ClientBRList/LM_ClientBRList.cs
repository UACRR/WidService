using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace IPSModulesLibrary.ClientBRList
{
    public class LM_ClientBRList : ViewModelBase
    {
        private string _tvAll = "Всі";
        public string TV_ALL
        {
            get => _tvAll;
            set
            {
                _tvAll = value;
                OnPropertyChanged(() => TV_ALL);
            }
        }
    }
}
