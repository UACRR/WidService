using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PrePayType
    {
        public PrePayType()
        {
            LicAuthorBR = new HashSet<LicAuthorBR>();
            PrePayTypeTr = new HashSet<PrePayTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<LicAuthorBR> LicAuthorBR { get; set; }
        public ICollection<PrePayTypeTr> PrePayTypeTr { get; set; }
    }
}
