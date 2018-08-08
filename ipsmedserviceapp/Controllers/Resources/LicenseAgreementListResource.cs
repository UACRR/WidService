using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Controllers.Resources
{
    public class LicenseAgreementListResource
    {
        public List<int> States { get; set; } = new List<int>();
        public int? Status { get; set; }
    }
}
