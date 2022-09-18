using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace CubeOfNumber
{
    internal class Program
    {
        static readonly Calculator calc = new Calculator();
        static string number;

        static void Main(string[] args)
        {
            calc.ErrorAction = PrintError; // sets location adress to the function adress
            calc.ResulatAction = PrintResult;
            calc.ExitAction = PrintExit;
            calc.PrintCubedAction = PrintCubeOfNumber;
            PrintCubeOfNumber();
        }

        private static void PrintCubeOfNumber()
        {
            Console.WriteLine("Insert number:");
            number = Console.ReadLine();
            calc.GetCubeOfNumber(number);
        }

        private static void PrintResult(string result) => Console.WriteLine($"Cube of number {number} is: {result}");

        private static void PrintError() => Console.WriteLine("Incorrect input!");

        private static void PrintExit() => Console.WriteLine("Finished.");
    }
}
