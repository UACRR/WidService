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
            AgreementAddCommunity = new ObservableListSource<AgreementAddCommunity>();
            AgreementAddPartner = new ObservableListSource<AgreementAddPartner>();
            AgreementAddRh = new ObservableListSource<AgreementAddRh>();
            LicenseAgreement = new ObservableListSource<LicenseAgreement>();
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
        public virtual ObservableListSource<AgreementAddBr> AgreementAddBr { get; set; }
        public virtual ObservableListSource<AgreementAddCommunity> AgreementAddCommunity { get; set; }
        public virtual ObservableListSource<AgreementAddPartner> AgreementAddPartner { get; set; }
        public virtual ObservableListSource<AgreementAddRh> AgreementAddRh { get; set; }
        public virtual ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
    }
}

