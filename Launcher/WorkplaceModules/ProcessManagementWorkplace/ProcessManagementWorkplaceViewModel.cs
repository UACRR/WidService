using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ipsFormsDesign.Interfaces;
using IPSViewComponentLibraryWPF.IPSExtensions;
using Telerik.Windows.Controls;

namespace Launcher.WorkplaceModules.ProcessManagementWorkplace
{
    public class ProcessManagementWorkplaceViewModel : ViewModelBase
    {
        private LM_ProcessManagementWorkplace _loc = new LM_ProcessManagementWorkplace();
        public LM_ProcessManagementWorkplace LOC
        {
            get => _loc;
            set
            {
                _loc = value;
                OnPropertyChanged(() => LOC);
            }
        }

        private TabItem _mainTabItem;
        public TabItem MainTabItem
        {
            get => _mainTabItem;
            set
            {
                _mainTabItem = value;
                if (value?.Content is UserControl control)
                {
                    if (control.DataContext is ILazyLoadData lazyLoadData)
                        lazyLoadData.LazyLoadData();
                }

                OnPropertyChanged(() => MainTabItem);
            }
        }


        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            //AppLanguageLibrary.UpdateLanguageLocalization(LOC, nameof(AppLanguageLibrary.CurrentLanguage.CopyrightAdminWorkplaceLD));
        }
    }
}
