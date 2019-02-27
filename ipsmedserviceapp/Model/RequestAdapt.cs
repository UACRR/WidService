using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestAdapt
    {
        public RequestAdapt()
        {
            RelAdaptUseArea = new HashSet<RelAdaptUseArea>();
            RelGenreAdapt = new HashSet<RelGenreAdapt>();
        }

        public int ReqId { get; set; }
        public string ExecNick { get; set; }
        public int? ModifyType { get; set; }
        public int? ModifyTextType { get; set; }
        public string ModifyTextComment { get; set; }
        public int? ModifyMusicType { get; set; }
        public string ModifyMusictComment { get; set; }
        public string UseAreaComment { get; set; }

        public virtual ModifyMusicType ModifyMusicTypeNavigation { get; set; }
        public virtual ModifyTextType ModifyTextTypeNavigation { get; set; }
        public virtual ModifyType ModifyTypeNavigation { get; set; }
        public virtual Request Req { get; set; }
        public virtual ICollection<RelAdaptUseArea> RelAdaptUseArea { get; set; }
        public virtual ICollection<RelGenreAdapt> RelGenreAdapt { get; set; }
    }
}
