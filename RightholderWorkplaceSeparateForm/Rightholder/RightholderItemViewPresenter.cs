using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightholderWorkplaceSeparateForm.Rightholder
{
    public class RightholderItemViewPresenter
    {
        private readonly RightholderItemView _view;
        private readonly RightholderViewPresenter _parentPresenter; // TODO: IPresenter or IChildPresenter

        public RightholderItemViewPresenter(RightholderItemView view, RightholderViewPresenter parentPresenter)
        {
            _parentPresenter = parentPresenter;
            _view = view;
            _view.Presenter = this;
        }

        public void Run()
        {
            _view.Run();
        }

        public void Save()
        {
            // Save to db

            //OnSavedRightholder();

            _parentPresenter.ShowRightholderList();
        }

        //public void AddRightholder()
        //{
        //    //OnSavedRightholder(Rightholder);

        //    OnSavedRightholder();
        //}

        //public event EventHandler SavedRightholder;

        //protected void OnSavedRightholder()
        //{
        //    SavedRightholder?.Invoke(this, EventArgs.Empty);
        //}
    }
}
