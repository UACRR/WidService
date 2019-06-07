using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementType
    {
        public AgreementType()
        {
            AgreementMaster = new HashSet<AgreementMaster>();
            AgreementTypeTr = new HashSet<AgreementTypeTr>();
            RelDocAgrType = new HashSet<RelDocAgrType>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public string TemplateName { get; set; }

        public virtual ICollection<AgreementMaster> AgreementMaster { get; set; }
        public virtual ICollection<AgreementTypeTr> AgreementTypeTr { get; set; }
        public virtual ICollection<RelDocAgrType> RelDocAgrType { get; set; }
    }
}
