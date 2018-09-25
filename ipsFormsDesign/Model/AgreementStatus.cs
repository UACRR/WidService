using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgreementStatus : IAgreementStatus
    {
        public AgreementStatus()
        {
            AgreementAddBR = new ObservableListSource<AgreementAddBR>();
            AgreementAddPartner = new ObservableListSource<AgreementAddPartner>();
            AgreementAddRH = new ObservableListSource<AgreementAddRH>();
            AgreementMaster = new ObservableListSource<AgreementMaster>();
            AgreementStatusTr = new ObservableListSource<AgreementStatusTr>();
            LicenseAgrParam = new ObservableListSource<LicenseAgrParam>();
            LicenseAgreement = new ObservableListSource<LicenseAgreement>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<AgreementAddBR> AgreementAddBR { get; set; }
        public ObservableListSource<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ObservableListSource<AgreementAddRH> AgreementAddRH { get; set; }
        public ObservableListSource<AgreementMaster> AgreementMaster { get; set; }
        public ObservableListSource<AgreementStatusTr> AgreementStatusTr { get; set; }
        public ObservableListSource<LicenseAgrParam> LicenseAgrParam { get; set; }
        public ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
    }
}

