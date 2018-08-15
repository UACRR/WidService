using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicAuthorBr : ILicAuthorBr
    {
        public int CRightId { get; set; }
        public int? PrepayType { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateClose { get; set; }
        public DateTime? DateModify { get; set; }
        public DateTime? DateAccept { get; set; }
        public decimal? Rate { get; set; }
        public decimal? PrepaySum { get; set; }
        public decimal? PrepaySumAuthor { get; set; }
        public string R030 { get; set; }
        public DateTime? PrepayDateDo { get; set; }
        public decimal? PrepayRest { get; set; }
        public decimal? PrepayUsed { get; set; }

        public CopyRight CRight { get; set; }
        public PrePayType PrepayTypeNavigation { get; set; }
    }
}

