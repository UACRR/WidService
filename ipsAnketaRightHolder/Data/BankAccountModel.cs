using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsAnketaRightHolder.Data
{
    public class BankAccountModel
    {
        public BankAccountModel()
        {
            AnketaCompany = new HashSet<AnketaCompanyModel>();
            AnketaPerson = new HashSet<AnketaPersonModel>();
        }

        public int BanAccId { get; set; }
        public int? CustId { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public string TransitNumber { get; set; }
        public int? Mfo { get; set; }
        public string MfoName { get; set; }
        public string MfoOkpo { get; set; }

        //public KlR030 CurrencyNavigation { get; set; }
        public CustomerModel Cust { get; set; }
        public ICollection<AnketaCompanyModel> AnketaCompany { get; set; }
        public ICollection<AnketaPersonModel> AnketaPerson { get; set; }
    }
}
