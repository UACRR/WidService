using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CopyRTranslate
    {
        public int cRightId { get; set; }
        public int? roleCode { get; set; }
        public string langFrom { get; set; }
        public string langTo { get; set; }

        public CopyRight cRight { get; set; }
        public Language langFromNavigation { get; set; }
        public Language langToNavigation { get; set; }
        public CreativeTranslate roleCodeNavigation { get; set; }
    }
}
