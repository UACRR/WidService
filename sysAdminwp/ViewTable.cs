using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysAdminwp
{
    partial class ViewTable
    {
        public int Code { get; set; }
        public string NameUk { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }

        public ViewTable()
        {
            Code = default(int);
            NameUk = default(string);
            NameRu = default(string);
            NameEn = default(string);
        }
    }
}
