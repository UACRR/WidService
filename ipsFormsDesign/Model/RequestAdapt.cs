using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestAdapt : IRequestAdapt
    {
        public RequestAdapt()
        {
            RelAdaptUseArea = new ObservableListSource<RelAdaptUseArea>();
            RelGenreAdapt = new ObservableListSource<RelGenreAdapt>();
        }

        public int reqId { get; set; }
        public string execNick { get; set; }
        public int? modifyType { get; set; }
        public int? modifyTextType { get; set; }
        public string modifyTextComment { get; set; }
        public int? modifyMusicType { get; set; }
        public string modifyMusictComment { get; set; }
        public string useAreaComment { get; set; }

        public ModifyMusicType modifyMusicTypeNavigation { get; set; }
        public ModifyTextType modifyTextTypeNavigation { get; set; }
        public ModifyType modifyTypeNavigation { get; set; }
        public Request req { get; set; }
        public ObservableListSource<RelAdaptUseArea> RelAdaptUseArea { get; set; }
        public ObservableListSource<RelGenreAdapt> RelGenreAdapt { get; set; }
    }
}

