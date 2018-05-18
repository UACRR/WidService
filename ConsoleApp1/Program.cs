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



            Console.ReadKey();
        }
    }
}
