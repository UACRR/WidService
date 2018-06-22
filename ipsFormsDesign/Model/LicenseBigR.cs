using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicenseBigR : ILicenseBigR
    {
        public LicenseBigR()
        {
            LicAuthor = new ObservableListSource<LicAuthor>();
            MusicalDesign = new ObservableListSource<MusicalDesign>();
        }

        public int LicId { get; set; }
        public DateTime? DatePremiere { get; set; }
        public int? ObjId { get; set; }
        public decimal? FillingRate { get; set; }
        public int? PerfomNumb { get; set; }
        public decimal? TicketPriceNc { get; set; }
        public decimal? TicketPriceUsd { get; set; }
        public bool? IsTour { get; set; }
        public string WhereTour { get; set; }

        public LicenseAgreement Lic { get; set; }
        public ObjectRight Obj { get; set; }
        public ObservableListSource<LicAuthor> LicAuthor { get; set; }
        public ObservableListSource<MusicalDesign> MusicalDesign { get; set; }
    }
}

