using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AnketaCompany : IAnketaCompany
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
        public int FaRegion { get; set; }
        public string RegistrNumber { get; set; }
        public string RegistrWho { get; set; }

        public ActivityType ActivityCodeNavigation { get; set; }
        public BankAccount BanAcc { get; set; }
        public Company Cust { get; set; }
        public Customer CustNavigation { get; set; }
        public Country FaCountryNavigation { get; set; }
        public Region FaRegionNavigation { get; set; }
        public Country JaCountryNavigation { get; set; }
        public Region JaRegionNavigation { get; set; }
        public AnketaStatus StatusNavigation { get; set; }
        public TypeVat TypeVatNavigation { get; set; }
    }
}

