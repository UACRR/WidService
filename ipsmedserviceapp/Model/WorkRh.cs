using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class WorkRH
    {
        public int cRightId { get; set; }
        public int? workTypeRH { get; set; }
        public string workCommentRH { get; set; }
        public DateTime? workDateRH { get; set; }
        public int? workTypeCl { get; set; }
        public DateTime? workDateCl { get; set; }
        public string workCoommentCl { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }

        [JsonIgnore]
        public CopyRight cRight { get; set; }
        [JsonIgnore]
        public WorkType workTypeClNavigation { get; set; }
        [JsonIgnore]
        public WorkType workTypeRHNavigation { get; set; }
    }
}

