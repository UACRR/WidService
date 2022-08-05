using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IPSViewComponentLibraryWPF.IPSExtensions;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.ViewModels;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.Views;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.Windows;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights
{
    public class TransferOfRightsViewModel : ViewModelBase
    {

        #region * * * BAHAVIOR PROPERTIES * * *

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

        private Visibility _defaultTransferVisibility = Visibility.Visible;
        public Visibility DefaultTransferVisibility
        {
            get => _defaultTransferVisibility;
            set
            {
                _defaultTransferVisibility = value;
                OnPropertyChanged(() => DefaultTransferVisibility);
            }
        }

        private Visibility _pubSubTransferVisibility = Visibility.Collapsed;
        public Visibility PubSubTransferVisibility
        {
            get => _pubSubTransferVisibility;
            set
            {
                _pubSubTransferVisibility = value;
                OnPropertyChanged(() =>  PubSubTransferVisibility);
            }
        }

        #endregion

        #region * * * DATA PROPERTIES * * *

        public LM_TransferOfRights LM { get; set; } = new LM_TransferOfRights();

        private ObservableCollection<ObjectsRightOfRightholder> _objectsRightItemSource = new ObservableCollection<ObjectsRightOfRightholder> 
        {
                new ObjectsRightOfRightholder {Name = "rightolder1"},
                new ObjectsRightOfRightholder {Name = "rightolder2"},
                new ObjectsRightOfRightholder {Name = "rightolder3"},
                new ObjectsRightOfRightholder {Name = "rightolder4"},
                new ObjectsRightOfRightholder {Name = "rightolder5"},
        };
        public ObservableCollection<ObjectsRightOfRightholder> ObjectsRightItemSource
        {
            get => _objectsRightItemSource;
            set
            {
                _objectsRightItemSource = value;
                OnPropertyChanged(() => ObjectsRightItemSource);
            }
        }

        private ObservableCollection<TransferedObjectsRightModel> _selectedObjectsRightItemSource = new ObservableCollection<TransferedObjectsRightModel>
        {
            new TransferedObjectsRightModel
            {
                ObjId = 1,
                Name = "objectname3",
                RateRh = 44.54m,
                RoleName = "Композитор",
                Rightholders = new ObservableCollection<RightholderInfoModel>
                {
                    new RightholderInfoModel
                    {
                        CustId = 1,
                        RightholderCode = "454DS",
                        IPI = "555/AD4D/DF",
                        RightholderName = "The thread"
                    },
                    new RightholderInfoModel
                    {
                        CustId = 2,
                        RightholderCode = "454DS",
                        IPI = "888-99-425/15",
                        RightholderName = "Trace"
                    },
                }
            },
            new TransferedObjectsRightModel
            {
                ObjId = 2,
                Name = "OnPropertyChanged",
                RateRh = 44.54m,
                RoleName = "Композитор",
                Rightholders = new ObservableCollection<RightholderInfoModel>
                {
                    new RightholderInfoModel
                    {
                        CustId = 1,
                        RightholderCode = "454DS",
                        IPI = "555/AD4D/DF",
                        RightholderName = "The thread"
                    },
                    new RightholderInfoModel
                    {
                        CustId = 2,
                        RightholderCode = "454DS",
                        IPI = "888-99-425/15",
                        RightholderName = "Trace"
                    },
                    new RightholderInfoModel
                    {
                        CustId = 2,
                        RightholderCode = "454DS",
                        IPI = "888-99-425/15",
                        RightholderName = "Trace"
                    },
                }
            },
            new TransferedObjectsRightModel
            {
                Name = "objectname6",
                RateRh = 44.54m,
                RoleName = "Композитор",
            },
            new TransferedObjectsRightModel
            {
                Name = "underground",
                RateRh = 44.54m,
                RoleName = "Композитор",
            }
        };
        public ObservableCollection<TransferedObjectsRightModel> SelectedObjectsRightItemSource
        {
            get => _selectedObjectsRightItemSource;
            set
            {
                _selectedObjectsRightItemSource = value;
                OnPropertyChanged(() => SelectedObjectsRightItemSource);
            }
        }

        private RightholderInfoModel _selectedRightholder = new RightholderInfoModel
        {
            RightholderName = "1234",
        };
        public RightholderInfoModel SelectedRightholder
        {
            get => _selectedRightholder;
            set
            {
                _selectedRightholder = value;
                OnPropertyChanged(() => SelectedRightholder);
            }
        }

        private RightholderInfoModel _selectedRightholderAdd;
        public RightholderInfoModel SelectedRightholderAdd
        {
            get => _selectedRightholderAdd;
            set
            {
                _selectedRightholderAdd = value;
                OnPropertyChanged(() => SelectedRightholderAdd);
            }
        }

        private DateProperty _dateProperty;
        public DateProperty DateProperty
        {
            get => _dateProperty;
            set
            {
                _dateProperty = value;
                OnPropertyChanged(() => DateProperty);
            }
        }
        #endregion

        #region * * * METHODS * * *



        #endregion

        #region * * * COMMANDS * * *

        public ICommand SelectDefaultTransferCommand => new IPSDelegateCommand(SelectTransferCommandExecute);
        private void SelectTransferCommandExecute(object o)
        {
            DefaultTransferVisibility = Visibility.Visible;
            PubSubTransferVisibility = Visibility.Collapsed;

            var d = (DefaultTransferView)o;
            ((DefaultTransferViewModel) d.DataContext).TransferTypeOfRight = TransferTypeOfRight.Default;
        }

        public ICommand SelectHeritageTransferCommand => new IPSDelegateCommand(SelectHeritageTransferCommandExecute);
        private void SelectHeritageTransferCommandExecute(object o)
        {
            
            DefaultTransferVisibility = Visibility.Visible;
            PubSubTransferVisibility = Visibility.Collapsed;

            var d = (DefaultTransferView)o;
            ((DefaultTransferViewModel)d.DataContext).TransferTypeOfRight = TransferTypeOfRight.Haritage;
        }

        public ICommand SelectPubSubTransferCommand => new IPSDelegateCommand(SelectPubSubTransferCommandExecute);
        private void SelectPubSubTransferCommandExecute(object o)
        {
            DefaultTransferVisibility = Visibility.Collapsed;
            PubSubTransferVisibility = Visibility.Visible;

            var d = (PublisherSubpublisherTransferView)o;
            var lm = ((PublisherSubpublisherTransferViewModel)d.DataContext).LM;


        }

        #endregion
    }
}
