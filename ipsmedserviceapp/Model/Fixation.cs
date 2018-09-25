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

        public int fixId { get; set; }
        public int? partnerCustId { get; set; }
        public int stageStatus { get; set; }
        public int? clientCustId { get; set; }
        public int? licId { get; set; }
        public int? usesType { get; set; }
        public string eventName { get; set; }
        public string eventDates { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string placement { get; set; }
        public int? countPlace { get; set; }
        public decimal? ticketPriceMin { get; set; }
        public decimal? ticketPriceMax { get; set; }
        public DateTime? fixationDate { get; set; }
        public decimal? rewardAmount { get; set; }
        public decimal? courtFeeAmount { get; set; }
        public string clientName { get; set; }
        public string clientInnOkpo { get; set; }
        public string userId { get; set; }

        public Client clientCust { get; set; }
        public LicenseAgreement lic { get; set; }
        public Partner partnerCust { get; set; }
        public FixStageStatus stageStatusNavigation { get; set; }
        public AspNetUsers user { get; set; }
        public UsesType usesTypeNavigation { get; set; }
        public ICollection<FixFile> FixFile { get; set; }
        public ICollection<FixStorageDevice> FixStorageDevice { get; set; }
    }
}
