using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgreementType : IAgreementType
    {
        public AgreementType()
        {
            AgreementTypeTr = new HashSet<AgreementTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public string TemplateName { get; set; }

        public ICollection<AgreementTypeTr> AgreementTypeTr { get; set; }
    }
}

