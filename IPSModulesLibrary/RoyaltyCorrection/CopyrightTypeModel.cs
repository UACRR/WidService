using System;
using System.Linq;
using ipsFormsDesign.Data;

namespace IPSModulesLibrary.RoyaltyCorrection
{
    public class CopyrightTypeModel
    {
        private int _kindcode;
        public int Kindcode
        {
            get => _kindcode;
            set
            {
                _kindcode = value;
                TypeName = IpsGlobal.AnketaDictionaties.copyrightKind?.SingleOrDefault(rec => rec.CodeI == value)?.Name;
            }
        }
        public DateTime DateWork { get; set; }
        public string TypeName { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public bool IsSelected { get; set; }

    }
}
