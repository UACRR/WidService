using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicAuthorBr
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

        [JsonIgnore]
        public virtual CopyRight CRight { get; set; }
        [JsonIgnore]
        public virtual PrePayType PrepayTypeNavigation { get; set; }
    }
}


