using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaCompany
    {
        public int CustId { get; set; }
        public int Version { get; set; }
        public int? ActivityCode { get; set; }
        public int? IsCurrent { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string FaAddress { get; set; }
        public string JaAddress { get; set; }
        public string Okpo { get; set; }
        public DateTime? RegistrDate { get; set; }
        public int? TypeVat { get; set; }
        public string NumberVat { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public string JaCity { get; set; }
        public string FaCity { get; set; }
        public string JaCountry { get; set; }
        public string FaCountry { get; set; }
        public int? BanAccId { get; set; }
        public int? JaRegion { get; set; }
        public int? FaRegion { get; set; }

        public ActivityType ActivityCodeNavigation { get; set; }
        public BankAccount BanAcc { get; set; }
        [JsonIgnore]
        public Company Cust { get; set; }
        [JsonIgnore]
        public Customer CustNavigation { get; set; }
        [JsonIgnore]
        public Country FaCountryNavigation { get; set; }
        [JsonIgnore]
        public Region FaRegionNavigation { get; set; }
        [JsonIgnore]
        public Country JaCountryNavigation { get; set; }
        [JsonIgnore]
        public Region JaRegionNavigation { get; set; }
        [JsonIgnore]
        public AnketaStatus StatusNavigation { get; set; }
        [JsonIgnore]
        public TypeVat TypeVatNavigation { get; set; }
    }
}
