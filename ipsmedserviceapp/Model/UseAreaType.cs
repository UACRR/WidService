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

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public int ReqType { get; set; }
        public string Name { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual RequestType ReqTypeNavigation { get; set; }
        public virtual ICollection<RelAdaptUseArea> RelAdaptUseArea { get; set; }
        public virtual ICollection<UseAreaTypeTr> UseAreaTypeTr { get; set; }
    }
}
