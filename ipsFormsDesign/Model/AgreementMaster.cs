using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
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

        [JsonIgnore]
        public AgreementStatus AgrStatusNavigation { get; set; }
        [JsonIgnore]
        public AgreementType AgrTypeNavigation { get; set; }
        [JsonIgnore]
        public Customer Cust { get; set; }
        public ObservableListSource<AgreementAddBr> AgreementAddBr { get; set; }
        [JsonIgnore]
        public ObservableListSource<AgreementAddCommunity> AgreementAddCommunity { get; set; }
        public ObservableListSource<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ObservableListSource<AgreementAddRh> AgreementAddRh { get; set; }
        [JsonIgnore]
        public ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
    }
}


