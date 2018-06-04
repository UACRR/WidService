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

        public RightholderItemViewPresenter(RightholderItemView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        public void Run()
        {
            _view.Run();
        }

        //public void AddRightholder()
        //{
        //    //RightholderType = 3;
        //    //OnAddedRightholder(RightholderType);

        //    OnAddedRightholder();
        //}

        //public event EventHandler AddedRightholder;

        //protected void OnAddedRightholder()
        //{
        //    AddedRightholder?.Invoke(this, EventArgs.Empty);
        //}
    }
}
