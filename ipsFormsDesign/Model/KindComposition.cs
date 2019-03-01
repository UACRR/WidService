using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class KindComposition : IKindComposition
    {
        public KindComposition()
        {
            KindCompositionTr = new ObservableListSource<KindCompositionTr>();
            ModifyMusicType = new ObservableListSource<ModifyMusicType>();
            ModifyTextType = new ObservableListSource<ModifyTextType>();
            ModifyType = new ObservableListSource<ModifyType>();
            Request = new ObservableListSource<Request>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int CategoryCode { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual ObservableListSource<KindCompositionTr> KindCompositionTr { get; set; }
        public virtual ObservableListSource<ModifyMusicType> ModifyMusicType { get; set; }
        public virtual ObservableListSource<ModifyTextType> ModifyTextType { get; set; }
        public virtual ObservableListSource<ModifyType> ModifyType { get; set; }
        public virtual ObservableListSource<Request> Request { get; set; }
    }
}

