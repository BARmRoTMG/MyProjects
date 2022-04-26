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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to our hotel! Please make your reservation here.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Room of choice: \n1. Regular Room (250 nis per night). \n2. Double Room (400 nis per night). \n3. Suite (600 nis per night)");

            int roomChoice;
            int numOfNights;
            int breakfast;

            if (int.TryParse(Console.ReadLine(), out roomChoice))
            {
                if (roomChoice == 1) //Regular Room
                {
                    Console.WriteLine("For how many nights would you like to set your reservation for?");

                    if (int.TryParse(Console.ReadLine(), out numOfNights))
                    {
                        if (numOfNights < 10)
                        {
                            Console.WriteLine("Do you want breakfast included? (50 nis per day) \n(Insert 1 for Yes, 2 for No)");
                            if (int.TryParse(Console.ReadLine(), out breakfast))
                            {
                                if (breakfast == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Your reservation has been made! \nA regular room with breakfast included is a total of " + ((250 * numOfNights) + (numOfNights * 50)) + " NIS.");
                                }
                                else if (breakfast == 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Your reservation has been made! \nA regular room without breakfast is a total of " + 250 * numOfNights + " NIS.");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("You can only use either 1 or 2.");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid data type!");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can't book more then 10 nights at the moment.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid data type!");
                    }
                } else if (roomChoice == 2) // Double Room
                {
                    Console.WriteLine("For how many nights would you like to set your reservation for?");

                    if (int.TryParse(Console.ReadLine(), out numOfNights))
                    {
                        if (numOfNights < 10)
                        {
                            Console.WriteLine("Do you want breakfast included? (50 nis per day) \n(Insert 1 for Yes, 2 for No)");
                            if (int.TryParse(Console.ReadLine(), out breakfast))
                            {
                                if (breakfast == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Your reservation has been made! \nA double room with breakfast included is a total of " + ((400 * numOfNights) + (numOfNights * 50)) + " NIS.");
                                }
                                else if (breakfast == 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Your reservation has been made! \nA double room without breakfast is a total of " + 400 * numOfNights + " NIS.");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("You can only use either 1 or 2.");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid data type!");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can't book more then 10 nights at the moment.");
                        }
                    }
                    } else if (roomChoice == 3) // Suite
                {
                    Console.WriteLine("For how many nights would you like to set your reservation for?");

                    if (int.TryParse(Console.ReadLine(), out numOfNights))
                    {
                        if (numOfNights < 10)
                        {
                            Console.WriteLine("Do you want breakfast included? (50 nis per day) \n(Insert 1 for Yes, 2 for No)");
                            if (int.TryParse(Console.ReadLine(), out breakfast))
                            {
                                if (breakfast == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Your reservation has been made! \nA suite with breakfast included is a total of " + ((600 * numOfNights) + (numOfNights * 50)) + " NIS.");
                                }
                                else if (breakfast == 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Your reservation has been made! \nA suite room without breakfast is a total of " + 600 * numOfNights + " NIS.");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("You can only use either 1 or 2.");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid data type!");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You can't book more then 10 nights at the moment.");
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid room type.");
                }
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid data type!");
            }
            Console.ReadKey();
        }
    }
}
