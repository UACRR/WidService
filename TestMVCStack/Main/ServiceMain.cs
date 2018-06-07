using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCStack.Main
{
    public class ServiceMain
    {
        class test : IData
        {
            public string field1 { get; set ; }
            public string field2 { get; set ; }
        }
        public IList<IData> getData()
        {
            List<IData> list = new List<IData>();

            list.Add(new test { field1 = "1111", field2 = "222222" });
            list.Add(new test { field1 = "4444", field2 = "222222" });

            return list;
        }
    }
}
