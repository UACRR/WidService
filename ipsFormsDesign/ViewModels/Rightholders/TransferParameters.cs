using System;
using System.Collections.Generic;

namespace ipsFormsDesign.ViewModels.Rightholders
{
    public class TransferParameters
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTill { get; set; }
        public int OldRightholderId { get; set; }
        public int LegalBasis { get; set; }
        public List<TransferedObject> ObjectsRightList { get; set; } = new List<TransferedObject>();
    }

    public class TransferedObject
    {
        public int ObjId { get; set; }
        public int? CRightId { get; set; }
        public List<NewRightholder> NewRightholderList { get; set; } = new List<NewRightholder>();
    }

    public class NewRightholder
    {
        public int CustId { get; set; }
        public decimal Rate { get; set; }
    }
}
