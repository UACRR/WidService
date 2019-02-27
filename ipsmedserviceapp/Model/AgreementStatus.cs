using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementStatus
    {
        public AgreementStatus()
        {
            AgreementAddBr = new HashSet<AgreementAddBr>();
            AgreementAddCommunity = new HashSet<AgreementAddCommunity>();
            AgreementAddPartner = new HashSet<AgreementAddPartner>();
            AgreementAddRh = new HashSet<AgreementAddRh>();
            AgreementMaster = new HashSet<AgreementMaster>();
            AgreementStatusTr = new HashSet<AgreementStatusTr>();
            LicenseAgrParam = new HashSet<LicenseAgrParam>();
            LicenseAgreement = new HashSet<LicenseAgreement>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AgreementAddBr> AgreementAddBr { get; set; }
        public virtual ICollection<AgreementAddCommunity> AgreementAddCommunity { get; set; }
        public virtual ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        public virtual ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        public virtual ICollection<AgreementMaster> AgreementMaster { get; set; }
        public virtual ICollection<AgreementStatusTr> AgreementStatusTr { get; set; }
        public virtual ICollection<LicenseAgrParam> LicenseAgrParam { get; set; }
        public virtual ICollection<LicenseAgreement> LicenseAgreement { get; set; }
    }
}
