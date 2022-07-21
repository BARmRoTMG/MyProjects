﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Beverages;

namespace VendingMachine
{
    public class VendingMachine
    {
        bool isRunning = false;

        IBeverage[] _beverages;
        public IBeverage[] Beverages { get { return _beverages; } set { _beverages = value; } }

        public VendingMachine(params IBeverage[] beverages)
        {
            _beverages = beverages;
        }

        public void Prepare(string name)
        {
            for (int i = 0; i < _beverages.Length; i++)
            {
                if (_beverages[i].Name == name)
                {
                    _beverages[i].Prepare();
                    break;
                }
            }
        }

        public void Start()
        {
            int answer;
            isRunning = true;

            Console.WriteLine("Welcome to my vending machine!\nPlease choose your drink of choice from the following options:");
            Console.WriteLine("-------------");

            while (isRunning)
            {
                Coffee coffee = new Coffee(Size.Small, 5);
                Tea tea = new Tea(Size.Small, 3);
                HotChocolate hotChocolate = new HotChocolate(Size.Small, 5);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1) Coffee\n2) Tea\n3)Hot Chocolate");
                bool bAnswer = int.TryParse(Console.ReadLine(), out answer);

                if (bAnswer)
                {
                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine("Please choose cup size:\nSmall / Medium / Large");
                            string cupSize = Console.ReadLine();
                            if (cupSize == "small" || cupSize == "Small")
                            {
                                coffee.Size = Size.Small;
                            } else if (cupSize == "medium" || cupSize == "Medium")
                            {
                                coffee.Size = Size.Medium;
                                coffee.Price++;
                            } else if (cupSize == "large" || cupSize == "Large")
                            {
                                coffee.Size = Size.Large;
                                coffee.Price += 2;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Please use correct syntax!");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Please choose cup size:\nSmall / Medium / Large");
                            cupSize = Console.ReadLine();
                            if (cupSize == "small" || cupSize == "Small")
                            {
                                tea.Size = Size.Small;
                            }
                            else if (cupSize == "medium" || cupSize == "Medium")
                            {
                                tea.Size = Size.Medium;
                                tea.Price++;
                            }
                            else if (cupSize == "large" || cupSize == "Large")
                            {
                                tea.Size = Size.Large;
                                tea.Price += 2;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Please use correct syntax!");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Please choose cup size:\nSmall / Medium / Large");
                            cupSize = Console.ReadLine();
                            if (cupSize == "small" || cupSize == "Small")
                            {
                                hotChocolate.Size = Size.Small;
                            }
                            else if (cupSize == "medium" || cupSize == "Medium")
                            {
                                hotChocolate.Size = Size.Medium;
                                hotChocolate.Price++;
                            }
                            else if (cupSize == "large" || cupSize == "Large")
                            {
                                hotChocolate.Size = Size.Large;
                                hotChocolate.Price += 2;
                            } else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Please use correct syntax!");
                            }
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("We don't have that drink!");
                            break;
                    }
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please insert valid input, Try again!");
                }

                if (answer == 1)
                {
                    coffee.Prepare();
                    Console.WriteLine(coffee.ToString());
                }
            }
        }
    }
}
