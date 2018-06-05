using RightholderWorkplaceSeparateForm.Services;
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
        private readonly RightholdersService _service;

        public RightholderItemViewPresenter(RightholderItemView view, RightholderViewPresenter parentPresenter, RightholdersService service)
        {
            _service = service;
            _parentPresenter = parentPresenter;
            _view = view;
            _view.Presenter = this;
        }

        public int RightholderId { get; set; }

        public void Run()
        {
            if (RightholderId == 0)
            {
                _view.Rightholder = _service.New();
            }
            else
            {
                _view.Rightholder = _service.GetById(RightholderId);
            }

            _view.Run();
        }

        public void Save()
        {
            var rightholder = _view.Rightholder;

            if (rightholder.Id == 0)
            {
                _service.Add(rightholder);
            }
            else
            {
                _service.Update(rightholder);
            }


            //OnSavedRightholder();

            _parentPresenter.Back( rightholder.Id );
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
