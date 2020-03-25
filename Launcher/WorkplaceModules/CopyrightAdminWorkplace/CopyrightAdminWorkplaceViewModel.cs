using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ipsFormsDesign.Interfaces;
using IPSModulesLibrary.ObjectsRightList;
using IPSViewComponentLibraryWPF.Modules.CopyrightRequest;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights;
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

        private RadTabItem _mainTabItem;
        public RadTabItem MainTabItem
        {
            get => _mainTabItem;
            set
            {
                _mainTabItem = value;
                if (value.Content is UserControl control)
                {
                    if (control.DataContext is ILazyLoadData lazyLoadData)
                        lazyLoadData.LazyLoadData();
                }

                OnPropertyChanged(() => MainTabItem);
            }
        }

        private RadTabItem _rightholderNestedTabItem;
        public RadTabItem RightholderNestedTabItem
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

        #endregion

    }
}
