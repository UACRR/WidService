using System;
using System.Linq;
using ipsFormsDesign.Data;

namespace IPSModulesLibrary.RightholdersList
{
    public class RightholdersListModel
    {
        public int CustId { get; set; }
        public short CustStatus { get; set; }
        public short CustType { get; set; }
        public short? AgrStatus { get; set; }
        public string InnerCode { get; set; }
        public string InterCode { get; set; }
        public string Name { get; set; }
        public DateTime? AgreementDate { get; set; }
        public int CntObj { get; set; }
        public float YearProfit { get; set; }

        private short _rHolderType;
        public short RHolderType
        {
            get => _rHolderType;
            set
            {
                _rHolderType = value;
                if (value == 3)
                {
                    RHolderTypeName = IpsGlobal.AnketaDictionaties.rholderType.First(rec => rec.CodeI == 3).Name;
                }
            }
        }

        public string RHolderTypeName { get; set; }
    }
}
