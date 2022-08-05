using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmRoPermitCommonLib
{
    public class RspGetUserPermissions : Response
    {
        public List<UserPermission> UserParmissions { get; set; }
    }
}
