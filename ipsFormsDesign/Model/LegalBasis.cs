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

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<LegalBasisTr> LegalBasisTr { get; set; }
    }
}

