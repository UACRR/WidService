using System;
using System.Linq;
using ipsFormsDesign.Data;

namespace IPSModulesLibrary.PartnerList
{
    public class PartnerListModel
    {
        public int? CustId { get; set; }
        public string Name { get; set; }
        public int AgrId { get; set; }
        public string AgrNumber { get; set; }
        public DateTime? AgrDate { get; set; }

        private int? _agrStatus;
        public int? AgrStatus
        {
            get => _agrStatus;
            set
            {
                _agrStatus = value;
                if (value.HasValue)
                {
                    StatusName = IpsGlobal.AnketaDictionaties.agreementStatus.First(rec => rec.CodeI == value.Value)?.Name;
                }
            }
        }

        public string StatusName { get; set; }
        public int? ClnCount { get; set; }
        public string INNOKPO { get; set; }
        public string JaCity { get; set; }
        public string AgrCount { get; set; }
        public bool IsMy { get; set; }
    }
}
