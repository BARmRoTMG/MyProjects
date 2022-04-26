using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter number: ");
            //int userNum = int.Parse(Console.ReadLine());

            //bool isZugi = userNum % 2 == 0;

            //if (isZugi)
            //{
            //    Console.WriteLine("Even number!");
            //} else
            //{
            //    Console.WriteLine("Odd number!");
            //}

            //if (userNum >= 0)
            //{
            //    Console.WriteLine("The number is bigger or equal to 0");
            //}
            //else
            //{
            //    Console.WriteLine("The number is smaller then 0");
            //}

            Console.Write("Enter your grade: ");
            int grade;

            if (int.TryParse(Console.ReadLine(), out grade))
            {
                if (grade >= 0 && grade <100)
                {
                    if (grade > 60)
                    {
                        Console.WriteLine("You've passed!");
                    }
                    else
                    {
                        Console.WriteLine("You've failed!");
                    }
                } else
                {
                    Console.WriteLine("Enter a grade between 1 to 100.");
                }
            }
            else
            {
                Console.WriteLine("Entered invalid data type!");
            }
            Console.ReadKey();
        }
    }
}
