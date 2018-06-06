using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestMVCStack.Main;

namespace TestMVCStack
{
    public class PresenterMain
    {
        public Control View { get; set; }
        public ServiceMain service { get; set; }

        public void Done(Type retType, object id)
        {
        }
        public void Done()
        {
        }

        public void Cancel()
        {

        }
    }
}
