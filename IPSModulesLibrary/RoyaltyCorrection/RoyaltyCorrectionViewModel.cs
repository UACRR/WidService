using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ipsFormsDesign.Interfaces;
using IPSViewComponentLibraryWPF.Extensions;
using IPSViewComponentLibraryWPF.IPSExtensions;

namespace IPSModulesLibrary.RoyaltyCorrection
{
    public class RoyaltyCorrectionViewModel : IPSViewModel<LM_RoyaltyCorrection>
    {

        #region * * * PROPERTIES * * *

        private int? _objectRightId;
        public int? ObjectRightID
        {
            get => _objectRightId;
            set
            {
                if (_objectRightId != value)
                {
                    ObjectLoaded = false;
                    ObjectRightName = string.Empty;
                }

                _objectRightId = value;
                OnPropertyChanged(() => ObjectRightID);
            }
        }

        private int? _rightholderId;
        public int? RightholderID
        {
            get => _rightholderId;
            set
            {
                if (_rightholderId != value)
                {
                    ObjectLoaded = false;
                    RightholderName = string.Empty;
                }

                _rightholderId = value;
                OnPropertyChanged(() => RightholderID);
            }
        }

        private string _objectRightName;
        public string ObjectRightName
        {
            get => _objectRightName;
            set
            {
                _objectRightName = value;
                OnPropertyChanged(() => ObjectRightName);
            }
        }

        private string _rightholderName;
        public string RightholderName
        {
            get => _rightholderName;
            set
            {
                _rightholderName = value;
                OnPropertyChanged(() => RightholderName);
            }
        }

        private bool ObjectLoaded { get; set; }

        private ObservableListSource<CopyrightTypeModel> _copyrightTypesItemSource;
        public ObservableListSource<CopyrightTypeModel> CopyrightTypesItemSource
        {
            get => _copyrightTypesItemSource;
            set
            {
                _copyrightTypesItemSource = value; 
                OnPropertyChanged(() => CopyrightTypesItemSource);
            }
        }

        private int? _newRightholderId;
        public int? NewRightholderID
        {
            get => _newRightholderId;
            set
            {
                if (_newRightholderId != value)
                {
                    IsNewRightholderSelected = false;
                    NewRightholderName = null;
                }

                _newRightholderId = value;
                OnPropertyChanged(() => NewRightholderID);
            }
        }

        private string _newRightholderName;
        public string NewRightholderName
        {
            get => _newRightholderName;
            set
            {
                _newRightholderName = value;
                IsNewRightholderSelected = !string.IsNullOrEmpty(value);
                OnPropertyChanged(() => NewRightholderName);
            }
        }

        private bool IsNewRightholderSelected { get; set; }

        #endregion

        #region * * * METHODS * * *


        #endregion

        #region * * * COMMANDS * * *

        public ICommand LoadCommand => new IPSDelegateCommand(LoadCommandExecute);
        private void LoadCommandExecute(object o)
        {
            
        }

        public ICommand SearchObjectCommand => new IPSDelegateCommand(SearchObjectCommandExecute);
        private async void SearchObjectCommandExecute(object o)
        {

            if(!ObjectRightID.HasValue || !RightholderID.HasValue)
            {
                ShowMessage.ShowWarning("Необхідно ввести код об'єкта права та код його правовласника!");
                return;
            }

            IsBusy = true;
            await Task.Delay(2340);
            IsBusy = false;

            ObjectRightName = "Заспіпаю я пісню тихую...побудила ой мати нас рано...";
            RightholderName = "Фальсифікований Олександр Олександрович";
            ObjectLoaded = true;

            CopyrightTypesItemSource = new ObservableListSource<CopyrightTypeModel>
            {
                new CopyrightTypeModel
                {
                    TypeName = "Публічне сповіщення",
                    Amount = 73876.54f,
                    Rate = 42.5f,
                },
                new CopyrightTypeModel
                {
                    TypeName = "Механічне відтворення",
                    Amount = 5948.11f,
                    Rate = 33.7f,
                },
                new CopyrightTypeModel
                {
                    TypeName = "Суміжні права",
                },
            };
        }

        public ICommand SearchRightholderCommand => new IPSDelegateCommand(SearchRightholderCommandExecute);
        private async void SearchRightholderCommandExecute(object o)
        {
            if (!NewRightholderID.HasValue)
                return;

            // some process
            IsBusy = true;
            await Task.Delay(2340);
            IsBusy = false;

            IsNewRightholderSelected = true;
            NewRightholderName = "Зажурений Тарас Григорович";
        }

        public ICommand RunCorrectionProcessCommand => new IPSDelegateCommand(RunCorrectionProcessCommandExecute, CanExecuteRunCorrectionProcessCommand);
        private async void RunCorrectionProcessCommandExecute(object o)
        {
            if (!IsNewRightholderSelected)
            {
                ShowMessage.ShowWarning("Не обрано правильного правовласника!");
                return;
            }

            var selectedList = CopyrightTypesItemSource.Where(rec => rec.IsSelected).ToList();
            if (!selectedList.Any())
            {
                ShowMessage.ShowWarning("Не обрано вид(и) права по якому(им) необхідно зробити виправлення!");
                return;
            }

            var confirmAction = ShowMessage.ConfirmAction("Виконати виправлення?");

            if (confirmAction == MessageBoxResult.Yes)
            {
                IsBusy = true;
                await Task.Delay(2340);
                IsBusy = false;

                ShowMessage.ShowInfo("Ok!");
            }
        }

        public bool CanExecuteRunCorrectionProcessCommand (object o) => ObjectLoaded && CopyrightTypesItemSource != null && CopyrightTypesItemSource.Any();
        
        public ICommand ClearCommand => new IPSDelegateCommand(ClearCommandExecute);
        private void ClearCommandExecute(object o)
        {
            var confirmAction = ShowMessage.ConfirmAction("Очистити дані?");

            if (confirmAction != MessageBoxResult.Yes)
                return;

            RightholderID = null;
            RightholderName = string.Empty;

            ObjectRightID = null;
            ObjectRightName = string.Empty;

            ObjectLoaded = false;

            CopyrightTypesItemSource = null;

            NewRightholderID = null;
            NewRightholderName = string.Empty;
        }

        #endregion
    }
}
