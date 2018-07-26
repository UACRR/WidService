using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public class CopyrightRequestPresenter
    {
        private readonly CopyrightRequestControl _view;
        private readonly RightholderService _rightholderService;

        public CopyrightRequestPresenter(CopyrightRequestControl view, RightholderService rightholderService)
        {
            _view = view;
            _view.Presenter = this;

            _rightholderService = rightholderService;
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
                _view.ShowError("Не вдалося зберегти зміни.");
        }

        public async void Print()
        {
            // process document
            var wordEngine = new WordEngine(IpsGlobal.AnketaDictionaties);
            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_Copyright-Request.docx");
            var objectRightList = (List<ObjectRightNotAccepted>)_view.ObjectRightListDataSource;
            await wordEngine.ProcessCopyrightRequest(template, _view.SelectedRightholder, objectRightList);

            // open view doc form
            var printView = new ViewAndPrintAgreement();
            printView.Text = "Запит на підтвердження прав на об'єкти";
            printView.ShowDocument(wordEngine.Pdf);

            // update status and date
        }
    }
}
