using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.Windows.Model;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.Windows
{
    public class RightholdersListViewModel : ViewModelBase
    {

        #region * * * BEHAVIOR PROPERTIES * * *

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(() => IsBusy);
            }
        }

        #endregion

        #region * * * DATAPROPERTIES * * *

        private int _tabIndex;
        public int TabIndex
        {
            get => _tabIndex;
            set
            {
                _tabIndex = value;
                OnPropertyChanged(() => TabIndex);
            }
        }

        private ObservableCollection<RightholderCopyrightModel> _rightholdersItemSource;
        public ObservableCollection<RightholderCopyrightModel> RightholdersItemSource
        {
            get => _rightholdersItemSource;
            set
            {
                _rightholdersItemSource = value;
                OnPropertyChanged(() => RightholdersItemSource);
            }
        }

        private RightholderCopyrightModel _selectedRightholder;
        public RightholderCopyrightModel SelectedRightholder
        {
            get => _selectedRightholder;
            set
            {
                _selectedRightholder = value;
                OnPropertyChanged(() => SelectedRightholder);
            }
        }

        private ObservableCollection<PublishersCopyrightModel> _publishersItemSource;
        public ObservableCollection<PublishersCopyrightModel> PublishersItemSource
        {
            get => _publishersItemSource;
            set
            {
                _publishersItemSource = value;
                OnPropertyChanged(() => PublishersItemSource);
            }
        }

        private PublishersCopyrightModel _selectedPublisher;
        public PublishersCopyrightModel SelectedPublisher
        {
            get => _selectedPublisher;
            set
            {
                _selectedPublisher = value;
                OnPropertyChanged(() => SelectedPublisher);
            }
        }


        #endregion

    }
}
