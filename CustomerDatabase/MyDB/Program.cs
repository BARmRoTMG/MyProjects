using System;
using System.Linq;

namespace MyDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContex data = new DataContex();

            data.Customers.ToList().ForEach(c => Console.WriteLine(c.Name));

            Console.ReadKey();
        }
    }
}
