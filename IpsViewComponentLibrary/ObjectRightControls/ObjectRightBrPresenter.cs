using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Events;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public class ObjectRightBrPresenter
    {
        private readonly ObjectRightBrView _view;
        private readonly ObjectRightService _objectRightService;
        private readonly DialogService _dialogService;
        private ObjectRight _objectRight;
        private BindingList<ObjectAuthorRightholderBrViewModel> _authorRightholderList;
        private bool _saved;

        public ObjectRightBrPresenter(ObjectRightBrView view)
        {
            _view = view;
            _view.Presenter = this;

            _view.FormClosing += View_FormClosing;

            _objectRightService = new ObjectRightService();
            _dialogService = new DialogService();
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
                    Country = foundedRightholder?.Country,
                    InnerCode = foundedRightholder?.InnerCode,
                    Author = a,
                    CopyRight = foundedCopyright,
                    LicAuthorBr = foundedCopyright.LicAuthorBr ?? new LicAuthorBr(),
                    WorkRh = foundedCopyright.WorkRh ?? new WorkRh(),
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

            _saved = true;

            // map from single table to Authors, Copyright, LicAuthorBr and WorkRh tables
            _objectRight.Authors.Clear();
            _objectRight.CopyRight.Clear();

            foreach (var ar in _authorRightholderList)
            {
                _objectRight.AddObjectBrAuthorRightholder(ar);
            }

            var result = _objectRightService.SaveObjectBr(_objectRight);

            ApplicationController.Instance.EventAggregator.PublishEvent(new ObjectRightUpdatedEvent());
            ApplicationController.Instance.EventAggregator.PublishEvent(new RightholderUpdatedEvent());

            if (result)
                _view.Close();
            else
                _dialogService.ShowError(_view, "Не вдалося зберегти об'єкт.");
        }

        private void View_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_saved && !_dialogService.ClosingIsConfirmed(_view))
            {
                e.Cancel = true;
            }
        }
    }
}
