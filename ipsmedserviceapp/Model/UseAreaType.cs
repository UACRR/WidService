using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UseAreaType
    {
        public UseAreaType()
        {
            RelAdaptUseArea = new HashSet<RelAdaptUseArea>();
            UseAreaTypeTr = new HashSet<UseAreaTypeTr>();
        }

        public int codeI { get; set; }
        public int categoryCode { get; set; }
        public int reqType { get; set; }
        public string name { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public RequestType reqTypeNavigation { get; set; }
        public ICollection<RelAdaptUseArea> RelAdaptUseArea { get; set; }
        public ICollection<UseAreaTypeTr> UseAreaTypeTr { get; set; }
    }
}
