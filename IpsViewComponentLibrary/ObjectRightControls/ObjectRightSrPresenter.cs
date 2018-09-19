
using ipsFormsDesign;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Events;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public class ObjectRightSrPresenter
    {
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

            _view.FormClosing += View_FormClosing;

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
            var newObjectRight = _objectRightService.NewObjectRight(category);

            Run(newObjectRight);
        }

        public void Show(int objId)
        {
            var objectContainer = _objectRightService.GetData(objId);

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
            var objectContainer = _objectRightService.GetData(objId);
            SetObjectRigth(objectContainer.objectRight, objectContainer.rhList);
        }

        public void NewObject()
        {
            if (_objectRight != null)
            {
                var newObjectRight = _objectRightService.NewObjectRight(_objectRight.CategoryCode);

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

            if (result)
                _view.Close();
            else
                _dialogService.ShowError(_view, "Не вдалося зберегти об'єкт.");
        }

        private void SetObjectRigth(ObjectRight objectRight, IList<ViewCustomer> rightholderList = null)
        {
            // TODO: Set all bindings for object right here

            _objectRight = objectRight;
            _view.UpdateObjectRightDataSources(objectRight, rightholderList);

            // map Authors and Copyright table into single table
            _view.ObjectAuthorRightholderList.Clear();

            foreach (var a in objectRight.Authors)
            {
                var foundedCopyright = objectRight.CopyRight.FirstOrDefault(c => c.CustId == a.CustId && c.RoleCode == a.RoleCode);
                var foundedRightholder = rightholderList?.FirstOrDefault(r => r.custId == a.CustId);

                _view.ObjectAuthorRightholderList.Add(new ObjectAuthorRightholder
                {
                    IsRightholder = a.CustId != null,
                    AuthId = a.AuthId,
                    ObjId = a.ObjId,
                    RoleCode = a.RoleCode,
                    FolkType = a.FolkType,
                    AuthorName = a.AuthorName,
                    CustId = a.CustId,
                    CRightId = foundedCopyright?.CRightId,
                    CopyrightStatus = foundedCopyright?.Status,
                    CommunityName = foundedRightholder?.Community_Name,
                    Rate = foundedCopyright?.Rate,
                    BeginDate = foundedCopyright?.BeginDate,
                    EndDate = foundedCopyright?.EndDate,
                });
            }
        }

        private void View_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_canClose)
                _canClose = _dialogService.ClosingIsConfirmed(_view);

            if (_canClose)
                _view.Hide();
        }
    }
}
