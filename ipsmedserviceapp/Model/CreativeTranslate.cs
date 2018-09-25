using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CreativeTranslate
    {
        public CreativeTranslate()
        {
            CopyRtranslate = new HashSet<CopyRtranslate>();
        }

        public int CodeI { get; set; }

        public CreativeRoleType CodeINavigation { get; set; }
        public ICollection<CopyRtranslate> CopyRtranslate { get; set; }
    }
}
