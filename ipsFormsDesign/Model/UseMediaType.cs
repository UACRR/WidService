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

        public Category CategoryCodeNavigation { get; set; }
        public RequestType ReqTypeNavigation { get; set; }
        public ObservableListSource<RelReqMedia> RelReqMedia { get; set; }
        public ObservableListSource<UseMediaTypeTr> UseMediaTypeTr { get; set; }
    }
}

