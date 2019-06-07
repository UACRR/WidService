using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaPerson
    {
        public int CustId { get; set; }
        public int Version { get; set; }
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

        public virtual BankAccount BanAcc { get; set; }
        public virtual Country CitizenshipNavigation { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual Person CustNavigation { get; set; }
        public virtual Country FaCountryNavigation { get; set; }
        public virtual Region FaRegionNavigation { get; set; }
        public virtual Lang LangNavigation { get; set; }
        public virtual Region LeRegionNavigation { get; set; }
        public virtual Country ReCountryNavigation { get; set; }
        public virtual Region ReRegionNavigation { get; set; }
        public virtual ResidentType ResidencyNavigation { get; set; }
        public virtual SexType SexNavigation { get; set; }
        public virtual AnketaStatus StatusNavigation { get; set; }
        public virtual TypeVat TypeVatNavigation { get; set; }
    }
}
