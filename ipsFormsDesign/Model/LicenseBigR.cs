using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicenseBigR : ILicenseBigR
    {
        public LicenseBigR()
        {
            LicAuthorBr = new ObservableListSource<LicAuthorBr>();
            MusicalDesign = new ObservableListSource<MusicalDesign>();
        }

        public int LicId { get; set; }
        public DateTime? DatePremiere { get; set; }
        public int? ObjId { get; set; }
        public decimal? FillingRate { get; set; }
        public int? PerformNumb { get; set; }
        public decimal? TicketPriceNc { get; set; }
        public decimal? TicketPriceUsd { get; set; }
        public bool? IsTour { get; set; }
        public string WhereTour { get; set; }
        public decimal? Rate { get; set; }
        public decimal? PrepayRest { get; set; }
        public string LangCode { get; set; }
        public int? PerformType { get; set; }
        public short? LicTerm { get; set; }
        public decimal? RateMusic { get; set; }
        public int LicVersion { get; set; }

        public virtual Language LangCodeNavigation { get; set; }
        public virtual LicenseAgrParam Lic { get; set; }
        public virtual ObjectRight Obj { get; set; }
        public virtual PerformType PerformTypeNavigation { get; set; }
        public virtual ObservableListSource<LicAuthorBr> LicAuthorBr { get; set; }
        public virtual ObservableListSource<MusicalDesign> MusicalDesign { get; set; }
    }
}

