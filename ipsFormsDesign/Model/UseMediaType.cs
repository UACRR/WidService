using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class UseMediaType : IUseMediaType
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

        public Category CategoryCodeNavigation { get; set; }
        public RequestType ReqTypeNavigation { get; set; }
        public ICollection<RelReqMedia> RelReqMedia { get; set; }
        public ICollection<UseMediaTypeTr> UseMediaTypeTr { get; set; }
    }
}

