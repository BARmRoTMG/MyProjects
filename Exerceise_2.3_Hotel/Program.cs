using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exerceise_2._3_Hotel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Hotel Bookings";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to our hotel! Please make your reservation here: ");
            Console.ForegroundColor = ConsoleColor.White;
            
            int roomChoice = 0;
            int numOfNights = 0;
            int breakfast = 0;

            for (int i = 0; i < 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Room of choice: \n1. Regular Room (250 nis per night). \n2. Double Room (400 nis per night). \n3. Suite (600 nis per night)");

                int.TryParse(Console.ReadLine(), out roomChoice);

                switch (roomChoice)
                {
                    case 1:
                        roomChoice = 1;
                        i++;
                        break;
                    case 2:
                        roomChoice = 2;
                        i++;
                        break;
                    case 3:
                        roomChoice = 3;
                        i++;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input!");
                        i--;
                        break;
                }
            }

            for (int i = 0; i < 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("For how many nights would you like to set your reservation for?");

                if (int.TryParse(Console.ReadLine(), out numOfNights))
                {
                    if (numOfNights < 10)
                    {
                        i++;
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Can't book more than 10 nights at the moment!");
                        i--;
                    }
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input!");
                    i--;
                }
            }

            for (int i =0; i < 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Do you want breakfast included? (50 nis per day) \n(Insert 1 for Yes, 2 for No)");

                if (int.TryParse(Console.ReadLine(), out breakfast))
                {
                    if (breakfast == 1)
                    {
                        breakfast = 1;
                        i++;
                    } else if (breakfast == 2)
                    {
                        breakfast = 2;
                        i++;
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Insert 1 OR 2 only!");
                        i--;
                    }

                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input!");
                    i--;
                }
            }

            if (roomChoice == 1 && breakfast == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your reservation has been made! \nA regular room with breakfast included is a total of " + ((250 * numOfNights) + (numOfNights * 50)) + " NIS.");
            } else if (roomChoice == 1 && breakfast == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your reservation has been made! \nA regular room without breakfast is a total of " + 250 * numOfNights + " NIS.");
            }

            if ((roomChoice == 2) && breakfast == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your reservation has been made! \nA double room with breakfast included is a total of " + ((400 * numOfNights) + (numOfNights * 50)) + " NIS.");
            } else if (roomChoice == 2 && breakfast == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your reservation has been made! \nA double room without breakfast is a total of " + 400 * numOfNights + " NIS.");
            }

            if (roomChoice == 3 && breakfast == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your reservation has been made! \nA suite with breakfast included is a total of " + ((600 * numOfNights) + (numOfNights * 50)) + " NIS.");
            } else if (roomChoice == 3 && breakfast == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your reservation has been made! \nA suite room without breakfast is a total of " + 600 * numOfNights + " NIS.");
            }

            Console.ReadKey();
        }
    }
}
