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

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? KindCompCode { get; set; }
        public int CategoryCode { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual KindComposition KindCompCodeNavigation { get; set; }
        public virtual ICollection<ModifyTextTypeTr> ModifyTextTypeTr { get; set; }
        public virtual ICollection<RequestAdapt> RequestAdapt { get; set; }
    }
}
