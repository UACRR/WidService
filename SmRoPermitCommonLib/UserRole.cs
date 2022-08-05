using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmRoPermitCommonLib
{
    public class UserRole
    {
        public int UserCode { get; set; }
        public int RoleCode { get; set; }
        public bool IsRead { get; set; }
        public bool IsWrite { get; set; }
    }
}
