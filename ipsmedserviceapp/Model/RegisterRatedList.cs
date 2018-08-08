using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegisterRatedList
    {
        public RegisterRatedList()
        {
            Register = new HashSet<Register>();
        }

        public int PeriodId { get; set; }
        public int RmId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Royalty { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserId { get; set; }
        public int? Status { get; set; }
        public int? CntReport { get; set; }

        public PaidPeriod Period { get; set; }
        public RegisterListStatus StatusNavigation { get; set; }
        public ICollection<Register> Register { get; set; }
    }
}
