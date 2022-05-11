using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLior_10._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Car ferrari = new Car("Ferrari", 4, 100);
            //Console.WriteLine($"You have a {ferrari._carType} with {ferrari._wheels} and {ferrari._fuel}% fuel level.");
            //ferrari.startEngine();

            //for (int i = 0; i < 1; i++)
            //{
            //    Console.WriteLine("Would you like to box and replace your wheels? (Y/N)");
            //    string userInput = Console.ReadLine();
            //    if(userInput == "Y" || userInput == "y")
            //    {
            //        Console.WriteLine("We will receive you in this lap.");
            //        Console.WriteLine("Box box box...");
            //        ferrari.pitStop();
            //    } else if (userInput == "N" || userInput == "n")
            //    {
            //        Console.WriteLine("Ok we are staying out.");
            //    } else
            //    {
            //        Console.WriteLine("No right action was taken.");
            //        i--;
            //    }
            //}

            //Console.WriteLine("We put you on {0} for max speed.", ferrari.wheelType);










            Person per1 = new Person("", 0, 0, "", 0, 0);


            do
            {
                Console.WriteLine("Please enter your name:");
                per1._name = Console.ReadLine();

            } while (!per1._name.All(Char.IsLetter));

            do
            {
                Console.WriteLine("Please enter your age:");                
            } while (!int.TryParse(Console.ReadLine(), out per1._age) || per1._age <= 0 || per1._age >= 101);

            do
            {
                Console.WriteLine("Please enter your social security number: (9 digits only)");
            } while (!int.TryParse(Console.ReadLine(), out per1._socialSecurityNumber) || per1._socialSecurityNumber.ToString().Length > 10 || per1._socialSecurityNumber.ToString().Length < 9);

            do
            {
                Console.WriteLine("Please enter your job:");
                per1._job = Console.ReadLine();

            } while (!per1._job.All(Char.IsLetter));

            do
            {
                Console.WriteLine("Please enter your height (in meters): ");
            } while (!double.TryParse(Console.ReadLine(), out per1._height) || per1._height <= 1 || per1._height > 10);

            do
            {
                Console.WriteLine("Please enter your weight: (in KG)");
            } while (!double.TryParse(Console.ReadLine(), out per1._weight) || per1._weight <= 0 || per1._weight > 200);


            per1.CalculateBMI();

            per1.Description();


            for (int i = 0; i < 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Would you like to change your job? (Y/N)");
                string userInput = Console.ReadLine();
                if (userInput == "Y" || userInput == "y")
                {
                    per1.ChangeJob();
                }
                else if (userInput == "N" || userInput == "n")
                {
                    Console.WriteLine("Copy, you are still a {0}", per1._job);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No right action was taken.");
                    i--;
                }

            }

            per1.Description();
            Console.ReadLine();
        }
    }
}
