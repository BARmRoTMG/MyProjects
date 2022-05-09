using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Methods_9._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee employee = new Employee();

            //do
            //{
            //    Console.Write("Please enter your hourly salary: ");
            //}
            //while (!double.TryParse(Console.ReadLine(), out employee._hourlySalary) || employee._hourlySalary <= 0);

            //do
            //{
            //    Console.Write("Please enter your total hours: ");
            //}
            //while (!double.TryParse(Console.ReadLine(), out employee._totalHours) || employee._totalHours <= 0);

            //Console.WriteLine("Your salary is " + employee.calculateSalary());








            //Item item1 = new Item(0, 0);
            //Item item2 = new Item(0, 0);

            //do
            //{
            //    Console.Write( "Enter base price for the first item: ");
            //}
            //while (!int.TryParse(Console.ReadLine(), out item1._basePrice) || item1._basePrice <= 0);

            //do
            //{
            //    Console.Write("Enter amount of discount for the first item: ");
            //}
            //while (!int.TryParse(Console.ReadLine(), out item1._discountPrecentage) || item1._discountPrecentage <= 0);

            //do
            //{
            //    Console.Write("Enter base price for the second item: ");
            //}
            //while (!int.TryParse(Console.ReadLine(), out item2._basePrice) || item2._basePrice <= 0);

            //do
            //{
            //    Console.Write("Enter amount of discount for the second item: ");
            //}
            //while (!int.TryParse(Console.ReadLine(), out item2._discountPrecentage) || item2._discountPrecentage <= 0 || item2._discountPrecentage >= 100);



            //Console.WriteLine("First item after discount is " + item1.calculatePrice() + "$, second item is " + item2.calculatePrice() + "$");




            Circle circl1 = new Circle("Uranus", "Gray", 15);
            Circle circl2 = new Circle("Sun", "Yellow", 25);
            Circle circl3 = new Circle("Mars", "Red", 10);

            circl1.Description();
            circl2.Description();
            circl3.Description();


            Console.ReadKey();
        }      
    }
}
