using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOriented
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person p1 = new Person("Bar", 23);
            //Person p2 = new Person("Bar", 24);
            //bool b = p1.Equals(p2);

            //Console.WriteLine(p1.ToString());
            //Console.WriteLine(p2.ToString());
            //Console.WriteLine(b);
            Baller b = new Baller();
            Console.ReadKey();
        }
    }

    public class Baller
    {
        public Baller()
        {
            Console.WriteLine("Enter a day of the week:");
            GetDay((Week) Enum.Parse(typeof(Week), Console.ReadLine()));

            Console.ReadKey();
        }
        public enum Week
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        };

        public string GetDay(Week w)
        {
            switch (w)
            {
                case Week.Sunday:
                case Week.Monday:
                case Week.Tuesday:
                case Week.Wednesday:
                    return "WEEK DAY";
                case Week.Thursday:
                case Week.Friday:
                case Week.Saturday:
                    return "WEEKEND!!!";
                default:
                    return "Invalid day of the week, please use 1-7.";
                    break;
            }
        }
    }
}
