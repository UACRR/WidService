using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgreementMaster : IAgreementMaster
    {
        public AgreementMaster()
        {
            AgreementAddBR = new ObservableListSource<AgreementAddBR>();
            AgreementAddPartner = new ObservableListSource<AgreementAddPartner>();
            AgreementAddRH = new ObservableListSource<AgreementAddRH>();
            LicenseAgreement = new ObservableListSource<LicenseAgreement>();
        }

        public int agrId { get; set; }
        public int custId { get; set; }
        public int? agrStatus { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }
        public int? agrType { get; set; }
        public int? version { get; set; }

        public AgreementStatus agrStatusNavigation { get; set; }
        public AgreementType agrTypeNavigation { get; set; }
        public Customer cust { get; set; }
        public ObservableListSource<AgreementAddBR> AgreementAddBR { get; set; }
        public ObservableListSource<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ObservableListSource<AgreementAddRH> AgreementAddRH { get; set; }
        public ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
    }
}

