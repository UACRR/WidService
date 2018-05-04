using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsAnketaRightHolder.Data
{
    public class RightHolderModel
    {
        public RightHolderModel()
        {
            //AgreementAddRh = new HashSet<AgreementAddRh>();
            //AnketaAddNick = new HashSet<AnketaAddNick>();
            //RegisterCount = new HashSet<RegisterCount>();
            //ReqAgreement = new HashSet<ReqAgreement>();
            //TermsOfService = new HashSet<TermsOfService>();
            //TerritoryExclude = new HashSet<TerritoryExclude>();
            //TerritoryInclude = new HashSet<TerritoryInclude>();
        }

        public int CustId { get; set; }
        //public byte? SignP { get; set; }
        //public bool? AroundWord { get; set; }
        //public string InterCode { get; set; }
        //public string InnerCode { get; set; }
        //public int? GetCode { get; set; }

        public CustomerModel Cust { get; set; }
        //public ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        //public ICollection<AnketaAddNick> AnketaAddNick { get; set; }
        //public ICollection<RegisterCount> RegisterCount { get; set; }
        //public ICollection<ReqAgreement> ReqAgreement { get; set; }
        //public ICollection<TermsOfService> TermsOfService { get; set; }
        //public ICollection<TerritoryExclude> TerritoryExclude { get; set; }
        //public ICollection<TerritoryInclude> TerritoryInclude { get; set; }
    }
}
