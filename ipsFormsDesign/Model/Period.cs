using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Period : IPeriod
    {
        public Period()
        {
            AgreementAddBr = new ObservableListSource<AgreementAddBr>();
            AgreementAddCommunity = new ObservableListSource<AgreementAddCommunity>();
            AgreementAddPartner = new ObservableListSource<AgreementAddPartner>();
            AgreementAddRh = new ObservableListSource<AgreementAddRh>();
            LicenseAgrParam = new ObservableListSource<LicenseAgrParam>();
            PaidPeriod = new ObservableListSource<PaidPeriod>();
            PeriodTr = new ObservableListSource<PeriodTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public string NameR { get; set; }

        public ObservableListSource<AgreementAddBr> AgreementAddBr { get; set; }
        public ObservableListSource<AgreementAddCommunity> AgreementAddCommunity { get; set; }
        public ObservableListSource<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ObservableListSource<AgreementAddRh> AgreementAddRh { get; set; }
        public ObservableListSource<LicenseAgrParam> LicenseAgrParam { get; set; }
        public ObservableListSource<PaidPeriod> PaidPeriod { get; set; }
        public ObservableListSource<PeriodTr> PeriodTr { get; set; }
    }
}

