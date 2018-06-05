using RightholderWorkplaceSeparateForm.Services;
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
        private readonly RightholdersService _service;

        public int SelectedRightholderId { get; set; }

        public RightholderListViewPresenter(RightholderListView view, RightholderViewPresenter parentPresenter, RightholdersService service)
        {
            _service = service;
            _parentPresenter = parentPresenter;
            _view = view;
            _view.Presenter = this;
        }

        public void GetList( object id = null)
        {
            var rightholders = _service.GetAll();
            _view.RighholdersList = rightholders;
            var custId = Convert.ToInt32(id);
            if (custId != 0)
            {
                _view.SelectedRightholderId = custId;
            }

        }
        public void Run()
        {
            GetList();
            if (SelectedRightholderId != 0)
            {
                _view.SelectedRightholderId = SelectedRightholderId;
            }

            _view.Run();
        }

        public void AddRightholder()
        {
            //RightholderType = 3;
            //OnAddedRightholder(RightholderType);

            //OnAddedRightholder();

            _parentPresenter.ShowRightholderItem();
        }

        public void EditRightholder()
        {
            var rightholderId = _view.SelectedRightholderId;

            _parentPresenter.ShowRightholderItem(rightholderId);
        }

        //public event EventHandler AddedRightholder;

        //protected void OnAddedRightholder()
        //{
        //    AddedRightholder?.Invoke(this, EventArgs.Empty);
        //}
    }
}
