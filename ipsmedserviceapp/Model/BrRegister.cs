using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class BrRegister
    {
        public BrRegister()
        {
            BrRegItem = new HashSet<BrRegItem>();
            Distribution = new HashSet<Distribution>();
        }

        public int RegId { get; set; }
        public int? PeriodId { get; set; }
        public int? CustId { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? FullAmount { get; set; }
        public decimal? RAmount { get; set; }
        public int? Status { get; set; }
        public string FileName { get; set; }
        public string UserId { get; set; }

        public virtual Client Cust { get; set; }
        public virtual PaidPeriod Period { get; set; }
        public virtual RegisterStatus StatusNavigation { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<BrRegItem> BrRegItem { get; set; }
        public virtual ICollection<Distribution> Distribution { get; set; }
    }
}
