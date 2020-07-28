using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmRoPermitCommonLib
{
    public class RspLogin : Response
    {
        public enum LoginResult
        {
            Failed, Success, ChangePassword
        }

        public int UserCodeI { get; set; }
        public string Name { get; set; }
        public LoginResult Result { get; set; }
    }
}
