using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormattingAssignment
{
    internal class Program
    {
        private static string _userName;
        private static int _userChoice = 0;
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Product p1 = new Product("iPhone 14", 999.80, 150);
            Product p2 = new Product("AirPods 3", 189.90, 100);
            Product p3 = new Product("Macbook Pro", 9999.99, 200);

            Console.Write("Hello user, please enter your first name: ");
            _userName = Console.ReadLine();

            Console.WriteLine("Hi " + _userName + ", please choose your item of choice.");
            Console.WriteLine("------------1------------");
            Console.WriteLine(p1);
            Console.WriteLine("------------2------------");
            Console.WriteLine(p2);
            Console.WriteLine("------------3------------");
            Console.WriteLine(p3);
            Console.WriteLine("-------------------------");

            Picker();
            MessageBox.Show("Purchase made! Printing Invoice...");

            Console.WriteLine("\n\n--------Invoice--------");
            if (_userChoice == 1)
                Console.WriteLine($"\nCustomer Name: {_userName}\nProduct Name: {p1.ProductName}\nProduct Price: {p1.ProductPrice:C}\nProduct Warranty: {p1.Warranty:D}");
            else if (_userChoice == 2)
                Console.WriteLine($"\nCustomer Name: {_userName}\nProduct Name: {p2.ProductName}\nProduct Price: {p2.ProductPrice:C}\nProduct Warranty: {p2.Warranty:D}");
            else
                Console.WriteLine($"\nCustomer Name: {_userName}\nProduct Name: {p3.ProductName}\nProduct Price: {p3.ProductPrice:C}\nProduct Warranty: {p3.Warranty:D}");

            Console.ReadKey();
        }

        public static void Picker()
        {
            for (int i = 0; i < 1; i++)
            {
                int.TryParse(Console.ReadLine(), out _userChoice);
                switch (_userChoice)
                {
                    case 1:
                        _userChoice = 1;
                        i++;
                        break;
                    case 2:
                        _userChoice = 2;
                        i++;
                        break;
                    case 3:
                        _userChoice = 3;
                        i++;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Put a number between 1-3");
                        i--;
                        break;
                }
            }
        }
    }
}
