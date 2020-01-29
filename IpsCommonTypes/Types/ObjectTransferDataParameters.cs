using System;
using System.Collections.Generic;
using System.Text;

namespace IpsCommonTypes.Types
{
    public class ObjectTransferDataParameters
    {
        public int ParentCustId { get; set; }
        public int LegalBasis { get; set; }
        public string UserName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<TransferObject> TransferObjects { get; set; } = new List<TransferObject>();
    }

    public class TransferObject
    {
        public int ObjId { get; set; }
        public int? ParentCRightId { get; set; }
        public decimal RemainderRate { get; set; }
        public int RoleCode { get; set; }
        //public DateTime BeginDate { get; set; }
        //public DateTime? EndDate { get; set; }
        public List<TransferRightholder> TransferRightholders { get; set; } = new List<TransferRightholder>();
    }

    public class TransferRightholder
    {
        public int CustId { get; set; }
        public decimal Rate{ get; set; }
    }
}
