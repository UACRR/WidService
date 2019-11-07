using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
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

        private bool _isCheckedAllRunable = false;
        private bool _isCheckedAll;
        public bool IsCheckedAll
        {
            get => _isCheckedAll;
            set
            {
                _isCheckedAll = value;

                _isCheckedAllRunable = true;

                foreach (var obj in _itemSourceCopyrightRequestObjects)
                    obj.IsSelected = value;

                _isCheckedAllRunable = false;

                UpdatePanelData();

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

        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged(() => Comment);
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
                WorkDateRH = new DateTime(2018,07,15),
            },
            new CopyrightRequestRightholdersModel
            {
                CustId = 123,
                Name = "Орбіт Ігор Юрійович",
                CntObj = 44515,
                InnerCode = "QQ/8744-A-FF3",
                InterCode = "0003-7845/FF",
                RegistrDate = new DateTime(2017,03,22),
                WorkDateRH = new DateTime(2018,12,11)
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
                WorkCommentRH = "Дуже важлива функція для роботи з об'єктами права."
            },
            new CopyrightRequestObjectsModel
            {
                ObjId = 354345,
                ObjName = "OnPropertyChanged",
                GenreName = "Музика",
                Duration = "00:05:59",
                WorkCommentRH = "З зовнішньої бази внесені дані з загальним процентом більше 100 (права не підтверджені)"
            },
            new CopyrightRequestObjectsModel
            {
                IsSelected = true,
                ObjId = 8544,
                ObjName = "Васильки",
                GenreName = "Джаз",
                Duration = "00:05:59",
                WorkCommentRH = "",
                WorkTypeRH = 2
            },
            new CopyrightRequestObjectsModel
            {
                ObjId = 245,
                ObjName = "Васильки",
                GenreName = "Блюз",
                Duration = "00:05:59",
                WorkCommentRH = "Відсутня можливість відібрати такі ОП для виправлення.",
                WorkTypeRH = 1,
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

        private CopyrightRequestObjectsModel _objectCurrentItem;
        public CopyrightRequestObjectsModel ObjectCurrentItem
        {
            get => _objectCurrentItem;
            set
            {
                _objectCurrentItem = value;

                UpdatePanelData();

                OnPropertyChanged(() => ObjectCurrentItem);
            }
        }

        private CopyrightRequestObjectsModel _objectCurrentItemMultiple;
        private CopyrightRequestObjectsModel _objectCurrentItemProperty;
        public CopyrightRequestObjectsModel ObjectCurrentItemProperty
        {
            get => _objectCurrentItemProperty;
            set
            {
                if (value == null)
                {
                    _objectCurrentItemProperty = _objectCurrentItemMultiple;
                    BackgroundProperty = null;
                }
                else
                {
                    _objectCurrentItemProperty = value;
                    BackgroundProperty = new SolidColorBrush(Color.FromArgb(255, 245, 245, 245));
                }
                
                OnPropertyChanged(() => ObjectCurrentItemProperty);
            }
        }
        
        // "WhiteSmoke" Color.FromArgb(255, 245, 245, 245)
        private SolidColorBrush _backgroundProperty;
        public SolidColorBrush BackgroundProperty
        {
            get => _backgroundProperty;
            set
            {
                _backgroundProperty = value;
                OnPropertyChanged(() => BackgroundProperty);
            }
        }

        private ObservableCollection<WorkType> _workTypeDictionary;
        public ObservableCollection<WorkType> WorkTypeDictionary
        {
            get => _workTypeDictionary;
            set
            {
                _workTypeDictionary = value;
                OnPropertyChanged(() => WorkTypeDictionary);
            }
        }

        private void UpdatePanelData()
        {
            if (ItemSourceCopyrightRequestObjects.Any(rec => rec.IsSelected))
            {
                if (_objectCurrentItemMultiple == null)
                    _objectCurrentItemMultiple = new CopyrightRequestObjectsModel();
                ObjectCurrentItemProperty = null;
            }
            else
            {
                ObjectCurrentItemProperty = ObjectCurrentItem;
                _objectCurrentItemMultiple = null;
            }
        }

        #region * * * COMMANDS * * *

        public ICommand LoadDataCommand => new IPSDelegateCommand(LoadDataCommandExecute);
        private void LoadDataCommandExecute(object o)
        {
            WorkTypeDictionary = new ObservableCollection<WorkType>(IpsGlobal.AnketaDictionaties.workType);
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

        public ICommand SelectedPropertyChangedCommand => new IPSDelegateCommand(SelectedPropertyChangedCommandExecute);
        private void SelectedPropertyChangedCommandExecute(object o)
        {

        }

        public ICommand CheckedChangedCommand => new IPSDelegateCommand(CheckedChangedCommandExecute);
        private void CheckedChangedCommandExecute(object o)
        {
            if (_isCheckedAllRunable)
                return;

            UpdatePanelData();
        }

        #endregion


    }
}