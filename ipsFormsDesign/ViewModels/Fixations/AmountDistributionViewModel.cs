using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.ViewModels.Fixations
{
    public class AmountDistributionViewModel
    {
        public int Id { get; set; }
        public int LicId { get; set; }
        public int ObjId { get; set; }
        public int CustjId { get; set; }
        public string ObjName { get; set; }
        public string Author { get; set; }
        public string Performer { get; set; }
        public string CustRhName { get; set; }
        public decimal Amount { get; set; }
    }
}
