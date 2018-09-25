using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Language
    {
        public Language()
        {
            CopyRTranslatelangFromNavigation = new HashSet<CopyRTranslate>();
            CopyRTranslatelangToNavigation = new HashSet<CopyRTranslate>();
            LicenseBigR = new HashSet<LicenseBigR>();
        }

        public string codeS { get; set; }
        public string name { get; set; }
        public int? nameId { get; set; }
        public string nameSh3 { get; set; }
        public short? shortChoise { get; set; }

        public ICollection<CopyRTranslate> CopyRTranslatelangFromNavigation { get; set; }
        public ICollection<CopyRTranslate> CopyRTranslatelangToNavigation { get; set; }
        public ICollection<LicenseBigR> LicenseBigR { get; set; }
    }
}
