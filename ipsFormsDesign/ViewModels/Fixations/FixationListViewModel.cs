using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string StatusName { get; set; }
        public string Responsible { get; set; }
        public DateTime? FixationDate { get; set; }
        public double RewardAmount { get; set; }
        public double CourtFeeAmount { get; set; }
        public double IncomeFeeAmount { get; set; }
    }
}
