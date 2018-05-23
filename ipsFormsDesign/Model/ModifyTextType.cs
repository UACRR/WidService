using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ModifyTextType : IModifyTextType
    {
        public ModifyTextType()
        {
            RequestAdapt = new HashSet<RequestAdapt>();
        }

        public int ModifyTextTypeCode { get; set; }
        public string ModifyTextTypeNameUk { get; set; }
        public string ModifyTextTypeNameRu { get; set; }
        public string ModifyTextTypeNameEn { get; set; }
        public int? KindCompCode { get; set; }
        public int CategoryCode { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public KindComposition KindCompCodeNavigation { get; set; }
        public ICollection<RequestAdapt> RequestAdapt { get; set; }
    }
}

