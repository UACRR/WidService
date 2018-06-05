using RightholderWorkplaceSeparateForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace RightholderWorkplaceSeparateForm.Rightholder
{
    public class RightholderViewPresenter
    {
        private readonly RightholderView _view;
        private readonly MainViewPresenter _parentPresenter; // TODO: IPresenter or IChildPresenter
        private readonly RightholdersService _service;

        public RightholderViewPresenter(RightholderView view, MainViewPresenter parentPresenter)
        {
            _parentPresenter = parentPresenter;
            _view = view;
            _view.Presenter = this;

            _service = new RightholdersService();
        }

        public void Run()
        {
            ShowRightholderList();
            _view.Run();
        }

        public void ShowRightholderList(int id = 0)
        {
            var rightholderListView = new RightholderListView();
            var rightholderListViewPresenter = new RightholderListViewPresenter(rightholderListView, this, _service);
            rightholderListViewPresenter.SelectedRightholderId = id;
            //rightholderListViewPresenter.AddedRightholder += AddRightholder;
            rightholderListViewPresenter.Run();

            _view.ShowView(rightholderListView);
        }

        public void ShowRightholderItem(int id = 0)
        {
            var rightholderItemView = new RightholderItemView();
            var rightholderItemViewPresenter = new RightholderItemViewPresenter(rightholderItemView, this, _service);
            //rightholderItemViewPresenter.SavedRightholder += SaveRightholder;
            rightholderItemViewPresenter.RightholderId = id;
            rightholderItemViewPresenter.Run();

            _view.ShowView(rightholderItemView);
        }

        //public void AddRightholder(object sender, EventArgs e)
        //{
        //    //TODO: create empty object

        //    ShowRightholderItem();
        //}

        //public void SaveRightholder(object sender, EventArgs e)
        //{
        //    // SelectedRightholderId = Id; ???
        //    ShowRightholderList();
        //}
    }
}
