using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class KindComposition : IKindComposition
    {
        public KindComposition()
        {
            ModifyMusicType = new HashSet<ModifyMusicType>();
            ModifyTextType = new HashSet<ModifyTextType>();
            ModifyType = new HashSet<ModifyType>();
            Request = new HashSet<Request>();
        }

        public int KindCompCode { get; set; }
        public string KindCompNameUk { get; set; }
        public string KindCompNameRu { get; set; }
        public string KindCompNameEn { get; set; }
        public int CategoryCode { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<ModifyMusicType> ModifyMusicType { get; set; }
        public ICollection<ModifyTextType> ModifyTextType { get; set; }
        public ICollection<ModifyType> ModifyType { get; set; }
        public ICollection<Request> Request { get; set; }
    }
}

