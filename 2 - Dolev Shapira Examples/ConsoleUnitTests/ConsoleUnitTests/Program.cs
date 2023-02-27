using System;
using System.Threading;

namespace ConsoleUnitTests
{
    //Refactoring
    //Cntr + R + M (Redactor + Method)
    //Cntr + R + R (Redactor + Rename)
    //Cntr + K + C (Key + Comment)
    //Cntr + K + U (Key + Uncomment)
    //Cntr + M + O
    //Cntr + M + P
    //Cntr + K + D (Key + Design)
    //Cntr + K + E
    //Cntr + K + S + T (Key + Surround with + Try/catch)


    //Alt + Enter // Alt + . 
    internal class Program
    {


        static void Main(string[] args)
        {
            if (args[0] == "1")
                GetRootSquare();
            else if (args[0] == "2")
                StartOtherLogic();
            else if (args[0] == "3")
                CheckPerformance();
            else
                return;

            //OtherElse();
            //OtherElse();
            //OtherElse();
            //OtherElse();
        }

        private static void CheckPerformance()
        {
            var count = 1;
            while(true)
            {
                Thread.Sleep(1000);
                Console.WriteLine(count++);
                if (count > 10)
                    break;
            }
        }


        #region Logic
        private static void OtherElse()
        {
            try
            {
                int i = 6;
                var numStr = Console.ReadLine();
                var num = double.Parse(numStr);
                Console.WriteLine(i / num);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void StartOtherLogic()
        {
            Console.WriteLine("Start");
        }

        private static void GetRootSquare()
        {
            Console.WriteLine("Insert U number:");
            var numStr = Console.ReadLine();

            Console.WriteLine($"Root Square of {numStr} = {Math.Sqrt(double.Parse(numStr))}");

            Console.ReadLine();
        } 
        #endregion

        #region Tests
        /// <summary>
        /// This test for stam
        /// </summary>
        /// <param name="i">Number of changes</param>
        static void Test(int i) => Console.WriteLine(i);
        static void Test1(int i) => Console.WriteLine(i);
        static void Test2(int i) => Console.WriteLine(i);
        static void Test3(int i) => Console.WriteLine(i);
        static void Test4(int i) => Console.WriteLine(i);
        static void Test5() { }
        #endregion
    }
}