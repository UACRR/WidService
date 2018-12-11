using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RegisterItem : IRegisterItem
    {
        public RegisterItem()
        {
            RegisterCount = new ObservableListSource<RegisterCount>();
            RegisterExtra = new ObservableListSource<RegisterExtra>();
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
        public int? Ticks { get; set; }
        public bool IsAuto { get; set; }

        [JsonIgnore]
        public RegisterItemType CodeItemNavigation { get; set; }
        public ObjectRight Obj { get; set; }
        [JsonIgnore]
        public Register Reg { get; set; }
        public RegisterItemFix RegisterItemFix { get; set; }
        public ObservableListSource<RegisterCount> RegisterCount { get; set; }
        public ObservableListSource<RegisterExtra> RegisterExtra { get; set; }
    }
}


