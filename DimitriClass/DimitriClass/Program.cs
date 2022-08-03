using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace DimitriClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calc calc = new Calc();

            Console.WriteLine("Insert number:");
            var numStr = Console.ReadLine();
            var res = calc.GetSquareRoot(numStr);

            Console.WriteLine($"Square root of {numStr} = {res}");
        }
    }
}
