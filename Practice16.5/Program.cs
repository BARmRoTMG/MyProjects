using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice16._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 5, 5, 5, 4, 5, 6, 7, 1, 9, 9, 9, 12, 13, 4, 4 };
            //int count = 0;
            //int numOfTrios = 0;

            //Array.Sort(arr);

            //for (int i = 0; i < arr.Length - 1; i++)
            //{
            //    if (arr[i] == arr[i + 1])
            //    {
            //        count++;
            //        if (count == 2)
            //        {
            //            numOfTrios++;
            //            count = 0;
            //        }
            //    }
            //}
            //Console.WriteLine(numOfTrios);








            //int[] shoeSizes = new int[15];
            //int input;

            //Console.WriteLine("Insered purchased shoe size: \n6-14 and 0 to stop.");

            //do
            //{
            //    if (!int.TryParse(Console.ReadLine(), out input) || input == 0)
            //        break;
            //    else if (input < 6 || input > 14)
            //        Console.WriteLine("That size is not available.");
            //    else
            //        shoeSizes[input]++;

            //} while (true);

            //for (int i = 6; i < shoeSizes.Length; i++)
            //{
            //    if (shoeSizes[i] == 0)
            //        Console.WriteLine($"You haven't sold the size: {i}");
            //}







            int[] arr = new int[50];
            int[] positive = new int[50];
            int posCount = 0;
            int negCount = 0;
            int[] negative = new int[50];

            for (int i = 0; i < arr.Length; i += 2)
            {
                positive[i]++;
                posCount++;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0) 
                {
                    negative[i]++;
                    negCount++;
                }
            }

            for (int i = 0; i < positive.Length; i++)
            {
                if (positive[i] > 0)
                    Console.WriteLine(i);
            }

            for (int i = 0; i < negative.Length; i++)
            {
                if (negative[i] > 0)
                    Console.WriteLine(i);
            }

            Console.WriteLine("There are {0} positive numbers.", posCount);
            Console.WriteLine("There are {0} negative numbers.", negCount);
            Console.ReadLine();
        }
    }
}
