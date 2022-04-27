using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopsHomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // EXERCISE 3.1

            //int fact = 1;
            //int number;

            //Console.Write("Enter any number: ");
            //number = int.Parse(Console.ReadLine());

            //for (int i = 1; i <= number; i++)
            //{
            //    fact = fact * i;
            //}

            //Console.Write("Factorial of " + number + " is: " + fact);


            // EXERCISE 3.2

            //int baseN;
            //int power;
            //bool running = true;

            //while (running)
            //{
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.Write("Enter base number: ");
            //    bool BbaseN = int.TryParse(Console.ReadLine(), out baseN);
            //    Console.Write("Enter power number: ");
            //    bool Bpower = int.TryParse(Console.ReadLine(), out power);

            //    if (Bpower && BbaseN)
            //    {
            //        double result = Math.Pow(baseN, power);

            //        Console.ForegroundColor = ConsoleColor.Yellow;
            //        Console.WriteLine($"{baseN} in the power of {power} is: {result}");
            //        running = false;    
            //    }
            //    else
            //    {
            //        running = true;
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("Invalid data type!");
            //    }

            //}


            // EXERCISE 3.3

            Random random = new Random();

            int devBy3 = 0;

            string output = "";

            for (int i = 0; i < 10 && devBy3 < 3; i++)
            {
                //Console.WriteLine(rnd = random.Next(1, 101));
                int rnd = random.Next(1, 101);

                output += " " + rnd;

                if (rnd % 3 == 0)
                {
                    devBy3++;
                }
            }

            if (devBy3 == 3)
            {
                Console.WriteLine(output);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Program Failed.");
            }

            Console.ReadLine();
        }
    }
}
