using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Model.SQLViewsData
{
    [NotMapped]
    public class vCustomer
    {
        public int CustId { get; set; }
        public string name { get; set; }
        public string INNOKPO { get; set; }
        public string IPI { get; set; }
        public int ankMy { get; set; }
    }
}
