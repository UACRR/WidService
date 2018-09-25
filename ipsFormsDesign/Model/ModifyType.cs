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

        public int codeI { get; set; }
        public string name { get; set; }
        public int? kindCompCode { get; set; }
        public int categoryCode { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public KindComposition kindCompCodeNavigation { get; set; }
        public ObservableListSource<ModifyTypeTr> ModifyTypeTr { get; set; }
        public ObservableListSource<RequestAdapt> RequestAdapt { get; set; }
    }
}

