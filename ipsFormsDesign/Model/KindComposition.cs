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

        public int codeI { get; set; }
        public string name { get; set; }
        public int categoryCode { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public ObservableListSource<KindCompositionTr> KindCompositionTr { get; set; }
        public ObservableListSource<ModifyMusicType> ModifyMusicType { get; set; }
        public ObservableListSource<ModifyTextType> ModifyTextType { get; set; }
        public ObservableListSource<ModifyType> ModifyType { get; set; }
        public ObservableListSource<Request> Request { get; set; }
    }
}

