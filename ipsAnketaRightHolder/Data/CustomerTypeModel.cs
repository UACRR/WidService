using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsAnketaRightHolder.Data
{
    public class CustomerTypeModel
    {
        public CustomerTypeModel()
        {
            Customer = new HashSet<CustomerModel>();
            //CustomerTypeTr = new HashSet<CustomerTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<CustomerModel> Customer { get; set; }
        //public ICollection<CustomerTypeTr> CustomerTypeTr { get; set; }
    }
}
