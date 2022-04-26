using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersice_2._2_BMI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double height;
            double weight;

            Console.Write("Please enter your height in meters: ");

            if  (double.TryParse(Console.ReadLine(), out height))
            {
                Console.Write("Please enter your weight in kg: ");
                if (double.TryParse(Console.ReadLine(), out weight))
                {
                    double BMI = weight / (height * height);

                    if (BMI > 18.5 && BMI < 25)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your BMI is " + BMI + " your weight is normal.");
                    } else if (BMI <= 18.4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your BMI is " + BMI + " you are too skinny.");
                    } else if (BMI >= 25.1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your BMI is " + BMI + " you need to loose some weight.");
                    }

                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine("Invalid data type!");
                }
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine("Invalid data type!");
            }
            Console.ReadKey();
        }
    }
}
