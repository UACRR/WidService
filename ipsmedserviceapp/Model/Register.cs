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
        public int? RmId { get; set; }
        public string Number { get; set; }
        public int CountRows { get; set; }
        public int CustId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int Durationticks { get; set; }
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
        public int? SchemaId { get; set; }
        public int? AlgorithmId { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyLogin { get; set; }

        [JsonIgnore]
        public virtual AlgorithmType Algorithm { get; set; }
        [JsonIgnore]
        public virtual Client Cust { get; set; }
        [JsonIgnore]
        public virtual RegisterStatus RgStatusNavigation { get; set; }
        [JsonIgnore]
        public virtual RegisterRatedList Rm { get; set; }
        [JsonIgnore]
        public virtual RegisterCcid RegisterCcid { get; set; }
        [JsonIgnore]
        public virtual ICollection<BrRegItem> BrRegItem { get; set; }
        public virtual ICollection<Distribution> Distribution { get; set; }
        public virtual ICollection<RegisterItem> RegisterItem { get; set; }
    }
}




