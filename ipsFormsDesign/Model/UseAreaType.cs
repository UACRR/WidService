using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UseAreaType : IUseAreaType
    {
        public UseAreaType()
        {
            RelAdaptUseArea = new HashSet<RelAdaptUseArea>();
            UseAreaTypeTr = new HashSet<UseAreaTypeTr>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public int ReqType { get; set; }
        public string Name { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public RequestType ReqTypeNavigation { get; set; }
        public ICollection<RelAdaptUseArea> RelAdaptUseArea { get; set; }
        public ICollection<UseAreaTypeTr> UseAreaTypeTr { get; set; }
    }
}

