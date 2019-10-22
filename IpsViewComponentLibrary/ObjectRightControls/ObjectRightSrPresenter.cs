
using ipsFormsDesign;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Events;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public class ObjectRightSrPresenter
    {
        private const string SaveObjectSuccessMsg = "Об'єкт збережено!";
        private const string SaveObjectErrorMsg = "Не вдалося зберегти об'єкт!";

        private readonly ObjectRightSrView _view;
        private readonly ObjectRightService _objectRightService;
        private readonly DialogService _dialogService;
        private ObjectRight _objectRight;
        private ObjectRightDictionaries _dictionaries;
        private bool _canClose;

        public RightholderMainView DefaultRightholder { get; set; }

        public ObjectRightSrPresenter(ObjectRightSrView view)
        {
            _view = view;
            _view.Presenter = this;

            _objectRightService = new ObjectRightService();
            _dialogService = new DialogService();
            _dictionaries = _objectRightService.GetDictionary();
        }

        public void Run(ObjectRight objectRight, IList<ViewCustomer> rightholderList = null)
        {
            _view.SetDictionaries(_dictionaries, objectRight.CategoryCode);
            SetObjectRigth(objectRight, rightholderList);

            var header = objectRight.ObjId == 0 ? "(Новий)" : objectRight.Name;
            _view.SetHeader(header);

            _view.Run();
        }

        public void ShowNew(int category)
        {
            var newObjectRight = _objectRightService.New(category);

            Run(newObjectRight);
        }

        public void Show(int objId)
        {
            var objectContainer = _objectRightService.GetObjectById(objId);

            Run(objectContainer.objectRight, objectContainer.rhList);
        }

        public void Show(ObjectRight objectRight)
        {
            Run(objectRight);
        }

        public List<ObjectRightMainView> GetObjectsForAutocomplite(string filter)
        {
            var objects = _objectRightService.GetObjectsByFilter(filter);

            return objects;
        }

        public void ObjectNameAutocompliteListItemSelected(int objId)
        {
            var objectContainer = _objectRightService.GetObjectById(objId);
            SetObjectRigth(objectContainer.objectRight, objectContainer.rhList);
        }

        public void NewObject()
        {
            if (_objectRight != null)
            {
                var newObjectRight = _objectRightService.New(_objectRight.CategoryCode);

                newObjectRight.Name = _objectRight.Name;

                SetObjectRigth(newObjectRight);
            }
        }

        public void AddObjectAuthorRightholder()
        {
            ObjectAuthorRightholder newObjectAuthorRightholder;

            if (DefaultRightholder == null)
                newObjectAuthorRightholder = new ObjectAuthorRightholder();
            else
                newObjectAuthorRightholder = new ObjectAuthorRightholder(DefaultRightholder);


            using (var authorRightholderItemView = new AuthorRightholderItemView(newObjectAuthorRightholder, _dictionaries, _objectRight.CategoryCode))
            {
                authorRightholderItemView.ShowDialog();

                if (authorRightholderItemView.DialogResult == DialogResult.OK)
                {
                    _view.ObjectAuthorRightholderList.Add(newObjectAuthorRightholder);
                }
            }
        }

        public void EditObjectAuthorRightholder(ObjectAuthorRightholder objectAuthorRightholder)
        {
            using (var authorRightholderItemView = new AuthorRightholderItemView(objectAuthorRightholder, _dictionaries, _objectRight.CategoryCode))
            {
                authorRightholderItemView.ShowDialog();
            }
        }

        public void DeleteObjectAuthorRightholder(ObjectAuthorRightholder objectAuthorRightholder)
        {
            _view.ObjectAuthorRightholderList.Remove(objectAuthorRightholder);
        }

        public void Save()
        {
            if (_objectRight == null)
                return;

            _canClose = true;

            // map from single table to Authors and Copyright tables
            _objectRight.Authors.Clear();
            _objectRight.CopyRight.Clear();
            foreach (var ar in _view.ObjectAuthorRightholderList)
            {
                _objectRight.AddObjectAuthorRightholder(ar);
            }

            if (_objectRight.CopyRight.GetTotalRate() > 100)
            {
                _dialogService.ShowError(_view, "Загальний відсоток володіння не може бути більше 100.");
                return;
            }

            var result = _objectRightService.Save(_objectRight);

            ApplicationController.Instance.EventAggregator.PublishEvent(new ObjectRightUpdatedEvent());
            ApplicationController.Instance.EventAggregator.PublishEvent(new RightholderUpdatedEvent());

            MessageShow.ShowInfoByResult(SaveObjectSuccessMsg, SaveObjectErrorMsg, result);

            //if (result)
            //    _view.Close();
            //else
            //    _dialogService.ShowError(_view, "Не вдалося зберегти об'єкт.");
        }

        private void SetObjectRigth(ObjectRight objectRight, IList<ViewCustomer> rightholderList = null)
        {
            // TODO: Set all bindings for object right here

            _objectRight = objectRight;
            _view.UpdateObjectRightDataSources(objectRight, rightholderList);

            // map Authors and Copyright table into single table
            _view.ObjectAuthorRightholderList.Clear();
            int[] RightHolderOnlyCode = { 8, 9 };
            var today = DateTime.Today;
            // Права дійсні на поточну дату
            var listOfCopyRight = objectRight.CopyRight
                            .Where(rec => rec.BeginDate <= today && rec.EndDate >= today )
                            .ToList();

            // створюємо пошук по списку прав по ключу custid & RoleCode
            var copyRightLookup = listOfCopyRight.ToLookup(rec => new { rec.CustId, RoleCode = (rec.RoleCode ?? 0) }, rec => rec.CRightId);

            foreach (var a in objectRight.Authors)
            {
                // Список ід прав для автора
                var findCRArray = copyRightLookup[new { CustId = (a.CustId ?? 0), a.RoleCode }].ToArray();
                // Тільки автор які на поточний момент немають правоволодіння
                //if ( (a.CustId ?? 0) == 0 )
                if (findCRArray.Count() == 0 ) // Прав немає
                {
                    // Підрахунок існуючих записів авторів
                    var cntPresent = _view.ObjectAuthorRightholderList
                                            .Count( rec => rec.RoleCode == a.RoleCode 
                                                    && rec.FolkType == a.FolkType
                                                    && string.Compare( rec.AuthorName, a.AuthorName.Trim(), StringComparison.InvariantCulture ) == 0 ) ;
                    
                    // Окрім правовласників і нові записи
                    if (!RightHolderOnlyCode.Contains(a.RoleCode) && cntPresent == 0)
                    _view.ObjectAuthorRightholderList.Add(new ObjectAuthorRightholder
                    {
                        IsRightholder = false,
                        AuthId = a.AuthId,
                        ObjId = a.ObjId,
                        RoleCode = a.RoleCode,
                        FolkType = a.FolkType,
                        AuthorName = a.AuthorName.Trim()
                    });

                    continue;
                }
                
                // Автор-Правовласник
                var foundedCopyrightList = listOfCopyRight.Where(c => c.CustId == a.CustId && c.RoleCode == a.RoleCode).ToArray();
                var foundedRightholder = rightholderList?.FirstOrDefault(r => r.custId == a.CustId);
                foreach (var foundedCopyright in foundedCopyrightList)
                {
                    // Патлякевич
                    // Бородьба з подвійними записами в Авторах
                    if (foundedCopyright != null)
                        listOfCopyRight.Remove(foundedCopyright);

                    // Патлякевич
                    // Не виводимо правовласників, права яких на об'єкт права вже закінчилися
                    if (RightHolderOnlyCode.Contains(a.RoleCode) && foundedCopyright == null)
                        continue;

                    _view.ObjectAuthorRightholderList.Add(new ObjectAuthorRightholder
                    {
                        IsRightholder = a.CustId != null,
                        AuthId = a.AuthId,
                        ObjId = a.ObjId,
                        RoleCode = a.RoleCode,
                        FolkType = a.FolkType,
                        AuthorName = a.AuthorName.Trim(),
                        CustId = a.CustId,
                        CRightId = foundedCopyright?.CRightId,
                        CopyrightStatus = foundedCopyright?.Status,
                        CommunityName = foundedRightholder?.Community_Name,
                        Rate = foundedCopyright?.Rate ?? 0m,
                        RateMech = foundedCopyright?.RateMech ?? 0m,
                        BeginDate = foundedCopyright?.BeginDate,
                        EndDate = foundedCopyright?.EndDate,
                    });
                }
            }
        }

        public void Close()
        {
            _view.Hide();
            // TODO: indicate when data was changed
            //if (!_canClose)
            //    _canClose = _dialogService.ClosingIsConfirmed((IWin32Window)_view);

            //if (_canClose)
            //    _view.Hide();
        }
    }
}
