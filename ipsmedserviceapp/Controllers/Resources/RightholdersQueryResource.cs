using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Controllers.Resources
{
    public class RightholdersQueryResource
    {
        public string SearchText { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
