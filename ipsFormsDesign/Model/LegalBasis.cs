using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LegalBasis : ILegalBasis
    {
        public LegalBasis()
        {
            LegalBasisTr = new HashSet<LegalBasisTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<LegalBasisTr> LegalBasisTr { get; set; }
    }
}

