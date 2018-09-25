using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ModifyTextType
    {
        public ModifyTextType()
        {
            ModifyTextTypeTr = new HashSet<ModifyTextTypeTr>();
            RequestAdapt = new HashSet<RequestAdapt>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public int? kindCompCode { get; set; }
        public int categoryCode { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public KindComposition kindCompCodeNavigation { get; set; }
        public ICollection<ModifyTextTypeTr> ModifyTextTypeTr { get; set; }
        public ICollection<RequestAdapt> RequestAdapt { get; set; }
    }
}
