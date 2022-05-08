using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Sequence
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int index;

            for (int i = 0; i < 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter an index for Fibonacci Sequence: ");

                if (int.TryParse(Console.ReadLine(), out index))
                {
                    if (index == 0)
                    {
                        Console.WriteLine("0");
                    }
                    else if (index <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Illegal action!");
                        i--;
                    }
                    else
                    {
                        int first = 0, second = 1, third;

                        Console.Write(first + " " + second + " ");

                        for (int j = 2; j < index; j++)
                        {
                            third = first + second;
                            Console.Write(third + " ");
                            first = second;
                            second = third;
                        }
                    }
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input!");
                    i--;
                }
            }               
            Console.ReadKey();
        }
    }
}
