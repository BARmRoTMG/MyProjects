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






            //Reversing arrays!
            //int[] array1 = new int[5];
            //int[] array2 = new int[5];
            //int count = 4;

            //for (int i = 0; i < array1.Length; i++)
            //{
            //    Console.WriteLine("Enter your grade: ");
            //    if (int.TryParse(Console.ReadLine(), out array1[i]))
            //    {

            //    }
            //    else
            //    {
            //        i--;
            //    }
            //}

            //for (int i = 0; i < array2.Length; i++)
            //{
            //    array2[(array2.Length - 1) - i] = array1[i];
            //}

            //for (int i = 0; i < array2.Length; i++)
            //{
            //    Console.WriteLine(array2[i] + " ");
            //}





            //char[] symetricArray = { 'A', 'B', 'C', 'D', 'E', 'D', 'C', 'B', 'A' };

            //if (IsSymetric(symetricArray))
            //    Console.WriteLine("First array is symetric");
            //else
            //    Console.WriteLine("First array is not symetric");


            //char[] nonSymetricArray = { 'A', 'B', 'R', 'D', 'E', 'D', 'C', 'B', 'A' };

            //if (IsSymetric(nonSymetricArray))
            //    Console.WriteLine("Second array is symetric");
            //else
            //    Console.WriteLine("Second array is not symetric");







            int[] shows = new int[5];
            int userInput;
            int numOfSeats;

            Console.WriteLine("Please enter Show number and amount of tickets to order");
            Console.WriteLine("Enter show number (0 to stop)");

            do
            {
                Console.WriteLine("Enter show number: ");
                while (!int.TryParse(Console.ReadLine(), out userInput) || userInput > 5 || userInput < 0)
                {
                    Console.WriteLine("Show doesn't exist.");
                    Console.WriteLine("Try again.");
                }

                if (userInput == 0)
                    break;

                Console.WriteLine("Enter number of seats: ");
                while (!int.TryParse(Console.ReadLine(), out numOfSeats) || numOfSeats < 0)
                {
                    Console.WriteLine("Invalid seats number.");
                    Console.WriteLine("Try again.");
                }

                shows[userInput - 1] += numOfSeats; // -1 because we the index starts at 0
            } while (true);

            for (int i = 0; i < shows.Length; i++)
            {
                Console.WriteLine($"{shows[i]} tickets purchased for show {i + 1}");
            }
            Console.ReadKey();
        }










        private static bool IsSymetric(char[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                if (arr[i] != arr[arr.Length - 1 - i])
                    return false;
            }

            return true;
        }
    }
}
