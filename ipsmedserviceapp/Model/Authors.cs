using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Authors
    {
        public int AuthId { get; set; }
        public int ObjId { get; set; }
        public int RoleCode { get; set; }
        public int? CustId { get; set; }
        public string AuthorName { get; set; }
        public int? IsFolkOrUnknown { get; set; }

        public RightHolder Cust { get; set; }
        public ObjectRight Obj { get; set; }
        public CreativeRoleType RoleCodeNavigation { get; set; }
    }
}
