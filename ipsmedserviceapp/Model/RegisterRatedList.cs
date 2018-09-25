using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegisterRatedList
    {
        public RegisterRatedList()
        {
            Distribution = new HashSet<Distribution>();
            Register = new HashSet<Register>();
        }

        public int periodId { get; set; }
        public int rmId { get; set; }
        public decimal? amount { get; set; }
        public decimal? royalty { get; set; }
        public DateTime? createDate { get; set; }
        public string userId { get; set; }
        public int? status { get; set; }
        public int? cntReport { get; set; }
        public decimal? paidAmount { get; set; }

        public PaidPeriod period { get; set; }
        public RegisterListStatus statusNavigation { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
        public ICollection<Register> Register { get; set; }
    }
}
