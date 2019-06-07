using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class KindComposition
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

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual ICollection<KindCompositionTr> KindCompositionTr { get; set; }
        public virtual ICollection<ModifyMusicType> ModifyMusicType { get; set; }
        public virtual ICollection<ModifyTextType> ModifyTextType { get; set; }
        public virtual ICollection<ModifyType> ModifyType { get; set; }
        public virtual ICollection<Request> Request { get; set; }
    }
}
