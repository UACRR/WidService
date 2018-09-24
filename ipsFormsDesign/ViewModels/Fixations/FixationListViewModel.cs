using System;

namespace ipsFormsDesign.ViewModels.Fixations
{
    public class FixationListViewModel
    {
        public int FixId { get; set; }
        public int? UsesType { get; set; }
        public string EventName { get; set; }
        public string ClientName { get; set; }
        public string EventDates { get; set; }
        public string EventLocation { get; set; }
        public string StageName { get; set; }
        public string StatusName { get; set; }
        public string Responsible { get; set; }
        public DateTime? FixationDate { get; set; }
        public decimal? RewardAmount { get; set; }
        public decimal? CourtFeeAmount { get; set; }
        public decimal? IncomeAmount { get; set; }
    }
}
