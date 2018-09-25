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

        public int regId { get; set; }
        public int rmId { get; set; }
        public string number { get; set; }
        public int countRows { get; set; }
        public int custId { get; set; }
        public DateTime? createDate { get; set; }
        public int durationticks { get; set; }
        public int? rgStatus { get; set; }
        public string fileName { get; set; }
        public string userId { get; set; }
        public int? periodId { get; set; }
        public decimal? regAmount { get; set; }
        public decimal? regRate { get; set; }
        public decimal? regRoyalty { get; set; }
        public decimal? musicAmount { get; set; }
        public decimal? musicRate { get; set; }
        public decimal? authAmount { get; set; }
        public decimal? authRate { get; set; }
        public decimal? paidAmount { get; set; }
        public int licId { get; set; }
        public int? schemaId { get; set; }
        public int? algorithmId { get; set; }

        [JsonIgnore]
        public AlgorithmType algorithm { get; set; }
        [JsonIgnore]
        public Client cust { get; set; }
        [JsonIgnore]
        public RegisterStatus rgStatusNavigation { get; set; }
        [JsonIgnore]
        public RegisterRatedList rm { get; set; }
        [JsonIgnore]
        public AspNetUsers user { get; set; }
        [JsonIgnore]
        public ICollection<BrRegItem> BrRegItem { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
        public ICollection<RegisterItem> RegisterItem { get; set; }
    }
}

