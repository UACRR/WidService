using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IPSViewComponentLibraryWPF.IPSExtensions;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model;
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


        private bool _isAllCheck;
        public bool IsAllCheck
        {
            get => _isAllCheck;
            set
            {
                _isAllCheck = value;
                OnPropertyChanged(() => IsAllCheck);
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
                        ObjId = 1,
                        CustId = 1,
                        RightholderCode = "454DS",
                        IPI = "555/AD4D/DF",
                        RightholderName = "The thread"
                    },
                    new RightholderInfoModel
                    {
                        ObjId = 1,
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
                        ObjId = 2,
                        CustId = 1,
                        RightholderCode = "454DS",
                        IPI = "555/AD4D/DF",
                        RightholderName = "The thread"
                    },
                    new RightholderInfoModel
                    {
                        ObjId = 1,
                        CustId = 2,
                        RightholderCode = "454DS",
                        IPI = "888-99-425/15",
                        RightholderName = "Trace"
                    },
                    new RightholderInfoModel
                    {
                        ObjId = 2,
                        CustId = 2,
                        RightholderCode = "454DS",
                        IPI = "888-99-425/15",
                        RightholderName = "Trace"
                    },
                }
            },
            new TransferedObjectsRightModel
            {
                ObjId = 3,
                Name = "objectname6",
                RateRh = 44.54m,
                RoleName = "Композитор",
            },
            new TransferedObjectsRightModel
            {
                ObjId = 4,
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

        private RightholderInfoModel _selectedRightholder;
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

        #endregion

        #region * * * METHODS * * *



        #endregion

        #region * * * COMMANDS * * *

        /// <summary>
        /// Завантаження
        /// </summary>
        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {

        }

        /// <summary>
        /// Відкрити об'єкт права на перегляд
        /// </summary>
        public ICommand ViewObjectRightCommand => new IPSDelegateCommand(ViewObjectRightCommandExecute);
        private void ViewObjectRightCommandExecute(object o)
        {

        }

        /// <summary>
        /// Відкрити об'єкт права на перегляд
        /// </summary>
        public ICommand RemoveObjectRightCommand => new IPSDelegateCommand(RemoveObjectRightCommandExecute);
        private void RemoveObjectRightCommandExecute(object o)
        {

        }

        public ICommand ChangeTransferTypeCommand => new IPSDelegateCommand(ChangeTransferTypeCommandExecute);
        private void ChangeTransferTypeCommandExecute(object o)
        {

        }

        public ICommand CheckAllCommand => new IPSDelegateCommand(CheckAllCommandExecute);
        private void CheckAllCommandExecute(object o)
        {

        }

        /// <summary>
        /// Обрати правовласника
        /// </summary>
        public ICommand SelectRightholderCommand => new IPSDelegateCommand(SelectRightholderCommandExecute);
        private void SelectRightholderCommandExecute(object o)
        {
            int? i = SelectedRightholder?.CustId + 1;

            SelectedRightholder = new RightholderInfoModel
            {
                CustId = i ?? 0,
                RightholderName = $"Василькович Адам Герцович ({i})",
            };
        }

        /// <summary>
        /// Показати анкету правовласника
        /// </summary>
        public ICommand OpenRightholderAnketaCommand => new IPSDelegateCommand(OpenRightholderAnketaCommandExecute);
        private void OpenRightholderAnketaCommandExecute(object o)
        {

        }

        /// <summary>
        /// Обрати додаткового правовласника
        /// </summary>
        public ICommand SelectRightholderAddCommand => new IPSDelegateCommand(SelectRightholderAddCommandExecute);
        private void SelectRightholderAddCommandExecute(object o)
        {

        }

        /// <summary>
        /// Показати анкету додаткового правовласника
        /// </summary>
        public ICommand OpenRightholderAddAnketaCommand => new IPSDelegateCommand(OpenRightholderAnketaAddCommandExecute);
        private void OpenRightholderAnketaAddCommandExecute(object o)
        {

        }


        #endregion
    }
}
