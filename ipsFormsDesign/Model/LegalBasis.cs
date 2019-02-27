using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LegalBasis : ILegalBasis
    {
        public LegalBasis()
        {
            LegalBasisTr = new ObservableListSource<LegalBasisTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<LegalBasisTr> LegalBasisTr { get; set; }
    }
}

