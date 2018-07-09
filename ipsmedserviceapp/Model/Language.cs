using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Language
    {
        public Language()
        {
            CopyRtranslateLangFromNavigation = new HashSet<CopyRtranslate>();
            CopyRtranslateLangToNavigation = new HashSet<CopyRtranslate>();
            LicenseBigR = new HashSet<LicenseBigR>();
        }

        public string CodeS { get; set; }
        public string Name { get; set; }
        public int? NameId { get; set; }
        public string NameSh3 { get; set; }
        public short? ShortChoise { get; set; }

        public ICollection<CopyRtranslate> CopyRtranslateLangFromNavigation { get; set; }
        public ICollection<CopyRtranslate> CopyRtranslateLangToNavigation { get; set; }
        public ICollection<LicenseBigR> LicenseBigR { get; set; }
    }
}
