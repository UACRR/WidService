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

        public int codeI { get; set; }
        public int reqType { get; set; }
        public string name { get; set; }
        public int categoryCode { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public RequestType reqTypeNavigation { get; set; }
        public ObservableListSource<RelReqMedia> RelReqMedia { get; set; }
        public ObservableListSource<UseMediaTypeTr> UseMediaTypeTr { get; set; }
    }
}

