
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;

namespace IpsViewComponentLibrary
{
    public class ObjectRightItemPresenter
    {
        private readonly ObjectRightItemView _view;
        private readonly ObjectRightService _objectRightService;
        private ObjectRight _objectRight;

        public ObjectRightItemPresenter(ObjectRightItemView view)
        {
            _view = view;
            _view.Presenter = this;

            _objectRightService = new ObjectRightService();
        }

        public void Run(ObjectRight objectRight, IList<ViewCustomer> rightholderList = null)
        {
            //_view.RightholderList = rightholderList;
            //_view.ObjectRight = objectRight;

            _view.SetDictionaries(_objectRightService.GetDictionary(), objectRight.CategoryCode);
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

        private void SetObjectRigth(ObjectRight objectRight, IList<ViewCustomer> rightholderList = null)
        {
            _objectRight = objectRight;
            _view.UpdateObjectRightDataSources(objectRight, rightholderList);
        }
    }
}
