using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Register : IRegister
    {
        public Register()
        {
            BrRegister = new HashSet<BrRegister>();
            Distribution = new HashSet<Distribution>();
            RegisterItem = new HashSet<RegisterItem>();
        }

        public int RegId { get; set; }
        public int? CustId { get; set; }
        public int? CountRows { get; set; }
        public string Login { get; set; }
        public int? RgStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? PeriodId { get; set; }
        public string UserId { get; set; }
        public string FileName { get; set; }
        public int? LicId { get; set; }
        public TimeSpan? DurationItems { get; set; }

        public Customer Cust { get; set; }
        public PaidPeriod Period { get; set; }
        public RegisterStatus RgStatusNavigation { get; set; }
        public AspNetUsers User { get; set; }
        public ICollection<BrRegister> BrRegister { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
        public ICollection<RegisterItem> RegisterItem { get; set; }
    }
}

