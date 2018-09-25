using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicenseBigR : ILicenseBigR
    {
        public LicenseBigR()
        {
            MusicalDesign = new ObservableListSource<MusicalDesign>();
        }

        public int licId { get; set; }
        public DateTime? datePremiere { get; set; }
        public int? objId { get; set; }
        public decimal? fillingRate { get; set; }
        public int? performNumb { get; set; }
        public decimal? ticketPriceNC { get; set; }
        public decimal? ticketPriceUSD { get; set; }
        public bool? isTour { get; set; }
        public string whereTour { get; set; }
        public decimal? rate { get; set; }
        public decimal? prepayRest { get; set; }
        public string langCode { get; set; }
        public int? performType { get; set; }
        public short? licTerm { get; set; }
        public decimal? rateMusic { get; set; }

        public Language langCodeNavigation { get; set; }
        public LicenseAgreement lic { get; set; }
        public ObjectRight obj { get; set; }
        public PerformType performTypeNavigation { get; set; }
        public ObservableListSource<MusicalDesign> MusicalDesign { get; set; }
    }
}

