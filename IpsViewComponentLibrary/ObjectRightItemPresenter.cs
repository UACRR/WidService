
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using System.Collections.Generic;

namespace IpsViewComponentLibrary
{
    public class ObjectRightItemPresenter
    {
        private readonly ObjectRightItemView _view;
        private readonly ObjectRightService _objectRightService;

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
            _view.UpdateObjectRightDataSources(objectRight, rightholderList);
            _view.Run();
        }

        public void ShowNew(int category, RightholderMainView defaultRightholder)
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
    }
}
