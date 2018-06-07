using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCStack
{
    public class LevelPresenter
    {
        private PresenterMain parent = null;
        public LevelPresenter( PresenterMain parent )
        {
            this.parent = parent;
        }

        public void Done( )
        {
            parent.Done();
        }

        public void Done( string id )
        {
            parent.Done(typeof(string), id);
        }
    }
}
