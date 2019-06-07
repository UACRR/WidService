using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysAdminwp
{
    public class ViewTable
    {
        public string Code { get; set; }
        public string NameUk { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        public string VariantUse { get; set; }
        public string Continent { get; set; }
        public string Category { get; set; }
        public string VariantObject { get; set; }
        public string klrCountry { get; set; }
        public string Object { get; set; }

        public ViewTable()
        {
            Code = default(string);
            NameUk = default(string);
            NameRu = default(string);
            NameEn = default(string);
            VariantUse = default(string);
            Continent = default(string);
            Category = default(string);
            VariantObject = default(string);
            klrCountry = default(string);
            Object = default(string);
        }
    }
}
