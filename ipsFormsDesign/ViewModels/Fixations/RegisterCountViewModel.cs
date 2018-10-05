using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.ViewModels.Fixations
{
    public class RegisterCountViewModel
    {
        public decimal RegCntId { get; set; }
        public int RegId { get; set; }
        public int RegIitemId { get; set; }
        public int ObjId { get; set; }
        public int CustId { get; set; }
        //public int? CRtype { get; set; }
        //public int? CRkindCode { get; set; }
        public decimal Rate { get; set; }
        public decimal OwnershipRate { get; set; }
        public string Name { get; set; }
        public string CreativeRoles { get; set; }
    }
}
