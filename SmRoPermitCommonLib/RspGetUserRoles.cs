using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmRoPermitCommonLib
{
    public class RspGetUserRoles : Response
    {
        public List<Role> Result { get; set; }
    }
}
