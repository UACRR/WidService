using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using IpsCommonTypes.DataModels;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
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
                    NewRightholderName = string.Empty;

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

            var service = RoyaltyCorrectionService.GetInstance();


            IsBusy = true;
            var result = await service.SearchObjectRightAsync(RightholderID.Value, ObjectRightID.Value);
            IsBusy = false;

            if (result.HasException) 
                ShowMessage.ShowError(result.Exception);

            if (result.Data == null)
            {
                ShowMessage.ShowWarning($"Нарахованого роялті з об'єкта права з ID: {ObjectRightID.Value} для правовласника з ID: {RightholderID.Value} не знайдено!");
                return;
            }

            // parse result

            ObjectRightName = result.Data.ObjectRightName;
            RightholderName = result.Data.RightholderName;
            ObjectLoaded = true;

            var list = new ObservableListSource<CopyrightTypeModel>();
            foreach (var item in result.Data.TransferList)
            {
                list.Add(new CopyrightTypeModel
                {
                    Amount = item.Amount,
                    Rate = item.Rate,
                    Kindcode = item.Kindcode,
                    DateWork = item.Datework,
                });
            }

            CopyrightTypesItemSource = list;
        }

        public ICommand SearchRightholderCommand => new IPSDelegateCommand(SearchRightholderCommandExecute);
        private async void SearchRightholderCommandExecute(object o)
        {
            if (!NewRightholderID.HasValue)
                return;
            
            var service = RoyaltyCorrectionService.GetInstance();

            IsBusy = true;
            var result = await service.SearchRightholderAsync(NewRightholderID.Value);
            IsBusy = false;

            if (result.HasException)
            {
                ShowMessage.ShowError(result.Exception);
                return;
            }

            if (result.Data != null)
            {
                IsNewRightholderSelected = true;
                NewRightholderName = result.Data.FullName;
            }
            else
            {
                ShowMessage.ShowWarning($"Правовласника з ID: «{NewRightholderID.Value}» не знайдено!");
                NewRightholderName = string.Empty;
            }
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
                var service = RoyaltyCorrectionService.GetInstance();

                var paramsList = new List<RoyaltyCorrectionParams>();
                foreach (var copyrightTypeModel in selectedList)
                {
                    paramsList.Add(new RoyaltyCorrectionParams
                    {
                        CustIdD = NewRightholderID.Value,
                        CustIdK = RightholderID.Value,
                        Amount = copyrightTypeModel.Amount,
                        Objid = ObjectRightID.Value,
                        KindCode = copyrightTypeModel.Kindcode,
                    });
                }

                IsBusy = true;
                var result = await service.RunCorrectionProcessAsync(paramsList);
                IsBusy = false;

                if (result.IsSuccess)
                {
                    ShowMessage.ShowInfo("Виправлення успішно виконано!");


                    var objectRightId = ObjectRightID.Value;
                    var rightholderId = RightholderID.Value;

                    ClearCommand.Execute(null);

                    ObjectRightID = objectRightId;
                    RightholderID = rightholderId;

                    SearchObjectCommand.Execute(null);
                }
                else
                {
                    if (result.HasException)
                    {
                        ShowMessage.ShowError(result.Exception);
                    }
                    else
                    {
                        var records = string.Join(";\n", result.Data.Select(rec => $"сума: {rec.Amount:N2}").ToList()) ;
                        ShowMessage.ShowError($"Неможливо виконати виправлення для записів: \n{records}");
                    }
                }
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
