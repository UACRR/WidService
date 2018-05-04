using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsAnketaRightHolder.Data
{
    public class CompanyModel
    {
        public CompanyModel()
        {
            AnketaCompany = new HashSet<AnketaCompanyModel>();
            //RelEmployee = new HashSet<RelEmployee>();
        }

        public int CustId { get; set; }
        public int Version { get; set; }

        public CustomerModel Cust { get; set; }
        public ICollection<AnketaCompanyModel> AnketaCompany { get; set; }
        //public ICollection<RelEmployee> RelEmployee { get; set; }
    }
}
