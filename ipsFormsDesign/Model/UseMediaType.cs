using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class UseMediaType : IUseMediaType
    {
        public UseMediaType()
        {
            RelReqMedia = new ObservableListSource<RelReqMedia>();
            UseMediaTypeTr = new ObservableListSource<UseMediaTypeTr>();
        }

        public int CodeI { get; set; }
        public int ReqType { get; set; }
        public string Name { get; set; }
        public int CategoryCode { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual RequestType ReqTypeNavigation { get; set; }
        public virtual ObservableListSource<RelReqMedia> RelReqMedia { get; set; }
        public virtual ObservableListSource<UseMediaTypeTr> UseMediaTypeTr { get; set; }
    }
}

