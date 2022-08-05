using SmRoPermitCommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmRoPermitCommonLib
{
    public class RqChangePasswordAndLogin : Request
    {
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
