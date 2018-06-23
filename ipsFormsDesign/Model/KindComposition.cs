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

        public Category CategoryCodeNavigation { get; set; }
        public ObservableListSource<KindCompositionTr> KindCompositionTr { get; set; }
        public ObservableListSource<ModifyMusicType> ModifyMusicType { get; set; }
        public ObservableListSource<ModifyTextType> ModifyTextType { get; set; }
        public ObservableListSource<ModifyType> ModifyType { get; set; }
        public ObservableListSource<Request> Request { get; set; }
    }
}

