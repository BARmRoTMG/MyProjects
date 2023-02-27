using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMemory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    Console.WriteLine("OK");
            //    Console.ReadLine();

            //    int i = 6;

            //for (int i = 0; i < 1e6; i++)
            //{
            //    NewMethod();
            //}

            A a1 = new A { Number = 1 };    //0x111
            A a2 = new A { Number = 1 };    //0x222
            A a3 = a1;                      //a3 = 0x111
            a3.Number = 2;                  //a3 = 0x111

            if (a1 == a3)
                Console.WriteLine("0x111 == 0x111");

            a3 = new A { Number = 1 };      //a3 = 0x333
            if (a1 == a3)
                Console.WriteLine("0x111 == 0x333");



            string s1 = "a";    //0x432
            string s2 = "a";

            s2 = "b";

            s1 += "b";  //0x43A
            s1 += "c";  //0x4B2
            s1 += "d";  //0x4C6

            s1 = "abcd";
            s1 = $"{'a'}{'b'}{'c'}{'d'}";

            StringBuilder sb1 = new StringBuilder();
            sb1.Append("a");
            sb1.Append("b");
            sb1.Append("c");

            StringBuilder sb2 = new StringBuilder();
            sb2.Append("a");
            sb2.Append("b");
            sb2.Append("c");

            if (sb1.ToString().Equals(sb2.ToString()))
                Console.WriteLine("GOOD");

            //if (s1 == s2)
            //    Console.WriteLine("OK");

            B b1 = new B { Number = 5 };
            B b2 = new B { Number = 5 };

            if (b1.Equals(b2))
                Console.WriteLine("GREAT");
        }

        private static void NewMethod()
        {
            A a = new A();

            //a = null;
            //delete a;
        }
    }

    class A { public int Number { get; set; } }

    class B
    {
        public int Number { get; set; }
        public override bool Equals(object obj)
        {
            return Number == ((B)obj).Number;

            //if (Number == ((B)obj).Number)
            //    return true;
            //else
            //    return false;
        }
    }
}
