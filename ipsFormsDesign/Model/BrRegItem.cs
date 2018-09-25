using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class BrRegItem : IBrRegItem
    {
        public BrRegItem()
        {
            RegisterCount = new ObservableListSource<RegisterCount>();
        }

        public int regItemId { get; set; }
        public int regId { get; set; }
        public int? objId { get; set; }
        public int? licId { get; set; }
        public string ItemName { get; set; }
        public int? countUse { get; set; }
        public int? numTicket { get; set; }
        public decimal? fullAmount { get; set; }
        public decimal? fullRate { get; set; }
        public decimal? rAmount { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }
        public int? status { get; set; }
        public int? regIdSr { get; set; }
        public decimal? musicRate { get; set; }
        public decimal? musicAmount { get; set; }
        public int? categoryCode { get; set; }

        public LicenseAgreement lic { get; set; }
        public ObjectRight obj { get; set; }
        public BrRegister reg { get; set; }
        public Register regIdSrNavigation { get; set; }
        public ItemStatus statusNavigation { get; set; }
        public ObservableListSource<RegisterCount> RegisterCount { get; set; }
    }
}

