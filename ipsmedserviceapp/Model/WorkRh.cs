using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class WorkRh
    {
        public int CRightId { get; set; }
        public int? WorkTypeRh { get; set; }
        public string WorkCommentRh { get; set; }
        public DateTime? WorkDateRh { get; set; }
        public int? WorkTypeCl { get; set; }
        public DateTime? WorkDateCl { get; set; }
        public string WorkCoommentCl { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }

        [JsonIgnore]
        public virtual CopyRight CRight { get; set; }
        [JsonIgnore]
        public virtual WorkType WorkTypeClNavigation { get; set; }
        [JsonIgnore]
        public virtual WorkType WorkTypeRhNavigation { get; set; }
    }
}

