using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegisterItem
    {
        public RegisterItem()
        {
            RegisterExtra = new HashSet<RegisterExtra>();
        }

        public int regId { get; set; }
        public int regIItemId { get; set; }
        public int? objId { get; set; }
        public int codeItem { get; set; }
        public string ItemName { get; set; }
        public int? categoryCode { get; set; }
        public string performer { get; set; }
        public string authorMusic { get; set; }
        public string authorText { get; set; }
        public TimeSpan? durationUse { get; set; }
        public int? countUse { get; set; }
        public TimeSpan? durationItem { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }
        public int? durationticks { get; set; }
        public int? ticks { get; set; }
        public bool isAuto { get; set; }

        [JsonIgnore]
        public RegisterItemType codeItemNavigation { get; set; }
        [JsonIgnore]
        public ObjectRight obj { get; set; }
        [JsonIgnore]
        public Register reg { get; set; }
        public ICollection<RegisterExtra> RegisterExtra { get; set; }
    }
}

