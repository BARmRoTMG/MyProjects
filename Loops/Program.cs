using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            int sum = 0;
             
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter a number: ");
                num = int.Parse(Console.ReadLine());
                sum += num;
            }

            sum = sum / 10;
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
