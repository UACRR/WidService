using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ModifyType : IModifyType
    {
        public ModifyType()
        {
            RequestAdapt = new HashSet<RequestAdapt>();
        }

        public int ModifyTypeCode { get; set; }
        public string ModifyTypeNameUk { get; set; }
        public string ModifyTypeNameRu { get; set; }
        public string ModifyTypeNameEn { get; set; }
        public int? KindCompCode { get; set; }
        public int CategoryCode { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public KindComposition KindCompCodeNavigation { get; set; }
        public ICollection<RequestAdapt> RequestAdapt { get; set; }
    }
}

