using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UseMediaType
    {
        public UseMediaType()
        {
            RelReqMedia = new HashSet<RelReqMedia>();
            UseMediaTypeTr = new HashSet<UseMediaTypeTr>();
        }

        public int CodeI { get; set; }
        public int ReqType { get; set; }
        public string Name { get; set; }
        public int CategoryCode { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual RequestType ReqTypeNavigation { get; set; }
        public virtual ICollection<RelReqMedia> RelReqMedia { get; set; }
        public virtual ICollection<UseMediaTypeTr> UseMediaTypeTr { get; set; }
    }
}
