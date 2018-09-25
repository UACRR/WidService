using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicenseAgreement : ILicenseAgreement
    {
        public LicenseAgreement()
        {
            BrRegItem = new ObservableListSource<BrRegItem>();
            Fixation = new ObservableListSource<Fixation>();
            LicenseAgrParam = new ObservableListSource<LicenseAgrParam>();
            MoneyPeriodLink = new ObservableListSource<MoneyPeriodLink>();
            PaidPeriod = new ObservableListSource<PaidPeriod>();
            licPlace = new ObservableListSource<licPlace>();
        }

        public int licId { get; set; }
        public int licCode { get; set; }
        public int? licType { get; set; }
        public int? custId { get; set; }
        public int? licStatus { get; set; }
        public int licClass { get; set; }
        public int agrId { get; set; }
        public int? licSize { get; set; }
        public int? licVersion { get; set; }
        public int? prolongVersion { get; set; }

        public AgreementMaster agr { get; set; }
        public Client cust { get; set; }
        public AgrLicenseType licCodeNavigation { get; set; }
        public AgreementStatus licStatusNavigation { get; set; }
        public LicenseType licTypeNavigation { get; set; }
        public LicenseBigR LicenseBigR { get; set; }
        public ObservableListSource<BrRegItem> BrRegItem { get; set; }
        public ObservableListSource<Fixation> Fixation { get; set; }
        public ObservableListSource<LicenseAgrParam> LicenseAgrParam { get; set; }
        public ObservableListSource<MoneyPeriodLink> MoneyPeriodLink { get; set; }
        public ObservableListSource<PaidPeriod> PaidPeriod { get; set; }
        public ObservableListSource<licPlace> licPlace { get; set; }
    }
}

