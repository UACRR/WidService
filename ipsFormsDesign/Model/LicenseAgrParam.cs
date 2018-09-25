using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicenseAgrParam : ILicenseAgrParam
    {
        public LicenseAgrParam()
        {
            License = new ObservableListSource<License>();
        }

        public int licId { get; set; }
        public int licVersion { get; set; }
        public string licNum { get; set; }
        public DateTime? licDate { get; set; }
        public DateTime? dateBegin { get; set; }
        public DateTime? dateEnd { get; set; }
        public decimal? minAmount { get; set; }
        public decimal? rateAmount { get; set; }
        public bool? isAutoprolog { get; set; }
        public decimal? addRate { get; set; }
        public decimal? indxInfl { get; set; }
        public int? periodCode { get; set; }
        public int? dayForPay { get; set; }
        public int? licStatus { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }
        public int? ankVersion { get; set; }
        public string comment { get; set; }

        public LicenseAgreement lic { get; set; }
        public AgreementStatus licStatusNavigation { get; set; }
        public Period periodCodeNavigation { get; set; }
        public ObservableListSource<License> License { get; set; }
    }
}

