using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmRoPermitCommonLib
{
    public class RspAddUser : Response
    {
        public struct AddUserResult
        {
            public int CodeI { get; set; }
            public string Password { get; set; }
        }

        public AddUserResult Result { get; set; }
    }
}
