using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementStatus
    {
        public AgreementStatus()
        {
            AgreementStatusTr = new HashSet<AgreementStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<AgreementStatusTr> AgreementStatusTr { get; set; }
    }
}
