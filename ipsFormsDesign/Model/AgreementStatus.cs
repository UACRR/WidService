using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementStatus : IAgreementStatus
    {
        public AgreementStatus()
        {
            AgreementMaster = new HashSet<AgreementMaster>();
            AgreementStatusTr = new HashSet<AgreementStatusTr>();
            AtreementStatusTr = new HashSet<AtreementStatusTr>();
            LicenseAgreement = new HashSet<LicenseAgreement>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<AgreementMaster> AgreementMaster { get; set; }
        public ICollection<AgreementStatusTr> AgreementStatusTr { get; set; }
        public ICollection<AtreementStatusTr> AtreementStatusTr { get; set; }
        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
    }
}

