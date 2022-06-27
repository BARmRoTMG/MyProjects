using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Set s1 = new Set(1, 2, 3, 4);
            //Set s2 = new Set(5, 7, 9, 4, 0);
            //Console.WriteLine(s1);
            //Console.WriteLine(s2);
            //Console.WriteLine("Original Forms UP - After Change DOWN");


            //s1.Union(s2);
            //Console.WriteLine(s1.ToString());

            //s1.Intersect(s2);
            //Console.WriteLine(s1.ToString());

            //s1.Subset(s2);
            //Console.WriteLine(s1.ToString());

            //s1.IsMember(2);
            //Console.WriteLine(s1.ToString());

            //Console.WriteLine(s1.IsMember(2));

            //s1.Insert(5);
            //Console.WriteLine(s1.ToString());

            //s1.Delete(2);
            //Console.WriteLine(s1.ToString());


            Random rnd = new Random();

            Set s1 = new Set();
            Set s2 = new Set();
            Set s3 = new Set();
            Set s4 = new Set();
            Set s5 = new Set();

            for (int i = 0; i < 12; i++)
            {
                int number;
                rnd.Next(0, 1000);
                number = rnd.Next(0, 1000);
                s1.Insert(number);
            }
            for (int i = 0; i < 12; i++)
            {
                int number;
                rnd.Next(0, 1000);
                number = rnd.Next(0, 1000);
                s2.Insert(number);
            }
            for (int i = 0; i < 12; i++)
            {
                int number;
                rnd.Next(0, 1000);
                number = rnd.Next(0, 1000);
                s3.Insert(number);
            }
            for (int i = 0; i < 12; i++)
            {
                int number;
                rnd.Next(0, 1000);
                number = rnd.Next(0, 1000);
                s4.Insert(number);
            }

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            s1.Union(s2);
            Console.WriteLine("After union: " + s1);
            s4.Intersect(s3);
            Console.WriteLine("after intersection:" + s4);


            int numCheck;
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Please enter a number: (Subset Method)");
                numCheck = int.Parse(Console.ReadLine());
                s5.Insert(numCheck);
            }
            bool numCheck2;
            numCheck2 = s1.Subset(s5);
            if (numCheck2 == true)
                Console.WriteLine("The set is subset of set.");
            else 
                Console.WriteLine("The set is not subset of set.");

            numCheck2 = s2.Subset(s5);
            if (numCheck2 == true)
                Console.WriteLine("The set is subset of set.");
            else 
                Console.WriteLine("The set is not subset of set.");


            Console.WriteLine("Enter one number: (IsMember Method)");
            int res = int.Parse(Console.ReadLine());
            numCheck2 = s5.IsMember(res);
            if (numCheck2 == true)
                Console.WriteLine("The number is in the set.");
            else
                Console.WriteLine("The number is not in the set.");



            Console.WriteLine("Enter a number: (Insert Method)");
            int res2 = int.Parse((Console.ReadLine()));
            s5.Insert(res2);
            s2.Insert(res2);
            Console.WriteLine(s5.ToString());
            Console.WriteLine(s2.ToString());
           


            Console.WriteLine("Enter a number: (Delete Method)");
            int res3 = int.Parse(Console.ReadLine());
            s2.Delete(res3);
            s5.Delete(res3);
            Console.WriteLine(s5.ToString());
            Console.WriteLine(s2.ToString());
        }
    }
}
