using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ipsFormsDesign.Interfaces;
using IPSViewComponentLibraryWPF.IPSExtensions;
using LanguageLibrary;
using Telerik.Windows.Controls;

namespace Launcher.WorkplaceModules.ReportWorkplace
{
    public class ReportWorkplaceViewModel : ViewModelBase
    {
        #region * * * PROPERTIES * * *

        private LM_ReportWorkplace _loc = new LM_ReportWorkplace();
        public LM_ReportWorkplace LOC
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
            if (MainTabItem?.Content is UserControl control)
            {
                if (control.DataContext is ILazyLoadData lazyLoadData)
                    lazyLoadData.LazyLoadData();
            }

            //AppLanguageLibrary.UpdateLanguageLocalization(LOC, nameof(AppLanguageLibrary.CurrentLanguage.ReportWorkplaceLD));
        }

        #endregion
    }
}
