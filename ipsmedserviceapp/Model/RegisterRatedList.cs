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

        public int PeriodId { get; set; }
        public int RmId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Royalty { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserId { get; set; }
        public int? Status { get; set; }
        public int? CntReport { get; set; }
        public decimal? PaidAmount { get; set; }

        public virtual PaidPeriod Period { get; set; }
        public virtual RegisterListStatus StatusNavigation { get; set; }
        public virtual ICollection<Distribution> Distribution { get; set; }
        public virtual ICollection<Register> Register { get; set; }
    }
}
