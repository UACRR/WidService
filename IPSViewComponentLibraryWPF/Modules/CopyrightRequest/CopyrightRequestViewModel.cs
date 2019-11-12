using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using IPSComponentLibrary.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.Modules.Document.DocumentViewer;
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

        private bool _isEnabledRightholdersGrid = true;
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

        private IList<ObjectRightNotAccepted> ListObjects { get; set; }


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

        private ObservableCollection<CopyrightRequestRightholdersModel> _rightholdersItemSource;
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

        private ObservableCollection<CopyrightRequestObjectsModel> _objectsItemSource;
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
                UpdatePropertyPanelData();
                OnPropertyChanged(() => CurrentObjectItem);
                _isProgrammaticallyChanging = false;
            }
        }

        private CopyrightRequestObjectsModel _currentObjectItemProperty;
        public CopyrightRequestObjectsModel CurrentObjectItemProperty
        {
            get => _currentObjectItemProperty;
            set
            {
                _currentObjectItemProperty = value;
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
                CurrentObjectItemProperty = new CopyrightRequestObjectsModel();

                BackgroundProperty = null;
                MultiplyChangeInfoVisibility = Visibility.Visible;
            }
            else
            {
                CurrentObjectItemProperty = new CopyrightRequestObjectsModel
                {
                    WorkTypeRH = CurrentObjectItem?.WorkTypeRH,
                    WorkCommentRH = CurrentObjectItem?.WorkCommentRH,
                };

                BackgroundProperty = new SolidColorBrush(Color.FromArgb(255, 245, 245, 245));
                MultiplyChangeInfoVisibility = Visibility.Collapsed;
            }

            IsEnabledPropertyPanel = CurrentObjectItem != null || ObjectsItemSource.Any(rec => rec.IsSelected);
            OnPropertyChanged(() => CurrentObjectItemProperty);
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
            ConvertToModel(list);
            //await Task.Factory.StartNew(() => ConvertToModel(list));
            IsBusy = false;

            HasUnsavedData = false;
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
            ListObjects = list;
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
            // TODO: add result handler
            //if (result)

            UpdateCopyrightRequestObjectList();
        }

        public ICommand CancelCommand => new IPSDelegateCommand(CancelCommandExecute);
        private void CancelCommandExecute(object o)
        {
            //IsBusy = true;
            //var list = await _service.GetNotAcceptedObjectsByRightholder(CurrentRightholderItem.CustId);
            //await Task.Factory.StartNew(() => ConvertToModel(list));
            //IsBusy = false;

            //HasUnsavedData = false;
            UpdateCopyrightRequestObjectList();
        }

        public ICommand PrintCopyrightRequestCommand => new IPSDelegateCommand(PrintCopyrightRequestCommandExecute);
        private void PrintCopyrightRequestCommandExecute(object o)
        {
            var model = (CopyrightRequestRightholdersModel) o;
            RightolderWithNotAcceptedCopyrightViewModel rightolder = new RightolderWithNotAcceptedCopyrightViewModel
            {
                CustId = model.CustId,
                Name = model.Name,
                InnerCode = model.InnerCode,
                InterCode = model.InterCode,
                WorkDateRH = model.WorkDateRH,
                RegistrDate = model.RegistrDate,
                CntObj = model.CntObj
            };

            var printView = new DocumentViewerForm();
            printView.ShowCopyrightRequest(rightolder, ListObjects);

            CurrentRightholderItem.WorkDateRH = DateTime.Now;
            foreach (var obj in ObjectsItemSource)
            {
                obj.WorkDateRH = DateTime.Now;
                obj.WorkTypeRH = 1;
            }

            SaveCommand.Execute(null);
        }

        public ICommand CheckedChangedCommand => new IPSDelegateCommand(CheckedChangedCommandExecute);
        private void CheckedChangedCommandExecute(object o)
        {
            if (_isCheckedAllRunable)
                return;

            _isProgrammaticallyChanging = true;
            UpdatePropertyPanelData();
            _isProgrammaticallyChanging = false;
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