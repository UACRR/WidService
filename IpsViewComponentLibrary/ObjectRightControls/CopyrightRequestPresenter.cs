using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;
using IpsViewComponentLibrary.ConsumerForms;
using System.Windows.Forms;
using IPSComponentLibrary.Forms;

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

        public void UpdateObjectsList()
        {
            IList<ObjectRightNotAccepted> objectRightList = _view.SelectedRightholder != null ?
                        _rightholderService.GetNotAcceptedObjectsByRightholder(_view.SelectedRightholder.CustId) :
                        new List<ObjectRightNotAccepted>();
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

                if (obj.WorkTypeRH.HasValue || obj.WorkDateRH.HasValue || !string.IsNullOrEmpty(obj.WorkCommentRH))
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
                UpdateObjectsList();
            }
            else
                _dialogService.ShowError(_view, "Не вдалося зберегти зміни.");
        }

        public void Print()
        {
            if(_view.SelectedRightholder == null )
            {
                MessageBox.Show("Не встановлено поточного запису", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var objectRightList = (ICollection<ObjectRightNotAccepted>)_view.ObjectRightListDataSource;

            var printView = new DocumentViewerForm();
            printView.Text = "Запит - " + _view.SelectedRightholder.Name;
            printView.ShowCopyrightRequest(_view.SelectedRightholder, objectRightList);

            UpdateStatusAndDate(objectRightList);
        }

        private void UpdateStatusAndDate(ICollection<ObjectRightNotAccepted> objectRightList)
        {
            if (_view.SelectedRightholder == null)
            {
                MessageBox.Show("Не встановлено поточного запису", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _view.SelectedRightholder.WorkDateRH = DateTime.Now;

            foreach (var obj in objectRightList)
            {
                obj.WorkDateRH = DateTime.Now;
                obj.WorkTypeRH = 1;
            }

            Save();
        }
    }
}
