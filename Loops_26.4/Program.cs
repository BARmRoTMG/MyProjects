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
            int numOfStudents = 11;
            int studentChoice;
            int Dev = 0;
            int QA = 0;
            int Consultant = 0;

            for (int i = 1; i < numOfStudents; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Student number " + i + ".");
                Console.WriteLine("Which course would you like to sign to?");
                Console.WriteLine("1. Development course. \n2. QA course \n3. Talk to a consultant");

                int.TryParse(Console.ReadLine(), out studentChoice);

                switch (studentChoice)
                 {
                   case 1:
                        Dev++;
                        break;
                   case 2:
                        QA++;
                        break;
                   case 3:
                        Consultant++;
                        break;
                   default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid answer!");
                        i--;
                        break;
                }
                
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Dev} students would like to take the Dev course, \n{QA} students would like to take the QA course, \n{Consultant} would like to talk to a consultant.");

            Console.ReadKey();
        }
    }
}
