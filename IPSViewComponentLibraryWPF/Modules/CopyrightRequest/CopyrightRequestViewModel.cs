using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ipsFormsDesign.Services;
using IPSViewComponentLibraryWPF.Extensions;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.CopyrightRequest
{
    public class CopyrightRequestViewModel : ViewModelBase
    {
        private readonly string _recordCount = "К-сть записів";

        //private readonly RightholderService _rightholderService = new RightholderService();

        public CopyrightRequestViewModel() {}


        #region * * * PROPERTIES * * *

        private bool _isCheckedAll;
        public bool IsCheckedAll
        {
            get => _isCheckedAll;
            set
            {
                _isCheckedAll = value;
                
                foreach (var obj in _itemSourceCopyrightRequestObjects)
                    obj.IsSelected = value;

                OnPropertyChanged(() => IsCheckedAll);
                OnPropertyChanged(() => ItemSourceCopyrightRequestObjects);
            }
        }

        private string _rightholdersCount = "К-сть записів: 0";
        public string RightholdersCount
        {
            get => _rightholdersCount;
            set
            {
                _rightholdersCount = value;
                OnPropertyChanged(() => RightholdersCount);
            }
        }

        private string _objectsCount = "К-сть записів: 0";
        public string ObjectsCount
        {
            get => _objectsCount;
            set
            {
                _objectsCount = value;
                OnPropertyChanged(() => ObjectsCount);
            }
        }

        #endregion

        private ObservableCollection<CopyrightRequestRightholdersModel> _itemSourceCopyrightRequestRightholders = new ObservableCollection<CopyrightRequestRightholdersModel>
        {
            new CopyrightRequestRightholdersModel
            {
                CustId = 123,
                Name = "Дірол Вадим Гетьманович",
                CntObj = 24,
                InnerCode = "ЙЙ-9585АА4/4",
                InterCode = "5045-78-4540",
                RegistrDate = new DateTime(2008,10,10),
                WorkDateRH = new DateTime(2018,07,15)
            }
        };
        public ObservableCollection<CopyrightRequestRightholdersModel> ItemSourceCopyrightRequestRightholders
        {
            get => _itemSourceCopyrightRequestRightholders;
            set
            {
                _itemSourceCopyrightRequestRightholders = value;
                RightholdersCount = $"{_recordCount}: {value.Count}";
                OnPropertyChanged(() => ItemSourceCopyrightRequestRightholders);
            }
        }
        
        private CopyrightRequestRightholdersModel _rightholderSelectedItem;
        public CopyrightRequestRightholdersModel RightholderSelectedItem
        {
            get => _rightholderSelectedItem;
            set
            {
                _rightholderSelectedItem = value;
                OnPropertyChanged(() => RightholderSelectedItem);
            }
        }

        private ObservableCollection<CopyrightRequestObjectsModel> _itemSourceCopyrightRequestObjects = new ObservableCollection<CopyrightRequestObjectsModel>
        {
            new CopyrightRequestObjectsModel
            {
                ObjId = 12245,
                ObjName = "Васильки",
                GenreName = "Пісня",
                Duration = "00:05:59",
            },
            new CopyrightRequestObjectsModel
            {
                ObjId = 354345,
                ObjName = "OnPropertyChanged",
                GenreName = "Музика",
                Duration = "00:05:59",
            },
            new CopyrightRequestObjectsModel
            {
                IsSelected = true,
                ObjId = 8544,
                ObjName = "Васильки",
                GenreName = "Джаз",
                Duration = "00:05:59",
            },
            new CopyrightRequestObjectsModel
            {
                ObjId = 245,
                ObjName = "Васильки",
                GenreName = "Блюз",
                Duration = "00:05:59",
            },
        };
        public ObservableCollection<CopyrightRequestObjectsModel> ItemSourceCopyrightRequestObjects
        {
            get => _itemSourceCopyrightRequestObjects;
            set
            {
                _itemSourceCopyrightRequestObjects = value;
                ObjectsCount = $"{_recordCount}: {value.Count}";
                OnPropertyChanged(() => ItemSourceCopyrightRequestObjects);
            }
        }

        #region * * * COMMANDS * * *

        public ICommand LoadDataCommand => new IPSDelegateCommand(LoadDataCommandExecute);
        private void LoadDataCommandExecute(object o)
        {

        }

        public ICommand SaveCommand => new IPSDelegateCommand(SaveCommandExecute);
        private void SaveCommandExecute(object o)
        {

        }

        public ICommand PrintCopyrightRequestCommand => new IPSDelegateCommand(PrintCopyrightRequestCommandExecute);
        private void PrintCopyrightRequestCommandExecute(object o)
        {
            var copyrightRequestRightholdersModel = (CopyrightRequestRightholdersModel) o;

        }

        #endregion


    }
}