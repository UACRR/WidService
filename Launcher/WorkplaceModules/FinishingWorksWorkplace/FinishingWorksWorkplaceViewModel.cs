using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Telerik.Windows.Controls;

namespace Launcher.WorkplaceModules.FinishingWorksWorkplace
{
    public class FinishingWorksWorkplaceViewModel : ViewModelBase
    {
        private LM_FinishingWorksWorkplace _loc = new LM_FinishingWorksWorkplace();
        public LM_FinishingWorksWorkplace LOC
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
            //AppLanguageLibrary.UpdateLanguageLocalization(LOC, nameof(AppLanguageLibrary.CurrentLanguage.CopyrightAdminWorkplaceLD));
        }
    }
}
