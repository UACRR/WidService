using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegisterItem
    {
        public RegisterItem()
        {
            RegisterCount = new HashSet<RegisterCount>();
        }

        public int RegId { get; set; }
        public int RegIitemId { get; set; }
        public int? ObjId { get; set; }
        public string ItemName { get; set; }
        public int? CategoryCode { get; set; }
        public string Performer { get; set; }
        public string AuthorMusic { get; set; }
        public string AuthorText { get; set; }
        public int? CountUse { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public TimeSpan? DurationUse { get; set; }
        public TimeSpan? DurationItem { get; set; }

        [JsonIgnore]
        public ObjectRight Obj { get; set; }
        [JsonIgnore]
        public Register Reg { get; set; }
        public ICollection<RegisterCount> RegisterCount { get; set; }
    }
}

