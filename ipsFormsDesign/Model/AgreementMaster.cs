using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgreementMaster : IAgreementMaster
    {
        public AgreementMaster()
        {
            AgreementAddBr = new ObservableListSource<AgreementAddBr>();
            AgreementAddPartner = new ObservableListSource<AgreementAddPartner>();
            AgreementAddRh = new ObservableListSource<AgreementAddRh>();
            LicenseAgreement = new ObservableListSource<LicenseAgreement>();
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
        public ObservableListSource<AgreementAddBr> AgreementAddBr { get; set; }
        public ObservableListSource<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ObservableListSource<AgreementAddRh> AgreementAddRh { get; set; }
        public ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
    }
}

