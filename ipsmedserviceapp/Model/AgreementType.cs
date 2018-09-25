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

        public int codeI { get; set; }
        public string name { get; set; }
        public string templateName { get; set; }

        public ICollection<AgreementMaster> AgreementMaster { get; set; }
        public ICollection<AgreementTypeTr> AgreementTypeTr { get; set; }
        public ICollection<RelDocAgrType> RelDocAgrType { get; set; }
    }
}
