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
            // WHILE LOOP

            //Console.Write("Enter a number: ");
            //int num = int.Parse(Console.ReadLine());

            //int digit = 0;

            //while (num != 0)
            //{
            //    digit += num % 10;
            //    num /= 10;
            //}

            //Console.WriteLine($"The sum of {num} is {digit}.");


            int length = int.Parse(Console.ReadLine());

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
