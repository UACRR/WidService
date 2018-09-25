using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CopyRtranslate
    {
        public int CRightId { get; set; }
        public int? RoleCode { get; set; }
        public string LangFrom { get; set; }
        public string LangTo { get; set; }

        public CopyRight CRight { get; set; }
        public Language LangFromNavigation { get; set; }
        public Language LangToNavigation { get; set; }
        public CreativeTranslate RoleCodeNavigation { get; set; }
    }
}
