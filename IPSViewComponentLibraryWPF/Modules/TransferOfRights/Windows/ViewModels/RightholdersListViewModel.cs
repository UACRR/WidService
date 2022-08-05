using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ipsFormsDesign.Services;
using IPSViewComponentLibraryWPF.IPSExtensions;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.Windows.Model;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.Windows.Models;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.Windows.ViewModels
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

        public TransferTypeOfRight TransferTypeOfRight { get; set; }

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

        #region * * * METHODS * * *

        

        #endregion

        #region * * * COMMANDS * * *

        /// <summary>
        /// Завантаження
        /// </summary>
        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private async void LoadCommandExecute(object o)
        {
            if (RightholdersItemSource != null && TransferTypeOfRight == TransferTypeOfRight.Default)
                return;

            var service = TransferOfRightService.GetInstance();
            var list = new ObservableCollection<RightholderCopyrightModel>();

            IsBusy = true;
            var data = TransferTypeOfRight == TransferTypeOfRight.Default ? await service.GetRightholdersDefault() : await service.GetRightholdersHeritage();
            IsBusy = false;

            foreach (var obj in data)
            {
                var item = new RightholderCopyrightModel
                {
                    CustId = (int)(long)obj[0],
                    CustStatus = (int)(long)obj[1],
                    InnerCode = (string)obj[2],
                    InterCode = (string)obj[3],
                    Name = (string)obj[4],
                    CntObj = (int)(long)obj[5],
                    RHolderType = (int)(long)obj[6],
                };

                list.Add(item);
            }

            RightholdersItemSource = list;
        }

        public ICommand SelectRightholderCommand => new IPSDelegateCommand(SelectRightholderCommandExecute);
        private void SelectRightholderCommandExecute(object o)
        {
            if (SelectedRightholder == null)
                return;

            if (o is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
        }

        #endregion
    }
}
