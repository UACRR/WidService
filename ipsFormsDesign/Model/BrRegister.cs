using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class BrRegister : IBrRegister
    {
        public BrRegister()
        {
            BrRegItem = new HashSet<BrRegItem>();
            Distribution = new HashSet<Distribution>();
        }

        public int RegId { get; set; }
        public int? PeriodId { get; set; }
        public int? CustId { get; set; }
        public int? ReqIdSr { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? FullAmount { get; set; }
        public decimal? RAmount { get; set; }
        public int? Status { get; set; }
        public string FileName { get; set; }
        public string UserId { get; set; }

        public Client Cust { get; set; }
        public PaidPeriod Period { get; set; }
        public Register ReqIdSrNavigation { get; set; }
        public RegisterStatus StatusNavigation { get; set; }
        public ICollection<BrRegItem> BrRegItem { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
    }
}

