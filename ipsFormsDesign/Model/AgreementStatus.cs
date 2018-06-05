using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgreementStatus : IAgreementStatus
    {
        public AgreementStatus()
        {
            AgreementAddBr = new HashSet<AgreementAddBr>();
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
        public ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        public ICollection<AgreementMaster> AgreementMaster { get; set; }
        public ICollection<AgreementStatusTr> AgreementStatusTr { get; set; }
        public ICollection<LicenseAgrParam> LicenseAgrParam { get; set; }
        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
    }
}

