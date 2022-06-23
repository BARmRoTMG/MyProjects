using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOriented
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Bar", 23);
            Person p2 = new Person("Bar", 24);
            bool b = p1.Equals(p2);

            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());
            Console.WriteLine(b);
            Console.ReadKey();
        }
    }
}
