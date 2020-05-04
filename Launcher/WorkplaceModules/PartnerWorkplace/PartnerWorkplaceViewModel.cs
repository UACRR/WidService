using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ipsFormsDesign.Interfaces;
using IPSModulesLibrary.PartnerList;
using IPSViewComponentLibraryWPF.IPSExtensions;
using LanguageLibrary;
using Telerik.Windows.Controls;

namespace Launcher.WorkplaceModules.PartnerWorkplace
{
    public class PartnerWorkplaceViewModel : ViewModelBase
    {
        private LM_PartnerList _loc = new LM_PartnerList();
        public LM_PartnerList LOC
        {
            get => _loc;
            set
            {
                _loc = value;
                OnPropertyChanged(() => LOC);
            }
        }

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            if (((PartnerListControl)o).DataContext is ILazyLoadData lazyLoadData)
                lazyLoadData.LazyLoadData();

            //AppLanguageLibrary.UpdateLanguageLocalization(LOC, nameof(AppLanguageLibrary.CurrentLanguage.));
        }

    }
}
