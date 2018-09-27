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

        public ICollection<AgreementAddBr> AgreementAddBr { get; set; }
        public ICollection<AgreementAddCommunity> AgreementAddCommunity { get; set; }
        public ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        public ICollection<AgreementMaster> AgreementMaster { get; set; }
        public ICollection<AgreementStatusTr> AgreementStatusTr { get; set; }
        public ICollection<LicenseAgrParam> LicenseAgrParam { get; set; }
        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
    }
}
