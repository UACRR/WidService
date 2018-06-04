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

        public RightholderViewPresenter(RightholderView view)
        {
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
            _view.ShowRightholderList();
        }

        public RightholderListView GetRightholderListView()
        {
            var rightholderListView = new RightholderListView();
            var rightholderListViewPresenter = new RightholderListViewPresenter(rightholderListView);
            rightholderListViewPresenter.AddedRightholder += AddRightholder;
            rightholderListViewPresenter.Run();

            return rightholderListView;
        }

        public void AddRightholder(object sender, EventArgs e)
        {
            _view.ShowRightholderItem();
        }

        public RightholderItemView GetRightholderItemView()
        {
            var rightholderItemView = new RightholderItemView();
            var rightholderItemViewPresenter = new RightholderItemViewPresenter(rightholderItemView);
            rightholderItemViewPresenter.SavedRightholder += SaveRightholder;
            rightholderItemViewPresenter.Run();

            return rightholderItemView;
        }

        public void SaveRightholder(object sender, EventArgs e)
        {
            // SelectedRightholderId = Id; ???
            _view.ShowRightholderList();
        }
    }
}
