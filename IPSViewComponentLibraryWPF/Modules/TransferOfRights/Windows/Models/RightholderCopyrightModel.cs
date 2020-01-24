using System.Linq;
using ipsFormsDesign.Data;

namespace IPSViewComponentLibraryWPF.Modules.TransferOfRights.Windows.Models
{
    public class RightholderCopyrightModel
    {
        public int CustId { get; set; }
        public string InnerCode { get; set; }
        public string InterCode { get; set; }
        public string Name { get; set; }
        public int CntObj { get; set; }

        private int _custStatus;
        public int CustStatus
        {
            get => _custStatus;
            set
            {
                _custStatus = value;
                if (IpsGlobal.AnketaDictionaties != null)
                {
                    var customerStatus = IpsGlobal.AnketaDictionaties.customerStatus.FirstOrDefault(rec => rec.CodeI == value);
                    CustomerStatusName = customerStatus?.Name;
                }
            }
        }

        public string CustomerStatusName { get; set; }

        private int _rHolderType;
        public int RHolderType
        {
            get => _rHolderType;
            set
            {
                _rHolderType = value;
                if (IpsGlobal.AnketaDictionaties != null)
                {
                    var rholderType = IpsGlobal.AnketaDictionaties.rholderType.FirstOrDefault(rec => rec.CodeI == value);
                    RHolderTypeName = rholderType?.Name;
                }
            }
        }

        public string RHolderTypeName { get; set; }
    }
}
