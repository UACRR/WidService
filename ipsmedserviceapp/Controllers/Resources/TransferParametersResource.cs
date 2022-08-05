using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Controllers.Resources
{
    public class TransferParametersResource
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTill { get; set; }
        public int OldRightholderId { get; set; }
        public int LegalBasis { get; set; }
        public List<TransferedObjectResource> ObjectsRightList { get; set; } = new List<TransferedObjectResource>();
    }

    public class TransferedObjectResource
    {
        public int ObjId { get; set; }
        public int? CRightId { get; set; }
        public List<NewRightholderResource> NewRightholderList { get; set; } = new List<NewRightholderResource>();
    }

    public class NewRightholderResource
    {
        public int CustId { get; set; }
        public decimal Rate { get; set; }
    }
}
