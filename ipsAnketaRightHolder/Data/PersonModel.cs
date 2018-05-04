using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsAnketaRightHolder.Data
{
    public class PersonModel
    {
        public PersonModel()
        {
            AnketaPerson = new HashSet<AnketaPersonModel>();
        }

        public int CustId { get; set; }
        public int Version { get; set; }

        public CustomerModel Cust { get; set; }
        public ICollection<AnketaPersonModel> AnketaPerson { get; set; }
    }
}
