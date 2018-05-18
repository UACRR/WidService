using System;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        class Data
        {
            public string Addr1 { get; set; }
            public int Ind1 { get; set; }
            public string Addr2 { get; set; }
            public int Ind2 { get; set; }
        }
        interface IData
        {
            string Addr { get; set; }
            int Ind { get; set; }
        }

        static void Main(string[] args)
        {
            Data test = new Data { Ind1 = 1, Ind2 = 10, Addr1 = "AAAAAA", Addr2 = "BBBBB" };

            dynamic test01 = new Data { Ind1 = 1, Ind2 = 10, Addr1 = "AAAAAA", Addr2 = "BBBBB" }; 
            var test0101 = tes  

                (
                    Addr: Addr1,
                    Ind: Ind1
                );


            Console.WriteLine($"Addr1={test01.Addr} --- Ind1 = {test01.Ind }");

            IData test02 = new RefData<Data>(test, new[] { "Addr2", "Ind2" });
            Console.WriteLine($"Addr1={test02.Addr} --- Ind1 = {test02.Ind }");

            test01.Ind += 100;
            test01.Addr ="A0A0A0A0";

            Console.WriteLine($"Test: {test.Ind1},{test.Addr1},{test.Ind2},{test.Addr2}");


            Console.ReadKey();
        }
    }
}
