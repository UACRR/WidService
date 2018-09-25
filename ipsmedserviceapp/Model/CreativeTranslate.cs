using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CreativeTranslate
    {
        public CreativeTranslate()
        {
            CopyRTranslate = new HashSet<CopyRTranslate>();
        }

        public int codeI { get; set; }

        public CreativeRoleType codeINavigation { get; set; }
        public ICollection<CopyRTranslate> CopyRTranslate { get; set; }
    }
}
