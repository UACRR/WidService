using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaPerson
    {
        public int custId { get; set; }
        public int version { get; set; }
        public int status { get; set; }
        public string firstName { get; set; }
        public string surName { get; set; }
        public string lastName { get; set; }
        public string nikName { get; set; }
        public int? sex { get; set; }
        public DateTime? birthDate { get; set; }
        public string phoneMobileMain { get; set; }
        public string phoneMobileExtra { get; set; }
        public string phoneHome { get; set; }
        public string eMail { get; set; }
        public string citizenship { get; set; }
        public int? residency { get; set; }
        public string reCountry { get; set; }
        public string reAddress { get; set; }
        public string inn { get; set; }
        public string pUSeries { get; set; }
        public string pUNumber { get; set; }
        public string pUIssuedWho { get; set; }
        public DateTime? pUIssuedWhen { get; set; }
        public string pFSeries { get; set; }
        public string pFNumber { get; set; }
        public DateTime? pFIssuedDate { get; set; }
        public DateTime? pFValidity { get; set; }
        public string buisNumberRegistration { get; set; }
        public DateTime? buisDateRegistration { get; set; }
        public string buisNumberPayer { get; set; }
        public string buisSertNumberPayer { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }
        public int? typeVAT { get; set; }
        public string reCity { get; set; }
        public string faCountry { get; set; }
        public string faCity { get; set; }
        public string faAddress { get; set; }
        public int? banAccId { get; set; }
        public int? faRegion { get; set; }
        public string lang { get; set; }
        public int? reRegion { get; set; }
        public string leCountry { get; set; }
        public int? leRegion { get; set; }
        public string leCity { get; set; }
        public string leAddress { get; set; }
        public string lePostIndex { get; set; }

        public BankAccount banAcc { get; set; }
        public Country citizenshipNavigation { get; set; }
        public Customer cust { get; set; }
        public Person custNavigation { get; set; }
        public Country faCountryNavigation { get; set; }
        public Region faRegionNavigation { get; set; }
        public Lang langNavigation { get; set; }
        public Region leRegionNavigation { get; set; }
        public Country reCountryNavigation { get; set; }
        public Region reRegionNavigation { get; set; }
        public ResidentType residencyNavigation { get; set; }
        public SexType sexNavigation { get; set; }
        public AnketaStatus statusNavigation { get; set; }
        public TypeVAT typeVATNavigation { get; set; }
    }
}
