using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Partner
    {
        public Partner()
        {
            AgreementAddPartner = new HashSet<AgreementAddPartner>();
            Distribution = new HashSet<Distribution>();
            Fixation = new HashSet<Fixation>();
            PartnerClient = new HashSet<PartnerClient>();
        }

        public int CustId { get; set; }
        public bool? IsMy { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        public virtual ICollection<Distribution> Distribution { get; set; }
        public virtual ICollection<Fixation> Fixation { get; set; }
        public virtual ICollection<PartnerClient> PartnerClient { get; set; }
    }
}
