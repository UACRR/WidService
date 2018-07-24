using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public class ObjectRightBrPresenter
    {
        private readonly ObjectRightBrView _view;
        private ObjectRightService _objectRightService;
        private ObjectRight _objectRight;
        private BindingList<ObjectAuthorRightholderBrViewModel> _authorRightholderList;

        public ObjectRightBrPresenter(ObjectRightBrView view)
        {
            _view = view;
            _view.Presenter = this;

            _objectRightService = new ObjectRightService();
        }

        public void Show(int objId)
        {
            var objectContainer = _objectRightService.GetDataBr(objId);

            SetObjectRightData(objectContainer.objectRight, objectContainer.rhList);

            _view.Run();
        }

        private void SetObjectRightData(ObjectRight objectRight, IList<ViewCustomer> rightholderList = null)
        {
            _objectRight = objectRight;

            _view.ObjectRightDataSource = _objectRight;
            _view.LicenseBigRDataSource = _objectRight.LicenseBigR;

            // map Authors, Copyright, LicAuthorBr and WorkRh tables into single table
            var tmpAuthorRightholderList = _objectRight.Authors.Select(a =>
            {
                var foundedCopyright = objectRight.CopyRight.FirstOrDefault(c => c.CustId == a.CustId && c.RoleCode == a.RoleCode);
                var foundedRightholder = rightholderList?.FirstOrDefault(r => r.custId == a.CustId);

                return new ObjectAuthorRightholderBrViewModel
                {
                    //Country = foundedRightholder.Country, // TODO: Country
                    //InnerCode = foundedRightholder.InnerCode, // TODO: InnerCode
                    Author = a,
                    CopyRight = foundedCopyright,
                    LicAuthorBr = foundedCopyright.LicAuthorBr,
                    WorkRh = foundedCopyright.WorkRh,
                };
            })
            .ToList();

            _authorRightholderList = new BindingList<ObjectAuthorRightholderBrViewModel>(tmpAuthorRightholderList);

            _view.AuthorRightholderListDataSource = _authorRightholderList;
        }

        public void Save()
        {
            if (_objectRight == null)
                return;

            // map from single table to Authors, Copyright, LicAuthorBr and WorkRh tables
            _objectRight.Authors.Clear();
            _objectRight.CopyRight.Clear();

            foreach (var ar in _authorRightholderList)
            {
                _objectRight.AddObjectBrAuthorRightholder(ar);
            }

            var result = _objectRightService.SaveObjectBr(_objectRight);

            // TODO: Raise broadcast event object right updated

            if (result)
                _view.Close();
            else
                _view.ShowError("Не вдалося зберегти об'єкт.");
        }
    }
}
