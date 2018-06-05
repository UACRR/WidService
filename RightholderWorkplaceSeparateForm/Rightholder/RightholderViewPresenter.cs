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
            var rightholderListView = new RightholderListView();
            var rightholderListViewPresenter = new RightholderListViewPresenter(rightholderListView);
            rightholderListViewPresenter.AddedRightholder += AddRightholder;
            rightholderListViewPresenter.Run();

            _view.ShowRightholderList(rightholderListView);
        }

        public void AddRightholder(object sender, EventArgs e)
        {
            var rightholderItemView = new RightholderItemView();
            var rightholderItemViewPresenter = new RightholderItemViewPresenter(rightholderItemView);
            rightholderItemViewPresenter.SavedRightholder += SaveRightholder;
            rightholderItemViewPresenter.Run();

            _view.ShowRightholderItem(rightholderItemView);
        }

        public void SaveRightholder(object sender, EventArgs e)
        {
            // SelectedRightholderId = Id; ???
            ShowRightholderList();
        }
    }
}
