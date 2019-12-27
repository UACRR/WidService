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


        private ObservableCollection<RightholderInfoModel> _rightholdersItemSource = new ObservableCollection<RightholderInfoModel>
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
        };
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
