using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Events;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;
using System.Collections.Generic;
using System.ComponentModel;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public class ObjectRightBrPresenter
    {
        private const string SaveObjectSuccessMsg = "Об'єкт збережено!";
        private const string SaveObjectErrorMsg = "Не вдалося зберегти об'єкт!";

        private readonly ObjectRightBrView _view;
        private readonly ObjectRightService _objectRightService;
        private readonly DialogService _dialogService;
        private ObjectRight _objectRight;
        private BindingList<ObjectAuthorRightholderBrViewModel> _authorRightholderList;
        private bool _canClose;

        public ObjectRightBrPresenter(ObjectRightBrView view)
        {
            _view = view;
            _view.Presenter = this;

            _objectRightService = new ObjectRightService();
            _dialogService = new DialogService();
        }

        public void Show(int objId)
        {
            var objectContainer = _objectRightService.GetDataBr(objId);

            SetObjectRightData(objectContainer.objectRight, objectContainer.rhList);

            var header = objectContainer.objectRight.ObjId == 0 ? "(Новий)" : objectContainer.objectRight.Name;
            _view.SetHeader(header);

            _view.Run();
        }

        private void SetObjectRightData(ObjectRight objectRight, IList<ViewCustomer> rightholderList = null)
        {
            _objectRight = objectRight;

            _view.ObjectRightDataSource = _objectRight;
            _view.LicenseBigRDataSource = _objectRight.LicenseBigR;

            // map Authors, Copyright, LicAuthorBr and WorkRh tables into single table
            _authorRightholderList = new BindingList<ObjectAuthorRightholderBrViewModel>(_objectRight.GetObjectBrAuthorRightholderList(rightholderList));

            _view.AuthorRightholderListDataSource = _authorRightholderList;
        }

        public void Save()
        {
            if (_objectRight == null)
                return;

            _canClose = true;

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

            MessageShow.ShowInfoByResult(SaveObjectSuccessMsg, SaveObjectErrorMsg, result);


            //if (result)
            //    _view.Close();
            //else
            //    _dialogService.ShowError(_view, "Не вдалося зберегти об'єкт.");
        }

        public void Close()
        {
            _view.Hide();
            // TODO: indicate when data was changed
            //if (!_canClose)
            //    _canClose = _dialogService.ClosingIsConfirmed(_view);

            //if (_canClose)
            //    _view.Hide();
        }
    }
}
