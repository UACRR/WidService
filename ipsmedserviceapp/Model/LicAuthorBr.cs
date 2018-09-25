using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicAuthorBR
    {
        public int cRightId { get; set; }
        public int? prepayType { get; set; }
        public DateTime? dateCreate { get; set; }
        public DateTime? dateClose { get; set; }
        public DateTime? dateModify { get; set; }
        public DateTime? dateAccept { get; set; }
        public decimal? rate { get; set; }
        public decimal? prepaySum { get; set; }
        public decimal? prepaySumAuthor { get; set; }
        public string r030 { get; set; }
        public DateTime? prepayDateDo { get; set; }
        public decimal? prepayRest { get; set; }
        public decimal? prepayUsed { get; set; }

        [JsonIgnore]
        public CopyRight cRight { get; set; }
        [JsonIgnore]
        public PrePayType prepayTypeNavigation { get; set; }
    }
}

