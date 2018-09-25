using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementStatus
    {
        public AgreementStatus()
        {
            AgreementAddBR = new HashSet<AgreementAddBR>();
            AgreementAddPartner = new HashSet<AgreementAddPartner>();
            AgreementAddRH = new HashSet<AgreementAddRH>();
            AgreementMaster = new HashSet<AgreementMaster>();
            AgreementStatusTr = new HashSet<AgreementStatusTr>();
            LicenseAgrParam = new HashSet<LicenseAgrParam>();
            LicenseAgreement = new HashSet<LicenseAgreement>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<AgreementAddBR> AgreementAddBR { get; set; }
        public ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ICollection<AgreementAddRH> AgreementAddRH { get; set; }
        public ICollection<AgreementMaster> AgreementMaster { get; set; }
        public ICollection<AgreementStatusTr> AgreementStatusTr { get; set; }
        public ICollection<LicenseAgrParam> LicenseAgrParam { get; set; }
        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
    }
}
