using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Fixation
    {
        public Fixation()
        {
            FixFile = new HashSet<FixFile>();
            FixStorageDevice = new HashSet<FixStorageDevice>();
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

        public Client ClientCust { get; set; }
        public LicenseAgreement Lic { get; set; }
        public Partner PartnerCust { get; set; }
        public FixStageStatus StageStatusNavigation { get; set; }
        public AspNetUsers User { get; set; }
        public UsesType UsesTypeNavigation { get; set; }
        public ICollection<FixFile> FixFile { get; set; }
        public ICollection<FixStorageDevice> FixStorageDevice { get; set; }
    }
}
