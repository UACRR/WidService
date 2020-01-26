using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using IpsCommonTypes.Types;
using ipsFormsDesign.Services;
using IPSViewComponentLibraryWPF.IPSExtensions;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.Model;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.Windows;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.Windows.Models;
using IPSViewComponentLibraryWPF.Modules.TransferOfRights.Windows.ViewModels;
using Telerik.Windows.Controls;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.ViewModels
{
    public class DefaultTransferViewModel : ViewModelBase
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

        private Visibility _buttonMoveSelectedVisibility = Visibility.Visible;
        public Visibility ButtonMoveSelectedVisibility
        {
            get => _buttonMoveSelectedVisibility;
            set
            {
                _buttonMoveSelectedVisibility = value;
                OnPropertyChanged(() => ButtonMoveSelectedVisibility);
            }
        }

        private TransferTypeOfRight _transferTypeOfRight;
        /// <summary>
        /// Тип передачі прав
        /// </summary>
        public TransferTypeOfRight TransferTypeOfRight 
        {
            get => _transferTypeOfRight;
            set
            {
                if (_transferTypeOfRight != value)
                    ClearData();

                _transferTypeOfRight = value;

                bool isDefault = value == TransferTypeOfRight.Default;

                if (isDefault)
                {
                    ButtonMoveSelectedVisibility = Visibility.Visible;
                    HeritageDateEndVisibility = Visibility.Visible;
                }
                else
                {
                    ButtonMoveSelectedVisibility = Visibility.Collapsed;
                    HeritageDateEndVisibility = Visibility.Collapsed;
                }

            }
        }

        private bool _isAutocalculatePercent = true;
        /// <summary>
        /// Індикатор авторозрахунку %
        /// </summary>
        public bool IsAutocalculatePercent
        {
            get => _isAutocalculatePercent;
            set
            {
                _isAutocalculatePercent = value;

                foreach (var objectsRight in SelectedObjectsRightItemSource)
                    objectsRight.IsAutoDistributionPercent = value;
                
                OnPropertyChanged(() => IsAutocalculatePercent);
            }
        }

        private Visibility _heritageDateEndVisibility = Visibility.Visible;
        /// <summary>
        /// Індикатор видимості "дати до". При передачі прав в спадщину "дата до" буде успадкована з батьківського Copyright
        /// </summary>
        public Visibility HeritageDateEndVisibility
        {
            get => _heritageDateEndVisibility;
            set
            {
                _heritageDateEndVisibility = value;
                OnPropertyChanged(() => HeritageDateEndVisibility);
            }
        }

        #endregion

        #region * * * DATA PROPERTIES * * *

        public LM_TransferOfRights LM { get; set; } = new LM_TransferOfRights();
        private ObservableCollection<RightholderCopyrightModel> LazyRightholdersCollection { get; set; }

        private ObservableCollection<ObjectsRightOfRightholder> _objectsRightItemSource;
        /// <summary>
        /// Список об'єктів, що можуть бути використані для передачі
        /// </summary>
        public ObservableCollection<ObjectsRightOfRightholder> ObjectsRightItemSource
        {
            get => _objectsRightItemSource;
            set
            {
                _objectsRightItemSource = value;
                OnPropertyChanged(() => ObjectsRightItemSource);
            }
        }

        private ObjectsRightOfRightholder _selectedObjectRight;
        /// <summary>
        /// Обраний правовласник
        /// </summary>
        public ObjectsRightOfRightholder SelectedObjectRight
        {
            get => _selectedObjectRight;
            set
            {
                _selectedObjectRight = value;
                OnPropertyChanged(() => SelectedObjectRight);
            }
        }

        private ObservableCollection<TransferedObjectsRightModel> _selectedObjectsRightItemSource;
        /// <summary>
        /// Список обраних об'єктів, що передаються
        /// </summary>
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
        /// <summary>
        /// Обраний правовласник для передачі прав
        /// </summary>
        public RightholderInfoModel SelectedRightholder
        {
            get => _selectedRightholder;
            set
            {
                _selectedRightholder = value;
                LoadObjectsForTransfer();
                OnPropertyChanged(() => SelectedRightholder);
            }
        }

        private bool _isInfinityDateEnd;
        /// <summary>
        /// Індикатор передачі прав назавжди
        /// </summary>
        public bool IsInfinityDateEnd
        {
            get => _isInfinityDateEnd;
            set
            {
                _isInfinityDateEnd = value;
                OnPropertyChanged(() => IsInfinityDateEnd);
            }
        }

        private DateProperty _dateProperty;
        /// <summary>
        /// Параметри початку та закінчення дії прав
        /// </summary>
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

        private async void LoadObjectsForTransfer()
        {
            if (SelectedRightholder == null)
                return;
            
            IsBusy = true;
            var data = await TransferOfRightService.GetInstance().GetObjectsForTransfer(SelectedRightholder.CustId);
            IsBusy = false;

            var d_COO = getColumnDictionary(data.CopyrightsOfObjects.Columns);
            var nesteditems = new ObservableCollection<CopyrightOfObject>();

            foreach (DataRow row in data.CopyrightsOfObjects.Rows)
            {
                var obj = row.ItemArray;
                nesteditems.Add(new CopyrightOfObject
                {
                    ObjId = (int)(long)obj[d_COO[nameof(CopyrightOfObject.ObjId).ToLower()]],
                    Name = (string)obj[d_COO[nameof(CopyrightOfObject.Name).ToLower()]],
                    CRightId = (int)(long)obj[d_COO[nameof(CopyrightOfObject.CRightId).ToLower()]],
                    BeginDate = (DateTime?)obj[d_COO[nameof(CopyrightOfObject.BeginDate).ToLower()]],
                    EndDate = (DateTime?)obj[d_COO[nameof(CopyrightOfObject.EndDate).ToLower()]],
                    RatePer = (double)obj[d_COO[nameof(CopyrightOfObject.RatePer).ToLower()]],
                    RateMech = (double)obj[d_COO[nameof(CopyrightOfObject.RateMech).ToLower()]],
                    RoleCode = (int)(long)obj[d_COO[nameof(CopyrightOfObject.RoleCode).ToLower()]],
                    Status = (int)(long)obj[d_COO[nameof(CopyrightOfObject.Status).ToLower()]],
                });
            }

            var d_TO = getColumnDictionary(data.TransferObjects.Columns);
            var list = new ObservableCollection<ObjectsRightOfRightholder>();

            foreach (DataRow row in data.TransferObjects.Rows)
            {
                var obj = row.ItemArray;

                var item = new ObjectsRightOfRightholder
                {
                    ObjId = (int)(long)obj[d_TO[nameof(ObjectsRightOfRightholder.ObjId).ToLower()]],
                    CRightId = (int)(long)obj[d_TO[nameof(ObjectsRightOfRightholder.CRightId).ToLower()]],
                    Name = (string)obj[d_TO[nameof(ObjectsRightOfRightholder.Name).ToLower()]],
                    GenreType = (int?)(long?)obj[d_TO[nameof(ObjectsRightOfRightholder.GenreType).ToLower()]],
                    RoleCode = (int)(long)obj[d_TO[nameof(ObjectsRightOfRightholder.RoleCode).ToLower()]],

                    RateTotal = (double)obj[d_TO[nameof(ObjectsRightOfRightholder.RateTotal).ToLower()]],
                    RatePer = (double)obj[d_TO[nameof(ObjectsRightOfRightholder.RatePer).ToLower()]],
                    RateMech = (double)obj[d_TO[nameof(ObjectsRightOfRightholder.RateMech).ToLower()]],

                    Author = (string)obj[d_TO[nameof(ObjectsRightOfRightholder.Author).ToLower()]],
                    Performer = (string)obj[d_TO[nameof(ObjectsRightOfRightholder.Performer).ToLower()]],
                };

                item.CopyrightOfObjectList = new ObservableCollection<CopyrightOfObject>(nesteditems.Where(rec => rec.ObjId == item.ObjId));

                list.Add(item);
            }

            Dictionary<string, int> getColumnDictionary(DataColumnCollection columns)
            {
                var temp = new Dictionary<string, int>();

                for (int i = 0; i < columns.Count; i++)
                {
                    temp.Add(columns[i].ColumnName.ToLower(), i);
                }

                return temp;
            }

            ObjectsRightItemSource = list;
        }

        private void ClearData()
        {
            SelectedObjectsRightItemSource = new ObservableCollection<TransferedObjectsRightModel>();
            ObjectsRightItemSource = new ObservableCollection<ObjectsRightOfRightholder>();
            IsInfinityDateEnd = false;
            DateProperty = new DateProperty();
            SelectedRightholder = null;
            SelectedObjectRight = null;
        }

        private bool CheckDataValidate()
        {
            var hasAssign = SelectedObjectsRightItemSource.Any(rec => rec.Rightholders.Any());
            if (!hasAssign)
            {
                ShowMessage.ShowWarning("Не додано жодного правонатупника!");
                return false;
            }

            return TransferTypeOfRight == TransferTypeOfRight.Default
                ? ValidateDefaultTransferData()
                : ValidateHeritageData();
        }

        private bool ValidateDefaultTransferData()
        {
            var list = new List<int>();
            foreach (var transferedObject in SelectedObjectsRightItemSource)
            {
                var totalRate = transferedObject.Rightholders.Sum(rec => rec.RightholderRate);
                if (totalRate > transferedObject.RateRh)
                {
                    list.Add(transferedObject.ObjId);
                }
            }

            if (list.Any())
            {
                string message = $"Для об'єкта(ів) ID:{string.Join(", ", list)} перевищено сумарний % володіння правонаступників!\n";
                ShowMessage.ShowWarning(message);
                return false;
            }

            return true;
        }

        private bool ValidateHeritageData()
        {
            var list = new List<int>();
            foreach (var transferedObject in SelectedObjectsRightItemSource)
            {
                var totalRate = transferedObject.Rightholders.Sum(rec => rec.RightholderRate);
                if (totalRate != transferedObject.RateRh)
                {
                    list.Add(transferedObject.ObjId);
                }
            }

            if (list.Any())
            {
                string message = $"Для об'єкта(ів) ID:{string.Join(", ", list)} сумарний % володіння правонаступників повинен збігатись з % володіння об'єтка!\n";
                ShowMessage.ShowWarning(message);
                return false;
            }


            return true;
        }

        #endregion

        #region * * * COMMANDS * * *

        /// <summary>
        /// Обрати правовласника
        /// </summary>
        public ICommand SelectRightholderCommand => new IPSDelegateCommand(SelectRightholderCommandExecute);
        private void SelectRightholderCommandExecute(object o)
        {
            var window = new RightholdersListWindow();
            var dataContext = (RightholdersListViewModel) window.DataContext;
            dataContext.TransferTypeOfRight = TransferTypeOfRight;
            
            if (LazyRightholdersCollection != null)
                dataContext.RightholdersItemSource = LazyRightholdersCollection;

            var result = window.ShowDialog() ?? false;

            if (result)
            {
                SelectedRightholder = new RightholderInfoModel
                {
                    CustId = dataContext.SelectedRightholder.CustId,
                    RightholderName = dataContext.SelectedRightholder.Name,
                };
                if (TransferTypeOfRight == TransferTypeOfRight.Default)
                    LazyRightholdersCollection = new ObservableCollection<RightholderCopyrightModel>(dataContext.RightholdersItemSource);
            }
        }

        /// <summary>
        /// Показати анкету правовласника
        /// </summary>
        public ICommand OpenRightholderAnketaCommand => new IPSDelegateCommand(OpenRightholderAnketaCommandExecute, o => SelectedRightholder != null);
        private void OpenRightholderAnketaCommandExecute(object o)
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
            var result = ShowMessage.ConfirmAction($"Видалити об'єкт ID:{((TransferedObjectsRightModel) o).ObjId} з передачі прав?");
            if (result == MessageBoxResult.Yes)
                SelectedObjectsRightItemSource.Remove((TransferedObjectsRightModel)o);
        }

        /// <summary>
        /// Перенести обрані об'єкти
        /// </summary>
        public ICommand MoveSelectedObjectsCommand => new IPSDelegateCommand(MoveSelectedObjectsCommandExecute, CanExecuteMoveObjectsCommand);
        private void MoveSelectedObjectsCommandExecute(object o)
        {
            var items = ObjectsRightItemSource
                .Where(rec => rec.IsSelected)
                .Select(rec => new TransferedObjectsRightModel
                {
                    Name = rec.Name,
                    ObjId = rec.ObjId,
                    CRightId = rec.CRightId,
                    RoleName = rec.RoleName,
                    RateRh = (decimal) rec.RatePer,
                });

            DateProperty = new DateProperty();
            SelectedObjectsRightItemSource = new ObservableCollection<TransferedObjectsRightModel>(items);
        }

        /// <summary>
        /// Перенести всі об'єкти
        /// </summary>
        public ICommand MoveAllObjectsCommand => new IPSDelegateCommand(MoveAllObjectsCommandExecute, CanExecuteMoveObjectsCommand);
        private void MoveAllObjectsCommandExecute(object o)
        {
            var items = ObjectsRightItemSource
                .Select(rec => new TransferedObjectsRightModel
                {
                    Name = rec.Name,
                    ObjId = rec.ObjId,
                    CRightId = rec.CRightId,
                    RoleName = rec.RoleName,
                    RateRh = (decimal)rec.RatePer,
                });

            DateProperty = new DateProperty();
            SelectedObjectsRightItemSource = new ObservableCollection<TransferedObjectsRightModel>(items);
        }

        private bool CanExecuteMoveObjectsCommand(object o)
        {
            return ObjectsRightItemSource != null && ObjectsRightItemSource.Any();
        }

        #region - нижня панель - 

        /// <summary>
        /// Додати правонаступника
        /// </summary>
        public ICommand AddRightholderToTransferCommand => new IPSDelegateCommand(AddRightholderToTransferCommandExecute, CanExecuteAddRightholderToTransferCommand);
        private void AddRightholderToTransferCommandExecute(object o)
        {
            var window = new RightholdersListWindow();
            var dataContext = (RightholdersListViewModel)window.DataContext;
            dataContext.TransferTypeOfRight = TransferTypeOfRight.Default;

            if (LazyRightholdersCollection != null)
                dataContext.RightholdersItemSource = LazyRightholdersCollection;

            var result = window.ShowDialog() ?? false;

            if (result)
            {
                foreach (var item in SelectedObjectsRightItemSource)
                {
                    item.Rightholders.Add(new RightholderInfoModel
                    {
                        CustId = dataContext.SelectedRightholder.CustId,
                        RightholderName = dataContext.SelectedRightholder.Name,
                        IPI = dataContext.SelectedRightholder.InterCode,
                        RightholderCode = dataContext.SelectedRightholder.InnerCode,
                    });
                    item.UpdateDistributionPercents();
                }

                LazyRightholdersCollection = new ObservableCollection<RightholderCopyrightModel>(dataContext.RightholdersItemSource);
            }
        }

        private bool CanExecuteAddRightholderToTransferCommand(object o)
        {
            return SelectedObjectsRightItemSource != null && SelectedObjectsRightItemSource.Any();
        }

        /// <summary>
        /// Очистити дані
        /// </summary>
        public ICommand ClearObjectsCommand => new IPSDelegateCommand(ClearObjectsCommandExecute);
        private void ClearObjectsCommandExecute(object o)
        {
            var result = ShowMessage.ConfirmAction("Очистити дані?");
            if (result == MessageBoxResult.Yes)
                ClearData();
        }

        // TODO:
        /// <summary>
        /// Зберегти
        /// </summary>
        public ICommand SaveCommand => new IPSDelegateCommand(SaveCommandExecute);
        private void SaveCommandExecute(object o)
        {
            if (IsInfinityDateEnd)
                DateProperty.DateEnd = new DateTime(3000, 01, 01);

            if (!CheckDataValidate())
                return;

            var transferData = new ObjectTransferDataParameters
            {
                ParentCustId = SelectedRightholder.CustId,
                LegalBasis = TransferTypeOfRight == TransferTypeOfRight.Default ? 5 : 3,
            };

            foreach (var transferedObject in SelectedObjectsRightItemSource)
            {
                var item = new TransferObject
                {
                    ObjId = transferedObject.ObjId,
                    ParentCRightId = transferedObject.CRightId,
                    BeginDate = DateProperty.DateBegin.Value,
                    EndDate = DateProperty.DateEnd.Value,
                };

                foreach (var rightholder in transferedObject.Rightholders)
                {
                    item.TransferRightholders.Add(new TransferRightholder
                    {
                        CustId = rightholder.CustId,
                        Rate = rightholder.RightholderRate,
                    });
                }

                transferData.TransferObjects.Add(item);
            }

            var service = TransferOfRightService.GetInstance();
            object result;

            if (TransferTypeOfRight == TransferTypeOfRight.Default)
            {
                result = service.TransferRightsOfObjectsDetault(transferData);
            }
            else if (TransferTypeOfRight == TransferTypeOfRight.Haritage)
            {
                result = service.TransferRightsOfObjectsHeritage(transferData);
            }

            LazyRightholdersCollection = null;
            ClearData();
            ShowMessage.ShowInfo("Bingo!");
        }

        #endregion


        #endregion
    }
}
