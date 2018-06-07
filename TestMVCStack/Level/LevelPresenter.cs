using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestMVCStack.Interface;
using TestMVCStack.Main;

namespace TestMVCStack
{
    public abstract class LevelPresenterBase : IPresenterLevel
    {
        public IPresenterMain parent { get;  }
        public IView view = null;
        protected IService service { get;  }
        public LevelPresenterBase( IPresenterMain parent, IService service )
        {
            this.parent = parent;
            this.service = service;
        }

        public Type PresenterType { get { return typeof(IData); } }

        public void Done( )
        {
            parent.presenterDone();
        }

        public void Done( object id )
        {
            parent.presenterDone(id);
        }


        abstract public void Refresh();
        abstract public void Refresh(object id);

        public void SetView(IView view)
        {
            this.view = view; ;
        }

        public void Cancel()
        {
            parent.presenterCancel();
        }
    }

    public class GridLevelPresenter : LevelPresenterBase
    {
        public GridLevelPresenter(IPresenterMain parent, IService service) : base(parent,service)
        {

        }
        public override void Refresh()
        {
            var list = service.GetList();
            view.SetBindingSource(list);
        }

        public override void Refresh(object id)
        {
            var list = service.GetList();
            view.SetBindingSource(list);
            var selectedView = view as IViewWithCurrent;
            if (selectedView != null)
                selectedView.SetCurrentRow(id);

        }
    }
}
