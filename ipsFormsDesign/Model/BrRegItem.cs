using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class BrRegItem : IBrRegItem
    {
        public BrRegItem()
        {
            RegisterCount = new HashSet<RegisterCount>();
        }

        public int RegItemId { get; set; }
        public int RegId { get; set; }
        public int? ObjId { get; set; }
        public int? LicId { get; set; }
        public string ItemName { get; set; }
        public int? CategoryCode { get; set; }
        public int? CountUse { get; set; }
        public int? NumTicket { get; set; }
        public decimal? FullAmount { get; set; }
        public decimal? FullRate { get; set; }
        public decimal? RAmount { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public int? Status { get; set; }

        public LicenseAgreement Lic { get; set; }
        public ObjectRight Obj { get; set; }
        public BrRegister Reg { get; set; }
        public ItemStatus StatusNavigation { get; set; }
        public ICollection<RegisterCount> RegisterCount { get; set; }
    }
}

