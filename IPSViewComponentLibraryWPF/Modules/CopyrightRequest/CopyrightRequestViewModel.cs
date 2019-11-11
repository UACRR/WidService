using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IPSViewComponentLibraryWPF.Extensions;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.CopyrightRequest
{
    public class CopyrightRequestViewModel : ViewModelBase
    {
        private readonly string _recordCount = "К-сть записів";
        private CopyrightRequestService _service;

        public CopyrightRequestViewModel() {}

        #region * * * PROPERTIES * * *

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

        private bool _isEnabledPropertyPanel;
        public bool IsEnabledPropertyPanel
        {
            get => _isEnabledPropertyPanel;
            set
            {
                _isEnabledPropertyPanel = value;
                OnPropertyChanged(() => IsEnabledPropertyPanel);
            }
        }

        private bool _isEnabledRightholdersGrid;
        public bool IsEnabledRightholdersGrid
        {
            get => _isEnabledRightholdersGrid;
            set
            {
                _isEnabledRightholdersGrid = value;
                OnPropertyChanged(() => IsEnabledRightholdersGrid);
            }
        }

        private bool _hasUnsavedData = true;
        /// <summary>
        /// Наявні незбережені дані
        /// </summary>
        private bool HasUnsavedData
        {
            get => _hasUnsavedData;
            set
            {
                _hasUnsavedData = value;
                IsEnabledRightholdersGrid = !value;
            }
        }

        private bool _isCheckedAllRunable;
        private bool _isCheckedAll;
        public bool IsCheckedAll
        {
            get => _isCheckedAll;
            set
            {
                _isCheckedAll = value;

                _isCheckedAllRunable = true;

                foreach (var obj in _objectsItemSource)
                    obj.IsSelected = value;

                _isCheckedAllRunable = false;

                UpdatePropertyPanelData();

                OnPropertyChanged(() => IsCheckedAll);
                OnPropertyChanged(() => ObjectsItemSource);
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

        private Visibility _multiplyChangeInfoVisibility = Visibility.Collapsed;
        public Visibility MultiplyChangeInfoVisibility
        {
            get => _multiplyChangeInfoVisibility;
            set
            {
                _multiplyChangeInfoVisibility = value;
                OnPropertyChanged(() => MultiplyChangeInfoVisibility);
            }
        }

        private ObservableCollection<CopyrightRequestRightholdersModel> _rightholdersItemSource = new ObservableCollection<CopyrightRequestRightholdersModel>
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
        public ObservableCollection<CopyrightRequestRightholdersModel> RightholdersItemSource
        {
            get => _rightholdersItemSource;
            set
            {
                _rightholdersItemSource = value;

                CurrentRightholderItem = null;

                RightholdersCount = $"{_recordCount}: {value.Count}";
                OnPropertyChanged(() => RightholdersItemSource);
            }
        }
        
        private CopyrightRequestRightholdersModel _currentRightholderItem;
        /// <summary>
        /// Обраний із списку правовласник
        /// </summary>
        public CopyrightRequestRightholdersModel CurrentRightholderItem
        {
            get => _currentRightholderItem;
            set
            {
                _currentRightholderItem = value;
                UpdateCopyrightRequestObjectList();
                OnPropertyChanged(() => CurrentRightholderItem);
            }
        }

        private ObservableCollection<CopyrightRequestObjectsModel> _objectsItemSource = new ObservableCollection<CopyrightRequestObjectsModel>
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
        public ObservableCollection<CopyrightRequestObjectsModel> ObjectsItemSource
        {
            get => _objectsItemSource;
            set
            {
                _objectsItemSource = value;

                CurrentObjectItem = null;

                ObjectsCount = $"{_recordCount}: {value?.Count ?? 0}";
                OnPropertyChanged(() => ObjectsItemSource);
            }
        }

        private CopyrightRequestObjectsModel _currentObjectItem;
        /// <summary>
        /// Обраний із списку об'єкт запиту
        /// </summary>
        public CopyrightRequestObjectsModel CurrentObjectItem
        {
            get => _currentObjectItem;
            set
            {
                _isProgrammaticallyChanging = true;
                _currentObjectItem = value;
                IsEnabledPropertyPanel = value != null;
                UpdatePropertyPanelData();
                OnPropertyChanged(() => CurrentObjectItem);
                _isProgrammaticallyChanging = false;
            }
        }

        private CopyrightRequestObjectsModel _currentObjectItemMultiple;
        private CopyrightRequestObjectsModel _currentObjectItemProperty;
        public CopyrightRequestObjectsModel CurrentObjectItemProperty
        {
            get => _currentObjectItemProperty;
            set
            {
                if (value == null)
                {
                    _currentObjectItemProperty = _currentObjectItemMultiple;
                    BackgroundProperty = null;
                }
                else
                {
                    _currentObjectItemProperty = value;
                    
                    // "WhiteSmoke"
                    BackgroundProperty = new SolidColorBrush(Color.FromArgb(255, 245, 245, 245));
                }
                
                OnPropertyChanged(() => CurrentObjectItemProperty);
            }
        }
        
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
        
        #endregion

        private void UpdatePropertyPanelData()
        {
            if (ObjectsItemSource == null)
            {
                CurrentObjectItemProperty = null;
                return;
            }

            if (ObjectsItemSource.Any(rec => rec.IsSelected))
            {
                if (_currentObjectItemMultiple == null)
                    _currentObjectItemMultiple = new CopyrightRequestObjectsModel();
                CurrentObjectItemProperty = null;
                MultiplyChangeInfoVisibility = Visibility.Visible;
            }
            else
            {
                CurrentObjectItemProperty = CurrentObjectItem;
                MultiplyChangeInfoVisibility = Visibility.Collapsed;
                _currentObjectItemMultiple = null;
            }
        }

        /// <summary>
        /// Update objects of copyright request data when selected rightholder changed
        /// </summary>
        private async void UpdateCopyrightRequestObjectList()
        {
            if (CurrentRightholderItem == null)
            {
                ObjectsItemSource = null;
                return;
            }

            IsBusy = true;
            var list = await _service.GetNotAcceptedObjectsByRightholder(CurrentRightholderItem.CustId);
            await Task.Factory.StartNew(() => ConvertToModel(list));
            IsBusy = false;
        }

        /// <summary>
        /// Convert to rightholder list with copyright requests internal model
        /// </summary>
        /// <param name="list"></param>
        private void ConvertToModel(IList<RightolderWithNotAcceptedCopyrightViewModel> list)
        {
            var modelList = new ObservableCollection<CopyrightRequestRightholdersModel>();
            foreach (var item in list)
            {
                modelList.Add(new CopyrightRequestRightholdersModel
                {
                    CustId = item.CustId,
                    Name = item.Name,
                    InnerCode = item.InnerCode,
                    InterCode = item.InterCode,
                    WorkDateRH = item.WorkDateRH,
                    RegistrDate = item.RegistrDate,
                    CntObj = item.CntObj
                });
            }

            RightholdersItemSource = modelList;
        }

        private void ConvertToModel(IList<ObjectRightNotAccepted> list)
        {
            var modelList = new ObservableCollection<CopyrightRequestObjectsModel>();
            foreach (var item in list)
            {
                modelList.Add(new CopyrightRequestObjectsModel
                {
                    IsSelected = false,
                    CRightId = item.CRightId,
                    CustId = item.CustId,
                    ObjId = item.ObjId,
                    ObjName = item.ObjName,
                    GenreName = item.GenreName,
                    Duration = item.Duration,
                    RoleName = item.RoleName,
                    SpecName = item.SpecName,
                    Rate = item.Rate,
                    Performer = item.Performer,
                    WorkCommentRH = item.WorkCommentRH,
                    WorkDateRH = item.WorkDateRH,
                    WorkTypeRH = item.WorkTypeRH,
                });
            }

            ObjectsItemSource = modelList;
        }

        #region * * * COMMANDS * * *

        public ICommand LoadDataCommand => new IPSDelegateCommand(LoadDataCommandExecute);
        private async void LoadDataCommandExecute(object o)
        {
            WorkTypeDictionary = new ObservableCollection<WorkType>(IpsGlobal.AnketaDictionaties.workType);
            _service = CopyrightRequestService.GetInstance();

            IsBusy = true;
            var rightholderList = await _service.GetCopyrightRequestRightholderList();
            await Task.Factory.StartNew(() => ConvertToModel(rightholderList));
            IsBusy = false;
        }

        public ICommand SaveCommand => new IPSDelegateCommand(SaveCommandExecute);
        private void SaveCommandExecute(object o)
        {
            var copyrighList = new List<CopyRight>();

            foreach (var obj in ObjectsItemSource)
            {
                var copyright = new CopyRight
                {
                    CRightId = obj.CRightId,
                    Rate = obj.Rate,
                };

                if (obj.WorkTypeRH.HasValue || obj.WorkDateRH.HasValue || !string.IsNullOrEmpty(obj.WorkCommentRH))
                {
                    copyright.WorkRh = new WorkRh
                    {
                        CRightId = obj.CRightId,
                        WorkTypeRh = obj.WorkTypeRH,
                        WorkDateRh = obj.WorkDateRH,
                        WorkCommentRh = obj.WorkCommentRH,
                    };
                }

                copyrighList.Add(copyright);
            }

            var result = _service.UpdateCopyrights(copyrighList);

            //if (result)

            HasUnsavedData = false;
            UpdateCopyrightRequestObjectList();

            
            //_dialogService.ShowError(_view, "Не вдалося зберегти зміни.");
        }

        public ICommand CancelCommand => new IPSDelegateCommand(CancelCommandExecute);
        private void CancelCommandExecute(object o)
        {
            HasUnsavedData = false;
            UpdateCopyrightRequestObjectList();
        }

        public ICommand PrintCopyrightRequestCommand => new IPSDelegateCommand(PrintCopyrightRequestCommandExecute);
        private void PrintCopyrightRequestCommandExecute(object o)
        {
            var copyrightRequestRightholdersModel = (CopyrightRequestRightholdersModel) o;

            
            //var printView = new IPSViewComponentLibrary. ViewAndPrintAgreementForm();
            //printView.Text = $"Запит - {copyrightRequestRightholdersModel.Name}";
            //printView.ShowCopyrightRequest(copyrightRequestRightholdersModel, ObjectsItemSource);

            //UpdateStatusAndDate(objectRightList);
        }

        public ICommand CheckedChangedCommand => new IPSDelegateCommand(CheckedChangedCommandExecute);
        private void CheckedChangedCommandExecute(object o)
        {
            if (_isCheckedAllRunable)
                return;

            UpdatePropertyPanelData();
        }

        private bool _isProgrammaticallyChanging = false;
        public ICommand PropertyChangedCommand => new IPSDelegateCommand(PropertyChangedCommandExecute);
        private void PropertyChangedCommandExecute(object o)
        {
            if (_isProgrammaticallyChanging)
                return;

            if (CurrentObjectItem != null)
                CurrentObjectItem.WorkDateRH = DateTime.Now;

            foreach (var item in ObjectsItemSource.Where(rec => rec.IsSelected))
            {
                item.WorkDateRH = DateTime.Now;
                item.WorkTypeRH = CurrentObjectItemProperty.WorkTypeRH;
                item.WorkCommentRH = CurrentObjectItemProperty.WorkCommentRH;
            }

            HasUnsavedData = true;
        }

        #endregion
    }
}