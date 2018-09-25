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

        public int codeI { get; set; }
        public string name { get; set; }
        public int categoryCode { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public ICollection<KindCompositionTr> KindCompositionTr { get; set; }
        public ICollection<ModifyMusicType> ModifyMusicType { get; set; }
        public ICollection<ModifyTextType> ModifyTextType { get; set; }
        public ICollection<ModifyType> ModifyType { get; set; }
        public ICollection<Request> Request { get; set; }
    }
}
