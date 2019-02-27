using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ModifyType
    {
        public ModifyType()
        {
            ModifyTypeTr = new HashSet<ModifyTypeTr>();
            RequestAdapt = new HashSet<RequestAdapt>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? KindCompCode { get; set; }
        public int CategoryCode { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual KindComposition KindCompCodeNavigation { get; set; }
        public virtual ICollection<ModifyTypeTr> ModifyTypeTr { get; set; }
        public virtual ICollection<RequestAdapt> RequestAdapt { get; set; }
    }
}
