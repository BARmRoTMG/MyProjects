using Logic;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Linq;

namespace ConsoleCalculator
{
    internal class Program
    {
        static int counter;
        static void Main(string[] args)
        {
            Calc calc = new Calc();

            Console.WriteLine("Insert U number:");
            var numStr = Console.ReadLine();
            var res = calc.GetRootSquare(numStr);

            Console.WriteLine($"Root square of {numStr} = {res}");


            //Timer timer = new Timer(1000);
            ////timer.Elapsed += Timer_Elapsed;
            //timer.Elapsed += (s, e) => UpdateCounter();
            //timer.Start();

            //List<int> list = new List<int> { 6, 3, 3, 6, 8, 9, 3, 3, 6, 2, 2 };
            //list.Where(n => n > 3).ToList().ForEach(Console.WriteLine);

            //int i = 9;
            //int i2 = 9;
            //int i3 = 9;
            //object obj = null;

            Console.ReadLine();
        }

        //private void Test() => Console.WriteLine("OK");

        private static void UpdateCounter() => Console.WriteLine(counter++);

        //private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    Console.WriteLine(counter++);
        //}
    }
}