using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Authors
    {
        public int authId { get; set; }
        public int objId { get; set; }
        public int roleCode { get; set; }
        public int? custId { get; set; }
        public string authorName { get; set; }
        public int? isFolkOrUnknown { get; set; }
        public int? folkType { get; set; }

        public RightHolder cust { get; set; }
        public FolkType folkTypeNavigation { get; set; }
        public ObjectRight obj { get; set; }
        public CreativeRoleType roleCodeNavigation { get; set; }
    }
}
