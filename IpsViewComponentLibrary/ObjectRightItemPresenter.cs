
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    public class ObjectRightItemPresenter
    {
        private readonly ObjectRightItemView _view;
        private readonly ObjectRightService _objectRightService;
        private ObjectRight _objectRight;
        private ObjectRightDictionaries _dictionaries;

        public ObjectRightItemPresenter(ObjectRightItemView view)
        {
            _view = view;
            _view.Presenter = this;

            _objectRightService = new ObjectRightService();
            _dictionaries = _objectRightService.GetDictionary();
        }

        public void Run(ObjectRight objectRight, IList<ViewCustomer> rightholderList = null)
        {
            //_view.RightholderList = rightholderList;
            //_view.ObjectRight = objectRight;

            _view.SetDictionaries(_dictionaries, objectRight.CategoryCode);
            SetObjectRigth(objectRight, rightholderList);
            _view.Run();
        }

        public void ShowNew(int category, RightholderMainView defaultRightholder) // move defaultRightholder to property
        {
            var newObjectRight = _objectRightService.NewObjectRight(category);

            Run(newObjectRight);

            // TODO: process default rightholder
        }

        public void Show(int objId)
        {
            var objectContainer = _objectRightService.GetData(objId);

            Run(objectContainer.objectRight, objectContainer.rhList);
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
            var newObjectAuthorRightholder = new ObjectAuthorRightholder(); // _forRightholder - to fix

            using (var authorRightholderItemView = new AuthorRightholderItemView(newObjectAuthorRightholder, _dictionaries, _objectRight.CategoryCode))
            {
                authorRightholderItemView.ShowDialog();

                if (authorRightholderItemView.DialogResult == DialogResult.OK)
                {
                    _view.ObjectAuthorRightholderList.Add(newObjectAuthorRightholder);

                    //CalculateTotalPersent(); // to fix - update total persent from presenter presenter
                }
            }
        }

        public void EditObjectAuthorRightholder(ObjectAuthorRightholder objectAuthorRightholder)
        {
            using (var authorRightholderItemView = new AuthorRightholderItemView(objectAuthorRightholder, _dictionaries, _objectRight.CategoryCode))
            {
                authorRightholderItemView.ShowDialog();

                if (authorRightholderItemView.DialogResult == DialogResult.OK)
                {
                    //CalculateTotalPersent(); // to fix - update total persent from presenter presenter
                }
            }
        }

        public void DeleteObjectAuthorRightholder(ObjectAuthorRightholder objectAuthorRightholder)
        {
            _view.ObjectAuthorRightholderList.Remove(objectAuthorRightholder);

            //CalculateTotalPersent(); // to fix - update total persent from presenter presenter
        }

        public void Save()
        {
            if (_objectRight != null)
            {
                // map from single table to Authors and Copyright tables
                _objectRight.Authors.Clear();
                _objectRight.CopyRight.Clear();
                foreach (var ar in _view.ObjectAuthorRightholderList)
                {
                    _objectRight.AddObjectAuthorRightholder(ar);
                }

                if (_objectRight.CopyRight.GetTotalRate() > 100)
                {
                    _view.ShowError("Загальний відсоток володіння не може бути більше 100.");
                    return;
                }

                var result = _objectRightService.Save(_objectRight);

                // TODO: Raise broadcast event object right updated

                if (!result)
                    _view.ShowError("Не вдалося зберегти об'єкт.");
            }

            _view.Close();
        }

        private void SetObjectRigth(ObjectRight objectRight, IList<ViewCustomer> rightholderList = null)
        {
            // TODO: Set all bindings for object right here

            _objectRight = objectRight;
            _view.UpdateObjectRightDataSources(objectRight, rightholderList);

            // map Authors and Copyright table into single table
            foreach (var a in objectRight.Authors)
            {
                var foundedCopyright = objectRight.CopyRight.FirstOrDefault(c => c.CustId == a.CustId && c.RoleCode == a.RoleCode);
                var foundedRightholder = rightholderList?.FirstOrDefault(r => r.custId == a.CustId);

                _view.ObjectAuthorRightholderList.Add(new ObjectAuthorRightholder
                {
                    AuthId = a.AuthId,
                    ObjId = a.ObjId,
                    RoleCode = a.RoleCode,
                    FolkType = a.FolkType,
                    AuthorName = a.AuthorName,
                    IsRightholder = a.CustId != null,
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

        private void CalculateTotalPersent() // to fix
        {
            //var list = objectAuthorRightholderBindingSource.List.Cast<ObjectAuthorRightholder>();

            //var totalPersent = list.Where(ar => ar.Rate != null).Sum(s => s.Rate);

            //txtTotalPersent.Text = totalPersent.ToString();

            //if (totalPersent > 100)
            //    txtTotalPersent.ForeColor = Color.Red;
            //else
            //    txtTotalPersent.ForeColor = SystemColors.ControlText;
        }
    }
}
