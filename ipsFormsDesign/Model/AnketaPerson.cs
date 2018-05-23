using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaPerson : IAnketaPerson
    {
        public int CustId { get; set; }
        public int Version { get; set; }
        public int? IsCurrent { get; set; }
        public int Status { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public string NikName { get; set; }
        public int? Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneMobileMain { get; set; }
        public string PhoneMobileExtra { get; set; }
        public string PhoneHome { get; set; }
        public string EMail { get; set; }
        public string Citizenship { get; set; }
        public int? Residency { get; set; }
        public string ReCountry { get; set; }
        public string ReAddress { get; set; }
        public string Inn { get; set; }
        public string PUseries { get; set; }
        public string PUnumber { get; set; }
        public string PUissuedWho { get; set; }
        public DateTime? PUissuedWhen { get; set; }
        public string PFseries { get; set; }
        public string PFnumber { get; set; }
        public DateTime? PFissuedDate { get; set; }
        public DateTime? PFvalidity { get; set; }
        public string BuisNumberRegistration { get; set; }
        public DateTime? BuisDateRegistration { get; set; }
        public string BuisNumberPayer { get; set; }
        public string BuisSertNumberPayer { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public int? TypeVat { get; set; }
        public string ReCity { get; set; }
        public string FaCountry { get; set; }
        public string FaCity { get; set; }
        public string FaAddress { get; set; }
        public int? BanAccId { get; set; }
        public int? FaRegion { get; set; }
        public string Lang { get; set; }
        public int? ReRegion { get; set; }
        public string LeCountry { get; set; }
        public int? LeRegion { get; set; }
        public string LeCity { get; set; }
        public string LeAddress { get; set; }
        public string LePostIndex { get; set; }

        public BankAccount BanAcc { get; set; }
        [JsonIgnore]
        public Country CitizenshipNavigation { get; set; }
        [JsonIgnore]
        public Customer Cust { get; set; }
        [JsonIgnore]
        public Person CustNavigation { get; set; }
        [JsonIgnore]
        public Country FaCountryNavigation { get; set; }
        [JsonIgnore]
        public Region FaRegionNavigation { get; set; }
        [JsonIgnore]
        public Lang LangNavigation { get; set; }
        [JsonIgnore]
        public Region LeRegionNavigation { get; set; }
        [JsonIgnore]
        public Country ReCountryNavigation { get; set; }
        [JsonIgnore]
        public Region ReRegionNavigation { get; set; }
        [JsonIgnore]
        public ResidentType ResidencyNavigation { get; set; }
        [JsonIgnore]
        public SexType SexNavigation { get; set; }
        [JsonIgnore]
        public AnketaStatus StatusNavigation { get; set; }
        [JsonIgnore]
        public TypeVat TypeVatNavigation { get; set; }
    }
}





