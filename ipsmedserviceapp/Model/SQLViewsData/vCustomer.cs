using System.ComponentModel.DataAnnotations.Schema;

namespace ipsmedserviceapp.Model.SQLViewsData
{
    [NotMapped]
    public class vCustomer
    {
        public int CustId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string INNOKPO { get; set; }
        public string IPI { get; set; }
        public int AnkMy { get; set; }

    }
}
