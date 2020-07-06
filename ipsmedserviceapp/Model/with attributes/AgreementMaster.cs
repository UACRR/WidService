using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementMaster
    {
        public AgreementMaster()
        {
            AgreementAddBr = new HashSet<AgreementAddBr>();
            AgreementAddCommunity = new HashSet<AgreementAddCommunity>();
            AgreementAddPartner = new HashSet<AgreementAddPartner>();
            AgreementAddRh = new HashSet<AgreementAddRh>();
            LicenseAgreement = new HashSet<LicenseAgreement>();
        }

        public int AgrId { get; set; }
        public int CustId { get; set; }
        public int? AgrStatus { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public int? AgrType { get; set; }
        public int? Version { get; set; }

        public virtual AgreementStatus AgrStatusNavigation { get; set; }
        public virtual AgreementType AgrTypeNavigation { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual ICollection<AgreementAddBr> AgreementAddBr { get; set; }
        public virtual ICollection<AgreementAddCommunity> AgreementAddCommunity { get; set; }
        public virtual ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        public virtual ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        public virtual ICollection<LicenseAgreement> LicenseAgreement { get; set; }
    }
}
