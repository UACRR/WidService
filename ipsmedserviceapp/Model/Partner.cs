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

        public int custId { get; set; }

        public Customer cust { get; set; }
        public ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
        public ICollection<Fixation> Fixation { get; set; }
        public ICollection<PartnerClient> PartnerClient { get; set; }
    }
}
