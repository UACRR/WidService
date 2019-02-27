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
        public string RegistrNumber { get; set; }
        public string RegistrWho { get; set; }
        public string LeCity { get; set; }
        public string LeCountry { get; set; }
        public string LePostIndex { get; set; }
        public int? LeRegion { get; set; }
        public string LeAddress { get; set; }

        public virtual ActivityType ActivityCodeNavigation { get; set; }
        public virtual BankAccount BanAcc { get; set; }
        public virtual Company Cust { get; set; }
        public virtual Customer CustNavigation { get; set; }
        public virtual Country FaCountryNavigation { get; set; }
        public virtual Region FaRegionNavigation { get; set; }
        public virtual Country JaCountryNavigation { get; set; }
        public virtual Region JaRegionNavigation { get; set; }
        public virtual Country LeCountryNavigation { get; set; }
        public virtual Region LeRegionNavigation { get; set; }
        public virtual AnketaStatus StatusNavigation { get; set; }
        public virtual TypeVat TypeVatNavigation { get; set; }
    }
}

