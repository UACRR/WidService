using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LegalBasis
    {
        public LegalBasis()
        {
            LegalBasisTr = new HashSet<LegalBasisTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LegalBasisTr> LegalBasisTr { get; set; }
    }
}
