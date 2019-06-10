using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Fixation : IFixation
    {
        public Fixation()
        {
            FixFile = new ObservableListSource<FixFile>();
            FixStorageDevice = new ObservableListSource<FixStorageDevice>();
        }

        public int FixId { get; set; }
        public int? PartnerCustId { get; set; }
        public int StageStatus { get; set; }
        public int? ClientCustId { get; set; }
        public int? LicId { get; set; }
        public int? UsesType { get; set; }
        public string EventName { get; set; }
        public string EventDates { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Placement { get; set; }
        public int? CountPlace { get; set; }
        public decimal? TicketPriceMin { get; set; }
        public decimal? TicketPriceMax { get; set; }
        public DateTime? FixationDtBegin { get; set; }
        public DateTime? FixationDtEnd { get; set; }
        public decimal? RewardAmount { get; set; }
        public decimal? CourtFeeAmount { get; set; }
        public string UserId { get; set; }

        public virtual Client ClientCust { get; set; }
        public virtual LicenseAgreement Lic { get; set; }
        public virtual Partner PartnerCust { get; set; }
        public virtual FixStageStatus StageStatusNavigation { get; set; }
        public virtual UsesType UsesTypeNavigation { get; set; }
        public virtual ObservableListSource<FixFile> FixFile { get; set; }
        public virtual ObservableListSource<FixStorageDevice> FixStorageDevice { get; set; }
    }
}

