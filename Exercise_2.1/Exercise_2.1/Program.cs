using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hi, please enter your age: ");
            int userAge;
            double userSalary;

            if (int.TryParse(Console.ReadLine(), out userAge))
            {
                if (userAge >= 18)
                {
                    Console.Write("Enter your monthly salary: ");
                    if (double.TryParse(Console.ReadLine(), out userSalary))
                    {
                        Console.WriteLine("Your salary is: " + userSalary * 0.95);
                    }
                    else
                    {
                        Console.Error.WriteLine("Invalid data type!");
                    }

                } else
                {
                    Console.Write("Enter your monthly salary: ");
                    if (double.TryParse(Console.ReadLine(), out userSalary))
                    {
                        Console.WriteLine("Your salary is: " + userSalary);
                    }
                    else
                    {
                        Console.Error.WriteLine("Invalid data type!");
                    }
                }
            } 
            else
            {
                Console.Error.WriteLine("Invalid data type!");
            }

            Console.ReadKey();
        }
    }
}

