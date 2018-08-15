using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Register
    {
        public Register()
        {
            BrRegItem = new HashSet<BrRegItem>();
            Distribution = new HashSet<Distribution>();
            RegisterItem = new HashSet<RegisterItem>();
        }

        public int RegId { get; set; }
        public int RmId { get; set; }
        public string Number { get; set; }
        public int CountRows { get; set; }
        public int CustId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Durationticks { get; set; }
        public int? RgStatus { get; set; }
        public string FileName { get; set; }
        public string UserId { get; set; }
        public int? PeriodId { get; set; }
        public decimal? RegAmount { get; set; }
        public decimal? RegRate { get; set; }
        public decimal? RegRoyalty { get; set; }
        public decimal? MusicAmount { get; set; }
        public decimal? MusicRate { get; set; }
        public decimal? AuthAmount { get; set; }
        public decimal? AuthRate { get; set; }
        public decimal? PaidAmount { get; set; }
        public int? LicId { get; set; }

        [JsonIgnore]
        public Client Cust { get; set; }
        [JsonIgnore]
        public RegisterRatedList RegisterRatedList { get; set; }
        [JsonIgnore]
        public RegisterStatus RgStatusNavigation { get; set; }
        [JsonIgnore]
        public AspNetUsers User { get; set; }
        [JsonIgnore]
        public ICollection<BrRegItem> BrRegItem { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
        public ICollection<RegisterItem> RegisterItem { get; set; }
    }
}

