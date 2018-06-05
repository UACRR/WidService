using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightholderWorkplaceSeparateForm.Rightholder
{
    public class RightholderListViewPresenter
    {
        private readonly RightholderListView _view;
        private readonly RightholderViewPresenter _parentPresenter; // TODO: IPresenter or IChildPresenter

        public RightholderListViewPresenter(RightholderListView view, RightholderViewPresenter parentPresenter)
        {
            _parentPresenter = parentPresenter;
            _view = view;
            _view.Presenter = this;
        }

        public void Run()
        {
            _view.Run();
        }

        public void AddRightholder()
        {
            //RightholderType = 3;
            //OnAddedRightholder(RightholderType);

            //OnAddedRightholder();

            _parentPresenter.ShowRightholderItem();
        }

        //public event EventHandler AddedRightholder;

        //protected void OnAddedRightholder()
        //{
        //    AddedRightholder?.Invoke(this, EventArgs.Empty);
        //}
    }
}
