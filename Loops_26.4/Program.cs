using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_26._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 99; i >= 0; i -= 11)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
