using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public class CopyrightRequestPresenter
    {
        private readonly CopyrightRequestControl _view;
        private readonly RightholderService _rightholderService;
        private readonly DialogService _dialogService;

        public CopyrightRequestPresenter(CopyrightRequestControl view, RightholderService rightholderService)
        {
            _view = view;
            _view.Presenter = this;

            _rightholderService = rightholderService;
            _dialogService = new DialogService();
        }

        public void UpdateRightholderList()
        {
            var rightholderList = _rightholderService.GetRightholdersWithNotAcceptedCopyrights();
            _view.RightholderListDataSource = rightholderList;
        }

        public void UpdateObjectsList(int custId)
        {
            var objectRightList = _rightholderService.GetNotAcceptedObjectsByRightholder(custId);
            _view.ObjectRightListDataSource = objectRightList;
        }

        public void Save()
        {
            var objectRightList = (List<ObjectRightNotAccepted>)_view.ObjectRightListDataSource;
            var copyrighList = new List<CopyRight>();

            foreach(var obj in objectRightList)
            {
                var copyright = new CopyRight
                {
                    CRightId = obj.CRightId,
                    Rate = obj.Rate,
                };

                if (obj.WorkTypeRH.HasValue || obj.WorkDateRH.HasValue || !String.IsNullOrEmpty(obj.WorkCommentRH))
                {
                    copyright.WorkRh = new WorkRh
                    {
                        CRightId = obj.CRightId,
                        WorkTypeRh = obj.WorkTypeRH,
                        WorkDateRh = obj.WorkDateRH,
                        WorkCommentRh = obj.WorkCommentRH,
                    };
                }

                copyrighList.Add(copyright);
            }

            var result = _rightholderService.UpdateCopyrights(copyrighList);

            if (result)
            {
                UpdateObjectsList(_view.SelectedRightholder.CustId);
            }
            else
                _dialogService.ShowError(_view, "Не вдалося зберегти зміни.");
        }

        public void Print()
        {
            var objectRightList = (ICollection<ObjectRightNotAccepted>)_view.ObjectRightListDataSource;

            var printView = new ViewAndPrintAgreement();
            printView.Text = "Запит - " + _view.SelectedRightholder.Name;
            printView.ShowCopyrightRequest(_view.SelectedRightholder, objectRightList);

            UpdateStatusAndDate(objectRightList);
        }

        private void UpdateStatusAndDate(ICollection<ObjectRightNotAccepted> objectRightList)
        {
            foreach (var obj in objectRightList)
            {
                obj.WorkDateRH = DateTime.Now;
                obj.WorkTypeRH = 1;
            }

            Save();
        }
    }
}
