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
            Console.WriteLine("Which course would you like to sign to?");
            Console.WriteLine("1. Development course. \n2. QA course \n3. Talk to a consultant");

            int studentChoice = int.Parse(Console.ReadLine());
            int Dev = 0;
            int QA = 0;
            int Consultant = 0;

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
            }












            bool bStudentChoice = int.TryParse(Console.ReadLine(), out studentChoice);

            while (!bStudentChoice)
            {
                if (bStudentChoice)
                {
                    bStudentChoice = true;
                    StudentRunner();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid data type!");
                }
            }
            Console.ReadKey();
        }
        private static void StudentRunner()
        {
            Console.WriteLine("test");
        }
    }
}
