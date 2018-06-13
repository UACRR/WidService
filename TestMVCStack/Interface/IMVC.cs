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

    public interface IPresenter
    {
        void Done();
        void Cancel();
        void Save( object item );
        void AddNew();
        void EditItem(object item);
        void NestPanel();
    }

}
