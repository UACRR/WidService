using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Period : IPeriod
    {
        public Period()
        {
            AgreementAddBR = new ObservableListSource<AgreementAddBR>();
            AgreementAddPartner = new ObservableListSource<AgreementAddPartner>();
            AgreementAddRH = new ObservableListSource<AgreementAddRH>();
            LicenseAgrParam = new ObservableListSource<LicenseAgrParam>();
            PaidPeriod = new ObservableListSource<PaidPeriod>();
            PeriodTr = new ObservableListSource<PeriodTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public string nameR { get; set; }

        public ObservableListSource<AgreementAddBR> AgreementAddBR { get; set; }
        public ObservableListSource<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ObservableListSource<AgreementAddRH> AgreementAddRH { get; set; }
        public ObservableListSource<LicenseAgrParam> LicenseAgrParam { get; set; }
        public ObservableListSource<PaidPeriod> PaidPeriod { get; set; }
        public ObservableListSource<PeriodTr> PeriodTr { get; set; }
    }
}

