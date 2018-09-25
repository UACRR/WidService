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

        public int ReqId { get; set; }
        public string ExecNick { get; set; }
        public int? ModifyType { get; set; }
        public int? ModifyTextType { get; set; }
        public string ModifyTextComment { get; set; }
        public int? ModifyMusicType { get; set; }
        public string ModifyMusictComment { get; set; }
        public string UseAreaComment { get; set; }

        public ModifyMusicType ModifyMusicTypeNavigation { get; set; }
        public ModifyTextType ModifyTextTypeNavigation { get; set; }
        public ModifyType ModifyTypeNavigation { get; set; }
        public Request Req { get; set; }
        public ObservableListSource<RelAdaptUseArea> RelAdaptUseArea { get; set; }
        public ObservableListSource<RelGenreAdapt> RelGenreAdapt { get; set; }
    }
}

