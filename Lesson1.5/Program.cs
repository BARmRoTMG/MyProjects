using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // EXERSICE 1 labs 08-10


            //int userNum;
            //int tempNum = 0;
            //int biggestNum = int.MinValue;

            //for (int i = 0; i < 15; i++)
            //{
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.Write("Enter a whole number: ");
            //    bool bUserNum = int.TryParse(Console.ReadLine(), out userNum);

            //    if (bUserNum)
            //    {
            //        if (userNum > biggestNum)
            //        {
            //            tempNum = userNum;
            //        } 
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("Invalid input!");
            //        i--;
            //    }
            //}
            //Console.WriteLine(tempNum);


            // EXERSICE 2


            //int userNum;
            //int negativeNum = 0;
            //string output = "";

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.Write("Enter a whole number: ");
            //    bool bUserNum = int.TryParse(Console.ReadLine(), out userNum);

            //    if (bUserNum)
            //    {
            //        if (userNum < 0)
            //        {
            //            negativeNum = userNum;
            //            output += negativeNum.ToString() + " ";
            //        }
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("Invalid input!");
            //        i--;

            //    }
            //}
            //if (negativeNum == 0)
            //{
            //    Console.WriteLine("No negative numbers.");
            //}
            //else
            //{
            //    Console.WriteLine(output);
            //}


            // EXERCISE 3


            //int input;
            //int sumSingles = 0;
            //int sumScores = 0;

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("Enter number #{0}", (i + 1));
            //    if (int.TryParse(Console.ReadLine(), out input) && (input > 9) && (input < 100))
            //    {
            //        sumSingles += input % 10;
            //        sumScores += input / 10;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Not a 2-digit number.");
            //        i--;
            //    }
            //}
            //Console.WriteLine("The sum of the single digits is " + sumSingles);
            //Console.WriteLine("The sum of the score digits is " + sumScores);


            // TIMES BOARD


            //for (int i = 1; i <= 10; i++)
            //{
            //    for (int j = 1; j <= 10; j++)
            //    {
            //        Console.Write(i * j);
            //        Console.Write("\t");
            //    }
            //    Console.WriteLine(" ");
            //}


            // LOOPS IN LOOPS


            Console.WriteLine("Height of rectangle: ");
            int height = int.Parse(Console.ReadLine());

            Console.WriteLine("Width of rectangle: ");
            int width = int.Parse(Console.ReadLine());

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine(" ");
            } 
            Console.ReadKey();
        }
    }
}