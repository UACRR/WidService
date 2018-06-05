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

        public RightholderViewPresenter(RightholderView view, MainViewPresenter parentPresenter)
        {
            _parentPresenter = parentPresenter;
            _view = view;
            _view.Presenter = this;
        }

        public void Run()
        {
            ShowRightholderList();
            _view.Run();
        }

        public void ShowRightholderList()
        {
            var rightholderListView = new RightholderListView();
            var rightholderListViewPresenter = new RightholderListViewPresenter(rightholderListView, this);
            //rightholderListViewPresenter.AddedRightholder += AddRightholder;
            rightholderListViewPresenter.Run();

            _view.ShowView(rightholderListView);
        }

        public void ShowRightholderItem()
        {
            var rightholderItemView = new RightholderItemView();
            var rightholderItemViewPresenter = new RightholderItemViewPresenter(rightholderItemView, this);
            //rightholderItemViewPresenter.SavedRightholder += SaveRightholder;
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
