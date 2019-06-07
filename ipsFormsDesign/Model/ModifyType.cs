using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ModifyType : IModifyType
    {
        public ModifyType()
        {
            ModifyTypeTr = new ObservableListSource<ModifyTypeTr>();
            RequestAdapt = new ObservableListSource<RequestAdapt>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? KindCompCode { get; set; }
        public int CategoryCode { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual KindComposition KindCompCodeNavigation { get; set; }
        public virtual ObservableListSource<ModifyTypeTr> ModifyTypeTr { get; set; }
        public virtual ObservableListSource<RequestAdapt> RequestAdapt { get; set; }
    }
}

