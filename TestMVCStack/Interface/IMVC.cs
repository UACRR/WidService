using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestMVCStack.Main;

namespace TestMVCStack.Interface
{
    public interface IService
    {
        IList<IData> GetList();
        IData newItem();
        IData Clone(object row);
        void Save(object row);
        void AddNexItem();
    }

    public interface IView
    {
        void SetBindingSource(object Source);
        IPresenterLevel presenter { get; }
    }
    public interface IViewMain : IView
    {
        void SetView(Control view);
    }

    public interface IViewWithCurrent : IView
    {
        void SetCurrentRow(object id);
    }

    public interface IPresenter
    {
        void Done();
        void Done(object id);
        void Cancel();
        void Refresh();
        void Refresh(object id);
        Type PresenterType { get; }
        void SetView(IView view);
    }

    public interface IPresenterMain : IPresenter
    {
        void presenterDone(object id);
        void presenterDone();
        void presenterCancel();
        void runGrid(IData curRow);
        void editData(IData curRow);
        void NewMainPresenter();
    }


    public interface IPresenterLevel  : IPresenter
    {
        IPresenterMain parent { get;  }
}



}
