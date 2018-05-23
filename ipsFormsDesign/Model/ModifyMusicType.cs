using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ModifyMusicType : IModifyMusicType
    {
        public ModifyMusicType()
        {
            RequestAdapt = new HashSet<RequestAdapt>();
        }

        public int ModifyMusicTypeCode { get; set; }
        public string ModifyMusicTypeNameUk { get; set; }
        public string ModifyMusicTypeNameRu { get; set; }
        public string ModifyMusicTypeNameEn { get; set; }
        public int? KindCompCode { get; set; }
        public int CategoryCode { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public KindComposition KindCompCodeNavigation { get; set; }
        public ICollection<RequestAdapt> RequestAdapt { get; set; }
    }
}

