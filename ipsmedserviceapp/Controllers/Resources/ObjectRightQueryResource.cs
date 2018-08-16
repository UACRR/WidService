using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Controllers.Resources
{
    public class ObjectRightQueryResource
    {
        public int? State { get; set; }
        public int? Category { get; set; }
        public int? Genre { get; set; }
        public string SearchText { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
