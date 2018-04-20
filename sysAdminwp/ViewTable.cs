using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysAdminwp
{
    public class ViewTable
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
    public class ViewTableExt
    {
        public int Index { get; set; }
        public float Code { get; set; }
        public string NameUk { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }

        public ViewTableExt()
        {
            Index = default(int);
            Code = default(float);
            NameUk = default(string);
            NameRu = default(string);
            NameEn = default(string);
        }
    }
}
