using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ModifyTextType : IModifyTextType
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

        public Category CategoryCodeNavigation { get; set; }
        public KindComposition KindCompCodeNavigation { get; set; }
        public ICollection<ModifyTextTypeTr> ModifyTextTypeTr { get; set; }
        public ICollection<RequestAdapt> RequestAdapt { get; set; }
    }
}

