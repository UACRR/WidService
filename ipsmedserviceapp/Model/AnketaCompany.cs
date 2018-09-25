using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaCompany
    {
        public int custId { get; set; }
        public int version { get; set; }
        public int? activityCode { get; set; }
        public int status { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string faAddress { get; set; }
        public string jaAddress { get; set; }
        public string okpo { get; set; }
        public DateTime? registrDate { get; set; }
        public int? typeVAT { get; set; }
        public string numberVAT { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }
        public string jaCity { get; set; }
        public string faCity { get; set; }
        public string jaCountry { get; set; }
        public string faCountry { get; set; }
        public int? banAccId { get; set; }
        public int? jaRegion { get; set; }
        public int? faRegion { get; set; }
        public string registrNumber { get; set; }
        public string registrWho { get; set; }
        public string leCity { get; set; }
        public string leCountry { get; set; }
        public string lePostIndex { get; set; }
        public int? leRegion { get; set; }
        public string leAddress { get; set; }

        public ActivityType activityCodeNavigation { get; set; }
        public BankAccount banAcc { get; set; }
        public Company cust { get; set; }
        public Customer custNavigation { get; set; }
        public Country faCountryNavigation { get; set; }
        public Region faRegionNavigation { get; set; }
        public Country jaCountryNavigation { get; set; }
        public Region jaRegionNavigation { get; set; }
        public Country leCountryNavigation { get; set; }
        public Region leRegionNavigation { get; set; }
        public AnketaStatus statusNavigation { get; set; }
        public TypeVAT typeVATNavigation { get; set; }
    }
}
