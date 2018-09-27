using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgreementStatus : IAgreementStatus
    {
        public AgreementStatus()
        {
            AgreementAddBr = new ObservableListSource<AgreementAddBr>();
            AgreementAddCommunity = new ObservableListSource<AgreementAddCommunity>();
            AgreementAddPartner = new ObservableListSource<AgreementAddPartner>();
            AgreementAddRh = new ObservableListSource<AgreementAddRh>();
            AgreementMaster = new ObservableListSource<AgreementMaster>();
            AgreementStatusTr = new ObservableListSource<AgreementStatusTr>();
            LicenseAgrParam = new ObservableListSource<LicenseAgrParam>();
            LicenseAgreement = new ObservableListSource<LicenseAgreement>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<AgreementAddBr> AgreementAddBr { get; set; }
        public ObservableListSource<AgreementAddCommunity> AgreementAddCommunity { get; set; }
        public ObservableListSource<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ObservableListSource<AgreementAddRh> AgreementAddRh { get; set; }
        public ObservableListSource<AgreementMaster> AgreementMaster { get; set; }
        public ObservableListSource<AgreementStatusTr> AgreementStatusTr { get; set; }
        public ObservableListSource<LicenseAgrParam> LicenseAgrParam { get; set; }
        public ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
    }
}

