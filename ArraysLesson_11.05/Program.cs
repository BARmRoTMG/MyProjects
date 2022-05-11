using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysLesson_11._05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = {2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine("Enter a number to check: ");
            //    int input = int.Parse(Console.ReadLine());

            //    if (Array.IndexOf(numbers, input) == -1)
            //    {
            //        Console.WriteLine("not found");
            //    } else
            //    {
            //        Console.WriteLine("found");
            //        break;
            //    }
            //}



            //int[] arr = new int[10];
            //int maxValue = 0;
            //Random r = new Random();

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i] = r.Next(1, 101));
            //    if (arr[i] > maxValue)
            //        maxValue = arr[i];
            //}

            ////Console.WriteLine("The biggest number is " + arr.Max());
            //Console.WriteLine("The biggest number is " + maxValue);





            //  int[] grades = new int[10];
            //  int sum = 0;

            //  for (int i = 0; i < grades.Length; i++)
            //  {
            //      Console.WriteLine("Enter your grade: ");
            //      if (int.TryParse(Console.ReadLine(), out grades[i]) && grades[i] > 0 && grades[i] <= 100)
            //      {
            //          sum += grades[i];
            //      } else
            //      {
            //          Console.WriteLine("That's not a grade!");
            //          i--;
            //      }
            //  }

            //  Console.WriteLine("Your grade avarage is: " + sum / grades.Length);
            ////Console.WriteLine("Your grade avarage is: " + grades.Sum() / grades.Length);
            ///






            //int[] arr = new int[100];

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = 1;
            //}



            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (i % 2 == 0 || i == 0)
            //    {
            //        arr[i] += 2;
            //    }
            //    if (i % 3 == 0 || i == 0)
            //    {
            //        arr[i] += 3;
            //    }
            //    Console.WriteLine(arr[i]);
            //}




            int[] array1 = new int[10];
            int[] array2 = new int[10];

            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine("Enter your grade: ");
                if (int.TryParse(Console.ReadLine(), out array1[i]))
                {
                    array1[i] = array2[i];
                }
                else
                {
                    i--;
                }
            }

            for (int i = 0; i < array2.Length; i++)
            {
                Console.WriteLine(array2[i]);
            }
                Console.ReadKey();
        }
    }
}
