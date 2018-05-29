using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class KindComposition : IKindComposition
    {
        public KindComposition()
        {
            KindCompositionTr = new HashSet<KindCompositionTr>();
            ModifyMusicType = new HashSet<ModifyMusicType>();
            ModifyTextType = new HashSet<ModifyTextType>();
            ModifyType = new HashSet<ModifyType>();
            Request = new HashSet<Request>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int CategoryCode { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<KindCompositionTr> KindCompositionTr { get; set; }
        public ICollection<ModifyMusicType> ModifyMusicType { get; set; }
        public ICollection<ModifyTextType> ModifyTextType { get; set; }
        public ICollection<ModifyType> ModifyType { get; set; }
        public ICollection<Request> Request { get; set; }
    }
}

