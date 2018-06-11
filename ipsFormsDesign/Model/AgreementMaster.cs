using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgreementMaster : IAgreementMaster
    {
        public AgreementMaster()
        {
            AgreementAddBr = new HashSet<AgreementAddBr>();
            AgreementAddPartner = new HashSet<AgreementAddPartner>();
            AgreementAddRh = new HashSet<AgreementAddRh>();
            LicenseAgreement = new HashSet<LicenseAgreement>();
        }

        public int AgrId { get; set; }
        public int CustId { get; set; }
        public int? AgrStatus { get; set; }
        public string AgrNumber { get; set; }
        public DateTime? AgrDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public int? AgrType { get; set; }
        public int? Version { get; set; }

        public AgreementStatus AgrStatusNavigation { get; set; }
        public AgreementType AgrTypeNavigation { get; set; }
        public Customer Cust { get; set; }
        public ICollection<AgreementAddBr> AgreementAddBr { get; set; }
        public ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
    }
}

