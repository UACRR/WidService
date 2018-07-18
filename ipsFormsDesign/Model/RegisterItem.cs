using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RegisterItem : IRegisterItem
    {
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

        public RegisterItemType CodeItemNavigation { get; set; }
        public ObjectRight Obj { get; set; }
        public Register Reg { get; set; }
    }
}

