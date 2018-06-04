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

        internal void Save()
        {
            OnSavedRightholder();
        }

        public void AddRightholder()
        {
            //OnSavedRightholder(Rightholder);

            OnSavedRightholder();
        }

        public event EventHandler SavedRightholder;

        protected void OnSavedRightholder()
        {
            SavedRightholder?.Invoke(this, EventArgs.Empty);
        }
    }
}
