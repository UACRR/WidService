using System;
using System.Collections.Generic;
using System.Text;
using ipsmedserviceapp.Model;

namespace ipsFormsDesign.Interfaces
{
    public class AnketaDictionaties
    {
        public IList<CustomerType> customerType { get; set; }
        public IList<CustomerStatus> customerStatus { get; set; }
        public IList<PositionType> positionType { get; set; }
        public IList<KlR030> klR030 { get; set; }
        public IList<ActivityType> activityType { get; set; }
        public IList<Region> region { get; set; }
        public IList<TypeVat> typeVat { get; set; }
        public IList<ResidentType> residentType { get; set; }
        public IList<SexType> sexType { get; set; }
        public IList<Country> country { get; set; }
        public IList<Lang> lang { get; set; }
        public IList<AnketaStatus> anketaStatus { get; set; }
        public IList<TypePlace> typePlace { get; set;  }
    }
}
