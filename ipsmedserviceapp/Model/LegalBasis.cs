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

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<LegalBasisTr> LegalBasisTr { get; set; }
    }
}
