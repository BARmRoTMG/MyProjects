using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionTirgul
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // EXERCISE 1

            /*
             int age;
             int degree;
             int experience;

             Console.WriteLine("Hello, in order to define which factory you will most fit too, \nplease fill in the following: ");

             Console.WriteLine("Please enter your age: \n1. Between 20 - 24 \n2. Above 25");
             int.TryParse(Console.ReadLine(), out age);

             switch (age)
             {
                 case 1:
                     age = 1;
                     break;
                 case 2:
                     age = 2;
                     break;
                 default:
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine("Thats not one of the options!");
                     break;
             }

             Console.ForegroundColor = ConsoleColor.White;
             Console.WriteLine("Please enter your degree:\n0 - No Degree \n1 - First Degree \n2 - Second Degree)");
             int.TryParse(Console.ReadLine(), out degree);

             switch (degree)
             {
                 case 0:
                     degree = 0;
                     break;
                 case 1:
                     degree = 1;
                     break;
                 case 2:
                     degree = 2;
                     break;
                 default:
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine("Thats not one of the options!");
                     break;
             }

             Console.ForegroundColor = ConsoleColor.White;
             Console.WriteLine("Please enter your experience in years: \n0 - 2 Years or above \n1 - 4 Years or above\n2 - 5 Years or above)");
             int.TryParse(Console.ReadLine(), out experience);

             switch (experience)
             {
                 case 0:
                     experience = 0;
                     break;
                 case 1:
                     experience = 1;
                     break;
                 case 2:
                     experience = 2;
                     break;
                 default:
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine("Thats not one of the options!");
                     break;
             }



             if (age == 1 && degree == 1 && experience == 1)
             {
                 Console.ForegroundColor = ConsoleColor.Green;
                 Console.WriteLine("You have been assigned to work at FACTORY A!");
             }
             else if (age == 2 && experience == 2 && degree == 1)
             {
                 Console.ForegroundColor = ConsoleColor.Green;
                 Console.WriteLine("You can be assigned to work at FACTORY A or FACTORY B!");
             } else if ((age == 2 && degree == 2 && experience == 0) || (age == 2 && degree == 1 && experience == 2))
             {
                 Console.ForegroundColor = ConsoleColor.Green;
                 Console.WriteLine("You have been assigned to work at FACTORY B!");
             } else
             {
                 Console.ForegroundColor = ConsoleColor.Yellow;
                 Console.WriteLine("You do not fit to work in any of our factories!");
             } 
            */


            // EXERCISE 2
            /*
            Console.WriteLine("Enter a number:");       
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a number:");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a number:");
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a number:");
            int num4 = int.Parse(Console.ReadLine());

            if ((num1 + num2) == (num3 + num4) || (num3 + num2) == (num1 + num4) || (num4 + num2) == (num1 + num3))
            {
                Console.WriteLine("Two sets of numbers is equal to the other sets of numbers.");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No two number sets!");
            }
            */


            // EXERCISE 3


            /*
            int osemSUm = 50000;

            Console.WriteLine("Please enter the annual profit number of Osem: ");
            int userInput = int.Parse(Console.ReadLine());

            if (userInput == osemSUm)
            {
                Console.WriteLine("This is equal to the avarage profit.");
            }
            else if (userInput > osemSUm)
                Console.WriteLine("This is more then the avarage profit.");
            else
                Console.WriteLine("This is less then the avarage profit.");
            */


            // EXERCISE 4

            /*
            Random rand = new Random();
            int ageRnd = rand.Next(1910, 2000);

            Console.WriteLine("You were born at " + ageRnd);
            if (ageRnd > 1982)
            {
                Console.WriteLine("You are not old enough to vote!");
            } else
                Console.WriteLine("You can vote!");
            */


            // For Loops 1

            /*
            int userNum;
            int specialNumCount = 0;

            Console.WriteLine("Enter a whole number to check if it is perfect or not: ");
            if (int.TryParse(Console.ReadLine(), out userNum)) 
            {
                for (int i = 1; i < userNum; i++)
                {
                    if(userNum % i == 0)
                    {
                        specialNumCount += i;
                    }
                } 
                if (specialNumCount == userNum)
                    Console.WriteLine("{0} is a perfect number.", userNum);
                else
                    Console.WriteLine("{0} is not a perfect number.", userNum);

            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not a whole number!");
            }
            for (int i = 1; i <= 1000; i++)
            {
                int sum = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        sum += j;
                    }
                }
                if (sum == i)
                {
                    Console.WriteLine($"There are {i} perfect numbers between 1 and 1000.");
                }
            }
            */


            // While Loops 1


            /*
            int maxNum = 9999;
            int currentSum = 0;
            int userInput;

            while (currentSum <= maxNum)
            {
                Console.WriteLine("Enter a number: ");
                int.TryParse(Console.ReadLine(), out userInput);

                currentSum += userInput;

                Console.WriteLine("The total is: {0}", currentSum);

            }

            Console.WriteLine("You have reached 9999!");
            */


            // While Loops 2

            /*
            int numOfFam = 0;
            int numOfBoys = 0;
            int numOfGirls = 0;
            int numOfKids = 0;
            int equalKids = 0;
            int totalKids = 0;

            while(numOfFam < 10)
            {
                Console.ForegroundColor = ConsoleColor.White
                    ;
                Console.WriteLine("Enter number of boys: ");
                bool bBoys = int.TryParse(Console.ReadLine(), out numOfBoys);

                Console.WriteLine("Enter number of girls: ");
                bool bGirls = int.TryParse(Console.ReadLine(), out numOfGirls);

                if (bBoys && bGirls)
                {
                    if (numOfBoys == numOfGirls)
                    {
                        equalKids++;
                    }

                    numOfFam++;

                    numOfKids = numOfBoys + numOfGirls;
                    totalKids += numOfKids;

                    Console.WriteLine($"You have {numOfKids} kids.");
                }        
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input in one or more of the fields.");
                }
            }

            Console.WriteLine($"There are {numOfFam} families,\nand there are {equalKids} families with the same number of boys and girls.\nAnd there is a total of {totalKids} kids.");
            */


            // While Loops 3
            int width = 5;
            int height = 5;

            for (int i = 1; i < width; i++)
            {
                for (int j = 1; j < height; j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine(" ");
                Console.Write(i);
            }

            Console.ReadKey();
        }
    }
}
