using System;
using Logic;

namespace DelegateExcerise
{
    internal class Program
    {
        static GetCubedNumber logic = new GetCubedNumber();

        static string number;

        static void Main(string[] args)
        {
            logic.ErrorAction = PrintError;
            logic.GetCubedNumberAction = PrintResult;
            PrintCubeOfNumber();

            Console.ReadKey();
        }

        private static void PrintCubeOfNumber()
        {
            Console.WriteLine("Insert number: ");
            number = Console.ReadLine();
            logic.GetCubeOfNumber(number);
        }

        private static void PrintResult(string result) => Console.WriteLine($"Cube of number {number} = {result}");

        private static void PrintError()
        {
            Console.WriteLine("Incorrect Input");
            PrintCubeOfNumber();
        }
    }
}
