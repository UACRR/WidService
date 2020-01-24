using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model;
using Telerik.Windows.Controls;

namespace TestWPFControls.Controls
{
    public class DefaultViewModel : ViewModelBase
    {
        private ObservableCollection<TransferedObjectsRightModel> _selectedObjectsRightItemSource;
        public ObservableCollection<TransferedObjectsRightModel> SelectedObjectsRightItemSource
        {
            get => _selectedObjectsRightItemSource;
            set
            {
                _selectedObjectsRightItemSource = value;
                OnPropertyChanged(() => SelectedObjectsRightItemSource);
            }
        }


        private ObservableCollection<RightholderInfoModel> _rightholdersItemSource;
        public ObservableCollection<RightholderInfoModel> RightholdersItemSource
        {
            get => _rightholdersItemSource;
            set
            {
                _rightholdersItemSource = value;
                OnPropertyChanged(() => RightholdersItemSource);
            }
        }
    }
}
