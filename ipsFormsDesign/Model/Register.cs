using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Register
    {
        public Register()
        {
            Distribution = new HashSet<Distribution>();
            RegisterItem = new HashSet<RegisterItem>();
        }

        public int RegId { get; set; }
        public int? CustId { get; set; }
        public int? CountRows { get; set; }
        public double? DurationItems { get; set; }
        public string Login { get; set; }
        public int? RgStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? PeriodId { get; set; }
        public string UserId { get; set; }
        public string FileName { get; set; }
        public decimal? FullAmount { get; set; }
        public decimal? FullRate { get; set; }
        public int? NumTiket { get; set; }

        public Customer Cust { get; set; }
        public RegisterStatus RgStatusNavigation { get; set; }
        public AspNetUsers User { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
        public ICollection<RegisterItem> RegisterItem { get; set; }
    }
}
