using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmRoPermitCommonLib
{
    public class RspGetAllUsers : Response
    {
        public List<User> Result { get; set; }
    }
}
