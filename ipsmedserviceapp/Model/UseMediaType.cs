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

        public int codeI { get; set; }
        public int reqType { get; set; }
        public string name { get; set; }
        public int categoryCode { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public RequestType reqTypeNavigation { get; set; }
        public ICollection<RelReqMedia> RelReqMedia { get; set; }
        public ICollection<UseMediaTypeTr> UseMediaTypeTr { get; set; }
    }
}
