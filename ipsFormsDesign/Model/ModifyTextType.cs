using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ModifyTextType : IModifyTextType
    {
        public ModifyTextType()
        {
            ModifyTextTypeTr = new ObservableListSource<ModifyTextTypeTr>();
            RequestAdapt = new ObservableListSource<RequestAdapt>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public int? kindCompCode { get; set; }
        public int categoryCode { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public KindComposition kindCompCodeNavigation { get; set; }
        public ObservableListSource<ModifyTextTypeTr> ModifyTextTypeTr { get; set; }
        public ObservableListSource<RequestAdapt> RequestAdapt { get; set; }
    }
}

