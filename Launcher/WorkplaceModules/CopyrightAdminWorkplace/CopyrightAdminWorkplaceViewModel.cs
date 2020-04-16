using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using ipsFormsDesign.Interfaces;
using IPSModulesLibrary.ObjectsRightList;
using IPSViewComponentLibraryWPF.IPSExtensions;
using IPSViewComponentLibraryWPF.Modules.CopyrightRequest;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights;
using LanguageLibrary;
using Telerik.Windows.Controls;

namespace Launcher.WorkplaceModules.CopyrightAdminWorkplace
{
    public class CopyrightAdminWorkplaceViewModel : ViewModelBase
    {

        #region * * * PROPERTIES * * *

        private LM_CopyrightAdminWorkplace _loc = new LM_CopyrightAdminWorkplace();
        public LM_CopyrightAdminWorkplace LOC
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

        private TabItem _rightholderNestedTabItem;
        public TabItem RightholderNestedTabItem
        {
            get => _rightholderNestedTabItem;
            set
            {
                _rightholderNestedTabItem = value;


                if (value.Content is UserControl control)
                {
                    if (control.DataContext is ILazyLoadData lazyLoadData) 
                        lazyLoadData.LazyLoadData();
                }

                OnPropertyChanged(() => RightholderNestedTabItem);
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

            if (RightholderNestedTabItem.Content is UserControl nestedControl)
            {
                if (nestedControl.DataContext is ILazyLoadData lazyLoadData)
                    lazyLoadData.LazyLoadData();
            }

            AppLanguageLibrary.UpdateLanguageLocalization(LOC, nameof(AppLanguageLibrary.CurrentLanguage.CopyrightAdminWorkplaceLD));
        }

        #endregion
    }
}
