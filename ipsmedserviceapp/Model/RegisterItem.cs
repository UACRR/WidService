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
            RegisterExtra = new HashSet<RegisterExtra>();
        }

        public int RegId { get; set; }
        public int RegIitemId { get; set; }
        public int? ObjId { get; set; }
        public int CodeItem { get; set; }
        public string ItemName { get; set; }
        public int? CategoryCode { get; set; }
        public string Performer { get; set; }
        public string AuthorMusic { get; set; }
        public string AuthorText { get; set; }
        public TimeSpan? DurationUse { get; set; }
        public int? CountUse { get; set; }
        public TimeSpan? DurationItem { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public int? Durationticks { get; set; }
        public int Ticks { get; set; }
        public bool IsAuto { get; set; }
        public int? GenreType { get; set; }

        [JsonIgnore]
        public virtual RegisterItemType CodeItemNavigation { get; set; }
        [JsonIgnore]
        public virtual GenreType GenreTypeNavigation { get; set; }
        public virtual ObjectRight Obj { get; set; }
        [JsonIgnore]
        public virtual Register Reg { get; set; }
        public virtual RegisterItemFix RegisterItemFix { get; set; }
        public virtual ICollection<RegisterCount> RegisterCount { get; set; }
        public virtual ICollection<RegisterExtra> RegisterExtra { get; set; }
    }
}

