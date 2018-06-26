using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PrePayType
    {
        public PrePayType()
        {
            LicAuthorBr = new HashSet<LicAuthorBr>();
            PrePayTypeTr = new HashSet<PrePayTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<LicAuthorBr> LicAuthorBr { get; set; }
        public ICollection<PrePayTypeTr> PrePayTypeTr { get; set; }
    }
}
