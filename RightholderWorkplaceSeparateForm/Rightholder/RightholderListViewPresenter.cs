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

        public RightholderListViewPresenter(RightholderListView view)
        {
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

            OnAddedRightholder();
        }

        public event EventHandler AddedRightholder;

        protected void OnAddedRightholder()
        {
            AddedRightholder?.Invoke(this, EventArgs.Empty);
        }
    }
}
