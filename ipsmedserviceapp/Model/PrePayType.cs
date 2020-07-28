using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PrePayType
    {
        public PrePayType()
        {
            LicAuthorBr = new HashSet<LicAuthorBr>();
            MoneyPrepayLink = new HashSet<MoneyPrepayLink>();
            PrePayTypeTr = new HashSet<PrePayTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LicAuthorBr> LicAuthorBr { get; set; }
        public virtual ICollection<MoneyPrepayLink> MoneyPrepayLink { get; set; }
        public virtual ICollection<PrePayTypeTr> PrePayTypeTr { get; set; }
    }
}
