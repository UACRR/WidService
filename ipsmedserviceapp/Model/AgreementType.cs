using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementType
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
